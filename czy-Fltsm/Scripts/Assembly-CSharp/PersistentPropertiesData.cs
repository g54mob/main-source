using System;
using System.Collections.Generic;

[Serializable]
public class PersistentPropertiesData
{
	private readonly List<string> _persistentPropertiesGuids = new List<string>();

	[NonSerialized]
	private PersistentPropertiesReferences _properties;

	public PersistentPropertiesData(PersistentPropertiesReferences properties)
	{
		_properties = properties;
	}

	public void Restore(PersistentPropertiesReferences properties)
	{
		_properties = properties;
	}

	public int PersistReference(PersistentProperties reference)
	{
		if (_properties.TryReturnGuid(reference, out var guid))
		{
			for (int i = 0; i < _persistentPropertiesGuids.Count; i++)
			{
				if (guid == _persistentPropertiesGuids[i])
				{
					return i;
				}
			}
			int count = _persistentPropertiesGuids.Count;
			_persistentPropertiesGuids.Add(guid);
			return count;
		}
		return -1;
	}

	public bool TryReturnPersistedIndex(PersistentProperties reference, out int index)
	{
		if (_properties.TryReturnGuid(reference, out var guid))
		{
			for (int i = 0; i < _persistentPropertiesGuids.Count; i++)
			{
				if (guid == _persistentPropertiesGuids[i])
				{
					index = i;
					return true;
				}
			}
		}
		index = -1;
		return false;
	}

	public bool TryReturnReference<T>(int index, out T reference) where T : PersistentProperties
	{
		reference = null;
		if (index < 0)
		{
			return false;
		}
		if (index >= _persistentPropertiesGuids.Count)
		{
			return false;
		}
		return _properties.TryReturnReference<T>(_persistentPropertiesGuids[index], out reference);
	}
}
