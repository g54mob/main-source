using System;
using System.Globalization;
using CTS.BBT.TechTree;
using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class UI_MachineMgr_FeatureUpgrade : UI_MachineMgr_MachinePanelFeature<MachineBase>
	{
		[SerializeField]
		private CTSButton _upgradeButton;

		[SerializeField]
		private TMP_Text _priceText;

		[SerializeField]
		private TMP_Text _maxText;

		[SerializeField]
		private LocalizedString _maxLevelReachedText;

		[SerializeField]
		private LocalizedString _notEnoughMoneyText;

		private LockToggle _buttonLocker = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_buttonLocker.Add(_upgradeButton);
			_upgradeButton.onClick.AddListener(OnButtonClick);
		}

		private void OnDestroy()
		{
			_upgradeButton.onClick.RemoveListener(OnButtonClick);
		}

		protected override bool CanBeDisplayedForFurniture(MachineBase furniture)
		{
			return (object)furniture.MachineUpgrade != null;
		}

		protected override void OnFurnitureSet(MachineBase furniture)
		{
			MoneyHandler.MoneyAmountChanged += OnMoneyAmountChanged;
			TechTreeManager.OnTechnologyResearched += OnTechnologyResearched;
			furniture.MachineUpgrade.MachineUpgraded += OnMachineUpgraded;
		}

		protected override void OnFurnitureUnset(MachineBase furniture)
		{
			MoneyHandler.MoneyAmountChanged -= OnMoneyAmountChanged;
			TechTreeManager.OnTechnologyResearched -= OnTechnologyResearched;
			furniture.MachineUpgrade.MachineUpgraded -= OnMachineUpgraded;
		}

		protected override void OnRepaint()
		{
			if (!(base._furniture is MachineBase machineBase))
			{
				return;
			}
			if (machineBase.MachineUpgrade.upgradeIsDisabled)
			{
				_maxText.gameObject.SetActive(value: true);
				_maxText.text = _maxLevelReachedText.GetLocalizedStringSafe();
				_priceText.text = _maxLevelReachedText.GetLocalizedStringSafe();
				_buttonLocker.Lock();
				_priceText.gameObject.SetActive(value: false);
				_upgradeButton.gameObject.SetActive(value: false);
				return;
			}
			_maxText.gameObject.SetActive(value: false);
			_priceText.gameObject.SetActive(value: true);
			_upgradeButton.gameObject.SetActive(value: true);
			int upgradePrice = machineBase.MachineUpgrade.GetUpgradePrice();
			if (MonoSingleton<MoneyHandler>.Instance.CurrentMoney < upgradePrice)
			{
				_priceText.text = _notEnoughMoneyText.GetLocalizedStringSafe();
				_buttonLocker.Lock();
				return;
			}
			_priceText.text = upgradePrice.ToString("C0", CultureInfo.GetCultureInfo("en-US")).Replace(",", "");
			if ((bool)machineBase.MachineTechTree)
			{
				_buttonLocker.SetLock((int)(TechTreeManager.GetTechnologyResearchLevel(machineBase.MachineTechTree.TechTreeTechnologyRequiered) - 1) <= (int)machineBase.MachineUpgrade.currentLevel);
			}
			else
			{
				_buttonLocker.Unlock();
			}
		}

		private void OnButtonClick()
		{
			if (base._furniture is MachineBase machineBase)
			{
				machineBase.MachineUpgrade.Upgrade();
			}
		}

		private void OnMoneyAmountChanged(int obj)
		{
			SafeRepaint();
		}

		private void OnMachineUpgraded()
		{
			SafeRepaint();
		}

		private void OnTechnologyResearched(TechTreeTechnologySO obj)
		{
			SafeRepaint();
		}

		private void SafeRepaint()
		{
			try
			{
				OnRepaint();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}
}
