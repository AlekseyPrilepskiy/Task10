using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action MouseButtonPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseButtonPressed?.Invoke();
            Debug.Log("Клавиша нажата.");
        }
    }
}
