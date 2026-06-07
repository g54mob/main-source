using System;
using UnityEngine;
using ZLinq;
using ZLinq.Linq;
using ZLinq.Traversables;

public class GameObjectPool : ObjectPoolBase<GameObject>
{
	private readonly GameObject _original;

	private readonly Transform _parent;

	public GameObjectPool(GameObject original, Transform parent = null)
	{
		if (!original)
		{
			throw new ArgumentNullException("original");
		}
		_original = original;
		_parent = parent;
	}

	public GameObject Rent(Transform parent, bool worldPositionStays = false)
	{
		GameObject gameObject = Rent();
		gameObject.transform.SetParent(parent, worldPositionStays);
		return gameObject;
	}

	public GameObject Rent(Vector3 position, Quaternion rotation)
	{
		GameObject gameObject = Rent();
		gameObject.transform.SetPositionAndRotation(position, rotation);
		return gameObject;
	}

	public GameObject Rent(Vector3 position, Quaternion rotation, Transform parent, bool worldPositionStays = false)
	{
		GameObject gameObject = Rent(parent, worldPositionStays);
		gameObject.transform.SetPositionAndRotation(position, rotation);
		return gameObject;
	}

	protected override GameObject CreateInstance()
	{
		return UnityEngine.Object.Instantiate(_original, _parent);
	}

	protected override void OnRent(GameObject instance)
	{
		instance.SetActive(value: true);
		using ValueEnumerator<OfType<Children<GameObjectTraverser, GameObject>, GameObject, IPoolRentListener>, IPoolRentListener> valueEnumerator = instance.Children().OfType<IPoolRentListener>().GetEnumerator<OfType<Children<GameObjectTraverser, GameObject>, GameObject, IPoolRentListener>, IPoolRentListener>();
		while (valueEnumerator.MoveNext())
		{
			valueEnumerator.Current.OnRent();
		}
	}

	protected override void OnReturn(GameObject instance)
	{
		instance.transform.SetParent(_parent, worldPositionStays: false);
		instance.SetActive(value: false);
		using ValueEnumerator<OfType<Children<GameObjectTraverser, GameObject>, GameObject, IPoolReturnListener>, IPoolReturnListener> valueEnumerator = instance.Children().OfType<IPoolReturnListener>().GetEnumerator<OfType<Children<GameObjectTraverser, GameObject>, GameObject, IPoolReturnListener>, IPoolReturnListener>();
		while (valueEnumerator.MoveNext())
		{
			valueEnumerator.Current.OnReturn();
		}
	}

	protected override void OnDestroy(GameObject instance)
	{
		UnityEngine.Object.Destroy(instance);
	}
}
