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

    public void GenerateTile(Texture2D tex, float worldWidth, float worldHeight, float baseSize, float tileSize)
    {
        const int BASE_VERT_OFFSET = 8;
        const int BASE_INDEX_OFFSET = 30;

        int numVerts = tex.width * tex.height + BASE_VERT_OFFSET;
        int numTrianglesIndices = ((tex.width) * (tex.height)) * 6 + BASE_INDEX_OFFSET;
        //Debug.Log(numTrianglesIndices);

        int[] indices = new int[numTrianglesIndices];

        Vector3 [] verts = new Vector3[numVerts];
        //Vector3 [] normals = new Vector3[numVerts];
        Color[] colors = new Color[numVerts];

        float halfWidth = worldWidth * 0.5f;
        float halfHeight = worldHeight * 0.5f;

        Vector3 currVert = Vector3.zero;
        
        int vertIndex = BASE_VERT_OFFSET;
        int indexIdx = BASE_INDEX_OFFSET;

        for(int i = 0; i < BASE_VERT_OFFSET; ++i)
        {
            verts[i] = Vector3.zero;
        }

        verts[0].x = -halfWidth;
        verts[0].z = -halfHeight;
        verts[1].x = -halfWidth;
        verts[1].y = baseSize;
        verts[1].z = -halfHeight;

        verts[2].x = -halfWidth;
        verts[2].z = halfHeight;
        verts[3].x = -halfWidth;
        verts[3].y = baseSize;
        verts[3].z = halfHeight;

        verts[4].x = halfWidth;
        verts[4].z = halfHeight;
        verts[5].x = halfWidth;
        verts[5].y = baseSize;
        verts[5].z = halfHeight;

        verts[6].x = halfWidth;
        verts[6].z = -halfHeight;
        verts[7].x = halfWidth;
        verts[7].y = baseSize;
        verts[7].z = -halfHeight;

        indices[0] = 0;
        indices[1] = 1;
        indices[2] = 2;
        indices[3] = 3;
        indices[4] = 2;
        indices[5] = 1;

        indices[6] = 2;
        indices[7] = 3;
        indices[8] = 4;
        indices[9] = 5;
        indices[10] = 4;
        indices[11] = 3;

        indices[12] = 4;
        indices[13] = 5;
        indices[14] = 6;
        indices[15] = 7;
        indices[16] = 6;
        indices[17] = 5;

        indices[18] = 6;
        indices[19] = 7;
        indices[20] = 0;
        indices[21] = 1;
        indices[22] = 0;
        indices[23] = 7;

        indices[24] = 0;
        indices[25] = 2;
        indices[26] = 6;
        indices[27] = 4;
        indices[28] = 6;
        indices[29] = 2;

        for(int j = 0; j < tex.height; j++)
        {
            for(int i = 0; i < tex.width; i++)
            {
                Color c = tex.GetPixel(i, j);
                float v = 1.0f - c.r;
                currVert.y = (baseSize - (tileSize)) + tileSize * v;  //sample y value from the texutre...
                currVert.x = -halfWidth + (((float)i / (float)tex.width) * worldWidth);
                currVert.z = -halfHeight + (((float)j / (float)tex.height) * worldHeight);
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
