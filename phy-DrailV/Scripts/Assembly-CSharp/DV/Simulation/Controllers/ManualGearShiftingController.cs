using LocoSim.Implementations;

namespace DV.Simulation.Controllers
{
	public class ManualGearShiftingController : ARefreshableChildrenController<GearShifter>
	{
		public bool AnyInNeutral
		{
			get
			{
				GearShifter[] array = entries;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].InNeutral)
					{
						return true;
					}
				}
				return false;
			}
		}

		public void Init(TrainCar car, SimulationFlow simFlow)
		{
			GearShifter[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Init(simFlow);
			}
		}
	}
}
