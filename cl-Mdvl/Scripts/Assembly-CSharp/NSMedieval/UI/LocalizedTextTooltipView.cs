using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.UI
{
	public class LocalizedTextTooltipView : TooltipViewNew
	{
		[SerializeField]
		private List<string> textKeys = new List<string>();

		[SerializeField]
		private List<string> styles = new List<string>();

		[SerializeField]
		private List<KeyInputEvent> keyInputEvents = new List<KeyInputEvent>();

		[Tooltip("If this is true, the tooltip will force apply the styles from Styles list to the lines.\nOtherwise the first line will always be formatted as Title")]
		[SerializeField]
		private bool disableAutoStyling;

		private string nonLocalizedText;

		public List<string> TextKeys
		{
			get
			{
				return textKeys;
			}
			set
			{
				textKeys = value;
			}
		}

		public void SetNonLocalizedText(string nonLocalizedText)
		{
			this.nonLocalizedText = nonLocalizedText;
		}

		private static string GetKeyCodeText(KeyInputEvent keyInputEvent)
		{
			KeyCode keyCode = MonoSingleton<GlobalSaveController>.Instance.GetKeyCode(keyInputEvent);
			if (keyCode != KeyCode.None)
			{
				return "<style=Shortcut>[" + MonoSingleton<LocalizationController>.Instance.GetText($"keycode_{keyCode}") + "]</style>";
			}
			return string.Empty;
		}

		protected override List<string> GetLinesToShow()
		{
			if (!string.IsNullOrEmpty(nonLocalizedText))
			{
				return new List<string> { nonLocalizedText };
			}
			ClearLines();
			for (int i = 0; i < textKeys.Count; i++)
			{
				string text;
				if (keyInputEvents.Count > i && keyInputEvents[i] != KeyInputEvent.None)
				{
					string keyCodeText = GetKeyCodeText(keyInputEvents[i]);
					text = MonoSingleton<LocalizationController>.Instance.GetText(textKeys[i]) + "  " + keyCodeText;
				}
				else
				{
					text = MonoSingleton<LocalizationController>.Instance.GetText(textKeys[i]) ?? "";
				}
				if (disableAutoStyling)
				{
					string lineStyle = ((styles != null && i < styles.Count) ? styles[i] : string.Empty);
					AppendLine(text, lineStyle);
				}
				else if (!string.IsNullOrEmpty(text))
				{
					if (i == 0 && (styles == null || styles.Count <= i || !styles[i].Equals("Default")))
					{
						AppendLine(text, TooltipStyles.TooltipTitle);
					}
					else
					{
						AppendLine(text);
					}
				}
			}
			return lines;
		}

		public void SetTooltipKey(string keyId)
		{
			textKeys.Clear();
			textKeys.Add(keyId);
		}
	}
}
