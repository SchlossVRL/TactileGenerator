using UnityEngine;
using System.IO;
using System;

public class TactileGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject TilePrefab;

    [SerializeField]
    string TextureDir;

    [SerializeField]
    Texture2D TestTexture;

    [SerializeField]
    float WorldWidth;

    [SerializeField]
    float WorldHeight;

    [SerializeField]
    float BaseSize;

    [SerializeField]
    float TileSize;

    [SerializeField]
    bool Invert;

    [SerializeField]
    bool ScaleQuarter;

    [SerializeField]
    bool WriteMM;

    [SerializeField]
    bool CastingOption;

    [SerializeField]
    bool CastingInvert;

    [SerializeField]
    float CastingBorderSize;

    [SerializeField]
    bool Smooth;

    [SerializeField]
    int SmoothWindow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    [ContextMenu("Generate")]
    void Generate()
    {
        if(TestTexture != null)
        {
            GameObject ip = Instantiate(TilePrefab);
            /*string sPNG = TestTexture.name;
            sPNG = sPNG.Replace("Assets/Resources/", "");
            sPNG = sPNG.Replace(".png", "");
            int num = int.Parse(TestTexture.name);
            
            if(num <= 99)
            {
                ip.name = num.ToString("D2");
            }
            else
            {
                ip.name = sPNG;
            }*/

            TactileTile ipc = ip.GetComponent<TactileTile>();
            
            ipc.GenerateTile(TestTexture, WorldWidth, WorldHeight, BaseSize, TileSize, Invert, ScaleQuarter, WriteMM, CastingOption, CastingBorderSize, CastingInvert, Smooth, SmoothWindow);
        }
        else
        {
            if(TilePrefab != null)
            {
                string[] textures = Directory.GetFiles("Assets/Resources/"+TextureDir+"/", "*.png");
    
                Vector3 maxB = new Vector3(-99999f, -99999f, -99999f);
                Vector3 minB = new Vector3(99999f, 99999f, 99999f);
                int zeroCount = 0;
                
                int numTextures = textures.Length;

                int numberIndex = 0;

                for(int i = 0; i < numTextures; ++i)
                {
                    string sPNG = textures[i];
                    sPNG = sPNG.Replace("Assets/Resources/", "");
                    sPNG = sPNG.Replace(".png", "");
                    
                    Texture2D colorTex = Resources.Load<Texture2D>(sPNG);

                    GameObject ip = Instantiate(TilePrefab);

                    /*string s = sPNG.Substring(1, sPNG.Length);
                    int num = int.Parse(s);
                    
                    if(num <= 99)
                    {
                        ip.name = int.Parse(sPNG).ToString("D2");
                    }
                    else
                    {*/
                    string s = sPNG.Replace("brodatz/", "");
                    ip.name = s;
                    //}

                    TactileTile ipc = ip.GetComponent<TactileTile>();
                    
                    ipc.GenerateTile(colorTex, WorldWidth, WorldHeight, BaseSize, TileSize, Invert, ScaleQuarter, WriteMM, CastingOption, CastingBorderSize, CastingInvert, Smooth, SmoothWindow);

                    ipc.gameObject.SetActive(false);
                    //UnityEngine.Object.DestroyImmediate(colorTex);
                }	
            }
        }
    }
}
