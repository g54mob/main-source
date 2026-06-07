using FixMath;

namespace Server
{
	public interface ISimulationObserver
	{
		void OnModelAdded(ISimulation simulation, IModel model, Fix64 timestamp);

		void OnModelRemoved(ISimulation simulation, IModel model, Fix64 timestamp);
	}
}
