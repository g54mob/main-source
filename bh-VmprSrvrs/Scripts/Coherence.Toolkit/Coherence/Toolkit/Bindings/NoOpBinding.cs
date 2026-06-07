using Coherence.SimulationFrame;

namespace Coherence.Toolkit.Bindings
{
	public class NoOpBinding : Binding
	{
		public override string CoherenceComponentName { get; }

		public NoOpBinding(string coherenceComponentName)
		{
		}

		public override void IsDirty(AbsoluteSimulationFrame simulationFrame, out bool dirty, out bool justStopped)
		{
			dirty = default(bool);
			justStopped = default(bool);
		}

		public override void MarkAsReadyToSend()
		{
		}

		internal override bool Activate()
		{
			return false;
		}
	}
}
