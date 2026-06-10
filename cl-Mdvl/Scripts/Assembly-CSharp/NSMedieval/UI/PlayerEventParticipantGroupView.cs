using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.PlayerTriggeredEventSystem;

namespace NSMedieval.UI
{
	public class PlayerEventParticipantGroupView : PlayerEventLimitedItemGroup
	{
		private readonly List<PlayerEventParticipantEntryView> participantEntryViews = new List<PlayerEventParticipantEntryView>();

		public void SetData(KeyValuePair<EventAttendeeType, HashSet<IEventParticipant>> typeList, bool hasAttendees, Action<EventAttendeeType> addNewCallback, Action<IEventParticipant, EventAttendeeType, bool> addRemoveCallback)
		{
			SetTitle(PlayerTriggeredEventUtils.GetAttendeeGroupTitle(typeList.Key));
			addNewButton.onNonInteractableClick.RemoveAllListeners();
			addNewButton.GetComponent<LocalizedTextTooltipView>().SetTooltipKey(MonoSingleton<LocalizationController>.Instance.GetText("general_add_participant") ?? "");
			int num = 0;
			foreach (IEventParticipant item in typeList.Value)
			{
				participantEntryViews.GetAt(itemGroupView, num).SetData(item, typeList.Key, addRemoveCallback);
				num++;
			}
			if (!hasAttendees)
			{
				addNewButton.interactable = false;
				addNewButton.onNonInteractableClick.AddListener(delegate
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("no_" + typeList.Key.ToString().ToLower() + "_message"));
				});
			}
			else
			{
				addNewButton.interactable = true;
				addNewButton.AddCleanListener(delegate
				{
					addNewCallback(typeList.Key);
				});
			}
			participantEntryViews.SetActiveFromIndex(num, active: false);
			addNewButton.transform.SetSiblingIndex(num);
		}
	}
}
