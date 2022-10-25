using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

public class SwitchOutfit : MonoBehaviour
{
    [SerializeField] InputRegister inputRegister;
    [SerializeField] Vector2 navVector;
    [SerializeField] Outfits outfits;
    [SerializeField] int Shirt = 0;
    [SerializeField] int ShirtColor = 0;
    [SerializeField] float pressThreshold = 0.5f;
    [SerializeField] float current1 = 0f;
    [SerializeField] float current2 = 0f;
    [SerializeField] float current3 = 0f;
    [SerializeField] float current4 = 0f;
    private void Awake()
    {
        inputRegister = GetComponent<InputRegister>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        current1 += Time.deltaTime;
        current2 += Time.deltaTime;
        current3 += Time.deltaTime;
        current4 += Time.deltaTime;
        navVector = inputRegister.GetNav();
        float leftRight = navVector.x;
        float upDown = navVector.y;
        if (upDown > 0.2f && current1 >= pressThreshold)
        {
            current1 = 0f;
            if (Shirt < outfits.type.Length - 1)
            {
                Shirt += 1;
            }
            else Shirt = 0;
        }
        if (upDown < -0.2f && current2 >= pressThreshold)
        {
            current2 = 0f;
            if (Shirt > 0)
            {
                Shirt -= 1;
            }
            else Shirt = 0;
        }
        if(leftRight > 0.2f && current3 >= pressThreshold)
        {
            current3 = 0f;
            if (ShirtColor < outfits.type[Shirt].collection.Length - 1)
            {
                ShirtColor += 1;
            }
            else
                ShirtColor = 0;
        }
        if (leftRight < -0.2f && current4 >= pressThreshold)
        {
            current4 = 0f;
            if (ShirtColor > 0)
            {
                ShirtColor -= 1;
            }
            else
                ShirtColor = 0;
        }
        if (Shirt == 0)
        {
            outfits.type[Shirt].collection[ShirtColor].mesh.gameObject.SetActive(true);
            for (int i = 0; i < outfits.type[Shirt].collection.Length - 1;)
            {
                i++;
                if(i!= ShirtColor)
                outfits.type[Shirt].collection[i].mesh.SetActive(false);
            }
        }
        if (Shirt == 1)
        {
            outfits.type[Shirt].collection[ShirtColor].mesh.gameObject.SetActive(true);
            for (int i = 0; i < outfits.type[Shirt].collection.Length - 1;)
            {
                i++;
                if (i != ShirtColor)
                    outfits.type[Shirt].collection[i].mesh.SetActive(false);
            }
        }
    }
}
