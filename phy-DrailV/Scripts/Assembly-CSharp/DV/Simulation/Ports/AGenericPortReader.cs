using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Ports
{
	public abstract class AGenericPortReader : MonoBehaviour
	{
		public virtual bool ExternalTickCall => false;

		public abstract void Init(TrainCar car, SimulationFlow simFlow);

		public abstract void Deinit();

		public virtual void Tick()
		{
		}
	}
}
