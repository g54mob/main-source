using System;
using System.Runtime.Serialization;

[Serializable]
public class ResearchStationPersistentData : BuildableExtendablePersistentData<ResearchStation>
{
	[OptionalField(VersionAdded = 2)]
	public float Progress;

	public PersistentReference<Agent>.Reference ReservingAgent;

	public ResearchStationPersistentData(ResearchStation station)
		: base(station)
	{
		base.Instance = station;
		Progress = station.Progress;
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<ResearchStation>(out var component))
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
