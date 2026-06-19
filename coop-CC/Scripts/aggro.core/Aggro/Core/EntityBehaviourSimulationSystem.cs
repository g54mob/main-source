namespace Aggro.Core
{
	[NoAutoCreation]
	internal sealed class EntityBehaviourSimulationSystem : EntityBehaviourSystemBase
	{
		public override string systemName => base.behaviourType.Name + " OnUpdateSimulation";

		protected override string GetProfilerMarkerLabel()
		{
			return $"EntityBehaviourSimulationSystem.OnUpdateSystem ({base.behaviourType})";
		}

		protected override void OnUpdateBehaviour(IEntityBehaviourBase behaviour)
		{
			behaviour.UpdateSimulation();
		}
	}
}
