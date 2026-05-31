using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class UI_MachineMgr_CategoryCredibility : UI_MachineMgr_CategoryFeature
	{
		[SerializeField]
		private int _defaultValue = 100;

		[SerializeField]
		private ClickAndHoldButton _plusButton;

		[SerializeField]
		private ClickAndHoldButton _minusButton;

		[SerializeField]
		private TMP_Text _countText;

		[SerializeField]
		private InputActionReference _multiAddInput;

		[SerializeField]
		private StringKey _syncKey;

		private readonly LockToggle _plusLock = new LockToggle();

		private readonly LockToggle _minusLock = new LockToggle();

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

		public override void SetDefaultValues()
		{
			base.SetDefaultValues();
			SetCredibility(_defaultValue);
		}

		protected override void OnRepaint()
		{
			int syncedCredibility = GetSyncedCredibility();
			_plusLock.SetLock(syncedCredibility >= 100);
			_minusLock.SetLock(syncedCredibility <= 1);
			_countText.text = syncedCredibility.ToString();
		}

		private void OnPlusButtonTick()
		{
			AddCredibility(1);
		}

		private void OnMinusButtonTick()
		{
			AddCredibility(-1);
		}

		private void AddCredibility(int value)
		{
			if (_multiAddInput.action.inProgress)
			{
				value *= 10;
			}
			SetCredibility(GetSyncedCredibility() + value);
		}

		private void SetCredibility(int credibility)
		{
			credibility = Mathf.Clamp(credibility, 1, 100);
			_syncManager.SetSyncedInt(_category.CategoryData.SyncKey, _syncKey, credibility);
		}

		private int GetSyncedCredibility()
		{
			return _syncManager.GetSyncedInt(_category.CategoryData.SyncKey, _syncKey);
		}
	}
}
