using UnityEngine;

public class TactileTile : MonoBehaviour
{
    const int LABEL_NUMBER_WIDTH = 24;
    const int LABEL_NUMBER_HEIGHT = 40;

    static int[,,]  DigitLookup = new int[LABEL_NUMBER_WIDTH,LABEL_NUMBER_HEIGHT,10];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeLookup()
    {
        for(int i = 0; i < LABEL_NUMBER_HEIGHT; ++i)
        {
            DigitLookup[0,i,0] = 1;
            DigitLookup[LABEL_NUMBER_WIDTH-1,i,0] = 1;
            DigitLookup[(LABEL_NUMBER_WIDTH/2),i,1] = 1;
            DigitLookup[(LABEL_NUMBER_WIDTH/2)+1,i,1] = 1;

            DigitLookup[0,i,2] = 1;
            DigitLookup[LABEL_NUMBER_WIDTH-1,i,2] = 1;
            
            DigitLookup[0,i,3] = 1;
            DigitLookup[LABEL_NUMBER_WIDTH-1,i,3] = 1;
            
            DigitLookup[LABEL_NUMBER_WIDTH-1,i,4] = 1;

            DigitLookup[0,i,5] = 1;
            DigitLookup[LABEL_NUMBER_WIDTH-1,i,5] = 1;

            DigitLookup[0,i,6] = 1;
            DigitLookup[LABEL_NUMBER_WIDTH-1,i,6] = 1;

            DigitLookup[LABEL_NUMBER_WIDTH-1,i,7] = 1;

            DigitLookup[0,i,8] = 1;
            DigitLookup[LABEL_NUMBER_WIDTH-1,i,8] = 1;

            DigitLookup[0,i,9] = 1;
            DigitLookup[LABEL_NUMBER_WIDTH-1,i,9] = 1;
        }

        for(int i = 0; i < LABEL_NUMBER_WIDTH; ++i)
        {
            DigitLookup[i,0,0] = 1;
            DigitLookup[i,LABEL_NUMBER_HEIGHT-1,0] = 1;

            DigitLookup[i,0,2] = 1;
            DigitLookup[i,LABEL_NUMBER_HEIGHT-1,2] = 1;
            DigitLookup[i,LABEL_NUMBER_HEIGHT/2,2] = 1;
            
            DigitLookup[i,0,3] = 1;
            DigitLookup[i,LABEL_NUMBER_HEIGHT-1,3] = 1;
            DigitLookup[i,LABEL_NUMBER_HEIGHT/2,3] = 1;
            
            DigitLookup[i,LABEL_NUMBER_HEIGHT/2,4] = 1;

            DigitLookup[i,0,5] = 1;
            DigitLookup[i,LABEL_NUMBER_HEIGHT-1,5] = 1;
            DigitLookup[i,LABEL_NUMBER_HEIGHT/2,5] = 1;
            
            DigitLookup[i,0,6] = 1;
            DigitLookup[i,LABEL_NUMBER_HEIGHT-1,6] = 1;
            DigitLookup[i,LABEL_NUMBER_HEIGHT/2,6] = 1;

            DigitLookup[i,0,7] = 1;

            DigitLookup[i,0,8] = 1;
            DigitLookup[i,LABEL_NUMBER_HEIGHT-1,8] = 1;
            DigitLookup[i,LABEL_NUMBER_HEIGHT/2,8] = 1;
            

            DigitLookup[i,0,9] = 1;
            DigitLookup[i,LABEL_NUMBER_HEIGHT-1,9] = 1;
            DigitLookup[i,LABEL_NUMBER_HEIGHT/2,9] = 1;
        }

        for(int i = LABEL_NUMBER_HEIGHT/2; i < LABEL_NUMBER_HEIGHT; ++i)
        {
             DigitLookup[0,i,9] = 0;
             DigitLookup[0,i,5] = 0;
             DigitLookup[0,i,3] = 0;

             DigitLookup[LABEL_NUMBER_WIDTH-1,i,2] = 0;
        }

        for(int i = 0; i < LABEL_NUMBER_HEIGHT/2; ++i)
        {
            //if(i < (LABEL_NUMBER_HEIGHT/2)-1)
            {
                DigitLookup[0,i,2] = 0;
                DigitLookup[0,i,3] = 0;
            }
            
            DigitLookup[0,i,4] = 1;

            DigitLookup[LABEL_NUMBER_WIDTH-1,i,5] = 0;
            DigitLookup[LABEL_NUMBER_WIDTH-1,i,6] = 0;
        }
    }

    public void GenerateTile(Texture2D tex, float worldWidth, float worldHeight, float baseSize, 
    float tileSize, bool invert, bool scaleQuarter=false, bool writeMM=false, bool castingOption=false, 
    float castingBorderSize=0f, bool castingInvert=false, bool Smooth=false, int SmoothWindow=0)
    {
        InitializeLookup();

        int heightPixels = tex.height;
        int widthPixels = tex.width;

        float castingBase = 0.002f;

        if(scaleQuarter)
        {
            heightPixels = heightPixels / 2;
            widthPixels = widthPixels / 2;
        }

        int castingTrisWidth = 0;
        float sphereWidth = 0;

        if(castingOption)
        {
            //base number of additional triangles on texture size...
            castingTrisWidth = (int)((float)(castingBorderSize / worldWidth) * (float)widthPixels);
            sphereWidth = (castingTrisWidth / 4.0f);    //3.8f
            //Debug.Log(castingTrisWidth);

            heightPixels += (2 * castingTrisWidth);
            widthPixels += (2 * castingTrisWidth);
            
            worldWidth += (2 * castingBorderSize);
            worldHeight += (2 * castingBorderSize);

            /*Vector3[] vertices = new Vector3[(longitudeSegments + 1) * (latitudeSegments + 1)];
            
            int index = 0;

            for (int lat = 0; lat <= latitudeSegments; lat++)
            {
                float latAngle = Mathf.PI / 2 * (lat / (float)latitudeSegments); // Hemisphere, so only PI/2
                float y = Mathf.Sin(latAngle); // y coordinate

                for (int lon = 0; lon <= longitudeSegments; lon++)
                {
                    float lonAngle = 2 * Mathf.PI * (lon / (float)longitudeSegments);
                    float x = Mathf.Cos(lonAngle) * Mathf.Cos(latAngle); // x coordinate
                    float z = Mathf.Sin(lonAngle) * Mathf.Cos(latAngle); // z coordinate

                    vertices[index] = new Vector3(x, y, z) * radius;

                    index++;
                }
            }*/
        }

        int BASE_VERT_OFFSET = widthPixels * heightPixels;// * 2;
        //int BASE_INDEX_OFFSET = tex.width * 12 + tex.height * 12;

        int numVerts = widthPixels * heightPixels * 2;//+ tex.width * 2 + tex.height * 2;
        int numTrianglesIndices = ((widthPixels) * (heightPixels)) * 12 + widthPixels * 12 + heightPixels * 12;
        //Debug.Log(numTrianglesIndices);

        if(writeMM)
        {
            worldWidth *= 1000f;
            worldHeight *= 1000f;
            baseSize *= 1000f;
            tileSize *= 1000f;
        }

        float halfWidth = worldWidth * 0.5f;
        float halfHeight = worldHeight * 0.5f;

        Vector3 currVert = Vector3.zero;

        int[] indices = new int[numTrianglesIndices];

        Vector3 [] verts = new Vector3[numVerts];
        //Vector3 [] normals = new Vector3[numVerts];
        Color[] colors = new Color[numVerts];

        int vertIndex = 0;
        int indexIdx = 0;
        
        string s = tex.name.Substring(1, tex.name.Length-1);
                    
        //Debug.Log(s);

        int HALF_LABEL_BOUNDS_WIDTH = (LABEL_NUMBER_WIDTH * 2 + 6);
        int START_LABEL_HEIGHT = 30;
        int SPACING = 8;

        //bottom
		for(int j = 0; j < heightPixels; j++)
        {
            for(int i = 0; i < widthPixels; i++)
            {
                Color c = Color.white;
                if(castingOption)
                {
                    int wIdx = i;
                    int hIdx = j;

                    bool bothIn = true;

                    if(i > castingTrisWidth && i < widthPixels - castingTrisWidth)
                    {
                        wIdx = wIdx - castingTrisWidth;
                    } 
                    else
                    {
                        bothIn = false;
                    }

                    if(j > castingTrisWidth && j < heightPixels - castingTrisWidth)
                    {
                        hIdx = hIdx - castingTrisWidth;
                    }
                    else
                    {
                        bothIn = false;
                    }

                    if(bothIn)
                    {
                        c = tex.GetPixel(wIdx, hIdx);
                    }
                }
                else
                {
                    c = tex.GetPixel(i, j);
                }

				if(j == 10 && i > 50 && i < widthPixels - 50)
                {
                    currVert.y = 0.0005f;
                }
                else if(j >= START_LABEL_HEIGHT && j < (START_LABEL_HEIGHT + LABEL_NUMBER_HEIGHT) &&
                         i >= (widthPixels / 2) - HALF_LABEL_BOUNDS_WIDTH && i < (widthPixels / 2) + HALF_LABEL_BOUNDS_WIDTH)
                {
                    int hLookup = j - START_LABEL_HEIGHT;
                    int wLookup = (i - ((widthPixels/2)-HALF_LABEL_BOUNDS_WIDTH));

                    if(i >= (widthPixels / 2) - HALF_LABEL_BOUNDS_WIDTH && i < (widthPixels / 2) - HALF_LABEL_BOUNDS_WIDTH + LABEL_NUMBER_WIDTH && s.Length > 0)
                    {
                        //1st digit...
                        int d = int.Parse(s[0].ToString());
                        //Debug.Log(wLookup + ", " + hLookup + ", " + d + " : " + TactileTile.DigitLookup[wLookup,hLookup,d]);

                        if(TactileTile.DigitLookup[wLookup,hLookup,d] > 0)
                        {
                            currVert.y = 0.0005f;
                            //Debug.Log("Yes");
                        }
                        else
                        {
                            currVert.y = 0f;
                        }
                    }
                    else if(i > (widthPixels / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH + SPACING) && 
                    i <= (widthPixels / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*2 + SPACING) && s.Length > 1)
                    {
                        wLookup -= (LABEL_NUMBER_WIDTH + SPACING+1);
                        int d = int.Parse(s[1].ToString());
                        //Debug.Log(wLookup + ", " + hLookup + ", " + d);// + " : " + TactileTile.DigitLookup[wLookup,hLookup,d]);

                        if(DigitLookup[wLookup,hLookup,d] > 0)
                        {
                            currVert.y = 0.0005f;
                        }
                        else
                        {
                            currVert.y = 0f;
                        }
                    }
                    else if(i > (widthPixels / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*2) + SPACING*2 && 
                    i <= (widthPixels / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*3 + SPACING*2) && s.Length > 2)
                    {
                        wLookup -= (LABEL_NUMBER_WIDTH*2 + (SPACING*2)+1);
                        int d = int.Parse(s[2].ToString());
                        //Debug.Log(wLookup + ", " + hLookup + ", " + d);// + " : " + TactileTile.DigitLookup[wLookup,hLookup,d]);

                        if(DigitLookup[wLookup,hLookup,d] > 0)
                        {
                            currVert.y = 0.0005f;
                        }
                        else
                        {
                            currVert.y = 0f;
                        }
                    }
                    else
                    {
                        currVert.y = 0f;
                    }

                }
                else
                {
				    currVert.y = 0f;
                }

                currVert.x = -halfWidth + (((float)i / ((float)widthPixels-1f)) * worldWidth);
                currVert.z = -halfHeight + (((float)j / ((float)heightPixels-1f)) * worldHeight);

                verts[vertIndex] = currVert;
                //normals[vertIndex] = Vector3.up;
                colors[vertIndex] = c;

                if(j < heightPixels-1 && i < widthPixels-1)
                {
                    //Debug.Log(j + " " + i + " " + indexIdx);
                    indices[indexIdx] = vertIndex;
                    indices[indexIdx+1] = vertIndex+1;
                    indices[indexIdx+2] = vertIndex+widthPixels;
                    indices[indexIdx+3] = vertIndex+1;
                    indices[indexIdx+4] = vertIndex+widthPixels+1;
                    indices[indexIdx+5] = vertIndex+widthPixels;
                }
                vertIndex++;
                indexIdx += 6;
				
			}	
		}
		
        for(int j = 0; j < heightPixels; j++)
        {
            for(int i = 0; i < widthPixels; i++)
            {
                Color c = Color.black;
                bool bothIn = true;

                if(castingOption)
                {
                    int wIdx = i;
                    int hIdx = j;

                    if(i > castingTrisWidth && i < widthPixels - castingTrisWidth)
                    {
                        wIdx = wIdx - castingTrisWidth;
                    }
                    else
                    {
                        bothIn = false;
                    }

                    if(j > castingTrisWidth && j < heightPixels - castingTrisWidth)
                    {
                        hIdx = hIdx - castingTrisWidth;
                    }
                    else
                    {
                        bothIn = false;
                    }

                    if(bothIn)
                    {
                        if(Smooth)
                        {
                            c = CalcSmoothColor(wIdx, hIdx, widthPixels, heightPixels, SmoothWindow, tex);
                        }
                        else
                        {
                            c = tex.GetPixel(wIdx, hIdx);
                        }
                        c.g = 0f;
                    }
                    else
                    {
                        //if within hemisphere area...
                        if(CalcCastingSphere(i, j, widthPixels, heightPixels, castingTrisWidth, sphereWidth, out c.r))
                        {
                            c.g = 1f;
                        }
                    }
                }
                else
                {
                    if(Smooth)
                    {
                        c = CalcSmoothColor(i, j, widthPixels, heightPixels, SmoothWindow, tex);
                    }
                    else
                    {
                        c = tex.GetPixel(i, j);
                    }
                }

                float v = 0f;
                if(invert)
                {
                    v = 1.0f - c.r;
                }
                else
                {
                    v = c.r;
                }

                if(castingOption)
                {
                    if(c.g == 1f)
                    {
                        if(castingInvert)
                        {
                            currVert.y = (baseSize) + tileSize * (v);
                        }
                        else
                        {
                            currVert.y = castingBase + (baseSize) + tileSize * (1f-v);
                        }
                    }
                    else
                    {
                        if(bothIn)
                        {
                            if(castingInvert)
                            {
                                currVert.y = (baseSize);
                            }
                            else
                            {
                                currVert.y = castingBase + tileSize * (1f-v);
                            }
                        }
                        else
                        {
                            if(castingInvert)
                            {
                                currVert.y = (baseSize);
                            }
                            else
                            {
                                currVert.y = castingBase + (baseSize) + tileSize * v;
                            }
                        }
                    }
                }
                else
                {
                    currVert.y = (baseSize) + tileSize * v;  //sample y value from the texutre...
                }

                currVert.x = -halfWidth + (((float)i / ((float)widthPixels-1f)) * worldWidth);
                currVert.z = -halfHeight + (((float)j / ((float)heightPixels-1f)) * worldHeight);
                
                verts[vertIndex] = currVert;
                //normals[vertIndex] = Vector3.up;
                colors[vertIndex] = c;

                if(j < heightPixels-1 && i < widthPixels-1)
                {
                    //Debug.Log(j + " " + i + " " + indexIdx);
                    indices[indexIdx] = vertIndex;
                    indices[indexIdx+1] = vertIndex+1;
                    indices[indexIdx+2] = vertIndex+widthPixels;
                    indices[indexIdx+3] = vertIndex+1;
                    indices[indexIdx+4] = vertIndex+widthPixels+1;
                    indices[indexIdx+5] = vertIndex+widthPixels;
                }
                vertIndex++;
                indexIdx += 6;
            }
        }

        //now neede to handle edges...
        //top
        for(int j = 0; j < widthPixels-1; j++)
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
        for(int j = 0; j < widthPixels-1; j++)
        {
            indices[indexIdx] = widthPixels * (heightPixels-1) + j;
            indices[indexIdx+1] = BASE_VERT_OFFSET + widthPixels * (heightPixels-1) + j;
            indices[indexIdx+2] = widthPixels * (heightPixels-1) + j + 1;
            indices[indexIdx+3] = widthPixels * (heightPixels-1) + j + 1;
            indices[indexIdx+4] = BASE_VERT_OFFSET + widthPixels * (heightPixels-1) + j + 1;
            indices[indexIdx+5] = BASE_VERT_OFFSET + widthPixels * (heightPixels-1) + j;
            indexIdx += 6;
        }

        //left
        for(int j = 0; j < heightPixels-1; j++)
        {
            indices[indexIdx] = widthPixels * j;
            indices[indexIdx+1] = BASE_VERT_OFFSET + widthPixels * j;
            indices[indexIdx+2] = widthPixels * (j+1);
            indices[indexIdx+3] = widthPixels * (j+1);
            indices[indexIdx+4] = BASE_VERT_OFFSET + (widthPixels * (j+1));
            indices[indexIdx+5] = BASE_VERT_OFFSET + widthPixels * j;
            indexIdx += 6;
        }

        //right
        for(int j = 0; j < heightPixels-1; j++)
        {
            indices[indexIdx] = widthPixels * j + (widthPixels-1);
            indices[indexIdx+1] = BASE_VERT_OFFSET + widthPixels * j + (widthPixels-1);
            indices[indexIdx+2] = widthPixels * (j+1) + (widthPixels-1);
            indices[indexIdx+3] = widthPixels * (j+1) + (widthPixels-1);
            indices[indexIdx+4] = BASE_VERT_OFFSET + widthPixels * (j+1) + (widthPixels-1);
            indices[indexIdx+5] = BASE_VERT_OFFSET + widthPixels * j + (widthPixels-1);
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

    bool CalcCastingSphere(int i, int j, int widthPixels, int heightPixels, int castingTrisWidth, float sphereWidth, out float heightVal)
    {
        heightVal = 1f;
        
        if(i < castingTrisWidth)
        {
            if(j < castingTrisWidth)
            {
                //check if within circle that is quarter size in radius of the casting with...
                float dist = Vector2.Distance(new Vector2(i,j), new Vector2(castingTrisWidth/2, castingTrisWidth/2));
                if(dist < sphereWidth) {
                    float latAngle = Mathf.PI / 2f * (dist/sphereWidth); // Hemisphere, so only PI/2
                    heightVal = Mathf.Cos(latAngle);
                    return true;
                }
            }
            else if(j > heightPixels-castingTrisWidth)
            {
                float dist = Vector2.Distance(new Vector2(i,j), new Vector2(castingTrisWidth/2, heightPixels-(castingTrisWidth/2)));
                if(dist < sphereWidth) {
                    float latAngle = Mathf.PI / 2f * (dist/sphereWidth); // Hemisphere, so only PI/2
                    heightVal = Mathf.Cos(latAngle);
                    return true;
                }
            }
        }
        else if(i > widthPixels - castingTrisWidth)
        {
            if(j < castingTrisWidth)
            {
                float dist = Vector2.Distance(new Vector2(i,j), new Vector2(widthPixels-(castingTrisWidth/2), castingTrisWidth/2));
                if(dist < sphereWidth) {
                    float latAngle = Mathf.PI / 2f * (dist/sphereWidth); // Hemisphere, so only PI/2
                    heightVal = Mathf.Cos(latAngle);
                    return true;
                }
            }
            else if(j > heightPixels-castingTrisWidth)
            {
                float dist = Vector2.Distance(new Vector2(i,j), new Vector2(widthPixels-(castingTrisWidth/2), heightPixels-(castingTrisWidth/2)));
                if(dist < sphereWidth) {
                    float latAngle = Mathf.PI / 2f * (dist/sphereWidth); // Hemisphere, so only PI/2
                    heightVal = Mathf.Cos(latAngle);
                    return true;
                }
            }
        }

        return false;
    }

    Color CalcSmoothColor(int i, int j, int widthPixels, int heightPixels, int SmoothWindow, Texture2D tex)
    {
        Color c = Color.black;
        Color heightSum = Color.black;
        for(int k = j-SmoothWindow; k <= j+SmoothWindow; ++k)
        {
            for(int l = i-SmoothWindow; l <= i+SmoothWindow; ++l)
            {
                int hIdx = k;
                int wIdx = l;

                if(wIdx < 0)
                {
                    wIdx = 0;
                }

                if(hIdx < 0)
                {
                    hIdx = 0;
                }

                if(wIdx > widthPixels-1)
                {
                    wIdx = widthPixels-1;
                }

                if(hIdx > heightPixels-1)
                {
                    hIdx = heightPixels-1;
                }

                heightSum += tex.GetPixel(wIdx, hIdx);
            }
        }

        c = (heightSum / (float)((SmoothWindow * 2 + 1) * (SmoothWindow * 2 + 1)));

        return c;
    }
}
