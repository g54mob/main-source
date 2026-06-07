using System;

[Serializable]
public class HousePersistentData : BuildableExtendablePersistentData<House>
{
	public PersistentReference<Agent>.Reference[] Inhabitants;

	public HousePersistentData(House house)
		: base(house)
	{
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<House>(out var component))
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
