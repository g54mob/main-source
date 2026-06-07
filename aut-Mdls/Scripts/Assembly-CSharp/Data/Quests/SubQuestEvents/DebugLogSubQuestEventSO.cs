#define ENABLE_DEBUG_LOGS
using UnityEngine;
using Utils;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Debug Log", fileName = "DebugLog", order = 3)]
	public class DebugLogSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private string _log;

		public override void Execute()
		{
			this.Log(base.name + ": " + _log, "Execute", 13);
		}
	}
}
