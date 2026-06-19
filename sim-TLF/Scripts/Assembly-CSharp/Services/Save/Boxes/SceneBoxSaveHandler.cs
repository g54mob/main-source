using System.Collections.Generic;
using System.Linq;
using Data.Save;
using Items.Box;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Services.Save.Boxes
{
	public class SceneBoxSaveHandler : MonoBehaviour
	{
		[SerializeField]
		[HideInInspector]
		private string _id;

		[SerializeField]
		private ItemBoxView _box;

		[Inject]
		private BoxesSaveRegistry _registry;

		public string SaveKey => _id;

		public int Priority => 10;

		private void Awake()
		{
			_registry.OnSaveStarted += OnSave;
			_registry.OnLoadCompleted += OnLoad;
		}

		private void OnDestroy()
		{
			_registry.OnSaveStarted -= OnSave;
			_registry.OnLoadCompleted -= OnLoad;
		}

		public void OnSave()
		{
			_registry.Save(_id, new BoxSaveData
			{
				IsOpen = _box.Opened,
				ContentGUIDs = _box.ContentRefs.Select((AssetReference r) => r.AssetGUID).ToList()
			});
		}

		public void OnLoad()
		{
			if (_registry.TryGet(_id, out var data))
			{
				List<AssetReference> contentRefs = data.ContentGUIDs.Select((string guid) => new AssetReference(guid)).ToList();
				_box.ApplyState(data, contentRefs);
			}
		}
	}
}
