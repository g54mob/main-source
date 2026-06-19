namespace Aggro.Core
{
	[NoAutoCreation]
	internal sealed class EntityBehaviourPresentationSystem : EntityBehaviourSystemBase
	{
		public override string systemName => base.behaviourType.Name + " OnUpdatePresentation";

		protected override string GetProfilerMarkerLabel()
		{
			return $"EntityBehaviourPresentationSystem.OnUpdateSystem ({base.behaviourType})";
		}

		protected override void OnUpdateBehaviour(IEntityBehaviourBase behaviour)
		{
			behaviour.UpdatePresentation();
		}
	}
}
