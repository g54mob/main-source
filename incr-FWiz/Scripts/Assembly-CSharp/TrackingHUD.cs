using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class TrackingHUD : MonoBehaviour
{
	public static TrackingHUD Instance;

	public List<TrackingHUDItem> HUDItemPrefabs;

	public List<TrackingHUDItem> HUDItems;

	public TrackingHUDItem OpenHuditem;

	public EventReference ToggleSound;

	public bool ClosedAll;

	public Transform TrackingItemParent;

	public bool ShouldBeActive => false;

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void Show(object showObject)
	{
	}

	public void Remove(TrackingHUDItem hudItem)
	{
	}

	public void OnSetEnabled(bool enabled)
	{
	}

	public void OnShowTrackingItem()
	{
	}

	public void OnHideTrackingItem()
	{
	}

	public void Evaluate()
	{
	}

	public void ToggleOpenHudItem(TrackingHUDItem selectedHudItem)
	{
	}
}
