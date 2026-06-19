using System;
using UI.Inventory;
using UnityEngine;
using Zenject;

namespace Items
{
	public class ProgressiveConsumableItem : UsableConsumableItem, IConsumeProgressable, IConsumeChangeProgressable
	{
		[SerializeField]
		private float _maxProgress = 100f;

		[SerializeField]
		private float _step;

		[SerializeField]
		private float _currentProgress;

		[SerializeField]
		private MeshRenderer _debugMeshRenderer;

		[Inject]
		private readonly IInventoryService _inventoryService;

		[Inject]
		private readonly IInventoryUIService _inventoryUIService;

		public Action OnProgress { get; set; }

		float IConsumeProgressable.MaxProgress => _maxProgress;

		float IConsumeChangeProgressable.CurrentProgress => _currentProgress;

		public override void Equip()
		{
			base.Equip();
		}

		public override void Unequip()
		{
			base.Unequip();
		}

		void IConsumeChangeProgressable.ChangeConsumableProgress()
		{
			if (_currentProgress <= 0f)
			{
				_currentProgress = 0f;
				_consumableObject.TryUnuse();
				return;
			}
			Debug.Log(this);
			if (this != null)
			{
				ChangeProgress((0f - _step) * Time.deltaTime);
			}
			ChangeProgress((0f - _step) * Time.deltaTime);
		}

		private void ChangeProgress(float value)
		{
			_currentProgress += value;
			_consumableObject.Progress();
		}

		void IConsumeChangeProgressable.SetCurrentProgress(float progress)
		{
			_currentProgress = progress;
		}

		private new void OnDestroy()
		{
			Debug.Log("[DESTROY] for " + base.gameObject.name);
		}
	}
}
