using System;
using System.Collections.Generic;
using NSEipix;
using NSMedieval.PlayerTriggeredEventSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.UI.ScenarioEditor
{
	public class EventParticipantListPopupView : CharacterEditPopupView
	{
		[FormerlySerializedAs("workersGroup")]
		[SerializeField]
		private LayoutGroupView participantsGroup;

		private readonly List<EventParticipantEntry> participantEntryViews = new List<EventParticipantEntry>();

		private HashSet<IEventParticipant> alreadySelectedParticipants = new HashSet<IEventParticipant>();

		private List<IEventParticipant> eligibleParticipants = new List<IEventParticipant>();

		private Action<IEventParticipant, EventAttendeeType, bool> cachedCallback;

		private PlayerTriggeredEventInstance eventInstance;

		private EventAttendeeType type;

		public void ShowAttendeeList(PlayerTriggeredEventInstance eventInstance, EventAttendeeType type, Action<IEventParticipant, EventAttendeeType, bool> addRemoveCallback)
		{
			cachedCallback = addRemoveCallback;
			this.type = type;
			this.eventInstance = eventInstance;
			popupTitle.SetText(PlayerTriggeredEventUtils.GetAttendeeGroupTitle(this.type));
			PlayerTriggeredEventUtils.GetEligibleAttendees(eventInstance, type, out var list);
			alreadySelectedParticipants = this.eventInstance.AttendeesByType[type];
			eligibleParticipants = list;
			RefreshView();
		}

		private void AddRemoveCallback(IEventParticipant eventParticipant, bool selected)
		{
			cachedCallback(eventParticipant, type, selected);
			RefreshView();
		}

		private void RefreshView()
		{
			Show();
			int num = 0;
			foreach (IEventParticipant eligibleParticipant in eligibleParticipants)
			{
				EventParticipantEntry at = participantEntryViews.GetAt(participantsGroup, num);
				bool selected = alreadySelectedParticipants.Contains(eligibleParticipant);
				bool locked = eventInstance.LockedInUI(eligibleParticipant);
				at.SetData(eligibleParticipant, selected, locked, AddRemoveCallback);
				at.SetBackground(num % 2 == 0);
				num++;
			}
			participantEntryViews.SetActiveFromIndex(num, active: false);
		}
	}
}
