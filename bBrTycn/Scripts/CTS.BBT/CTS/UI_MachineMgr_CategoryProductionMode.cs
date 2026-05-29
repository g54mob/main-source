using System;
using CTS.BBT;
using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_MachineMgr_CategoryProductionMode : UI_MachineMgr_CategoryFeature, ILocaleRepaint
	{
		[SerializeField]
		private TMP_Text _textContainer;

		[SerializeField]
		private CTSButton _plusButton;

		[SerializeField]
		private CTSButton _minusButton;

		[SerializeField]
		private StringKey _syncKey;

		private readonly LockToggle _plusLock = new LockToggle();

		private readonly LockToggle _minusLock = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_plusButton.onClick.AddListener(OnPlusClicked);
			_minusButton.onClick.AddListener(OnMinusClicked);
			_plusLock.Add(_plusButton);
			_minusLock.Add(_minusButton);
		}

		public override void SetDefaultValues()
		{
			base.SetDefaultValues();
			if (_category.CategoryData.AssociatedFurniture.Prefab.GetComponent<FurnitureInteractor>() is MachineBase machineBase)
			{
				SetSyncedValue(machineBase.MachineProductionMode);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_plusButton.onClick.RemoveListener(OnPlusClicked);
			_minusButton.onClick.RemoveListener(OnMinusClicked);
		}

		private void OnPlusClicked()
		{
			SetProductionMode(GetSyncedValue() + 1);
		}

		private void OnMinusClicked()
		{
			SetProductionMode(GetSyncedValue() - 1);
		}

		private void SetProductionMode(EMachineProductionMode value)
		{
			value = (EMachineProductionMode)Math.Clamp((int)value, 1, 3);
			SetSyncedValue(value);
		}

		protected override void OnRepaint()
		{
			RepaintLocale();
			EMachineProductionMode syncedValue = GetSyncedValue();
			_minusLock.SetLock(syncedValue <= EMachineProductionMode.Safe);
			_plusLock.SetLock(syncedValue >= EMachineProductionMode.Overclocked);
		}

		private void SetSyncedValue(EMachineProductionMode value)
		{
			_syncManager.SetSyncedInt(_category.CategoryData.SyncKey, _syncKey, (int)value);
		}

		private EMachineProductionMode GetSyncedValue()
		{
			return (EMachineProductionMode)_syncManager.GetSyncedInt(_category.CategoryData.SyncKey, _syncKey);
		}

		public void RepaintLocale()
		{
			EMachineProductionMode syncedValue = GetSyncedValue();
			if (CTSSingleton<UsableFurnituresManager>.Instance.ProductionModesLocalizations.TryGetValue(syncedValue, out var value))
			{
				_textContainer.text = value.GetLocalizedStringSafe();
			}
			else
			{
				_textContainer.text = syncedValue.ToString();
			}
		}
	}
}
