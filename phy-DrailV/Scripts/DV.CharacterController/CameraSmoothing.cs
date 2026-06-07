using DV.Utils;
using UnityEngine;

[ExecuteAfter(typeof(CustomFirstPersonController))]
public class CameraSmoothing : MonoBehaviour
{
	private const float THRESHOLD_SPEED = 0.01f;

	private const float FIRST_STEP_DISTANCE = 0.2f;

	private const float MINIMUM_BOB_VELOCITY_Y = 0.001f;

	private const float BOB_MIN = -0.5f;

	private const float BOB_MAX = 0.1f;

	public Transform head;

	public Transform cameraAnchor;

	public bool canBob = true;

	public bool canSmooth = true;

	[SerializeField]
	private float headSmoothingGrounded = 0.16f;

	[SerializeField]
	private float headSmoothingAirborne = 0.02f;

	[SerializeField]
	private float bobHeight = -0.1f;

	[SerializeField]
	private float bobWalkBaseDistance = 0.6f;

	[SerializeField]
	private float bobRunBaseDistance = 0.4f;

	[SerializeField]
	private float bobDuration = 0.1f;

	[SerializeField]
	private float bobRunMultiplier = 2f;

	private bool isVR;

	private float ySmoothVelo;

	private float bobDistance = 1f;

	private float bobTime;

	private CharacterController charController;

	private CustomFirstPersonController fpc;

	private void Awake()
	{
		charController = GetComponent<CharacterController>();
		fpc = GetComponent<CustomFirstPersonController>();
		isVR = fpc.provider.IsVR;
		OnHeadBobPreferenceUpdated();
	}

	private void Start()
	{
		head.parent = base.transform.parent;
		SetupListeners(on: true);
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			fpc.provider.OriginShiftUpdated_Register(OnWorldMoved);
			fpc.provider.HeadBobPreferenceUpdated_Register(OnHeadBobPreferenceUpdated);
		}
		else
		{
			fpc.provider.OriginShiftUpdated_Unregister(OnWorldMoved);
			fpc.provider.HeadBobPreferenceUpdated_Unregister(OnHeadBobPreferenceUpdated);
		}
	}

	private void OnWorldMoved(Vector3 moveVector)
	{
		if (head.parent == null)
		{
			head.position = new Vector3(base.transform.position.x, head.position.y, base.transform.position.z);
		}
	}

	private void OnHeadBobPreferenceUpdated()
	{
		canBob = fpc.provider.UseHeadBob;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(cameraAnchor.position, 0.02f);
	}

	private void Update()
	{
		UpdateCameraSmoothing();
	}

	private void UpdateCameraSmoothing(bool forced = false)
	{
		if (forced || (!(Time.timeScale <= 0f) && !(Time.deltaTime <= 0f)))
		{
			float num = fpc.baseWalkSpeed * fpc.movementSpeedMultipiler;
			float num2 = fpc.baseRunSpeed * fpc.runSpeedMultipiler * fpc.movementSpeedMultipiler;
			float num3 = bobWalkBaseDistance * num;
			float num4 = bobRunBaseDistance * num2;
			float num5 = (isVR ? (bobHeight * fpc.movementSpeedMultipiler * 0.25f) : bobHeight);
			float magnitude = charController.velocity.magnitude;
			float num6 = magnitude * Time.deltaTime;
			if (magnitude < 0.01f || fpc.IsClimbingLadders)
			{
				bobDistance = 0.2f;
			}
			bobDistance -= num6;
			bobTime -= Time.deltaTime;
			if (bobDistance < 0f && charController.isGrounded)
			{
				fpc.RequestFootstepSound();
				bobTime = bobDuration;
				bobDistance = (fpc.m_IsWalking ? num3 : num4);
			}
			float num7 = ((Mathf.Abs(charController.velocity.y) > 0.001f) ? (charController.velocity.y * 0.1f) : 0f);
			if (canBob && bobTime > 0f)
			{
				num7 += (fpc.m_IsWalking ? num5 : (num5 * bobRunMultiplier));
			}
			num7 = Mathf.Clamp(num7, -0.5f, 0.1f);
			Vector3 position = cameraAnchor.position;
			float num8 = position.y + num7;
			position.y = (canSmooth ? SmoothY(head.position.y, num8) : num8);
			head.position = position;
			head.localScale = Vector3.one;
		}
	}

	public void ForceUpdateHeadPosition()
	{
		Vector3 position = cameraAnchor.position;
		head.position = position;
	}

	private float SmoothY(float current, float target)
	{
		if (float.IsNaN(ySmoothVelo))
		{
			Debug.LogWarning("ySmoothVelo was set to NaN, trying to recover by reseting to 0!", this);
			ySmoothVelo = 0f;
		}
		return Mathf.SmoothDamp(current, target, ref ySmoothVelo, fpc.previouslyGrounded ? headSmoothingGrounded : headSmoothingAirborne);
	}

	public void UpdateImmediately()
	{
		UpdateCameraSmoothing(forced: true);
	}
}
