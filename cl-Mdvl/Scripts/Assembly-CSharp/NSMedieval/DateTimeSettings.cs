using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class DateTimeSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private ushort daysInSeason;

		[SerializeField]
		private ushort hoursInDay;

		[SerializeField]
		private ushort minutesInHour;

		[SerializeField]
		private List<Season> seasons;

		[SerializeField]
		private uint maxDays;

		[SerializeField]
		private IntRange startingYearRange;

		[SerializeField]
		private ushort statsUpdatePerHour;

		[SerializeField]
		private ushort goalsUpdatePerHour;

		[SerializeField]
		private string[] dayEffectors;

		[SerializeField]
		private float dayEffectorsEnd;

		[SerializeField]
		private string[] nightEffectors;

		[SerializeField]
		private float nightEffectorsEnd;

		[SerializeField]
		private ushort animalIdlePointRelocateHours;

		[SerializeField]
		private List<TraderStockModifiersContainer> stockModifiersBySeason;

		public ushort DaysInSeason => daysInSeason;

		public ushort HoursInDay => hoursInDay;

		public ushort MinutesInHour => minutesInHour;

		public List<Season> Seasons => seasons;

		public uint MaxDays => maxDays;

		public IntRange StartingYearRange => startingYearRange;

		public ushort StatsUpdatePerHour => statsUpdatePerHour;

		public ushort GoalsUpdatePerHour => goalsUpdatePerHour;

		public string[] DayEffectors => dayEffectors;

		public float DayEffectorsEnd => dayEffectorsEnd;

		public string[] NightEffectors => nightEffectors;

		public float NightEffectorsEnd => nightEffectorsEnd;

		public ushort AnimalIdlePointRelocateHours => animalIdlePointRelocateHours;

		public List<TraderStockModifiersContainer> StockModifiersBySeason => stockModifiersBySeason;

		public int MinutesInDay()
		{
			return HoursInDay * MinutesInHour;
		}

		public override string GetID()
		{
			return "DateTimeSettings";
		}
	}
}
