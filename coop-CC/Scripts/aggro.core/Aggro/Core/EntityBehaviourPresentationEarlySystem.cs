namespace Aggro.Core
{
	[NoAutoCreation]
	internal sealed class EntityBehaviourPresentationEarlySystem : EntityBehaviourSystemBase
	{
		public override string systemName => base.behaviourType.Name + " OnUpdatePresentationEarly";

		protected override string GetProfilerMarkerLabel()
		{
			return $"EntityBehaviourPresentationEarlySystem.OnUpdateSystem ({base.behaviourType})";
		}

		protected override void OnUpdateBehaviour(IEntityBehaviourBase behaviour)
		{
			behaviour.UpdatePresentationEarly();
		}
	}
}
