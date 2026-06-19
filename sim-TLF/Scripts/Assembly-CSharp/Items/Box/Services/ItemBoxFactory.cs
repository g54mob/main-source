using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Services.Save.Boxes;
using Services.Save.SpawnedItems;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Items.Box.Services
{
	public class ItemBoxFactory : IItemBoxFactory
	{
		[Inject]
		private DiContainer _diContainer;

		[Inject]
		private SpawnedItemsRegistry _spawnedItemsRegistry;

		private AssetReference _boxPrefabReference;

		public ItemBoxFactory(AssetReference boxPrefabReference)
		{
			_boxPrefabReference = boxPrefabReference;
		}

		public async UniTask<ItemBoxView> CreateItemBox(Vector3 worldPos, List<AssetReference> contentRefs)
		{
			GameObject prefab = await _boxPrefabReference.LoadAssetAsync<GameObject>();
			GameObject gameObject = _diContainer.InstantiatePrefab(prefab, worldPos, Quaternion.identity, null);
			_boxPrefabReference.ReleaseAsset();
			if (!gameObject.TryGetComponent<ItemBoxView>(out var component))
			{
				Debug.LogError("Prefab is missing ItemBoxView component");
				return null;
			}
			component.Init(contentRefs);
			string text = Guid.NewGuid().ToString();
			SpawnedItemSaveHandler spawnedItemSaveHandler = component.AddComponent<SpawnedItemSaveHandler>();
			SpawnedBoxSaveHandler spawnedBoxSaveHandler = component.AddComponent<SpawnedBoxSaveHandler>();
			_diContainer.Inject(spawnedItemSaveHandler);
			_diContainer.Inject(spawnedBoxSaveHandler);
			spawnedItemSaveHandler.Init(text, _boxPrefabReference.RuntimeKey.ToString());
			spawnedBoxSaveHandler.Init(component, text);
			return component;
		}
	}
}
