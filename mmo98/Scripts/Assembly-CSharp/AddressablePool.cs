using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using ZLinq;
using ZLinq.Linq;
using ZLinq.Traversables;

public class AddressablePool : ObjectPoolBase<GameObject>
{
	private readonly object _key;

	private readonly Transform _parent;

	public AddressablePool(object key, Transform parent = null)
	{
		_key = key ?? throw new ArgumentNullException("key");
		_parent = parent;
	}

	public AddressablePool(AssetReferenceGameObject reference, Transform parent = null)
	{
		if (!reference.RuntimeKeyIsValid())
		{
			throw new ArgumentNullException("reference");
		}
		_key = reference.RuntimeKey;
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
		return Addressables.InstantiateAsync(_key, _parent).WaitForCompletion();
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
		Addressables.Release(instance);
	}
}
