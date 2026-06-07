using DV.Utils;
using UnityEngine;

namespace DV.VFX
{
	public class WorldMoverParticleSimulationSpace : MonoBehaviour
	{
		private void Awake()
		{
			if ((bool)SingletonBehaviour<WorldMover>.Instance)
			{
				ParticleSystem.MainModule main = GetComponent<ParticleSystem>().main;
				main.simulationSpace = ParticleSystemSimulationSpace.Custom;
				main.customSimulationSpace = WorldMover.OriginShiftParent;
			}
			Object.Destroy(this);
		}
	}
}
