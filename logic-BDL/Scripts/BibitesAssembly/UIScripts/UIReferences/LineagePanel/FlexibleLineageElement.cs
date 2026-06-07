using System;
using UnityEngine;

namespace UIScripts.UIReferences.LineagePanel
{
	public class FlexibleLineageElement : LineageElement
	{
		[SerializeField]
		protected bool orientedVertical;

		[NonSerialized]
		public Vector2 startAnchor;

		[NonSerialized]
		public Vector2 endAnchor;

		public virtual void SetAnchors(Vector2 start, Vector2 end)
		{
			if (!hasInit)
			{
				Init();
			}
			startAnchor = start;
			endAnchor = end;
			if (orientedVertical)
			{
				height = Mathf.Abs(start.y - end.y);
			}
			else
			{
				width = Mathf.Abs(start.y - end.y);
			}
			rt.localPosition = (start + end) / 2f;
			rt.sizeDelta = new Vector2(width, height);
		}
	}
}
