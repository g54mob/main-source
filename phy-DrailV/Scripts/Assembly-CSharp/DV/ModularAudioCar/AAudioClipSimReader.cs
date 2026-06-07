using LocoSim.Implementations;
using UnityEngine;

namespace DV.ModularAudioCar
{
	public abstract class AAudioClipSimReader : MonoBehaviour
	{
		public abstract void Init(TrainCar car, SimulationFlow simFlow);

		public abstract void Deinit();
	}
}
