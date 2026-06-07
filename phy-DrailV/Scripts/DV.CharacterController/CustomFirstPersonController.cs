using System;
using DV;
using DV.Utils;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CustomFirstPersonController : MonoBehaviour
{
	public delegate void ClimbingLaddersChangedDelegate(bool isClimbing, Transform ladders);

	public const string LADDERS_TAG = "Ladders";

	public const float PLAYER_HEIGHT = 1.62f;

	public const float PLAYER_CROUCH_HEIGHT = 0.72f;

	public const float MIN_PLAYER_SITTING_HEIGHT = 0.8f;

	public const float MAX_PLAYER_SITTING_HEIGHT = 1.5f;

	public const float PLAYER_SITTING_HEIGHT = 1.3f;

	public const float SIT_CANCEL_RANGE_SQR = 9f;

	private const float UNDERWATER_DEADZONE = 0.4f;

	private const float UNDERWATER_ENTER_VELOCITY_LOSS_MULT = 0.6f;

	private const float SWIM_SPEED_COMPARED_TO_RUN = 0.8f;

	private const float HEAD_THICKNESS = 0.1f;

	private const float JUMP_LEDGE_TOLERANCE_MULTIPLIER = 3f;

	private const float NOT_STANDING_SPEED_MULTIPLIER = 0.5f;

	private const float KNOCKED_OVER_THRESHOLD = 0.995f;

	private const float STRAIGHTEN_ROTATION_LERP = 0.1f;

	private const float CAPSULE_GOING_UP_SPEED = 10f;

	private const float LADDER_CLIMB_DIRECTION_LOOK_DOWN_ANGLE_THRESHOLD = 150f;

	private const float LADDER_CLIMB_SLOWDOWN_ANGLE_TAPER = 15f;

	private const float LADDER_STRAFE_SPEED_MULTIPLIER = 0.3f;

	private const float LADDER_VERTICALITY_THRESHOLD = 0.9848077f;

	private const float LADDER_ATTACH_ANGLE_THRESHOLD = 0.9f;

	private const float LADDER_END_EFFECT_TAPER = 0.1f;

	private const float LADDER_FOOTSTEP_DISTANCE = 0.48f;

	private const int REQUIRED_GROUNDED_FRAMES_TO_ENABLE_FOOTSTEPS = 10;

	private const int REQUIRED_GROUNDED_FRAMES_TO_ENABLE_FOOTSTEPS_SHORT = 3;

	public ACharacterControllerProvider provider;

	[Header("Movement variables")]
	[SerializeField]
	[Range(0f, 90f)]
	private float realMaxSlopeAngle = 60f;

	public float baseWalkSpeed = 4f;

	public float baseRunSpeed = 8f;

	public float ladderClimbingSpeedMultiplier = 0.5f;

	public Vector2 ladderJumpForce;

	[SerializeField]
	private float m_JumpSpeed = 6f;

	[SerializeField]
	private float m_UpwardsGravityMultiplier = 2f;

	[SerializeField]
	private float m_DownwardsGravityMultiplier = 3f;

	[SerializeField]
	private float m_StickToGroundForce = 5f;

	[SerializeField]
	private float stepOffset = 0.4f;

	[SerializeField]
	private LocomotionInputWrapper playerInput;

	private bool toggleAlwaysRun;

	public float movementSpeedMultipiler = 1f;

	public float runSpeedMultipiler = 1f;

	[Header("Other variables")]
	public CustomMouseLook m_MouseLook;

	[SerializeField]
	private LayerMask traversableLayers;

	[NonSerialized]
	public bool m_IsWalking;

	private bool straighteningInProgress;

	[SerializeField]
	private FootstepsAudioPlayer footstepsAudio;

	public Camera m_Camera;

	[NonSerialized]
	public Vector2 m_Input;

	private Vector3 m_MoveDir = Vector3.zero;

	private Vector3 desiredMove = Vector3.zero;

	[NonSerialized]
	public CharacterController capsule;

	[NonSerialized]
	public bool previouslyGrounded;

	[NonSerialized]
	public bool m_Jumping;

	public Transform directionDevice;

	public PhysicMaterial noFriction;

	private int ignoreFootstepsUntilGroundedCounter = 10;

	public Vector3 prevFrameLandingVelocity;

	private bool canClimbLadder;

	private bool isClimbingLadders;

	private Transform ladders;

	private BoxCollider ladderCollider;

	private float ladderClimbedDistance;

	public bool isRepositioning;

	public Transform previousGround;

	public Vector3 previousLocalPosition;

	private Vector3 underwaterVelocity;

	[NonSerialized]
	public bool underwater;

	private bool previouslyUnderwater;

	private RaycastHit[] hits = new RaycastHit[4];

	private bool crouchJumped;

	private bool isSeatedVR;

	private Transform jumpedFromLadders;

	private bool justTeleported;

	private Collider[] cols = new Collider[2];

	public float ladderStepOffset = 0.005f;

	public Vector3 DesiredMove => desiredMove;

	private bool IgnoreFootsteps => ignoreFootstepsUntilGroundedCounter > 0;

	public bool IsClimbingLadders
	{
		get
		{
			return isClimbingLadders;
		}
		set
		{
			if (isClimbingLadders != value)
			{
				isClimbingLadders = value;
				if (!isClimbingLadders)
				{
					canClimbLadder = false;
					Ladders = null;
					ladderCollider = null;
					capsule.stepOffset = stepOffset;
				}
				else
				{
					PlayLadderSound();
				}
				this.ClimbingLaddersChanged?.Invoke(isClimbingLadders, Ladders);
			}
		}
	}

	private Transform Ladders
	{
		get
		{
			return ladders;
		}
		set
		{
			if (!(Ladders == value))
			{
				ladders = value;
				ladderCollider = ((ladders != null) ? ladders.GetComponent<BoxCollider>() : null);
			}
		}
	}

	public float CapsuleHeight { get; private set; }

	public float CapsuleHeightNoVRCrouch { get; private set; }

	public bool FreeLookAllowed { get; set; } = true;

	public LocomotionInputWrapper Locomotion => playerInput;

	public bool IsCrouching => playerInput.CrouchRequested;

	private bool CanMove
	{
		get
		{
			if (!isRepositioning)
			{
				return provider.IsGameLoaded;
			}
			return false;
		}
	}

	private bool IsVR => provider.IsVR;

	public event ClimbingLaddersChangedDelegate ClimbingLaddersChanged;

	private void Awake()
	{
		directionDevice = base.transform;
		OnToggleAlwaysRun();
		provider.AlwaysRunToggleChange_Register(OnToggleAlwaysRun);
		if (IsVR)
		{
			provider.SeatedPlayAreaTypeChange_Register(OnSeatedPlayAreaTypeChange);
			OnSeatedPlayAreaTypeChange();
		}
		if (!IsVR)
		{
			m_Camera = GetComponentInChildren<Camera>(includeInactive: true);
		}
		else
		{
			provider.VRTKToggle_Register(this);
		}
		capsule = GetComponent<CharacterController>();
		GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Extrapolate;
	}

	private void OnSeatedPlayAreaTypeChange()
	{
		isSeatedVR = provider.IsVRSeatedMode;
		IgnoreFootstepsSoundUntilGrounded();
	}

	private void OnToggleAlwaysRun()
	{
		toggleAlwaysRun = provider.IsAlwaysRunEnabled;
	}

	private void OnEnable()
	{
		if (IsVR)
		{
			m_Camera = provider.GetVRCamera();
		}
	}

	private void OnDestroy()
	{
		provider.AlwaysRunToggleChange_Unregister(OnToggleAlwaysRun);
		if (IsVR)
		{
			provider.SeatedPlayAreaTypeChange_Unregister(OnSeatedPlayAreaTypeChange);
		}
		provider.VRTKToggle_Unregister(this);
		if (IsVR)
		{
			provider.TeleportStarted_Unregister(OnTeleportStarted);
		}
	}

	private void Start()
	{
		capsule.detectCollisions = false;
		capsule.slopeLimit = realMaxSlopeAngle;
		m_Jumping = false;
		SetCapsuleHeight(1.62f);
		capsule.minMoveDistance = 1E-07f;
		capsule.stepOffset = stepOffset;
		capsule.material = noFriction;
		m_MouseLook.Init(base.transform, m_Camera.transform, provider);
		if (IsVR)
		{
			provider.TeleportStarted_Register(OnTeleportStarted);
		}
	}

	private void OnTeleportStarted()
	{
		justTeleported = true;
	}

	private void Update()
	{
		if (Time.timeScale <= 0f || Time.deltaTime <= 0f)
		{
			return;
		}
		if (previouslyGrounded && ignoreFootstepsUntilGroundedCounter > 0)
		{
			ignoreFootstepsUntilGroundedCounter--;
		}
		ValidateCharacterControllerValues();
		if (!previouslyGrounded && capsule.isGrounded)
		{
			RequestFootstepSound(FootstepsAudioScriptableObject.MovementType.Landing);
			m_MoveDir.y = 0f;
			m_Jumping = false;
			jumpedFromLadders = null;
		}
		prevFrameLandingVelocity = capsule.velocity;
		if (!capsule.isGrounded && !m_Jumping && previouslyGrounded)
		{
			m_MoveDir.y = 0f;
		}
		previouslyGrounded = capsule.isGrounded;
		if (FreeLookAllowed)
		{
			RotateView();
		}
		provider.CheckSitting();
		float num = (IsCrouching ? 0.72f : (provider.IsSitting ? provider.PlayerSittingHeight : 1.62f));
		if (capsule.isGrounded)
		{
			CapsuleHeightNoVRCrouch = num;
		}
		if (num > CapsuleHeight)
		{
			float num2 = num - CapsuleHeight;
			num2 = Mathf.Clamp(num2 * 10f * Time.deltaTime, 0f, num2);
			num = CapsuleHeight + num2;
		}
		if (!capsule.isGrounded && !IsClimbingLadders)
		{
			float radius = capsule.radius;
			if (Physics.OverlapSphereNonAlloc(base.transform.position, radius, cols, traversableLayers, QueryTriggerInteraction.Ignore) == 0)
			{
				CapsuleHeightNoVRCrouch = num;
			}
		}
		if (IsCrouching && !crouchJumped && !capsule.isGrounded && !IsClimbingLadders)
		{
			crouchJumped = true;
			capsule.Move(Vector3.up * (capsule.height - num));
		}
		else if (!IsCrouching && crouchJumped)
		{
			crouchJumped = false;
		}
		float num3 = 0f;
		if (IsVR)
		{
			num3 = (isSeatedVR ? provider.VRSeatedHeight : provider.VRRoomscaleHeight);
			float num4 = m_Camera.transform.localPosition.y + num3;
			if (isSeatedVR)
			{
				num4 += 1.62f;
			}
			num = Mathf.Min(num, Mathf.Max(num4, 0.72f));
		}
		if (CapsuleHeight != num)
		{
			if (SphereCastCeiling(base.transform.position, capsule.radius / 2f, Vector3.up, out var hit, 1.62f, traversableLayers, QueryTriggerInteraction.Ignore))
			{
				float a = hit.point.y - base.transform.position.y - capsule.radius - 0.1f;
				a = Mathf.Max(a, 0.72f);
				num = Mathf.Min(num, a);
				if (IsVR)
				{
					float num5 = 1.62f - a;
					float num6 = capsule.radius + 0.1f - num3 - m_Camera.transform.localPosition.y;
					if (!isSeatedVR)
					{
						num6 += 1.62f;
					}
					float b = num5 - num6;
					b = Mathf.Max(0f, b);
					CapsuleHeightNoVRCrouch -= b;
				}
			}
			SetCapsuleHeight(num);
		}
		if (!justTeleported)
		{
			CharacterMovement();
		}
		else
		{
			justTeleported = false;
		}
	}

	private bool SphereCastCeiling(Vector3 origin, float radius, Vector3 direction, out RaycastHit hit, float maxDistance, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction)
	{
		int num = Physics.SphereCastNonAlloc(origin, radius, direction, hits, maxDistance, layerMask, queryTriggerInteraction);
		RaycastUtils.SortDistanceAndExpandCache(ref hits, num);
		for (int i = 0; i < num; i++)
		{
			hit = hits[i];
			if (hit.distance != 0f && !hit.collider.TryGetComponent<IgnoreCharacterHeadCollisionTag>(out var _))
			{
				return true;
			}
		}
		hit = default(RaycastHit);
		return false;
	}

	public void IgnoreFootstepsSoundUntilGrounded(bool isShortIgnore = false)
	{
		ignoreFootstepsUntilGroundedCounter = (isShortIgnore ? 3 : 10);
	}

	public void RequestFootstepSound()
	{
		FootstepsAudioScriptableObject.MovementType moveType = FootstepsAudioScriptableObject.MovementType.Walking;
		if (IsCrouching)
		{
			moveType = FootstepsAudioScriptableObject.MovementType.Crouching;
		}
		else if (m_IsWalking)
		{
			moveType = FootstepsAudioScriptableObject.MovementType.Walking;
		}
		else if (!m_IsWalking)
		{
			moveType = FootstepsAudioScriptableObject.MovementType.Running;
		}
		RequestFootstepSound(moveType);
	}

	public void RequestFootstepSound(FootstepsAudioScriptableObject.MovementType moveType)
	{
		if (!IgnoreFootsteps)
		{
			footstepsAudio.RequestPlayFootstepSound(moveType, base.transform.position, prevFrameLandingVelocity.magnitude, capsule.radius - 0.015f, base.transform);
		}
	}

	private void ValidateCharacterControllerValues()
	{
		float num = capsule.height + 2f * capsule.skinWidth;
		if (num > 1.63f)
		{
			Debug.LogWarning($"Character Controller total height ({num}) is greater than uncrouched height ({1.62f})", this);
		}
		else if (num < 0.71000004f)
		{
			Debug.LogWarning($"Character Controller total height ({num}) is less than default crouch height ({0.72f})", this);
		}
		Vector3 vector = new Vector3(0f, capsule.height * 0.5f + capsule.skinWidth, 0f);
		if (capsule.center != vector)
		{
			Debug.LogWarning($"Character Controller center is offset by {vector - capsule.center}", this);
		}
		if (Mathf.Abs(capsule.slopeLimit - realMaxSlopeAngle) > 0.1f)
		{
			Debug.LogWarning("Slope Limit value different than realMaxSlopeAngle. Resetting value.", this);
			capsule.slopeLimit = realMaxSlopeAngle;
		}
	}

	private float ProcessInputAndGetSpeed()
	{
		if (!toggleAlwaysRun)
		{
			m_IsWalking = !playerInput.RunRequested;
		}
		else
		{
			m_IsWalking = playerInput.RunRequested;
		}
		float num = baseWalkSpeed;
		float num2 = baseRunSpeed;
		float num3 = (m_IsWalking ? num : (num2 * runSpeedMultipiler)) * movementSpeedMultipiler;
		if (IsCrouching || provider.IsSitting)
		{
			num3 *= 0.5f;
		}
		m_Input = playerInput.speed;
		if (m_Input.sqrMagnitude > 1f)
		{
			m_Input.Normalize();
		}
		return num3;
	}

	public void ForceLookRotation(Quaternion rotation)
	{
		if (!IsVR)
		{
			m_MouseLook.ForceRotation(base.transform, m_Camera.transform, rotation);
		}
	}

	public void ForceLookRotationNoTilt(Quaternion rotation)
	{
		if (!IsVR)
		{
			m_MouseLook.ForceRotationNoTilt(base.transform, m_Camera.transform, rotation);
		}
	}

	private void RotateView()
	{
		if (!IsVR)
		{
			m_MouseLook.LookRotation(base.transform, m_Camera.transform);
		}
	}

	public void RotateViewBy(Vector2 delta)
	{
		if (!IsVR)
		{
			m_MouseLook.LookRotation(base.transform, m_Camera.transform, delta);
		}
	}

	private void CharacterMovement()
	{
		float num = ProcessInputAndGetSpeed();
		float num2 = Vector3.Dot(base.transform.up, Vector3.up);
		bool flag = num2 < 0.995f;
		float num3 = 0f - (base.transform.position.y + 0.4f - provider.WaterLevel);
		underwater = num3 > 0f;
		if (previouslyUnderwater != underwater)
		{
			previouslyUnderwater = underwater;
			if (underwater)
			{
				underwaterVelocity = capsule.velocity;
				underwaterVelocity.y *= 0.6f;
			}
		}
		bool flag2 = playerInput.JumpRequested && !m_Jumping;
		bool flag3 = m_Input.sqrMagnitude > float.Epsilon || flag2 || IsCrouching || provider.IsSitting;
		if (capsule.isGrounded && !flag3 && !straighteningInProgress && !flag && !underwater)
		{
			if (capsule.enabled)
			{
				if (capsule.velocity.sqrMagnitude > float.Epsilon)
				{
					capsule.SimpleMove(Vector3.zero);
				}
				capsule.enabled = false;
			}
			desiredMove = Vector3.zero;
			return;
		}
		if (!isRepositioning && !capsule.enabled)
		{
			capsule.enabled = true;
		}
		if (flag && flag3 && !straighteningInProgress)
		{
			straighteningInProgress = true;
		}
		if (straighteningInProgress)
		{
			Quaternion camForwardRotation = VectorUtils.GetCamForwardRotation(base.transform.forward, base.transform.up);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, camForwardRotation, 0.1f);
			if (num2 > 0.9999f)
			{
				straighteningInProgress = false;
			}
		}
		if (underwater)
		{
			Transform transform = (IsVR ? directionDevice : m_Camera.transform);
			desiredMove = transform.forward * m_Input.y + transform.right * m_Input.x;
			float num4 = baseRunSpeed * runSpeedMultipiler * movementSpeedMultipiler * 0.8f;
			if (desiredMove.y > 0f)
			{
				desiredMove.y *= Mathf.Clamp01(num3 - 0.4f);
			}
			m_MoveDir = desiredMove * num4;
			m_MoveDir.y += Physics.gravity.y * Time.deltaTime * m_DownwardsGravityMultiplier * NumberUtil.MapClamp(num3, 0f, 1.2f, 1f, 0f);
			m_MoveDir.y = Mathf.Clamp(m_MoveDir.y + (playerInput.SwimRequested ? NumberUtil.MapClamp(num3, 0f, 0.5f, 0f, num4) : (IsCrouching ? (0f - num4) : 0f)), 0f - num4, num4);
			if (underwaterVelocity.y < capsule.velocity.y && capsule.velocity.y < 0f)
			{
				underwaterVelocity.y = capsule.velocity.y;
			}
			m_MoveDir = Vector3.Lerp(underwaterVelocity, m_MoveDir, 2f * Time.deltaTime);
			underwaterVelocity = m_MoveDir;
		}
		else
		{
			Vector3 vector;
			Vector3 vector2;
			if (directionDevice.forward.y != 0f)
			{
				vector = new Vector3(directionDevice.forward.x, 0f, directionDevice.forward.z).normalized;
				vector2 = new Vector3(directionDevice.right.x, 0f, directionDevice.right.z).normalized;
			}
			else
			{
				vector = directionDevice.forward;
				vector2 = directionDevice.right;
			}
			desiredMove = vector * m_Input.y + vector2 * m_Input.x;
			Physics.SphereCast(base.transform.position + Vector3.up * capsule.radius, capsule.radius, Vector3.down, out var hitInfo, capsule.radius + capsule.skinWidth, traversableLayers, QueryTriggerInteraction.Ignore);
			float num5 = 0f;
			if (capsule.velocity.y > 0f)
			{
				num5 = Vector3.Angle(Vector3.up, hitInfo.normal);
			}
			if (num5 > 0f && num5 < 90f)
			{
				Vector3 currentVelocity = desiredMove.normalized;
				desiredMove = Vector3.SmoothDamp(desiredMove, desiredMove * Mathf.Cos(90f / realMaxSlopeAngle * num5 * ((float)Math.PI / 180f)), ref currentVelocity, 0.01f);
			}
			desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);
			m_MoveDir.x = desiredMove.x * num;
			m_MoveDir.z = desiredMove.z * num;
			if (capsule.isGrounded && previouslyGrounded)
			{
				if (Physics.Raycast(base.transform.position, Vector3.down, capsule.height / 2f + capsule.skinWidth + capsule.stepOffset, traversableLayers, QueryTriggerInteraction.Ignore))
				{
					m_MoveDir.y = 0f - m_StickToGroundForce;
				}
				else
				{
					m_MoveDir.y = Physics.gravity.y * Time.deltaTime * m_DownwardsGravityMultiplier;
				}
			}
			else if (capsule.velocity.y > 0f)
			{
				m_MoveDir += Physics.gravity * m_UpwardsGravityMultiplier * Time.deltaTime;
			}
			else
			{
				m_MoveDir += Physics.gravity * m_DownwardsGravityMultiplier * Time.deltaTime;
			}
			if (IsClimbingLadders)
			{
				m_MoveDir.y = 0f;
			}
			TryClimbLadders();
			if (flag2)
			{
				JumpMechanic();
			}
			if (!IsClimbingLadders && (bool)base.transform.parent && (capsule.collisionFlags & CollisionFlags.Below) != CollisionFlags.None)
			{
				float num6 = base.transform.position.y - hitInfo.point.y;
				if (num6 < 0f)
				{
					base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + num6, base.transform.position.z);
				}
			}
			if ((bool)hitInfo.transform)
			{
				previousGround = hitInfo.transform;
				previousLocalPosition = hitInfo.transform.InverseTransformPoint(base.transform.position);
			}
		}
		if (CanMove)
		{
			capsule.Move(m_MoveDir * Time.deltaTime);
		}
		base.transform.localScale = Vector3.one;
		if (provider.IsInCar && underwater)
		{
			(Transform carTransform, Bounds carBounds) carTransformAndBounds = provider.GetCarTransformAndBounds();
			Transform item = carTransformAndBounds.carTransform;
			Bounds item2 = carTransformAndBounds.carBounds;
			Vector3 vector3 = Vector3.one * (capsule.radius * 1.99f) + Vector3.up;
			item2.size += vector3;
			if (!item2.Contains(item.InverseTransformPoint(base.transform.position)))
			{
				GetComponent<CharacterReparenting>().ReparentTo(null);
			}
		}
	}

	public void MoveBy(Vector3 direction)
	{
		capsule.enabled = true;
		capsule.Move(direction);
		isRepositioning = false;
	}

	public void SetCapsuleHeight(float height)
	{
		CapsuleHeight = height;
		capsule.height = height - capsule.skinWidth * 2f;
		capsule.center = new Vector3(0f, height * 0.5f, 0f);
	}

	private void JumpMechanic()
	{
		if (!IsClimbingLadders)
		{
			if (m_Jumping)
			{
				return;
			}
			if (capsule.isGrounded)
			{
				SetJumpParameters();
				return;
			}
			float radius = capsule.radius * 3f;
			if (Physics.OverlapSphereNonAlloc(base.transform.position, radius, cols, traversableLayers, QueryTriggerInteraction.Ignore) > 0)
			{
				SetJumpParameters();
			}
		}
		else
		{
			jumpedFromLadders = Ladders;
			DropFromLadders();
			SetJumpParameters();
		}
	}

	private void SetJumpParameters()
	{
		m_MoveDir.y = m_JumpSpeed;
		m_Jumping = true;
		provider.IsSitting = false;
	}

	private void TryClimbLadders()
	{
		if (IsClimbingLadders && (bool)Ladders)
		{
			ClimbLadders();
		}
	}

	private void ClimbLadders()
	{
		if (!(m_MoveDir.sqrMagnitude > 0f))
		{
			return;
		}
		Vector3 forward = playerInput.LocomotionInputInterpreter.LadderClimbDirectionTransform.transform.forward;
		Vector3 forward2 = Ladders.forward;
		Vector3 up = Ladders.up;
		bool flag = Vector3.Dot(forward2, forward) > 0f;
		bool flag2 = Vector3.Dot(forward2, m_MoveDir) > 0f;
		bool flag3 = up.y < 0f;
		int num = ((!flag3) ? 1 : (-1));
		float num2 = Vector3.Angle(forward, Vector3.up);
		float num3 = (float)((!(num2 > 150f)) ? 1 : (-1)) * m_Input.y * (float)num;
		float num4 = Mathf.Clamp01(Mathf.Abs(num2 - 150f) / 15f);
		float distanceToLadderEnd = GetDistanceToLadderEnd(1f);
		float distanceToLadderEnd2 = GetDistanceToLadderEnd(-1f);
		float value = (flag3 ? distanceToLadderEnd2 : distanceToLadderEnd);
		float value2 = Mathf.Min(distanceToLadderEnd, distanceToLadderEnd2);
		float num5 = 0f;
		float num6 = ((num3 > 0f) ? distanceToLadderEnd : distanceToLadderEnd2);
		float t = NumberUtil.MapClamp(value2, 0.1f, 0f, 1f, 0f);
		float num7 = NumberUtil.MapClamp(value, 0.1f, 0f, 1f, 0f);
		capsule.stepOffset = Mathf.Lerp(stepOffset, ladderStepOffset, num7);
		bool groundedSafer = GetGroundedSafer();
		if (!(capsule.isGrounded && flag) || !(Vector3.Dot(m_MoveDir, forward2) < 0f))
		{
			num5 = num3;
			num5 *= Time.deltaTime;
			num5 *= (playerInput.RunRequested ? (baseRunSpeed * runSpeedMultipiler * 0.7f) : (baseWalkSpeed * movementSpeedMultipiler));
			num5 *= num4;
			num5 *= ladderClimbingSpeedMultiplier;
			if (!flag3 && num5 > 0f)
			{
				num5 = Mathf.Min(num5, num6);
			}
			else if (flag3 && num5 < 0f)
			{
				num5 = Mathf.Max(num5, 0f - num6);
			}
			if (!groundedSafer)
			{
				if (num6 > 0f)
				{
					float num8 = Mathf.Lerp(1f, 0.3f, t);
					m_MoveDir.x *= num8;
					m_MoveDir.z *= num8;
					if (!flag2)
					{
						Vector3 vector = Vector3.ProjectOnPlane(m_MoveDir, ladders.right);
						vector.y = 0f;
						vector *= num7;
						m_MoveDir -= vector;
					}
				}
			}
			else if (!flag2)
			{
				num5 = 0f;
			}
		}
		Vector3 position = base.transform.position;
		Vector3 motion = up * num5;
		capsule.Move(motion);
		Vector3 vector2 = base.transform.position - position;
		if (vector2.y == 0f && groundedSafer && motion.y < -0.001f && GetDistanceToLadderEnd(flag3 ? (-1f) : 1f).IsInRange(0.003f, capsule.radius + capsule.skinWidth))
		{
			capsule.Move(-forward2 * (0.2f * Time.deltaTime));
			capsule.Move(motion);
		}
		float num9 = ladderClimbedDistance + vector2.y;
		if (Mathf.RoundToInt(num9 / 0.48f) != Mathf.RoundToInt(ladderClimbedDistance / 0.48f))
		{
			PlayLadderSound();
		}
		ladderClimbedDistance = num9;
	}

	private void PlayLadderSound()
	{
		footstepsAudio.PlayFootstepSound(FootstepsAudioScriptableObject.SurfaceType.Ladder, base.transform.position, 0.8f, base.transform);
	}

	private bool GetGroundedSafer()
	{
		float num = 0.01f;
		float radius = capsule.radius;
		if (!capsule.isGrounded)
		{
			return PhysicsQueryBuilder.OverlapSphere(base.transform.position + Vector3.up * (radius - num * 2f), radius - num, traversableLayers).Length > 0;
		}
		return true;
	}

	private float GetDistanceToLadderEnd(float localMove)
	{
		float y = ladderCollider.size.y;
		float y2 = ladderCollider.center.y;
		float num = Mathf.Sign(localMove);
		float y3 = y * 0.5f * num + y2;
		Vector3 inPoint = ladderCollider.transform.TransformPoint(new Vector3(0f, y3, 0f));
		return 0f - new Plane(ladderCollider.transform.up * localMove, inPoint).GetDistanceToPoint(base.transform.position);
	}

	private void DropFromLadders()
	{
		IsClimbingLadders = false;
	}

	private void OnTriggerStay(Collider other)
	{
		if (!other.transform.CompareTag("Ladders") || (!playerInput.ClimbLadderRequested && !IsClimbingLadders && !m_Jumping))
		{
			return;
		}
		Transform transform = other.transform;
		bool flag = m_MoveDir.y > 0.5f;
		if (jumpedFromLadders != null && transform == jumpedFromLadders && flag)
		{
			return;
		}
		if (base.transform.position.y < transform.position.y)
		{
			Vector3 moveDir = m_MoveDir;
			moveDir.y = 0f;
			if (Vector3.Dot(moveDir.normalized, transform.forward) < 0.9f)
			{
				return;
			}
		}
		Ladders = transform;
		bool num = IsClimbingLadders;
		canClimbLadder = Ladders != null && Mathf.Abs(Vector3.Dot(Ladders.up, Vector3.up)) >= 0.9848077f;
		IsClimbingLadders = canClimbLadder;
		if (!num)
		{
			m_Jumping = false;
			jumpedFromLadders = null;
		}
		else if (!canClimbLadder)
		{
			DropFromLadders();
		}
	}

	public LayerMask GetTraversableLayers()
	{
		return traversableLayers;
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Ladders") && ((bool)Ladders || IsClimbingLadders))
		{
			DropFromLadders();
		}
	}

	public void UpdateLocomotionValues(float walkMult, float runMult)
	{
		if (IsVR)
		{
			movementSpeedMultipiler = walkMult;
			runSpeedMultipiler = runMult;
		}
		else
		{
			movementSpeedMultipiler = 1f;
			runSpeedMultipiler = 1f;
		}
	}
}
