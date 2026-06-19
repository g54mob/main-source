using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Level Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/ObjectiveIconUnlock.png")]
	public class UnlockPersistentObjective : LevelAction
	{
		[UsedImplicitly]
		public SharedInstance_TH20TH20_ObjectiveDefinition _objectiveToUnlock;

		public override TaskStatus OnUpdate()
		{
			return TaskStatus.Success;
		}
	}
}
