using UnityEngine;

namespace WaveHarmonic.Crest
{
	[CreateAssetMenu(fileName = "FoamSettings", menuName = "Crest/Simulation Settings/Foam")]
	public sealed class FoamLodSettings : LodSettings
	{
		[Header("General settings")]
		[Tooltip("Foam will not exceed this value in the simulation which can be used to prevent foam from accumulating too much.")]
		[Min(0f)]
		[SerializeField]
		private float _Maximum = 10f;

		[Tooltip("How quickly foam dissipates.\n\nLow values mean foam remains on surface for longer. This setting should be balanced with the generation *strength* parameters below.")]
		[SerializeField]
		internal float _FoamFadeRate = 0.8f;

		[Header("Whitecaps")]
		[Tooltip("Scales intensity of foam generated from waves.\n\nThis setting should be balanced with the Foam Fade Rate setting.")]
		[SerializeField]
		internal float _WaveFoamStrength = 1f;

		[Tooltip("How much of the waves generate foam.\n\nHigher values will lower the threshold for foam generation, giving a larger area.")]
		[SerializeField]
		internal float _WaveFoamCoverage = 0.55f;

		[Tooltip("The minimum LOD  to sample waves from.\n\nZero means all waves and increasing will exclude lower wavelengths which can help with too much foam near the camera.")]
		[SerializeField]
		internal int _FilterWaves = 2;

		[Header("Shoreline")]
		[Tooltip("Foam will be generated in water shallower than this depth.\n\nControls how wide the band of foam at the shoreline will be. Note that this is not a distance to shoreline, but a threshold on water depth, so the width of the foam band can vary based on terrain slope. To address this limitation we allow foam to be manually added from geometry or from a texture, see the next section.")]
		[SerializeField]
		internal float _ShorelineFoamMaximumDepth = 0.65f;

		[Tooltip("Scales intensity of foam generated in shallow water.\n\nThis setting should be balanced with the Foam Fade Rate setting.")]
		[SerializeField]
		internal float _ShorelineFoamStrength = 2f;

		[Tooltip("Primes foam when terrain height is this value above water.\n\nThis ignores other foam settings and writes a constant foam value.")]
		[SerializeField]
		internal float _ShorelineFoamPriming = 5f;

		public int FilterWaves
		{
			get
			{
				return _FilterWaves;
			}
			set
			{
				_FilterWaves = value;
			}
		}

		public float FoamFadeRate
		{
			get
			{
				return _FoamFadeRate;
			}
			set
			{
				_FoamFadeRate = value;
			}
		}

		public float Maximum
		{
			get
			{
				return _Maximum;
			}
			set
			{
				_Maximum = value;
			}
		}

		public float ShorelineFoamMaximumDepth
		{
			get
			{
				return _ShorelineFoamMaximumDepth;
			}
			set
			{
				_ShorelineFoamMaximumDepth = value;
			}
		}

		public float ShorelineFoamPriming
		{
			get
			{
				return _ShorelineFoamPriming;
			}
			set
			{
				_ShorelineFoamPriming = value;
			}
		}

		public float ShorelineFoamStrength
		{
			get
			{
				return _ShorelineFoamStrength;
			}
			set
			{
				_ShorelineFoamStrength = value;
			}
		}

		public float WaveFoamCoverage
		{
			get
			{
				return _WaveFoamCoverage;
			}
			set
			{
				_WaveFoamCoverage = value;
			}
		}

		public float WaveFoamStrength
		{
			get
			{
				return _WaveFoamStrength;
			}
			set
			{
				_WaveFoamStrength = value;
			}
		}
	}
}
