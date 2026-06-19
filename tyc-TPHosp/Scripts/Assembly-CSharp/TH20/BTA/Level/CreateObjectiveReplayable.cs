using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA.Level
{
	[TaskCategory(" TH20/Level Script/Objectives")]
	[TaskName("Discover Online Challenge")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/ObjectiveIconUnlock.png")]
	public class CreateObjectiveReplayable : ExpiringLevelAction
	{
		[UsedImplicitly]
		public SharedInstance_TH20TH20_ObjectiveDefinition Objective;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			base.Owner.Level.LevelScriptManager.CreateObjective(string.Empty, Objective.Instance, isVisible: true, isDiscovered: false, isReplayable: true, startImmediately: false);
			return TaskStatus.Success;
		}
	}
}
