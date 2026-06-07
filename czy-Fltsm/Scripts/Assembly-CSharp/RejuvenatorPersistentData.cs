using System;

[Serializable]
public class RejuvenatorPersistentData : BuildableExtendablePersistentData<Rejuvenator>
{
	public RejuvenatorPersistentData(Rejuvenator rejuvenator)
		: base(rejuvenator)
	{
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<Rejuvenator>(out var component))
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
