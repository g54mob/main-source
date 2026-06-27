using System;
using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.TimeSystems
{
	[CreateAssetMenu(fileName = "DayOfWeekInfo", menuName = "Restory/TimeSystemsData/DayOfWeekInfo")]
	public class DayOfWeekInfo : RestoryEntityInfoBase
	{
		[SerializeField]
		private DayOfWeek dayOfWeek;

		[SerializeField]
		private string localizationKey;

		[SerializeField]
		private string shortLocalizationKey;

		public DayOfWeek DayOfWeek => dayOfWeek;

		public string LocalizationKey => localizationKey;

		public string ShortLocalizationKey => shortLocalizationKey;
	}
}
