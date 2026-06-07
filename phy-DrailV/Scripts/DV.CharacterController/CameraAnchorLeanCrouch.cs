using UnityEngine;

public class CameraAnchorLeanCrouch : MonoBehaviour
{
	private const float CROUCH_OFFSET = -0.7f;

	private const float LEAN_CANCEL_RANGE = 3f;

	public Transform cameraAnchor;

	[SerializeField]
	private float maxLeanOffset = 0.4f;

	[SerializeField]
	private float maxLeanAngle = 5f;

	[SerializeField]
	private float leanSmoothingDuration = 0.1f;

	private LocomotionInputWrapper locomotionInput;

	private CustomFirstPersonController customFPC;

	private Vector3 initialLocalPositionXZ;

	private LocomotionInputWrapper.LeanDirection leanDirection;

	private float currentLeanXValue;

	private float currentLeanAngleValue;

	private float xSmoothRefVel;

	private float angleSmoothRefVel;

	private bool isVR;

	private Vector3 leanStartingPosition;

	private Transform lastParent;

	public Vector3 LeanRelativePosition { get; private set; }

	public Quaternion LeanRelativeRotation { get; private set; }

	private ACharacterControllerProvider Provider => customFPC.provider;

	private float HeadOffsetSeated => Provider.VRSeatedHeight;

	private float HeadOffsetRoomscale => Provider.VRRoomscaleHeight - 1.62f;

	private bool IsSeated => Provider.IsVRSeatedMode;

	private void Awake()
	{
		customFPC = GetComponent<CustomFirstPersonController>();
		locomotionInput = GetComponent<LocomotionInputWrapper>();
		isVR = customFPC.provider.IsVR;
	}

	private void Start()
	{
		initialLocalPositionXZ = new Vector3(cameraAnchor.localPosition.x, 0f, cameraAnchor.localPosition.z);
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
			locomotionInput.LeanDirectionChanged += OnLeanValueChanged;
		}
		else
		{
			locomotionInput.LeanDirectionChanged -= OnLeanValueChanged;
		}
	}

	private void OnLeanValueChanged(LocomotionInputWrapper.LeanDirection leanDirection)
	{
		if (this.leanDirection == LocomotionInputWrapper.LeanDirection.NotLeaning && leanDirection != LocomotionInputWrapper.LeanDirection.NotLeaning)
		{
			lastParent = base.transform.parent;
			leanStartingPosition = (base.transform.parent ? base.transform.localPosition : (base.transform.localPosition - Provider.OriginShift));
		}
		this.leanDirection = leanDirection;
	}

	private void Update()
	{
		DoLean();
		UpdateHeight();
	}

	private void DoLean()
	{
		if (isVR || Time.timeScale <= 0f || Time.deltaTime <= 0f)
		{
			return;
		}
		if (leanDirection != LocomotionInputWrapper.LeanDirection.NotLeaning)
		{
			float num = (float)leanDirection * maxLeanOffset;
			float target = (0f - Mathf.Sign(num)) * maxLeanAngle;
			currentLeanXValue = Mathf.SmoothDamp(currentLeanXValue, num, ref xSmoothRefVel, leanSmoothingDuration);
			currentLeanAngleValue = Mathf.SmoothDamp(currentLeanAngleValue, target, ref angleSmoothRefVel, leanSmoothingDuration);
			if (locomotionInput.LocomotionInputInterpreter.IsLeanPressed)
			{
				lastParent = base.transform.parent;
				leanStartingPosition = (base.transform.parent ? base.transform.localPosition : (base.transform.localPosition - Provider.OriginShift));
			}
			else
			{
				Vector3 vector = (base.transform.parent ? base.transform.localPosition : (base.transform.localPosition - Provider.OriginShift));
				if (lastParent != base.transform.parent || (vector - leanStartingPosition).sqrMagnitude > 9f)
				{
					locomotionInput.ResetLean();
				}
			}
		}
		else
		{
			currentLeanXValue = Mathf.SmoothDamp(currentLeanXValue, 0f, ref xSmoothRefVel, leanSmoothingDuration);
			currentLeanAngleValue = Mathf.SmoothDamp(currentLeanAngleValue, 0f, ref angleSmoothRefVel, leanSmoothingDuration);
		}
		LeanRelativePosition = new Vector3(currentLeanXValue, 0f, 0f);
		LeanRelativeRotation = Quaternion.Euler(0f, 0f, currentLeanAngleValue);
		cameraAnchor.localPosition = LeanRelativePosition + new Vector3(0f, cameraAnchor.localPosition.y, initialLocalPositionXZ.z);
		cameraAnchor.localRotation = LeanRelativeRotation;
	}

	public void UpdateHeight()
	{
		Vector3 localPosition = cameraAnchor.localPosition;
		float y = localPosition.y;
		float num2;
		if (isVR)
		{
			float num = (IsSeated ? HeadOffsetSeated : HeadOffsetRoomscale);
			num2 = customFPC.CapsuleHeightNoVRCrouch + num;
		}
		else
		{
			num2 = customFPC.CapsuleHeight;
		}
		localPosition.y = num2;
		cameraAnchor.localPosition = localPosition;
		float num3 = num2 - y;
		if (num3 != 0f)
		{
			customFPC.provider.OnPlayerHeightAdjusted?.Invoke(num2, num3);
		}
	}
}
