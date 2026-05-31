using System;
using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_MachineMgr_FeatureProductionMode : UI_MachineMgr_MachinePanelFeature<MachineBase>, ILocaleRepaint
	{
		[SerializeField]
		private TMP_Text _textContainer;

		[SerializeField]
		private CTSButton _plusButton;

		[SerializeField]
		private CTSButton _minusButton;

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

		protected void OnDestroy()
		{
			_plusButton.onClick.RemoveListener(OnPlusClicked);
			_minusButton.onClick.RemoveListener(OnMinusClicked);
		}

		private void OnPlusClicked()
		{
			if (base._furniture is MachineBase machineBase)
			{
				SetProductionMode(machineBase, (int)(machineBase.MachineProductionMode + 1));
			}
		}

		private void OnMinusClicked()
		{
			if (base._furniture is MachineBase machineBase)
			{
				SetProductionMode(machineBase, (int)(machineBase.MachineProductionMode - 1));
			}
		}

		private static void SetProductionMode(MachineBase machine, int value)
		{
			value = Math.Clamp(value, 1, 3);
			machine.SetProductionMode((EMachineProductionMode)value);
		}

		protected override bool CanBeDisplayedForFurniture(MachineBase furniture)
		{
			return furniture.MachineProductionMode != EMachineProductionMode.None;
		}

		protected override void OnFurnitureSet(MachineBase furniture)
		{
			furniture.ProductionModeChanged += OnProductionModeChanged;
		}

		protected override void OnFurnitureUnset(MachineBase furniture)
		{
			furniture.ProductionModeChanged -= OnProductionModeChanged;
		}

		protected override void OnRepaint()
		{
			RepaintLocale();
			if (base._furniture is MachineBase machineBase)
			{
				_minusLock.SetLock(machineBase.MachineProductionMode <= EMachineProductionMode.Safe);
				_plusLock.SetLock(machineBase.MachineProductionMode >= EMachineProductionMode.Overclocked);
			}
		}

		private void OnProductionModeChanged()
		{
			Repaint();
		}

		public void RepaintLocale()
		{
			if (base._furniture is MachineBase machineBase)
			{
				if (CTSSingleton<UsableFurnituresManager>.Instance.ProductionModesLocalizations.TryGetValue(machineBase.MachineProductionMode, out var value))
				{
					_textContainer.text = value.GetLocalizedStringSafe();
				}
				else
				{
					_textContainer.text = machineBase.MachineProductionMode.ToString();
				}
			}
		}
	}
}
