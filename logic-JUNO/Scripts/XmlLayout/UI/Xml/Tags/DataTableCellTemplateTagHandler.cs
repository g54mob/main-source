using System.Collections.Generic;
using UI.Tables;
using UnityEngine;

namespace UI.Xml.Tags
{
	public class DataTableCellTemplateTagHandler : ElementTagHandler
	{
		public override string prefabPath => null;

		public override MonoBehaviour primaryComponent => base.currentInstanceTransform.GetComponent<TableCell>();

		public override bool isCustomElement => true;

		public override string elementChildType => null;

		public override string elementGroup => "dataTableRow";

		public override string extension => "base";

		public override Dictionary<string, string> attributes => new Dictionary<string, string>
		{
			{ "dontUseTableCellBackground", "xs:boolean" },
			{ "columnSpan", "xs:int" },
			{ "overrideGlobalPadding", "xs:boolean" }
		};

		public override List<string> attributeGroups => new List<string> { "image", "layoutBase" };

		public override bool renderElement => false;

		public override void ApplyAttributes(AttributeDictionary attributes)
		{
			TableCell tableCell = null;
			string currentTemplateType = DataTableRowTemplateTagHandler.currentTemplateType;
			if (!(currentTemplateType == "HeaderRow"))
			{
				if (currentTemplateType == "DataRow")
				{
					tableCell = DataTableTagHandler.currentDataTable.templateDataCell;
				}
			}
			else
			{
				tableCell = DataTableTagHandler.currentDataTable.templateHeaderCell;
			}
			if (tableCell != null)
			{
				ElementTagHandler xmlTagHandler = XmlLayoutUtilities.GetXmlTagHandler("Cell");
				XmlElement xmlElement = tableCell.GetComponent<XmlElement>();
				if (xmlElement == null)
				{
					xmlElement = tableCell.gameObject.AddComponent<XmlElement>();
					xmlElement.Initialise(base.currentXmlElement.xmlLayoutInstance, tableCell.transform as RectTransform, xmlTagHandler);
				}
				xmlElement.ApplyAttributes(attributes);
			}
		}
	}
}
