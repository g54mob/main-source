public class PetBed : Chest, IPetOwner
{
	public PetBase activePet { get; set; }

	public int GetPetAuxDataIndex()
	{
		return base.inventoryHandler?.GetContainedObjectData(0).auxDataIndex ?? 0;
	}

	public int GetPetXp()
	{
		return base.inventoryHandler?.GetObjectData(0).amount ?? 0;
	}

	public bool ShouldHidePetName()
	{
		return false;
	}
}
