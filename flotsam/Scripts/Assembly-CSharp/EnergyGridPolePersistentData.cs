using System;

[Serializable]
public class EnergyGridPolePersistentData : BuildableExtendablePersistentData<EnergyGridPole>
{
	public EnergyGridPolePersistentData(EnergyGridPole pole)
		: base(pole)
	{
		base.Instance = pole;
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<EnergyGridPole>(out var component))
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
