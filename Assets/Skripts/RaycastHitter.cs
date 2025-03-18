using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHitter : MonoBehaviour
{
    [SerializeField] private float _rayLength = 15f;
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _inputReader.MouseButtonPressed += Hit;
    }

    private void OnDisable()
    {
        _inputReader.MouseButtonPressed -= Hit;
    }

    private void Hit() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayLength))
        {
            IDamageable damage = hit.collider.GetComponent<IDamageable>();

            if (damage != null)
            {
                damage.TakeDamage();
            }
        }
    }
}
