
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utility script to change the material render queues. This fixes the problem that some transparent materials show through others incorrectly.
/// </summary>
public class SetMaterialRenderQueue : MonoBehaviour
{
    public int RenderQueue = 2001;
    public List<Material> Materials = new List<Material>();

    void Start()
    {
        foreach (Material material in Materials)
        {
            material.renderQueue = RenderQueue;
        }
    }
}

