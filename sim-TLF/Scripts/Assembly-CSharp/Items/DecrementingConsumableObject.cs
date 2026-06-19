using UI.Inventory;
using UnityEngine;
using Zenject;

namespace Items
{
	public class DecrementingConsumableObject : UsableConsumableItem, IConsumeDecremental, IConsumeChangeProgressable
	{
		[SerializeField]
		private int _maxQuantity = 10;

		[SerializeField]
		private int _step = 1;

		[SerializeField]
		private int _currentQuantity;

		[SerializeField]
		private float _progressOfOne;

		[SerializeField]
		private float _currentProgress;

		[Inject]
		private IInventoryUIService _inventoryUIService;

		[Inject]
		private IInventoryService _inventoryService;

		int IConsumeDecremental.MaxQuantity => _maxQuantity;

		int IConsumeDecremental.CurrentQuantity => _currentQuantity;

		float IConsumeDecremental.ProgressOfOne => _progressOfOne;

		float IConsumeChangeProgressable.CurrentProgress => _currentProgress;

		protected override void Start()
		{
			base.Start();
			_currentProgress = 0f;
		}

		public override void Equip()
		{
			if (_currentQuantity > 0)
			{
				base.Equip();
				if (!_inventoryService.Items.Contains(this))
				{
					Debug.Log(this);
					Equip();
				}
				((IConsumeDecremental)this).ChangeQuantity(-1);
				((IConsumeDecremental)this).ResetCurrentProgress();
			}
		}

		void IConsumeDecremental.ChangeQuantity(int quantity)
		{
			_currentQuantity += quantity;
		}

		void IConsumeDecremental.ResetCurrentProgress()
		{
			_currentProgress = _progressOfOne;
		}

		void IConsumeChangeProgressable.ChangeConsumableProgress()
		{
			if (_currentProgress <= 0f)
			{
				Debug.Log("Current Progress Is <= 0");
				_currentProgress = 0f;
				_consumableObject.TryUnuse();
				return;
			}
			Debug.Log(this);
			if (this != null)
			{
				Debug.Log("World Equipable is not null");
				ChangeCurrentProgress();
			}
			ChangeCurrentProgress();
		}

		private void ChangeCurrentProgress()
		{
			_currentProgress -= (float)_step * Time.deltaTime;
			_consumableObject.Progress();
		}

		public void SetCurrentProgress(float progress)
		{
			_currentProgress = 0f;
		}
	}
}
