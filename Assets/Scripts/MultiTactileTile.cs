using UnityEngine;

public class MultiTactileTile : MonoBehaviour
{
    const int LABEL_NUMBER_WIDTH = 12;  //24    //divided both by 2 for bar chart sizes...
    const int LABEL_NUMBER_HEIGHT = 20; //40

    static int[,,]  DigitLookup = new int[LABEL_NUMBER_WIDTH,LABEL_NUMBER_HEIGHT,10];

    static int[,] BLookup = new int[LABEL_NUMBER_WIDTH, LABEL_NUMBER_HEIGHT];
    static int[,] FLookup = new int[LABEL_NUMBER_WIDTH, LABEL_NUMBER_HEIGHT];
    static int[,] PLookup = new int[LABEL_NUMBER_WIDTH, LABEL_NUMBER_HEIGHT];
    static int[,] ELookup = new int[LABEL_NUMBER_WIDTH, LABEL_NUMBER_HEIGHT];

    static int[,] MLookup = new int[LABEL_NUMBER_WIDTH, LABEL_NUMBER_HEIGHT];

    static int[,] SLookup = new int[LABEL_NUMBER_WIDTH, LABEL_NUMBER_HEIGHT];

    static int[,] GLookup = new int[LABEL_NUMBER_WIDTH, LABEL_NUMBER_HEIGHT];

    [SerializeField]
    GameObject CutObject;

    [SerializeField]
    GameObject TilePrefab;

    [SerializeField]
    Texture2D matchTexture;

    [SerializeField]
    int colorMatchIndex;

    [SerializeField]
    float _tolerance;

    [SerializeField]
    TextAsset colorMatches;

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
            BLookup[0, i] = 1;
            ELookup[0, i] = 1;
            FLookup[0, i] = 1;
            PLookup[0, i] = 1;
            MLookup[0, i] = 1;
            MLookup[LABEL_NUMBER_WIDTH-1, i] = 1;

            BLookup[LABEL_NUMBER_WIDTH-1, i] = 0;
            if(i > 3 && i < (LABEL_NUMBER_HEIGHT/2) - 3 || i > (LABEL_NUMBER_HEIGHT/2) + 3 && i < LABEL_NUMBER_HEIGHT-3) {
                BLookup[LABEL_NUMBER_WIDTH-1, i] = 1;
                //MLookup[LABEL_NUMBER_WIDTH-1, i] = 1;
                if(i > 3 && i < (LABEL_NUMBER_HEIGHT/2) - 3)
                {
                    PLookup[LABEL_NUMBER_WIDTH-1, i] = 1;
                }
            }

            if(i > 3 && i < LABEL_NUMBER_HEIGHT-3) {
                GLookup[0, i] = 1;
            }

            if(i > (LABEL_NUMBER_HEIGHT/2) && i < LABEL_NUMBER_HEIGHT) {
                GLookup[LABEL_NUMBER_WIDTH-1, i] = 1;
            }

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

            //if(i < LABEL_NUMBER_WIDTH - 3)
            {
                BLookup[i, 0] = 1;
                PLookup[i, 0] = 1;
                if(i > 3 && i < LABEL_NUMBER_WIDTH - 1) {
                    SLookup[i, 0] = 1;
                    GLookup[i, 0] = 1;
                    if(i > 8) {
                        GLookup[i, LABEL_NUMBER_HEIGHT/2] = 1;
                    }
                    GLookup[i, LABEL_NUMBER_HEIGHT-1] = 1;
                }

                ELookup[i, 0] = 1;
                FLookup[i, 0] = 1;

                BLookup[i, LABEL_NUMBER_HEIGHT/2] = 1;
                PLookup[i, LABEL_NUMBER_HEIGHT/2] = 1;
                
                if(i < LABEL_NUMBER_WIDTH - 3) {
                    ELookup[i, LABEL_NUMBER_HEIGHT/2] = 1;
                    FLookup[i, LABEL_NUMBER_HEIGHT/2] = 1;
                }

                if(i > 3 && i < LABEL_NUMBER_WIDTH - 3) {
                    SLookup[i, LABEL_NUMBER_HEIGHT/2] = 1;
                }

                FLookup[i, LABEL_NUMBER_HEIGHT/2] = 1;

                BLookup[i, LABEL_NUMBER_HEIGHT-1] = 1;
                if(i < LABEL_NUMBER_WIDTH - 3) {
                    SLookup[i, LABEL_NUMBER_HEIGHT-1] = 1;
                }
                ELookup[i, LABEL_NUMBER_HEIGHT-1] = 1;
            }
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

        for(int i = LABEL_NUMBER_WIDTH - 4; i < LABEL_NUMBER_WIDTH; ++i)
        {
            BLookup[i, 0] = 0;
            BLookup[i, LABEL_NUMBER_HEIGHT/2] = 0;
            BLookup[i, LABEL_NUMBER_HEIGHT-1] = 0;

            PLookup[i, 0] = 0;
            PLookup[i, LABEL_NUMBER_HEIGHT/2] = 0;
        }

        BLookup[LABEL_NUMBER_WIDTH - 4, LABEL_NUMBER_HEIGHT-2] = 1;
        BLookup[LABEL_NUMBER_WIDTH - 3, LABEL_NUMBER_HEIGHT-3] = 1;
        BLookup[LABEL_NUMBER_WIDTH - 2, LABEL_NUMBER_HEIGHT-4] = 1;

        BLookup[LABEL_NUMBER_WIDTH - 4, 1] = 1;
        BLookup[LABEL_NUMBER_WIDTH - 3, 2] = 1;
        BLookup[LABEL_NUMBER_WIDTH - 2, 3] = 1;

        PLookup[LABEL_NUMBER_WIDTH - 4, 1] = 1;
        PLookup[LABEL_NUMBER_WIDTH - 3, 2] = 1;
        PLookup[LABEL_NUMBER_WIDTH - 2, 3] = 1;
        
        PLookup[LABEL_NUMBER_WIDTH - 4, (LABEL_NUMBER_HEIGHT/2)-1] = 1;
        PLookup[LABEL_NUMBER_WIDTH - 3, (LABEL_NUMBER_HEIGHT/2)-2] = 1;
        PLookup[LABEL_NUMBER_WIDTH - 2, (LABEL_NUMBER_HEIGHT/2)-3] = 1;

        BLookup[LABEL_NUMBER_WIDTH - 4, (LABEL_NUMBER_HEIGHT/2)+1] = 1;
        BLookup[LABEL_NUMBER_WIDTH - 3, (LABEL_NUMBER_HEIGHT/2)+2] = 1;
        BLookup[LABEL_NUMBER_WIDTH - 2, (LABEL_NUMBER_HEIGHT/2)+3] = 1;

        SLookup[LABEL_NUMBER_WIDTH - 3, (LABEL_NUMBER_HEIGHT/2)+1] = 1;
        SLookup[LABEL_NUMBER_WIDTH - 2, (LABEL_NUMBER_HEIGHT/2)+2] = 1;
        SLookup[LABEL_NUMBER_WIDTH - 1, (LABEL_NUMBER_HEIGHT/2)+3] = 1;

        for(int j = (LABEL_NUMBER_HEIGHT/2)+3; j < (LABEL_NUMBER_HEIGHT)-3; ++j) { 
            SLookup[LABEL_NUMBER_WIDTH - 1, j] = 1;
        }

        for(int j = 4; j < (LABEL_NUMBER_HEIGHT/2)-3; ++j) { 
            SLookup[0, j] = 1;
        }


        SLookup[0, 2] = 1;
        SLookup[1, 1] = 1;
        SLookup[2, 0] = 1;

        GLookup[0, 3] = 1;
        GLookup[1, 2] = 1;
        GLookup[2, 1] = 1;
        GLookup[3, 0] = 1;

        GLookup[0, LABEL_NUMBER_HEIGHT - 4] = 1;
        GLookup[1, LABEL_NUMBER_HEIGHT - 3] = 1;
        GLookup[2, LABEL_NUMBER_HEIGHT - 2] = 1;
        GLookup[3, LABEL_NUMBER_HEIGHT - 1] = 1;

        SLookup[LABEL_NUMBER_WIDTH - 1, LABEL_NUMBER_HEIGHT - 3] = 1;
        SLookup[LABEL_NUMBER_WIDTH - 2, LABEL_NUMBER_HEIGHT - 2] = 1;
        SLookup[LABEL_NUMBER_WIDTH - 3, LABEL_NUMBER_HEIGHT - 1] = 1;

        SLookup[0, (LABEL_NUMBER_HEIGHT/2)-3] = 1;
        SLookup[1, (LABEL_NUMBER_HEIGHT/2)-2] = 1;
        SLookup[2, (LABEL_NUMBER_HEIGHT/2)-1] = 1;

        BLookup[LABEL_NUMBER_WIDTH - 3, (LABEL_NUMBER_HEIGHT/2)-1] = 1;
        BLookup[LABEL_NUMBER_WIDTH - 2, (LABEL_NUMBER_HEIGHT/2)-2] = 1;
        BLookup[LABEL_NUMBER_WIDTH - 1, (LABEL_NUMBER_HEIGHT/2)-3] = 1;

        for(int j = 1; j < (LABEL_NUMBER_HEIGHT/3); ++j) {
            MLookup[j, j] = 1;
            MLookup[LABEL_NUMBER_WIDTH-j, j] = 1;
        }
    }

    public bool GetLetter(int wLookup, int hLookup, char letter, bool flip=false) {
        if(letter == 'b') {
            return (MultiTactileTile.BLookup[wLookup,hLookup] > 0);
        } else if(letter == 'p') {
            return (MultiTactileTile.PLookup[wLookup,hLookup] > 0);
        } else if(letter == 'm') {
            return (MultiTactileTile.MLookup[wLookup,hLookup] > 0);
        } else if(letter == 's') {
            return (MultiTactileTile.SLookup[wLookup,hLookup] > 0);
        } else if(letter == 'e') {
            return (MultiTactileTile.ELookup[wLookup,hLookup] > 0);
        } else if(letter == 'f') {
            return (MultiTactileTile.FLookup[wLookup,hLookup] > 0);
        } else if(letter == 'g') {
            return (MultiTactileTile.GLookup[wLookup,hLookup] > 0);
        }

        return false;
    }

    [ContextMenu("CutBase")]
    void CutBase()
    {
        int newVertCount = 0;
        int newTriCount = 0;
        
        Bounds b = CutObject.GetComponent<MeshRenderer>().bounds;

        Mesh thisM = GetComponent<MeshFilter>().sharedMesh;

        Vector3 [] verts = thisM.vertices;
        int [] indices = thisM.triangles;

        Vector3 bMax = b.max;

        Vector3 vCenterBounds = b.center;
        vCenterBounds.y += (b.extents.y + 0.001f);

        string t = colorMatches.text;
        string[] lineSeparators = new string[] { "\r\n", "\n" };
        string[] lines = t.Split(lineSeparators, System.StringSplitOptions.None);

        int numObjects = lines.Length;
        Color32[] colorLookup = new Color32[numObjects];

        for(int i = 0; i < numObjects; ++i)
        {
            string[] vals = lines[i].Split(',');
            string numString = vals[3].Substring(1,vals[3].Length-1);
            colorLookup[i] = new Color32((byte)int.Parse(vals[0]), (byte)int.Parse(vals[1]), (byte)int.Parse(vals[2]), 255);
        }
        
        for(int i = 0; i < indices.Length; i+=3)
        {
            int numAbove = 0;

            int index1 = indices[i];
            int index2 = indices[i+1];
            int index3 = indices[i+2];

            int i1x = indices[i] % matchTexture.width;
            int i1y = indices[i] / matchTexture.width;

            int i2x = indices[i+1] % matchTexture.width;
            int i2y = indices[i+1] / matchTexture.width;

            int i3x = indices[i+2] % matchTexture.width;
            int i3y = indices[i+2] / matchTexture.width;

            Color m1 = matchTexture.GetPixel(i1x, i1y);
            Color m2 = matchTexture.GetPixel(i2x, i2y);
            Color m3 = matchTexture.GetPixel(i3x, i3y);
            
            Vector4 d1 = m1;
            Vector4 d2 = m2;
            Vector4 d3 = m3;

            int matchIndex1 = -1;
            int matchIndex2 = -1;
            int matchIndex3 = -1;

            float minMatchDist1 = 9999f;
            float minMatchDist2 = 9999f;
            float minMatchDist3 = 9999f;

            for(int p = 0; p < colorLookup.Length; ++p)
            {
                float dist1 = Vector4.Distance(d1, (Color)colorLookup[p]);
                if(dist1 < minMatchDist1)
                {
                    minMatchDist1 = dist1;
                    matchIndex1 = p;
                }

                float dist2 = Vector4.Distance(d2, (Color)colorLookup[p]);
                if(dist2 < minMatchDist2)
                {
                    minMatchDist2 = dist2;
                    matchIndex2 = p;
                }

                float dist3 = Vector4.Distance(d3, (Color)colorLookup[p]);
                if(dist3 < minMatchDist3)
                {
                    minMatchDist3 = dist3;
                    matchIndex3 = p;
                }
            }

            Vector3 v1 = verts[indices[i]];
            Vector3 v2 = verts[indices[i+1]];
            Vector3 v3 = verts[indices[i+2]];

            if(matchIndex1 == colorMatchIndex)
            //if(dist1 < _tolerance)
            //if(v1.y > bMax.y)
            {
                numAbove++;
            }

            if(matchIndex2 == colorMatchIndex)
            //if(dist2 < _tolerance)
            //if(v2.y > bMax.y)
            {
                numAbove++;
            }

            if(matchIndex3 == colorMatchIndex)
            //if(dist3 < _tolerance)
            //if(v3.y > bMax.y)
            {
                numAbove++;
            }

            if(matchIndex1 == colorMatchIndex || matchIndex2 == colorMatchIndex || matchIndex3 == colorMatchIndex)
            //if(dist1 < _tolerance || dist2 < _tolerance || dist3 < _tolerance)
            //if(v1.y > bMax.y || v2.y > bMax.y || v3.y > bMax.y)
            {

                if(numAbove < 4)
                {
                    if(numAbove == 1 || numAbove == 2)
                    {
                        newTriCount+=3;
                        newVertCount+=3;
                    }
                    else
                    {
                        newTriCount+=6;
                        newVertCount+=6;
                    }
                }
            }
        }

        Vector3[] newVertices = new Vector3[newVertCount];
        int[] newIndices = new int[newTriCount];
        Color[] newColors = new Color[newVertCount];

        Color c = Color.white;
        
        int iIndex = 0;
        int vCount = 0;

        for(int i = 0; i < indices.Length; i+=3)
        {
            int numAbove = 0;

            int index1 = indices[i];
            int index2 = indices[i+1];
            int index3 = indices[i+2];

            int i1x = indices[i] % matchTexture.width;
            int i1y = indices[i] / matchTexture.width;

            int i2x = indices[i+1] % matchTexture.width;
            int i2y = indices[i+1] / matchTexture.width;

            int i3x = indices[i+2] % matchTexture.width;
            int i3y = indices[i+2] / matchTexture.width;

            Color m1 = matchTexture.GetPixel(i1x, i1y);
            Color m2 = matchTexture.GetPixel(i2x, i2y);
            Color m3 = matchTexture.GetPixel(i3x, i3y);
            
            Vector4 d1 = m1;
            Vector4 d2 = m2;
            Vector4 d3 = m3;

            int matchIndex1 = -1;
            int matchIndex2 = -1;
            int matchIndex3 = -1;

            float minMatchDist1 = 9999f;
            float minMatchDist2 = 9999f;
            float minMatchDist3 = 9999f;

            for(int p = 0; p < colorLookup.Length; ++p)
            {
                float dist1 = Vector4.Distance(d1, (Color)colorLookup[p]);
                if(dist1 < minMatchDist1)
                {
                    minMatchDist1 = dist1;
                    matchIndex1 = p;
                }

                float dist2 = Vector4.Distance(d2, (Color)colorLookup[p]);
                if(dist2 < minMatchDist2)
                {
                    minMatchDist2 = dist2;
                    matchIndex2 = p;
                }

                float dist3 = Vector4.Distance(d3, (Color)colorLookup[p]);
                if(dist3 < minMatchDist3)
                {
                    minMatchDist3 = dist3;
                    matchIndex3 = p;
                }
            }
            
            //instead of relaying on the tolerance check, check if any color is closest to the match, vs. other colors...


            Vector3 v1 = verts[indices[i]];
            Vector3 v2 = verts[indices[i+1]];
            Vector3 v3 = verts[indices[i+2]];
            
            if(matchIndex1 == colorMatchIndex)
            //if(v1.y > bMax.y)
            //if(dist1 < _tolerance)
            {
                numAbove++;
            }

            if(matchIndex2 == colorMatchIndex)
            //if(v2.y > bMax.y)
            //if(dist2 < _tolerance)
            {
                numAbove++;
            }

            if(matchIndex3 == colorMatchIndex)
            //if(dist3 < _tolerance)
            //if(v3.y > bMax.y)
            {
                numAbove++;
            }

            if(matchIndex1 == colorMatchIndex || matchIndex2 == colorMatchIndex || matchIndex3 == colorMatchIndex)
            //if(dist1 < _tolerance || dist2 < _tolerance || dist3 < _tolerance)
            //if(v1.y > bMax.y || v2.y > bMax.y || v3.y > bMax.y)
            {
                Vector3 v1New = v1;
                v1New.y = 0f;
                Vector3 v2New = v2;
                v2New.y = 0f;
                Vector3 v3New = v3;
                v3New.y = 0f;

                if(numAbove < 4)
                {
                    if(numAbove == 1)
                    {
                        if(matchIndex1 == colorMatchIndex)
                        //if(dist1 < _tolerance)
                        //if(v1.y > bMax.y)
                        {
                            newVertices[vCount] = v1;
                            newVertices[vCount+1] = v2New;
                            newVertices[vCount+2] = v3New;
                        }
                        else if(matchIndex2 == colorMatchIndex)
                        //else if(dist2 < _tolerance)
                        //else if(v2.y > bMax.y)
                        {
                            newVertices[vCount] = v1New;
                            newVertices[vCount+1] = v2;
                            newVertices[vCount+2] = v3New;            
                        }
                        else if(matchIndex3 == colorMatchIndex)
                        //else if(dist3 < _tolerance)
                        //else if(v3.y > bMax.y)
                        {
                            newVertices[vCount] = v1New;
                            newVertices[vCount+1] = v2New;
                            newVertices[vCount+2] = v3;   
                        }

                        newColors[vCount] = c;
                        newColors[vCount+1] = c;
                        newColors[vCount+2] = c;

                        newIndices[iIndex] = iIndex;
                        newIndices[iIndex+1] = iIndex+1;
                        newIndices[iIndex+2] = iIndex+2;

                        iIndex+=3;
                        vCount+=3;
                    }
                    else if(numAbove == 2)
                    {
                        if(matchIndex1 == colorMatchIndex && matchIndex2 == colorMatchIndex)
                        //if(dist1 < _tolerance && dist2 < _tolerance)
                        //if(v1.y > bMax.y && v2.y > bMax.y)
                        {
                            newVertices[vCount] = v1;
                            newVertices[vCount+1] = v2;
                            newVertices[vCount+2] = v3New;
                        }
                        else if(matchIndex2 == colorMatchIndex && matchIndex3 == colorMatchIndex)
                        //else if(dist2 < _tolerance && dist3 < _tolerance)
                        //else if(v2.y > bMax.y && v3.y > bMax.y)
                        {
                            newVertices[vCount] = v1New;
                            newVertices[vCount+1] = v2;
                            newVertices[vCount+2] = v3;
                        }
                        else if(matchIndex3 == colorMatchIndex && matchIndex1 == colorMatchIndex)
                        //else if(dist3 < _tolerance && dist1 < _tolerance)
                        //else if(v3.y > bMax.y && v1.y > bMax.y)
                        {
                            newVertices[vCount] = v1;
                            newVertices[vCount+1] = v2New;
                            newVertices[vCount+2] = v3;
                        }

                        newColors[vCount] = c;
                        newColors[vCount+1] = c;
                        newColors[vCount+2] = c;

                        newIndices[iIndex] = iIndex;
                        newIndices[iIndex+1] = iIndex+1;
                        newIndices[iIndex+2] = iIndex+2;

                        iIndex+=3;
                        vCount+=3;
                    }
                    else if(numAbove == 3)
                    {
                        newVertices[vCount] = v1;
                        newVertices[vCount+1] = v2;
                        newVertices[vCount+2] = v3;

                        /*Vector3 vNorm1 = Vector3.Normalize(v2-v1);
                        Vector3 vNorm2 = Vector3.Normalize(v2-v3);

                        Vector3 vCross = Vector3.Cross(vNorm1, vNorm2);
                        Vector3 vToMid = Vector3.up;//Vector3.Normalize(vCenterBounds - v2);

                        if(Vector3.Dot(vCross, vToMid) < 0f)
                        {
                            newVertices[vCount] = v1;
                            newVertices[vCount+1] = v3;
                            newVertices[vCount+2] = v2;
                        }
                        else
                        {
                            newVertices[vCount] = v1;
                            newVertices[vCount+1] = v2;
                            newVertices[vCount+2] = v3;
                        }*/

                        newVertices[vCount+3] = v1New;
                        newVertices[vCount+4] = v2New;
                        newVertices[vCount+5] = v3New;

                        newIndices[iIndex] = iIndex;
                        newIndices[iIndex+1] = iIndex+1;
                        newIndices[iIndex+2] = iIndex+2;
                        newIndices[iIndex+3] = iIndex+3;
                        newIndices[iIndex+4] = iIndex+4;
                        newIndices[iIndex+5] = iIndex+5;

                        newColors[vCount] = c;
                        newColors[vCount+1] = c;
                        newColors[vCount+2] = c;
                        newColors[vCount+3] = c;
                        newColors[vCount+4] = c;
                        newColors[vCount+5] = c;

                        iIndex+=6;
                        vCount+=6;  
                    }



                }
            }
        }

        if(TilePrefab != null)
        {
            GameObject newTile = Instantiate(TilePrefab);
            MeshFilter m = newTile.GetComponent<MeshFilter>();
            Mesh newMesh = new Mesh();
            m.sharedMesh = newMesh;
            newMesh.name = "test";
            if(m != null)
            {
                newMesh.vertices = newVertices;
                newMesh.colors = newColors;
                //newMesh.normals = normals;
                newMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
                newMesh.SetIndices(newIndices, MeshTopology.Triangles, 0, false);
                newMesh.RecalculateNormals();
                newMesh.RecalculateTangents();
                newMesh.UploadMeshData(true);
            }
        }

    }

    public void GenerateMultiTile(Texture2D tex, TextAsset textAsset, float worldWidth, float worldHeight, float baseSize,
        float tileSize, bool invert, Color32 matchColor, bool scaleQuarter=false, bool castingOption=false, 
        float castingBorderSize=0f, bool castingInvert=false, bool Smooth=false, int SmoothWindow=0, bool AddCastingDivets=false, bool AddLetter=false, char Letter='b',
        bool makeControl=false, bool doSilicone=false, float castingBase=0.002f, bool addTileBorder=false, int borderTris=0, bool addCustomDivets=false, float divetOffset=0f,
        float divetRadius = 0f, bool barChart=false, bool castingHole = false, bool doColorMatch=false) 
    {
        InitializeLookup();

        int heightPixels = tex.height;
        int widthPixels = tex.width;

        /*if(scaleQuarter)
        {
            heightPixels = heightPixels / 2;
            widthPixels = widthPixels / 2;
        }*/

        string t = textAsset.text;
        string[] lineSeparators = new string[] { "\r\n", "\n" };
        string[] lines = t.Split(lineSeparators, System.StringSplitOptions.None);

        Texture2D[] tileTextures = new Texture2D[lines.Length];
        Color32[] colorLookup = new Color32[lines.Length];

        for(int i = 0; i < lines.Length; ++i)
        {
            string[] vals = lines[i].Split(',');
            string numString = vals[3].Substring(1,vals[3].Length-1);
            colorLookup[i] = new Color32((byte)int.Parse(vals[0]), (byte)int.Parse(vals[1]), (byte)int.Parse(vals[2]), 255);

            Debug.Log(numString);
            
            tileTextures[i] = (Texture2D)Resources.Load("brodatz/D"+numString);
            if(tileTextures[i] != null)
            {
                Debug.Log(tileTextures[i].name);
                Debug.Log(colorLookup[i]);
            }
            else
            {
                Debug.Log("null");
            }
        }
        
        int originalPixelWidth = widthPixels / 3;

        float widthIncrement = worldWidth / (float)widthPixels;
        float heightIncrement = worldHeight / (float)heightPixels;

        int castingTrisWidth = 0;
        int castingTrisHeight = 0;
        float sphereWidth = 0;

        if(castingOption)
        {
            //base number of additional triangles on texture size...
            if(barChart) 
            {
                widthIncrement = (worldWidth / ((float)(widthPixels-1f))) * 3f;
                widthPixels /= 3;
            }

            castingTrisWidth = (int)((float)(castingBorderSize / worldWidth) * (float)widthPixels);
            castingTrisHeight = (int)((float)(castingBorderSize / worldHeight) * (float)heightPixels);
            
            Debug.Log(castingTrisWidth);
            sphereWidth = (castingTrisWidth / 4.5f);    //3.8f
            //Debug.Log(castingTrisWidth);

            heightPixels += (2 * castingTrisWidth);
            widthPixels += (2 * castingTrisWidth);
            
            worldWidth += (2 * castingBorderSize);
            worldHeight += (2 * castingBorderSize);
            
        }
        else
        {
            if(barChart) 
            {
                widthIncrement = (worldWidth / ((float)(widthPixels-1f))) * 3f;// * 0.3333333f;
                widthPixels /= 3;
                
                //for bar chart casting we want to sample the middle 1/3 of the texture, but also add border triangles...

                //widthPixels = widthPixels+1;
            }
        }
        
        int BASE_VERT_OFFSET = widthPixels * heightPixels;// * 2;
        //int BASE_INDEX_OFFSET = tex.width * 12 + tex.height * 12;

        int numVerts = widthPixels * heightPixels * 2;//+ tex.width * 2 + tex.height * 2;
        int numTrianglesIndices = ((widthPixels) * (heightPixels)) * 12 + widthPixels * 12 + heightPixels * 12;
        //Debug.Log(numTrianglesIndices);

        int LINE_LENGTH = 50;

        if(barChart) {
            LINE_LENGTH = 12;
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
        if(barChart) { 
            HALF_LABEL_BOUNDS_WIDTH = LABEL_NUMBER_WIDTH * 2 - 3;
        }
        
        if(AddLetter && s.Length > 2) {
            HALF_LABEL_BOUNDS_WIDTH = LABEL_NUMBER_WIDTH * 2 + (LABEL_NUMBER_WIDTH/3);
        } else if(AddLetter && s.Length == 1) {
            HALF_LABEL_BOUNDS_WIDTH = (LABEL_NUMBER_WIDTH + 6);
        }


        int START_LABEL_HEIGHT = 30;
        int SPACING = 8;

        if(castingOption) {
            //HALF_LABEL_BOUNDS_WIDTH = HALF_LABEL_BOUNDS_WIDTH / 2;
            START_LABEL_HEIGHT = START_LABEL_HEIGHT / 2;
            SPACING = SPACING / 2;
        }

        if(barChart) {
            SPACING = (SPACING / 3);
        }

        //Debug.Log(widthPixels);
        //bottom
		for(int j = 0; j < heightPixels; j++)
        {
            int start = 0;
            int end = widthPixels;
            if (barChart)
            {
                if (!castingOption)
                {
                    start = widthPixels;
                    end = start + widthPixels;
                }
                    //start = widthPixels - castingTrisWidth;
                    //end = start + castingTrisWidth * 2 + widthPixels
            }

            for(int i = start; i < end; i++)
            {

                Color c = Color.white;
                if(castingOption)
                {
                    int wIdx = i;
                    int hIdx = j;

                    bool bothIn = true;

                    if (i > castingTrisWidth && i < end - castingTrisWidth)
                    {
                        wIdx = wIdx - castingTrisWidth;
                    }
                    else
                    {
                        bothIn = false;
                    }

                    if (j > castingTrisWidth && j < heightPixels - castingTrisWidth)
                    {
                        hIdx = hIdx - castingTrisWidth;
                    }
                    else
                    {
                        bothIn = false;
                    }
                    
                    if (bothIn)
                    {
                        c = tex.GetPixel(wIdx, hIdx);
                    }
                }
                else
                {
                    c = tex.GetPixel(i, j);
                }
                
                if(j == 10 && i > start+LINE_LENGTH && i < end - LINE_LENGTH)
                {
                    if(!castingOption) {
                        currVert.y = 0f;// 0.0005f; //old underline
                    }
                }
                /*else if(j >= START_LABEL_HEIGHT && j < (START_LABEL_HEIGHT + LABEL_NUMBER_HEIGHT) &&
                         i >= ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH && i < ((start+end) / 2) + HALF_LABEL_BOUNDS_WIDTH)
                {
                    int hLookup = j - START_LABEL_HEIGHT;
                    int wLookup = (i - (((start+end)/2)-HALF_LABEL_BOUNDS_WIDTH));

                    if(i >= ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH && 
                        i < ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH + LABEL_NUMBER_WIDTH && 
                        s.Length > 0)
                    {
                        //1st digit...
                        int d = 0;//int.Parse(s[0].ToString());
                        if(AddLetter) {
                            if(GetLetter(wLookup, hLookup, Letter)) {
                                currVert.y = 0.0005f;
                            }
                            else {
                                currVert.y = 0f;
                            }
                        }
                        else {
                            if(MultiTactileTile.DigitLookup[wLookup,hLookup,d] > 0) {
                                currVert.y = 0.0005f;
                                //Debug.Log("Yes");
                            } else {
                                currVert.y = 0f;
                            }
                        }
                    }
                    else if(i > ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH + SPACING) && 
                        i <= ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*2 + SPACING) && 
                        ((s.Length > 1) || (AddLetter && s.Length > 0)))
                    {
                        wLookup -= (LABEL_NUMBER_WIDTH + SPACING+1);
                        int d = 0;
                        if(AddLetter) {
                            //d = int.Parse(s[0].ToString());
                        } else {
                            //d = int.Parse(s[1].ToString());
                        }
                        //Debug.Log(wLookup + ", " + hLookup + ", " + d);// + " : " + TactileTile.DigitLookup[wLookup,hLookup,d]);

                        if(DigitLookup[wLookup,hLookup,d] > 0) {
                            currVert.y = 0.0005f;
                        } else {
                            currVert.y = 0f;
                        }
                    }
                    else if(i > ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*2) + SPACING*2 && 
                        i <= ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*3 + SPACING*2) && 
                        ((s.Length > 2) || (AddLetter && s.Length > 1)) )
                    {
                        wLookup -= (LABEL_NUMBER_WIDTH*2 + (SPACING*2)+1);
                        int d = 0;
                        if(AddLetter) {
                            //d = int.Parse(s[1].ToString());
                        } else {
                            //d = int.Parse(s[2].ToString());
                        }
                        //Debug.Log(wLookup + ", " + hLookup + ", " + d);// + " : " + TactileTile.DigitLookup[wLookup,hLookup,d]);

                        if(DigitLookup[wLookup,hLookup,d] > 0) {
                            currVert.y = 0.0005f;
                        } else {
                            currVert.y = 0f;
                        }
                    }
                    else if(i > ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*3) + SPACING*3 && 
                        i <= ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*4 + SPACING*3) && 
                        (AddLetter && s.Length > 2))
                    {
                        wLookup -= (LABEL_NUMBER_WIDTH*3 + (SPACING*3)+1);
                        int d = int.Parse(s[2].ToString());
                        if(DigitLookup[wLookup,hLookup,d] > 0) {
                            currVert.y = 0.0005f;
                        } else {
                            currVert.y = 0f;
                        }
                    }
                    else
                    {
                        currVert.y = 0f;
                    }

                }*/
                else
                {
				    currVert.y = 0f;
                }

                //currVert.x = -halfWidth + ((float)(i - start) / ((float)((end-start)-1f)) * worldWidth);
                currVert.x = -halfWidth + (((float)i - (float)start) * widthIncrement);// * worldWidth);

                currVert.z = -halfHeight + (((float)j / ((float)heightPixels-1f)) * worldHeight);
                //currVert.z = -halfHeight + ((float)j * heightIncrement);

                if(makeControl || castingInvert || castingOption) {
                    if(!AddLetter) {
                        currVert.y = 0f;
                    }
                }

                verts[vertIndex] = currVert;
                //normals[vertIndex] = Vector3.up;
                colors[vertIndex] = c;

                if(j < heightPixels-1 && i < end-1)
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
            int start = 0;
            int end = widthPixels;
            if(barChart) {
                if(!castingOption)
                {
                    start = widthPixels;
                    end = start+widthPixels;
                }
            }

            for(int i = start; i < end; i++)
            {
                Color c = Color.black;
                bool bothIn = true;
                bool numberArea = false;
                bool onBorder = false;

                if(castingOption)
                {
                    int wIdx = end-1-i;
                    //int wIdx = i;
                    int hIdx = j;

                    if(i > castingTrisWidth && i < end - castingTrisWidth)
                    {
                        wIdx = wIdx - castingTrisWidth;
                        if(barChart)
                        {
                            //want to sample from the middle of the original texture...

                            wIdx += originalPixelWidth;
                        }
                    }
                    else
                    {
                        bothIn = false;
                        if(addTileBorder) {
                            if(((i >= castingTrisWidth - borderTris) && (i <= castingTrisWidth) || 
                            (i >= end - castingTrisWidth) && (i <= (end - castingTrisWidth + borderTris))) && 
                            ((j <= heightPixels - castingTrisHeight + borderTris) && j >= castingTrisHeight - borderTris)) {
                                onBorder = true;
                            }
                        }
                    }

                    if(j > castingTrisHeight && j < heightPixels - castingTrisHeight)
                    {
                        hIdx = hIdx - castingTrisHeight;
                    }
                    else
                    {
                        bothIn = false;
                        if(addTileBorder) {
                            if(((j >= castingTrisHeight - borderTris) && (j <= castingTrisHeight) ||
                             (j >= heightPixels - castingTrisHeight) && (j <= (heightPixels - castingTrisHeight + borderTris))) &&
                             ((i <= end - castingTrisWidth + borderTris) && i >= castingTrisWidth - borderTris)) {
                                onBorder = true;
                            }
                        }
                    }

                    if(bothIn)
                    {
                        if(Smooth)
                        {
                            c = CalcSmoothColor(wIdx, hIdx, end, heightPixels, SmoothWindow, tex, barChart);
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
                        if(AddCastingDivets)
                        {
                            if(addCustomDivets) {
                                if(CalcCastingSphereCustom(i, j, castingTrisWidth, end, heightPixels, worldWidth, worldHeight, 
                                    halfWidth, halfHeight, divetOffset, divetRadius, out c.r))
                                {
                                    c.g = 1f;
                                }
                            } else {
                                if(CalcCastingSphere(i, j, end, heightPixels, castingTrisWidth, sphereWidth, out c.r))
                                {
                                    c.g = 1f;
                                }
                            }
                        }

                        if(!castingInvert) {
                            /*if(j >= START_LABEL_HEIGHT && j < (START_LABEL_HEIGHT + LABEL_NUMBER_HEIGHT) &&
                                i >= (end / 2) - HALF_LABEL_BOUNDS_WIDTH && i < (end / 2) + HALF_LABEL_BOUNDS_WIDTH)
                            {
                                int hLookup = j - START_LABEL_HEIGHT;
                                int wLookup = (i - ((end/2)-HALF_LABEL_BOUNDS_WIDTH));

                                if(i >= (end / 2) - HALF_LABEL_BOUNDS_WIDTH && 
                                    i < (end / 2) - HALF_LABEL_BOUNDS_WIDTH + LABEL_NUMBER_WIDTH && 
                                    s.Length > 0)
                                {
                                    if(wLookup <= (LABEL_NUMBER_WIDTH/2)) {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) + ((LABEL_NUMBER_WIDTH/2) - wLookup) - 1;
                                        //Debug.Log(wLookup);
                                    } else {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) - (wLookup - (LABEL_NUMBER_WIDTH/2)) - 1;
                                        // Debug.Log(wLookup);
                                    }

                                    //1st digit...

                                    int d = int.Parse(s[s.Length-1].ToString());

                                    if(MultiTactileTile.DigitLookup[wLookup,hLookup,d] > 0) {
                                        currVert.y = 0.0005f;
                                        numberArea = true;
                                    } 
                                    
                                }
                                else if(i > (end / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH + SPACING) && 
                                    i <= (end / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*2 + SPACING) && 
                                    ((s.Length > 1) || (AddLetter && s.Length > 0)))
                                {
                                    wLookup -= (LABEL_NUMBER_WIDTH + SPACING+1);
                                    
                                    if(wLookup <= (LABEL_NUMBER_WIDTH/2)) {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) + ((LABEL_NUMBER_WIDTH/2) - wLookup) - 1;
                                        //Debug.Log(wLookup);
                                    } else {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) - (wLookup - (LABEL_NUMBER_WIDTH/2)) - 1;
                                        // Debug.Log(wLookup);
                                    }
                                    int d = 0;
                                    if(AddLetter && s.Length == 1) {
                                        if(GetLetter(wLookup, hLookup, Letter)) {
                                            currVert.y = 0.0005f;
                                            numberArea = true;
                                        }
                                    } else {
                                        d = int.Parse(s[s.Length-2].ToString());
                                        if(DigitLookup[wLookup,hLookup,d] > 0) {
                                            currVert.y = 0.0005f;
                                            numberArea = true;
                                        } 
                                    }
                                    //Debug.Log(wLookup + ", " + hLookup + ", " + d);// + " : " + TactileTile.DigitLookup[wLookup,hLookup,d]);


                                }
                                else if(i > (end / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*2) + SPACING*2 && 
                                    i <= (end / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*3 + SPACING*2) && 
                                    ((s.Length > 2) || (AddLetter && s.Length > 1)) )
                                {
                                    wLookup -= (LABEL_NUMBER_WIDTH*2 + (SPACING*2)+1);
                                    
                                    if(wLookup <= (LABEL_NUMBER_WIDTH/2)) {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) + ((LABEL_NUMBER_WIDTH/2) - wLookup) - 1;
                                        //Debug.Log(wLookup);
                                    } else {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) - (wLookup - (LABEL_NUMBER_WIDTH/2)) - 1;
                                        // Debug.Log(wLookup);
                                    }
                                    int d = 0;
                                    if(AddLetter && s.Length == 2) {
                                        if(GetLetter(wLookup, hLookup, Letter)) {
                                            currVert.y = 0.0005f;
                                            numberArea = true;
                                        }
                                    } else {
                                        d = int.Parse(s[s.Length-3].ToString());
                                        if(DigitLookup[wLookup,hLookup,d] > 0) {
                                            currVert.y = 0.0005f;
                                            numberArea = true;
                                        } 
                                    }
                                    //Debug.Log(wLookup + ", " + hLookup + ", " + d);// + " : " + TactileTile.DigitLookup[wLookup,hLookup,d]);


                                }
                                else if(i > (end / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*3) + SPACING*3 && 
                                    i <= (end / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*4 + SPACING*3) && 
                                    (AddLetter && s.Length > 2))
                                {
                                    wLookup -= (LABEL_NUMBER_WIDTH*3 + (SPACING*3)+1);
                                    if(wLookup <= (LABEL_NUMBER_WIDTH/2)) {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) + ((LABEL_NUMBER_WIDTH/2) - wLookup) - 1;
                                        //Debug.Log(wLookup);
                                    } else {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) - (wLookup - (LABEL_NUMBER_WIDTH/2)) - 1;
                                        // Debug.Log(wLookup);
                                    }

                                    if(GetLetter(wLookup, hLookup, Letter)) {
                                        currVert.y = 0.0005f;
                                        numberArea = true;
                                    }
                                    //int d = int.Parse(s[s.Length-3].ToString());
                                    //if(DigitLookup[wLookup,hLookup,d] > 0) {
                                    //    currVert.y = 0.0005f;
                                    //    numberArea = true;
                                    //} 
                                }
                            }*/
                        }
                    }
                }
                else
                {
                    if(Smooth)
                    {
                        int wIdx = i;
                        int hIdx = j;
                        if (invert)
                        {
                            wIdx = end - 1 - i;
                            if (barChart)
                            {
                                //want to sample from the middle of the original texture...

                                wIdx += originalPixelWidth;
                            }
                        }
                        
                        //c = CalcSmoothColor(wIdx, j, end, heightPixels, SmoothWindow, tex, barChart);
                        c = Color.black;

                        Color heightSum = Color.black;
                        for(int k = j-SmoothWindow; k <= j+SmoothWindow; ++k)
                        {
                            for(int l = i-SmoothWindow; l <= i+SmoothWindow; ++l)
                            {
                                hIdx = k;
                                wIdx = l;

                                if(wIdx < 0)
                                {
                                    wIdx = 0;
                                }

                                if(hIdx < 0)
                                {
                                    hIdx = 0;
                                }

                                if(wIdx > widthPixels-1 && !barChart)
                                {
                                    wIdx = widthPixels-1;
                                }

                                if(hIdx > heightPixels-1)
                                {
                                    hIdx = heightPixels-1;
                                }

                                Color col = tex.GetPixel(wIdx, hIdx);
                                bool f = false;
                                Color32 c2 = new Color32((byte)(col.r*255), (byte)(col.g*255), (byte)(col.b*255), 255);
                                for(int q = 0; q < lines.Length; ++q)
                                {
                                    //Debug.Log(c2);
                                    //Debug.Log(colorLookup[q]);
                                    if(c2.r == colorLookup[q].r && c2.g == colorLookup[q].g && c2.b == colorLookup[q].b)
                                    {
                                        if(doColorMatch)
                                        {
                                            if(c2.r == matchColor.r && c2.g == matchColor.g && c2.b == matchColor.b)
                                            {
                                                if(scaleQuarter)
                                                {
                                                    c = tileTextures[q].GetPixel(wIdx/2, hIdx/2);
                                                }
                                                else
                                                {
                                                    c = tileTextures[q].GetPixel(wIdx, hIdx);
                                                }
                                                f = true;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            if(scaleQuarter)
                                            {
                                                c = tileTextures[q].GetPixel(wIdx/2, hIdx/2);
                                            }
                                            else
                                            {
                                                c = tileTextures[q].GetPixel(wIdx, hIdx);
                                            }
                                            f = true;
                                            break;
                                        }
                                    }
                                }

                                if(!f)
                                {
                                    //Debug.Log(c2);
                                    //find minimum
                                    int minIndex = -1;
                                    float maxDist = 99999f;
                                    for(int q = 0; q < lines.Length; ++q)
                                    {
                                        if(Vector4.Distance((Color)c2, (Color)colorLookup[q]) < maxDist)
                                        {
                                            maxDist = Vector4.Distance((Color)c2, (Color)colorLookup[q]);
                                            minIndex = q;
                                        }
                                    }

                                    if(minIndex != -1)
                                    {
                                        if(doColorMatch)
                                        {
                                            if(matchColor.r == colorLookup[minIndex].r && 
                                                matchColor.g == colorLookup[minIndex].g && 
                                                matchColor.b == colorLookup[minIndex].b)
                                            {
                                                if(scaleQuarter)
                                                {
                                                    c = tileTextures[minIndex].GetPixel(wIdx/2, hIdx/2);
                                                }
                                                else
                                                {
                                                    c = tileTextures[minIndex].GetPixel(wIdx, hIdx);
                                                }
                                                f = true;
                                            }
                                        }
                                        else
                                        {
                                            if(scaleQuarter)
                                            {
                                                c = tileTextures[minIndex].GetPixel(wIdx/2, hIdx/2);
                                            }
                                            else
                                            {
                                                c = tileTextures[minIndex].GetPixel(wIdx, hIdx);
                                            }
                                        }
                                    }
                                }

                                if(doColorMatch && !f)
                                {
                                    c = Color.black;
                                }

                                heightSum += c;
                            
                            }
                        }

                        c = (heightSum / (float)((SmoothWindow * 2 + 1) * (SmoothWindow * 2 + 1)));

                    }
                    else
                    {
                        int wIdx = i;
                        if (invert)
                        {
                            wIdx = end - 1 - i;
                            if (barChart)
                            {
                                //want to sample from the middle of the original texture...

                                wIdx += originalPixelWidth;
                            }
                        }

                        int hIdx = j;

                        /*if(scaleQuarter)
                        {
                            hIdx *= 2;
                            wIdx *= 2;
                        }*/

                        c = tex.GetPixel(wIdx, hIdx);
                        //Debug.Log(c);
                        bool f = false;
                        Color32 c2 = new Color32((byte)(c.r*255), (byte)(c.g*255), (byte)(c.b*255), 255);
                        for(int q = 0; q < lines.Length; ++q)
                        {
                            //Debug.Log(c2);
                            //Debug.Log(colorLookup[q]);
                            if(c2.r == colorLookup[q].r && c2.g == colorLookup[q].g && c2.b == colorLookup[q].b)
                            {
                                if(doColorMatch)
                                {
                                    if(c2.r == matchColor.r && c2.g == matchColor.g && c2.b == matchColor.b)
                                    {
                                        if(scaleQuarter)
                                        {
                                            c = tileTextures[q].GetPixel(wIdx/2, hIdx/2);
                                        }
                                        else
                                        {
                                            c = tileTextures[q].GetPixel(wIdx, hIdx);
                                        }
                                        f = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    if(scaleQuarter)
                                    {
                                        c = tileTextures[q].GetPixel(wIdx/2, hIdx/2);
                                    }
                                    else
                                    {
                                        c = tileTextures[q].GetPixel(wIdx, hIdx);
                                    }
                                    f = true;
                                    break;
                                }
                            }
                        }

                        if(!f)
                        {
                            //Debug.Log(c2);
                            //find minimum
                            int minIndex = -1;
                            float maxDist = 99999f;
                            for(int q = 0; q < lines.Length; ++q)
                            {
                                if(Vector4.Distance((Color)c2, (Color)colorLookup[q]) < maxDist)
                                {
                                    maxDist = Vector4.Distance((Color)c2, (Color)colorLookup[q]);
                                    minIndex = q;
                                }
                            }

                            if(minIndex != -1)
                            {
                                if(doColorMatch)
                                {
                                    if(matchColor.r == colorLookup[minIndex].r && 
                                        matchColor.g == colorLookup[minIndex].g && 
                                        matchColor.b == colorLookup[minIndex].b)
                                    {
                                        if(scaleQuarter)
                                        {
                                            c = tileTextures[minIndex].GetPixel(wIdx/2, hIdx/2);
                                        }
                                        else
                                        {
                                            c = tileTextures[minIndex].GetPixel(wIdx, hIdx);
                                        }
                                        f = true;
                                    }
                                }
                                else
                                {
                                    if(scaleQuarter)
                                    {
                                        c = tileTextures[minIndex].GetPixel(wIdx/2, hIdx/2);
                                    }
                                    else
                                    {
                                        c = tileTextures[minIndex].GetPixel(wIdx, hIdx);
                                    }
                                }
                            }
                        }

                        if(doColorMatch && !f)
                        {
                            c = Color.black;
                        }
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
                            if(doSilicone) {    //don't add the casting divets for silicone (omit the 1-v multiplier as it is below)
                                currVert.y = castingBase + (baseSize) + tileSize;
                            } else {
                                currVert.y = castingBase + (baseSize) + tileSize * (1f-v);
                            }
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
                                //currVert.y = baseSize + tileSize * (1f-v);
                                currVert.y = (castingBase + baseSize + tileSize) - (baseSize + tileSize * (v));

                                if(makeControl) {
                                    currVert.y = castingBase;// + tileSize;
                                }
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
                                //Debug.Log("hitting: " + v);
                                //add extra border here...
                                if(onBorder) {
                                    currVert.y = castingBase;// + (baseSize);
                                } else {
                                    currVert.y = castingBase + (baseSize) + tileSize * v;
                                }

                                if(numberArea) {
                                    currVert.y = castingBase + (baseSize) - 0.0005f;
                                }

                                if(makeControl) {
                                    if(numberArea) {
                                        currVert.y = castingBase + (baseSize) + tileSize - 0.0005f;
                                    } else {
                                        if(!onBorder) {
                                            currVert.y = castingBase + (baseSize) + tileSize;// + tileSize;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    currVert.y = (baseSize) + tileSize * v;  //sample y value from the texutre...
                    if(makeControl) {
                        currVert.y = (baseSize) + tileSize;
                    }
                }

                //currVert.x = -halfWidth + (((float)(i - start) / ((float)(end-start)-1f)) * worldWidth);

                currVert.x = -halfWidth + (((float)i - start) * widthIncrement);// * worldWidth);
                currVert.z = -halfHeight + (((float)j / ((float)heightPixels-1f)) * worldHeight);
                //currVert.z = -halfHeight + ((float)j * heightIncrement);
                /*if (vertIndex == verts.Length)
                {
                    Debug.Log(verts.Length);
                }*/

                verts[vertIndex] = currVert;
                //normals[vertIndex] = Vector3.up;
                colors[vertIndex] = c;

                if(j < heightPixels-1 && i < end-1)
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
    }

    public void GenerateTile(Texture2D tex, float worldWidth, float worldHeight, float baseSize, 
        float tileSize, bool invert, bool scaleQuarter=false,  bool castingOption=false, 
        float castingBorderSize=0f, bool castingInvert=false, bool Smooth=false, int SmoothWindow=0, bool AddCastingDivets=false, bool AddLetter=false, char Letter='b',
        bool makeControl=false, bool doSilicone=false, float castingBase=0.002f, bool addTileBorder=false, int borderTris=0, bool addCustomDivets=false, float divetOffset=0f,
        float divetRadius = 0f, bool barChart=false, bool castingHole = false )
    {
        InitializeLookup();

        int heightPixels = tex.height;
        int widthPixels = tex.width;

        if(scaleQuarter)
        {
            heightPixels = heightPixels / 2;
            widthPixels = widthPixels / 2;
        }

        int originalPixelWidth = widthPixels / 3;

        float widthIncrement = worldWidth / (float)widthPixels;
        float heightIncrement = worldHeight / (float)heightPixels;

        int castingTrisWidth = 0;
        int castingTrisHeight = 0;
        float sphereWidth = 0;

        if(castingOption)
        {
            //base number of additional triangles on texture size...
            if(barChart) 
            {
                widthIncrement = (worldWidth / ((float)(widthPixels-1f))) * 3f;
                widthPixels /= 3;
            }

            castingTrisWidth = (int)((float)(castingBorderSize / worldWidth) * (float)widthPixels);
            castingTrisHeight = (int)((float)(castingBorderSize / worldHeight) * (float)heightPixels);
            
            Debug.Log(castingTrisWidth);
            sphereWidth = (castingTrisWidth / 4.5f);    //3.8f
            //Debug.Log(castingTrisWidth);

            heightPixels += (2 * castingTrisWidth);
            widthPixels += (2 * castingTrisWidth);
            
            worldWidth += (2 * castingBorderSize);
            worldHeight += (2 * castingBorderSize);
            
        }
        else
        {
            if(barChart) 
            {
                widthIncrement = (worldWidth / ((float)(widthPixels-1f))) * 3f;// * 0.3333333f;
                widthPixels /= 3;
                
                //for bar chart casting we want to sample the middle 1/3 of the texture, but also add border triangles...

                //widthPixels = widthPixels+1;
            }
        }
        
        int BASE_VERT_OFFSET = widthPixels * heightPixels;// * 2;
        //int BASE_INDEX_OFFSET = tex.width * 12 + tex.height * 12;

        int numVerts = widthPixels * heightPixels * 2;//+ tex.width * 2 + tex.height * 2;
        int numTrianglesIndices = ((widthPixels) * (heightPixels)) * 12 + widthPixels * 12 + heightPixels * 12;
        //Debug.Log(numTrianglesIndices);

        int LINE_LENGTH = 50;

        if(barChart) {
            LINE_LENGTH = 12;
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
        if(barChart) { 
            HALF_LABEL_BOUNDS_WIDTH = LABEL_NUMBER_WIDTH * 2 - 3;
        }
        
        if(AddLetter && s.Length > 2) {
            HALF_LABEL_BOUNDS_WIDTH = LABEL_NUMBER_WIDTH * 2 + (LABEL_NUMBER_WIDTH/3);
        } else if(AddLetter && s.Length == 1) {
            HALF_LABEL_BOUNDS_WIDTH = (LABEL_NUMBER_WIDTH + 6);
        }


        int START_LABEL_HEIGHT = 30;
        int SPACING = 8;

        if(castingOption) {
            //HALF_LABEL_BOUNDS_WIDTH = HALF_LABEL_BOUNDS_WIDTH / 2;
            START_LABEL_HEIGHT = START_LABEL_HEIGHT / 2;
            SPACING = SPACING / 2;
        }

        if(barChart) {
            SPACING = (SPACING / 3);
        }

        //Debug.Log(widthPixels);
        //bottom
		for(int j = 0; j < heightPixels; j++)
        {
            int start = 0;
            int end = widthPixels;
            if (barChart)
            {
                if (!castingOption)
                {
                    start = widthPixels;
                    end = start + widthPixels;
                }
                    //start = widthPixels - castingTrisWidth;
                    //end = start + castingTrisWidth * 2 + widthPixels
            }

            for(int i = start; i < end; i++)
            {

                Color c = Color.white;
                if(castingOption)
                {
                    int wIdx = i;
                    int hIdx = j;

                    bool bothIn = true;

                    if (i > castingTrisWidth && i < end - castingTrisWidth)
                    {
                        wIdx = wIdx - castingTrisWidth;
                    }
                    else
                    {
                        bothIn = false;
                    }

                    if (j > castingTrisWidth && j < heightPixels - castingTrisWidth)
                    {
                        hIdx = hIdx - castingTrisWidth;
                    }
                    else
                    {
                        bothIn = false;
                    }
                    
                    if (bothIn)
                    {
                        c = tex.GetPixel(wIdx, hIdx);
                    }
                }
                else
                {
                    c = tex.GetPixel(i, j);
                }

				if(j == 10 && i > start+LINE_LENGTH && i < end - LINE_LENGTH)
                {
                    if(!castingOption) {
                        currVert.y = 0.0f;//0.0005f;    //old line
                    }
                }
                else if(j >= START_LABEL_HEIGHT && j < (START_LABEL_HEIGHT + LABEL_NUMBER_HEIGHT) &&
                         i >= ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH && i < ((start+end) / 2) + HALF_LABEL_BOUNDS_WIDTH)
                {
                    /*int hLookup = j - START_LABEL_HEIGHT;
                    int wLookup = (i - (((start+end)/2)-HALF_LABEL_BOUNDS_WIDTH));

                    if(i >= ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH && 
                        i < ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH + LABEL_NUMBER_WIDTH && 
                        s.Length > 0)
                    {
                        //1st digit...
                        int d = int.Parse(s[0].ToString());
                        if(AddLetter) {
                            if(GetLetter(wLookup, hLookup, Letter)) {
                                currVert.y = 0.0005f;
                            }
                            else {
                                currVert.y = 0f;
                            }
                        }
                        else {
                            if(MultiTactileTile.DigitLookup[wLookup,hLookup,d] > 0) {
                                currVert.y = 0.0005f;
                                //Debug.Log("Yes");
                            } else {
                                currVert.y = 0f;
                            }
                        }
                    }
                    else if(i > ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH + SPACING) && 
                        i <= ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*2 + SPACING) && 
                        ((s.Length > 1) || (AddLetter && s.Length > 0)))
                    {
                        wLookup -= (LABEL_NUMBER_WIDTH + SPACING+1);
                        int d = 0;
                        if(AddLetter) {
                            d = int.Parse(s[0].ToString());
                        } else {
                            d = int.Parse(s[1].ToString());
                        }
                        //Debug.Log(wLookup + ", " + hLookup + ", " + d);// + " : " + TactileTile.DigitLookup[wLookup,hLookup,d]);

                        if(DigitLookup[wLookup,hLookup,d] > 0) {
                            currVert.y = 0.0005f;
                        } else {
                            currVert.y = 0f;
                        }
                    }
                    else if(i > ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*2) + SPACING*2 && 
                        i <= ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*3 + SPACING*2) && 
                        ((s.Length > 2) || (AddLetter && s.Length > 1)) )
                    {
                        wLookup -= (LABEL_NUMBER_WIDTH*2 + (SPACING*2)+1);
                        int d = 0;
                        if(AddLetter) {
                            d = int.Parse(s[1].ToString());
                        } else {
                            d = int.Parse(s[2].ToString());
                        }
                        //Debug.Log(wLookup + ", " + hLookup + ", " + d);// + " : " + TactileTile.DigitLookup[wLookup,hLookup,d]);

                        if(DigitLookup[wLookup,hLookup,d] > 0) {
                            currVert.y = 0.0005f;
                        } else {
                            currVert.y = 0f;
                        }
                    }
                    else if(i > ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*3) + SPACING*3 && 
                        i <= ((start+end) / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*4 + SPACING*3) && 
                        (AddLetter && s.Length > 2))
                    {
                        wLookup -= (LABEL_NUMBER_WIDTH*3 + (SPACING*3)+1);
                        int d = int.Parse(s[2].ToString());
                        if(DigitLookup[wLookup,hLookup,d] > 0) {
                            currVert.y = 0.0005f;
                        } else {
                            currVert.y = 0f;
                        }
                    }
                    else*/
                    {
                        currVert.y = 0f;
                    }

                }
                else
                {
				    currVert.y = 0f;
                }

                //currVert.x = -halfWidth + ((float)(i - start) / ((float)((end-start)-1f)) * worldWidth);
                currVert.x = -halfWidth + (((float)i - (float)start) * widthIncrement);// * worldWidth);

                currVert.z = -halfHeight + (((float)j / ((float)heightPixels-1f)) * worldHeight);
                //currVert.z = -halfHeight + ((float)j * heightIncrement);

                if(makeControl || castingInvert || castingOption) {
                    if(!AddLetter) {
                        currVert.y = 0f;
                    }
                }

                verts[vertIndex] = currVert;
                //normals[vertIndex] = Vector3.up;
                colors[vertIndex] = c;

                if(j < heightPixels-1 && i < end-1)
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
            int start = 0;
            int end = widthPixels;
            if(barChart) {
                if(!castingOption)
                {
                    start = widthPixels;
                    end = start+widthPixels;
                }
            }

            for(int i = start; i < end; i++)
            {
                Color c = Color.black;
                bool bothIn = true;
                bool numberArea = false;
                bool onBorder = false;

                if(castingOption)
                {
                    int wIdx = end-1-i;
                    //int wIdx = i;
                    int hIdx = j;

                    if(i > castingTrisWidth && i < end - castingTrisWidth)
                    {
                        wIdx = wIdx - castingTrisWidth;
                        if(barChart)
                        {
                            //want to sample from the middle of the original texture...

                            wIdx += originalPixelWidth;
                        }
                    }
                    else
                    {
                        bothIn = false;
                        if(addTileBorder) {
                            if(((i >= castingTrisWidth - borderTris) && (i <= castingTrisWidth) || 
                            (i >= end - castingTrisWidth) && (i <= (end - castingTrisWidth + borderTris))) && 
                            ((j <= heightPixels - castingTrisHeight + borderTris) && j >= castingTrisHeight - borderTris)) {
                                onBorder = true;
                            }
                        }
                    }

                    if(j > castingTrisHeight && j < heightPixels - castingTrisHeight)
                    {
                        hIdx = hIdx - castingTrisHeight;
                    }
                    else
                    {
                        bothIn = false;
                        if(addTileBorder) {
                            if(((j >= castingTrisHeight - borderTris) && (j <= castingTrisHeight) ||
                             (j >= heightPixels - castingTrisHeight) && (j <= (heightPixels - castingTrisHeight + borderTris))) &&
                             ((i <= end - castingTrisWidth + borderTris) && i >= castingTrisWidth - borderTris)) {
                                onBorder = true;
                            }
                        }
                    }

                    if(bothIn)
                    {
                        if(Smooth)
                        {
                            c = CalcSmoothColor(wIdx, hIdx, end, heightPixels, SmoothWindow, tex, barChart);
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
                        if(AddCastingDivets)
                        {
                            if(addCustomDivets) {
                                if(CalcCastingSphereCustom(i, j, castingTrisWidth, end, heightPixels, worldWidth, worldHeight, 
                                    halfWidth, halfHeight, divetOffset, divetRadius, out c.r))
                                {
                                    c.g = 1f;
                                }
                            } else {
                                if(CalcCastingSphere(i, j, end, heightPixels, castingTrisWidth, sphereWidth, out c.r))
                                {
                                    c.g = 1f;
                                }
                            }
                        }

                        if(!castingInvert) {
                            /*if(j >= START_LABEL_HEIGHT && j < (START_LABEL_HEIGHT + LABEL_NUMBER_HEIGHT) &&
                                i >= (end / 2) - HALF_LABEL_BOUNDS_WIDTH && i < (end / 2) + HALF_LABEL_BOUNDS_WIDTH)
                            {
                                int hLookup = j - START_LABEL_HEIGHT;
                                int wLookup = (i - ((end/2)-HALF_LABEL_BOUNDS_WIDTH));

                                if(i >= (end / 2) - HALF_LABEL_BOUNDS_WIDTH && 
                                    i < (end / 2) - HALF_LABEL_BOUNDS_WIDTH + LABEL_NUMBER_WIDTH && 
                                    s.Length > 0)
                                {
                                    if(wLookup <= (LABEL_NUMBER_WIDTH/2)) {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) + ((LABEL_NUMBER_WIDTH/2) - wLookup) - 1;
                                        //Debug.Log(wLookup);
                                    } else {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) - (wLookup - (LABEL_NUMBER_WIDTH/2)) - 1;
                                        // Debug.Log(wLookup);
                                    }

                                    //1st digit...

                                    int d = int.Parse(s[s.Length-1].ToString());

                                    if(MultiTactileTile.DigitLookup[wLookup,hLookup,d] > 0) {
                                        currVert.y = 0.0005f;
                                        numberArea = true;
                                    } 
                                    
                                }
                                else if(i > (end / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH + SPACING) && 
                                    i <= (end / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*2 + SPACING) && 
                                    ((s.Length > 1) || (AddLetter && s.Length > 0)))
                                {
                                    wLookup -= (LABEL_NUMBER_WIDTH + SPACING+1);
                                    
                                    if(wLookup <= (LABEL_NUMBER_WIDTH/2)) {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) + ((LABEL_NUMBER_WIDTH/2) - wLookup) - 1;
                                        //Debug.Log(wLookup);
                                    } else {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) - (wLookup - (LABEL_NUMBER_WIDTH/2)) - 1;
                                        // Debug.Log(wLookup);
                                    }
                                    int d = 0;
                                    if(AddLetter && s.Length == 1) {
                                        if(GetLetter(wLookup, hLookup, Letter)) {
                                            currVert.y = 0.0005f;
                                            numberArea = true;
                                        }
                                    } else {
                                        d = int.Parse(s[s.Length-2].ToString());
                                        if(DigitLookup[wLookup,hLookup,d] > 0) {
                                            currVert.y = 0.0005f;
                                            numberArea = true;
                                        } 
                                    }
                                    //Debug.Log(wLookup + ", " + hLookup + ", " + d);// + " : " + TactileTile.DigitLookup[wLookup,hLookup,d]);


                                }
                                else if(i > (end / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*2) + SPACING*2 && 
                                    i <= (end / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*3 + SPACING*2) && 
                                    ((s.Length > 2) || (AddLetter && s.Length > 1)) )
                                {
                                    wLookup -= (LABEL_NUMBER_WIDTH*2 + (SPACING*2)+1);
                                    
                                    if(wLookup <= (LABEL_NUMBER_WIDTH/2)) {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) + ((LABEL_NUMBER_WIDTH/2) - wLookup) - 1;
                                        //Debug.Log(wLookup);
                                    } else {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) - (wLookup - (LABEL_NUMBER_WIDTH/2)) - 1;
                                        // Debug.Log(wLookup);
                                    }
                                    int d = 0;
                                    if(AddLetter && s.Length == 2) {
                                        if(GetLetter(wLookup, hLookup, Letter)) {
                                            currVert.y = 0.0005f;
                                            numberArea = true;
                                        }
                                    } else {
                                        d = int.Parse(s[s.Length-3].ToString());
                                        if(DigitLookup[wLookup,hLookup,d] > 0) {
                                            currVert.y = 0.0005f;
                                            numberArea = true;
                                        } 
                                    }
                                    //Debug.Log(wLookup + ", " + hLookup + ", " + d);// + " : " + TactileTile.DigitLookup[wLookup,hLookup,d]);


                                }
                                else if(i > (end / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*3) + SPACING*3 && 
                                    i <= (end / 2) - HALF_LABEL_BOUNDS_WIDTH + (LABEL_NUMBER_WIDTH*4 + SPACING*3) && 
                                    (AddLetter && s.Length > 2))
                                {
                                    wLookup -= (LABEL_NUMBER_WIDTH*3 + (SPACING*3)+1);
                                    if(wLookup <= (LABEL_NUMBER_WIDTH/2)) {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) + ((LABEL_NUMBER_WIDTH/2) - wLookup) - 1;
                                        //Debug.Log(wLookup);
                                    } else {
                                        wLookup = (LABEL_NUMBER_WIDTH/2) - (wLookup - (LABEL_NUMBER_WIDTH/2)) - 1;
                                        // Debug.Log(wLookup);
                                    }

                                    if(GetLetter(wLookup, hLookup, Letter)) {
                                        currVert.y = 0.0005f;
                                        numberArea = true;
                                    }
                                    //int d = int.Parse(s[s.Length-3].ToString());
                                    //if(DigitLookup[wLookup,hLookup,d] > 0) {
                                    //    currVert.y = 0.0005f;
                                    //    numberArea = true;
                                    //} 
                                }
                            }*/
                        }
                    }
                }
                else
                {
                    if(Smooth)
                    {
                        int wIdx = i;
                        if (invert)
                        {
                            wIdx = end - 1 - i;
                            if (barChart)
                            {
                                //want to sample from the middle of the original texture...

                                wIdx += originalPixelWidth;
                            }
                        }
                        
                        c = CalcSmoothColor(wIdx, j, end, heightPixels, SmoothWindow, tex, barChart);
                    }
                    else
                    {
                        int wIdx = i;
                        if (invert)
                        {
                            wIdx = end - 1 - i;
                            if (barChart)
                            {
                                //want to sample from the middle of the original texture...

                                wIdx += originalPixelWidth;
                            }
                        }

                        c = tex.GetPixel(wIdx, j);
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
                            if(doSilicone) {    //don't add the casting divets for silicone (omit the 1-v multiplier as it is below)
                                currVert.y = castingBase + (baseSize) + tileSize;
                            } else {
                                currVert.y = castingBase + (baseSize) + tileSize * (1f-v);
                            }
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
                                //currVert.y = baseSize + tileSize * (1f-v);
                                currVert.y = (castingBase + baseSize + tileSize) - (baseSize + tileSize * (v));

                                if(makeControl) {
                                    currVert.y = castingBase;// + tileSize;
                                }
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
                                //Debug.Log("hitting: " + v);
                                //add extra border here...
                                if(onBorder) {
                                    currVert.y = castingBase;// + (baseSize);
                                } else {
                                    currVert.y = castingBase + (baseSize) + tileSize * v;
                                }

                                if(numberArea) {
                                    currVert.y = castingBase + (baseSize) - 0.0005f;
                                }

                                if(makeControl) {
                                    if(numberArea) {
                                        currVert.y = castingBase + (baseSize) + tileSize - 0.0005f;
                                    } else {
                                        if(!onBorder) {
                                            currVert.y = castingBase + (baseSize) + tileSize;// + tileSize;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    currVert.y = (baseSize) + tileSize * v;  //sample y value from the texutre...
                    if(makeControl) {
                        currVert.y = (baseSize) + tileSize;
                    }
                }

                //currVert.x = -halfWidth + (((float)(i - start) / ((float)(end-start)-1f)) * worldWidth);

                currVert.x = -halfWidth + (((float)i - start) * widthIncrement);// * worldWidth);
                currVert.z = -halfHeight + (((float)j / ((float)heightPixels-1f)) * worldHeight);
                //currVert.z = -halfHeight + ((float)j * heightIncrement);
                /*if (vertIndex == verts.Length)
                {
                    Debug.Log(verts.Length);
                }*/

                verts[vertIndex] = currVert;
                //normals[vertIndex] = Vector3.up;
                colors[vertIndex] = c;

                if(j < heightPixels-1 && i < end-1)
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

    bool CalcCastingSphereCustom(int i, int j, int castingTrisWidth, int widthPixels, int heightPixels, float worldWidth, float worldHeight, float halfWidth, float halfHeight,
        float divetOffset, float divetRadius, out float heightVal)
    {
        heightVal = 1f;

        Vector2 world2DPos = new Vector2(0f, 0f);
        //do the distance check here based on divet offset and radius depending on what quadrant we are in...
        world2DPos.x = -halfWidth + (((float)i / ((float)widthPixels-1f)) * worldWidth);
        world2DPos.y = -halfHeight + (((float)j / ((float)heightPixels-1f)) * worldHeight);
        

        if(i < castingTrisWidth)
        {
            if(j < castingTrisWidth)
            {
                Vector2 world2DPosCorner = new Vector2(0f, 0f);
                world2DPosCorner.x = -halfWidth + divetOffset;
                world2DPosCorner.y = -halfHeight + divetOffset;

                float dist = Vector2.Distance(world2DPos, world2DPosCorner);
                if(dist < divetRadius) {
                    float latAngle = Mathf.PI / 2f * (dist/divetRadius); // Hemisphere, so only PI/2
                    heightVal = Mathf.Cos(latAngle);
                    return true;
                }
            }
            else if(j > heightPixels-castingTrisWidth)
            {
                Vector2 world2DPosCorner = new Vector2(0f, 0f);
                world2DPosCorner.x = -halfWidth + divetOffset;
                world2DPosCorner.y = -halfHeight + worldHeight - divetOffset;
        
                float dist = Vector2.Distance(world2DPos, world2DPosCorner);
                if(dist < divetRadius) {
                    float latAngle = Mathf.PI / 2f * (dist/divetRadius); // Hemisphere, so only PI/2
                    heightVal = Mathf.Cos(latAngle);
                    return true;
                }
            }
        }
        else if(i > widthPixels - castingTrisWidth)
        {
            if(j < castingTrisWidth)
            {
                Vector2 world2DPosCorner = new Vector2(0f, 0f);
                world2DPosCorner.x = -halfWidth + worldWidth - divetOffset;
                world2DPosCorner.y = -halfHeight + divetOffset;
        
                float dist = Vector2.Distance(world2DPos, world2DPosCorner);
                if(dist < divetRadius) {
                    float latAngle = Mathf.PI / 2f * (dist/divetRadius); // Hemisphere, so only PI/2
                    heightVal = Mathf.Cos(latAngle);
                    return true;
                }
            }
            else if(j > heightPixels-castingTrisWidth)
            {
                Vector2 world2DPosCorner = new Vector2(0f, 0f);
                world2DPosCorner.x = -halfWidth + worldWidth - divetOffset;
                world2DPosCorner.y = -halfHeight + worldHeight - divetOffset;
        
                float dist = Vector2.Distance(world2DPos, world2DPosCorner);
                if(dist < divetRadius) {
                    float latAngle = Mathf.PI / 2f * (dist/divetRadius); // Hemisphere, so only PI/2
                    heightVal = Mathf.Cos(latAngle);
                    return true;
                }
            }
        }

        return false;
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

    Color CalcSmoothColor(int i, int j, int widthPixels, int heightPixels, int SmoothWindow, Texture2D tex, bool barChart=false)
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

                if(wIdx > widthPixels-1 && !barChart)
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
