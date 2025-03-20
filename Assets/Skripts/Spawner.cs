using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int SpawnStepPositiveValue = 2;
    [SerializeField] private int SpawnStepNegativeValue = -2;
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

        _cubes.Clear();
    }

    public void Spawn(Cube cube)
    {
        List<Cube> spawnedCubes = new List<Cube>();

        for (int i = 0; i < GetRandomValue(_minimalCount, _maximalCount + 1); i++)
        {
            float positionX = cube.transform.position.x + GetRandomValue(SpawnStepNegativeValue, SpawnStepPositiveValue);
            float positionY = 1;
            float positionZ = cube.transform.position.z + GetRandomValue(SpawnStepNegativeValue, SpawnStepPositiveValue);

            Vector3 position = new Vector3(positionX, positionY, positionZ);

            Cube newCube = Instantiate(cube);

            newCube.transform.position = position;
            newCube.Decrease();
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
