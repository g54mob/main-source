using System;

[Serializable]
public class ConstructionPersistentData : BuildableExtendablePersistentData<Construction>
{
	public Reference[] Neighbours;

	public bool HookSnap;

	public bool EnableConstructionHooks;

	public ConstructionPersistentData(Construction construction)
		: base(construction)
	{
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<Construction>(out var component))
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
