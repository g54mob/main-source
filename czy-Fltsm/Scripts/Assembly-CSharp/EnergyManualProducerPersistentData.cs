using System;
using System.Runtime.Serialization;

[Serializable]
public class EnergyManualProducerPersistentData : BuildableExtendablePersistentData<EnergyManualProducer>
{
	public PersistentReference<Project>.Reference RechargeProject;

	[OptionalField(VersionAdded = 2)]
	public float EnergyFillPercentage = 0.5f;

	public float EnergyThreshold;

	public EnergyManualProducerPersistentData(EnergyManualProducer producer)
		: base(producer)
	{
		EnergyFillPercentage = producer.EnergyFillPercentage;
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<EnergyManualProducer>(out var component))
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
