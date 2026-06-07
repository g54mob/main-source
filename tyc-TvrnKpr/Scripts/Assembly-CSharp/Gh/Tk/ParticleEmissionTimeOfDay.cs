using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(ParticleSystem))]
	public class ParticleEmissionTimeOfDay : MonoBehaviour
	{
		public AnimationCurve dayTimeCurve;

		public int maxRate;

		private ParticleSystem.EmissionModule _emissionModule;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
