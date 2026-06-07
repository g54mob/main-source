using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public abstract class AParticlePortReader : MonoBehaviour
	{
		public abstract void Init(SimulationFlow simFlow);

		public abstract void Deinit();
	}
}
