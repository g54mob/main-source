using UnityEngine;

namespace AllIn1VfxToolkit
{
	[CreateAssetMenu(fileName = "All1VfxParticleHelperTemplate", menuName = "AllIn1Vfx/ParticleHelperTemplate")]
	public class AllIn1ParticleHelperSO : ScriptableObject
	{
		public bool matchDurationToLifetime;

		public bool randomRotation;

		public float minLifetime = 5f;

		public float maxLifetime = 5f;

		public float minSpeed = 5f;

		public float maxSpeed = 5f;

		public float minSize = 1f;

		public float maxSize = 1f;

		public ParticleSystem.MinMaxGradient startColor;

		public bool isBurst;

		public int minNumberOfParticles = 10;

		public int maxNumberOfParticles = 10;

		public AllIn1ParticleHelperComponent.EmissionShapes currEmissionShape;

		public AllIn1ParticleHelperComponent.LifetimeSettings colorLifetime = AllIn1ParticleHelperComponent.LifetimeSettings.Descendent;

		public AllIn1ParticleHelperComponent.LifetimeSettings sizeLifetime;
	}
}
