using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
	public struct Row
	{
		public Transform EntryParent;

		public List<TableEntry> Entries;

		public Row(string rowName, GameObject prefab, Transform rowParent)
		{
			EntryParent = Object.Instantiate(prefab, rowParent).transform;
			EntryParent.name = rowName;
			EntryParent.SetParent(rowParent);
			EntryParent.localPosition = Vector3.zero;
			Entries = new List<TableEntry>();
		}

		public void AddEntry(TableEntry entry)
		{
			if (Entries == null)
			{
				Entries = new List<TableEntry> { entry };
			}
		}

		public void RemoveEntry(TableEntry entry)
		{
			if (Entries != null)
			{
				Entries.Remove(entry);
			}
		}
	}

	[SerializeField]
	private TableEntry.Style[] _styles = new TableEntry.Style[0];

	[SerializeField]
	private GameObject _rowPrefab;

	public List<Row> Rows { get; private set; } = new List<Row>();

	public Row AddRow()
	{
		Row row = new Row("Row " + Rows.Count, _rowPrefab, base.transform);
		Rows.Add(row);
		return row;
	}

	public bool TryAddEntry(Row row, string styleID, string term, float width, out TableEntry entry)
	{
		if (TryReturnStyle(styleID, out var style))
		{
			entry = Object.Instantiate(style.Prefab, row.EntryParent);
			entry.Initialize(style, term, width);
			row.AddEntry(entry);
			return true;
		}
		entry = null;
		return false;
	}

	public bool TryAddEntry(Row row, string styleID, Sprite sprite, Color spriteColor, float width, out TableEntry entry)
	{
		if (TryReturnStyle(styleID, out var style))
		{
			entry = Object.Instantiate(style.Prefab, row.EntryParent);
			entry.Initialize(style, sprite, spriteColor, width);
			row.AddEntry(entry);
			return true;
		}
		entry = null;
		return false;
	}

	private bool TryReturnStyle(string id, out TableEntry.Style style)
	{
		TableEntry.Style[] styles = _styles;
		for (int i = 0; i < styles.Length; i++)
		{
			TableEntry.Style style2 = styles[i];
			if (style2.Equals(id))
			{
				style = style2;
				return true;
			}
		}
		style = default(TableEntry.Style);
		return false;
	}
}
