﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granny : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Animator Animator;

    public void Interact()
    {
        Animator.SetBool("IsTalking", true);
    }
    public void CancelInteract()
    {
        Debug.Log("cancel");
        Animator.SetBool("IsTalking", false);
    }
    public MonoBehaviour GetMonoBehaviour()
    {
        return this;
    }

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
    }
}
