using NSMedieval.State;

namespace NSMedieval.Manager
{
	public class ResourcePileCount
	{
		public int UnreachableCount { get; private set; }

		public int TotalCount { get; private set; }

		public int ForbiddenCount { get; private set; }

		public int StockpileTotalCount { get; private set; }

		public int StockpileForbiddenCount { get; private set; }

		public int StockpilePlacedCount { get; private set; }

		public int AnimalFeederPlacedCount { get; private set; }

		public int DroppedByEnemy { get; private set; }

		public int OwnedByEnemy { get; private set; }

		public int StockpileAllowedCount => StockpileTotalCount - ForbiddenCount;

		public int AllowedCount => TotalCount - ForbiddenCount;

		public ResourcePileCount()
		{
		}

		public ResourcePileCount(int unreachable, int totalCount, int forbiddenCount, int stockpileTotalCount, int stockpileForbiddenCount, int stockpilePlacedCount, int animalFeederPlacedCount, int droppedByEnemy, int ownedByEnemy)
		{
			UnreachableCount = unreachable;
			TotalCount = totalCount;
			StockpileTotalCount = stockpileTotalCount;
			StockpileForbiddenCount = stockpileForbiddenCount;
			ForbiddenCount = forbiddenCount;
			StockpilePlacedCount = stockpilePlacedCount;
			AnimalFeederPlacedCount = animalFeederPlacedCount;
			DroppedByEnemy = droppedByEnemy;
			OwnedByEnemy = ownedByEnemy;
		}

		public override string ToString()
		{
			return $"Unreachable:{UnreachableCount}, Total:{TotalCount}, Forbidden:{ForbiddenCount}, Allowed:{AllowedCount}, StockpileTotal:{StockpileTotalCount}, StockpileForbid:{StockpileForbiddenCount}, StockpileAllow:{StockpileAllowedCount}, StockpilePlaced:{StockpilePlacedCount}, AnimalFeederPlacedCount:{AnimalFeederPlacedCount}, DroppedByEnemy:{DroppedByEnemy}, OwnedByEnemy:{OwnedByEnemy}";
		}

		public void Add(ResourcePileCount b)
		{
			UnreachableCount += b.UnreachableCount;
			TotalCount += b.TotalCount;
			ForbiddenCount += b.ForbiddenCount;
			StockpileTotalCount += b.StockpileTotalCount;
			StockpileForbiddenCount += b.StockpileForbiddenCount;
			StockpilePlacedCount += b.StockpilePlacedCount;
			AnimalFeederPlacedCount += b.AnimalFeederPlacedCount;
			DroppedByEnemy += b.DroppedByEnemy;
			OwnedByEnemy += b.OwnedByEnemy;
		}

		public void Subtract(ResourcePileCount b)
		{
			UnreachableCount -= b.UnreachableCount;
			TotalCount -= b.TotalCount;
			ForbiddenCount -= b.ForbiddenCount;
			StockpileTotalCount -= b.StockpileTotalCount;
			StockpileForbiddenCount -= b.StockpileForbiddenCount;
			StockpilePlacedCount -= b.StockpilePlacedCount;
			AnimalFeederPlacedCount -= b.AnimalFeederPlacedCount;
			DroppedByEnemy -= b.DroppedByEnemy;
			OwnedByEnemy -= b.OwnedByEnemy;
		}

		public void Add(ResourcePileInstance pile)
		{
			Add(this, pile, (pile?.GetStoredResource()?.Amount).GetValueOrDefault());
		}

		public void Subtract(ResourcePileInstance pile)
		{
			Subtract(this, pile, (pile?.GetStoredResource()?.Amount).GetValueOrDefault());
		}

		public static void Subtract(ResourcePileCount count, ResourcePileInstance pile, int amount)
		{
			ResourceInstance storedResource = pile.GetStoredResource();
			if (storedResource != null || amount != 0)
			{
				bool num = ResourcePileUtils.IsReachableByWorker(pile);
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				bool placedOnAnimalFeeder = pile.PlacedOnAnimalFeeder;
				if (!num)
				{
					num3 = amount;
				}
				else if (!placedOnAnimalFeeder)
				{
					num2 = amount;
					num4 = (pile.IsForbidden ? amount : 0);
				}
				count.UnreachableCount -= num3;
				count.TotalCount -= num2;
				count.ForbiddenCount -= num4;
				count.StockpileTotalCount -= (pile.IsStoredOnStockpile() ? amount : 0);
				count.StockpileForbiddenCount -= ((pile.IsStoredOnStockpile() && pile.IsForbidden) ? amount : 0);
				count.StockpilePlacedCount -= (((pile.IsPlacedOnStockpile() || pile.IsPlacedOnStorageBuilding) && !placedOnAnimalFeeder) ? amount : 0);
				count.AnimalFeederPlacedCount -= (placedOnAnimalFeeder ? amount : 0);
				count.DroppedByEnemy -= ((storedResource != null && storedResource.DroppedByEnemy) ? amount : 0);
				count.OwnedByEnemy -= ((storedResource != null && !storedResource.OwnedByPlayer()) ? amount : 0);
			}
		}

		public static void Add(ResourcePileCount count, ResourcePileInstance pile, int amount)
		{
			ResourceInstance storedResource = pile.GetStoredResource();
			if (storedResource == null && amount == 0)
			{
				return;
			}
			bool num = ResourcePileUtils.IsReachableByWorker(pile);
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			bool placedOnAnimalFeeder = pile.PlacedOnAnimalFeeder;
			if (!num)
			{
				num3 = amount;
			}
			else
			{
				if (!placedOnAnimalFeeder)
				{
					num2 = amount;
				}
				num4 = (pile.IsForbidden ? amount : 0);
			}
			count.UnreachableCount += num3;
			count.TotalCount += num2;
			count.ForbiddenCount += num4;
			count.StockpileTotalCount += (pile.IsStoredOnStockpile() ? amount : 0);
			count.StockpileForbiddenCount += ((pile.IsStoredOnStockpile() && pile.IsForbidden) ? amount : 0);
			count.StockpilePlacedCount += (((pile.IsPlacedOnStockpile() || pile.IsPlacedOnStorageBuilding) && !placedOnAnimalFeeder) ? amount : 0);
			count.AnimalFeederPlacedCount += (placedOnAnimalFeeder ? amount : 0);
			count.DroppedByEnemy += ((storedResource != null && storedResource.DroppedByEnemy) ? amount : 0);
			count.OwnedByEnemy += ((storedResource != null && !storedResource.OwnedByPlayer()) ? amount : 0);
		}

		public void Reset()
		{
			UnreachableCount = 0;
			TotalCount = 0;
			ForbiddenCount = 0;
			StockpileTotalCount = 0;
			StockpileForbiddenCount = 0;
			StockpilePlacedCount = 0;
			AnimalFeederPlacedCount = 0;
			DroppedByEnemy = 0;
			OwnedByEnemy = 0;
		}
	}
}
