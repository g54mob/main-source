public interface IPetOwner
{
	PetBase activePet { get; set; }

	int GetPetAuxDataIndex();

	int GetPetXp();

	bool ShouldHidePetName();
}
