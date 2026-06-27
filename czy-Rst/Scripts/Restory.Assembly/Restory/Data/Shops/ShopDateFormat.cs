using System;
using UnityEngine;

namespace Restory.Data.Shops
{
	[CreateAssetMenu(menuName = "Restory/Shops/ShopDateFormat", fileName = "Name - ShopDateFormat")]
	public sealed class ShopDateFormat : ScriptableObject
	{
		[SerializeField]
		private string todayLocalizationKey = "GUI_TODAY";

		[SerializeField]
		private string yesterdayLocalizationKey = "GUI_YESTERDAY";

		[SerializeField]
		private string weekLocalizationKey = "GUI_TOMORROW";

		[SerializeField]
		private string moreWeekLocalizationKey = "GUI_MONTH";

		public string GetLocalizationKey(TimeSpan timeSpan)
		{
			if (timeSpan.TotalDays < 1.0)
			{
				return todayLocalizationKey;
			}
			if (timeSpan.TotalDays < 2.0)
			{
				return yesterdayLocalizationKey;
			}
			if (timeSpan.TotalDays < 7.0)
			{
				return weekLocalizationKey;
			}
			return moreWeekLocalizationKey;
		}
	}
}
