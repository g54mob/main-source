using Brewery.Items;
using InventorySystem;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Employee
{
	public class BreweryEmployeeCarryController : NetworkBehaviour
	{
		private const string TAG = "BREW_EMP|CARRY";

		[Header("Sockets")]
		[Tooltip("Transform where one-handed items attach (e.g. right hand bone)")]
		[SerializeField]
		private Transform oneHandedSocket;

		[Tooltip("Transform where two-handed items attach (e.g. chest/spine bone)")]
		[SerializeField]
		private Transform twoHandedSocket;

		[Header("Two-Handed Carry Offsets (Barrel)")]
		[SerializeField]
		private Vector3 barrelPositionOffset;

		[SerializeField]
		private Vector3 barrelRotationOffset;

		[SerializeField]
		private Vector3 barrelScale;

		[Header("Carry Animation Layer")]
		[Tooltip("Index of the two-handed carrying animation layer (same as player = 7)")]
		[SerializeField]
		private int carryLayerIndex;

		[Tooltip("Speed of layer weight fade in/out")]
		[Range(1f, 20f)]
		[SerializeField]
		private float layerFadeSpeed;

		[Header("Animation")]
		[SerializeField]
		private float appearDuration;

		[SerializeField]
		private float disappearDuration;

		private NetworkVariable<FixedString64Bytes> syncedCarriedItemId;

		private NetworkVariable<BeerDataSnapshot> syncedBeverageMetadata;

		private Animator npcAnimator;

		private GameObject spawnedVisual;

		private Item currentItem;

		private bool isCarryingTwoHanded;

		private float carryLayerWeight;

		private static readonly int IsCarryingHash;

		private static readonly int IsCarryingOneHandedHash;

		public bool IsCarryingTwoHanded => false;

		public Item CurrentItem => null;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void CacheBoneSockets()
		{
		}

		public void ShowCarry(string itemId)
		{
		}

		public void ShowCarryWithMetadata(string itemId, BeerDataSnapshot metadata)
		{
		}

		public void HideCarry()
		{
		}

		private void OnCarriedItemChanged(FixedString64Bytes oldValue, FixedString64Bytes newValue)
		{
		}

		private void SpawnVisual(Item item)
		{
		}

		private void ApplyBeverageVisual()
		{
		}

		private void OnBeverageMetadataChanged(BeerDataSnapshot prev, BeerDataSnapshot current)
		{
		}

		private void DestroyVisual()
		{
		}

		private void DisablePhysicsOnVisual(GameObject visual)
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
