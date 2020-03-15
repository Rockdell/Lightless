﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameObject player;
    public GameObject pauseMenuCanvas;
    private InputActions inputActions;
    private PlayerScript playerScript;
    private PauseMenu pauseMenuScript;

    private void Awake() {
        inputActions = new InputActions();
        playerScript = player.GetComponent<PlayerScript>();
        pauseMenuScript = pauseMenuCanvas.GetComponent<PauseMenu>();
        inputActions.Player.Move.performed += ctx => playerScript.UpdateMovement(ctx.ReadValue<Vector2>());
        inputActions.Player.Look.performed += ctx => playerScript.UpdateCrosshair(ctx.ReadValue<Vector2>());
        inputActions.Player.Shoot.performed += _ => playerScript.Shoot();
        inputActions.Player.Pause.performed += _ => pauseMenuScript.PauseKeyPressed();
        
        //TODO remove?
        inputActions.Player.GrenadeThrow.performed += _ => playerScript.SetIsAimingToTrue();
        //

        inputActions.Player.GrenadeThrow.canceled += _ => playerScript.ThrowGrenade();
    }

    private void OnEnable() {
        inputActions.Enable();
    }

    private void OnDisable() {
        inputActions.Disable();
    }
}
