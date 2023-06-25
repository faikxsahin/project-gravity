using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 1500f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip metroidEngine;

    Rigidbody rigidBody;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Debug.Log("Pressed SPACE - Thrusting");
            rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(metroidEngine);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // Debug.Log("Pressed A - Rotating Left");
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Debug.Log("Pressed D - Rotating Right");
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rigidBody.freezeRotation = true; // Freezing rotation for smooth manual rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigidBody.freezeRotation = false; // Unfreezing rotation for the dominance of physics system
    }

}