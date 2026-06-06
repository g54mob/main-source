using System.Collections.Generic;
using Brewery.Shelf;
using Brewery.Stations;
using UnityEngine;

namespace Brewery.Employee
{
	[RequireComponent(typeof(BoxCollider))]
	public class BreweryBuildingZone : MonoBehaviour
	{
		private const string TAG = "BREW_EMP|ZONE";

		[SerializeField]
		private string buildingName;

		[Tooltip("How often to rescan for new/removed stations and shelves (seconds)")]
		[SerializeField]
		private float scanInterval;

		private readonly List<BaseBreweryStation> stations;

		private readonly List<ShelfInventoryManager> shelves;

		private BoxCollider zoneCollider;

		private float scanTimer;

		public string BuildingName => null;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void Scan()
		{
		}

		public void ManualScan()
		{
		}

		public IReadOnlyList<BaseBreweryStation> GetStations()
		{
			return null;
		}

		public IReadOnlyList<ShelfInventoryManager> GetShelves()
		{
			return null;
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
