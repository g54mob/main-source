namespace Aggro.Core
{
	[NoAutoCreation]
	internal sealed class EntityBehaviourSimulationEarlySystem : EntityBehaviourSystemBase
	{
		public override string systemName => base.behaviourType.Name + " OnUpdateSimulationEarly";

		protected override string GetProfilerMarkerLabel()
		{
			return $"EntityBehaviourSimulationEarlySystem.OnUpdateSystem ({base.behaviourType})";
		}

		protected override void OnUpdateBehaviour(IEntityBehaviourBase behaviour)
		{
			behaviour.UpdateSimulationEarly();
		}
	}
}
