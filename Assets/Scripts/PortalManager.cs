using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{
    public GameObject MainCamera;

    public GameObject Sponza;
    public GameObject Spartan;
    public GameObject Cavalier;
    public GameObject Soldier;

    private Component[] SpartanComponents;
    private Component[] CavalierComponents;
    private Component[] SoldierComponents;

    private Material[] SponzaMaterials;
    private Material[][] SpartanMaterials;
    private Material[][] CavalierMaterials;
    private Material[][] SoldierMaterials;
    // Start is called before the first frame update
    void Start()
    {
        SponzaMaterials = Sponza.GetComponent<Renderer>().sharedMaterials;
        for (int i = 0; i < Spartan.transform.childCount; ++i)
        {
            //SpartanComponents[i] = Spartan.transform.GetChild(i).GetComponent<Renderer>();
            SpartanMaterials[i] = Spartan.transform.GetChild(i).GetComponent<Renderer>().sharedMaterials;
        }
        for (int i = 0; i < Cavalier.transform.childCount; ++i)
        {
            //CavalierComponents[i] = Cavalier.transform.GetChild(i).GetComponent<Renderer>();
            CavalierMaterials[i] = Cavalier.transform.GetChild(i).GetComponent<Renderer>().sharedMaterials;
        }
        for (int i = 0; i < Soldier.transform.childCount; ++i)
        {
            //SoldierComponents[i] = Soldier.transform.GetChild(i).GetComponent<Renderer>();
            SoldierMaterials[i] = Soldier.transform.GetChild(i).GetComponent<Renderer>().sharedMaterials;
        }
    }

    // Update is called once per frame
    void OnTriggerStay(Collider collider)
    {
        Vector3 camPositionInPortalSpace = transform.InverseTransformPoint(MainCamera.transform.position);

        if(camPositionInPortalSpace.y < 0.5f)
        {
            //Disable stencil test
            for(int i = 0; i < SponzaMaterials.Length; ++i)
            {
                SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
            for (int i = 0; i < SpartanMaterials.Length; ++i)
            {
                for (int j = 0; j < SpartanMaterials[i].Length; ++j)
                {
                    SpartanMaterials[i][j].SetInt("_StencilComp", (int)CompareFunction.Always);
                }
            }
            for (int i = 0; i < CavalierMaterials.Length; ++i)
            {
                for (int j = 0; j < CavalierMaterials[i].Length; ++j)
                {
                    CavalierMaterials[i][j].SetInt("_StencilComp", (int)CompareFunction.Always);
                }
            }
            for (int i = 0; i < SoldierMaterials.Length; ++i)
            {
                for (int j = 0; j < SoldierMaterials[i].Length; ++j)
                {
                    SoldierMaterials[i][j].SetInt("_StencilComp", (int)CompareFunction.Always);
                }
            }
        }
        else
        {
            //Enable stencil test
            for (int i = 0; i < SponzaMaterials.Length; ++i)
            {
                SponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
            for (int i = 0; i < SpartanMaterials.Length; ++i)
            {
                for (int j = 0; j < SpartanMaterials[i].Length; ++j)
                {
                    SpartanMaterials[i][j].SetInt("_StencilComp", (int)CompareFunction.Equal);
                }
            }
            for (int i = 0; i < CavalierMaterials.Length; ++i)
            {
                for (int j = 0; j < CavalierMaterials[i].Length; ++j)
                {
                    CavalierMaterials[i][j].SetInt("_StencilComp", (int)CompareFunction.Equal);
                }
            }
            for (int i = 0; i < SoldierMaterials.Length; ++i)
            {
                for (int j = 0; j < SoldierMaterials[i].Length; ++j)
                {
                    SoldierMaterials[i][j].SetInt("_StencilComp", (int)CompareFunction.Equal);
                }
            }
        }
    }
}
