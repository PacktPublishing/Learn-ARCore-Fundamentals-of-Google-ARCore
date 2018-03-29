namespace Packt.ARCoreDesign
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class ObjectOutliner : MonoBehaviour
    {
        public int MaterialSlot;
        public Material DefaultMaterial;
        public Material OutlineMaterial;
        public bool outlineOn;  

        public void Outline()
        {
            outlineOn = !outlineOn;

            var renderer = GetComponent<MeshRenderer>();
            Material[] mats = renderer.materials;
            if (outlineOn)
            {
                mats[MaterialSlot] = OutlineMaterial;
            }
            else
            {
                mats[MaterialSlot] = DefaultMaterial;
            }
            renderer.materials = mats;
        }
    }
}
