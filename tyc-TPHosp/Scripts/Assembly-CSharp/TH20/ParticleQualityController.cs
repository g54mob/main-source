using UnityEngine;

namespace TH20
{
	[RequireComponent(typeof(ParticleSystem))]
	public class ParticleQualityController : MonoBehaviour
	{
		public ParticleSystem ParticleSystem;

		private void Reset()
		{
			ParticleSystem = GetComponent<ParticleSystem>();
		}
	}
}
