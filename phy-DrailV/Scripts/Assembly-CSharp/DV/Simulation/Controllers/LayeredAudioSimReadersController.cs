using DV.ModularAudioCar;
using LocoSim.Implementations;

namespace DV.Simulation.Controllers
{
	public class LayeredAudioSimReadersController : ARefreshableChildrenController<ALayeredAudioSimReader>
	{
		public void Init(TrainCar car, SimulationFlow simFlow)
		{
			ALayeredAudioSimReader[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Init(car, simFlow);
			}
		}

		public void Deinit()
		{
			ALayeredAudioSimReader[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Deinit();
			}
		}
	}
}
