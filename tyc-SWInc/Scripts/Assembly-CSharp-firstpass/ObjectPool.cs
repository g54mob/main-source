using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T>
{
	[NonSerialized]
	private HashList<T> _pool = new HashList<T>();

	[NonSerialized]
	public HashSet<T> Active = new HashSet<T>();

	private Action<T> _activate;

	private Action<T> _deactivate;

	private Func<T> _create;

	public ObjectPool(Func<T> create, Action<T> activate = null, Action<T> deactivate = null)
	{
		_activate = activate;
		_deactivate = deactivate;
		_create = create;
	}

	public T Get()
	{
		T val = ((_pool.Count > 0) ? Pop() : _create());
		Action<T> activate = _activate;
		if (activate != null)
		{
			activate(val);
		}
		Active.Add(val);
		return val;
	}

	public void Claim(T o)
	{
		Active.Remove(o);
		_pool.Remove(o);
	}

	private T Pop()
	{
		T result = _pool[_pool.Count - 1];
		_pool.RemoveAt(_pool.Count - 1);
		return result;
	}

	public void Release(T o, bool ignoreReleased = false)
	{
		_pool.Add(o);
		if (!Active.Remove(o) && !ignoreReleased)
		{
			Debug.Log("Released object to pool that was never activated");
		}
		Action<T> deactivate = _deactivate;
		if (deactivate != null)
		{
			deactivate(o);
		}
	}

	public void ReleaseAll()
	{
		if (Active.Count <= 0)
		{
			return;
		}
		bool flag = _deactivate != null;
		foreach (T item in Active)
		{
			if (flag)
			{
				_deactivate(item);
			}
			_pool.Add(item);
		}
		Active.Clear();
	}
}
