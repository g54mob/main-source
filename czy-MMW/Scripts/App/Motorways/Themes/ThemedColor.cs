using System;
using UnityEngine;

namespace Motorways.Themes
{
	[Serializable]
	public class ThemedColor
	{
		[StringEnumSearch(typeof(ThemedMaterialType))]
		public string type;

		public Color color;

		public string propertyToChange = "_Color";

		private ThemedMaterialType _materialType;

		public ThemedMaterialType MaterialType
		{
			get
			{
				if (_materialType.ToString() != type && !Diagnostics.Verify(type.TryParse(out _materialType), "{0} isn't a valid ThemedMaterialType!", type))
				{
					return ThemedMaterialType.Land;
				}
				return _materialType;
			}
		}

		public ThemedColor(ThemedMaterialType type, Color color, string propertyToChange = "_Color")
		{
			this.type = type.ToString();
			this.color = color;
			this.propertyToChange = propertyToChange;
		}
	}
}
