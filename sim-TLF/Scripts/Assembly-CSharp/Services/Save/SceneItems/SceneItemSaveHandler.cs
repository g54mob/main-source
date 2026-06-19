using MyBox;
using UnityEngine;
using Zenject;

namespace Services.Save.SceneItems
{
	public class SceneItemSaveHandler : MonoBehaviour
	{
		[SerializeField]
		[ReadOnly(new string[] { })]
		private string _id;

		[Inject]
		private SceneItemsRegistry _registry;

		[Inject]
		private ISaveService _saveService;

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
			_registry.Save(_id, base.transform.position, base.transform.eulerAngles);
		}

		public void OnLoad()
		{
			Debug.Log("[Handler] OnLoad called for " + _id);
			if (_registry.TryGet(_id, out var data))
			{
				Debug.Log($"[Handler] Moving {_id} to {data.Position}");
				base.transform.position = data.Position;
				base.transform.eulerAngles = data.Rotation;
			}
			else
			{
				Debug.LogWarning("[Handler] ID '" + _id + "' not found in registry!");
			}
		}
	}
}
