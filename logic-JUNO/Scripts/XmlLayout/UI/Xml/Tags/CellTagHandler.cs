using UI.Tables;
using UnityEngine;

namespace UI.Xml.Tags
{
	public class CellTagHandler : ElementTagHandler
	{
		public override MonoBehaviour primaryComponent
		{
			get
			{
				if (base.currentInstanceTransform == null)
				{
					return null;
				}
				return base.currentInstanceTransform.GetComponent<TableCell>();
			}
		}

		public override string prefabPath => "Prefabs/TableLayout/Cell";
	}
}
