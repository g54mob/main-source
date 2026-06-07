using DV.Simulation.Cars;
using LocoSim.Definitions;
using LocoSim.Implementations.Test;

namespace LocoSim.DVExtensions.Test
{
	public class SimDataDisplaySimController : SimDataDisplayBase
	{
		public SimController simController;

		public override SimConnectionDefinition SimDef => simController.connectionsDefinition;

		protected override void InitializeSimulation()
		{
			simFlow = simController.simFlow;
		}
	}
}
