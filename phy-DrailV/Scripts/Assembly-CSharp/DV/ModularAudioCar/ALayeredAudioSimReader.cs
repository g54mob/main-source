using LocoSim.Implementations;
using UnityEngine;

namespace DV.ModularAudioCar
{
	public abstract class ALayeredAudioSimReader : MonoBehaviour
	{
		public abstract void Init(TrainCar car, SimulationFlow simFlow);

		public abstract void Deinit();
	}
}
