using System;
using System.Runtime.Serialization;

[Serializable]
public class EnergyGridBuildableComponentPersistentData : BuildableExtendablePersistentData<EnergyGridBuildableComponent>, IEnergyGridComponentPersistentData
{
	[OptionalField(VersionAdded = 2)]
	private EnergyGridConnectorPersistentData _connectorPersistentData;

	public PersistentReference<EnergyGrid>.Reference EnergyGrid;

	public Reference[] EnergyLinks;

	PersistentReference<EnergyGrid>.Reference IEnergyGridComponentPersistentData.EnergyGridReference
	{
		get
		{
			if (_connectorPersistentData == null)
			{
				return EnergyGrid;
			}
			return _connectorPersistentData.EnergyGridReference;
		}
	}

	public EnergyGridBuildableComponentPersistentData(EnergyGridBuildableComponent component)
		: base(component)
	{
		base.Instance = component;
		_connectorPersistentData = new EnergyGridConnectorPersistentData(component);
	}

	public override void PopulateReferences()
	{
		_connectorPersistentData?.PopulateReferences();
	}

	public override void Restore()
	{
		base.Restore();
		_connectorPersistentData?.Restore();
	}

	public override void RestoreData(Buildable buildable)
	{
		if (!PersistenceManager.HasSaveInfoVersion(0, 9, 0, "e10") && buildable.TryGetComponent<EnergyGridBuildableComponent>(out var component))
		{
			base.Instance = component;
			_connectorPersistentData?.RestoreData(buildable);
		}
	}

	public override void RestoreReferences()
	{
		if (base.Instance != null)
		{
			base.Instance.RestoreReferences(this);
		}
	}

	EnergyGridConnector[] IEnergyGridComponentPersistentData.GetEnergyLinks()
	{
		if (_connectorPersistentData != null)
		{
			return _connectorPersistentData.GetEnergyLinks();
		}
		if (EnergyLinks.IsNullOrEmpty())
		{
			return null;
		}
		EnergyGridConnector[] array = new EnergyGridConnector[EnergyLinks.Length];
		for (int i = 0; i < EnergyLinks.Length; i++)
		{
			if (EnergyLinks[i].TryReturn(out var instance))
			{
				array[i] = instance;
			}
		}
		return array;
	}
}
