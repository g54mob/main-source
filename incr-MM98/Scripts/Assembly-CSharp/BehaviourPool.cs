using System;
using UnityEngine;
using ZLinq;
using ZLinq.Linq;
using ZLinq.Traversables;

public class BehaviourPool<T> : ObjectPoolBase<T> where T : Behaviour
{
	private readonly T _original;

	private readonly Transform _parent;

	public BehaviourPool(T original, Transform parent = null)
	{
		if (!original)
		{
			throw new ArgumentNullException("original");
		}
		_original = original;
		_parent = parent;
	}

	public T Rent(Transform parent, bool worldPositionStays = false)
	{
		T val = Rent();
		val.transform.SetParent(parent, worldPositionStays);
		return val;
	}

	public T Rent(Vector3 position, Quaternion rotation)
	{
		T val = Rent();
		val.transform.SetPositionAndRotation(position, rotation);
		return val;
	}

	public T Rent(Vector3 position, Quaternion rotation, Transform parent, bool worldPositionStays = false)
	{
		T val = Rent(parent, worldPositionStays);
		val.transform.SetPositionAndRotation(position, rotation);
		return val;
	}

	protected override T CreateInstance()
	{
		return UnityEngine.Object.Instantiate(_original, _parent);
	}

	protected override void OnRent(T instance)
	{
		instance.gameObject.SetActive(value: true);
		using ValueEnumerator<OfType<Children<GameObjectTraverser, GameObject>, GameObject, IPoolRentListener>, IPoolRentListener> valueEnumerator = instance.gameObject.Children().OfType<IPoolRentListener>().GetEnumerator<OfType<Children<GameObjectTraverser, GameObject>, GameObject, IPoolRentListener>, IPoolRentListener>();
		while (valueEnumerator.MoveNext())
		{
			valueEnumerator.Current.OnRent();
		}
	}

	protected override void OnReturn(T instance)
	{
		instance.transform.SetParent(_parent, worldPositionStays: false);
		instance.gameObject.SetActive(value: false);
		using ValueEnumerator<OfType<Children<GameObjectTraverser, GameObject>, GameObject, IPoolReturnListener>, IPoolReturnListener> valueEnumerator = instance.gameObject.Children().OfType<IPoolReturnListener>().GetEnumerator<OfType<Children<GameObjectTraverser, GameObject>, GameObject, IPoolReturnListener>, IPoolReturnListener>();
		while (valueEnumerator.MoveNext())
		{
			valueEnumerator.Current.OnReturn();
		}
	}

	protected override void OnDestroy(T instance)
	{
		if (Application.isPlaying)
		{
			UnityEngine.Object.Destroy(instance);
		}
		else
		{
			UnityEngine.Object.DestroyImmediate(instance);
		}
	}
}
