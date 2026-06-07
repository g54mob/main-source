using UnityEngine;

namespace Placemaker
{
	public class ClickParticleSound : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private ParticleSystem particles;

		[SerializeField]
		private float lowestSpeed;

		private const float volumeModifier = 0.1f;

		public void OnParticleCollision(GameObject other)
		{
		}

		private void OnParticleTrigger()
		{
		}
	}
}
