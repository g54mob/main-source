using UI.Tables;
using UnityEngine;

namespace UI.Xml.Tags
{
	public class RowTagHandler : ElementTagHandler
	{
		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<TableRow>();
			}
		}

		public override string prefabPath => "Prefabs/TableLayout/Row";
	}
}
