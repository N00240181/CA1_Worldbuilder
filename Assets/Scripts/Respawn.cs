using UnityEngine;
using UnityEngine.InputSystem;

public class RespawnPlayer : MonoBehaviour
{
    [Header("Respawn Settings")]
    public Transform spawnPoint;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.rKey.wasPressedThisFrame)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        if (spawnPoint == null)
        {
            Debug.LogWarning("No spawn point assigned!");
            return;
        }

        if (controller != null)
            controller.enabled = false;

        transform.position = spawnPoint.position;

        if (controller != null)
            controller.enabled = true;
    }
}