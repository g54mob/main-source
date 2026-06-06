using System.Collections.Generic;
using Brewery.Shelf;
using Brewery.Stations;

namespace Brewery.Employee.AI
{
	public class BreweryEmployeeAI
	{
		private const string TAG = "BREW_EMP|AI";

		private readonly BreweryBuildingZone buildingZone;

		private readonly ulong employeeNetworkObjectId;

		private readonly BreweryEmployeeSlot employeeSlot;

		private readonly BreweryEmployeeManager employeeManager;

		private ShelfInventoryManager failedBottleShelf;

		private int failedBottleSlot;

		private float failedBottleExpiry;

		private static readonly Dictionary<(int shelfId, int slotIndex), ulong> barrelClaims;

		public static bool TryClaimBarrel(ShelfInventoryManager shelf, int slotIndex, ulong employeeNetId)
		{
			return false;
		}

		public static void ReleaseBarrelClaim(ShelfInventoryManager shelf, int slotIndex, ulong employeeNetId)
		{
		}

		public static void ReleaseAllBarrelClaims(ulong employeeNetId)
		{
		}

		private bool IsBarrelClaimedByOther(ShelfInventoryManager shelf, int slotIndex)
		{
			return false;
		}

		public void SetBottlingCooldown(ShelfInventoryManager shelf, int slotIndex, float cooldownSeconds)
		{
		}

		private bool IsBottlingOnCooldown(ShelfInventoryManager shelf, int slotIndex)
		{
			return false;
		}

		public BreweryEmployeeAI(BreweryBuildingZone zone, ulong networkObjectId, BreweryEmployeeSlot slot, BreweryEmployeeManager manager = null)
		{
		}

		public BreweryTask PlanNextTask()
		{
			return null;
		}

		private void ReleaseUnusedClaims(IReadOnlyList<BaseBreweryStation> stations, BreweryTask selectedTask)
		{
		}

		private void CleanupStaleLocks(IReadOnlyList<BaseBreweryStation> stations)
		{
		}

		private BreweryTask CheckBottlingTasks(IReadOnlyList<ShelfInventoryManager> shelves)
		{
			return null;
		}

		private BreweryTask CheckCollectOutputTasks(IReadOnlyList<BaseBreweryStation> stations)
		{
			return null;
		}

		private BreweryTask CheckStartProcessingTasks(IReadOnlyList<BaseBreweryStation> stations, IReadOnlyList<ShelfInventoryManager> shelves)
		{
			return null;
		}

		private BreweryTask CheckResumeLoadingTasks(IReadOnlyList<BaseBreweryStation> stations, IReadOnlyList<ShelfInventoryManager> shelves)
		{
			return null;
		}

		private BreweryTask CheckNewProductionTasks(IReadOnlyList<BaseBreweryStation> stations, IReadOnlyList<ShelfInventoryManager> shelves)
		{
			return null;
		}

		private BreweryTask CheckOptionalInputTasks(IReadOnlyList<BaseBreweryStation> stations, IReadOnlyList<ShelfInventoryManager> shelves)
		{
			return null;
		}

		private BreweryTask CheckCatalyzingTasks(IReadOnlyList<ShelfInventoryManager> shelves)
		{
			return null;
		}

		public ShelfInventoryManager FindShelfWithSpace(string itemId, bool isFinalProduct = false)
		{
			return null;
		}

		public ShelfInventoryManager FindOutputShelfWithSpace(string itemId)
		{
			return null;
		}

		public int FindNextUnloadedInput(BaseBreweryStation station, Recipe recipe)
		{
			return 0;
		}

		public ShelfInventoryManager FindShelfWithItem(string itemId, int minQuantity = 1)
		{
			return null;
		}

		public ShelfInventoryManager FindShelfWithIngredient(RecipeInput input)
		{
			return null;
		}

		public RecipeInput? FindNextAvailableOptionalInput(Recipe recipe, BaseBreweryStation station)
		{
			return null;
		}

		public int CountLoadedOptionalInputs(Recipe recipe, BaseBreweryStation station)
		{
			return 0;
		}
	}
}
