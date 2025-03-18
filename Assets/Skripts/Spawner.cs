using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int _minimalCount = 2;
    private int _maximalCount = 6;
    private int _minimalChance = 0;
    private int _maximalChance = 100;

    public event Action<Cube> Spawned;

    private void OnEnable()
    {
        Cube.BlownUp += Spawn;
    }

    private void OnDisable()
    {
        Cube.BlownUp -= Spawn;
    }

    public void Spawn(Cube cube, float chanceToSplit)
    {
        if (chanceToSplit >= GetRandomValue(_minimalChance, _maximalChance + 1))
        {
            for (int i = 0; i < GetRandomValue(_minimalCount, _maximalCount + 1); i++)
            {
                Vector3 position = new Vector3(cube.transform.position.x + GetRandomValue(-1, 1), 1, cube.transform.position.z + GetRandomValue(-1, 1));

                Cube newCube = Instantiate(cube);

                newCube.transform.position = position;
                newCube.Decrease();
                Spawned?.Invoke(newCube);
            }
        }
    }

    private int GetRandomValue(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }
}
