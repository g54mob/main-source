namespace Aggro.Core
{
	[NoAutoCreation]
	internal sealed class EntityBehaviourSimulationLateSystem : EntityBehaviourSystemBase
	{
		public override string systemName => base.behaviourType.Name + " OnUpdateSimulationLate";

		protected override string GetProfilerMarkerLabel()
		{
			return $"EntityBehaviourSimulationLateSystem.OnUpdateSystem ({base.behaviourType})";
		}

		protected override void OnUpdateBehaviour(IEntityBehaviourBase behaviour)
		{
			behaviour.UpdateSimulationLate();
		}
	}
}
