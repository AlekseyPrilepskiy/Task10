using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour, IDamageable
{
    [SerializeField] private float _chanceToSplit = 100f;
    [SerializeField] private float _decreaseScaleCoefficient = 0.5f;
    [SerializeField] private float _decreaseSplitChanceCoefficient = 0.5f;

    private Renderer _renderer;
    private Rigidbody _rigidBody;

    private int _minimalChance = 0;
    private int _maximalChance = 100;

    public event Action<Cube> Splitted;
    public event Action Destroyed;

    public Renderer Renderer => _renderer;
    public Rigidbody RigidBody => _rigidBody;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void TakeDamage()
    {
        if (_chanceToSplit >= Random.Range(_minimalChance, _maximalChance + 1))
        {
            Splitted?.Invoke(this);
        }
        else
        {
            Destroyed?.Invoke();
        }

        Destroy(gameObject);
    }

    public void Decrease()
    {
        transform.localScale *= _decreaseScaleCoefficient;
        _chanceToSplit *= _decreaseSplitChanceCoefficient;
    }
}
