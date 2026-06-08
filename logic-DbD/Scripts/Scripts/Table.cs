using System;
using System.Collections.Generic;

public class Table
{
	private string[] columnNames;

	private List<string[]> tableData;

	public Table(int columns)
	{
		columnNames = new string[columns];
		tableData = new List<string[]>();
	}

	public Table(List<string[]> tableData)
	{
		if (tableData.Count <= 0)
		{
			throw new Exception("Given table has no data associated with it");
		}
		columnNames = new string[tableData[0].Length];
		this.tableData = tableData;
	}

	public void SetColumnName(int columnNumber, string columnName)
	{
		columnNames[columnNumber] = columnName;
	}

	public void AddRow(string[] rowData)
	{
		tableData.Add(rowData);
	}

	public string[] GetColumnNames()
	{
		return columnNames;
	}

	public List<string[]> GetRows()
	{
		return tableData;
	}

	public int[] GetMaxLengthPerColumn()
	{
		if (tableData.Count == 0)
		{
			return null;
		}
		int[] array = new int[tableData[0].Length];
		foreach (string[] tableDatum in tableData)
		{
			for (int i = 0; i < tableDatum.Length; i++)
			{
				if (tableDatum[i].Length > array[i])
				{
					array[i] = tableDatum[i].Length;
				}
			}
		}
		return array;
	}

	public bool IsEmpty()
	{
		return tableData.Count == 0;
	}

	public int RowCount()
	{
		return tableData.Count;
	}

	public override string ToString()
	{
		string text = "";
		foreach (string[] row in GetRows())
		{
			text = text + string.Join(", ", row) + "\n";
		}
		return text;
	}
}
