using System;
using System.Text;
using DV.Localization;
using I2.Loc;

namespace DV.Game.Tutorial
{
	[AttributeUsage(AttributeTargets.Field)]
	public class ControlHintAttribute : Attribute
	{
		private string messageCache;

		private string cachedLanguage;

		private bool? vrState;

		public PreferencesExclusivity ExclusiveTo { get; private set; }

		public string ActionKey { get; private set; }

		public string ActionValue { get; private set; }

		public string ActionValueVR { get; private set; }

		public string WandValue { get; private set; }

		public bool HoldButton { get; private set; }

		public bool LocalizeValue { get; private set; }

		public ControlHintAttribute(string key, string value, string vrValue = null, bool holdButton = false, PreferencesExclusivity exclusiveTo = PreferencesExclusivity.Any, string wandValue = null, bool localizeValue = false)
		{
			ActionKey = key;
			ActionValue = value;
			ActionValueVR = vrValue;
			WandValue = wandValue;
			LocalizeValue = localizeValue;
			HoldButton = holdButton;
			ExclusiveTo = exclusiveTo;
		}

		private string GetValue(bool vr, bool wand)
		{
			if (vr && wand && !string.IsNullOrEmpty(WandValue))
			{
				return WandValue;
			}
			if (vr && !string.IsNullOrEmpty(ActionValueVR))
			{
				return ActionValueVR;
			}
			return ActionValue;
		}

		public string GetMessage()
		{
			if (messageCache == null || cachedLanguage != LocalizationManager.CurrentLanguage || !vrState.HasValue || vrState.Value != VRManager.IsVREnabled())
			{
				bool flag = VRManager.IsVREnabled();
				bool wand = flag && VRManager.AnyWandController();
				if ((ExclusiveTo == PreferencesExclusivity.NonVR && flag) || (ExclusiveTo == PreferencesExclusivity.VR && !flag))
				{
					messageCache = string.Empty;
					cachedLanguage = LocalizationManager.CurrentLanguage;
					vrState = flag;
					return messageCache;
				}
				string value = GetValue(flag, wand);
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(LocalizationAPI.L(ActionKey));
				if (!string.IsNullOrEmpty(value))
				{
					stringBuilder.Append("<color=#00ffff>  \\u00BB  </color>");
					if (HoldButton)
					{
						string text = LocalizationAPI.L("tutorial/controlhint/generic/hold");
						stringBuilder.Append("<color=#ffff00>");
						stringBuilder.Append(text.Replace("{}", "<b>" + TutorialHelper.LocalizeAndFormatMarkups(value, LocalizeValue) + "</b>"));
						stringBuilder.Append("</color>");
					}
					else
					{
						stringBuilder.Append("<color=#ffff00>");
						if (!LocalizeValue)
						{
							stringBuilder.Append("<b>");
						}
						stringBuilder.Append(TutorialHelper.LocalizeAndFormatMarkups(value, LocalizeValue));
						if (!LocalizeValue)
						{
							stringBuilder.Append("</b>");
						}
						stringBuilder.Append("</color>");
					}
				}
				messageCache = stringBuilder.ToString();
				cachedLanguage = LocalizationManager.CurrentLanguage;
				vrState = flag;
			}
			return messageCache;
		}
	}
}
