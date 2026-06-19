using BehaviorDesigner.Runtime.Tasks;
using FullInspector;
using UnityEngine;

namespace TH20.BTA.Level
{
	[TaskCategory(" TH20/Level Script/Objectives")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/TutorialIcon.png")]
	public class StartTutorialMode : ExpiringLevelAction
	{
		[SerializeField]
		private SharedInstance<TutorialModeDefinition> _definition;

		public override TaskStatus OnUpdate()
		{
			if (_definition == null || _definition.Instance == null)
			{
				return TaskStatus.Success;
			}
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			base.Owner.Level.TutorialManager.SetTutorialMode(_definition.Instance);
			return TaskStatus.Success;
		}
	}
}
