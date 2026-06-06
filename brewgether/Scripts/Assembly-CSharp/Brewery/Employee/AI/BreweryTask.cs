using System.Collections.Generic;
using Brewery.Core;
using Brewery.Items;
using Brewery.Shelf;
using Brewery.Stations;
using UnityEngine;

namespace Brewery.Employee.AI
{
	public class BreweryTask
	{
		public BreweryTaskType taskType;

		public int priority;

		public BaseBreweryStation targetStation;

		public ShelfInventoryManager targetShelf;

		public BreweryStationEmployeeLock stationLock;

		public Recipe recipe;

		public int currentInputIndex;

		public string carriedItemId;

		public int carriedQuantity;

		public bool carriedBarrelIsSpecial;

		public int optionalSlotIndex;

		public bool isOptionalInput;

		public int barrelSlotIndex;

		public BeverageType bottlingBeverageType;

		public StationRole? stationRole;

		public CatalystAssignment catalystAssignment;

		public BeerDataSnapshot catalyzedSnapshot;

		public string catalyzedItemId;

		public List<(ShelfInventoryManager shelf, string catalystId, int qty)> catalystSources;

		public ShelfInventoryManager plainBeverageShelf;

		public Transform catalystStationTransform;
	}
}
