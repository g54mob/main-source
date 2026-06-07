using DV.Items;
using UnityEngine;

namespace DV.VFX
{
	public class ItemParticleSimulationSpace : MonoBehaviour
	{
		public ParticleSystem particleSystem;

		private void Start()
		{
			GetComponent<ItemSimulationSpace>().SimulationSpaceChanged += delegate(Transform _, Transform parent)
			{
				ParticleSystem.MainModule main = particleSystem.main;
				main.simulationSpace = ParticleSystemSimulationSpace.Custom;
				main.customSimulationSpace = ((parent != null) ? parent : WorldMover.OriginShiftParent);
			};
		}
	}
}
