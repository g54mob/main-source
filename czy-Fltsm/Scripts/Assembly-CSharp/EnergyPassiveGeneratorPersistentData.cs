using System;

[Serializable]
public class EnergyPassiveGeneratorPersistentData : BuildableExtendablePersistentData<EnergyPassiveGenerator>
{
	public EnergyPassiveGeneratorPersistentData(EnergyPassiveGenerator generator)
		: base(generator)
	{
		base.Instance = generator;
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<EnergyPassiveGenerator>(out var component))
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
