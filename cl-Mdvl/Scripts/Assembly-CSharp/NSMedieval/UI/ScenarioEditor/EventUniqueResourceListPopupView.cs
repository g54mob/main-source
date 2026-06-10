using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSMedieval.Model;
using NSMedieval.PlayerTriggeredEventSystem;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI.ScenarioEditor
{
	public class EventUniqueResourceListPopupView : CharacterEditPopupView
	{
		[SerializeField]
		private LayoutGroupView resourcesGroup;

		private readonly List<EventResourceEntry> resourceEntryViews = new List<EventResourceEntry>();

		private readonly List<Resource> eligibleResources = new List<Resource>();

		private Resource alreadySelectedResource;

		private Action<KeyValuePair<string, Resource>, bool> cachedCallback;

		private PlayerTriggeredEventInstance eventInstance;

		private string groupId;

		private ToggleGroup toggleGroup;

		public void ShowResourceList(PlayerTriggeredEventInstance eventInstance, string resourceGroupId, Action<KeyValuePair<string, Resource>, bool> addRemoveCallback)
		{
			cachedCallback = addRemoveCallback;
			this.eventInstance = eventInstance;
			groupId = resourceGroupId;
			popupTitle.SetText(PlayerTriggeredEventUtils.GetUniqueResourceGroupTitleLocalized(eventInstance, resourceGroupId));
			if (PlayerTriggeredEventUtils.GetEligibleUniqueResources(eventInstance.Blueprint.GetUniqueResourceSetting(resourceGroupId), out var collection))
			{
				alreadySelectedResource = this.eventInstance.UniqueResourceGroups[resourceGroupId];
				eligibleResources.Clear();
				eligibleResources.AddRange(collection);
				RefreshView();
			}
		}

		private void AddRemoveCallback(KeyValuePair<string, Resource> groupResourcePair, bool selected)
		{
			cachedCallback(groupResourcePair, selected);
		}

		private void RefreshView()
		{
			Show();
			int num = 0;
			foreach (Resource eligibleResource in eligibleResources)
			{
				EventResourceEntry at = resourceEntryViews.GetAt(resourcesGroup, num);
				bool flag = alreadySelectedResource == eligibleResource && alreadySelectedResource != null;
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(5, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\EventUniqueResourceListPopupView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(flag);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted(alreadySelectedResource);
					messageBuilder.AppendLiteral(" == ");
					messageBuilder.AppendFormatted(eligibleResource);
				}
				Log.Debug(messageBuilder);
				at.SetData(eligibleResource, groupId, flag, toggleGroup, AddRemoveCallback);
				at.SetBackground(num % 2 == 0);
				num++;
			}
			resourceEntryViews.SetActiveFromIndex(num, active: false);
		}

		protected override void Start()
		{
			base.Start();
			toggleGroup = resourcesGroup.GetComponent<ToggleGroup>();
		}
	}
}
