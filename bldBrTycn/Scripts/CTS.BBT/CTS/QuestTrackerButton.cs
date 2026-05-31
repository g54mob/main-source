using System;
using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CTS
{
	public class QuestTrackerButton : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CTSButton _button;

		[SerializeField]
		private Image _image;

		private Quest _assignedQuest;

		public bool AsQuestAssigned => _assignedQuest;

		protected override void OnEnabled()
		{
			_button.onClick.AddListener(OnButtonClicked);
			_button.SelectionStateChanged += SelectionStateChanged;
			QuestTrackerManager.CurrentQuestChanged += OnCurrentQuestChanged;
		}

		protected override void OnDisabled()
		{
			QuestTrackerManager.CurrentQuestChanged -= OnCurrentQuestChanged;
			_button.SelectionStateChanged -= SelectionStateChanged;
			_button.onClick.RemoveListener(OnButtonClicked);
		}

		private void SelectionStateChanged(ESelectionState obj)
		{
			switch (obj)
			{
			case ESelectionState.Normal:
				_image.color = BBTPalette.GetColor(BBTPalette.ButtonContentNormalKey);
				break;
			case ESelectionState.Highlighted:
				_image.color = BBTPalette.GetColor(BBTPalette.ButtonContentHighlightedKey);
				break;
			case ESelectionState.Pressed:
			case ESelectionState.Selected:
				_image.color = BBTPalette.GetColor(BBTPalette.ButtonContentSelectedKey);
				break;
			case ESelectionState.Disabled:
				_image.color = BBTPalette.GetColor(BBTPalette.ButtonContentDisabledKey);
				break;
			default:
				throw new ArgumentOutOfRangeException("obj", obj, null);
			}
		}

		private void OnCurrentQuestChanged(Quest quest)
		{
			bool flag = quest == _assignedQuest;
			_button.interactable = !flag;
			Image image = _image;
			Color color3;
			if (!flag)
			{
				Color color = (_image.color = BBTPalette.GetColor(BBTPalette.ButtonContentNormalKey));
				color3 = color;
			}
			else
			{
				color3 = BBTPalette.GetColor(BBTPalette.ButtonContentSelectedKey);
			}
			image.color = color3;
			_button.image.overrideSprite = (flag ? _button.spriteState.selectedSprite : null);
		}

		public void OnButtonClicked()
		{
			QuestTrackerManager.SelectTrackedQuestToShow(_assignedQuest);
			EventSystem.current.SetSelectedGameObject(null);
		}

		public void AssignQuest(Quest quest)
		{
			base.gameObject.SetActive(quest);
			_assignedQuest = quest;
			_button.interactable = quest != null;
		}
	}
}
