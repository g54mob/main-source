using System;
using UnityEngine;
using UnityEngine.UI;

public class PrometeoCarController : MonoBehaviour
{
	[Space(20f)]
	[Space(10f)]
	[Range(20f, 190f)]
	public int maxSpeed = 90;

	[Range(10f, 120f)]
	public int maxReverseSpeed = 45;

	[Range(1f, 10f)]
	public int accelerationMultiplier = 2;

	[Space(10f)]
	[Range(10f, 45f)]
	public int maxSteeringAngle = 27;

	[Range(0.1f, 1f)]
	public float steeringSpeed = 0.5f;

	[Space(10f)]
	[Range(100f, 600f)]
	public int brakeForce = 350;

	[Range(1f, 10f)]
	public int decelerationMultiplier = 2;

	[Range(1f, 10f)]
	public int handbrakeDriftMultiplier = 5;

	[Space(10f)]
	public Vector3 bodyMassCenter;

	public GameObject frontLeftMesh;

	public WheelCollider frontLeftCollider;

	[Space(10f)]
	public GameObject frontRightMesh;

	public WheelCollider frontRightCollider;

	[Space(10f)]
	public GameObject rearLeftMesh;

	public WheelCollider rearLeftCollider;

	[Space(10f)]
	public GameObject rearRightMesh;

	public WheelCollider rearRightCollider;

	[Space(20f)]
	[Space(10f)]
	public bool useEffects;

	public ParticleSystem RLWParticleSystem;

	public ParticleSystem RRWParticleSystem;

	[Space(10f)]
	public TrailRenderer RLWTireSkid;

	public TrailRenderer RRWTireSkid;

	[Space(20f)]
	[Space(10f)]
	public bool useUI;

	public Text carSpeedText;

	[Space(20f)]
	[Space(10f)]
	public bool useSounds;

	public AudioSource carEngineSound;

	public AudioSource tireScreechSound;

	private float initialCarEngineSoundPitch;

	[Space(20f)]
	[Space(10f)]
	public bool useTouchControls;

	public GameObject throttleButton;

	private PrometeoTouchInput throttlePTI;

	public GameObject reverseButton;

	private PrometeoTouchInput reversePTI;

	public GameObject turnRightButton;

	private PrometeoTouchInput turnRightPTI;

	public GameObject turnLeftButton;

	private PrometeoTouchInput turnLeftPTI;

	public GameObject handbrakeButton;

	private PrometeoTouchInput handbrakePTI;

	[HideInInspector]
	public float carSpeed;

	[HideInInspector]
	public bool isDrifting;

	[HideInInspector]
	public bool isTractionLocked;

	private Rigidbody carRigidbody;

	private float steeringAxis;

	private float throttleAxis;

	private float driftingAxis;

	private float localVelocityZ;

	private float localVelocityX;

	private bool deceleratingCar;

	private bool touchControlsSetup;

	private bool isSoundOn;

	private WheelFrictionCurve FLwheelFriction;

	private float FLWextremumSlip;

	private WheelFrictionCurve FRwheelFriction;

	private float FRWextremumSlip;

	private WheelFrictionCurve RLwheelFriction;

	private float RLWextremumSlip;

	private WheelFrictionCurve RRwheelFriction;

	private float RRWextremumSlip;

	private void Start()
	{
		carRigidbody = base.gameObject.GetComponent<Rigidbody>();
		carRigidbody.centerOfMass = bodyMassCenter;
		FLwheelFriction = default(WheelFrictionCurve);
		FLwheelFriction.extremumSlip = frontLeftCollider.sidewaysFriction.extremumSlip;
		FLWextremumSlip = frontLeftCollider.sidewaysFriction.extremumSlip;
		FLwheelFriction.extremumValue = frontLeftCollider.sidewaysFriction.extremumValue;
		FLwheelFriction.asymptoteSlip = frontLeftCollider.sidewaysFriction.asymptoteSlip;
		FLwheelFriction.asymptoteValue = frontLeftCollider.sidewaysFriction.asymptoteValue;
		FLwheelFriction.stiffness = frontLeftCollider.sidewaysFriction.stiffness;
		FRwheelFriction = default(WheelFrictionCurve);
		FRwheelFriction.extremumSlip = frontRightCollider.sidewaysFriction.extremumSlip;
		FRWextremumSlip = frontRightCollider.sidewaysFriction.extremumSlip;
		FRwheelFriction.extremumValue = frontRightCollider.sidewaysFriction.extremumValue;
		FRwheelFriction.asymptoteSlip = frontRightCollider.sidewaysFriction.asymptoteSlip;
		FRwheelFriction.asymptoteValue = frontRightCollider.sidewaysFriction.asymptoteValue;
		FRwheelFriction.stiffness = frontRightCollider.sidewaysFriction.stiffness;
		RLwheelFriction = default(WheelFrictionCurve);
		RLwheelFriction.extremumSlip = rearLeftCollider.sidewaysFriction.extremumSlip;
		RLWextremumSlip = rearLeftCollider.sidewaysFriction.extremumSlip;
		RLwheelFriction.extremumValue = rearLeftCollider.sidewaysFriction.extremumValue;
		RLwheelFriction.asymptoteSlip = rearLeftCollider.sidewaysFriction.asymptoteSlip;
		RLwheelFriction.asymptoteValue = rearLeftCollider.sidewaysFriction.asymptoteValue;
		RLwheelFriction.stiffness = rearLeftCollider.sidewaysFriction.stiffness;
		RRwheelFriction = default(WheelFrictionCurve);
		RRwheelFriction.extremumSlip = rearRightCollider.sidewaysFriction.extremumSlip;
		RRWextremumSlip = rearRightCollider.sidewaysFriction.extremumSlip;
		RRwheelFriction.extremumValue = rearRightCollider.sidewaysFriction.extremumValue;
		RRwheelFriction.asymptoteSlip = rearRightCollider.sidewaysFriction.asymptoteSlip;
		RRwheelFriction.asymptoteValue = rearRightCollider.sidewaysFriction.asymptoteValue;
		RRwheelFriction.stiffness = rearRightCollider.sidewaysFriction.stiffness;
		if (carEngineSound != null)
		{
			initialCarEngineSoundPitch = carEngineSound.pitch;
		}
		if (useUI)
		{
			InvokeRepeating("CarSpeedUI", 0f, 0.1f);
		}
		else if (!useUI && carSpeedText != null)
		{
			carSpeedText.text = "0";
		}
		if (useSounds)
		{
			InvokeRepeating("CarSounds", 0f, 0.1f);
		}
		else if (!useSounds)
		{
			if (carEngineSound != null)
			{
				carEngineSound.Stop();
			}
			if (tireScreechSound != null)
			{
				tireScreechSound.Stop();
			}
		}
		if (!useEffects)
		{
			if (RLWParticleSystem != null)
			{
				RLWParticleSystem.Stop();
			}
			if (RRWParticleSystem != null)
			{
				RRWParticleSystem.Stop();
			}
			if (RLWTireSkid != null)
			{
				RLWTireSkid.emitting = false;
			}
			if (RRWTireSkid != null)
			{
				RRWTireSkid.emitting = false;
			}
		}
		if (useTouchControls)
		{
			if (throttleButton != null && reverseButton != null && turnRightButton != null && turnLeftButton != null && handbrakeButton != null)
			{
				throttlePTI = throttleButton.GetComponent<PrometeoTouchInput>();
				reversePTI = reverseButton.GetComponent<PrometeoTouchInput>();
				turnLeftPTI = turnLeftButton.GetComponent<PrometeoTouchInput>();
				turnRightPTI = turnRightButton.GetComponent<PrometeoTouchInput>();
				handbrakePTI = handbrakeButton.GetComponent<PrometeoTouchInput>();
				touchControlsSetup = true;
			}
			else
			{
				Debug.LogWarning("Touch controls are not completely set up. You must drag and drop your scene buttons in the PrometeoCarController component.");
			}
		}
	}

	private void Update()
	{
		carSpeed = MathF.PI * 2f * frontLeftCollider.radius * frontLeftCollider.rpm * 60f / 1000f;
		localVelocityX = base.transform.InverseTransformDirection(carRigidbody.linearVelocity).x;
		localVelocityZ = base.transform.InverseTransformDirection(carRigidbody.linearVelocity).z;
		if (useTouchControls && touchControlsSetup)
		{
			if (throttlePTI.buttonPressed)
			{
				CancelInvoke("DecelerateCar");
				deceleratingCar = false;
				GoForward();
			}
			if (reversePTI.buttonPressed)
			{
				CancelInvoke("DecelerateCar");
				deceleratingCar = false;
				GoReverse();
			}
			if (turnLeftPTI.buttonPressed)
			{
				TurnLeft();
			}
			if (turnRightPTI.buttonPressed)
			{
				TurnRight();
			}
			if (handbrakePTI.buttonPressed)
			{
				CancelInvoke("DecelerateCar");
				deceleratingCar = false;
				Handbrake();
			}
			if (!handbrakePTI.buttonPressed)
			{
				RecoverTraction();
			}
			if (!throttlePTI.buttonPressed && !reversePTI.buttonPressed)
			{
				ThrottleOff();
			}
			if (!reversePTI.buttonPressed && !throttlePTI.buttonPressed && !handbrakePTI.buttonPressed && !deceleratingCar)
			{
				InvokeRepeating("DecelerateCar", 0f, 0.1f);
				deceleratingCar = true;
			}
			if (!turnLeftPTI.buttonPressed && !turnRightPTI.buttonPressed && steeringAxis != 0f)
			{
				ResetSteeringAngle();
			}
		}
		AnimateWheelMeshes();
	}

	private void Temp()
	{
		if (Input.GetKey(KeyCode.W))
		{
			CancelInvoke("DecelerateCar");
			deceleratingCar = false;
			GoForward();
		}
		if (Input.GetKey(KeyCode.S))
		{
			CancelInvoke("DecelerateCar");
			deceleratingCar = false;
			GoReverse();
		}
		if (Input.GetKey(KeyCode.A))
		{
			TurnLeft();
		}
		if (Input.GetKey(KeyCode.D))
		{
			TurnRight();
		}
		if (Input.GetKey(KeyCode.Space))
		{
			CancelInvoke("DecelerateCar");
			deceleratingCar = false;
			Handbrake();
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			RecoverTraction();
		}
		if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
		{
			ThrottleOff();
		}
		if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Space) && !deceleratingCar)
		{
			InvokeRepeating("DecelerateCar", 0f, 0.1f);
			deceleratingCar = true;
		}
		if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && steeringAxis != 0f)
		{
			ResetSteeringAngle();
		}
	}

	public void HandleMovement(float throttle)
	{
		if (throttle > 0f)
		{
			AudioManager.S.RcControlling(controlling: true);
			StopDeceleration();
			GoForward();
		}
		else if (throttle < 0f)
		{
			AudioManager.S.RcControlling(controlling: true);
			StopDeceleration();
			GoReverse();
		}
		else
		{
			AudioManager.S.RcControlling(controlling: false);
			ThrottleOff();
		}
	}

	public void HandleSteering(float steer)
	{
		if (steer < 0f)
		{
			TurnLeft();
		}
		else if (steer > 0f)
		{
			TurnRight();
		}
		if (Mathf.Approximately(steer, 0f) && steeringAxis != 0f)
		{
			ResetSteeringAngle();
		}
	}

	public void HandleDeceleration(float throttle)
	{
		if (Mathf.Approximately(throttle, 0f) && !deceleratingCar)
		{
			InvokeRepeating("DecelerateCar", 0f, 0.1f);
			deceleratingCar = true;
		}
	}

	public void StopDeceleration()
	{
		CancelInvoke("DecelerateCar");
		deceleratingCar = false;
	}

	public void CarSpeedUI()
	{
		if (useUI)
		{
			try
			{
				float f = Mathf.Abs(carSpeed);
				carSpeedText.text = Mathf.RoundToInt(f).ToString();
			}
			catch (Exception message)
			{
				Debug.LogWarning(message);
			}
		}
	}

	public void CarSounds()
	{
		if (useSounds)
		{
			try
			{
				if (carEngineSound != null)
				{
					float pitch = initialCarEngineSoundPitch + Mathf.Abs(carRigidbody.linearVelocity.magnitude) / 25f;
					carEngineSound.pitch = pitch;
				}
				if (isDrifting || (isTractionLocked && Mathf.Abs(carSpeed) > 12f))
				{
					if (!tireScreechSound.isPlaying)
					{
						tireScreechSound.Play();
					}
				}
				else if (!isDrifting && (!isTractionLocked || Mathf.Abs(carSpeed) < 12f))
				{
					tireScreechSound.Stop();
				}
				return;
			}
			catch (Exception message)
			{
				Debug.LogWarning(message);
				return;
			}
		}
		if (!useSounds)
		{
			if (carEngineSound != null && carEngineSound.isPlaying)
			{
				carEngineSound.Stop();
			}
			if (tireScreechSound != null && tireScreechSound.isPlaying)
			{
				tireScreechSound.Stop();
			}
		}
	}

	public void TurnLeft()
	{
		steeringAxis -= Time.deltaTime * 10f * steeringSpeed;
		if (steeringAxis < -1f)
		{
			steeringAxis = -1f;
		}
		float b = steeringAxis * (float)maxSteeringAngle;
		frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, b, steeringSpeed);
		frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, b, steeringSpeed);
	}

	public void TurnRight()
	{
		steeringAxis += Time.deltaTime * 10f * steeringSpeed;
		if (steeringAxis > 1f)
		{
			steeringAxis = 1f;
		}
		float b = steeringAxis * (float)maxSteeringAngle;
		frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, b, steeringSpeed);
		frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, b, steeringSpeed);
	}

	public void ResetSteeringAngle()
	{
		if (steeringAxis < 0f)
		{
			steeringAxis += Time.deltaTime * 10f * steeringSpeed;
		}
		else if (steeringAxis > 0f)
		{
			steeringAxis -= Time.deltaTime * 10f * steeringSpeed;
		}
		if (Mathf.Abs(frontLeftCollider.steerAngle) < 1f)
		{
			steeringAxis = 0f;
		}
		float b = steeringAxis * (float)maxSteeringAngle;
		frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, b, steeringSpeed);
		frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, b, steeringSpeed);
	}

	private void AnimateWheelMeshes()
	{
		try
		{
			frontLeftCollider.GetWorldPose(out var pos, out var quat);
			frontLeftMesh.transform.position = pos;
			frontLeftMesh.transform.rotation = quat;
			frontRightCollider.GetWorldPose(out var pos2, out var quat2);
			frontRightMesh.transform.position = pos2;
			frontRightMesh.transform.rotation = quat2;
			rearLeftCollider.GetWorldPose(out var pos3, out var quat3);
			rearLeftMesh.transform.position = pos3;
			rearLeftMesh.transform.rotation = quat3;
			rearRightCollider.GetWorldPose(out var pos4, out var quat4);
			rearRightMesh.transform.position = pos4;
			rearRightMesh.transform.rotation = quat4;
		}
		catch (Exception message)
		{
			Debug.LogWarning(message);
		}
	}

	public void GoForward()
	{
		if (Mathf.Abs(localVelocityX) > 2.5f)
		{
			isDrifting = true;
			DriftCarPS();
		}
		else
		{
			isDrifting = false;
			DriftCarPS();
		}
		throttleAxis += Time.deltaTime * 3f;
		if (throttleAxis > 1f)
		{
			throttleAxis = 1f;
		}
		if (localVelocityZ < -1f)
		{
			Brakes();
		}
		else if (Mathf.RoundToInt(carSpeed) < maxSpeed)
		{
			frontLeftCollider.brakeTorque = 0f;
			frontLeftCollider.motorTorque = (float)accelerationMultiplier * 50f * throttleAxis;
			frontRightCollider.brakeTorque = 0f;
			frontRightCollider.motorTorque = (float)accelerationMultiplier * 50f * throttleAxis;
			rearLeftCollider.brakeTorque = 0f;
			rearLeftCollider.motorTorque = (float)accelerationMultiplier * 50f * throttleAxis;
			rearRightCollider.brakeTorque = 0f;
			rearRightCollider.motorTorque = (float)accelerationMultiplier * 50f * throttleAxis;
		}
		else
		{
			frontLeftCollider.motorTorque = 0f;
			frontRightCollider.motorTorque = 0f;
			rearLeftCollider.motorTorque = 0f;
			rearRightCollider.motorTorque = 0f;
		}
	}

	public void GoReverse()
	{
		if (Mathf.Abs(localVelocityX) > 2.5f)
		{
			isDrifting = true;
			DriftCarPS();
		}
		else
		{
			isDrifting = false;
			DriftCarPS();
		}
		throttleAxis -= Time.deltaTime * 3f;
		if (throttleAxis < -1f)
		{
			throttleAxis = -1f;
		}
		if (localVelocityZ > 1f)
		{
			Brakes();
		}
		else if (Mathf.Abs(Mathf.RoundToInt(carSpeed)) < maxReverseSpeed)
		{
			frontLeftCollider.brakeTorque = 0f;
			frontLeftCollider.motorTorque = (float)accelerationMultiplier * 50f * throttleAxis;
			frontRightCollider.brakeTorque = 0f;
			frontRightCollider.motorTorque = (float)accelerationMultiplier * 50f * throttleAxis;
			rearLeftCollider.brakeTorque = 0f;
			rearLeftCollider.motorTorque = (float)accelerationMultiplier * 50f * throttleAxis;
			rearRightCollider.brakeTorque = 0f;
			rearRightCollider.motorTorque = (float)accelerationMultiplier * 50f * throttleAxis;
		}
		else
		{
			frontLeftCollider.motorTorque = 0f;
			frontRightCollider.motorTorque = 0f;
			rearLeftCollider.motorTorque = 0f;
			rearRightCollider.motorTorque = 0f;
		}
	}

	public void ThrottleOff()
	{
		frontLeftCollider.motorTorque = 0f;
		frontRightCollider.motorTorque = 0f;
		rearLeftCollider.motorTorque = 0f;
		rearRightCollider.motorTorque = 0f;
	}

	public void DecelerateCar()
	{
		if (Mathf.Abs(localVelocityX) > 2.5f)
		{
			isDrifting = true;
			DriftCarPS();
		}
		else
		{
			isDrifting = false;
			DriftCarPS();
		}
		if (throttleAxis != 0f)
		{
			if (throttleAxis > 0f)
			{
				throttleAxis -= Time.deltaTime * 10f;
			}
			else if (throttleAxis < 0f)
			{
				throttleAxis += Time.deltaTime * 10f;
			}
			if (Mathf.Abs(throttleAxis) < 0.15f)
			{
				throttleAxis = 0f;
			}
		}
		carRigidbody.linearVelocity *= 1f / (1f + 0.025f * (float)decelerationMultiplier);
		frontLeftCollider.motorTorque = 0f;
		frontRightCollider.motorTorque = 0f;
		rearLeftCollider.motorTorque = 0f;
		rearRightCollider.motorTorque = 0f;
		if (carRigidbody.linearVelocity.magnitude < 0.25f)
		{
			carRigidbody.linearVelocity = Vector3.zero;
			CancelInvoke("DecelerateCar");
		}
	}

	public void Brakes()
	{
		frontLeftCollider.brakeTorque = brakeForce;
		frontRightCollider.brakeTorque = brakeForce;
		rearLeftCollider.brakeTorque = brakeForce;
		rearRightCollider.brakeTorque = brakeForce;
	}

	public void Handbrake()
	{
		CancelInvoke("RecoverTraction");
		driftingAxis += Time.deltaTime;
		if (driftingAxis * FLWextremumSlip * (float)handbrakeDriftMultiplier < FLWextremumSlip)
		{
			driftingAxis = FLWextremumSlip / (FLWextremumSlip * (float)handbrakeDriftMultiplier);
		}
		if (driftingAxis > 1f)
		{
			driftingAxis = 1f;
		}
		if (Mathf.Abs(localVelocityX) > 2.5f)
		{
			isDrifting = true;
		}
		else
		{
			isDrifting = false;
		}
		if (driftingAxis < 1f)
		{
			FLwheelFriction.extremumSlip = FLWextremumSlip * (float)handbrakeDriftMultiplier * driftingAxis;
			frontLeftCollider.sidewaysFriction = FLwheelFriction;
			FRwheelFriction.extremumSlip = FRWextremumSlip * (float)handbrakeDriftMultiplier * driftingAxis;
			frontRightCollider.sidewaysFriction = FRwheelFriction;
			RLwheelFriction.extremumSlip = RLWextremumSlip * (float)handbrakeDriftMultiplier * driftingAxis;
			rearLeftCollider.sidewaysFriction = RLwheelFriction;
			RRwheelFriction.extremumSlip = RRWextremumSlip * (float)handbrakeDriftMultiplier * driftingAxis;
			rearRightCollider.sidewaysFriction = RRwheelFriction;
		}
		isTractionLocked = true;
		DriftCarPS();
	}

	public void DriftCarPS()
	{
		if (useEffects)
		{
			try
			{
				if (isDrifting)
				{
					RLWParticleSystem.Play();
					RRWParticleSystem.Play();
				}
				else if (!isDrifting)
				{
					RLWParticleSystem.Stop();
					RRWParticleSystem.Stop();
				}
			}
			catch (Exception message)
			{
				Debug.LogWarning(message);
			}
			try
			{
				if ((isTractionLocked || Mathf.Abs(localVelocityX) > 5f) && Mathf.Abs(carSpeed) > 12f)
				{
					RLWTireSkid.emitting = true;
					RRWTireSkid.emitting = true;
				}
				else
				{
					RLWTireSkid.emitting = false;
					RRWTireSkid.emitting = false;
				}
				return;
			}
			catch (Exception message2)
			{
				Debug.LogWarning(message2);
				return;
			}
		}
		if (!useEffects)
		{
			if (RLWParticleSystem != null)
			{
				RLWParticleSystem.Stop();
			}
			if (RRWParticleSystem != null)
			{
				RRWParticleSystem.Stop();
			}
			if (RLWTireSkid != null)
			{
				RLWTireSkid.emitting = false;
			}
			if (RRWTireSkid != null)
			{
				RRWTireSkid.emitting = false;
			}
		}
	}

	public void RecoverTraction()
	{
		isTractionLocked = false;
		driftingAxis -= Time.deltaTime / 1.5f;
		if (driftingAxis < 0f)
		{
			driftingAxis = 0f;
		}
		if (FLwheelFriction.extremumSlip > FLWextremumSlip)
		{
			FLwheelFriction.extremumSlip = FLWextremumSlip * (float)handbrakeDriftMultiplier * driftingAxis;
			frontLeftCollider.sidewaysFriction = FLwheelFriction;
			FRwheelFriction.extremumSlip = FRWextremumSlip * (float)handbrakeDriftMultiplier * driftingAxis;
			frontRightCollider.sidewaysFriction = FRwheelFriction;
			RLwheelFriction.extremumSlip = RLWextremumSlip * (float)handbrakeDriftMultiplier * driftingAxis;
			rearLeftCollider.sidewaysFriction = RLwheelFriction;
			RRwheelFriction.extremumSlip = RRWextremumSlip * (float)handbrakeDriftMultiplier * driftingAxis;
			rearRightCollider.sidewaysFriction = RRwheelFriction;
			Invoke("RecoverTraction", Time.deltaTime);
		}
		else if (FLwheelFriction.extremumSlip < FLWextremumSlip)
		{
			FLwheelFriction.extremumSlip = FLWextremumSlip;
			frontLeftCollider.sidewaysFriction = FLwheelFriction;
			FRwheelFriction.extremumSlip = FRWextremumSlip;
			frontRightCollider.sidewaysFriction = FRwheelFriction;
			RLwheelFriction.extremumSlip = RLWextremumSlip;
			rearLeftCollider.sidewaysFriction = RLwheelFriction;
			RRwheelFriction.extremumSlip = RRWextremumSlip;
			rearRightCollider.sidewaysFriction = RRwheelFriction;
			driftingAxis = 0f;
		}
	}
}
