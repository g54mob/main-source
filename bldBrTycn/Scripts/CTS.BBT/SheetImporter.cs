using System.Collections.Generic;
using CTS;
using NorskaLib.GoogleSheetsDatabase;
using UnityEngine;

public class SheetImporter : DataContainerBase
{
	[PageName("Furnitures")]
	[SerializeField]
	public List<FurnitureDataStruct> Furnitures;

	[PageName("Customers")]
	[SerializeField]
	public List<CustomerDataStruct> Customers;

	[PageName("WorkerLeveling")]
	[SerializeField]
	public List<WorkerLevelingDataStruct> WorkerLeveling;
}
