using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	public class QuestTrackerButtonsManager : MonoBehaviour
	{
		[SerializeField]
		private QuestTrackerButton _mainQuestButton;

		[SerializeField]
		private QuestTrackerButton _secondaryQuestButton;

		[SerializeField]
		private List<QuestTrackerButton> _circumstantialButtons = new List<QuestTrackerButton>();

		private Dictionary<Quest, QuestTrackerButton> _usedCircumstantialButtons = new Dictionary<Quest, QuestTrackerButton>();

		private List<Quest> _trackedQuests = new List<Quest>();

		private void Awake()
		{
			_circumstantialButtons.AddRange(GetComponentsInChildren<QuestTrackerButton>());
			foreach (QuestTrackerButton circumstantialButton in _circumstantialButtons)
			{
				circumstantialButton.gameObject.SetActive(value: false);
			}
		}

		private void OnDisable()
		{
			QuestTrackerManager.TrackingQuest -= OnTrackingQuest;
			QuestTrackerManager.UntrackingQuest -= OnUntrackingQuest;
		}

		private void OnEnable()
		{
			QuestTrackerManager.TrackingQuest += OnTrackingQuest;
			QuestTrackerManager.UntrackingQuest += OnUntrackingQuest;
		}

		private void OnUntrackingQuest(Quest quest)
		{
			_trackedQuests.Remove(quest);
			switch (quest.QuestType)
			{
			case Quest.EQuestType.Main:
				UntrackMainQuest();
				break;
			case Quest.EQuestType.Secondary:
				UntrackSecondaryQuest();
				break;
			case Quest.EQuestType.Circumstantial:
				UntrackCircumstantialQuest(quest);
				break;
			}
		}

		private void UntrackMainQuest()
		{
			_mainQuestButton.AssignQuest(null);
		}

		private void UntrackSecondaryQuest()
		{
			_secondaryQuestButton.AssignQuest(null);
		}

		private void UntrackCircumstantialQuest(Quest quest)
		{
			if (_usedCircumstantialButtons.ContainsKey(quest))
			{
				_usedCircumstantialButtons[quest].AssignQuest(null);
				_circumstantialButtons.Add(_usedCircumstantialButtons[quest]);
				_usedCircumstantialButtons.Remove(quest);
			}
		}

		public void OnTrackingQuest(Quest quest)
		{
			switch (quest.QuestType)
			{
			case Quest.EQuestType.Main:
				TrackMainQuest(quest);
				break;
			case Quest.EQuestType.Secondary:
				TrackSecondaryQuest(quest);
				break;
			case Quest.EQuestType.Circumstantial:
				TrackCircumstantialQuest(quest);
				break;
			}
		}

		private void TrackMainQuest(Quest quest)
		{
			if (!_mainQuestButton.AsQuestAssigned)
			{
				_mainQuestButton.AssignQuest(quest);
				_mainQuestButton.OnButtonClicked();
			}
		}

		private void TrackSecondaryQuest(Quest quest)
		{
			if (!_secondaryQuestButton.AsQuestAssigned)
			{
				_secondaryQuestButton.AssignQuest(quest);
				_secondaryQuestButton.OnButtonClicked();
			}
		}

		private void TrackCircumstantialQuest(Quest quest)
		{
			if (_circumstantialButtons.Count != 0 && !_usedCircumstantialButtons.ContainsKey(quest))
			{
				if (!_trackedQuests.Contains(quest))
				{
					_trackedQuests.Add(quest);
				}
				QuestTrackerButton questTrackerButton = _circumstantialButtons[0];
				_circumstantialButtons.RemoveAt(0);
				_usedCircumstantialButtons.Add(quest, questTrackerButton);
				questTrackerButton.AssignQuest(quest);
				if (_usedCircumstantialButtons.Count == 1)
				{
					questTrackerButton.OnButtonClicked();
				}
			}
		}

		public void ResetButtons()
		{
			_mainQuestButton.AssignQuest(null);
			_secondaryQuestButton.AssignQuest(null);
			foreach (KeyValuePair<Quest, QuestTrackerButton> usedCircumstantialButton in _usedCircumstantialButtons)
			{
				usedCircumstantialButton.Value.AssignQuest(null);
				_circumstantialButtons.Add(usedCircumstantialButton.Value);
			}
			_usedCircumstantialButtons.Clear();
		}
	}
}
