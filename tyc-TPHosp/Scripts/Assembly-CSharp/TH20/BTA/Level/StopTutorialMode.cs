using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTA.Level
{
	[TaskCategory(" TH20/Level Script/Objectives")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/TutorialIcon.png")]
	public class StopTutorialMode : ExpiringLevelAction
	{
		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			base.Owner.Level.TutorialManager.SetTutorialMode(null);
			return TaskStatus.Success;
		}
	}
}
