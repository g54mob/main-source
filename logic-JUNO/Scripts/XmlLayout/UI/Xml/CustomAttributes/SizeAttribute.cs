using System;
using System.Linq;
using UnityEngine;

namespace UI.Xml.CustomAttributes
{
	public abstract class SizeAttribute : CustomXmlAttribute
	{
		public override bool UsesApplyMethod => true;

		public override bool KeepOriginalTag => true;

		public override eAttributeGroup AttributeGroup => eAttributeGroup.RectPosition;

		public override string DefaultValue => "100%";

		protected Vector2 ApplyAlignment(Vector2 vector, RectAlignment alignment = RectAlignment.MiddleCenter)
		{
			return alignment switch
			{
				RectAlignment.MiddleCenter => new Vector2((1f - vector.x) / 2f, (1f - vector.y) / 2f), 
				RectAlignment.MiddleLeft => new Vector2(0f, (1f - vector.y) / 2f), 
				RectAlignment.MiddleRight => new Vector2(1f - vector.x, (1f - vector.y) / 2f), 
				RectAlignment.UpperCenter => new Vector2((1f - vector.x) / 2f, 1f - vector.y), 
				RectAlignment.LowerCenter => new Vector2((1f - vector.x) / 2f, 0f), 
				RectAlignment.UpperLeft => new Vector2(0f, 1f - vector.y), 
				RectAlignment.UpperRight => new Vector2(1f - vector.x, 1f - vector.y), 
				RectAlignment.LowerLeft => new Vector2(0f, 0f), 
				RectAlignment.LowerRight => new Vector2(1f - vector.x, 0f), 
				_ => vector, 
			};
		}

		protected RectAlignmentStruct GetAlignmentStruct(float width, float height, Vector2 position, RectAlignment alignment = RectAlignment.MiddleCenter)
		{
			Vector2 pivot = new Vector2(0.5f, 0.5f);
			Vector2 anchorMin = new Vector2(0.5f, 0.5f);
			Vector2 anchorMax = new Vector2(0.5f, 0.5f);
			float num = width / 2f;
			float num2 = height / 2f;
			switch (alignment)
			{
			case RectAlignment.LowerCenter:
				pivot = new Vector2(0.5f, 0f);
				anchorMin = new Vector2(0.5f, 0f);
				anchorMax = new Vector2(0.5f, 0f);
				position = new Vector2(0f, num2);
				break;
			case RectAlignment.LowerLeft:
				pivot = new Vector2(0f, 0f);
				anchorMin = new Vector2(0f, 0f);
				anchorMax = new Vector2(0f, 0f);
				position = new Vector2(num, num2);
				break;
			case RectAlignment.LowerRight:
				pivot = new Vector2(1f, 0f);
				anchorMin = new Vector2(1f, 0f);
				anchorMax = new Vector2(1f, 0f);
				position = new Vector2(0f - num, num2);
				break;
			case RectAlignment.MiddleLeft:
				pivot = new Vector2(0f, 0.5f);
				anchorMin = new Vector2(0f, 0.5f);
				anchorMax = new Vector2(0f, 0.5f);
				position = new Vector2(num, 0f);
				break;
			case RectAlignment.MiddleRight:
				pivot = new Vector2(1f, 0.5f);
				anchorMin = new Vector2(1f, 0.5f);
				anchorMax = new Vector2(1f, 0.5f);
				position = new Vector2(0f - num, 0f);
				break;
			case RectAlignment.UpperCenter:
				pivot = new Vector2(0.5f, 1f);
				anchorMin = new Vector2(0.5f, 1f);
				anchorMax = new Vector2(0.5f, 1f);
				position = new Vector2(0f, 0f - num2);
				break;
			case RectAlignment.UpperLeft:
				pivot = new Vector2(0f, 1f);
				anchorMin = new Vector2(0f, 1f);
				anchorMax = new Vector2(0f, 1f);
				position = new Vector2(num, 0f - num2);
				break;
			case RectAlignment.UpperRight:
				pivot = new Vector2(1f, 1f);
				anchorMin = new Vector2(1f, 1f);
				anchorMax = new Vector2(1f, 1f);
				position = new Vector2(0f - num, 0f - num2);
				break;
			}
			return new RectAlignmentStruct
			{
				Pivot = pivot,
				AnchorMin = anchorMin,
				AnchorMax = anchorMax,
				Position = position
			};
		}

		protected RectAlignment GetRectAlignment(string alignment)
		{
			RectAlignment result = RectAlignment.MiddleCenter;
			if (Enum.GetNames(typeof(RectAlignment)).Contains(alignment, StringComparer.OrdinalIgnoreCase))
			{
				result = (RectAlignment)Enum.Parse(typeof(RectAlignment), alignment, ignoreCase: true);
			}
			return result;
		}
	}
}
