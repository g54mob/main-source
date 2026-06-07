using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UI.Tables;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Xml
{
	[ExecuteInEditMode]
	public class XmlLayoutDataTable : MonoBehaviour
	{
		[Header("Configuration")]
		public bool PrettifyColumnHeaders = true;

		[SerializeField]
		[HideInInspector]
		internal TableRow headerRow;

		[SerializeField]
		[HideInInspector]
		internal List<TableRow> dataRows = new List<TableRow>();

		[SerializeField]
		[HideInInspector]
		private List<string> headings = new List<string>();

		[Header("Object References")]
		public TableLayout table;

		public TableRow templateHeaderRow;

		public TableCell templateHeaderCell;

		public TableRow templateDataRow;

		public TableCell templateDataCell;

		private Dictionary<Type, Dictionary<string, MemberInfo>> cachedMembers = new Dictionary<Type, Dictionary<string, MemberInfo>>();

		[SerializeField]
		internal List<XmlLayoutDataTableRow> mvvmRows = new List<XmlLayoutDataTableRow>();

		public void SetData<T>(Dictionary<string, string> columns, List<T> dataSource)
		{
			ClearData();
			HandleColumnsDefinition(columns);
			if (dataSource != null)
			{
				RenderDataRows(dataSource, typeof(T));
			}
		}

		public void SetData<T>(List<T> rows)
		{
			ClearData();
			if (rows != null && !TryHandleDataSourceAsDictionary(rows))
			{
				Type typeFromHandle = typeof(T);
				RenderFromList(rows.Cast<object>().ToList(), typeFromHandle);
			}
		}

		public void SetData(List<object> rows, Type itemType)
		{
			ClearData();
			if (rows != null)
			{
				if (itemType == typeof(Dictionary<string, string>))
				{
					SetDataFromDictionary(rows.Cast<Dictionary<string, string>>().ToList());
				}
				else
				{
					RenderFromList(rows, itemType);
				}
			}
		}

		private void RenderFromList(List<object> rows, Type itemType)
		{
			headings = ExtractHeadingsFromType(itemType);
			RenderHeadingRow(headings);
			if (rows.Any())
			{
				RenderDataRows(rows, itemType);
			}
		}

		private List<string> ExtractHeadingsFromType(Type type)
		{
			return (from m in type.GetMembers(BindingFlags.Instance | BindingFlags.Public)
				where m.MemberType == MemberTypes.Property || m.MemberType == MemberTypes.Field
				select m.Name).ToList();
		}

		private void SetDataFromDictionary(List<Dictionary<string, string>> data)
		{
			headings = ExtractHeadingsFromDictionary(data);
			RenderHeadingRow(headings);
			RenderDataRows(data, typeof(Dictionary<string, string>));
		}

		public bool TryHandleDataSourceAsDictionary<T>(List<T> dataSource)
		{
			if (typeof(T) == typeof(Dictionary<string, string>))
			{
				SetDataFromDictionary(dataSource.Cast<Dictionary<string, string>>().ToList());
				return true;
			}
			return false;
		}

		private void RenderDataRowsFromDictionary(List<Dictionary<string, string>> rows)
		{
			foreach (Dictionary<string, string> row in rows)
			{
				RenderDataRow(row);
			}
		}

		private void RenderDataRows<T>(List<T> rows, Type type)
		{
			if (type == typeof(Dictionary<string, string>))
			{
				RenderDataRowsFromDictionary(rows.Cast<Dictionary<string, string>>().ToList());
				return;
			}
			Dictionary<string, MemberInfo> members = GetMembers(type);
			List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
			foreach (T row in rows)
			{
				list.Add(ExtractRowData(row, type, members));
			}
			RenderDataRowsFromDictionary(list);
		}

		private Dictionary<string, MemberInfo> GetMembers(Type type)
		{
			if (!cachedMembers.ContainsKey(type))
			{
				cachedMembers.Add(type, (from kvp in headings.ToDictionary((string k) => k, (string v) => type.GetMember(v).FirstOrDefault())
					where kvp.Value != null
					select kvp).ToDictionary((KeyValuePair<string, MemberInfo> k) => k.Key, (KeyValuePair<string, MemberInfo> v) => v.Value));
			}
			return cachedMembers[type];
		}

		private Dictionary<string, string> ExtractRowData(object rowDataObject, Type type, Dictionary<string, MemberInfo> members = null)
		{
			if (members == null)
			{
				members = GetMembers(type);
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (string heading in headings)
			{
				MemberInfo memberInfo = members[heading];
				if (memberInfo != null)
				{
					dictionary.Add(heading, (memberInfo != null) ? memberInfo.GetMemberValue(rowDataObject).ToString() : string.Empty);
				}
			}
			return dictionary;
		}

		private void HandleColumnsDefinition(Dictionary<string, string> columns)
		{
			headings = columns.Keys.ToList();
			RenderHeadingRow(columns.Values.ToList(), doNotPrettify: true);
		}

		private TableRow RenderDataRow(Dictionary<string, string> data)
		{
			TableRow tableRow = Instantiate(templateDataRow, "Data Row");
			table.AddRow(tableRow);
			foreach (string heading in headings)
			{
				TableCell tableCell = Instantiate(templateDataCell, "Data Cell");
				tableRow.AddCell(tableCell);
				tableCell.GetComponentInChildren<Text>().text = (data.ContainsKey(heading) ? data[heading] : string.Empty);
			}
			dataRows.Add(tableRow);
			XmlLayoutTimer.AtEndOfFrame(table.CalculateLayoutInputHorizontal, this);
			return tableRow;
		}

		private void RenderHeadingRow(List<string> headings, bool doNotPrettify = false)
		{
			List<string> list = headings;
			if (PrettifyColumnHeaders && !doNotPrettify)
			{
				list = list.Select((string h) => h.SplitByCapitals().ToTitleCase()).ToList();
			}
			headerRow = Instantiate(templateHeaderRow, "Header Row");
			table.AddRow(headerRow);
			foreach (string item in list)
			{
				TableCell tableCell = Instantiate(templateHeaderCell, "Header Cell");
				headerRow.AddCell(tableCell);
				tableCell.GetComponentInChildren<Text>().text = item;
			}
		}

		private List<string> ExtractHeadingsFromDictionary(List<Dictionary<string, string>> data)
		{
			List<string> list = new List<string>();
			foreach (Dictionary<string, string> datum in data)
			{
				foreach (KeyValuePair<string, string> item in datum)
				{
					if (!list.Contains(item.Key))
					{
						list.Add(item.Key);
					}
				}
			}
			return list;
		}

		public void ClearData(bool preserveHeadingRow = false)
		{
			if (!preserveHeadingRow && headerRow != null)
			{
				_Destroy(headerRow);
			}
			if (dataRows.Any())
			{
				dataRows.Where((TableRow dr) => dr != null).ToList().ForEach(delegate(TableRow dr)
				{
					_Destroy(dr);
				});
				dataRows.Clear();
			}
		}

		private T Instantiate<T>(T template, string name = "") where T : MonoBehaviour
		{
			T val = UnityEngine.Object.Instantiate(template);
			val.gameObject.SetActive(value: true);
			val.name = name;
			return val;
		}

		private void _Destroy(UnityEngine.Object o)
		{
			if (!(o == null))
			{
				if (o is MonoBehaviour)
				{
					o = ((MonoBehaviour)o).gameObject;
				}
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(o);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(o);
				}
			}
		}

		public void SetCellValue(int rowIndex, string columnName, object value)
		{
			if (rowIndex > dataRows.Count)
			{
				Debug.LogWarningFormat("[XmlLayout][DataTable][SetCellValue]: Invalid rowIndex '{0}' provided.", rowIndex);
				return;
			}
			TableRow tableRow = dataRows[rowIndex];
			int num = headings.IndexOf(columnName);
			if (num == -1 || num > tableRow.Cells.Count)
			{
				Debug.LogWarningFormat("[XmlLayout][DataTable][SetCellValue]: Invalid columnName '{0}' provided.", columnName);
			}
			else
			{
				TableCell cell = tableRow.Cells[num];
				string columnType = "text";
				_SetCellValue(cell, value, columnType);
			}
		}

		private void _SetCellValue(TableCell cell, object value, string columnType)
		{
			if (columnType == "text")
			{
				cell.gameObject.GetComponentInChildren<Text>().text = value.ToString();
			}
		}

		internal void InitMVVM(Type type, IList<object> initialRowData)
		{
			ClearData();
			mvvmRows.Clear();
			if (type == typeof(Dictionary<string, string>))
			{
				headings = ExtractHeadingsFromDictionary(initialRowData.Cast<Dictionary<string, string>>().ToList());
			}
			else
			{
				headings = ExtractHeadingsFromType(type);
			}
			RenderHeadingRow(headings);
		}

		internal XmlLayoutDataTableRow AddRowMVVM(IObservableList list, object rowData, Type type)
		{
			TableRow tableRow = ((!(type == typeof(Dictionary<string, string>))) ? RenderDataRow(ExtractRowData(rowData, type)) : RenderDataRow(rowData as Dictionary<string, string>));
			XmlLayoutDataTableRow xmlLayoutDataTableRow = tableRow.gameObject.AddComponent<XmlLayoutDataTableRow>();
			xmlLayoutDataTableRow.guid = list.GetGUID(rowData);
			mvvmRows.Add(xmlLayoutDataTableRow);
			XmlLayoutTimer.AtEndOfFrame(table.CalculateLayoutInputHorizontal, this);
			return xmlLayoutDataTableRow;
		}

		internal void RemoveRowMVVM(string guid)
		{
			XmlLayoutDataTableRow xmlLayoutDataTableRow = mvvmRows.FirstOrDefault((XmlLayoutDataTableRow r) => r.guid == guid);
			if (xmlLayoutDataTableRow != null)
			{
				_Destroy(xmlLayoutDataTableRow);
			}
			XmlLayoutTimer.AtEndOfFrame(table.CalculateLayoutInputHorizontal, this);
		}

		internal void UpdateRowMVVM(string rowGuid, object rowData, string changedField = null)
		{
			XmlLayoutDataTableRow xmlLayoutDataTableRow = mvvmRows.Where((XmlLayoutDataTableRow r) => r != null).FirstOrDefault((XmlLayoutDataTableRow r) => r.guid == rowGuid);
			if (!(xmlLayoutDataTableRow != null))
			{
				return;
			}
			bool flag = rowData.GetType() == typeof(Dictionary<string, string>);
			Dictionary<string, string> dictionary = null;
			if (flag)
			{
				dictionary = rowData as Dictionary<string, string>;
			}
			int rowIndex = mvvmRows.IndexOf(xmlLayoutDataTableRow);
			if (changedField != null)
			{
				object obj = null;
				obj = ((!flag) ? rowData.GetType().GetMember(changedField).First()
					.GetMemberValue(rowData) : (dictionary.ContainsKey(changedField) ? dictionary[changedField] : null));
				SetCellValue(rowIndex, changedField, obj);
				return;
			}
			foreach (string heading in headings)
			{
				object obj2 = null;
				obj2 = ((!flag) ? rowData.GetType().GetMember(heading).First()
					.GetMemberValue(rowData) : (dictionary.ContainsKey(heading) ? dictionary[heading] : null));
				SetCellValue(rowIndex, heading, obj2);
			}
		}
	}
}
