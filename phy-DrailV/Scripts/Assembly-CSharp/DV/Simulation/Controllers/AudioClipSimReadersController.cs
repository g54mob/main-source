using DV.ModularAudioCar;
using LocoSim.Implementations;

namespace DV.Simulation.Controllers
{
	public class AudioClipSimReadersController : ARefreshableChildrenController<AAudioClipSimReader>
	{
		public void Init(TrainCar car, SimulationFlow simFlow)
		{
			AAudioClipSimReader[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Init(car, simFlow);
			}
		}

		public void Deinit()
		{
			AAudioClipSimReader[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Deinit();
			}
		}
	}
}
