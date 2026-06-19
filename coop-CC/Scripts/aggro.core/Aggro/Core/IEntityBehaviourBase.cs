namespace Aggro.Core
{
	public interface IEntityBehaviourBase : IEntityTyped
	{
		internal int typeIndex { get; set; }

		internal int behaviourIndex { get; set; }

		internal Entity entity { get; set; }

		internal void Initialize();

		internal void InitializeLate();

		internal void Created();

		internal void StartedRunning();

		internal void Destroyed();

		internal void UpdateSimulation();

		internal void UpdateSimulationEarly();

		internal void UpdateSimulationLate();

		internal void UpdatePresentation();

		internal void UpdatePresentationEarly();

		internal void UpdatePresentationLate();
	}
}
