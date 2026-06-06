using System;

[Serializable]
public class PontonPersistentData : BuildableExtendablePersistentData<WalkwayPonton>
{
	public PersistentReference<EnergyGridPole>.Reference EnergyGridPole;

	public PontonPersistentData(WalkwayPonton ponton)
		: base(ponton)
	{
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<WalkwayPonton>(out var component))
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
