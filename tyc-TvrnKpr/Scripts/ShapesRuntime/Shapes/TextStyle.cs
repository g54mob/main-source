using System;
using TMPro;
using UnityEngine;

namespace Shapes
{
	[Serializable]
	public struct TextStyle
	{
		public static readonly TextStyle defaultTextStyle;

		public TMP_FontAsset font;

		public float size;

		public FontStyles style;

		public TextAlign alignment;

		public float characterSpacing;

		public float wordSpacing;

		public float lineSpacing;

		public float paragraphSpacing;

		public Vector4 margins;

		public bool wrap;

		public TextOverflowModes overflow;
	}
}
