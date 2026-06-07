using System;
using UnityEngine;

public abstract class ACharacterControllerProvider : MonoBehaviour
{
	public Action<float, float> OnPlayerHeightAdjusted;

	public abstract bool IsGameLoaded { get; }

	public abstract Vector3 OriginShift { get; }

	public abstract float WaterLevel { get; }

	public abstract float PlayerSittingHeight { get; }

	public abstract bool IsSitting { get; set; }

	public abstract bool IsInCar { get; }

	public abstract bool IsVR { get; }

	public abstract bool IsVRSeatedMode { get; }

	public abstract bool IsAlwaysRunEnabled { get; }

	public abstract float VRSeatedHeight { get; }

	public abstract float VRRoomscaleHeight { get; }

	public abstract bool UseHeadBob { get; }

	public abstract bool InvertMouseYPreference { get; }

	public abstract bool LeanToggle { get; }

	public abstract bool CrouchToggle { get; }

	public abstract bool RunToggle { get; }

	public abstract int MovablePlatformLayer { get; }

	public abstract void CheckSitting();

	public abstract (Transform carTransform, Bounds carBounds) GetCarTransformAndBounds();

	public abstract void AlwaysRunToggleChange_Register(Action onToggleAlwaysRun);

	public abstract void AlwaysRunToggleChange_Unregister(Action onToggleAlwaysRun);

	public abstract Camera GetVRCamera();

	public abstract void VRTKToggle_Register(CustomFirstPersonController customFirstPersonController);

	public abstract void VRTKToggle_Unregister(CustomFirstPersonController customFirstPersonController);

	public abstract void SeatedPlayAreaTypeChange_Register(Action onSeatedPlayAreaTypeChange);

	public abstract void SeatedPlayAreaTypeChange_Unregister(Action onSeatedPlayAreaTypeChange);

	public abstract void TeleportStarted_Register(Action onTeleportStarted);

	public abstract void TeleportStarted_Unregister(Action onTeleportStarted);

	public abstract void OriginShiftUpdated_Register(Action<Vector3> onWorldMoved);

	public abstract void OriginShiftUpdated_Unregister(Action<Vector3> onWorldMoved);

	public abstract void HeadBobPreferenceUpdated_Register(Action onHeadBobPreferenceUpdated);

	public abstract void HeadBobPreferenceUpdated_Unregister(Action onHeadBobPreferenceUpdated);

	public abstract void RequestCursor(CustomMouseLook caller, bool cursorVisible);

	public abstract void InvertMouseYChanged_Register(Action onInvertMouseYUpdated);

	public abstract void RequestSystemStuff_Register(Action<float> onMouseSensitivityStateChanged, Action<bool> screenspaceMouseOnValueChanged);

	public abstract void RequestValue(object caller, int state, int priority);

	public abstract void RemoveValue(object caller);

	public abstract void TrainCarExplosion_Register(Action<Vector3, float> onPlayerInExplosion);

	public abstract void TrainCarExplosion_Unregister(Action<Vector3, float> onPlayerInExplosion);

	public abstract void LeanToggleChanged_Register(Action onToggleLeanPreferenceUpdated);

	public abstract void LeanToggleChanged_Unregister(Action onToggleLeanPreferenceUpdated);

	public abstract void CrouchToggleChanged_Register(Action onToggleCrouchPreferenceUpdated);

	public abstract void CrouchToggleChanged_Unregister(Action onToggleCrouchPreferenceUpdated);

	public abstract void RunToggleChanged_Register(Action onToggleRunPreferenceUpdated);

	public abstract void RunToggleChanged_Unregister(Action onToggleRunPreferenceUpdated);

	public abstract ILocomotionInputInterpreter GetLocomotionInputInterpreter();

	public abstract Bounds GetTrainBounds(Transform trainTransform);

	public abstract void OnCharacterReparented(Transform reparentedTo);
}
