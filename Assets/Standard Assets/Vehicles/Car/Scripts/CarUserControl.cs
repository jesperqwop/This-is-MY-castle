using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{

    [RequireComponent(typeof(CarController))]
    public class CarUserControl : MonoBehaviour
    {

        public float player;
        public GameObject sittingPlayer;

        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {

            if (player == 1)
            {            // pass the input to the car!
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");

                float handbrake = CrossPlatformInputManager.GetAxis("Jump");
                m_Car.Move(h, v, v, handbrake);
                m_Car.Move(h, v, v, 0f);
            }
            if (player == 2)
            {            // pass the input to the car!
                float h = CrossPlatformInputManager.GetAxis("Horizontal2");
                float v = CrossPlatformInputManager.GetAxis("Vertical2");

                float handbrake = CrossPlatformInputManager.GetAxis("Jump");
                m_Car.Move(h, v, v, handbrake);
                m_Car.Move(h, v, v, 0f);
            }
        }
    }
}
