using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using UnityEngine;

namespace UI.Xml.Tags
{
	public class DataTableTagHandler : ElementTagHandler, IObservableListTagHandler
	{
		internal Dictionary<string, XmlLayoutDataTable> dataTableElements = new Dictionary<string, XmlLayoutDataTable>();

		internal static XmlLayoutDataTable currentDataTable { get; private set; }

		public override MonoBehaviour primaryComponent => base.currentInstanceTransform.GetComponent<XmlLayoutDataTable>();

		public override bool isCustomElement => true;

		public override string elementChildType => "dataTable";

		public override Dictionary<string, string> attributes => new Dictionary<string, string> { { "prettifyColumnHeaders", "xs:boolean" } };

		public override bool UseParseChildElements => true;

		protected override void HandleDataSourceAttribute(string dataSource, string additionalDataSource = null)
		{
			XmlElementDataSource item = new XmlElementDataSource(dataSource, base.currentXmlElement);
			base.currentXmlLayoutInstance.ElementDataSources.RemoveAll((XmlElementDataSource ed) => ed.XmlElement == base.currentXmlElement);
			base.currentXmlLayoutInstance.ElementDataSources.Add(item);
		}

		public override void ParseChildElements(XmlNode xmlNode)
		{
			string dataSource = base.currentXmlElement.DataSource;
			if (string.IsNullOrEmpty(dataSource))
			{
				return;
			}
			XmlLayoutController xmlLayoutController = base.currentXmlLayoutInstance.XmlLayoutController;
			if (xmlLayoutController == null)
			{
				return;
			}
			PropertyInfo property = xmlLayoutController.GetType().GetProperty("viewModel");
			if (property == null)
			{
				Debug.LogWarning("[XmlLayout] Warning: Useage of the <List> element requires the XmlLayoutController to have a view model type defined.");
				return;
			}
			object value = property.GetValue(xmlLayoutController, null);
			MemberInfo memberInfo = value.GetType().GetMember(dataSource).FirstOrDefault();
			if (memberInfo == null)
			{
				Debug.LogWarning("[XmlLayout] Warning: View Model does not contain a field or property for data source '" + dataSource + "'.");
				return;
			}
			IList obj = (IList)memberInfo.GetMemberValue(value);
			IObservableList observableList = (IObservableList)obj;
			if (obj == null || observableList == null)
			{
				return;
			}
			XmlLayoutDataTable value2 = primaryComponent as XmlLayoutDataTable;
			string id = string.Empty;
			if (base.currentXmlElement.HasAttribute("id"))
			{
				id = base.currentXmlElement.attributes["id"];
			}
			else
			{
				id = observableList.guid;
				XmlLayoutTimer.AtEndOfFrame(delegate
				{
					base.currentXmlElement.SetAndApplyAttribute("id", id);
				}, base.currentXmlElement, forceEvenIfObjectIsInactive: true);
			}
			if (dataTableElements.ContainsKey(id))
			{
				dataTableElements[id] = value2;
			}
			else
			{
				dataTableElements.Add(id, value2);
			}
		}

		public override void SetListData(IObservableList list)
		{
			if (list == null)
			{
				return;
			}
			List<object> items = list.GetItems();
			XmlLayoutDataTable obj = primaryComponent as XmlLayoutDataTable;
			Type itemType = list.itemType;
			obj.InitMVVM(itemType, items);
			foreach (object item in items)
			{
				AddListItem(list, item, base.currentXmlElement.DataSource);
			}
		}

		public bool IsHandlingList(IObservableList list)
		{
			return dataTableElements.ContainsKey(list.guid);
		}

		public void RemoveListItem(IObservableList list, object item, string listName)
		{
			XmlLayoutDataTable dataTable = GetDataTable(list.guid);
			if (!(dataTable == null))
			{
				dataTable.RemoveRowMVVM(list.GetGUID(item));
			}
		}

		public void AddListItem(IObservableList list, object item, string listName)
		{
			XmlLayoutDataTable dataTable = GetDataTable(list.guid);
			if (!(dataTable == null))
			{
				dataTable.AddRowMVVM(list, item, list.itemType);
			}
		}

		public void UpdateListItem(IObservableList list, int index, object item, string listName, string changedField = null)
		{
			XmlLayoutDataTable dataTable = GetDataTable(list.guid);
			if (!(dataTable == null))
			{
				dataTable.UpdateRowMVVM(list.GetGUID(item), item, changedField);
			}
		}

		private XmlLayoutDataTable GetDataTable(string guid)
		{
			return dataTableElements.FirstOrDefault((KeyValuePair<string, XmlLayoutDataTable> dt) => dt.Key == guid).Value;
		}

		public override void Open(AttributeDictionary attributes)
		{
			base.Open(attributes);
			currentDataTable = primaryComponent as XmlLayoutDataTable;
		}
	}
}
