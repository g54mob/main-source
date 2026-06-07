using UnityEngine;

namespace Gh.Tk
{
	public class PatronAttractionGauges : MonoBehaviour
	{
		public Transform timeFill;

		public Transform timeParticlesTopTrans;

		public ParticleSystem timeParticlesTop;

		public ParticleSystem timeParticlesFill;

		public ParticleSystem timeParticlesEvap;

		public Transform accuracyFill;

		public Transform accuracyParticlesTopTrans;

		public ParticleSystem accuracyParticlesTop;

		public ParticleSystem accuracyParticlesFill;

		public ParticleSystem accuracyParticlesEvap;

		public float timeValue;

		public float accuracyValue;

		private void Update()
		{
		}

		private void ParticleEnabler(ParticleSystem ps, float val)
		{
		}
	}
}
