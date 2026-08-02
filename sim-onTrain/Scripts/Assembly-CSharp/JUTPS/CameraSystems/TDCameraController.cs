using UnityEngine;

namespace JUTPS.CameraSystems
{
	[AddComponentMenu("JU TPS/Third Person System/Cameras/JU TopDown Camera Controller")]
	public class TDCameraController : JUCameraController
	{
		protected enum PlayerStates
		{
			Normal = 0,
			FireMode = 1,
			Aiming = 2,
			Driving = 3,
			Dead = 4,
			TpsFixed = 5
		}

		[HideInInspector]
		public JUCharacterController PlayerTarget;

		[Header("Default Camera States")]
		public CameraState NormalCameraState = new CameraState("Normal Camera State", 15f, 15f, 50f, 0f, 0f, 0f, 0f, 0f);

		public CameraState FireModeCameraState = new CameraState("Fire Mode Camera State", 15f, 15f, 50f, 0f, 0f, 0f, 0f, 0f);

		public CameraState AimModeCameraState = new CameraState("Scope Mode Camera State", 15f, 15f, 50f, 0f, 0f, 0f, 0f, 0f);

		public CameraState DrivingVehicleCameraState = new CameraState("Driving Vehicle Camera State", 15f, 15f, 50f, 0f, 0f, 0f, 0f, 0f);

		public CameraState DeadPlayerCameraState = new CameraState("Dead Player Camera State", 15f, 15f, 30f, 0f, 0f, 0f, 0f, 0f);

		public CameraState TpsFixedModeCameraState = new CameraState("TpsFixed Mode Camera State", 15f, 15f, 50f, 0f, 0f, 0f, 0f, 0f);

		protected PlayerStates CharacterState;

		protected override void Start()
		{
			base.Start();
			if (TargetToFollow != null && TargetToFollow.TryGetComponent<JUCharacterController>(out var component))
			{
				PlayerTarget = component;
				TargetToFollow = PlayerTarget.HumanoidSpine;
			}
		}

		protected virtual void Update()
		{
			UpdateCharacterState(PlayerTarget ? PlayerTarget : null);
			ChangeCameraStateAccordingCharacterState(CharacterState);
		}

		protected virtual void FixedUpdate()
		{
			if (!(TargetToFollow == null))
			{
				SetPivotCameraPosition(base.GetCurrentCameraState.GetCameraPivotPosition(TargetToFollow));
			}
		}

		protected virtual void LateUpdate()
		{
			SetCameraPosition(base.GetCurrentCameraState.GetCameraPosition(mCamera.transform), SmoothMove: false);
			SetFieldOfView(base.GetCurrentCameraState.CameraFieldOfView);
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
			if (!IsTransitioningToCustomState)
			{
				switch (characterState)
				{
				case PlayerStates.Normal:
					SetCameraStateTransition(base.GetCurrentCameraState, NormalCameraState);
					break;
				case PlayerStates.FireMode:
					SetCameraStateTransition(base.GetCurrentCameraState, FireModeCameraState);
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
				case PlayerStates.TpsFixed:
					SetCameraStateTransition(base.GetCurrentCameraState, TpsFixedModeCameraState);
					break;
				}
			}
		}
	}
}
