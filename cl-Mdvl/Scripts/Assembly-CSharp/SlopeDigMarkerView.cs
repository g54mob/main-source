using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI;
using NSMedieval.Views.Resources;
using UnityEngine;

public class SlopeDigMarkerView : DigMarkerResourceView
{
	[SerializeField]
	private Collider meshCollider;

	[SerializeField]
	private Vector3 colliderOffset;

	private SlopeInstance slope;

	public override void OnInstantiated()
	{
		base.OnInstantiated();
		slope = MonoSingleton<SlopeManager>.Instance.GetSlopeAtPosition(base.ResourceInstance.GridDataPosition - Vec3Int.up);
		if (slope == null)
		{
			Debug.Log("Slope not found for SlopeDigMarkerView. TODO: delete SlopeDigMarkerViews which do not have a slope.");
			return;
		}
		Transform transform = base.transform;
		transform.rotation = Quaternion.Euler(0f, slope.Angle - 90f, 0f);
		transform.localPosition += transform.rotation * colliderOffset;
	}

	protected override List<InfoPanelStat> GetInfoStats()
	{
		List<InfoPanelStat> list = new List<InfoPanelStat>();
		if (slope == null)
		{
			return list;
		}
		list.Add(new InfoPanelStat("menu_hit_points", "/", new IntRange((int)slope.Health, slope.HealthMax), StatType.Health));
		return list;
	}

	protected override List<InfoPanelResource> GetResourcesInfo()
	{
		if (base.ResourceInstance == null || base.ResourceInstance.Blueprint == null)
		{
			return new List<InfoPanelResource>();
		}
		SlopeInstance slopeAtPosition = MonoSingleton<SlopeManager>.Instance.GetSlopeAtPosition(base.ResourceInstance.GridDataPosition - Vec3Int.up);
		if (slopeAtPosition == null)
		{
			return new List<InfoPanelResource>();
		}
		List<InfoPanelResource> list = new List<InfoPanelResource>();
		if (base.ResourceInstance.Blueprint.StoredResources == null)
		{
			return list;
		}
		float mineYieldMultiplier = GlobalSaveController.CurrentVillageData.GameParametersCurrent.MineYieldMultiplier;
		foreach (ResourceInstance storedResource in base.ResourceInstance.Blueprint.StoredResources)
		{
			int min = (int)((float)(storedResource.Amount * slopeAtPosition.DigAmount) * mineYieldMultiplier);
			int max = (int)((float)(storedResource.Amount * slopeAtPosition.DigAmountMax) * mineYieldMultiplier);
			list.Add(new InfoPanelResource(storedResource.BlueprintId, "resource", new IntRange(min, max)));
		}
		return list;
	}

	internal override void Deselect(bool isSilent = false)
	{
		base.Deselect(isSilent);
		if (slope != null)
		{
			slope.Selected = false;
		}
	}

	internal override void Select()
	{
		if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.LeftControl))
		{
			ClickedJumpToLowerLayer();
			return;
		}
		base.Select();
		if (slope != null)
		{
			slope.Selected = true;
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		slope = null;
	}
}
