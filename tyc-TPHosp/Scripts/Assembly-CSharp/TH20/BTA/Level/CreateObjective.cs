using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA.Level
{
	[TaskCategory(" TH20/Level Script/Objectives")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/ObjectiveIconAdd.png")]
	public class CreateObjective : LevelAction
	{
		[UsedImplicitly]
		public bool WaitForCompletion = true;

		[UsedImplicitly]
		public SharedInstance_TH20TH20_ObjectiveDefinition Objective;

		[UsedImplicitly]
		public bool IsDiscovered;

		[UsedImplicitly]
		public bool IsReplayable;

		[UsedImplicitly]
		public bool StartImmediately = true;

		[UsedImplicitly]
		public string Name;

		private bool _objectiveExpired;

		public override void OnStart()
		{
			base.OnStart();
			_objectiveExpired = base.Owner.Level.LevelScriptManager.HasObjectiveExpired(Name, out var _);
			if (!_objectiveExpired)
			{
				base.Owner.Level.LevelScriptManager.CreateObjective(Name, Objective.Instance, isVisible: true, IsDiscovered, IsReplayable, StartImmediately);
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (!WaitForCompletion || _objectiveExpired)
			{
				return TaskStatus.Success;
			}
			_objectiveExpired = base.Owner.Level.LevelScriptManager.HasObjectiveExpired(Name, out var _);
			if (!_objectiveExpired)
			{
				return TaskStatus.Running;
			}
			return TaskStatus.Success;
		}
	}
}
