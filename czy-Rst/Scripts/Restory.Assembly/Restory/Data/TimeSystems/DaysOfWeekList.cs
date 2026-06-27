using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.TimeSystems
{
	[CreateAssetMenu(fileName = "DaysOfWeekList", menuName = "Restory/TimeSystemsData/DaysOfWeekList")]
	public class DaysOfWeekList : ScriptableObject
	{
		[SerializeField]
		private List<DayOfWeekInfo> daysOfWeek;

		public List<DayOfWeekInfo> DaysOfWeek => daysOfWeek;
	}
}
