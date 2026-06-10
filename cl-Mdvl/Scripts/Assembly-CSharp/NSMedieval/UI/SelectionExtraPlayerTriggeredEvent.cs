using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Production;
using NSMedieval.RoomDetection;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	public class SelectionExtraPlayerTriggeredEvent : SelectionExtraWindowView
	{
		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private TMP_Text infoText;

		[SerializeField]
		private SoundButton planEventButton;

		[SerializeField]
		private SoundButton endEventButton;

		[SerializeField]
		private TMP_Text debugText;

		private InfoPanelPlayerTriggeredEvent eventInfo;

		private void OnEnable()
		{
			MonoSingleton<PlayerTriggeredEventManager>.Instance.EventDiscardedEvent += Refresh;
			MonoSingleton<PlayerTriggeredEventManager>.Instance.EventStartedEvent += SubscribeToEvent;
			debugText.gameObject.SetActive(value: false);
		}

		private void OnDisable()
		{
			if (MonoSingleton<PlayerTriggeredEventManager>.IsInstantiated())
			{
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventDiscardedEvent -= Refresh;
				MonoSingleton<PlayerTriggeredEventManager>.Instance.EventStartedEvent -= SubscribeToEvent;
			}
		}

		public void UpdatePanel(InfoPanelPlayerTriggeredEvent playerTriggeredEventInfo)
		{
			base.Show();
			eventInfo = playerTriggeredEventInfo;
			title.text = base.Localize.GetText(LocKeyUtils.GetName(eventInfo.PlayerTriggeredEvent.LocKeys));
			Refresh();
		}

		private void Refresh()
		{
			if (MonoSingleton<PlayerTriggeredEventManager>.Instance.IsAnotherEventRunning(eventInfo.PlayerTriggeredEvent.GetID()))
			{
				planEventButton.interactable = false;
				planEventButton.gameObject.SetActive(value: true);
				endEventButton.gameObject.SetActive(value: false);
				infoText.text = UiUtils.Localize.GetText("plan_event_disabled_other_event");
			}
			else if (MonoSingleton<PlayerTriggeredEventManager>.Instance.CanShowView(eventInfo.PlayerTriggeredEvent.GetID(), eventInfo.BaseBuildingInstance))
			{
				planEventButton.interactable = true;
				planEventButton.gameObject.SetActive(value: true);
				endEventButton.gameObject.SetActive(value: false);
				infoText.text = string.Empty;
			}
			else if (eventInfo.PlayerTriggeredEvent.RoomRequired && !IsInEventRoom() && !MonoSingleton<PlayerTriggeredEventManager>.Instance.IsEventRunning())
			{
				planEventButton.interactable = false;
				planEventButton.gameObject.SetActive(value: true);
				endEventButton.gameObject.SetActive(value: false);
				List<string> list = new List<string>();
				string[] roomTypeIds = eventInfo.PlayerTriggeredEvent.RoomTypeIds;
				foreach (string id in roomTypeIds)
				{
					list.Add(LocKeyUtils.GetName(Repository<RoomTypeRepository, RoomType>.Instance.GetByID(id).LocKeys));
				}
				infoText.text = UiUtils.Localize.GetText("plan_event_disabled").Replace("<room_name>", UiUtils.GetLocalizedAlmanacLinks(list));
			}
			else
			{
				planEventButton.gameObject.SetActive(value: false);
				endEventButton.gameObject.SetActive(value: true);
				infoText.text = string.Empty;
			}
		}

		private void UnsubscribeFromEvent(PlayerTriggeredEventInstance eventInstance)
		{
			eventInstance.StateChangedEvent -= OnEventStateChanged;
			Refresh();
		}

		private void SubscribeToEvent(PlayerTriggeredEventInstance eventInstance)
		{
			if (!eventInfo.PlayerTriggeredEvent.RoomRequired || IsInEventRoom())
			{
				eventInstance.StateChangedEvent += OnEventStateChanged;
				Refresh();
			}
		}

		private void OnEventStateChanged(EventState state)
		{
			if (state == EventState.Ended)
			{
				Refresh();
			}
		}

		public override void Initialize()
		{
			base.Initialize();
			planEventButton.AddCleanListener(OnPlanEventButtonClicked);
			endEventButton.AddCleanListener(OnEndEventButtonClicked);
			planEventButton.gameObject.SetActive(value: true);
		}

		private void OnEndEventButtonClicked()
		{
			if (MonoSingleton<PlayerTriggeredEventManager>.Instance.CanEndWithoutPenalty())
			{
				MonoSingleton<PlayerTriggeredEventManager>.Instance.OnEndEventClick();
				return;
			}
			List<KeyValuePair<string, Action>> list = new List<KeyValuePair<string, Action>>();
			list.Add(new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_yes"), MonoSingleton<PlayerTriggeredEventManager>.Instance.OnEndEventClick));
			list.Add(new KeyValuePair<string, Action>(MonoSingleton<LocalizationController>.Instance.GetText("general_no"), delegate
			{
			}));
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("end_event_confirm", list));
		}

		private void OnPlanEventButtonClicked()
		{
			MonoSingleton<PlayerTriggeredEventManager>.Instance.ShowView();
		}

		private bool IsInEventRoom()
		{
			return MonoSingleton<PlayerTriggeredEventManager>.Instance.IsInEventRoom(eventInfo.BaseBuildingInstance);
		}
	}
}
