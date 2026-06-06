using UnityEngine;
using UnityEngine.UI;

public class PrometeoCarController : MonoBehaviour
{
	[Space(20f)]
	[Space(10f)]
	[Range(20f, 190f)]
	public int maxSpeed;

	[Range(10f, 120f)]
	public int maxReverseSpeed;

	[Range(1f, 10f)]
	public int accelerationMultiplier;

	[Space(10f)]
	[Range(10f, 45f)]
	public int maxSteeringAngle;

	[Range(0.1f, 1f)]
	public float steeringSpeed;

	[Space(10f)]
	[Range(100f, 600f)]
	public int brakeForce;

	[Range(1f, 10f)]
	public int decelerationMultiplier;

	[Range(1f, 10f)]
	public int handbrakeDriftMultiplier;

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
	}

	private void Update()
	{
	}

	public void CarSpeedUI()
	{
	}

	public void CarSounds()
	{
	}

	public void TurnLeft()
	{
	}

	public void TurnRight()
	{
	}

	public void ResetSteeringAngle()
	{
	}

	private void AnimateWheelMeshes()
	{
	}

	public void GoForward()
	{
	}

	public void GoReverse()
	{
	}

	public void ThrottleOff()
	{
	}

	public void DecelerateCar()
	{
	}

	public void Brakes()
	{
	}

	public void Handbrake()
	{
	}

	public void DriftCarPS()
	{
	}

	public void RecoverTraction()
	{
	}
}
