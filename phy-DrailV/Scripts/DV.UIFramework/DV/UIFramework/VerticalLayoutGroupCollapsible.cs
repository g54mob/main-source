using System;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UIFramework
{
	public class VerticalLayoutGroupCollapsible : LayoutGroup
	{
		[Serializable]
		public class PlatformCellHeight
		{
			public APlatformProvider.Platform platform;

			public float cellHeight;
		}

		public float spacing;

		public bool fitToContent = true;

		public float cellHeight = 50f;

		public List<PlatformCellHeight> platformHeights;

		protected override void Awake()
		{
			base.Awake();
			APlatformProvider.Platform currentPlatform = SingletonBehaviour<APlatformProvider>.Instance.CurrentPlatform;
			foreach (PlatformCellHeight platformHeight in platformHeights)
			{
				if (currentPlatform.HasAnyByteFlag(platformHeight.platform))
				{
					cellHeight = platformHeight.cellHeight;
				}
			}
		}

		public override void CalculateLayoutInputHorizontal()
		{
			base.CalculateLayoutInputHorizontal();
			Rect rect = base.rectTransform.rect;
			float width = rect.width;
			float height = rect.height;
			int count = base.rectChildren.Count;
			float num = ((count > 1) ? spacing : 0f);
			float num2 = 0f;
			for (int i = 0; i < count; i++)
			{
				RectTransform rectTransform = base.rectChildren[i];
				CollapsibleElement component = rectTransform.GetComponent<CollapsibleElement>();
				if (!(component == null))
				{
					Vector2 layoutIndentation = component.layoutIndentation;
					float x = width - (float)base.padding.left - (float)base.padding.right - layoutIndentation.x;
					float y = ((cellHeight > 0f) ? cellHeight : ((height - (float)(base.padding.top + base.padding.bottom) - layoutIndentation.y) / (float)count));
					Vector2 vector = new Vector2(x, y);
					num2 += layoutIndentation.y;
					SetChildAlongAxis(rectTransform, 0, (float)base.padding.left + layoutIndentation.x, vector.x);
					SetChildAlongAxis(rectTransform, 1, (float)base.padding.top + num2 + (vector.y + num) * (float)i, vector.y);
				}
			}
			if (fitToContent)
			{
				base.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num2 + (cellHeight + num) * (float)count + (float)base.padding.top + (float)base.padding.bottom);
			}
		}

		public override void CalculateLayoutInputVertical()
		{
		}

		public override void SetLayoutHorizontal()
		{
		}

		public override void SetLayoutVertical()
		{
		}
	}
}
