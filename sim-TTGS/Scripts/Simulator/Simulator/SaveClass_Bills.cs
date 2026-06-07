using System;
using Simulator.GameWorld;

namespace Simulator
{
	[Serializable]
	public class SaveClass_Bills
	{
		public RentBill rentBill;

		public ElecBill elecBill;

		public SalariesBill salariesBill;

		public SaveClass_Bills()
		{
			rentBill = (RentBill)BillsSettings.RentBill.Clone();
			elecBill = (ElecBill)BillsSettings.ElecBill.Clone();
			salariesBill = (SalariesBill)BillsSettings.SalariesBill.Clone();
		}
	}
}
