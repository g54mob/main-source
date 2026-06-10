using System;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.State;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class EventParticipantEntry : LayoutGroupItemView
	{
		[SerializeField]
		private Image icon;

		[SerializeField]
		private TMP_Text nameLabel;

		[SerializeField]
		private Toggle selectParticipantToggle;

		[SerializeField]
		private EventParticipantTooltipView iconTooltip;

		[SerializeField]
		private GameObject background;

		private Color iconDefaultColor = Color.white;

		public void SetData(IEventParticipant eventParticipant, bool selected, bool locked, Action<IEventParticipant, bool> addRemoveCallback)
		{
			nameLabel.alpha = (locked ? 0.5f : 1f);
			nameLabel.SetText(((CreatureBase)eventParticipant).GetFullName());
			iconDefaultColor.a = (locked ? 0.5f : 1f);
			icon.color = iconDefaultColor;
			icon.sprite = eventParticipant.GetSprite();
			iconTooltip.SetData(eventParticipant, locked);
			selectParticipantToggle.interactable = true;
			selectParticipantToggle.SetIsOnWithoutNotify(selected);
			selectParticipantToggle.onValueChanged.RemoveAllListeners();
			selectParticipantToggle.onValueChanged.AddListener(delegate(bool value)
			{
				addRemoveCallback(eventParticipant, value);
			});
			if (locked)
			{
				selectParticipantToggle.SetIsOnWithoutNotify(value: false);
				selectParticipantToggle.interactable = false;
			}
		}

		public void SetBackground(bool selected)
		{
			background.SetActive(selected);
		}
	}
}
