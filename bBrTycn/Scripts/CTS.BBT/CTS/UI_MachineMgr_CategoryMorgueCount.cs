using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_MachineMgr_CategoryMorgueCount : UI_MachineMgr_CategoryFeature
	{
		[SerializeField]
		private int _maxValue = 9;

		[SerializeField]
		private ClickAndHoldButton _plusButton;

		[SerializeField]
		private ClickAndHoldButton _minusButton;

		[SerializeField]
		private TMP_Text _textContainer;

		[SerializeField]
		private StringKey _syncKey;

		private readonly LockToggle _plusLock = new LockToggle();

		private readonly LockToggle _minusLock = new LockToggle();

		public override void SetDefaultValues()
		{
			base.SetDefaultValues();
			SetSyncedValue(_maxValue);
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			_plusButton.HeldTick += OnPlusButtonTick;
			_minusButton.HeldTick += OnMinusButtonTick;
			_plusLock.Add(_plusButton);
			_minusLock.Add(_minusButton);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_plusButton.HeldTick -= OnPlusButtonTick;
			_minusButton.HeldTick -= OnMinusButtonTick;
		}

		protected override void OnRepaint()
		{
			int syncedValue = GetSyncedValue();
			_plusLock.SetLock(syncedValue >= _maxValue);
			_minusLock.SetLock(syncedValue <= 1);
			_textContainer.text = syncedValue.ToString();
		}

		private void OnMinusButtonTick()
		{
			SetSyncedValue(GetSyncedValue() - 1);
		}

		private void OnPlusButtonTick()
		{
			SetSyncedValue(GetSyncedValue() + 1);
		}

		private void SetSyncedValue(int value)
		{
			_syncManager.SetSyncedInt(_category.CategoryData.SyncKey, _syncKey, value);
		}

		private int GetSyncedValue()
		{
			return _syncManager.GetSyncedInt(_category.CategoryData.SyncKey, _syncKey);
		}
	}
}
