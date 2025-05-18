using UnityEngine;
using System.IO;
using System;

public class TactileGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject TilePrefab;

    [SerializeField]
    [Tooltip("If present, and nothing in TestTexture, generates a tile for each texture in the specified directory from Assets/Resources/")]
    string TextureDir;

    [SerializeField]
    [Tooltip("If present - generates a single tile from this texture.")]
    Texture2D TestTexture;

    [SerializeField]
    [Tooltip("The width of the generated tile. In meters.")]
    float WorldWidth;

    [SerializeField]
    [Tooltip("The length of the generated tile. In meters.")]
    float WorldLength;

    [SerializeField]
    [Tooltip("The height of the base of the tile, before the tile height data. In meters.")]
    float BaseSize;

    [SerializeField]
    [Tooltip("The maximum height of the actual tile height data as created via the brodatz texture. In meters.")]
    float TileSize;

    [SerializeField]
    [Tooltip("The height underneath when creating a casting mold. In meters.")]
    float CastingBase;

    [SerializeField]
    [Tooltip("Whether to invert the values of the texture to black high, white low.")]
    bool Invert;

    [SerializeField]
    [Tooltip("Whether to scale a texture to 1 quarter of the texture as the total size (magnifies by 2)")]
    bool ScaleQuarter;

    [SerializeField]
    [Tooltip("Take the middle 1/3 of the current tactile texture for sampling")]
    bool BarChart;

    [SerializeField]
    [Tooltip("If on makes a casting mold of the current tile instead of the tile itself.")]
    bool CastingOption;

    [SerializeField]
    bool CastingInvert;

    [SerializeField]
    float CastingBorderSize;

    //[SerializeField]
    bool AddCastingDivets;

    [SerializeField]
    bool Smooth;

    [SerializeField]
    int SmoothWindow;

    [SerializeField]
    bool AddLetter;

    [SerializeField]
    char Letter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    bool MakeControl;

    [SerializeField]
    bool DoSilicone;

    [SerializeField]
    bool AddBorder;

    [SerializeField]
    int NumBorderTriangles;

    [SerializeField]
    bool AddCustomDivets;

    [SerializeField]
    float DivetOffset;

    [SerializeField]
    float DivetRadius;

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

            if(CastingOption) {
                AddCastingDivets = true;
            }
            
            ipc.GenerateTile(TestTexture, WorldWidth, WorldLength, BaseSize, TileSize, Invert, ScaleQuarter, 
                CastingOption, CastingBorderSize, CastingInvert, Smooth, SmoothWindow, AddCastingDivets, 
                AddLetter, Letter, MakeControl, DoSilicone, CastingBase, AddBorder, NumBorderTriangles, AddCustomDivets, 
                DivetOffset, DivetRadius, BarChart);
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

                    if(CastingOption) {
                        AddCastingDivets = true;
                    }
                    
                    ipc.GenerateTile(colorTex, WorldWidth, WorldLength, BaseSize, TileSize, Invert, ScaleQuarter, 
                        CastingOption, CastingBorderSize, CastingInvert, Smooth, SmoothWindow, AddCastingDivets, 
                        AddLetter, Letter, MakeControl, DoSilicone, CastingBase, AddBorder, NumBorderTriangles, AddCustomDivets, 
                        DivetOffset, DivetRadius, BarChart);

                    ipc.gameObject.SetActive(false);
                    //UnityEngine.Object.DestroyImmediate(colorTex);
                }	
            }
        }
    }
}
