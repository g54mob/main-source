using System;
using SaintsField.Interfaces;
using SaintsField.Utils;
using UnityEngine;

namespace SaintsField
{
	public class GUIColorAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly bool IsCallback;

		public readonly string Callback;

		public readonly Color Color;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy => "";

		public GUIColorAttribute(float r, float g, float b, float a = 1f)
		{
			Color = new Color(r, g, b, a);
		}

		public GUIColorAttribute(string hexColor)
		{
			if (hexColor.StartsWith("#"))
			{
				if (!ColorUtility.TryParseHtmlString(hexColor, out var color))
				{
					throw new ArgumentOutOfRangeException("hexColor", hexColor, "Not a html hex color string");
				}
				Color = color;
			}
			else
			{
				IsCallback = true;
				Callback = RuntimeUtil.ParseCallback(hexColor).content;
			}
		}

		public GUIColorAttribute(EColor eColor, float alpha = 1f)
		{
			if (alpha >= 1f)
			{
				Color = eColor.GetColor();
				return;
			}
			Color color = eColor.GetColor();
			color.a = alpha;
			Color = color;
		}
	}
}
