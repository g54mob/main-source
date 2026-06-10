using System;
using NSEipix.View.UI;
using NSMedieval.PlayerTriggeredEventSystem;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class PlayerEventParticipantEntryView : LayoutGroupItemView
	{
		private readonly int iconIndex;

		private readonly int removeButtonIndex = 1;

		public void SetData(IEventParticipant participant, EventAttendeeType type, Action<IEventParticipant, EventAttendeeType, bool> removeCallback)
		{
			Image component = base.GroupItems[iconIndex].GetComponent<Image>();
			if (!(component == null))
			{
				component.sprite = participant.GetSprite();
				base.GroupItems[removeButtonIndex].GetComponent<SoundButton>().AddCleanListener(delegate
				{
					removeCallback(participant, type, arg3: false);
				});
				if (base.TooltipNew is EventParticipantTooltipView eventParticipantTooltipView)
				{
					eventParticipantTooltipView.SetData(participant);
				}
			}
		}
	}
}
