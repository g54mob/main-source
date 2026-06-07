using ParticleEffects;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	public class DroppedBottleShatter : MonoBehaviour
	{
		[SerializeField]
		private ParticleEffectManager.ParticleType shatterParticle;

		private bool hasShattered;

		private void OnCollisionEnter(Collision collision)
		{
		}
	}
}
