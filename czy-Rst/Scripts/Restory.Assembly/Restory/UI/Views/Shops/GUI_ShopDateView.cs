using System;
using Restory.Data.Shops;
using Restory.ObjectPools;
using Restory.UserInterface;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Views.Shops
{
	public sealed class GUI_ShopDateView : UIBehaviour, ICleanableComponent
	{
		[SerializeField]
		private GUI_LocalisedText dateText;

		[SerializeField]
		private ShopDateFormat dateFormat;

		public void SetDateTime(TimeSpan timeSpan)
		{
			dateText.LocalizationID = dateFormat.GetLocalizationKey(timeSpan);
		}

		public void Clean()
		{
			dateText.LocalizationID = string.Empty;
		}
	}
}
