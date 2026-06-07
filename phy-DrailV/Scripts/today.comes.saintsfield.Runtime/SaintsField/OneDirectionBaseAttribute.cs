using System;
using SaintsField.Interfaces;
using SaintsField.Utils;
using UnityEngine;

namespace SaintsField
{
	public abstract class OneDirectionBaseAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly string Start;

		public readonly int StartIndex;

		public readonly string StartSpace;

		public readonly string End;

		public readonly int EndIndex;

		public readonly string EndSpace;

		public readonly Color Color;

		public readonly string ColorCallback;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy => "";

		protected OneDirectionBaseAttribute(string start = null, int startIndex = 0, string startSpace = "this", string end = null, int endIndex = 0, string endSpace = "this", EColor eColor = EColor.White, string color = null)
		{
			Start = start;
			StartIndex = startIndex;
			StartSpace = startSpace;
			End = end;
			EndIndex = endIndex;
			EndSpace = endSpace;
			Color = eColor.GetColor();
			bool flag = !string.IsNullOrEmpty(color);
			ColorCallback = null;
			if (flag && color.StartsWith("#"))
			{
				if (!ColorUtility.TryParseHtmlString(color, out var color2))
				{
					throw new Exception("Color " + color + " is not a valid color");
				}
				Color = color2;
			}
			else if (flag)
			{
				string item = RuntimeUtil.ParseCallback(color).content;
				ColorCallback = item;
			}
		}
	}
}
