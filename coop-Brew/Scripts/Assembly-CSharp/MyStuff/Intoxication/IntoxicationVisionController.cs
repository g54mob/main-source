using System.Collections.Generic;
using Brewery.Core;
using Brewery.DrinkingSystem;
using Brewery.Items;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Rendering;

namespace MyStuff.Intoxication
{
	public class IntoxicationVisionController : NetworkBehaviour
	{
		[SerializeField]
		private List<IntoxicationTagProfile> tagProfiles;

		[Header("Plain Beverage Profiles")]
		[SerializeField]
		private IntoxicationTagProfile plainBeerProfile;

		[SerializeField]
		private IntoxicationTagProfile plainWineProfile;

		[SerializeField]
		private IntoxicationTagProfile plainSpiritsProfile;

		[Header("Debug")]
		[SerializeField]
		private bool debugLog;

		[Tooltip("Force-trigger an effect in play mode for testing")]
		[SerializeField]
		private BrewTag debugTestTag;

		private NetworkVariable<bool> isIntoxicatedNetworked;

		private Dictionary<BrewTag, IntoxicationTagProfile> _profileLookup;

		private readonly List<IntoxicationEffectState> _activeEffects;

		private Volume _volume;

		private VolumeProfile _runtimeProfile;

		private DrinkingController _drinkingController;

		private bool _subscribed;

		private static readonly BrewTag[] AllTags;

		private static readonly int _WobbleAmplitude;

		private static readonly int _WobbleFrequency;

		private static readonly int _DoubleVisionOffset;

		private static readonly int _DoubleVisionAlpha;

		private static readonly int _ColorCyclingSpeed;

		private static readonly int _ColorCyclingIntensity;

		private static readonly int _RadialBlurStrength;

		private static readonly int _RadialBlurSamples;

		private static readonly int _ScreenPulseAmplitude;

		private static readonly int _ScreenPulseFrequency;

		private static readonly int _FocusBlurStrength;

		private static readonly int _FocusBlurRadius;

		public static bool IsActive
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public static bool ForceDebugActive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsIntoxicated => false;

		private void SetIntoxicatedNetworked(bool value)
		{
		}

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void OnEnable()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void OnDisable()
		{
		}

		private new void OnDestroy()
		{
		}

		private void Subscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		private void CreateVolume()
		{
		}

		private void HandleDrinkConsumed(BeerDataSnapshot snapshot)
		{
		}

		private bool ApplyOrRefreshEffect(BrewTag tag, IntoxicationTagProfile profile)
		{
			return false;
		}

		private IntoxicationTagProfile GetPlainProfile(BaseType baseType)
		{
			return null;
		}

		private void Update()
		{
		}

		private AggregatedIntoxicationParams Aggregate()
		{
			return default(AggregatedIntoxicationParams);
		}

		public void ClearAllEffects()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
