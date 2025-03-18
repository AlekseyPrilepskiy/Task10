using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{
    [SerializeField] private RaycastHitter _raycastHitter;
    [SerializeField] private float _chanceToSplit = 100f;
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 3f;

    public static event Action<Cube, float> BlownUp;

    private void OnEnable()
    {
        _raycastHitter.TargetHitted += BlowUp;
    }

    private void OnDisable()
    {
        _raycastHitter.TargetHitted -= BlowUp;
    }

    public void BlowUp(Cube cube)
    {
        if (cube == this)
        {
            BlownUp?.Invoke(this, _chanceToSplit);
            Explode();
            Destroy(gameObject);
        }
    }

    public void Decrease()
    {
        transform.localScale *= 0.5f;
        _chanceToSplit *= 0.5f;
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }
}
