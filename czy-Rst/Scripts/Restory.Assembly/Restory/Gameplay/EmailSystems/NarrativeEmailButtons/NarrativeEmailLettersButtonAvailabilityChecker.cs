using System;
using System.Collections.Generic;
using Restory.Data.Email;
using UnityEngine;

namespace Restory.Gameplay.EmailSystems.NarrativeEmailButtons
{
	public class NarrativeEmailLettersButtonAvailabilityChecker
	{
		private readonly Dictionary<Type, IEmailBlockableButtonHandler> handlersDictionary = new Dictionary<Type, IEmailBlockableButtonHandler>();

		public NarrativeEmailLettersButtonAvailabilityChecker(IEnumerable<IEmailBlockableButtonHandler> emailBlockableButtonHandlers)
		{
			foreach (IEmailBlockableButtonHandler emailBlockableButtonHandler in emailBlockableButtonHandlers)
			{
				Type baseType = emailBlockableButtonHandler.GetType().BaseType;
				if (baseType == null)
				{
					Debug.LogError("[NarrativeEmailLettersButtonAvailabilityChecker] tried to fill its dictionary with email button handlers, but handler [" + emailBlockableButtonHandler.GetType().FullName + "] has no base type!");
					continue;
				}
				Type[] genericArguments = baseType.GetGenericArguments();
				if (genericArguments.Length == 0)
				{
					Debug.LogError("[NarrativeEmailLettersButtonAvailabilityChecker] tried to fill its dictionary with email button handlers, but handler [" + emailBlockableButtonHandler.GetType().FullName + "]'s base type [" + baseType.FullName + "] has no generic arguments!");
				}
				else
				{
					handlersDictionary.Add(genericArguments[0], emailBlockableButtonHandler);
				}
			}
		}

		public bool ShouldButtonBeEnabled(EmailLetterNarrativeRecord letterRecord, PressedEmailButtons buttonToCheck, out string disabledButtonExplanationLocalizationKey)
		{
			switch (buttonToCheck)
			{
			case PressedEmailButtons.None:
				disabledButtonExplanationLocalizationKey = string.Empty;
				return false;
			case PressedEmailButtons.OkButton:
				return ShouldButtonBeEnabled(letterRecord.Message.OkButtonPressActions, out disabledButtonExplanationLocalizationKey);
			case PressedEmailButtons.YesButton:
				return ShouldButtonBeEnabled(letterRecord.Message.YesButtonPressActions, out disabledButtonExplanationLocalizationKey);
			case PressedEmailButtons.NoButton:
				return ShouldButtonBeEnabled(letterRecord.Message.NoButtonPressActions, out disabledButtonExplanationLocalizationKey);
			default:
				throw new NotImplementedException();
			}
		}

		private bool ShouldButtonBeEnabled(IEnumerable<EmailButtonSettingsBase> buttonSettingsList, out string refusalMessageLocalizationKey)
		{
			foreach (EmailButtonSettingsBase buttonSettings in buttonSettingsList)
			{
				if (buttonSettings is EmailBlockableButtonSettingsBase emailBlockableButtonSettingsBase)
				{
					if (!handlersDictionary.TryGetValue(buttonSettings.GetType(), out var value))
					{
						Debug.LogError("[NarrativeEmailLettersButtonAvailabilityChecker] tried to process button action [" + buttonSettings.GetType().FullName + "], but had no handler for it!");
					}
					else if (!value.ShouldButtonBeEnabled(buttonSettings))
					{
						refusalMessageLocalizationKey = emailBlockableButtonSettingsBase.DisabledButtonExplanationLocalizationKey;
						return false;
					}
				}
			}
			refusalMessageLocalizationKey = string.Empty;
			return true;
		}
	}
}
