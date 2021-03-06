﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles player interaction with interactables.
/// </summary>
public class PlayerInteraction : MonoBehaviour
{
    public AudioClip interactSound;

    private bool isTouchingInteractable = false;
    private GameObject interactable;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameManager.GetAudioManager();
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact") && isTouchingInteractable)
        {
            audioManager.PlaySFX(interactSound);
            interactable.GetComponent<Interactable>().Interact();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Interactable")
        {
            isTouchingInteractable = true;
            interactable = collider.gameObject;
        }
    }

    void OnTriggerExit2D()
    {
        isTouchingInteractable = false;
    }
}
