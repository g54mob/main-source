using System.Collections.Generic;
using MyBox;
using UnityEngine;
using UnityEngine.UI;

public class AirplaneController : MonoBehaviour
{
	[SerializeField]
	private ThrottleComponent _throttleComponent;

	[SerializeField]
	private List<AeroSurface> controlSurfaces;

	[SerializeField]
	private List<WheelCollider> wheels;

	[SerializeField]
	private float rollControlSensitivity = 0.2f;

	[SerializeField]
	private float pitchControlSensitivity = 0.2f;

	[SerializeField]
	private float yawControlSensitivity = 0.2f;

	[SerializeField]
	private WheelCollider leftWheel;

	[SerializeField]
	private WheelCollider rightWheel;

	[SerializeField]
	private float _rotationDampingRate = 50f;

	[Range(-1f, 1f)]
	public float Pitch;

	[Range(-1f, 1f)]
	public float Yaw;

	[Range(-1f, 1f)]
	public float Roll;

	[Range(0f, 1f)]
	public float Flap;

	[SerializeField]
	private Text displayText;

	[Range(0f, 1f)]
	public float thrustPercent;

	[Range(0f, 1f)]
	public float handBreakPercent = 1f;

	[SerializeField]
	private bool _isAi;

	[SerializeField]
	private float _maxBreakTorque = 50000f;

	[ReadOnly(new string[] { })]
	public float brakesTorque = 50000f;

	private float leftWheelDefaultDamping;

	private float rightWheelDefaultDamping;

	private AircraftPhysics aircraftPhysics;

	private Rigidbody rb;

	private void Start()
	{
		aircraftPhysics = GetComponent<AircraftPhysics>();
		rb = GetComponent<Rigidbody>();
		leftWheelDefaultDamping = leftWheel.wheelDampingRate;
		rightWheelDefaultDamping = rightWheel.wheelDampingRate;
		handBreakPercent = 1f;
	}

	private void Update()
	{
		if (!_isAi)
		{
			if (displayText != null)
			{
				displayText.text = "V: " + ((int)rb.linearVelocity.magnitude).ToString("D3") + " m/s\n";
				Text text = displayText;
				text.text = text.text + "A: " + ((int)base.transform.position.y).ToString("D4") + " m\n";
				Text text2 = displayText;
				text2.text = text2.text + "T: " + (int)(thrustPercent * 100f) + "%\n";
				displayText.text += ((brakesTorque > 0f) ? "B: ON" : "B: OFF");
			}
			Pitch = Input.GetAxis("Vertical");
			Roll = Input.GetAxis("Horizontal");
			Yaw = Input.GetAxis("Yaw");
			if (Input.GetKeyDown(KeyCode.Space))
			{
				thrustPercent = ((thrustPercent > 0f) ? 0f : 1f);
			}
			if (Input.GetKeyDown(KeyCode.V))
			{
				Flap = ((Flap > 0f) ? 0f : 0.3f);
			}
			if (Input.GetKeyDown(KeyCode.B))
			{
				handBreakPercent = ((!(handBreakPercent > 0f)) ? 1 : 0);
			}
			_throttleComponent.ForceThrottle(thrustPercent);
		}
	}

	private void FixedUpdate()
	{
		SetControlSurfecesAngles(Pitch, Roll, Yaw, Flap);
		UpdateWheelsPhysics();
		if (Yaw < 0f)
		{
			leftWheel.wheelDampingRate = _rotationDampingRate;
			rightWheel.wheelDampingRate = rightWheelDefaultDamping;
		}
		else if (Yaw > 0f)
		{
			rightWheel.wheelDampingRate = _rotationDampingRate;
			leftWheel.wheelDampingRate = leftWheelDefaultDamping;
		}
		else
		{
			leftWheel.wheelDampingRate = leftWheelDefaultDamping;
			rightWheel.wheelDampingRate = rightWheelDefaultDamping;
		}
	}

	public void UpdateWheelsPhysics()
	{
		foreach (WheelCollider wheel in wheels)
		{
			wheel.motorTorque = 0.01f;
			wheel.brakeTorque = _maxBreakTorque * handBreakPercent;
		}
	}

	public void AddThrust(float value)
	{
		thrustPercent = Mathf.Clamp01(thrustPercent + value);
	}

	public void AddBrakes(float value)
	{
		handBreakPercent = Mathf.Clamp01(handBreakPercent + value);
	}

	public void SetControlSurfecesAngles(float pitch, float roll, float yaw, float flap)
	{
		foreach (AeroSurface controlSurface in controlSurfaces)
		{
			if (!(controlSurface == null) && controlSurface.IsControlSurface)
			{
				switch (controlSurface.InputType)
				{
				case ControlInputType.Pitch:
					controlSurface.SetFlapAngle(pitch * pitchControlSensitivity * controlSurface.InputMultiplyer);
					break;
				case ControlInputType.Roll:
					controlSurface.SetFlapAngle(roll * rollControlSensitivity * controlSurface.InputMultiplyer);
					break;
				case ControlInputType.Yaw:
					controlSurface.SetFlapAngle((0f - yaw) * yawControlSensitivity * controlSurface.InputMultiplyer);
					break;
				case ControlInputType.Flap:
					controlSurface.SetFlapAngle(Flap * controlSurface.InputMultiplyer);
					break;
				}
			}
		}
	}

	private void OnDrawGizmos()
	{
		if (!Application.isPlaying)
		{
			SetControlSurfecesAngles(Pitch, Roll, Yaw, Flap);
		}
	}
}
