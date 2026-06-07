using System;
using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.DevConsole
{
	[Serializable]
	public class LogEntryColors
	{
		public Color ErrorColor;

		public Color ErrorColorHighlight;

		public Color MessageColor;

		public Color MessageColorHighlight;

		public Color WarningColor;

		public Color WarningColorHighlight;

		internal ColorBlock ErrorColors;

		internal ColorBlock MessageColors;

		internal ColorBlock WarningColors;

		internal void Initialize()
		{
			MessageColors = new ColorBlock
			{
				normalColor = MessageColor,
				highlightedColor = MessageColorHighlight,
				pressedColor = MessageColorHighlight,
				colorMultiplier = 1f,
				fadeDuration = 0.1f
			};
			WarningColors = new ColorBlock
			{
				normalColor = WarningColor,
				highlightedColor = WarningColorHighlight,
				pressedColor = WarningColorHighlight,
				colorMultiplier = 1f,
				fadeDuration = 0.1f
			};
			ErrorColors = new ColorBlock
			{
				normalColor = ErrorColor,
				highlightedColor = ErrorColorHighlight,
				pressedColor = ErrorColorHighlight,
				colorMultiplier = 1f,
				fadeDuration = 0.1f
			};
		}
	}
}
