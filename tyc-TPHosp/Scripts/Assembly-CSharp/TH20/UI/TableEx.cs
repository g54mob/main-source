using UnityEngine;

namespace TH20.UI
{
	public static class TableEx
	{
		public static RectTransform GetColumnHeader(this Table table, int columnIndex)
		{
			if (table.ColumnHeaders == null)
			{
				return null;
			}
			RectTransform result = null;
			if (table.ColumnHeaders != null && columnIndex < table.ColumnHeaders.childCount)
			{
				result = table.ColumnHeaders.GetChild(columnIndex).GetComponent<RectTransform>();
			}
			return result;
		}

		public static GameObject InstantiateAsRow(this Table table, GameObject row)
		{
			GameObject result = Object.Instantiate(row, table.Rows, worldPositionStays: false);
			table.SetDirty();
			return result;
		}

		public static void DestroyRow(this Table table, int rowIndex)
		{
			if (table.Rows != null && rowIndex < table.Rows.childCount)
			{
				Object.Destroy(table.Rows.GetChild(rowIndex).gameObject);
			}
			table.SetDirty();
		}

		public static void DestroyRow(this Table table, GameObject gameObject)
		{
			for (int i = 0; i < table.Rows.childCount; i++)
			{
				if (table.Rows.GetChild(i).gameObject == gameObject)
				{
					Object.Destroy(gameObject);
					break;
				}
			}
			table.SetDirty();
		}
	}
}
