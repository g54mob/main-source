using System.Diagnostics;
using DV;
using DV.Interaction.Inputs;
using DV.Localization;
using DV.Utils;
using UnityEngine;

public class CabTeleportDestination : MonoBehaviour, ITeleportDestination, IPointable
{
	public TeleportHoverGlow hoverGlow;

	public Transform roomscaleTeleportPosition;

	private TrainCar car;

	private bool isVR;

	private InteractionInfoDynamicToggle infoDynamicToggle;

	private void Awake()
	{
		car = TrainCar.Resolve(base.gameObject);
		isVR = VRManager.IsVREnabled();
		if (car == null)
		{
			UnityEngine.Debug.LogError("Unexpected state: car couldn't be found on CabTeleportDestination! Text display won't work properly.");
		}
	}

	private void OnEnable()
	{
	}

	public void Hover(Vector3 _, Vector3 __, HandIPointableSource ___)
	{
		base.enabled = true;
		if (!isVR)
		{
			if (!(PlayerManager.Car == car))
			{
				SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(GetHoverText());
			}
			if (!infoDynamicToggle)
			{
				infoDynamicToggle = SingletonBehaviour<UiVisibilityManagerNonvr>.Instance.GetComponent<InteractionInfoDynamicToggle>();
			}
		}
		if ((bool)hoverGlow)
		{
			hoverGlow.Hover((!isVR && (bool)infoDynamicToggle) ? infoDynamicToggle.FadeValue : 1f);
		}
	}

	public void Unhover()
	{
		if ((bool)hoverGlow)
		{
			hoverGlow.Unhover();
		}
		base.enabled = false;
	}

	public string GetHoverText()
	{
		return LocalizationAPI.L("interaction/enter", InputManager.Actions.Teleport.LocalizeInput());
	}

	public bool IsTeleportAllowed()
	{
		return true;
	}

	public (Vector3 pos, Quaternion rot) GetTeleportPose()
	{
		if (isVR && !GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType) && GamePreferences.Get<int>(Preferences.VRTeleportOrientation) == 3 && (bool)roomscaleTeleportPosition)
		{
			return (pos: GetRoomscaleTeleportPosition(), rot: base.transform.rotation);
		}
		if (PlayerCabPositionManager.TryLoadPosition(car.carLivery.parentType, isVR, out var cabPosition))
		{
			return (pos: base.transform.TransformPoint(cabPosition.localPosition), rot: base.transform.rotation * Quaternion.Euler(cabPosition.nonVRPitch, cabPosition.localRotation, 0f));
		}
		return (pos: base.transform.position, rot: base.transform.rotation);
	}

	public void AfterPlayerTeleported()
	{
		if (!isVR)
		{
			CharacterControllerProvider component = PlayerManager.PlayerTransform.GetComponent<CharacterControllerProvider>();
			CustomFirstPersonController component2 = PlayerManager.PlayerTransform.GetComponent<CustomFirstPersonController>();
			component.IsSitting = false;
			component2.SetCapsuleHeight(1.62f);
			if (PlayerCabPositionManager.TryLoadPosition(car.carLivery.parentType, isVR, out var cabPosition) && cabPosition.sittingHeight > 0f)
			{
				component.IsSitting = true;
				component.SetSittingHeight(cabPosition.sittingHeight);
				component2.SetCapsuleHeight(cabPosition.sittingHeight);
			}
			PlayerManager.PlayerTransform.GetComponent<CameraAnchorLeanCrouch>().UpdateHeight();
			PlayerManager.PlayerTransform.GetComponent<CameraSmoothing>().UpdateImmediately();
		}
	}

	private Vector3 GetRoomscaleTeleportPosition()
	{
		Vector3 position = roomscaleTeleportPosition.position;
		Vector3 localPosition = PlayerManager.ActiveCamera.transform.localPosition;
		localPosition.y = 0f;
		return position + car.transform.rotation * localPosition;
	}

	public bool ShouldRotatePlayerOnTeleport()
	{
		return true;
	}

	[Conditional("UNITY_EDITOR")]
	private void ValidateColliders()
	{
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
		if (componentsInChildren.Length == 0)
		{
			UnityEngine.Debug.LogError("[cab] on '" + base.transform.parent.name + "' doesn't have any colliders", this);
			return;
		}
		Collider[] array = componentsInChildren;
		foreach (Collider collider in array)
		{
			if (!collider.isTrigger)
			{
				UnityEngine.Debug.LogError("[cab] collider on '" + base.transform.parent.name + "' is not set as trigger, player won't be able to enter cab", collider);
			}
		}
	}
}
