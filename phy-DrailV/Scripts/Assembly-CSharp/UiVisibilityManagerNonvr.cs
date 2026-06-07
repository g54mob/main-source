using DV;
using DV.InventorySystem;
using DV.UI;
using DV.Utils;
using UnityEngine;

public class UiVisibilityManagerNonvr : SingletonBehaviour<UiVisibilityManagerNonvr>
{
	private bool isVisible = true;

	public GameObject interactionInfoParent;

	public bool GetVisible()
	{
		return isVisible;
	}

	private void Start()
	{
		if (VRManager.IsVREnabled())
		{
			Debug.LogError("UiVisibilityManagerNonvr should only be used in non-vr. Destroying self.");
			Object.Destroy(base.gameObject);
		}
		else
		{
			SetupListeners(on: true);
			RefreshVisible();
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			SingletonBehaviour<AppUtil>.Instance.GamePaused += RefreshVisible;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused += RefreshVisible;
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled += RefreshVisible;
			GamePreferences.RegisterToPreferenceUpdated(Preferences.Crosshair, OnVisibilityUpdated);
		}
		else
		{
			SingletonBehaviour<AppUtil>.Instance.GamePaused -= RefreshVisible;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= RefreshVisible;
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled -= RefreshVisible;
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.Crosshair, OnVisibilityUpdated);
		}
	}

	private void OnVisibilityUpdated()
	{
		if (TimeUtil.IsFlowing)
		{
			RefreshVisible();
		}
	}

	private void RefreshVisible(ACanvasController<CanvasController.ElementType>.Element element)
	{
		RefreshVisible();
	}

	public void RefreshVisible()
	{
		isVisible = GamePreferences.Get<int>(Preferences.Crosshair) < 2 && !SingletonBehaviour<AppUtil>.Instance.IsTimePaused && (!SingletonBehaviour<InventoryViewBase>.Instance || !SingletonBehaviour<InventoryViewBase>.Instance.BigInventoryOpen) && !SingletonBehaviour<ScreenspaceMouse>.Instance.on;
		SetInteractionInfoVisibility(isVisible);
	}

	public void SetInteractionInfoVisibility(bool on)
	{
		if (interactionInfoParent == null)
		{
			Debug.LogError("interactionInfoParent is null!");
		}
		else
		{
			interactionInfoParent.SetActive(on);
		}
	}
}
