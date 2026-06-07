using System;

[Serializable]
public class EnginePersistentData : BuildableExtendablePersistentData<Engine>
{
	public float EnergyAmount;

	public EnginePersistentData(Engine engine)
		: base(engine)
	{
		base.Instance = engine;
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<Engine>(out var component))
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
