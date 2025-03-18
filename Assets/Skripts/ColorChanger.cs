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

    public void ChangeColor(Cube cube)
    {
        Renderer renderer = cube.GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
