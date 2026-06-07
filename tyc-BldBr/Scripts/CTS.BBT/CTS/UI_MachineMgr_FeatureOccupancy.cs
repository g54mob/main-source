using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class UI_MachineMgr_FeatureOccupancy : UI_MachineMgr_MachinePanelFeature, ILocaleRepaint
	{
		[SerializeField]
		private TMP_Text _textContainer;

		[SerializeField]
		private LocalizedString _occupiedString;

		[SerializeField]
		private LocalizedString _emptyString;

		public override bool CanBeDisplayedForFurniture(FurnitureInteractor furniture)
		{
			return furniture is ICustomerCell;
		}

		protected override void OnFurnitureSet(FurnitureInteractor furniture)
		{
			if (furniture is ICustomerCell customerCell)
			{
				customerCell.VictimChanged += OnVictimChanged;
			}
		}

		protected override void OnFurnitureUnset(FurnitureInteractor furniture)
		{
			if (furniture is ICustomerCell customerCell)
			{
				customerCell.VictimChanged -= OnVictimChanged;
			}
		}

		protected override void OnRepaint()
		{
			if (base._furniture is ICustomerCell customerCell)
			{
				if (customerCell.HasAVictim)
				{
					_textContainer.text = _occupiedString.GetLocalizedStringSafe();
				}
				else
				{
					_textContainer.text = _emptyString.GetLocalizedStringSafe();
				}
			}
		}

		private void OnVictimChanged(Agent obj)
		{
			Repaint();
		}

		public void RepaintLocale()
		{
			Repaint();
		}
	}
}
