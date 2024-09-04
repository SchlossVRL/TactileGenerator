using UnityEngine;

public class TactileTile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateTile(Texture2D tex, float worldWidth, float worldHeight, float baseSize, float tileSize, bool invert)
    {
        int BASE_VERT_OFFSET = tex.width * tex.height;// * 2;
        //int BASE_INDEX_OFFSET = tex.width * 12 + tex.height * 12;

        int numVerts = tex.width * tex.height * 2;//+ tex.width * 2 + tex.height * 2;
        int numTrianglesIndices = ((tex.width) * (tex.height)) * 12 + tex.width * 12 + tex.height * 12;
        //Debug.Log(numTrianglesIndices);

        int[] indices = new int[numTrianglesIndices];

        Vector3 [] verts = new Vector3[numVerts];
        //Vector3 [] normals = new Vector3[numVerts];
        Color[] colors = new Color[numVerts];

        float halfWidth = worldWidth * 0.5f;
        float halfHeight = worldHeight * 0.5f;

        Vector3 currVert = Vector3.zero;
        
        int vertIndex = 0;
        int indexIdx = 0;

        /*for(int j = 0; j < tex.width; ++j)
        {
            Color c = tex.GetPixel(j, 0);
            
            currVert.x = -halfWidth + (((float)j / ((float)tex.width-1f)) * worldWidth);
            currVert.y = 0f;
            currVert.z = -halfHeight;
            verts[vertIndex] = currVert;
            colors[vertIndex] = c;
            vertIndex++;
        }

        for(int j = 0; j < tex.width; ++j)
        {
            Color c = tex.GetPixel(j, tex.height-1);

            currVert.x = -halfWidth + (((float)j / ((float)tex.width-1f)) * worldWidth);
            currVert.y = 0f;
            currVert.z = halfHeight;
            verts[vertIndex] = currVert;
            colors[vertIndex] = c;
            vertIndex++;
        }

        for(int j = 0; j < tex.height; ++j)
        {
            Color c = tex.GetPixel(0, j);

            currVert.x = -halfWidth;
            currVert.y = 0f;
            currVert.z = -halfHeight + (((float)j / ((float)tex.height-1f)) * worldHeight);
            verts[vertIndex] = currVert;
            colors[vertIndex] = c;
            vertIndex++;
        }

        for(int j = 0; j < tex.height; ++j)
        {
            Color c = tex.GetPixel(tex.width-1, j);

            currVert.x = halfWidth;
            currVert.y = 0f;
            currVert.z = -halfHeight + (((float)j / ((float)tex.height-1f)) * worldHeight);
            verts[vertIndex] = currVert;
            colors[vertIndex] = c;
            vertIndex++;
        }*/

		for(int j = 0; j < tex.height; j++)
        {
            for(int i = 0; i < tex.width; i++)
            {
				Color c = tex.GetPixel(i, j);
				currVert.y = 0f; 
                currVert.x = -halfWidth + (((float)i / ((float)tex.width-1f)) * worldWidth);
                currVert.z = -halfHeight + (((float)j / ((float)tex.height-1f)) * worldHeight);
                verts[vertIndex] = currVert;
                //normals[vertIndex] = Vector3.up;
                colors[vertIndex] = c;

                if(j < tex.height-1 && i < tex.width-1)
                {
                    //Debug.Log(j + " " + i + " " + indexIdx);
                    indices[indexIdx] = vertIndex;
                    indices[indexIdx+1] = vertIndex+1;
                    indices[indexIdx+2] = vertIndex+tex.width;
                    indices[indexIdx+3] = vertIndex+1;
                    indices[indexIdx+4] = vertIndex+tex.width+1;
                    indices[indexIdx+5] = vertIndex+tex.width;
                }
                vertIndex++;
                indexIdx += 6;
				
			}	
		}
		
        for(int j = 0; j < tex.height; j++)
        {
            for(int i = 0; i < tex.width; i++)
            {
                Color c = tex.GetPixel(i, j);
                float v = 0f;
                if(invert)
                {
                    v = 1.0f - c.r;
                }
                else
                {
                    v = c.r;
                }

                currVert.y = (baseSize) + tileSize * v;  //sample y value from the texutre...
                currVert.x = -halfWidth + (((float)i / ((float)tex.width-1f)) * worldWidth);
                currVert.z = -halfHeight + (((float)j / ((float)tex.height-1f)) * worldHeight);
                verts[vertIndex] = currVert;
                //normals[vertIndex] = Vector3.up;
                colors[vertIndex] = c;

                if(j < tex.height-1 && i < tex.width-1)
                {
                    //Debug.Log(j + " " + i + " " + indexIdx);
                    indices[indexIdx] = vertIndex;
                    indices[indexIdx+1] = vertIndex+1;
                    indices[indexIdx+2] = vertIndex+tex.width;
                    indices[indexIdx+3] = vertIndex+1;
                    indices[indexIdx+4] = vertIndex+tex.width+1;
                    indices[indexIdx+5] = vertIndex+tex.width;
                }
                vertIndex++;
                indexIdx += 6;
            }
        }

        //now neede to handle edges...
        //top
        for(int j = 0; j < tex.width-1; j++)
        {
            indices[indexIdx] = j;
            indices[indexIdx+1] = BASE_VERT_OFFSET + j;
            indices[indexIdx+2] = j + 1;
            indices[indexIdx+3] = j + 1;
            indices[indexIdx+4] = BASE_VERT_OFFSET + j + 1;
            indices[indexIdx+5] = BASE_VERT_OFFSET + j;
            indexIdx += 6;
        }
        
        //bottom
        for(int j = 0; j < tex.width-1; j++)
        {
            indices[indexIdx] = tex.width * (tex.height-1) + j;
            indices[indexIdx+1] = BASE_VERT_OFFSET + tex.width * (tex.height-1) + j;
            indices[indexIdx+2] = tex.width * (tex.height-1) + j + 1;
            indices[indexIdx+3] = tex.width * (tex.height-1) + j + 1;
            indices[indexIdx+4] = BASE_VERT_OFFSET + tex.width * (tex.height-1) + j + 1;
            indices[indexIdx+5] = BASE_VERT_OFFSET + tex.width * (tex.height-1) + j;
            indexIdx += 6;
        }

        //left
        for(int j = 0; j < tex.height-1; j++)
        {
            indices[indexIdx] = tex.width * j;
            indices[indexIdx+1] = BASE_VERT_OFFSET + tex.width * j;
            indices[indexIdx+2] = tex.width * (j+1);
            indices[indexIdx+3] = tex.width * (j+1);
            indices[indexIdx+4] = BASE_VERT_OFFSET + (tex.width * (j+1));
            indices[indexIdx+5] = BASE_VERT_OFFSET + tex.width * j;
            indexIdx += 6;
        }

        //right
        for(int j = 0; j < tex.height-1; j++)
        {
            indices[indexIdx] = tex.width * j + (tex.width-1);
            indices[indexIdx+1] = BASE_VERT_OFFSET + tex.width * j + (tex.width-1);
            indices[indexIdx+2] = tex.width * (j+1) + (tex.width-1);
            indices[indexIdx+3] = tex.width * (j+1) + (tex.width-1);
            indices[indexIdx+4] = BASE_VERT_OFFSET + tex.width * (j+1) + (tex.width-1);
            indices[indexIdx+5] = BASE_VERT_OFFSET + tex.width * j + (tex.width-1);
            indexIdx += 6;
        }

        //vertIndex=0;

        /*for(int j = 0; j < tex.height; j++)
        {
            for(int i = 0; i < tex.width; i++)
            {
                if(j < tex.height-1 && i < tex.width-1)
                {
                    normals[vertIndex] = Vector3.Cross(Vector3.Normalize(verts[vertIndex+1] - verts[vertIndex]), Vector3.Normalize(verts[vertIndex+tex.width] - verts[vertIndex+1]));
                }
                vertIndex++;
            }
        }*/

        MeshFilter m = GetComponent<MeshFilter>();
        Mesh newMesh = new Mesh();
        m.mesh = newMesh;
        newMesh.name = tex.name;
        if(m != null)
        {
            newMesh.vertices = verts;
            newMesh.colors = colors;
            //newMesh.normals = normals;
            newMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
            newMesh.SetIndices(indices, MeshTopology.Triangles, 0, false);
            newMesh.RecalculateNormals();
            newMesh.RecalculateTangents();
            newMesh.UploadMeshData(true);
        }

        //DestroyImmediate(tex, true);
    }
}
