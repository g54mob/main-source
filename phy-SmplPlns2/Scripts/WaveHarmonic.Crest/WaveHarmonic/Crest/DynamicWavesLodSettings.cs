using UnityEngine;

namespace WaveHarmonic.Crest
{
	[CreateAssetMenu(fileName = "DynamicWavesSettings", menuName = "Crest/Simulation Settings/Dynamic Waves")]
	public sealed class DynamicWavesLodSettings : LodSettings
	{
		[Header("Simulation")]
		[Tooltip("How much energy is dissipated each frame.\n\nHelps simulation stability, but limits how far ripples will propagate. Set this as large as possible/acceptable. Default is 0.05.")]
		[SerializeField]
		internal float _Damping = 0.05f;

		[Tooltip("Stability control.\n\nLower values means more stable simulation, but may slow down some dynamic waves. This value should be set as large as possible until simulation instabilities/flickering begin to appear. Default is 0.7.")]
		[SerializeField]
		internal float _CourantNumber = 0.7f;

		[Header("Displacement Generation")]
		[Tooltip("Induce horizontal displacements to sharpen simulated waves.")]
		[SerializeField]
		internal float _HorizontalDisplace = 3f;

		[Tooltip("Clamp displacement to help prevent self-intersection in steep waves.\n\nZero means unclamped.")]
		[SerializeField]
		internal float _DisplaceClamp = 0.3f;

		[Tooltip("Multiplier for gravity.\n\nMore gravity means dynamic waves will travel faster. Higher values can be a source of instability.")]
		[SerializeField]
		internal float _GravityMultiplier = 1f;

		[Tooltip("Adds padding to water chunk bounds.\n\nDynamic Waves displaces the surface which can push vertices outside of the chunk bounds leading to culling issues. This value adds padding to the chunk bounds to mitigate this.")]
		[SerializeField]
		internal float _VerticalDisplacementCullingContributions = 5f;

		public float CourantNumber
		{
			get
			{
				return _CourantNumber;
			}
			set
			{
				_CourantNumber = value;
			}
		}

		public float Damping
		{
			get
			{
				return _Damping;
			}
			set
			{
				_Damping = value;
			}
		}

		public float DisplaceClamp
		{
			get
			{
				return _DisplaceClamp;
			}
			set
			{
				_DisplaceClamp = value;
			}
		}

		public float GravityMultiplier
		{
			get
			{
				return _GravityMultiplier;
			}
			set
			{
				_GravityMultiplier = value;
			}
		}

		public float HorizontalDisplace
		{
			get
			{
				return _HorizontalDisplace;
			}
			set
			{
				_HorizontalDisplace = value;
			}
		}

		public float VerticalDisplacementCullingContributions
		{
			get
			{
				return _VerticalDisplacementCullingContributions;
			}
			set
			{
				_VerticalDisplacementCullingContributions = value;
			}
		}
	}
}
