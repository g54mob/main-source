using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class ChildObjectCache<T> where T : UnityEngine.Object
{
	[SerializeField]
	private T _prefab;

	[SerializeField]
	[ConditionalHide("_spawnParent", false, true)]
	private Transform _parent;

	[SerializeField]
	[Tooltip("When 'Parent' is null a parent Transform will be spawned at the root of the scene.")]
	private bool _spawnParent;

	protected readonly List<T> _instances = new List<T>();

	public IReadOnlyList<T> Instances => _instances;

	public int Count { get; private set; }

	public T this[int index]
	{
		get
		{
			if (Count <= 0 || index < 0 || Count <= index)
			{
				throw new IndexOutOfRangeException();
			}
			return _instances[index];
		}
	}

	public void Reset()
	{
		Count = 0;
		GetParent().gameObject.SetActive(value: true);
	}

	public T Get(out int index)
	{
		index = Count;
		T val;
		while (Count < _instances.Count)
		{
			val = _instances[Count];
			if ((bool)val)
			{
				Count++;
				return val;
			}
			_instances.RemoveAt(Count);
		}
		val = UnityEngine.Object.Instantiate(_prefab, GetParent());
		_instances.Add(val);
		Count = _instances.Count;
		return val;
	}

	public T Get()
	{
		int index;
		return Get(out index);
	}

	public T Get(bool active, out int index)
	{
		T val = Get(out index);
		SetActive(val, active);
		return val;
	}

	public T Get(bool active)
	{
		int index;
		return Get(active, out index);
	}

	public bool Remove(T instance)
	{
		int i = 0;
		for (int count = _instances.Count; i < count; i++)
		{
			if (_instances[i] == instance)
			{
				_instances[i] = _instances[Count - 1];
				_instances[Count - 1] = instance;
				SetActive(instance, active: false);
				int count2 = Count - 1;
				Count = count2;
				return true;
			}
		}
		return false;
	}

	protected abstract void SetActive(T instance, bool active);

	public bool TryGetAtIndex(int index, out T instance)
	{
		instance = ((-1 < index && index < _instances.Count) ? _instances[index] : null);
		return instance;
	}

	public bool TryGetIndex(T instance, out int index)
	{
		for (index = 0; index < _instances.Count; index++)
		{
			if (_instances[index] == instance)
			{
				return true;
			}
		}
		index = -1;
		return false;
	}

	public bool TryFind(Predicate<T> match, out T instance)
	{
		instance = _instances.Find(match);
		return instance != null;
	}

	public void Trim()
	{
		int num = Count;
		while (num < _instances.Count)
		{
			T val = _instances[num];
			if ((bool)val)
			{
				SetActive(val, active: false);
				num++;
			}
			else
			{
				_instances.RemoveAt(num);
			}
		}
	}

	public void DeactivateParent()
	{
		if ((bool)_parent)
		{
			_parent.gameObject.SetActive(value: false);
		}
	}

	private Transform GetParent()
	{
		return _parent;
	}
}
