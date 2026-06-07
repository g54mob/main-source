using System;
using UnityEngine;

[AddComponentMenu("BoneCracker Games/Simple Car Controller/SCC Drivetrain")]
[RequireComponent(typeof(Rigidbody))]
public class SCC_Drivetrain : MonoBehaviour
{
	[Serializable]
	public class SCC_Wheels
	{
		public Transform wheelTransform;

		public SCC_Wheel wheelCollider;

		public bool isSteering;

		[Range(-45f, 45f)]
		public float steeringAngle = 25f;

		public bool isTraction;

		public bool isBrake;

		public bool isHandbrake;
	}

	private SCC_Network net;

	private Rigidbody rigid;

	public SCC_Wheels[] wheels;

	private SCC_InputProcessor inputProcessor;

	[Header("Steering Settings")]
	[Tooltip("Steer input'i ters çevirmek için bunu işaretle.")]
	public bool invertSteerInput;

	[Header("Steering Wheel Visual")]
	[Tooltip("Aracın içindeki direksiyon modeli.")]
	public Transform steeringWheel;

	[Tooltip("Direksiyonun maksimum dönüş açısı (sağ/sol).")]
	public float steeringWheelMaxAngle = 180f;

	private Quaternion steeringWheelDefaultLocalRotation;

	public Transform COM;

	public float speed;

	public float currentEngineRPM;

	public float minimumEngineRPM = 650f;

	public float maximumEngineRPM = 7000f;

	public float engineTorque = 1000f;

	public float brakeTorque = 1000f;

	public float maximumSpeed = 100f;

	public int direction = 1;

	public float finalDriveRatio = 3.2f;

	public float highSpeedSteerAngle = 100f;

	private float timerForReverse;

	private bool appliedBrake;

	private SCC_Network Net
	{
		get
		{
			if (net == null)
			{
				net = GetComponent<SCC_Network>();
			}
			return net;
		}
	}

	private Rigidbody Rigid
	{
		get
		{
			if (rigid == null)
			{
				rigid = GetComponent<Rigidbody>();
			}
			return rigid;
		}
	}

	private SCC_InputProcessor InputProcessor
	{
		get
		{
			if (inputProcessor == null)
			{
				inputProcessor = GetComponent<SCC_InputProcessor>();
			}
			return inputProcessor;
		}
	}

	private void Awake()
	{
		if (steeringWheel != null)
		{
			steeringWheelDefaultLocalRotation = steeringWheel.localRotation;
		}
	}

	private void FixedUpdate()
	{
		Engine();
		ApplySteering();
		ApplyTraction();
		ApplyBrake();
		ApplyHandBrake();
		Others();
	}

	private void Engine()
	{
		if (Net != null && (!Net.isOwned || Net.IsTravelLocked))
		{
			currentEngineRPM = Net.syncEngineRPM;
			return;
		}
		float num = 0f;
		int num2 = 0;
		for (int i = 0; i < wheels.Length; i++)
		{
			if (wheels[i].isTraction)
			{
				num += Mathf.Abs(wheels[i].wheelCollider.wheelRPMToSpeed);
			}
			num2++;
		}
		currentEngineRPM = Mathf.Lerp(minimumEngineRPM, maximumEngineRPM, num / (float)num2 / maximumSpeed);
	}

	private void ApplySteering()
	{
		float num = ((!(Net != null) || Net.isOwned) ? InputProcessor.inputs.steerInput : Net.syncSteerInput);
		if (invertSteerInput)
		{
			num = 0f - num;
		}
		float num2 = Mathf.Lerp(1f, 0.25f, speed / highSpeedSteerAngle);
		for (int i = 0; i < wheels.Length; i++)
		{
			if (wheels[i].isSteering)
			{
				wheels[i].wheelCollider.WheelCollider.steerAngle = wheels[i].steeringAngle * num * num2;
			}
			else
			{
				wheels[i].wheelCollider.WheelCollider.steerAngle = 0f;
			}
		}
		if (steeringWheel != null)
		{
			float y = steeringWheelMaxAngle * num * num2;
			steeringWheel.localRotation = steeringWheelDefaultLocalRotation * Quaternion.Euler(0f, y, 0f);
		}
	}

	private void ApplyTraction()
	{
		int num = 0;
		for (int i = 0; i < wheels.Length; i++)
		{
			if (wheels[i].isTraction)
			{
				num++;
			}
		}
		for (int j = 0; j < wheels.Length; j++)
		{
			if (wheels[j].isTraction)
			{
				wheels[j].wheelCollider.WheelCollider.motorTorque = engineTorque * finalDriveRatio * ((direction == 1) ? InputProcessor.inputs.throttleInput : (0f - InputProcessor.inputs.brakeInput)) / (float)Mathf.Clamp(num, 1, 20);
			}
			else
			{
				wheels[j].wheelCollider.WheelCollider.motorTorque = 0f;
			}
			if ((speed >= maximumSpeed || wheels[j].wheelCollider.wheelRPMToSpeed >= maximumSpeed) && wheels[j].isTraction)
			{
				wheels[j].wheelCollider.WheelCollider.motorTorque = 0f;
			}
		}
	}

	private void ApplyBrake()
	{
		appliedBrake = false;
		int num = 0;
		for (int i = 0; i < wheels.Length; i++)
		{
			if (wheels[i].isBrake)
			{
				num++;
			}
		}
		for (int j = 0; j < wheels.Length; j++)
		{
			if (wheels[j].isBrake)
			{
				wheels[j].wheelCollider.WheelCollider.brakeTorque = brakeTorque * ((direction == 1) ? InputProcessor.inputs.brakeInput : InputProcessor.inputs.throttleInput) / (float)Mathf.Clamp(num, 1, 20);
				if (wheels[j].wheelCollider.WheelCollider.brakeTorque >= 5f)
				{
					appliedBrake = true;
				}
			}
			else
			{
				wheels[j].wheelCollider.WheelCollider.brakeTorque = 0f;
			}
		}
	}

	private void ApplyHandBrake()
	{
		if (appliedBrake)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < wheels.Length; i++)
		{
			if (wheels[i].isHandbrake)
			{
				num++;
			}
		}
		for (int j = 0; j < wheels.Length; j++)
		{
			if (wheels[j].isHandbrake)
			{
				wheels[j].wheelCollider.WheelCollider.brakeTorque = brakeTorque * InputProcessor.inputs.handbrakeInput / (float)Mathf.Clamp(num, 1, 20);
			}
			else
			{
				wheels[j].wheelCollider.WheelCollider.brakeTorque = 0f;
			}
		}
	}

	private void Others()
	{
		Rigid.centerOfMass = COM.localPosition;
		if (Net != null && (!Net.isOwned || Net.IsTravelLocked))
		{
			speed = Net.syncSpeed;
		}
		else
		{
			speed = Rigid.linearVelocity.magnitude * 3.6f;
		}
		if (speed <= 5f && InputProcessor.inputs.brakeInput >= 0.75f)
		{
			timerForReverse += Time.fixedDeltaTime;
		}
		else if (speed <= 5f && InputProcessor.inputs.brakeInput <= 0.25f)
		{
			timerForReverse = 0f;
		}
		direction = ((!(timerForReverse >= 0.1f)) ? 1 : (-1));
	}

	private void Reset()
	{
		if (!GetComponent<Rigidbody>())
		{
			base.gameObject.AddComponent<Rigidbody>();
		}
		if (!GetComponent<SCC_InputProcessor>())
		{
			base.gameObject.AddComponent<SCC_InputProcessor>();
		}
		if (!GetComponent<SCC_Audio>())
		{
			base.gameObject.AddComponent<SCC_Audio>();
		}
		if (!GetComponent<SCC_Particles>())
		{
			base.gameObject.AddComponent<SCC_Particles>();
		}
		if (!GetComponent<SCC_AntiRoll>())
		{
			base.gameObject.AddComponent<SCC_AntiRoll>();
		}
		if (!GetComponent<SCC_RigidStabilizer>())
		{
			base.gameObject.AddComponent<SCC_RigidStabilizer>();
		}
		base.gameObject.GetComponent<Rigidbody>().mass = 1350f;
		base.gameObject.GetComponent<Rigidbody>().linearDamping = 0.01f;
		base.gameObject.GetComponent<Rigidbody>().angularDamping = 0.5f;
		base.gameObject.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
		base.gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
		GameObject gameObject = new GameObject("COM");
		gameObject.transform.SetParent(base.transform, worldPositionStays: false);
		gameObject.transform.localPosition = new Vector3(0f, -0.2f, 0f);
		COM = gameObject.transform;
	}
}
