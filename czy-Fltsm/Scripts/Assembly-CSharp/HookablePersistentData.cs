using System;

[Serializable]
public class HookablePersistentData : BuildableExtendablePersistentData<Hookable>
{
	public HookablePersistentData(Hookable hookable)
		: base(hookable)
	{
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<Hookable>(out var component))
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
