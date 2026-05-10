using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_MachineMgr_CategoryBloodQuality : UI_MachineMgr_CategoryFeature
	{
		[SerializeField]
		private int _defaultValue = 1;

		[SerializeField]
		private ClickAndHoldButton _plusButton;

		[SerializeField]
		private ClickAndHoldButton _minusButton;

		[SerializeField]
		private TMP_Text _qualityText;

		[SerializeField]
		private StringKey _syncKey;

		private readonly LockToggle _plusLock = new LockToggle();

		private readonly LockToggle _minusLock = new LockToggle();

		public override void SetDefaultValues()
		{
			base.SetDefaultValues();
			SetSyncedQuality(_defaultValue);
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
			int syncedQuality = GetSyncedQuality();
			_plusLock.SetLock(syncedQuality >= 10);
			_minusLock.SetLock(syncedQuality <= 1);
			_qualityText.text = syncedQuality.ToString();
		}

		private void OnMinusButtonTick()
		{
			SetSyncedQuality(GetSyncedQuality() - 1);
		}

		private void OnPlusButtonTick()
		{
			SetSyncedQuality(GetSyncedQuality() + 1);
		}

		private void SetSyncedQuality(int quality)
		{
			_syncManager.SetSyncedInt(_category.CategoryData.SyncKey, _syncKey, quality);
		}

		private int GetSyncedQuality()
		{
			return _syncManager.GetSyncedInt(_category.CategoryData.SyncKey, _syncKey);
		}
	}
}
