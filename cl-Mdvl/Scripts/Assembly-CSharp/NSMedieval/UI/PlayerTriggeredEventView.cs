using System.Collections.Generic;
using System.Text;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Repository;
using NSMedieval.UI.ScenarioEditor;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class PlayerTriggeredEventView : PopupView
	{
		[SerializeField]
		private GameObject content;

		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private TMP_Text info;

		[SerializeField]
		private SoundButton[] closeButtons;

		[SerializeField]
		private SoundButton acceptButton;

		[SerializeField]
		private EventParticipantListPopupView participantListPopupView;

		[SerializeField]
		private EventUniqueResourceListPopupView uniqueResourceListPopupView;

		[SerializeField]
		private GameObject leftPanelParent;

		[SerializeField]
		private GameObject participantsManyPrefab;

		[SerializeField]
		private GameObject participantsFewPrefab;

		[SerializeField]
		private GameObject resourceSettingsViewPrefab;

		[SerializeField]
		private GameObject uniqueResourceGroupPrefab;

		[SerializeField]
		private TMP_Text eventQualityList;

		[SerializeField]
		private TMP_Text estimatedEventQuality;

		[SerializeField]
		private TMP_Text eventQualityInfo;

		[SerializeField]
		private TMP_Text additionalInfo;

		private StringBuilder sb = new StringBuilder();

		private readonly int indentFirst = 70;

		private readonly int indentSecond = 90;

		private readonly List<PlayerEventParticipantGroupView> participantGroupViews = new List<PlayerEventParticipantGroupView>();

		private readonly Dictionary<string, List<PlayerEventResourceView>> resourceViews = new Dictionary<string, List<PlayerEventResourceView>>();

		private readonly List<PlayerEventResourceSettingsView> resourceSettingsViews = new List<PlayerEventResourceSettingsView>();

		private readonly List<PlayerEventUniqueResourceGroupView> uniqueResourceGroupViews = new List<PlayerEventUniqueResourceGroupView>();

		private PlayerTriggeredEventInstance eventInstance;

		public void SetDataAndShow(PlayerTriggeredEventInstance eventInstance)
		{
			Show();
			this.eventInstance = eventInstance;
			this.eventInstance.EventInventoryChangedAction += RefreshView;
			title.SetText(PlayerTriggeredEventUtils.GetLocalizedName(this.eventInstance.Blueprint));
			info.SetText(PlayerTriggeredEventUtils.GetLocalizedInfo(this.eventInstance.Blueprint));
			eventQualityInfo.SetText(string.Format("{0}: {1}{2}\n", MonoSingleton<LocalizationController>.Instance.GetText("player_triggered_event_duration"), this.eventInstance.Blueprint.EventDurationHours, "general_hour_short".ToLocalized()) + MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetDescription(this.eventInstance.Blueprint.LocKeys)));
			RefreshView();
		}

		public override void Hide()
		{
			base.Hide();
			eventInstance.EventInventoryChangedAction -= RefreshView;
			eventInstance = null;
		}

		private void RefreshView()
		{
			CheckIfCanStartEvent();
			RefreshAttendeeEntries();
			HandleResourceSettings();
			RefreshUniqueResourceEntries();
			HandleEventQualitySettings();
			additionalInfo.SetText(string.Empty);
			if (eventInstance.HasVisitorParticipant)
			{
				additionalInfo.SetText("* " + MonoSingleton<LocalizationController>.Instance.GetText("event_cooldown_visitor_participant"));
			}
		}

		private void RefreshAttendeeEntries()
		{
			Log.Info("Refreshing attendees", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\PlayerTriggeredEventView.cs");
			int num = 0;
			foreach (KeyValuePair<EventAttendeeType, HashSet<IEventParticipant>> item in eventInstance.AttendeesByType)
			{
				if (eventInstance.Blueprint.HasAttendeeType(item.Key))
				{
					GameObject prefab = ((item.Value.Count > 1) ? participantsManyPrefab : participantsFewPrefab);
					List<IEventParticipant> eligibleParticipants;
					bool eligibleAttendees = PlayerTriggeredEventUtils.GetEligibleAttendees(eventInstance, item.Key, out eligibleParticipants);
					participantGroupViews.GetAt(prefab, leftPanelParent.transform, num).SetData(item, eligibleAttendees, OnEditAttendeeList, AddRemoveAttendee);
					num++;
				}
			}
			participantGroupViews.SetActiveFromIndex(num, active: false);
		}

		private void AddRemoveAttendee(IEventParticipant participant, EventAttendeeType attendeeType, bool add)
		{
			eventInstance.AddRemoveParticipant(participant, attendeeType, add);
		}

		private void OnEditAttendeeList(EventAttendeeType attendeeType)
		{
			participantListPopupView.ShowAttendeeList(eventInstance, attendeeType, AddRemoveAttendee);
		}

		private void RefreshUniqueResourceEntries()
		{
			if (eventInstance.Blueprint.UniqueResourceSettings == null || eventInstance.Blueprint.UniqueResourceSettings.Length == 0)
			{
				uniqueResourceGroupViews.SetActiveFromIndex(0, active: false);
				return;
			}
			int num = 0;
			ResourceSetting[] uniqueResourceSettings = eventInstance.Blueprint.UniqueResourceSettings;
			foreach (ResourceSetting resourceSetting in uniqueResourceSettings)
			{
				PlayerEventUniqueResourceGroupView at = uniqueResourceGroupViews.GetAt(uniqueResourceGroupPrefab, leftPanelParent.transform, num);
				at.SetTitle(LocKeyUtils.GetName(resourceSetting.LocKeys).ToLocalized());
				Resource value = eventInstance.UniqueResourceGroups[resourceSetting.GetID()];
				at.SetData(hasResources: PlayerTriggeredEventUtils.GetEligibleUniqueResources(resourceSetting, out var _), groupResourcePair: new KeyValuePair<string, Resource>(resourceSetting.GetID(), value), addNewCallback: OnEditUniqueResourceList, addRemoveCallback: AddRemoveUniqueResource);
				num++;
			}
			uniqueResourceGroupViews.SetActiveFromIndex(num, active: false);
		}

		private void AddRemoveUniqueResource(KeyValuePair<string, Resource> groupResourcePair, bool add)
		{
			eventInstance.AddRemoveUniqueResource(groupResourcePair.Key, groupResourcePair.Value, add);
		}

		private void OnEditUniqueResourceList(string groupId)
		{
			uniqueResourceListPopupView.ShowResourceList(eventInstance, groupId, AddRemoveUniqueResource);
		}

		private void HandleResourceSettings()
		{
			resourceSettingsViews.SetActiveFromIndex(0, active: false);
			if (eventInstance.Blueprint.ResourceSettings == null || eventInstance.Blueprint.ResourceSettings.Length == 0)
			{
				return;
			}
			foreach (KeyValuePair<string, List<PlayerEventResourceView>> resourceView in resourceViews)
			{
				resourceView.Value.SetActiveFromIndex(0, active: false);
			}
			int num = 0;
			ResourceSetting[] resourceSettings = eventInstance.Blueprint.ResourceSettings;
			foreach (ResourceSetting resourceSetting in resourceSettings)
			{
				PlayerEventResourceSettingsView at = resourceSettingsViews.GetAt(resourceSettingsViewPrefab, leftPanelParent.transform, num);
				num++;
				at.Title.SetText(UiUtils.Localize.GetText(LocKeyUtils.GetName(resourceSetting.LocKeys)));
				int num2 = 0;
				foreach (Resource item in Repository<ResourceRepository, Resource>.Instance.GetAllResourcesByResourceCategory(resourceSetting.ResourceCategory))
				{
					if (PlayerTriggeredEventUtils.ShouldAddResource(resourceSetting, item))
					{
						resourceViews.TryAdd(resourceSetting.GetID(), new List<PlayerEventResourceView>());
						PlayerEventResourceView at2 = resourceViews[resourceSetting.GetID()].GetAt(at.ListParent, num2);
						at2.SetData(item, eventInstance.SetEventResourceValue, eventInstance.AddToEventResource);
						at2.gameObject.SetActive(value: true);
						num2++;
					}
				}
				if (num2 > 0)
				{
					resourceViews[resourceSetting.GetID()].SetActiveFromIndex(num2, active: false);
				}
			}
			resourceSettingsViews.SetActiveFromIndex(num, active: false);
		}

		private void HandleEventQualitySettings()
		{
			sb.Clear();
			foreach (PlayerTriggeredEventInfo item in eventInstance.IterateEventQualityInfo())
			{
				sb.AppendLine($"{item.Label}<indent={indentFirst}%>{item.Status}</indent><indent={indentSecond}%>{item.Points}</indent>");
			}
			int eventQualitySum = eventInstance.GetEventQualitySum();
			sb.AppendLine(string.Format("<style=AltColor>{0}<indent={1}%>{2}</indent></style>", MonoSingleton<LocalizationController>.Instance.GetText("event_quality_points"), indentSecond, eventQualitySum));
			sb.AppendLine();
			eventQualityList.SetText(sb.ToString());
			estimatedEventQuality.SetText(MonoSingleton<LocalizationController>.Instance.GetText("estimated_event_quality") + ": " + eventInstance.GetEstimatedEventQuality());
		}

		private void CheckIfCanStartEvent()
		{
			acceptButton.interactable = eventInstance.CanStart();
		}

		private void Awake()
		{
			MainView = content;
			acceptButton.onClick.AddListener(OnAccept);
			SoundButton[] array = closeButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].onClick.AddListener(OnClose);
			}
		}

		private void OnAccept()
		{
			MonoSingleton<PlayerTriggeredEventManager>.Instance.RunEvent();
			Hide();
		}

		private void OnClose()
		{
			MonoSingleton<PlayerTriggeredEventManager>.Instance.CancelEventPrep();
			Hide();
		}
	}
}
