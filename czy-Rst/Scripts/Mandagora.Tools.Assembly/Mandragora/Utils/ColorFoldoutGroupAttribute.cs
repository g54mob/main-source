using Sirenix.OdinInspector;
using UnityEngine;

namespace Mandragora.Utils
{
	public class ColorFoldoutGroupAttribute : PropertyGroupAttribute
	{
		public Color Color;

		public ColorFoldoutGroupAttribute(string path)
			: base(path)
		{
			Color = Color.white;
		}

		public ColorFoldoutGroupAttribute(string path, float r, float g, float b)
			: base(path)
		{
			Color = new Color(r, g, b);
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			ColorFoldoutGroupAttribute colorFoldoutGroupAttribute = (ColorFoldoutGroupAttribute)other;
			Color = colorFoldoutGroupAttribute.Color;
		}
	}
}
