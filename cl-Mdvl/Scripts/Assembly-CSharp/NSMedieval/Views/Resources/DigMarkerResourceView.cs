using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Views.Resources
{
	public class DigMarkerResourceView : MapResourceView<DigMarkerResourceInstance>
	{
		[SerializeField]
		private Collider voxelCollider;

		public Collider GetCollider => voxelCollider;

		public override void Setup(DigMarkerResourceInstance resource)
		{
			base.Setup(resource);
			resource.CancelDigMarkerFromInstanceEvent += OnCancelFromInstance;
		}

		public override string GetAdditionalMenuId()
		{
			return "digMarker";
		}

		public virtual void OnInstantiated()
		{
			if (base.ResourceInstance != null && !(base.ResourceInstance.Blueprint == null))
			{
				MonoSingleton<ResourceCommonController>.Instance.AddMiningMarker(base.ResourceInstance);
			}
		}

		public override WorldObject GetAsWorldObject()
		{
			return base.ResourceInstance;
		}

		public override string GetMultiselectName()
		{
			return "map_resource";
		}

		public override void CancelOrder(OrderType order)
		{
			if (base.ResourceInstance != null && !base.ResourceInstance.HasDisposed)
			{
				OrderType orderType = OrderType.None;
				if (order != OrderType.Cancel)
				{
					orderType = base.ResourceInstance.CurrentOrder & ~order;
				}
				base.ResourceInstance.SetPlayerOrder(orderType != OrderType.None);
				base.ResourceInstance.SetCurrentOrder(orderType);
			}
		}

		public override void OnOrderRefreshed()
		{
			if (base.ResourceInstance != null && !base.ResourceInstance.HasDisposed && base.ResourceInstance.OwnedByPlayer())
			{
				base.OnOrderRefreshed();
				if (base.ResourceInstance.CurrentOrder == OrderType.None && base.ResourceInstance.Blueprint.AutoRemoveOnCancelOrder)
				{
					Deselect();
					MonoSingleton<SlopeManager>.Instance.GetSlopeAtPosition(base.ResourceInstance.GridDataPosition - Vec3Int.up)?.OnDigCanceled();
					base.ResourceInstance.DontChangeTerrain();
					MonoSingleton<ReservationManager>.Instance.ReleaseAll(base.ResourceInstance);
					MonoSingleton<ResourceCommonController>.Instance.DestroyResource(base.ResourceInstance);
					Dispose();
				}
			}
		}

		protected override List<string> GetInfos()
		{
			MapNode gridSpaceBelow = base.ResourceInstance.GetGridSpaceBelow();
			List<string> list = new List<string>();
			list.Add(string.Format("{0}: <color=#ffeca8>{1}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("menu_hit_points"), gridSpaceBelow?.Health));
			list.Add(string.Format("{0}: <color=#ffeca8>{1}, {2}, {3}</color>\n", MonoSingleton<LocalizationController>.Instance.GetText("global_position"), (int)base.ResourceInstance.WorldPosition.x, (int)base.ResourceInstance.WorldPosition.y, (int)base.ResourceInstance.WorldPosition.z));
			return list;
		}

		protected override List<InfoPanelStat> GetInfoStats()
		{
			List<InfoPanelStat> list = new List<InfoPanelStat>();
			MapNode gridSpaceBelow = base.ResourceInstance.GetGridSpaceBelow();
			if (gridSpaceBelow?.VoxelType == null)
			{
				return list;
			}
			list.Add(new InfoPanelStat("menu_hit_points", "/", new IntRange(gridSpaceBelow.Health, gridSpaceBelow.VoxelType.Health), StatType.Health));
			return list;
		}

		protected override List<InfoPanelAction> GetInfoPanelActions()
		{
			if (base.ResourceInstance == null || base.ResourceInstance.HasDisposed || !base.ResourceInstance.OwnedByPlayer())
			{
				return new List<InfoPanelAction>();
			}
			return base.GetInfoPanelActions();
		}

		protected override List<InfoPanelResource> GetResourcesInfo()
		{
			List<InfoPanelResource> resourcesInfo = base.GetResourcesInfo();
			if (base.ResourceInstance?.Blueprint.StoredResources != null)
			{
				MapNode gridSpaceBelow = base.ResourceInstance.GetGridSpaceBelow();
				if (gridSpaceBelow?.VoxelType == null)
				{
					return resourcesInfo;
				}
				float mineYieldMultiplier = GlobalSaveController.CurrentVillageData.GameParametersCurrent.MineYieldMultiplier;
				foreach (ResourceInstance storedResource in base.ResourceInstance.Blueprint.StoredResources)
				{
					if (storedResource != null)
					{
						int min = (int)((float)(storedResource.Amount * gridSpaceBelow.DigAmount) * mineYieldMultiplier);
						int max = (int)((float)(storedResource.Amount * gridSpaceBelow.VoxelType.DigAmount) * mineYieldMultiplier);
						resourcesInfo.Add(new InfoPanelResource(storedResource.BlueprintId, "resource", new IntRange(min, max)));
					}
				}
			}
			return resourcesInfo;
		}

		private void OnCancelFromInstance()
		{
			if (base.ResourceInstance.OwnedByPlayer())
			{
				CancelOrder(OrderType.Cancel);
				return;
			}
			Deselect();
			MonoSingleton<SlopeManager>.Instance.GetSlopeAtPosition(base.ResourceInstance.GridDataPosition - Vec3Int.up)?.OnDigCanceled();
			base.ResourceInstance.DontChangeTerrain();
			MonoSingleton<ReservationManager>.Instance.ReleaseAll(base.ResourceInstance);
			MonoSingleton<ResourceCommonController>.Instance.DestroyResource(base.ResourceInstance);
			Dispose();
		}
	}
}
