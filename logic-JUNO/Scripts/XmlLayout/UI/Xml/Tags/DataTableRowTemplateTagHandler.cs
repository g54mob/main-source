using System.Collections.Generic;
using System.Linq;
using UI.Tables;
using UnityEngine;

namespace UI.Xml.Tags
{
	public class DataTableRowTemplateTagHandler : ElementTagHandler
	{
		internal static string currentTemplateType { get; private set; }

		public override string prefabPath => null;

		public override MonoBehaviour primaryComponent => base.currentInstanceTransform.GetComponent<TableRow>();

		public override bool isCustomElement => true;

		public override string elementChildType => "dataTableRow";

		public override string elementGroup => "dataTable";

		public override string extension => "simple";

		public override Dictionary<string, string> attributes => new Dictionary<string, string>
		{
			{ "preferredHeight", "xs:float" },
			{ "dontUseTableRowBackground", "xs:boolean" },
			{ "templateType", "HeaderRow,DataRow" }
		};

		public override List<string> attributeGroups => new List<string> { "image" };

		public override bool renderElement => false;

		public override void ApplyAttributes(AttributeDictionary attributes)
		{
			if (!attributes.ContainsKey("templateType"))
			{
				Debug.LogWarningFormat("[XmlLayout][DataTableRowTemplate] The 'templateType' attribute is required.");
				return;
			}
			string text = attributes["templateType"];
			XmlLayoutDataTable componentInParent = base.currentXmlElement.GetComponentInParent<XmlLayoutDataTable>();
			List<TableRow> list = new List<TableRow>();
			if (!(text == "HeaderRow"))
			{
				if (text == "DataRow")
				{
					list.Add(componentInParent.templateDataRow);
					list.AddRange(componentInParent.dataRows);
				}
			}
			else
			{
				list.Add(componentInParent.templateHeaderRow);
				list.Add(componentInParent.headerRow);
			}
			list = list.Where((TableRow r) => r != null).ToList();
			if (list.Count <= 0)
			{
				return;
			}
			ElementTagHandler xmlTagHandler = XmlLayoutUtilities.GetXmlTagHandler("Row");
			foreach (TableRow item in list)
			{
				XmlElement xmlElement = item.GetComponent<XmlElement>();
				if (xmlElement == null)
				{
					xmlElement = item.gameObject.AddComponent<XmlElement>();
					xmlElement.Initialise(base.currentXmlElement.xmlLayoutInstance, item.transform as RectTransform, xmlTagHandler);
				}
				xmlElement.ApplyAttributes(attributes);
			}
		}

		public override void Open(AttributeDictionary attributes)
		{
			base.Open(attributes);
			if (attributes.ContainsKey("templateType"))
			{
				currentTemplateType = attributes["templateType"];
			}
		}
	}
}
