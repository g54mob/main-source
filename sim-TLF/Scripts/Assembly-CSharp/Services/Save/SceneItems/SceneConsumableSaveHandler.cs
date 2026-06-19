using Items;
using UnityEngine;
using Zenject;

namespace Services.Save.SceneItems
{
	public class SceneConsumableSaveHandler : MonoBehaviour
	{
		[Inject]
		private SceneConsumablesRegistry _registry;

		private string _id;

		private IConsumeChangeProgressable _progressable;

		private IConsumeDecremental _decremental;

		private void Awake()
		{
			if (TryGetComponent<SceneItemSaveHandler>(out var component))
			{
				_id = component.SaveKey;
			}
			else
			{
				Debug.LogError("[SceneConsumableSaveHandler] SceneItemSaveHandler not found on " + base.gameObject.name + "! Add it first.");
			}
			_progressable = GetComponent<IConsumeChangeProgressable>();
			_decremental = GetComponent<IConsumeDecremental>();
			_registry.OnSaveStarted += OnSave;
			_registry.OnLoadCompleted += OnLoad;
		}

		private void OnDestroy()
		{
			_registry.OnSaveStarted -= OnSave;
			_registry.OnLoadCompleted -= OnLoad;
		}

		private void OnSave()
		{
			if (_progressable != null)
			{
				ConsumableData data = new ConsumableData
				{
					CurrentProgress = _progressable.CurrentProgress,
					CurrentQuantity = (_decremental?.CurrentQuantity ?? 0),
					ConsumableType = ((_decremental != null) ? "decrementing" : "progressive")
				};
				_registry.Save(_id, data);
				Debug.Log($"[SceneConsumableSaveHandler] Saved '{_id}': progress={data.CurrentProgress}, qty={data.CurrentQuantity}");
			}
		}

		private void OnLoad()
		{
			Debug.Log("[SceneConsumableSaveHandler] OnLoad called for '" + _id + "'");
			if (!_registry.TryGet(_id, out var data))
			{
				Debug.LogWarning("[SceneConsumableSaveHandler] ID '" + _id + "' not found in registry.");
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
				Debug.Log("[SceneConsumableSaveHandler] Applied decrementing default");
			}
			else if (_progressable != null)
			{
				_progressable?.SetCurrentProgress(100f);
				Debug.Log("[SceneConsumableSaveHandler] Applied progressive default");
			}
		}

		private void ApplyData(ConsumableData data)
		{
			if (data.ConsumableType == "decrementing" && _decremental != null)
			{
				int num = data.CurrentQuantity - _decremental.CurrentQuantity;
				if (num != 0)
				{
					_decremental.ChangeQuantity(num);
				}
				_decremental.ResetCurrentProgress();
				Debug.Log($"[SceneConsumableSaveHandler] Applied decrementing: qty={data.CurrentQuantity}");
			}
			else if (data.ConsumableType == "progressive")
			{
				_progressable?.SetCurrentProgress(data.CurrentProgress);
				Debug.Log($"[SceneConsumableSaveHandler] Applied progressive: progress={data.CurrentProgress}");
			}
		}
	}
}
