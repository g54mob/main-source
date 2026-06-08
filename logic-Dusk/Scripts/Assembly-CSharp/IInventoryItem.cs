public interface IInventoryItem
{
	InventoryTypeEnum InventoryType { get; }

	string GroupKey { get; }

	string Name { get; }

	string Suffix { get; }

	string Description { get; }

	string guiValue { get; }

	string guiInventoryType { get; }

	float Weight { get; }

	float SellValue { get; }

	bool IsBroken { get; }

	bool AgesDuringTravel { get; }

	ModificationStorageIdEnum AppliedModifications { get; }

	bool AddDaysTraveled(int additionalDays);
}
