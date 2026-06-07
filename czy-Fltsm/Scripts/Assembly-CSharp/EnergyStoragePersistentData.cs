using System;

[Serializable]
public class EnergyStoragePersistentData : BuildableExtendablePersistentData<EnergyStorage>
{
	public float EnergyAmount;

	public EnergyStoragePersistentData(EnergyStorage energyStorage)
		: base(energyStorage)
	{
		base.Instance = energyStorage;
		EnergyAmount = energyStorage.EnergyAmount;
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<EnergyStorage>(out var component))
		{
			base.Instance = component;
			base.Instance.Restore(this);
		}
	}

	public override void RestoreReferences()
	{
		if (base.Instance != null)
		{
			base.Instance.RestoreReferences(this);
		}
	}

	public override void PopulateReferences()
	{
		base.Instance.PopulateReferences(this);
	}
}
