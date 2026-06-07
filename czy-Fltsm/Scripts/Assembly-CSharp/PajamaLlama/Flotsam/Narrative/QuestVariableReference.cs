using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class QuestVariableReference
	{
		[SerializeField]
		private QuestProperties _questProperties;

		[SerializeField]
		private int _variableId;

		public T GetValue<T>(Quest quest = null) where T : class
		{
			if (TryGetValue<T>(out var value))
			{
				return value;
			}
			return null;
		}

		public bool TryGetValue<T>(out T value, Quest quest = null) where T : class
		{
			if (quest == null)
			{
				using (ListPool<Quest>.List list = ListPool<Quest>.Get())
				{
					foreach (Quest activeQuest in GameManager.StoryManager.ActiveQuests)
					{
						if (activeQuest.Properties == _questProperties)
						{
							list.Add(activeQuest);
						}
					}
					if (list.Count == 0)
					{
						Debug.LogException(new ArgumentException($"Unable to get quest variable value; No active quest found with quest properties '{_questProperties}'"));
					}
					else
					{
						if (1 >= list.Count)
						{
							return list[0].TryGetVariableValue<T>(_variableId, out value);
						}
						Debug.LogException(new ArgumentException($"Unable to get quest variable value; Multiple active quests found with quest properties '{_questProperties}'"));
					}
					value = null;
					return false;
				}
			}
			return quest.TryGetVariableValue<T>(_variableId, out value);
		}
	}
}
