using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace TH20.BTA.Level
{
	[TaskCategory(" TH20/Level Script/Objectives")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/TutorialIcon.png")]
	public class CircleActiveSubgoal : ExpiringLevelAction
	{
		[SerializeField]
		private float _duration;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			GeneralNotificationMenu generalNotificationMenu = base.Owner.Level.HUD.FindMenu<GeneralNotificationMenu>(includeInactive: false);
			if (generalNotificationMenu != null)
			{
				generalNotificationMenu.ShowLevelObjectiveTutorial(_duration);
			}
			return TaskStatus.Success;
		}
	}
}
