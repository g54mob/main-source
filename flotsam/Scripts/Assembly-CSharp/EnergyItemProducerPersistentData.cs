using System;
using System.Runtime.Serialization;

[Serializable]
public class EnergyItemProducerPersistentData : BuildableExtendablePersistentData<EnergyItemProducer>
{
	public PersistentReference<Project>.Reference ImportProject;

	public int ProjectCount;

	public float BurnTimer;

	public int RefillAmountPoint;

	[OptionalField(VersionAdded = 2)]
	public float EnergyFillPercentage = 0.5f;

	[OptionalField(VersionAdded = 2)]
	public bool IsGenerating;

	public EnergyItemProducerPersistentData(EnergyItemProducer producer)
		: base(producer)
	{
		ProjectCount = producer.ProjectCount;
		BurnTimer = producer.BurnTimer;
		RefillAmountPoint = producer.InventoryRefillAmountPoint;
		EnergyFillPercentage = producer.EnergyFillPercentage;
		IsGenerating = producer.IsGenerating;
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<EnergyItemProducer>(out var component))
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
