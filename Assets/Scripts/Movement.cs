using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float mainThrust = 1500f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip metroidEngine;
    [SerializeField] ParticleSystem mainThrusterParticle;
    [SerializeField] ParticleSystem rightThrusterParticle;
    [SerializeField] ParticleSystem leftThrusterParticle;

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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    void StartThrusting()
    {
        // Debug.Log("Pressed SPACE - Thrusting");
        rigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(metroidEngine);
        }

        if (!mainThrusterParticle.isPlaying)
        {
            mainThrusterParticle.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainThrusterParticle.Stop();
    }

    void RotateLeft()
    {
        ApplyRotation(rotationThrust);

        if (!rightThrusterParticle.isPlaying)
        {
            rightThrusterParticle.Play();
        }
    }

    void RotateRight()
    {
        ApplyRotation(-rotationThrust);

        if (!leftThrusterParticle.isPlaying)
        {
            leftThrusterParticle.Play();
        }
    }

    void StopRotating()
    {
        rightThrusterParticle.Stop();
        leftThrusterParticle.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rigidBody.freezeRotation = true; // Freezing rotation for smooth manual rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigidBody.freezeRotation = false; // Unfreezing rotation for the dominance of physics system
    }

}