using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTA.Level
{
	[TaskCategory(" TH20/Level Script/Objectives")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/TutorialIcon.png")]
	public class CancelCircleActiveSubgoal : ExpiringLevelAction
	{
		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			GeneralNotificationMenu generalNotificationMenu = base.Owner.Level.HUD.FindMenu<GeneralNotificationMenu>(includeInactive: false);
			if (generalNotificationMenu != null)
			{
				generalNotificationMenu.ShowLevelObjectiveTutorial(0f);
			}
			return TaskStatus.Success;
		}
	}
}
