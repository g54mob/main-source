using Unity.Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public enum PlayerState
	{
		Upright = 0,
		Ragdoll = 1
	}

	public enum AirState
	{
		Grounded = 0,
		Airborne = 1
	}

	[Header("Active Movement Profile")]
	public PlayerMovementProfile currMovementProfile;

	[Header("Camera")]
	[SerializeField]
	private GameObject playerCam;

	private CinemachineCamera playerCam_CineMachScript;

	private float calculatedFovFromVelocity;

	[SerializeField]
	private float fov_changeSpeed;

	public Vector2 cameraFov_FovRange;

	[SerializeField]
	private Vector2 cameraFov_VeloMagRange;

	public float fov_NormalizedDiff;

	public PlayerState playerState;

	public AirState airState;

	[Header("Movement")]
	[SerializeField]
	private PlayerMoveState playerMoveState;

	public Rigidbody rb;

	private Vector3 moveVec;

	private Vector2 inputVec;

	[SerializeField]
	private float drag_SlopeReduction;

	[SerializeField]
	private float drag_DesiredGround;

	[SerializeField]
	private float drag_GroundIncreasePerSec;

	[SerializeField]
	private float currMaxSpeed_Grounded;

	[SerializeField]
	private float currAccel_Ground;

	[SerializeField]
	private float lateralDampening;

	[Header("Air Movement")]
	private float maxVeloMagThisJump;

	[Header("Braking")]
	[SerializeField]
	private float deceleration_Grounded;

	[SerializeField]
	private float deceleration_Airborne;

	[Header("Floating/Ground Detection")]
	[SerializeField]
	private LayerMask hoverGroundCheckMask;

	[SerializeField]
	private GameObject hoverFeetCheckPOS;

	[SerializeField]
	private float hoverHeight;

	[SerializeField]
	private float hoverForceAmount;

	[SerializeField]
	private float hoverDampening;

	[SerializeField]
	private float groundCheck_2ndPass_Offset;

	[Header("Jumping")]
	private float justJumpedBuffer_Max = 0.1f;

	private float justJumpedBuffer_Curr;

	public bool canJump;

	[Header("Physics")]
	[SerializeField]
	private float torqueToFace_Force;

	[SerializeField]
	private GameObject desiredRotationObject;

	[Header("Slopes")]
	[SerializeField]
	private float maxSlopeAngle;

	[SerializeField]
	private float minSlopeAngle;

	[SerializeField]
	private float slopeSlipAcceleration;

	private Vector3 currentSlopeDirection = Vector3.zero;

	public float currentSlopeAngle;

	private Vector3 currentSlopeNormal = Vector3.zero;

	private Vector3 currentSlopeMoveVector = Vector3.zero;

	[SerializeReference]
	private float slopeStickyness;

	[Header("Additional Velocity")]
	[SerializeField]
	private Vector3 additionalVelo_ThisFrame;

	[Header("Stamina")]
	private float stamina_Curr;

	private float staminaRegen_DelayCurr;

	[Header("Step On Helper")]
	[SerializeField]
	private GameObject stepOnHelperObject;

	[Header("Trampoline Interaction")]
	private bool trampolineJumpNextFixedUpdate;

	[SerializeField]
	private float trampolineBounceForce;

	[Header("Bubble Jetpack")]
	[SerializeField]
	private float jetPack_UpwardPower;

	[SerializeField]
	private float holdToJetPackBuffer;

	private float holdToJetPackBuffer_Curr;

	private bool prevBubbleKeyHoldState;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		playerCam_CineMachScript = playerCam.GetComponent<CinemachineCamera>();
	}

	private void Start()
	{
		DumbAssPhysicsFix();
		InitialSetup();
	}

	private void DumbAssPhysicsFix()
	{
		rb.inertiaTensor = rb.inertiaTensor;
		rb.inertiaTensorRotation = rb.inertiaTensorRotation;
	}

	private void InitialSetup()
	{
		playerState = PlayerState.Upright;
		stamina_Curr = currMovementProfile.staminaMax;
		GameManager.Singleton.playerCamera = playerCam;
		playerCam.gameObject.transform.SetParent(null);
	}

	private void Update()
	{
		SetDesiredRotObjectFromCameraDir();
		moveVec = GetMoveDirectionFromInput();
		HandleJump();
		HandleLerpingGroundDrag();
		HandleStamina();
	}

	private void FixedUpdate()
	{
		HandleTorqueToLookDirection_Cross();
		CalculateSprintOrWalk();
		HandleGroundHover();
		HandleAirStateChanges();
		HandleMovement();
		HandleSlopeForces();
		HandleTrampolineJumps();
		ApplyAdditionalVelocities();
		HandleBubbleJetPack();
	}

	private void CalculateSprintOrWalk()
	{
		if (InputManager.Singleton.inputActions.PlayerActionMap.Sprint.IsPressed() && stamina_Curr > 0f)
		{
			if ((bool)OptionsManager.Singleton && OptionsManager.Singleton.toggle_Sprint_Setting == 1)
			{
				currAccel_Ground = currMovementProfile.accel_Grounded;
				currMaxSpeed_Grounded = currMovementProfile.maxMoveSpeed;
				playerMoveState = PlayerMoveState.Walking;
			}
			else
			{
				currAccel_Ground = currMovementProfile.accel_Grounded_Running;
				currMaxSpeed_Grounded = currMovementProfile.maxMoveSpeed_Running;
				playerMoveState = PlayerMoveState.Sprinting;
			}
		}
		else if (InputManager.Singleton.inputActions.PlayerActionMap.Crouch.IsPressed())
		{
			currAccel_Ground = currMovementProfile.accel_Grounded_Crouching;
			currMaxSpeed_Grounded = currMovementProfile.maxMoveSpeed_Crouching;
			playerMoveState = PlayerMoveState.Crouching;
		}
		else if ((bool)OptionsManager.Singleton && OptionsManager.Singleton.toggle_Sprint_Setting == 1)
		{
			currAccel_Ground = currMovementProfile.accel_Grounded_Running;
			currMaxSpeed_Grounded = currMovementProfile.maxMoveSpeed_Running;
			playerMoveState = PlayerMoveState.Sprinting;
		}
		else
		{
			currAccel_Ground = currMovementProfile.accel_Grounded;
			currMaxSpeed_Grounded = currMovementProfile.maxMoveSpeed;
			playerMoveState = PlayerMoveState.Walking;
		}
	}

	private void SetDesiredRotObjectFromCameraDir()
	{
		if (!(playerCam == null))
		{
			Vector3 forward = playerCam.transform.forward;
			forward.y = 0f;
			forward.Normalize();
			if (forward.sqrMagnitude > 0.001f)
			{
				Quaternion rotation = Quaternion.LookRotation(forward);
				desiredRotationObject.transform.rotation = rotation;
			}
		}
	}

	private Vector3 GetMoveDirectionFromInput(bool _ignoreX = false)
	{
		Vector3 zero = Vector3.zero;
		if (GenericMenuManager.Singleton.menuState == GenericMenuManager.MenuState.open)
		{
			return Vector3.zero;
		}
		if (currMovementProfile.disableMovement)
		{
			return zero;
		}
		inputVec = InputManager.Singleton.inputActions.PlayerActionMap.Movement.ReadValue<Vector2>();
		float num = inputVec.x;
		float y = inputVec.y;
		if (_ignoreX)
		{
			num = 0f;
		}
		return (desiredRotationObject.transform.right * num + desiredRotationObject.transform.forward * y).normalized;
	}

	private void HandleMovement()
	{
		float magnitude = moveVec.magnitude;
		bool flag = false;
		if (magnitude > 0.1f)
		{
			if (airState == AirState.Grounded)
			{
				Vector3 zero = Vector3.zero;
				if (currentSlopeAngle > 2.5f)
				{
					zero = GetForceUpToMax(currentSlopeMoveVector, currAccel_Ground, currMaxSpeed_Grounded);
				}
				else
				{
					Vector2 vector = InputManager.Singleton.inputActions.PlayerActionMap.Movement.ReadValue<Vector2>();
					if (vector.y >= 0.1f && vector.x <= 0.1f && vector.x >= -0.1f)
					{
						flag = true;
					}
					zero = GetForceUpToMax(moveVec, currAccel_Ground, currMaxSpeed_Grounded);
				}
				rb.AddForce(zero, ForceMode.Force);
				if (flag)
				{
					CancelOutExcessiveLateralForce();
				}
			}
			else if (airState == AirState.Airborne)
			{
				Vector3 forceUpToMax = GetForceUpToMax(moveVec, currMovementProfile.accel_Airborne, maxVeloMagThisJump);
				rb.AddForce(forceUpToMax, ForceMode.Force);
			}
			return;
		}
		Vector3 linearVelocity = rb.linearVelocity;
		linearVelocity.y = 0f;
		if (airState == AirState.Grounded)
		{
			if (currentSlopeAngle < minSlopeAngle)
			{
				rb.AddForce(-linearVelocity * deceleration_Grounded, ForceMode.Force);
			}
		}
		else if (airState == AirState.Airborne)
		{
			rb.AddForce(-linearVelocity * deceleration_Airborne, ForceMode.Force);
		}
	}

	private void CancelOutExcessiveLateralForce()
	{
		float magnitude = new Vector2(rb.linearVelocity.x, rb.linearVelocity.z).magnitude;
		if (moveVec.sqrMagnitude > 0.0001f)
		{
			moveVec.Normalize();
		}
		else
		{
			moveVec = Vector3.zero;
		}
		Vector3 b = moveVec * magnitude;
		Vector3 vector = Vector3.Lerp(new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z), b, lateralDampening * Time.fixedDeltaTime);
		rb.linearVelocity = new Vector3(vector.x, rb.linearVelocity.y, vector.z);
	}

	private Vector3 GetForceUpToMax(Vector3 _forceDirection, float _forcePower, float _limit)
	{
		float num = Vector3.Dot(rb.linearVelocity, _forceDirection.normalized);
		float num2 = _limit - num;
		if (num2 > 0f)
		{
			float num3 = Mathf.Min(num2 / Time.fixedDeltaTime, _forcePower);
			return _forceDirection.normalized * num3;
		}
		return Vector3.zero;
	}

	private void HandleFovChangeBasedOnVelocity()
	{
		if (!playerCam_CineMachScript)
		{
			return;
		}
		float magnitude = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z).magnitude;
		float num = 0f;
		if (magnitude > cameraFov_VeloMagRange.x)
		{
			if (magnitude > cameraFov_VeloMagRange.y)
			{
				calculatedFovFromVelocity = cameraFov_FovRange.y;
			}
			else
			{
				calculatedFovFromVelocity = Mathf.Lerp(t: fov_NormalizedDiff = (magnitude - cameraFov_VeloMagRange.x) / (cameraFov_VeloMagRange.y - cameraFov_VeloMagRange.x), a: cameraFov_FovRange.x, b: cameraFov_FovRange.y);
			}
		}
		else
		{
			calculatedFovFromVelocity = cameraFov_FovRange.x;
		}
		playerCam_CineMachScript.Lens.FieldOfView = Mathf.MoveTowards(playerCam_CineMachScript.Lens.FieldOfView, calculatedFovFromVelocity, fov_changeSpeed * Time.deltaTime);
	}

	private void HandleTorqueToLookDirection_Cross()
	{
		if (!(rb == null))
		{
			Vector3 normalized = desiredRotationObject.transform.forward.normalized;
			float y = Vector3.Cross(base.transform.forward.normalized, normalized).y;
			rb.AddTorque(Vector3.up * y * torqueToFace_Force, ForceMode.Force);
		}
	}

	private void HandleGroundHover()
	{
		Vector3 direction = Vector3.down;
		if (currentSlopeAngle > minSlopeAngle)
		{
			direction = -currentSlopeNormal;
		}
		Ray ray = new Ray(hoverFeetCheckPOS.transform.position, direction);
		float num = 1.05f;
		if (Physics.Raycast(ray, out var hitInfo, hoverHeight * num, hoverGroundCheckMask))
		{
			airState = AirState.Grounded;
			GetSlopeAndDirectionOfNormal(hitInfo);
			float distance = hitInfo.distance;
			float num2 = (hoverHeight - distance) * hoverForceAmount;
			float num3 = (0f - rb.linearVelocity.y) * hoverDampening;
			rb.AddForce(Vector3.up * (num2 + num3), ForceMode.Acceleration);
			stepOnHelperObject.transform.position = hitInfo.point;
		}
		else
		{
			currentSlopeAngle = 0f;
			currentSlopeNormal = Vector3.up;
			currentSlopeDirection = Vector3.up;
			currentSlopeMoveVector = Vector3.zero;
			airState = AirState.Airborne;
		}
	}

	private void HandleAirStateChanges()
	{
		canJump = airState == AirState.Grounded;
		if (airState == AirState.Grounded)
		{
			drag_DesiredGround = CalculateGroundedDrag();
		}
		else if (airState == AirState.Airborne)
		{
			rb.linearDamping = currMovementProfile.drag_Airborne;
			maxVeloMagThisJump = GetPlayerVelocityXZOnly().magnitude;
			if (maxVeloMagThisJump < currMovementProfile.minAirControl)
			{
				maxVeloMagThisJump = currMovementProfile.minAirControl;
			}
		}
	}

	private float CalculateGroundedDrag()
	{
		float num = 0f;
		num = ((!(currentSlopeAngle > minSlopeAngle)) ? currMovementProfile.drag_Grounded : (currMovementProfile.drag_Grounded - drag_SlopeReduction));
		if (num < 0f)
		{
			num = 0f;
		}
		return num;
	}

	private void HandleJump()
	{
		bool flag = justJumpedBuffer_Curr > 0f;
		if (justJumpedBuffer_Curr > 0f)
		{
			justJumpedBuffer_Curr -= Time.deltaTime;
		}
		if (airState == AirState.Grounded && InputManager.Singleton.inputActions.PlayerActionMap.Jump.WasPressedThisFrame() && !currMovementProfile.disableJump && (canJump || !flag))
		{
			Jump();
		}
	}

	private void Jump()
	{
		if (GameManager.Singleton.gameState == GameManager.GameState.Playing && HudManager.Singleton.activeUiGroup == HudManager.ActiveUiGroup.Playing)
		{
			justJumpedBuffer_Curr = justJumpedBuffer_Max;
			Vector3 playerVelocityXZOnly = GetPlayerVelocityXZOnly();
			Vector3 up = Vector3.up;
			rb.linearVelocity = playerVelocityXZOnly;
			rb.AddForce(up * currMovementProfile.jumpPower, ForceMode.VelocityChange);
		}
	}

	private void HandleBubbleJetPack()
	{
		if (GameManager.Singleton.hasTimerElapsed_IsNighttime || GameManager.Singleton.hardDisableBubble)
		{
			GameManager.Singleton.HideCameraBubble();
			rb.useGravity = true;
			prevBubbleKeyHoldState = false;
			holdToJetPackBuffer_Curr = 0f;
		}
		if (!PlayerStats.Singleton.bubbleJetpack_Unlocked)
		{
			return;
		}
		if (InputManager.Singleton.inputActions.PlayerActionMap.Jump.IsPressed())
		{
			if (holdToJetPackBuffer_Curr < holdToJetPackBuffer)
			{
				prevBubbleKeyHoldState = false;
				GameManager.Singleton.HideCameraBubble();
				holdToJetPackBuffer_Curr += Time.fixedDeltaTime;
				rb.useGravity = true;
				return;
			}
			_ = prevBubbleKeyHoldState;
			prevBubbleKeyHoldState = true;
			GameManager.Singleton.ShowCameraBubble();
			rb.useGravity = false;
			if (rb.linearVelocity.y < 0f)
			{
				rb.AddForce((0f - rb.linearVelocity.y * 5f) * Vector3.up, ForceMode.Acceleration);
			}
			if (base.transform.position.y < 11f)
			{
				if (rb.linearVelocity.y < 0.85f && rb.linearVelocity.y >= 0f)
				{
					rb.AddForce(Vector3.up * (jetPack_UpwardPower * 10f), ForceMode.Acceleration);
				}
				rb.AddForce(Vector3.up * jetPack_UpwardPower, ForceMode.Acceleration);
			}
			else
			{
				rb.AddForce(Vector3.up * (0f - rb.linearVelocity.y), ForceMode.VelocityChange);
			}
		}
		else
		{
			prevBubbleKeyHoldState = false;
			holdToJetPackBuffer_Curr = 0f;
			GameManager.Singleton.HideCameraBubble();
			rb.useGravity = true;
		}
	}

	private Vector3 GetPlayerVelocityXZOnly()
	{
		Vector3 linearVelocity = rb.linearVelocity;
		linearVelocity.y = 0f;
		return linearVelocity;
	}

	private void GetSlopeAndDirectionOfNormal(RaycastHit _hitInfo)
	{
		Vector3 vector = (currentSlopeNormal = _hitInfo.normal);
		currentSlopeAngle = Vector3.Angle(vector, Vector3.up);
		currentSlopeDirection = Vector3.Cross(vector, Vector3.Cross(Vector3.up, vector)).normalized;
		currentSlopeDirection = -currentSlopeDirection;
		currentSlopeMoveVector = Vector3.ProjectOnPlane(moveVec, vector).normalized;
		Debug.DrawRay(_hitInfo.point, vector, Color.green);
		Debug.DrawRay(_hitInfo.point, currentSlopeDirection, Color.red);
	}

	private void HandleSlopeForces()
	{
		if (currentSlopeAngle > minSlopeAngle)
		{
			float num = slopeSlipAcceleration * currentSlopeAngle;
			Vector3 vector = currentSlopeDirection.normalized * num;
			additionalVelo_ThisFrame += vector;
		}
	}

	private void ApplyAdditionalVelocities()
	{
		if (additionalVelo_ThisFrame != Vector3.zero)
		{
			rb.AddForce(additionalVelo_ThisFrame, ForceMode.Force);
		}
		additionalVelo_ThisFrame = Vector3.zero;
	}

	private void HandleLerpingGroundDrag()
	{
		if (rb.linearDamping < drag_DesiredGround)
		{
			rb.linearDamping += drag_GroundIncreasePerSec * Time.deltaTime;
		}
		else
		{
			rb.linearDamping = drag_DesiredGround;
		}
	}

	private void HandleStamina()
	{
		if (playerMoveState == PlayerMoveState.Sprinting)
		{
			stamina_Curr -= Time.deltaTime * currMovementProfile.staminaDrainRate;
			staminaRegen_DelayCurr = currMovementProfile.staminaRegenDelay;
		}
		else if (staminaRegen_DelayCurr > 0f)
		{
			staminaRegen_DelayCurr -= Time.deltaTime;
		}
		else if (stamina_Curr < currMovementProfile.staminaMax)
		{
			stamina_Curr += currMovementProfile.staminaRegenRate * Time.deltaTime;
		}
		else
		{
			stamina_Curr = currMovementProfile.staminaMax;
		}
		if (stamina_Curr == currMovementProfile.staminaMax)
		{
			HudManager.Singleton.HideStaminaBar();
			return;
		}
		HudManager.Singleton.ShowStaminaBar();
		float value = stamina_Curr / currMovementProfile.staminaMax;
		HudManager.Singleton.UpdateStaminaBar(value);
	}

	public void SteppedOnTrampoline()
	{
		trampolineJumpNextFixedUpdate = true;
	}

	private void HandleTrampolineJumps()
	{
		if (trampolineJumpNextFixedUpdate)
		{
			rb.AddForce(Vector3.up * trampolineBounceForce + new Vector3(0f, 0f - rb.linearVelocity.y, 0f), ForceMode.VelocityChange);
			trampolineJumpNextFixedUpdate = false;
		}
	}

	public Camera GetPlayerCam()
	{
		return playerCam.GetComponent<Camera>();
	}
}
