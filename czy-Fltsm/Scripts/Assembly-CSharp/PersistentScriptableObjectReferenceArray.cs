using System;
using UnityEngine;

[Serializable]
public class PersistentScriptableObjectReferenceArray<T> where T : ScriptableObject
{
	[SerializeField]
	private T[] _references;

	public int ReturnReferenceIndex(T reference)
	{
		int num = _references.Length;
		for (int i = 0; i < num; i++)
		{
			if (_references[i] == reference)
			{
				return i;
			}
		}
		return -1;
	}

	public bool TryReturnReferenceIndex(T reference, out int index)
	{
		int num = _references.Length;
		for (int i = 0; i < num; i++)
		{
			if (_references[i] == reference)
			{
				index = i;
				return true;
			}
		}
		index = -1;
		return false;
	}

	public T ReturnReference(int index)
	{
		if (-1 < index && index < _references.Length)
		{
			return _references[index];
		}
		return null;
	}

	public bool TryReturnReference(int index, out T reference)
	{
		if (-1 < index && index < _references.Length)
		{
			reference = _references[index];
			return true;
		}
		reference = null;
		return false;
	}
}
