using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace TH20
{
	[AddComponentMenu("TH20/Level Behavior Tree")]
	public class LevelScriptBehaviorTree : BehaviorTree
	{
		public Level Level { get; set; }

		public LevelScriptManager Manager { get; set; }

		public void LogExpiredTask(Task task)
		{
			Manager.AddExpiredTask(task.ID);
		}

		public bool HasTaskExpired(Task task)
		{
			return Manager.HasTaskExpired(task.ID);
		}
	}
}
