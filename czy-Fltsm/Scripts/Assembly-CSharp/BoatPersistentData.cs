using System;

[Serializable]
public class BoatPersistentData : BuildableExtendablePersistentData<Boat>
{
	public bool DriftWithCurrent;

	public PersistentReference<Project>.Reference ReclaimProject;

	public BoatPersistentData(Boat boat, bool driftWithCurrent)
		: base(boat)
	{
		DriftWithCurrent = driftWithCurrent;
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<Boat>(out var component))
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
