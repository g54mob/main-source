using System;
using System.Collections.Generic;
using Restory.Data.Email;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.EmailSystems.NarrativeEmailButtons
{
	public class NarrativeEmailLettersButtonPressDispatcher : IInitializable, IDisposable
	{
		private readonly EmailService emailService;

		private readonly Dictionary<Type, IEmailButtonHandler> handlersDictionary = new Dictionary<Type, IEmailButtonHandler>();

		public NarrativeEmailLettersButtonPressDispatcher(EmailService emailService, IEnumerable<IEmailButtonHandler> handlers)
		{
			this.emailService = emailService;
			foreach (IEmailButtonHandler handler in handlers)
			{
				Type baseType = handler.GetType().BaseType;
				if (baseType == null)
				{
					Debug.LogError("[NarrativeEmailLettersButtonPressDispatcher] tried to fill its dictionary with email button handlers, but handler [" + handler.GetType().FullName + "] has no base type!");
					continue;
				}
				Type[] genericArguments = baseType.GetGenericArguments();
				if (genericArguments.Length == 0)
				{
					Debug.LogError("[NarrativeEmailLettersButtonPressDispatcher] tried to fill its dictionary with email button handlers, but handler [" + handler.GetType().FullName + "]'s base type [" + baseType.FullName + "] has no generic arguments!");
				}
				else
				{
					handlersDictionary.Add(genericArguments[0], handler);
				}
			}
		}

		public void Initialize()
		{
			emailService.OnNarrativeLetterButtonPressed += ResolveLetterButtonPressed;
		}

		public void Dispose()
		{
			if (emailService.MonoShellExists())
			{
				emailService.OnNarrativeLetterButtonPressed -= ResolveLetterButtonPressed;
			}
		}

		private void ResolveLetterButtonPressed(EmailLetterNarrativeRecord letterRecord)
		{
			switch (letterRecord.PressedButton)
			{
			case PressedEmailButtons.OkButton:
				PerformButtonPressActions(letterRecord.Message.OkButtonPressActions);
				break;
			case PressedEmailButtons.YesButton:
				PerformButtonPressActions(letterRecord.Message.YesButtonPressActions);
				break;
			case PressedEmailButtons.NoButton:
				PerformButtonPressActions(letterRecord.Message.NoButtonPressActions);
				break;
			default:
				throw new NotImplementedException();
			case PressedEmailButtons.None:
				break;
			}
		}

		private void PerformButtonPressActions(IEnumerable<EmailButtonSettingsBase> buttonPressActions)
		{
			foreach (EmailButtonSettingsBase buttonPressAction in buttonPressActions)
			{
				PerformButtonPressAction(buttonPressAction);
			}
		}

		private void PerformButtonPressAction(EmailButtonSettingsBase buttonSettings)
		{
			Type type = buttonSettings.GetType();
			if (!handlersDictionary.TryGetValue(type, out var value))
			{
				Debug.LogError("[NarrativeEmailLettersButtonPressDispatcher] tried to process button action [" + type.FullName + "], but had no handler for it!");
			}
			else
			{
				value.HandleButtonPress(buttonSettings);
			}
		}
	}
}
