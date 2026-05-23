#define ENABLE_DEBUG_WARNINGS
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Data.Quests
{
	[CreateAssetMenu(menuName = "Quests/Quest", fileName = "Quest", order = 1)]
	public class QuestSO : ScriptableObject
	{
		[LocaKey]
		[SerializeField]
		private string _questNameKey;

		[SerializeField]
		private List<SubQuestSO> _orderedSubQuests = new List<SubQuestSO>();

		[SerializeField]
		private List<SubQuestSO> _nonOrderedSubQuests = new List<SubQuestSO>();

		public List<SubQuestSO> OrderedSubQuests => _orderedSubQuests;

		public List<SubQuestSO> NonOrderedSubQuests => _nonOrderedSubQuests;

		public string QuestName
		{
			get
			{
				if (!string.IsNullOrEmpty(_questNameKey))
				{
					return LocalizationUtility.GetLocalizedText(_questNameKey);
				}
				return "";
			}
		}

		private void Reset()
		{
			for (int i = 0; i < _orderedSubQuests.Count; i++)
			{
				if (_orderedSubQuests[i] == null)
				{
					this.LogWarning($"Ordered Subquest cannot be null in {base.name} at {i}", "Reset", 27);
				}
			}
			for (int j = 0; j < _nonOrderedSubQuests.Count; j++)
			{
				if (_nonOrderedSubQuests[j] == null)
				{
					this.LogWarning($"Nonordered Subquest cannot be null in {base.name} at {j}", "Reset", 33);
				}
			}
		}
	}
}
