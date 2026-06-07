using Brewery.Vehicle;
using Ezereal;
using Unity.Netcode;
using UnityEngine;

namespace MyStuff.Vehicle
{
	public class VehicleLightsController : NetworkBehaviour
	{
		[Header("Headlights (Front)")]
		[Tooltip("Front headlight(s). Assign 1-2 lights.")]
		[SerializeField]
		private Light[] headlights;

		[Header("Stoplights (Rear)")]
		[Tooltip("Rear stoplight(s)/brake lights. Assign 1-2 lights.")]
		[SerializeField]
		private Light[] stoplights;

		[Header("Stoplight Intensity")]
		[Tooltip("Intensity multiplier when stoplights are idle (running lights). 1.0 = use configured intensity.")]
		[SerializeField]
		private float stoplightIdleMultiplier;

		[Tooltip("Intensity multiplier when braking. 1.0 = use configured intensity.")]
		[SerializeField]
		private float stoplightBrakeMultiplier;

		[Header("Reverse Light")]
		[Tooltip("Which stoplight becomes the reverse light (white when backing up). -1 = last in array.")]
		[SerializeField]
		private int reverseLightIndex;

		[Tooltip("Intensity multiplier for reverse light. 1.0 = use configured intensity.")]
		[SerializeField]
		private float reverseLightIntensityMultiplier;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<bool> netLightsOn;

		private NetworkVariable<float> netBrakeAmount;

		private NetworkVariable<bool> netIsReversing;

		private NetworkVariable<bool> netHeadlightsOn;

		private IVehicleController _vehicleController;

		private EzerealCarController _carController;

		private bool _wasHasDriver;

		private bool _cachedLightsOn;

		private float _cachedBrakeAmount;

		private bool _cachedIsReversing;

		private bool _cachedHeadlightsOn;

		private float[] _stoplightBaseIntensities;

		private Color[] _stoplightBaseColors;

		private int _resolvedReverseLightIndex;

		private bool _rememberedHeadlightsOn;

		private bool _isSubscribedToInput;

		public bool AreLightsOn => false;

		public float BrakeAmount => 0f;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public override void OnGainedOwnership()
		{
		}

		public override void OnLostOwnership()
		{
		}

		private void Update()
		{
		}

		private void UpdateOwnerState()
		{
		}

		private bool GetHasDriver()
		{
			return false;
		}

		private float GetCurrentSpeed()
		{
			return 0f;
		}

		private bool GetIsReversing()
		{
			return false;
		}

		private float GetBrakeValue()
		{
			return 0f;
		}

		private float GetHandbrakeValue()
		{
			return 0f;
		}

		private void OnLightsOnChanged(bool previous, bool current)
		{
		}

		private void OnBrakeAmountChanged(float previous, float current)
		{
		}

		private void OnIsReversingChanged(bool previous, bool current)
		{
		}

		private void OnHeadlightsOnChanged(bool previous, bool current)
		{
		}

		private void UpdateLightVisuals()
		{
		}

		private void SetAllLightsEnabled(bool enabled)
		{
		}

		private void RestoreOriginalColors()
		{
		}

		private void SubscribeToInput()
		{
		}

		private void UnsubscribeFromInput()
		{
		}

		private void OnCarLightInput()
		{
		}

		private bool IsLocalPlayerInVehicle()
		{
			return false;
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
