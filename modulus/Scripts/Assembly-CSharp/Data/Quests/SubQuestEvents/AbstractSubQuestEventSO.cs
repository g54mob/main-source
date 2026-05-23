using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	public abstract class AbstractSubQuestEventSO : ScriptableObject
	{
		public abstract void Execute();
	}
}
