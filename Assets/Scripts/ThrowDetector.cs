using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ThrowDetector : MonoBehaviour
{
    private GameManager gameManager;
    private XRGrabInteractable grabInteractable;
    private bool wasThrown = false;
    private bool hasScored = false;


    void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.selectExited.AddListener(OnSelectExited);
            grabInteractable.selectEntered.AddListener(OnSelectEntered);
        }
    }


    private void OnSelectExited(SelectExitEventArgs args)
    {
        wasThrown = true;
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        wasThrown = false;
        hasScored = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (wasThrown && !hasScored && other.CompareTag("TargetZone"))
        {
           
            AudioSource trashcanAudioSource = other.GetComponent<AudioSource>();

            if (trashcanAudioSource != null)
            {
                trashcanAudioSource.Play();
            }

           
            if (gameManager != null)
            {
                gameManager.IncrementThrowCount();
                hasScored = true;
            }

            Destroy(gameObject); 
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude < 0.2f)
        {
            wasThrown = false;
        }
    }
}