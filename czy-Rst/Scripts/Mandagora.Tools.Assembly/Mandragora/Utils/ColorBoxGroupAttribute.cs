using Sirenix.OdinInspector;
using UnityEngine;

namespace Mandragora.Utils
{
	public class ColorBoxGroupAttribute : PropertyGroupAttribute
	{
		public Color Color;

		public bool ShowLabel;

		public ColorBoxGroupAttribute(string path, bool showLabel)
			: base(path)
		{
			Color = Color.white;
			ShowLabel = showLabel;
		}

		public ColorBoxGroupAttribute(string path, float r, float g, float b, bool showLabel = true)
			: base(path)
		{
			Color = new Color(r, g, b);
			ShowLabel = showLabel;
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			if (other is ColorFoldoutGroupAttribute colorFoldoutGroupAttribute)
			{
				Color = colorFoldoutGroupAttribute.Color;
			}
		}
	}
}
