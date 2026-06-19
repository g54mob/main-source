namespace Aggro.Core
{
	[NoAutoCreation]
	internal sealed class EntityBehaviourPresentationLateSystem : EntityBehaviourSystemBase
	{
		public override string systemName => base.behaviourType.Name + " OnUpdatePresentationLate";

		protected override string GetProfilerMarkerLabel()
		{
			return $"EntityBehaviourPresentationLateSystem.OnUpdateSystem ({base.behaviourType})";
		}

		protected override void OnUpdateBehaviour(IEntityBehaviourBase behaviour)
		{
			behaviour.UpdatePresentationLate();
		}
	}
}
