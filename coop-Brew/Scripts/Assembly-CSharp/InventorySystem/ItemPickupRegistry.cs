using System.Collections.Generic;
using BrewGame.SaveSystem.Integration;
using Brewery.Items;
using UnityEngine;

namespace InventorySystem
{
	public class ItemPickupRegistry : MonoBehaviour, ISaveable
	{
		private readonly Dictionary<ulong, ItemPickup> pickups;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private Dictionary<string, object> _pendingRestoreState;

		private bool _hasAttemptedRestore;

		public static ItemPickupRegistry Instance { get; private set; }

		public string SaveableId => null;

		public int SavePriority => 0;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		public void Register(ItemPickup pickup)
		{
		}

		public void Unregister(ItemPickup pickup)
		{
		}

		public int GetPickupCount()
		{
			return 0;
		}

		private void DestroyAllPickups()
		{
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		private void RestoreStateInternal(Dictionary<string, object> state)
		{
		}

		private Dictionary<string, object> CaptureBarrelMetadata(BarrelItemData barrelData)
		{
			return null;
		}

		private Dictionary<string, object> CaptureBeverageMetadata(BeverageItemData beverageData)
		{
			return null;
		}

		private Dictionary<string, object> CaptureCrateMetadata(CrateItemData crateData)
		{
			return null;
		}

		private void RestoreBarrelMetadata(GameObject instance, object metaObj)
		{
		}

		private void RestoreBeverageMetadata(GameObject instance, object metaObj)
		{
		}

		private void RestoreCrateMetadata(GameObject instance, object metaObj)
		{
		}
	}
}
