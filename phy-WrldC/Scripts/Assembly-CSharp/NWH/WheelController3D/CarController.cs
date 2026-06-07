using System.Collections.Generic;
using UnityEngine;

namespace NWH.WheelController3D
{
	public class CarController : MonoBehaviour
	{
		public bool vehicleIsActive;

		public bool trackSteer;

		[SerializeField]
		public List<_Wheel> wheels;

		private float xAxis;

		private float smoothXAxis;

		private float xAxisVelocity;

		private float yAxis;

		[HideInInspector]
		public float velocity;

		public float maxSteeringAngle = 35f;

		public float minSteeringAngle = 20f;

		public float maxMotorTorque;

		public float maxBrakeTorque;

		public float antiRollBarForce;

		public void FixedUpdate()
		{
			if (vehicleIsActive)
			{
				xAxis = Input.GetAxis("Horizontal");
				yAxis = Input.GetAxis("Vertical");
				velocity = base.transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z;
				smoothXAxis = Mathf.SmoothDamp(smoothXAxis, xAxis, ref xAxisVelocity, 0.12f);
				foreach (_Wheel wheel in wheels)
				{
					if (Input.GetKey(KeyCode.Space))
					{
						wheel.wc.brakeTorque = maxBrakeTorque;
					}
					else
					{
						wheel.wc.brakeTorque = 0f;
					}
					if (Mathf.Sign(velocity) < 0.1f && yAxis > 0.1f)
					{
						wheel.wc.brakeTorque = maxBrakeTorque;
					}
					if (wheel.power)
					{
						wheel.wc.motorTorque = maxMotorTorque * yAxis;
					}
					if (wheel.steer)
					{
						wheel.wc.steerAngle = Mathf.Lerp(maxSteeringAngle, minSteeringAngle, Mathf.Abs(velocity) * 0.05f) * xAxis;
					}
				}
			}
			ApplyAntirollBar();
		}

		public void ApplyAntirollBar()
		{
			for (int i = 0; i < wheels.Count; i += 2)
			{
				WheelController wc = wheels[i].wc;
				WheelController wc2 = wheels[i + 1].wc;
				if (!wc.springOverExtended && !wc.springBottomedOut && !wc2.springOverExtended && !wc2.springBottomedOut)
				{
					float springTravel = wc.springTravel;
					float springTravel2 = wc2.springTravel;
					float num = (springTravel - springTravel2) * antiRollBarForce;
					if (wc.isGrounded)
					{
						wc.parent.GetComponent<Rigidbody>().AddForceAtPosition(wc.wheel.up * (0f - num), wc.wheel.worldPosition);
					}
					if (wc2.isGrounded)
					{
						wc2.parent.GetComponent<Rigidbody>().AddForceAtPosition(wc2.wheel.up * num, wc2.wheel.worldPosition);
					}
				}
			}
		}

		public void Active(bool state)
		{
			vehicleIsActive = state;
		}

		public void OnMotorValueChanged(float v)
		{
			maxMotorTorque = v;
		}

		public void OnBrakeValueChanged(float a)
		{
			maxBrakeTorque = a;
		}
	}
}
