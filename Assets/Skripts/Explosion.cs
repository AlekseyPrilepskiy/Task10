using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private float _explosionForce = 1500f;
    [SerializeField] private float _explosionRadius = 5f;

    private void OnEnable()
    {
        _spawner.Spawned += Explode;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= Explode;
    }

    public void Explode(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            if (cube == this)
            {
                continue;
            }

            if (cube.RigidBody != null)
            {
                cube.RigidBody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }
}
