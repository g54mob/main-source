using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using ZLinq;
using ZLinq.Linq;
using ZLinq.Traversables;

public class AsyncAddressableGameObjectPool : AsyncObjectPoolBase<GameObject>
{
	private readonly object _key;

	private readonly Transform _parent;

	public AsyncAddressableGameObjectPool(object key, Transform parent = null)
	{
		_key = key ?? throw new ArgumentNullException("key");
		_parent = parent;
	}

	public AsyncAddressableGameObjectPool(AssetReferenceGameObject reference, Transform parent = null)
	{
		if (!reference.RuntimeKeyIsValid())
		{
			throw new ArgumentNullException("reference");
		}
		_key = reference.RuntimeKey;
		_parent = parent;
	}

	public async UniTask<GameObject> RentAsync(Transform parent, bool worldPositionStays = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		GameObject obj = await RentAsync(cancellationToken);
		obj.transform.SetParent(parent, worldPositionStays);
		return obj;
	}

	public async UniTask<GameObject> Rent(Vector3 position, Quaternion rotation, CancellationToken cancellationToken = default(CancellationToken))
	{
		GameObject obj = await RentAsync(cancellationToken);
		obj.transform.SetPositionAndRotation(position, rotation);
		return obj;
	}

	public async UniTask<GameObject> Rent(Vector3 position, Quaternion rotation, Transform parent, bool worldPositionStays = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		GameObject obj = await RentAsync(parent, worldPositionStays, cancellationToken);
		obj.transform.SetPositionAndRotation(position, rotation);
		return obj;
	}

	protected override UniTask<GameObject> CreateInstanceAsync(CancellationToken cancellationToken)
	{
		return Addressables.InstantiateAsync(_key, _parent).ToUniTask(null, PlayerLoopTiming.Update, cancellationToken);
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
