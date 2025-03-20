using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.Spawned += ChangeColor;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= ChangeColor;
    }

    public void ChangeColor(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            if (cube.Renderer != null)
            {
                cube.Renderer.material.color = new Color(Random.value, Random.value, Random.value);
            }
        }
    }
}
