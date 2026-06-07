using CTS.BBT;
using CTS.Core;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class UI_MachineMgr_FeatureLevel : UI_MachineMgr_MachinePanelFeature
	{
		[SerializeField]
		private TMP_Text _levelText;

		[SerializeField]
		private bool _displayLevelText;

		[SerializeField]
		[ShowIf("_displayLevelText")]
		private LocalizedString _levelLocalizedString;

		public override bool CanBeDisplayedForFurniture(FurnitureInteractor furniture)
		{
			if (!(furniture is MachineBase machineBase))
			{
				return false;
			}
			return (object)machineBase.MachineUpgrade != null;
		}

		protected override void OnFurnitureSet(FurnitureInteractor furniture)
		{
			if (furniture is MachineBase { MachineUpgrade: not null } machineBase)
			{
				machineBase.MachineUpgrade.MachineUpgraded += OnMachineUpgraded;
			}
		}

		protected override void OnFurnitureUnset(FurnitureInteractor furniture)
		{
			if (furniture is MachineBase { MachineUpgrade: not null } machineBase)
			{
				machineBase.MachineUpgrade.MachineUpgraded -= OnMachineUpgraded;
			}
		}

		private void OnMachineUpgraded()
		{
			OnRepaint();
		}

		protected override void OnRepaint()
		{
			if (base._furniture is MachineBase { MachineUpgrade: not null } machineBase)
			{
				string text = ((int)(machineBase.MachineUpgrade.currentLevel + 1)).ToString();
				if (_displayLevelText)
				{
					_levelText.text = _levelLocalizedString.GetLocalizedStringSafe() + " " + text;
				}
				else
				{
					_levelText.text = text;
				}
			}
		}
	}
}
