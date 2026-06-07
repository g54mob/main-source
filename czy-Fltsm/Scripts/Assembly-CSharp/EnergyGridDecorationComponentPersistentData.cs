using System;
using UnityEngine;

[Serializable]
public class EnergyGridDecorationComponentPersistentData : PersistentReference<EnergyGridConnector>, IEnergyGridComponentPersistentData
{
	public PersistentReference<EnergyGrid>.Reference EnergyGrid;

	public Reference[] EnergyLinks;

	PersistentReference<EnergyGrid>.Reference IEnergyGridComponentPersistentData.EnergyGridReference => EnergyGrid;

	public EnergyGridDecorationComponentPersistentData(EnergyGridDecorationComponent component)
		: base((EnergyGridConnector)component)
	{
		base.Instance = component;
	}

	public void RestoreData(Decoration decoration)
	{
		if (base.Instance == null)
		{
			base.Instance = decoration.GetComponent<EnergyGridConnector>();
		}
	}

	public void RestoreReferences()
	{
		if ((bool)base.Instance)
		{
			base.Instance.RestoreReferences(this);
		}
		else
		{
			Debug.LogException(new Exception("Unable to invoke EnergyGridConnector.RestoreReferences because the EnergyGridConnector instance is 'NULL'"));
		}
	}

	public void PopulateReferences()
	{
		EnergyGrid = base.Instance.EnergyGrid;
		if (!base.Instance.Connections.IsNullOrEmpty())
		{
			EnergyLinks = new Reference[base.Instance.Connections.Length];
			for (int i = 0; i < base.Instance.Connections.Length; i++)
			{
				EnergyLinks[i] = base.Instance.Connections[i];
			}
		}
	}

	EnergyGridConnector[] IEnergyGridComponentPersistentData.GetEnergyLinks()
	{
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
