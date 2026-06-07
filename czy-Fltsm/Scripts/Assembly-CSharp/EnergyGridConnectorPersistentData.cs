using System;
using UnityEngine;

[Serializable]
public class EnergyGridConnectorPersistentData : PersistentReference<EnergyGridConnector>, IEnergyGridComponentPersistentData
{
	private PersistentReference<EnergyGrid>.Reference _energyGrid;

	private Reference[] _energyLinks;

	public PersistentReference<EnergyGrid>.Reference EnergyGridReference => _energyGrid;

	public EnergyGridConnectorPersistentData(EnergyGridConnector component)
		: base(component)
	{
		base.Instance = component;
	}

	public void PopulateReferences()
	{
		if (base.Instance == null)
		{
			Debug.LogException(new Exception("Unable to EnergyGridConnectorPersistentData.PopulateReferences, Instance == NULL"));
			return;
		}
		if (base.Instance.Connections.IsNullOrEmpty())
		{
			Debug.LogException(new Exception(string.Format($"Unable to EnergyGridConnectorPersistentData.PopulateReferences for {0}, Instance.Connections {1}", string.IsNullOrWhiteSpace(base.Instance.Name) ? base.Instance.name : base.Instance.Name, (base.Instance.Connections == null) ? " == NULL" : "is empty")));
			return;
		}
		_energyGrid = base.Instance.EnergyGrid;
		_energyLinks = new Reference[base.Instance.Connections.Length];
		for (int i = 0; i < base.Instance.Connections.Length; i++)
		{
			_energyLinks[i] = base.Instance.Connections[i];
		}
	}

	public void RestoreData(IConstructible constructible)
	{
		if ((bool)constructible.gameObject && constructible.gameObject.TryGetComponent<EnergyGridConnector>(out var component))
		{
			base.Instance = component;
		}
		else
		{
			Debug.LogException(new Exception("Unable to restore EnergyGridConnector for buildable '" + constructible.Name + "'. It does not have the component attached!"));
		}
	}

	public void RestoreReferences()
	{
		if (base.Instance != null)
		{
			base.Instance.RestoreReferences(this);
		}
	}

	public EnergyGridConnector[] GetEnergyLinks()
	{
		if (_energyLinks.IsNullOrEmpty())
		{
			return null;
		}
		EnergyGridConnector[] array = new EnergyGridConnector[_energyLinks.Length];
		for (int i = 0; i < _energyLinks.Length; i++)
		{
			if (_energyLinks[i].TryReturn(out var instance))
			{
				array[i] = instance;
			}
		}
		return array;
	}
}
