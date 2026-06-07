using UnityEngine;

namespace DV.VFX
{
	public class TunnelParticleDampening : MonoBehaviour
	{
		[Header("Particle systems will have their LimitVelocityOverLifetime.drag values overwritten.")]
		public ParticleSystem[] systems;

		public Bogie bogie;

		public float dampening = 8f;

		public float minHeight = 4f;

		public float maxHeight = 16f;

		private float lastDampen = -1f;

		private void Update()
		{
			float num = float.PositiveInfinity;
			if (bogie.track != null)
			{
				num = bogie.track.SampleCeilingHeight((float)bogie.traveller.Span);
			}
			num = (1f - Mathf.Clamp01((num - minHeight) / (maxHeight - minHeight))) * dampening;
			if (lastDampen != num)
			{
				lastDampen = num;
				ParticleSystem[] array = systems;
				for (int i = 0; i < array.Length; i++)
				{
					ParticleSystem.LimitVelocityOverLifetimeModule limitVelocityOverLifetime = array[i].limitVelocityOverLifetime;
					limitVelocityOverLifetime.drag = num;
				}
			}
		}
	}
}
