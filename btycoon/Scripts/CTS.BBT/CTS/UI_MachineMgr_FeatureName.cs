using CTS.BBT;
using CTS.Core;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_MachineMgr_FeatureName : UI_MachineMgr_MachinePanelFeature, ILocaleRepaint
	{
		[SerializeField]
		private TMP_Text _nameText;

		public override bool CanBeDisplayedForFurniture(FurnitureInteractor machineBase)
		{
			return true;
		}

		protected override void OnFurnitureSet(FurnitureInteractor machineBase)
		{
		}

		protected override void OnFurnitureUnset(FurnitureInteractor machineBase)
		{
		}

		protected override void OnRepaint()
		{
			if ((object)base._furniture != null)
			{
				_nameText.text = base._furniture.Furniture.Parameters.LocalizationItemSONameKey.GetLocalizedStringSafe();
			}
		}

		public void RepaintLocale()
		{
			Repaint();
		}
	}
}
