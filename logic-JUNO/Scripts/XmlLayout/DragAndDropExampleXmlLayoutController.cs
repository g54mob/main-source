using UI.Tables;
using UI.Xml;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

internal class DragAndDropExampleXmlLayoutController : XmlLayoutController
{
	private void ItemDropped(XmlElement droppedItem, XmlElement cell)
	{
		if (cell.HasClass("itemCell") && droppedItem.HasClass("item"))
		{
			droppedItem.parentElement.RemoveChildElement(droppedItem);
			cell.AddChildElement(droppedItem);
			TableCell component = cell.GetComponent<TableCell>();
			base.xmlLayout.GetElementById<Text>("debugText").text = $"Item '{droppedItem.name}' dropped on cell '{GetCellPositionString(component)}' in table '{GetTableName(component)}'";
		}
	}

	private string GetCellPositionString(TableCell cell)
	{
		TableRow row = cell.GetRow();
		int num = row.GetTable().Rows.IndexOf(row) + 1;
		int num2 = row.Cells.IndexOf(cell) + 1;
		return $"{num},{num2}";
	}

	private string GetTableName(TableCell cell)
	{
		return cell.GetRow().GetTable().name;
	}

	private void ReturnToMainExamples()
	{
		base.xmlLayout.Hide(delegate
		{
			SceneManager.LoadSceneAsync("ExampleScene");
		});
	}

	private void Awake()
	{
		base.xmlLayout.Show();
	}
}
