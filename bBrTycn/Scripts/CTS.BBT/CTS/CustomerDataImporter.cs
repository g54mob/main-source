using System.Collections.Generic;
using NorskaLib.GoogleSheetsDatabase;
using UnityEngine;

namespace CTS
{
	public class CustomerDataImporter : DataImporter
	{
		[PageName("Customers")]
		[HideInInspector]
		public List<CustomerImportData> CustomersData;

		protected override void LoadData()
		{
		}
	}
}
