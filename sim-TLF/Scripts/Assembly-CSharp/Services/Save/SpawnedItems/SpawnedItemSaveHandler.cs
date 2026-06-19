using UnityEngine;
using Zenject;

namespace Services.Save.SpawnedItems
{
	public class SpawnedItemSaveHandler : MonoBehaviour
	{
		[SerializeField]
		private string _addressableKey;

		[Inject]
		private SpawnedItemsRegistry _registry;

		[Inject]
		private ISaveService _saveService;

		public string InstanceId { get; private set; }

		public string AddressableKey => _addressableKey;

		public void Init(string instanceId, string addressableKey)
		{
			InstanceId = instanceId;
			_addressableKey = addressableKey;
			_registry.OnSaveStarted += OnSave;
		}

		private void OnDestroy()
		{
			_registry.OnSaveStarted -= OnSave;
			_registry.Untrack(InstanceId);
		}

		private void OnSave()
		{
			_registry.Track(InstanceId, _addressableKey, base.transform.position, base.transform.eulerAngles);
		}
	}
}
