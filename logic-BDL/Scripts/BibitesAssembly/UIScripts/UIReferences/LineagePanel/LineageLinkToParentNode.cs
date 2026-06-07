using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.UIReferences.LineagePanel
{
	public class LineageLinkToParentNode : FlexibleLineageElement
	{
		public TooltipTrigger tooltip;

		public LineageElement arrowToChild;

		public Image junctionLeft;

		public Image junctionRight;

		public override void Init()
		{
			orientedVertical = false;
			arrowToChild.Init();
			base.Init();
		}

		public void UpdateTooltip(string title, string tooltipText)
		{
			tooltip.UpdateText(title, tooltipText);
		}

		public void SetDist(float toParent)
		{
			if (!hasInit)
			{
				Init();
			}
			rt.anchoredPosition = Vector2.right * toParent / 2f;
			rt.sizeDelta = new Vector2(Mathf.Abs(toParent), 11f);
			bool flag = toParent > 0f;
			arrowToChild.rt.anchoredPosition = -rt.anchoredPosition;
			junctionLeft.sprite = (flag ? LineageTreePanel.instance.elbowRight : LineageTreePanel.instance.junctionRight);
			junctionRight.sprite = (flag ? LineageTreePanel.instance.junctionLeft : LineageTreePanel.instance.elbowLeft);
		}
	}
}
