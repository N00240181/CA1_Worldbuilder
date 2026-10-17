
using UnityEngine;
using System.Collections;

public class TeleportPad : MonoBehaviour
{
    [Header("Teleport Settings")]
    public Transform destination;
    public float cooldown = 1.5f;

    [Header("Departure Sound")]
    public AudioClip departureSound;
    [Range(0f, 1f)]
    public float departureVolume = 1f;

    [Header("Arrival Sound")]
    public AudioClip arrivalSound;
    [Range(0f, 1f)]
    public float arrivalVolume = 1f;

    private static bool isTeleporting = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (isTeleporting)
            return;

        if (destination == null)
        {
            Debug.LogWarning("No teleport destination assigned!", this);
            return;
        }

        CharacterController controller =
            other.GetComponent<CharacterController>();

        if (controller == null)
            return;

        StartCoroutine(TeleportPlayer(other, controller));
    }

    private IEnumerator TeleportPlayer(
        Collider player,
        CharacterController controller)
    {
        isTeleporting = true;

        if (departureSound != null)
        {
            AudioSource.PlayClipAtPoint(
                departureSound, transform.position, departureVolume);
        }

        controller.enabled = false;
        player.transform.position = destination.position;
        controller.enabled = true;

        if (arrivalSound != null)
        {
            AudioSource.PlayClipAtPoint(
                arrivalSound, destination.position, arrivalVolume);
        }

        yield return new WaitForSeconds(cooldown);

        isTeleporting = false;
    }
}
