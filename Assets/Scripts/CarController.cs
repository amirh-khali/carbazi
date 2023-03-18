using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

    public AudioSource HornSound;
    public Button m_Button;
    public Light LeftLight;
    public Light RightLight;

    public float MaxSpeed;
    public float Speed;
    public float IncAcceleration;
    public float DecAcceleration;
    public float RotateValue;

    // Start is called before the first frame update
    void Start()
    {   
        this.MaxSpeed *= Time.deltaTime;
        this.DecAcceleration *= Time.deltaTime;
        this.IncAcceleration *= Time.deltaTime;
        this.RotateValue *= Time.deltaTime;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            if (this.Speed < this.MaxSpeed) {
                this.Speed += this.IncAcceleration; 
            }
        } else if (Input.GetKey(KeyCode.S)) {
            if (this.Speed > this.MaxSpeed * -1 / 2) {
                this.Speed -= this.IncAcceleration; 
            }
        } else {
            if (this.Speed > 0) {
                this.Speed = Math.Max(0, this.Speed - this.DecAcceleration);
            } else if (this.Speed < 0) {
                this.Speed = Math.Min(0, this.Speed + this.DecAcceleration);
            }
        }

        if (Input.GetKey(KeyCode.A)) {
            if (this.Speed > 0) {
                this.gameObject.transform.Rotate(0, this.RotateValue * -1, 0);
            } else if (this.Speed < 0) {
                this.gameObject.transform.Rotate(0, this.RotateValue, 0);
            }
        }

        if (Input.GetKey(KeyCode.D)) {
            if (this.Speed > 0) {
                this.gameObject.transform.Rotate(0, this.RotateValue, 0);
            } else if (this.Speed < 0) {
                this.gameObject.transform.Rotate(0, this.RotateValue * -1, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            HornSound.Play();
        }

        if (Input.GetKeyUp(KeyCode.P)) {
            HornSound.Stop();
        }

        this.gameObject.transform.Translate(this.Speed * Time.deltaTime * -1, 0, 0);
    }


    private void OnTriggerEnter(Collider other) {
        LeftLight.enabled = true;
        RightLight.enabled = true;
    }
    
    private void OnTriggerExit(Collider other) {
        LeftLight.enabled = false;
        RightLight.enabled = false;
    }

}
