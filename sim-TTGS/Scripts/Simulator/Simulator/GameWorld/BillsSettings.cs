using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Shop/Bills", Scope.Project)]
	public class BillsSettings : CustomSettings<BillsSettings>
	{
		[Header("Global")]
		[SerializeField]
		private int m_maxDaysPriceIncrease = 7;

		[Header("Bills")]
		[SerializeField]
		private RentBill m_rentBill;

		[SerializeField]
		private ElecBill m_elecBill;

		[SerializeField]
		private SalariesBill m_salariesBill;

		public static int MaxDaysPriceIncrease => CustomSettings<BillsSettings>.I.m_maxDaysPriceIncrease;

		public static RentBill RentBill => CustomSettings<BillsSettings>.I.m_rentBill;

		public static ElecBill ElecBill => CustomSettings<BillsSettings>.I.m_elecBill;

		public static SalariesBill SalariesBill => CustomSettings<BillsSettings>.I.m_salariesBill;
	}
}
