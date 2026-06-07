using LocoSim.Implementations;

namespace DV.Simulation.Controllers
{
	public class EnvironmentDamageController : ARefreshableChildrenController<EnvironmentDamager>
	{
		public void Init(SimulationFlow simFlow)
		{
			EnvironmentDamager[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Init(simFlow);
			}
		}
	}
}
