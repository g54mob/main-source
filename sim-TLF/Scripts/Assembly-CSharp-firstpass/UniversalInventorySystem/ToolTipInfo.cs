using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UniversalInventorySystem
{
	[Serializable]
	public class ToolTipInfo
	{
		[Serializable]
		public class TooltipText
		{
			[TextArea]
			public string text;

			public TextAlignmentOptions alignOptions;

			public FontStyles fontStyles;

			public TMP_FontAsset font;

			public int fontSize;

			public Color color;

			public AligmentOption aligmentOption;

			public XAligment pivot;

			public float pixelOrPercentage;
		}

		public bool useTooltip;

		public bool usePrefab;

		public GameObject tooltipPrefab;

		public Sprite sprite;

		public AligmentOption xAligmentOption;

		public XAligment xAlign;

		public float xPixelOrPercentage;

		public AligmentOption yAligmentOption;

		public YAligment yAlign;

		public float yPixelOrPercentage;

		public bool autoReAlign;

		public AutoRealignOptions autoRealignOptions;

		public Vector2 snapMargin;

		public Vector2 snapTo;

		public Color backgroudColor;

		public Vector2 size;

		public Vector2 padding;

		public Vector2 margin;

		public float maxWidth;

		public List<TooltipText> texts;
	}
}
