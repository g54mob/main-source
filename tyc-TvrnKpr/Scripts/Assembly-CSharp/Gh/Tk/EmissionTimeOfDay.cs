using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(ParticleSystem))]
	public class EmissionTimeOfDay : MonoBehaviour
	{
		public AnimationCurve dayTimeCurve;

		public float minRate;

		public float maxRate;

		private ParticleSystem ps;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
