using TMPro;
using UnityEngine.UI;
using Utility;

namespace UIScripts.UIReferences
{
	public class GraphLegendItem : PoolableItem<GraphLegendItem>
	{
		public Image img;

		public TextMeshProUGUI label;

		public TooltipTrigger tooltip;

		public void SetDescription(DataStreamDescription desc)
		{
			img.color = desc.color;
			label.text = desc.label;
			tooltip.UpdateText(desc.label, desc.description);
		}

		public void SetActive(bool val)
		{
			base.gameObject.SetActive(val);
		}
	}
}
