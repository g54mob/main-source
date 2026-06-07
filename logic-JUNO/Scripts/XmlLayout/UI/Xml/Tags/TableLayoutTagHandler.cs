using UI.Tables;
using UnityEngine;

namespace UI.Xml.Tags
{
	public class TableLayoutTagHandler : ElementTagHandler
	{
		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<TableLayout>();
			}
		}

		public override string prefabPath => "Prefabs/TableLayout/TableLayout";

		public override void ApplyAttributes(AttributeDictionary attributes)
		{
			base.ApplyAttributes(attributes);
			TableLayout tableLayout = primaryComponent as TableLayout;
			if (attributes.ContainsKey("columncount"))
			{
				int num = int.Parse(attributes["columncount"]);
				for (int i = 0; i < num; i++)
				{
					tableLayout.ColumnWidths.Add(0f);
				}
				if (!attributes.ContainsKey("automaticallyRemoveEmptyColumns"))
				{
					tableLayout.AutomaticallyRemoveEmptyColumns = false;
				}
			}
			if (attributes.ContainsKey("rowBackgroundColorAlternate") && !attributes.ContainsKey("useAlternateRowBackgroundColor"))
			{
				tableLayout.UseAlternateRowBackgroundColors = true;
			}
			if (attributes.ContainsKey("cellBackgroundColorAlternate") && !attributes.ContainsKey("useAlternateCellBackgroundColor"))
			{
				tableLayout.UseAlternateCellBackroundColors = true;
			}
		}
	}
}
