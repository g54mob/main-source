using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using SaintsField.Utils;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
	public class DrawLabelAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly Color Color;

		public readonly string ColorCallback;

		public readonly string Content;

		public readonly bool IsCallback;

		public readonly string Space;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy => "";

		public DrawLabelAttribute(EColor eColor, string content = null, string space = "this", string color = null)
		{
			(string content, bool isCallback) tuple = RuntimeUtil.ParseCallback(content);
			string item = tuple.content;
			bool item2 = tuple.isCallback;
			Content = item;
			IsCallback = item2;
			Space = space;
			Color = eColor.GetColor();
			ColorCallback = null;
			bool flag = !string.IsNullOrEmpty(color);
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
				string item3 = RuntimeUtil.ParseCallback(color).content;
				ColorCallback = item3;
			}
		}

		public DrawLabelAttribute(string content = null, string space = "this", string color = null)
			: this(EColor.White, content, space, color)
		{
		}
	}
}
