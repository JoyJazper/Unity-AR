using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FilterSwap : MonoBehaviour
{

    public GameObject btn;
    public Transform buttonHolder;
    Texture[] imgTex;
    public GameObject faceObject;

    void Start()
    {
        imgTex = Resources.LoadAll<Texture>("Image");
        foreach(Texture img in imgTex)
        {
            GameObject faceMask = Instantiate(btn as GameObject);
            faceMask.transform.SetParent(buttonHolder);
            faceMask.GetComponent<RawImage>().texture = img;

            string textureName = img.name;

            faceMask.GetComponent<Button>().onClick.AddListener(() => OnFilterSelect(textureName));
        }
    }

    public void OnFilterSelect(string maskName)
    {
        Renderer rent = faceObject.GetComponent<Renderer>();
        rent.material.mainTexture = Resources.Load<Texture>("Image/" + maskName);
    }
}
