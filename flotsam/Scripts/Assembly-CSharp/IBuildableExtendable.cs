using System.Collections.Generic;

public interface IBuildableExtendable
{
	Buildable Buildable { get; }

	bool Active { get; }

	void Initialize(Buildable buildable, bool restored = false);

	void Finish(bool restored = false);

	void Remove();

	void Activate();

	void Deactivate();

	void Shutdown();

	void ShutdownImmediately();

	void OnDeconstruct();

	void Restore(IBuildableExtendablePersistentData persistentData);

	void RestoreReferences(IBuildableExtendablePersistentData persistentData);

	void PopulateReferences(IBuildableExtendablePersistentData persistentData);

	bool IsEnabled();

	bool CanBeSalvaged();

	bool CanBeUpgraded()
	{
		return CanBeSalvaged();
	}

	bool CanBeSalvaged(ref List<Buildable> walkwayPontons)
	{
		return CanBeSalvaged();
	}

	bool CanBeDeconstructed();

	void Upgrade(Buildable buildable);

	IBuildableExtendablePersistentData ReturnPersistentData();

	string ReturnDescription(string text);

	float ReturnWeight();

	float ReturnWeightModifier()
	{
		return 1f;
	}

	List<Agent> GetWorkers(List<Agent> listToPopulate = null)
	{
		return listToPopulate;
	}
}
