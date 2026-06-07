using I2.Loc;
using UnityEngine;

public interface IConstructible : IPathfindingNodeProvider
{
	string Name { get; }

	PlaceableProperties Properties { get; }

	ConstructibleStatus StatusHolder { get; }

	Inventory Inventory { get; }

	Community Community { get; }

	GameObject gameObject { get; }

	void OnBuildPhaseUpdated(BuildPhase buildPhase);

	void FinishConstruction(bool restored = false);

	void RemoveConstructible();

	void StartUpgrade();

	void SetProgress(float progress);

	void DetachBuildingAgents()
	{
	}

	bool CanBeSalvaged()
	{
		return true;
	}

	bool CanBeDeconstructed(out LocalizedString error);

	bool IsInConstruction();

	void AddMalfunction(PlaceableAlertProperties properties)
	{
		StatusHolder.AddMalfunction(properties);
	}

	void RemoveMalfunction(PlaceableAlertProperties properties)
	{
		StatusHolder.RemoveMalfunction(properties);
	}
}
