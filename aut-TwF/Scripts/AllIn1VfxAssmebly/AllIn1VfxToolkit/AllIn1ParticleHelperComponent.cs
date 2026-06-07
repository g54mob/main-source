using UnityEngine;

namespace AllIn1VfxToolkit
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[AddComponentMenu("AllIn1VfxToolkit/AddAllIn1VfxParticleHelper")]
	public class AllIn1ParticleHelperComponent : MonoBehaviour
	{
		public enum EmissionShapes
		{
			Cone = 0,
			Sphere = 1,
			Circle = 2,
			None = 3
		}

		public enum LifetimeSettings
		{
			Ascendant = 0,
			Descendent = 1,
			None = 2
		}

		public bool hierarchyHelpers;

		public bool generalOptions;

		public bool shapeOptions;

		public bool emissionOptions;

		public bool overLifetimeOptions;

		public bool colorChangeOption;

		public bool particleHelperPresets;

		public bool particleSystemPresets;

		public int numberOfCopies = 1;

		public bool applyEverythingOnChange = true;

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

		public EmissionShapes currEmissionShape;

		public LifetimeSettings colorLifetime = LifetimeSettings.None;

		public LifetimeSettings sizeLifetime = LifetimeSettings.None;

		private void SetSceneDirty()
		{
		}
	}
}
