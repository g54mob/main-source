using System.Collections.Generic;
using NorskaLib.GoogleSheetsDatabase;
using UnityEngine;

[CreateAssetMenu(fileName = "CreditDataSheet", menuName = "Sheet/CreditDataSheet")]
public class CreditSheetImporter : DataContainerBase
{
	[PageName("Worker")]
	[SerializeField]
	public List<CreditImportStruct> Worker;

	[PageName("HierarchyJob")]
	[SerializeField]
	public List<HierarchyImportStruct> HierarchyJob;
}
