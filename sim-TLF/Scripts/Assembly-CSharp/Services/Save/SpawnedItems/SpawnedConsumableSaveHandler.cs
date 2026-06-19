using Items;
using Services.Save.Consumables;
using UnityEngine;
using Zenject;

namespace Services.Save.SpawnedItems
{
	public class SpawnedConsumableSaveHandler : MonoBehaviour
	{
		[Inject]
		private SpawnedConsumablesRegistry _registry;

		private string _instanceId;

		private IConsumeChangeProgressable _progressable;

		private IConsumeDecremental _decremental;

		public void Init(string instanceId)
		{
			_instanceId = instanceId;
			_progressable = GetComponent<IConsumeChangeProgressable>();
			_decremental = GetComponent<IConsumeDecremental>();
			_registry.OnSaveStarted += OnSave;
			_registry.OnLoadCompleted += OnLoad;
			OnLoad();
		}

		private void OnDestroy()
		{
			if (_registry != null)
			{
				_registry.OnSaveStarted -= OnSave;
				_registry.OnLoadCompleted -= OnLoad;
			}
		}

		private void OnSave()
		{
			if (_progressable != null)
			{
				SpawnedConsumableData data = new SpawnedConsumableData
				{
					CurrentProgress = _progressable.CurrentProgress,
					CurrentQuantity = (_decremental?.CurrentQuantity ?? 0),
					ConsumableType = ((_decremental != null) ? "decrementing" : "progressive")
				};
				_registry.Save(_instanceId, data);
				Debug.Log($"[SpawnedConsumableSaveHandler] Saved '{_instanceId}': progress={data.CurrentProgress}, qty={data.CurrentQuantity}");
			}
		}

		private void OnLoad()
		{
			Debug.Log("[SpawnedConsumableSaveHandler] OnLoad called for '" + _instanceId + "'");
			if (!_registry.TryGet(_instanceId, out var data))
			{
				Debug.LogWarning("[SpawnedConsumableSaveHandler] No data for '" + _instanceId + "'.");
				ApplyDefaultData();
			}
			else
			{
				ApplyData(data);
			}
		}

		private void ApplyDefaultData()
		{
			if (_decremental != null)
			{
				_decremental.ChangeQuantity(10);
				_decremental.ResetCurrentProgress();
				Debug.Log("[SpawnedConsumableSaveHandler] Applied default quantity");
			}
			else if (_progressable != null)
			{
				_progressable.SetCurrentProgress(100f);
				Debug.Log("[SpawnedConsumableSaveHandler] Applied default progress");
			}
		}

		private void ApplyData(SpawnedConsumableData data)
		{
			if (data.ConsumableType == "decrementing" && _decremental != null)
			{
				int num = data.CurrentQuantity - _decremental.CurrentQuantity;
				if (num != 0)
				{
					_decremental.ChangeQuantity(num);
				}
				_decremental.ResetCurrentProgress();
				Debug.Log($"[SpawnedConsumableSaveHandler] Applied decrementing: qty={data.CurrentQuantity}");
			}
			else if (data.ConsumableType == "progressive")
			{
				_progressable.SetCurrentProgress(data.CurrentProgress);
				Debug.Log($"[SpawnedConsumableSaveHandler] Applied progressive: progress={data.CurrentProgress}");
			}
		}
	}
}
