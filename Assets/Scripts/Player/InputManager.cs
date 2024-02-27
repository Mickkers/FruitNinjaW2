using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.GameplayActions gameplay;

    private TouchArea player;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<TouchArea>();
    }
    void Awake()
    {
        playerInput = new PlayerInput();
        gameplay = playerInput.Gameplay;
    }

    private void OnEnable()
    {
        gameplay.Enable();
    }

    private void OnDisable()
    {
        gameplay.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        player.SetValues(gameplay.Position.ReadValue<Vector2>(), gameplay.Clicked.IsPressed());
    }
}