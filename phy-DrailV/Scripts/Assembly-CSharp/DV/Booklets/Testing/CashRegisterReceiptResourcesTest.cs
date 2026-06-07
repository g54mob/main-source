using System.Collections.Generic;
using UnityEngine;

namespace DV.Booklets.Testing
{
	public class CashRegisterReceiptResourcesTest : ABookletTest
	{
		public List<CashRegisterModule> locoResourceModules;

		protected override GameObject CreateBooklet()
		{
			List<CashRegisterModule.CashRegisterModuleData> list = new List<CashRegisterModule.CashRegisterModuleData>();
			foreach (CashRegisterModule locoResourceModule in locoResourceModules)
			{
				list.Add(locoResourceModule.Data);
			}
			return BookletCreator_CashRegisterReceipt.Create(list, base.transform.position, base.transform.rotation, base.transform);
		}
	}
}
