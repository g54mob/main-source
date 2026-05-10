using System;
using AssetIcons;
using CTS.Core;
using UnityEngine;

namespace CTS.UI
{
	[CreateAssetMenu(menuName = "CTS/Color/Color Palette")]
	public class PaletteData : ScriptableStringKey
	{
		public abstract class PaletteDataContent
		{
			public abstract Color GetColor();
		}

		[Serializable]
		public class PaletteDataSimpleColor : PaletteDataContent
		{
			[SerializeField]
			protected Color _color = Color.white;

			public override Color GetColor()
			{
				return _color;
			}
		}

		[Serializable]
		public class PaletteDataReference : PaletteDataContent
		{
			[SerializeField]
			protected PaletteData _parent;

			public override Color GetColor()
			{
				if (!_parent)
				{
					return ErrorColor;
				}
				return _parent.GetColor();
			}
		}

		[Serializable]
		public class PaletteDataAdditive : PaletteDataReference
		{
			[SerializeField]
			protected Color _color = Color.white;

			public override Color GetColor()
			{
				if (_parent == null)
				{
					return _color;
				}
				Color color = _color;
				color *= _color.a;
				color.a = 0f;
				return _parent.GetColor() + color;
			}
		}

		[Serializable]
		public class PaletteDataMultiply : PaletteDataReference
		{
			[SerializeField]
			protected Color _color = Color.white;

			public override Color GetColor()
			{
				if (_parent == null)
				{
					return _color;
				}
				return _parent.GetColor() * _color;
			}
		}

		[SerializeReference]
		private PaletteDataContent _obj = new PaletteDataSimpleColor();

		private static Color ErrorColor = Color.magenta;

		[AssetIcon("100%", "100%", "0", "0", 64, IconAnchor.Center, IconAspect.Fit, "true", "#ffffff", 0, FontStyle.Normal, IconAnchor.Center, IconProjection.Perspective, -1, null)]
		public Color GetColor()
		{
			if (_obj == null)
			{
				return ErrorColor;
			}
			return _obj.GetColor();
		}

		public static implicit operator Color(PaletteData data)
		{
			return data.GetColor();
		}
	}
}
