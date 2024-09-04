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

            TactileTile ipc = ip.GetComponent<TactileTile>();
            
            ipc.GenerateTile(TestTexture, WorldWidth, WorldHeight, BaseSize, TileSize, Invert);
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

                    TactileTile ipc = ip.GetComponent<TactileTile>();
                    
                    ipc.GenerateTile(colorTex, WorldWidth, WorldHeight, BaseSize, TileSize, Invert);

                }	
            }
        }
    }
}
