using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandejaTilting : MonoBehaviour
{
    public float bandejaRotationSpeed = 100f;
    public float maxBandejaRotation = 25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x_input = Input.GetAxis("Horizontal");
        float z_input = Input.GetAxis("Vertical");
        
        if (z_input == 0)
        {
            // volver a la inclinacion 0 de x
            float x_angle = WrapAngle(transform.localEulerAngles.x);
            if (x_angle > 0.5)
            {
                transform.Rotate(Vector3.left * Time.deltaTime * bandejaRotationSpeed);
            }
            else if(x_angle < -0.5)
            {
                transform.Rotate(Vector3.right * Time.deltaTime * bandejaRotationSpeed);
            }
        }
        else
        {
            
            float x_angle = WrapAngle(transform.localEulerAngles.x);
            if (x_angle >= maxBandejaRotation && z_input > 0)
            {
                transform.localEulerAngles = new Vector3( UnwrapAngle(maxBandejaRotation),0, transform.localEulerAngles.z);
            }
            else if(x_angle <= -maxBandejaRotation && z_input < 0)
            {
                transform.localEulerAngles = new Vector3( UnwrapAngle(-maxBandejaRotation),0, transform.localEulerAngles.z);
            }
            else
            {
                Vector3 newRotation = new Vector3(z_input,0,0);
                transform.Rotate(newRotation * Time.deltaTime * bandejaRotationSpeed);
            }
        }
        if (x_input == 0)
        {
            // volver a la inclinacion 0 de z
            float z_angle = WrapAngle(transform.localEulerAngles.z);
            if (z_angle > 0.5)
            {
                transform.Rotate(Vector3.back * Time.deltaTime * bandejaRotationSpeed);
            }
            else if(z_angle < -0.5)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * bandejaRotationSpeed);
            }
        }
        else
        {
            float z_angle = WrapAngle(transform.localEulerAngles.z);
            // float x_angle = WrapAngle(bandeja.localEulerAngles.x);
            if (z_angle >= maxBandejaRotation && x_input < 0)
            {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,0,UnwrapAngle(maxBandejaRotation) );
            }
            else if (z_angle <= -maxBandejaRotation && x_input > 0)
            {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,0, UnwrapAngle(-maxBandejaRotation) );
            }
            else
            {
                Vector3 newRotation = new Vector3(0,0,-x_input);
                transform.Rotate(newRotation * Time.deltaTime * bandejaRotationSpeed);
            }
        }
    }
    
    private static float WrapAngle(float angle)
    {
        angle%=360;
        if(angle >180)
            return angle - 360;

        return angle;
    }

    private static float UnwrapAngle(float angle)
    {
        if(angle >=0)
            return angle;

        angle = -angle%360;

        return 360-angle;
    }
}
