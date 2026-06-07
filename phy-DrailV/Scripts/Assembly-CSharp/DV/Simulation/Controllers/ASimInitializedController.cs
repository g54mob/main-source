using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public abstract class ASimInitializedController : MonoBehaviour
	{
		public virtual bool ExternalTick => false;

		public abstract void Init(TrainCar car, SimulationFlow simFlow);

		public virtual void Tick(float deltaTime)
		{
		}
	}
}
