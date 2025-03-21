using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosibleObject : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 2f;

    private void OnEnable()
    {
        _cube.Destroyed += Explode;
    }

    private void OnDisable()
    {
        _cube.Destroyed -= Explode;
    }

    public void Explode()
    {
        float explosionCoefficient = transform.localScale.x;
        float explosionForce = _explosionForce / explosionCoefficient;
        float explosionRadius = _explosionRadius / explosionCoefficient;

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.attachedRigidbody != null)
            {
                collider.attachedRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }
}
