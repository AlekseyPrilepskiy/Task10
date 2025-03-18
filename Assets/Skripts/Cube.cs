using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour, IDamageable
{
    [SerializeField] private float _chanceToSplit = 100f;
    [SerializeField] private float _decreaseScaleCoefficient = 0.5f;
    [SerializeField] private float _decreaseSplitChanceCoefficient = 0.5f;

    private Renderer _renderer;

    public event Action<Cube> BlownUp;

    public Renderer Renderer => _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void TakeDamage()
    {
        if (_chanceToSplit >= Random.Range(0, 101))
        {
            BlownUp?.Invoke(this);
        }

        Destroy(gameObject);
    }

    public void Decrease()
    {
        transform.localScale *= _decreaseScaleCoefficient;
        _chanceToSplit *= _decreaseSplitChanceCoefficient;
    }

    public void Recolor()
    {
        if (Renderer != null)
        {
            Renderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
        else
            Debug.Log("GAY");
    }
}
