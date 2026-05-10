using System.Collections.Generic;
using NorskaLib.GoogleSheetsDatabase;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "BalancingSheetData", menuName = "BBT/BalancingSheetData")]
	public class BalancingSheetData : DataContainerBase
	{
		[PageName("Furnitures")]
		public List<FurnitureDataStruct> Furnitures;

		[PageName("Customers")]
		public List<CustomerDataStruct> Customers;
	}
}
