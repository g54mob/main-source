using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ButtonKeyCommandTooltipViewNew : TooltipViewNew
	{
		[SerializeField]
		private string titleTextPrefix;

		[SerializeField]
		private string infoTextPrefix;

		private BodyType workerBodyType = BodyType.Male;

		private string orderType;

		private KeyInputEvent keyInputEvent;

		public void Init(string orderType, KeyInputEvent keyInputEvent)
		{
			this.orderType = orderType;
			this.keyInputEvent = keyInputEvent;
		}

		public void SetBodyType(BodyType workerBodyType)
		{
			this.workerBodyType = workerBodyType;
		}

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			string text = "  " + GetKeyCodeText(keyInputEvent);
			string text2 = ((orderType != string.Empty) ? orderType : keyInputEvent.ToString());
			if (titleTextPrefix.Length > 0)
			{
				string line = MonoSingleton<LocalizationController>.Instance.GetText(titleTextPrefix + "_" + text2.ToLower(), workerBodyType) + text;
				AppendLine(line, TooltipStyles.TooltipTitle);
			}
			if (infoTextPrefix.Length > 0)
			{
				string text3 = MonoSingleton<LocalizationController>.Instance.GetText(infoTextPrefix + "_" + text2.ToLower(), workerBodyType);
				AppendLine(text3);
			}
			return lines;
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
	}
}
