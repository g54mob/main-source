using System;
using DV.Interaction.Inputs;
using DV.UI;
using DV.Utils;
using UnityEngine;
using VRTK;

public class CharacterControllerProvider : ACharacterControllerProvider
{
	private float _playerSittingHeight;

	private float sittingButtonTimer;

	private Vector3 playerSittingStartPosition;

	private bool _isSitting;

	private bool _subscribedToScroll;

	private RequestSystem requestSystem = new RequestSystem(0f);

	private Vector3 PlayerCurrentPosition
	{
		get
		{
			if (!base.transform.parent)
			{
				return base.transform.localPosition - OriginShift;
			}
			return base.transform.localPosition;
		}
	}

	public override bool IsGameLoaded
	{
		get
		{
			if (WorldStreamingInit.IsLoaded)
			{
				return !LoadingScreenManager.IsLoading;
			}
			return false;
		}
	}

	public override Vector3 OriginShift => WorldMover.currentMove;

	public override float WaterLevel => LevelInfo.WaterLevel;

	public override float PlayerSittingHeight => _playerSittingHeight;

	public override bool IsSitting
	{
		get
		{
			return _isSitting;
		}
		set
		{
			if (_isSitting && !value && InputManager.NewPlayer.GetButton(InputManager.Actions.Sit))
			{
				SingletonBehaviour<MouseInputEvents>.Instance.UnsubscribeScrollReceiver(OnScrolled);
			}
			if (!_isSitting && value)
			{
				playerSittingStartPosition = PlayerCurrentPosition;
			}
			_isSitting = value;
		}
	}

	public override bool IsInCar => PlayerManager.Car != null;

	public override bool IsVR => VRManager.IsVREnabled();

	public override bool IsVRSeatedMode => GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType);

	public override bool IsAlwaysRunEnabled => GamePreferences.Get<bool>(Preferences.AlwaysRunToggle);

	public override float VRSeatedHeight => GamePreferences.Get<float>(Preferences.PlayerSeatedHeight);

	public override float VRRoomscaleHeight => GamePreferences.Get<float>(Preferences.PlayerRoomscaleHeight);

	public override bool UseHeadBob => GamePreferences.Get<bool>(Preferences.HeadBob);

	public override bool InvertMouseYPreference => GamePreferences.Get<bool>(Preferences.InvertMouseY);

	public override bool LeanToggle => GamePreferences.Get<bool>(Preferences.LeanToggle);

	public override bool CrouchToggle => GamePreferences.Get<bool>(Preferences.CrouchToggle);

	public override bool RunToggle => GamePreferences.Get<bool>(Preferences.RunToggle);

	public override int MovablePlatformLayer => LayerMask.NameToLayer("Train_Walkable");

	private event Action<Vector3> WorldMovedStripped;

	private void HackAwake()
	{
		if ((bool)SingletonBehaviour<WorldMover>.Instance)
		{
			SingletonBehaviour<WorldMover>.Instance.WorldMoved += OnWorldMoved;
		}
	}

	private void HackOnDestroy()
	{
		if ((bool)SingletonBehaviour<WorldMover>.Instance)
		{
			SingletonBehaviour<WorldMover>.Instance.WorldMoved -= OnWorldMoved;
		}
	}

	private void OnWorldMoved(WorldMover _, Vector3 move)
	{
		this.WorldMovedStripped?.Invoke(move);
	}

	private void Awake()
	{
		HackAwake();
		_playerSittingHeight = 1.3f;
	}

	private void OnDestroy()
	{
		HackOnDestroy();
	}

	public override void CheckSitting()
	{
		if (VRManager.IsVREnabled())
		{
			return;
		}
		if (IsSitting)
		{
			if ((playerSittingStartPosition - PlayerCurrentPosition).sqrMagnitude > 9f)
			{
				IsSitting = false;
			}
			else if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Sit))
			{
				sittingButtonTimer = Time.time;
				SubScroll();
			}
			else if (_subscribedToScroll && !InputManager.NewPlayer.GetButton(InputManager.Actions.Sit))
			{
				UnsubScroll();
				if (Time.time - sittingButtonTimer < 0.3f)
				{
					IsSitting = false;
				}
			}
			if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Crouch) && GamePreferences.Get<bool>(Preferences.CrouchToggle))
			{
				IsSitting = false;
			}
		}
		else
		{
			if (_subscribedToScroll)
			{
				UnsubScroll();
			}
			if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Sit))
			{
				IsSitting = true;
				SubScroll();
			}
		}
	}

	private void SubScroll()
	{
		_subscribedToScroll = true;
		SingletonBehaviour<MouseInputEvents>.Instance.SubscribeScrollReceiver(OnScrolled, 10);
	}

	private void UnsubScroll()
	{
		_subscribedToScroll = false;
		SingletonBehaviour<MouseInputEvents>.Instance.UnsubscribeScrollReceiver(OnScrolled);
	}

	private void OnScrolled(int scroll)
	{
		_playerSittingHeight += (float)scroll * 0.1f;
		SetSittingHeight(_playerSittingHeight);
	}

	public void SetSittingHeight(float height)
	{
		float playerSittingHeight = _playerSittingHeight;
		_playerSittingHeight = Mathf.Clamp(height, 0.8f, 1.5f);
		float num = _playerSittingHeight - playerSittingHeight;
		if (num != 0f)
		{
			OnPlayerHeightAdjusted?.Invoke(_playerSittingHeight, num);
		}
	}

	public override (Transform carTransform, Bounds carBounds) GetCarTransformAndBounds()
	{
		return (carTransform: PlayerManager.Car.transform, carBounds: PlayerManager.Car.Bounds);
	}

	public override void AlwaysRunToggleChange_Register(Action callback)
	{
		GamePreferences.RegisterToPreferenceUpdated(Preferences.AlwaysRunToggle, callback);
	}

	public override void AlwaysRunToggleChange_Unregister(Action callback)
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.AlwaysRunToggle, callback);
	}

	public override Camera GetVRCamera()
	{
		return VRTK_DeviceFinder.HeadsetCamera().GetComponentInChildren<Camera>();
	}

	public override void VRTKToggle_Register(CustomFirstPersonController instance)
	{
		VRTK_SDKManager.instance?.AddBehaviourToToggleOnLoadedSetupChange(instance);
	}

	public override void VRTKToggle_Unregister(CustomFirstPersonController instance)
	{
		VRTK_SDKManager.instance?.RemoveBehaviourToToggleOnLoadedSetupChange(instance);
	}

	public override void SeatedPlayAreaTypeChange_Register(Action callback)
	{
		GamePreferences.RegisterToPreferenceUpdated(Preferences.SeatedPlayAreaType, callback);
	}

	public override void SeatedPlayAreaTypeChange_Unregister(Action callback)
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.SeatedPlayAreaType, callback);
	}

	public override void TeleportStarted_Register(Action callback)
	{
		PlayerManager.PlayerTeleportStarted += callback;
	}

	public override void TeleportStarted_Unregister(Action callback)
	{
		PlayerManager.PlayerTeleportStarted -= callback;
	}

	public override void OriginShiftUpdated_Register(Action<Vector3> callback)
	{
		WorldMovedStripped += callback;
	}

	public override void OriginShiftUpdated_Unregister(Action<Vector3> callback)
	{
		WorldMovedStripped -= callback;
	}

	public override void HeadBobPreferenceUpdated_Register(Action callback)
	{
		GamePreferences.RegisterToPreferenceUpdated(Preferences.HeadBob, callback);
	}

	public override void HeadBobPreferenceUpdated_Unregister(Action callback)
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.HeadBob, callback);
	}

	public override void RequestCursor(CustomMouseLook caller, bool cursorVisible)
	{
		SingletonBehaviour<CursorManager>.Instance.RequestCursor(caller, cursorVisible, -100);
	}

	public override void InvertMouseYChanged_Register(Action callback)
	{
		GamePreferences.RegisterToPreferenceUpdated(Preferences.InvertMouseY, callback);
	}

	public override void RequestSystemStuff_Register(Action<float> OnMouseSensitivityStateChanged, Action<bool> ScreenspaceMouseOnValueChanged)
	{
		requestSystem.ValueChanged += OnMouseSensitivityStateChanged;
		SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged += ScreenspaceMouseOnValueChanged;
	}

	public override void RequestValue(object caller, int state, int priority)
	{
		requestSystem.RequestValue(caller, state, priority);
	}

	public override void RemoveValue(object caller)
	{
		requestSystem.RemoveValue(caller);
	}

	public override void TrainCarExplosion_Register(Action<Vector3, float> callback)
	{
		TrainCarExplosion.PlayerInExplosion += callback;
	}

	public override void TrainCarExplosion_Unregister(Action<Vector3, float> callback)
	{
		TrainCarExplosion.PlayerInExplosion -= callback;
	}

	public override void LeanToggleChanged_Register(Action callback)
	{
		GamePreferences.RegisterToPreferenceUpdated(Preferences.LeanToggle, callback);
	}

	public override void LeanToggleChanged_Unregister(Action callback)
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.LeanToggle, callback);
	}

	public override void CrouchToggleChanged_Register(Action callback)
	{
		GamePreferences.RegisterToPreferenceUpdated(Preferences.CrouchToggle, callback);
	}

	public override void CrouchToggleChanged_Unregister(Action callback)
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.CrouchToggle, callback);
	}

	public override void RunToggleChanged_Register(Action onToggleRunPreferenceUpdated)
	{
		GamePreferences.RegisterToPreferenceUpdated(Preferences.RunToggle, onToggleRunPreferenceUpdated);
	}

	public override void RunToggleChanged_Unregister(Action onToggleRunPreferenceUpdated)
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.RunToggle, onToggleRunPreferenceUpdated);
	}

	public override ILocomotionInputInterpreter GetLocomotionInputInterpreter()
	{
		if (IsVR)
		{
			return new LocomotionInputVr();
		}
		return new LocomotionInputNonVr();
	}

	public override Bounds GetTrainBounds(Transform trainTransform)
	{
		return TrainCar.Resolve(trainTransform).Bounds;
	}

	public override void OnCharacterReparented(Transform reparentedTo)
	{
		bool flag = reparentedTo != null;
		TrainCar trainCar = (flag ? TrainCar.Resolve(reparentedTo) : null);
		if (PlayerManager.Car != trainCar)
		{
			PlayerManager.SetCar(trainCar);
		}
		if ((bool)SingletonBehaviour<WorldMover>.Instance)
		{
			SingletonBehaviour<WorldMover>.Instance.playerTracker.SetShouldApplyOriginShift(!flag);
		}
	}
}
