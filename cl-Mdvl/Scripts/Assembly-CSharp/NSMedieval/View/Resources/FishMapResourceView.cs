using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Map;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Tutorial;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Views.Resources;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.View.Resources
{
	public class FishMapResourceView : MapResourceView<FishMapResourceInstance>
	{
		public void OnInstantiated()
		{
			base.transform.position += Vector3.up * World.MapBlockHeight;
		}

		public override WorldObject GetAsWorldObject()
		{
			return base.ResourceInstance;
		}

		public override string GetMultiselectName()
		{
			if (!base.HasDisposed)
			{
				return base.ResourceInstance.BlueprintId;
			}
			return string.Empty;
		}

		public override string GetAdditionalMenuId()
		{
			return "fish";
		}

		protected override List<InfoPanelResource> GetResourcesInfo()
		{
			List<InfoPanelResource> resourcesInfo = base.GetResourcesInfo();
			foreach (ResourceInstance storedResource in base.ResourceInstance.Blueprint.StoredResources)
			{
				if (storedResource != null)
				{
					int min = base.ResourceInstance.FishRemaining * storedResource.Amount;
					int max = base.ResourceInstance.Blueprint.FishingCount * storedResource.Amount;
					resourcesInfo.Add(new InfoPanelResource(storedResource.BlueprintId, "resource", new IntRange(min, max)));
				}
			}
			return resourcesInfo;
		}

		protected override List<InfoPanelAction> GetInfoPanelActions()
		{
			if (TutorialManager.IsTutorialActive && !MonoSingleton<TutorialManager>.Instance.AllowCreatureCommands)
			{
				return new List<InfoPanelAction>();
			}
			int currentIndex = ((base.ResourceInstance.CurrentOrder == OrderType.Fishing) ? 1 : 0);
			KeyValuePair<SelectionInputActionData, Action>[] objectActions = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Fishing"), delegate
				{
					GiveOrder(OrderType.Fishing);
				}),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), delegate
				{
					CancelOrder(OrderType.Fishing);
				})
			};
			return new List<InfoPanelAction>
			{
				new InfoPanelAction(objectActions, currentIndex)
			};
		}
	}
}
