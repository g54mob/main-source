using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/PeristentScriptableObjects")]
public class PersistentPropertiesReferences : ScriptableObject
{
	[Serializable]
	internal class PersistentReference
	{
		[SerializeField]
		internal string Name;

		[SerializeField]
		internal string Type;

		[SerializeField]
		internal PersistentProperties Reference;

		[SerializeField]
		internal string Guid;
	}

	[SerializeField]
	internal PersistentReference[] _persistentReferences;

	[NonSerialized]
	private Dictionary<PersistentProperties.Types, IList<PersistentReference>> _persistentReferencesByType;

	public void Initialize()
	{
		if (_persistentReferencesByType != null)
		{
			return;
		}
		_persistentReferencesByType = new Dictionary<PersistentProperties.Types, IList<PersistentReference>>();
		PersistentReference[] persistentReferences = _persistentReferences;
		foreach (PersistentReference persistentReference in persistentReferences)
		{
			if (_persistentReferencesByType.TryGetValue(persistentReference.Reference.Type, out var value))
			{
				value.Add(persistentReference);
				continue;
			}
			value = new List<PersistentReference>(32);
			value.Add(persistentReference);
			_persistentReferencesByType.Add(persistentReference.Reference.Type, value);
		}
	}

	public bool TryReturnReference<T>(string Guid, out T reference) where T : PersistentProperties
	{
		PersistentReference[] persistentReferences = _persistentReferences;
		foreach (PersistentReference persistentReference in persistentReferences)
		{
			if (persistentReference.Guid == Guid)
			{
				reference = persistentReference.Reference as T;
				return reference != null;
			}
		}
		reference = null;
		return false;
	}

	public bool TryReturnGuid(PersistentProperties reference, out string guid)
	{
		if (reference.IsNull())
		{
			guid = null;
			return false;
		}
		if (_persistentReferencesByType == null || !_persistentReferencesByType.TryGetValue(reference.Type, out var value))
		{
			value = _persistentReferences;
		}
		int count = value.Count;
		for (int i = 0; i < count; i++)
		{
			PersistentReference persistentReference = value[i];
			if (persistentReference.Reference.IsEqual(reference))
			{
				guid = persistentReference.Guid;
				return true;
			}
		}
		guid = null;
		return false;
	}

	public void PopulateReferences<T>(PersistentProperties.Types type, List<T> references) where T : PersistentProperties
	{
		if (!_persistentReferencesByType.TryGetValue(type, out var value))
		{
			return;
		}
		foreach (PersistentReference item2 in value)
		{
			if (item2.Reference is T item)
			{
				references.Add(item);
			}
		}
	}
}
