using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SaintsField.Interfaces;
using SaintsField.Utils;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class ColorPaletteAttribute : PropertyAttribute, ISaintsAttribute
	{
		public struct ColorPaletteSource
		{
			public string Name;

			public bool IsCallback;
		}

		public readonly IReadOnlyList<ColorPaletteSource> ColorPaletteSources;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy => "";

		public ColorPaletteAttribute(params string[] names)
		{
			ColorPaletteSources = names.Select(delegate(string each)
			{
				var (name, isCallback) = RuntimeUtil.ParseCallback(each);
				return new ColorPaletteSource
				{
					Name = name,
					IsCallback = isCallback
				};
			}).ToArray();
		}
	}
}
