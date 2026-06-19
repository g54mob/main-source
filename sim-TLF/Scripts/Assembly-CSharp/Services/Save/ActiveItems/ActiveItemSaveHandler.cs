using UnityEngine;
using Zenject;

namespace Services.Save.ActiveItems
{
	public class ActiveItemSaveHandler : MonoBehaviour
	{
		[SerializeField]
		[HideInInspector]
		private string _id;

		[Inject]
		private ActiveItemsSaveRegistry _registry;

		private bool _subscribed;

		private void Awake()
		{
			if (!string.IsNullOrEmpty(_id))
			{
				Subscribe();
			}
		}

		public void Init(string instanceId)
		{
			_id = instanceId;
			Subscribe();
		}

		private void Subscribe()
		{
			if (!_subscribed)
			{
				_subscribed = true;
				_registry.OnSaveStarted += OnSave;
				_registry.OnLoadCompleted += OnLoad;
				OnLoad();
			}
		}

		private void OnDestroy()
		{
			if (_subscribed)
			{
				_registry.OnSaveStarted -= OnSave;
				_registry.OnLoadCompleted -= OnLoad;
			}
		}

		private void OnSave()
		{
			_registry.Save(_id, base.gameObject.activeSelf);
		}

		private void OnLoad()
		{
			if (_registry.TryGet(_id, out var isActive))
			{
				base.gameObject.SetActive(isActive);
			}
		}
	}
}
