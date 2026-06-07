using System;
using TMPro;
using UnityEngine;

namespace Shapes
{
	[Serializable]
	public struct TextStyle
	{
		public static readonly TextStyle defaultTextStyle = new TextStyle
		{
			font = ShapesAssets.Instance.defaultFont,
			size = 1f,
			style = FontStyles.Normal,
			alignment = TextAlign.Center,
			characterSpacing = 0f,
			wordSpacing = 0f,
			lineSpacing = 0f,
			paragraphSpacing = 0f,
			margins = Vector4.zero,
			wrap = TextWrappingModes.Normal,
			overflow = TextOverflowModes.Overflow,
			curvature = 0f,
			curvaturePivot = Vector2.zero
		};

		public TMP_FontAsset font;

		public float size;

		public FontStyles style;

		public TextAlign alignment;

		public float characterSpacing;

		public float wordSpacing;

		public float lineSpacing;

		public float paragraphSpacing;

		public Vector4 margins;

		public TextWrappingModes wrap;

		public TextOverflowModes overflow;

		public float curvature;

		public Vector2 curvaturePivot;
	}
}
