using JUTPS.JUInputSystem;
using JUTPS.VehicleSystem;
using JUTPS.WeaponSystem;
using UnityEngine;

namespace JUTPS.CameraSystems
{
	[AddComponentMenu("JU TPS/Third Person System/Cameras/JU Third Person Camera Controller")]
	public class TPSCameraController : JUCameraController
	{
		protected enum PlayerStates
		{
			Normal = 0,
			FireMode = 1,
			Aiming = 2,
			Driving = 3,
			Dead = 4
		}

		public JUCharacterController characterTarget;

		[Header("Settings")]
		public bool FollowUpTarget;

		[Header("Auto Rotator Settings")]
		public bool EnableAutoRotator;

		public float AutoRotateTime = 5f;

		public float AutoRotationSpeed = 4f;

		public bool EnableVehicleAutoRotation;

		public float VehicleAutoRotateTime = 3f;

		public float VehicleAutoRotationSpeed = 8f;

		public CameraState NormalCameraState = new CameraState("Normal Camera State");

		public CameraState FireModeCameraState = new CameraState("Fire Mode Camera State", 3f, 40f);

		public CameraState AimModeCameraState = new CameraState("Scope Mode Camera State", 0f, 15f, 40f, 0f, 0f, 0f, 0f, 0f, 0f, 2.5f);

		public CameraState DrivingVehicleCameraState = new CameraState("Driving Vehicle Camera State", 8f, 25f, 70f, 1.5f, 0f, 0f, 0f, 0f, 0f, 5f, -20f);

		public CameraState DeadPlayerCameraState = new CameraState("Dead Player Camera State", 6f, 5f, 40f, 0f, 0f, 0f, 0f, 0f, 0f, 2.5f, -30f, 60f);

		protected float CurrentTimeToAutoRotation;

		protected bool IsAutoRotationActivated;

		private float xmouse;

		private float ymouse;

		public bool isInFps;

		private bool isInitialized;

		protected PlayerStates CharacterState;

		private float SmoothedXMouse;

		private float SmoothedYMouse;

		private new void OnEnable()
		{
			base.OnEnable();
			Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(Initialize);
		}

		private void OnDisable()
		{
			Singleton<TSNetworkObjetManager>.Instance?.OnServerInitialize.AddListener(Initialize);
		}

		private new void Start()
		{
			base.Start();
		}

		protected void Initialize(TSPlayerController tsPlayer)
		{
			JUCharacterController component;
			if (isInitialized)
			{
				isInitialized = true;
			}
			else if (TargetToFollow.TryGetComponent<JUCharacterController>(out component))
			{
				characterTarget = component;
				TargetToFollow = characterTarget.HumanoidSpine;
			}
		}

		protected virtual void Update()
		{
			SetRotationInput();
			if (FollowUpTarget)
			{
				RotateCamera(xmouse, ymouse, 30f, (characterTarget == null) ? TargetToFollow.up : characterTarget.transform.up);
			}
			else
			{
				RotateCamera(xmouse, ymouse);
			}
			if (EnableAutoRotator)
			{
				if (characterTarget != null)
				{
					NormalAutoRotation(characterTarget);
				}
				else
				{
					NormalAutoRotation(TargetToFollow);
				}
			}
			if (EnableVehicleAutoRotation && characterTarget != null)
			{
				DrivingVehicleAutoRotation((characterTarget.DriveVehicleAbility != null) ? characterTarget.DriveVehicleAbility.VehicleToDrive : null);
			}
			UpdateCharacterState(characterTarget);
			ChangeCameraStateAccordingCharacterState(CharacterState);
		}

		protected virtual void SetRotationInput()
		{
			if (Cursor.lockState != CursorLockMode.Locked && !JUGameManager.IsMobile)
			{
				xmouse = 0f;
				ymouse = 0f;
			}
			else
			{
				xmouse = JUInput.GetAxis(JUInput.Axis.RotateVertical);
				ymouse = JUInput.GetAxis(JUInput.Axis.RotateHorizontal);
			}
		}

		protected virtual void FixedUpdate()
		{
			SetPivotCameraPosition(base.GetCurrentCameraState.GetCameraPivotPosition(TargetToFollow));
		}

		protected virtual void LateUpdate()
		{
			SetCameraPosition(base.GetCurrentCameraState.GetCameraPosition(mCamera.transform), SmoothMove: false);
			SetCameraCollision(base.GetCurrentCameraState.CollisionLayers);
			SetFieldOfView(base.GetCurrentCameraState.CameraFieldOfView);
			SetCameraToScopePosition();
		}

		public override void RecoilReaction(float Force)
		{
			base.RecoilReaction(Force);
			if (!(characterTarget == null))
			{
				Aiming = characterTarget.IsAiming;
			}
		}

		protected override void OnCameraRotate()
		{
			StopAutoRotation();
		}

		protected virtual void UpdateCharacterState(JUCharacterController character)
		{
			if (!(character == null))
			{
				if (!character.IsAiming && !character.IsDriving && !character.FiringMode && !character.IsDead)
				{
					CharacterState = PlayerStates.Normal;
				}
				if (character.IsAiming)
				{
					CharacterState = PlayerStates.Aiming;
				}
				if (character.FiringMode)
				{
					CharacterState = PlayerStates.FireMode;
				}
				if (character.IsDriving)
				{
					CharacterState = PlayerStates.Driving;
				}
				if (character.IsDead)
				{
					CharacterState = PlayerStates.Dead;
				}
			}
		}

		protected virtual void ChangeCameraStateAccordingCharacterState(PlayerStates characterState)
		{
			if (IsTransitioningToCustomState)
			{
				return;
			}
			switch (characterState)
			{
			case PlayerStates.Normal:
				SetCameraStateTransition(base.GetCurrentCameraState, NormalCameraState);
				break;
			case PlayerStates.FireMode:
				if (!isInFps)
				{
					SetCameraStateTransition(base.GetCurrentCameraState, FireModeCameraState);
				}
				break;
			case PlayerStates.Aiming:
				SetCameraStateTransition(base.GetCurrentCameraState, AimModeCameraState);
				break;
			case PlayerStates.Driving:
				SetCameraStateTransition(base.GetCurrentCameraState, DrivingVehicleCameraState);
				break;
			case PlayerStates.Dead:
				SetCameraStateTransition(base.GetCurrentCameraState, DeadPlayerCameraState);
				break;
			}
		}

		protected virtual void SetCameraToScopePosition()
		{
			if (characterTarget == null)
			{
				return;
			}
			Aiming = characterTarget.IsAiming;
			if (characterTarget.IsItemEquiped)
			{
				if (Aiming && characterTarget.WeaponInUseRightHand.AimMode != Weapon.WeaponAimMode.None && characterTarget.FiringMode)
				{
					Weapon weaponInUseRightHand = characterTarget.WeaponInUseRightHand;
					SmoothedYMouse = Mathf.Lerp(SmoothedYMouse, ymouse, 10f * Time.deltaTime);
					SmoothedXMouse = Mathf.Lerp(SmoothedXMouse, xmouse, 10f * Time.deltaTime);
					Vector3 targetPosition = weaponInUseRightHand.transform.position + weaponInUseRightHand.transform.right * (weaponInUseRightHand.CameraAimingPosition.x - SmoothedYMouse / 80f) + weaponInUseRightHand.transform.up * (weaponInUseRightHand.CameraAimingPosition.y - SmoothedXMouse / 80f) + mCamera.transform.parent.forward * weaponInUseRightHand.CameraAimingPosition.z;
					SetCameraPosition(targetPosition, SmoothMove: false);
					AimModeCameraState.CameraFieldOfView = Mathf.Lerp(AimModeCameraState.CameraFieldOfView, weaponInUseRightHand.CameraFOV, 15f * Time.deltaTime);
					SetFieldOfView(AimModeCameraState.CameraFieldOfView);
				}
				else
				{
					AimModeCameraState.CameraFieldOfView = base.GetCurrentCameraState.CameraFieldOfView;
				}
			}
		}

		protected virtual void NormalAutoRotation(JUCharacterController character)
		{
			if (character == null || !EnableAutoRotator)
			{
				return;
			}
			if (character.FiringMode)
			{
				CurrentTimeToAutoRotation = 0f;
				return;
			}
			if (character.IsMoving)
			{
				CurrentTimeToAutoRotation += 2f * Time.deltaTime;
			}
			AutoRotator(character.transform, AutoRotateTime, AutoRotationSpeed, AutoRotationSpeed);
		}

		protected virtual void NormalAutoRotation(Transform targetToFollow)
		{
			if (!(targetToFollow == null) && EnableAutoRotator)
			{
				AutoRotator(targetToFollow, AutoRotateTime, AutoRotationSpeed, AutoRotationSpeed);
			}
		}

		protected virtual void DrivingVehicleAutoRotation(Vehicle drivingVehicle)
		{
			if (!(drivingVehicle == null) && drivingVehicle.IsOn)
			{
				AutoRotator(drivingVehicle.transform, VehicleAutoRotateTime, VehicleAutoRotationSpeed, VehicleAutoRotationSpeed);
			}
		}

		public virtual void AutoRotator(Transform targetRotation, float MaxTimeToAutoRotation, float HorizontalSpeed = 5f, float VerticalSpeed = 3f, float AngleToStopAutoRotation = 90f)
		{
			if (Vector3.Angle(targetRotation.up, Vector3.up) > AngleToStopAutoRotation)
			{
				Debug.Log("Disabled Camera Auto Rotation in angle " + AngleToStopAutoRotation);
				return;
			}
			if (IsAutoRotationActivated)
			{
				rotytarget = Mathf.LerpAngle(rotytarget, targetRotation.rotation.eulerAngles.y, HorizontalSpeed * Time.deltaTime);
				rotxtarget = Mathf.LerpAngle(rotxtarget, 0f, VerticalSpeed * Time.deltaTime);
				return;
			}
			CurrentTimeToAutoRotation += Time.deltaTime;
			if (CurrentTimeToAutoRotation >= MaxTimeToAutoRotation)
			{
				IsAutoRotationActivated = true;
				CurrentTimeToAutoRotation = 0f;
			}
		}

		public virtual void StopAutoRotation()
		{
			CurrentTimeToAutoRotation = 0f;
			IsAutoRotationActivated = false;
		}

		public virtual void DisableVehicleAutoRotation()
		{
			StopAutoRotation();
			EnableVehicleAutoRotation = false;
		}
	}
}
