using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Cube> _cubes;

    private int _minimalCount = 2;
    private int _maximalCount = 6;

    public event Action<List<Cube>> Spawned;

    private void OnEnable()
    {
        foreach (Cube cube in _cubes)
        {
            if (cube != null)
            {
                cube.BlownUp += Spawn;
            }
        }
    }

    private void OnDisable()
    {
        foreach (Cube cube in _cubes)
        {
            if (cube != null)
            {
                cube.BlownUp -= Spawn;
            }
        }
    }

    public void Spawn(Cube cube)
    {
        List<Cube> spawnedCubes = new List<Cube>();

        for (int i = 0; i < GetRandomValue(_minimalCount, _maximalCount + 1); i++)
        {
            Vector3 position = new Vector3(cube.transform.position.x + GetRandomValue(-1, 1), 1, cube.transform.position.z + GetRandomValue(-1, 1));

            Cube newCube = Instantiate(cube);

            newCube.transform.position = position;
            newCube.Decrease();
            newCube.Recolor();
            newCube.BlownUp += Spawn;

            spawnedCubes.Add(newCube);
        }

        Spawned?.Invoke(spawnedCubes);
        _cubes.AddRange(spawnedCubes);
    }

    private int GetRandomValue(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }
}
