using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreatePanels : MonoBehaviour
{
	public const int DECIMALS_ROUNDED = 5;

	public const int MONOSPACE_SIZE = 11;

	[SerializeField]
	private GameObject windowPanelPrefab;

	[SerializeField]
	private GameObject dataCellPrefab;

	[SerializeField]
	private GameObject rowPrefab;

	[SerializeField]
	private GameObject columnNamePrefab;

	[SerializeField]
	private NotificationHandler notificationHandler;

	[SerializeField]
	private PanelManager tableManager;

	private GameObject notification;

	public GameObject CreateGivenPanel(string name)
	{
		return CreatePanel(name, canDelete: false, canRename: false, save: true);
	}

	public GameObject CreateDeletablePanel(string name)
	{
		return CreatePanel(name, canDelete: true, canRename: false, save: true);
	}

	public GameObject CreateUserPanel(string name, bool save)
	{
		GameObject gameObject = CreatePanel(name, canDelete: true, canRename: true, save);
		if (gameObject.GetComponent<RectTransform>().rect.width > (float)Screen.width)
		{
			if (!tableManager.DestroyPanel(name))
			{
				Object.Destroy(gameObject);
			}
			throw new IllegalQueryException("Search results cannot fit in your window. Please select less columns or shorten the length of column names.");
		}
		return gameObject;
	}

	private GameObject CreatePanel(string name, bool canDelete, bool canRename, bool save)
	{
		if (!tableManager.OpenPanel(name))
		{
			Table tableData = DatabaseUtils.GetTableData(name);
			Debug.Log("Number of rows in " + name + ": " + tableData.RowCount());
			if (tableData.RowCount() > 50000 || tableData.IsEmpty())
			{
				if (tableData.RowCount() > 50000)
				{
					throw new IllegalQueryException("Too many rows selected. Try to limit the amount of query results.");
				}
				throw new EmptyResultException("Nothing was found in the database using your query.");
			}
			GameObject gameObject = GeneratePanel(tableData, name);
			if (save)
			{
				tableManager.ManagePanel(name, gameObject, canDelete, canRename);
			}
			return gameObject;
		}
		return tableManager.GetPanel(name);
	}

	private GameObject GeneratePanel(Table data, string name)
	{
		string[] columnNames = data.GetColumnNames();
		List<string[]> rows = data.GetRows();
		GameObject gameObject = Object.Instantiate(windowPanelPrefab, base.transform.position, Quaternion.identity, base.transform);
		UIUtils.SetPenultimateLayer(gameObject);
		Transform transform = gameObject.transform.Find("Data Scroll View/Viewport/Row Container");
		RectTransform component = gameObject.GetComponent<RectTransform>();
		TextMeshProUGUI component2 = Object.Instantiate(rowPrefab, transform).GetComponent<TextMeshProUGUI>();
		component2.gameObject.name = "Row 0";
		int[] maxLengthPerColumn = data.GetMaxLengthPerColumn();
		BuildText(rows, component2, transform, columnNames, maxLengthPerColumn);
		Transform parent = gameObject.transform.Find("Column Names");
		string text = "";
		TextMeshProUGUI component3 = Object.Instantiate(columnNamePrefab, parent).GetComponent<TextMeshProUGUI>();
		for (int i = 0; i < columnNames.Length; i++)
		{
			string text2 = columnNames[i];
			text = ((i != columnNames.Length - 1 || columnNames.Length == 1 || maxLengthPerColumn[i] <= columnNames[i].Length) ? (text + InsertLink(text2.PadRight(getCellPadding(maxLengthPerColumn[i], columnNames[i].Length)), text2, isLeft: false)) : (text + InsertLink(text2.PadLeft(getCellPadding(maxLengthPerColumn[i], columnNames[i].Length) - 3), text2, isLeft: true)));
		}
		component3.text = text;
		gameObject.name = name;
		Panel component4 = gameObject.GetComponent<Panel>();
		component4.SetToolbarName(name);
		SetWindowSizeHorizontal(component, component2.preferredWidth, component3.preferredWidth, component4.GetToolbarNameObject().preferredWidth);
		SetWindowSizeVertical(component, rows.Count);
		return gameObject;
	}

	private void BuildText(List<string[]> rowData, TextMeshProUGUI rowText, Transform rowContainer, string[] columnNames, int[] maxColumnLengths)
	{
		int num = 1;
		int num2 = 0;
		foreach (string[] rowDatum in rowData)
		{
			if (num2 >= 500)
			{
				rowText = Object.Instantiate(rowPrefab, rowContainer).GetComponent<TextMeshProUGUI>();
				rowText.name = $"Row {num++}";
				num2 = 0;
			}
			string text = "";
			for (int i = 0; i < columnNames.Length; i++)
			{
				string text2 = rowDatum[i];
				string text3 = text2;
				if (IsValidDouble(text2) && text2.Contains(".") && text2.Length > 7)
				{
					text3 = text2.Substring(0, 7);
				}
				text = ((i != columnNames.Length - 1 || columnNames.Length == 1 || maxColumnLengths[i] <= columnNames[i].Length) ? (text + InsertLink(text3.PadRight(getCellPadding(maxColumnLengths[i], columnNames[i].Length)), text3, isLeft: false)) : (text + InsertLink(text3.PadLeft(getCellPadding(maxColumnLengths[i], columnNames[i].Length) - 3), text3, isLeft: true)));
			}
			TextMeshProUGUI textMeshProUGUI = rowText;
			textMeshProUGUI.text = textMeshProUGUI.text + text + "\n";
			num2++;
		}
	}

	private string InsertLink(string padded, string original, bool isLeft)
	{
		string text = "<link>" + original + "</link>";
		for (int i = 0; i < padded.Length - original.Length; i++)
		{
			text = (isLeft ? (" " + text) : (text + " "));
		}
		return text;
	}

	private int getCellPadding(int maxColumnElementLength, int maxColumnNameLength)
	{
		int num = Mathf.Max(maxColumnElementLength, maxColumnNameLength);
		int num2 = 4;
		return 3 + ((num < num2) ? num2 : num);
	}

	private void SetWindowSizeHorizontal(RectTransform windowTransform, float rowSize, float columnSize, float tableNameSize)
	{
		float size = Mathf.Max(25f + Mathf.Max(rowSize, columnSize, tableNameSize + 30f) + 40f, 150f);
		windowTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
	}

	private void SetWindowSizeVertical(RectTransform windowTransform, int rows)
	{
		int num = Mathf.Min(rows, 15);
		float num2 = 64.82f;
		if (num < 15)
		{
			num2 += 17f;
		}
		float size = (float)num * 26.82f + num2;
		windowTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
	}

	private static bool IsValidDouble(string value)
	{
		if (double.TryParse(value, out var result))
		{
			if (!double.IsNaN(result))
			{
				return !double.IsInfinity(result);
			}
			return false;
		}
		return false;
	}
}
