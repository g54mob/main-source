using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using SaintsField.Utils;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class SeparatorAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly string Title;

		public readonly EColor Color;

		public readonly EAlign EAlign;

		public readonly bool IsCallback;

		public readonly int Space;

		public readonly bool Below;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy => "";

		public SeparatorAttribute()
			: this(null)
		{
		}

		public SeparatorAttribute(EColor color)
			: this(null, color)
		{
		}

		public SeparatorAttribute(EColor color, int space)
			: this(null, color, EAlign.Start, isCallback: false, space)
		{
		}

		public SeparatorAttribute(EColor color, bool below)
			: this(null, color, EAlign.Start, isCallback: false, 0, below)
		{
		}

		public SeparatorAttribute(EColor color, int space, bool below)
			: this(null, color, EAlign.Start, isCallback: false, space, below)
		{
		}

		public SeparatorAttribute(int space)
			: this(null, EColor.Clear, EAlign.Start, isCallback: false, space)
		{
		}

		public SeparatorAttribute(int space, bool below)
			: this(null, EColor.Clear, EAlign.Start, isCallback: false, space, below)
		{
		}

		public SeparatorAttribute(string title, EAlign eAlign, bool isCallback = false, int space = 0, bool below = false)
			: this(title, EColor.Gray, eAlign, isCallback, space, below)
		{
		}

		public SeparatorAttribute(string title, EColor color = EColor.Gray, EAlign eAlign = EAlign.Start, bool isCallback = false, int space = 0, bool below = false)
		{
			(string content, bool isCallback) tuple = RuntimeUtil.ParseCallback(title, isCallback);
			string item = tuple.content;
			bool item2 = tuple.isCallback;
			Title = item;
			IsCallback = item2;
			Color = color;
			EAlign = eAlign;
			Space = space;
			Below = below;
		}
	}
}
