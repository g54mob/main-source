using System;
using System.Collections.Generic;
using System.Linq;
using Data.Save;
using Items.Box;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Services.Save.Boxes
{
	public class SpawnedBoxSaveHandler : MonoBehaviour
	{
		private ItemBoxView _box;

		[Inject]
		private BoxesSaveRegistry _registry;

		public string SaveKey { get; private set; }

		public int Priority => 10;

		public void Init(ItemBoxView boxView, string overrideId = null)
		{
			_box = boxView;
			SaveKey = overrideId ?? Guid.NewGuid().ToString();
			_registry.OnSaveStarted += OnSave;
			_registry.OnLoadCompleted += OnLoad;
			OnLoad();
		}

		public void Init(ItemBoxView boxView, string deterministicId, BoxesSaveRegistry registry)
		{
			_registry = registry;
			Init(boxView, deterministicId);
		}

		private void OnDestroy()
		{
			_registry.OnSaveStarted -= OnSave;
			_registry.OnLoadCompleted -= OnLoad;
		}

		public void OnSave()
		{
			_registry.Save(SaveKey, new BoxSaveData
			{
				IsOpen = _box.Opened,
				ContentGUIDs = _box.ContentRefs.Select((AssetReference r) => r.AssetGUID).ToList(),
				Position = (_box.Opened ? Vector3.zero : _box.transform.position)
			});
		}

		public void OnLoad()
		{
			if (_registry.TryGet(SaveKey, out var data))
			{
				List<AssetReference> contentRefs = data.ContentGUIDs.Select((string guid) => new AssetReference(guid)).ToList();
				_box.ApplyState(data, contentRefs);
				if (!data.IsOpen && data.Position != Vector3.zero)
				{
					_box.transform.position = data.Position;
				}
			}
		}
	}
}
