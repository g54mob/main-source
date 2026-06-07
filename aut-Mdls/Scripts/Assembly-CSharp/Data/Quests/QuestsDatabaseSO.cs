using System;
using System.Collections.Generic;
using System.Linq;
using Data.Quests.Validators;
using UnityEngine;

namespace Data.Quests
{
	[CreateAssetMenu(menuName = "Quests/QuestsDatabase", fileName = "QuestsDatabase", order = 0)]
	public class QuestsDatabaseSO : ScriptableObject
	{
		[SerializeField]
		private List<SkippableQuest> _quests;

		public QuestSO this[int i] => _quests.Where((SkippableQuest q) => !q.Skip).ElementAt(i).Quest;

		public int Count => _quests.Count((SkippableQuest q) => !q.Skip);

		public IEnumerable<AbstractSubQuestValidatorSO> AllOrderedValidators => _quests.SelectMany((SkippableQuest q) => (!q.Skip) ? q.Quest.OrderedSubQuests?.Select((SubQuestSO sq) => sq.Validator) : Array.Empty<AbstractSubQuestValidatorSO>());

		public IEnumerable<AbstractSubQuestValidatorSO> AllNonOrderedValidators => _quests.SelectMany((SkippableQuest q) => (!q.Skip) ? q.Quest.NonOrderedSubQuests?.Select((SubQuestSO sq) => sq.Validator) : Array.Empty<AbstractSubQuestValidatorSO>());
	}
}
