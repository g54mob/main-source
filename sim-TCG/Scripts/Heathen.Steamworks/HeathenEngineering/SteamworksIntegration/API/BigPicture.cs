using System;
using HeathenEngineering.Events;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration.API
{
	public static class BigPicture
	{
		public static class Client
		{
			private static UnityStringEvent eventGamepadTextInputDismissed = new UnityStringEvent();

			private static UnityEvent eventGamepadTextInputShown = new UnityEvent();

			private static Callback<GamepadTextInputDismissed_t> m_GamepadTextInputDismissed_t;

			public static UnityEvent EventGamepadTextInputShown
			{
				get
				{
					if (eventGamepadTextInputShown == null)
					{
						eventGamepadTextInputShown = new UnityEvent();
					}
					return eventGamepadTextInputShown;
				}
			}

			public static UnityStringEvent EventGamepadTextInputDismissed
			{
				get
				{
					if (eventGamepadTextInputDismissed == null)
					{
						eventGamepadTextInputDismissed = new UnityStringEvent();
					}
					if (m_GamepadTextInputDismissed_t == null)
					{
						m_GamepadTextInputDismissed_t = Callback<GamepadTextInputDismissed_t>.Create(HandleGameTextInputDismissed);
					}
					return eventGamepadTextInputDismissed;
				}
			}

			public static bool InBigPicture => SteamUtils.IsSteamInBigPictureMode();

			public static bool RunningOnDeck => SteamUtils.IsSteamRunningOnSteamDeck();

			[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
			private static void Init()
			{
				m_GamepadTextInputDismissed_t = null;
				eventGamepadTextInputDismissed = new UnityStringEvent();
				eventGamepadTextInputShown = new UnityEvent();
			}

			private static void HandleGameTextInputDismissed(GamepadTextInputDismissed_t result)
			{
				if (result.m_bSubmitted && SteamUtils.GetEnteredGamepadTextInput(out var pchText, result.m_unSubmittedText))
				{
					eventGamepadTextInputDismissed.Invoke(pchText);
				}
			}

			public static bool ShowTextInput(EGamepadTextInputMode inputMode, EGamepadTextInputLineMode lineMode, string description, uint maxLength, string currentText)
			{
				if (SteamUtils.ShowGamepadTextInput(inputMode, lineMode, description, maxLength, currentText))
				{
					eventGamepadTextInputShown.Invoke();
					return true;
				}
				return false;
			}

			public static bool ShowTextInput(EGamepadTextInputMode inputMode, EGamepadTextInputLineMode lineMode, string description, int maxLength, string currentText)
			{
				if (SteamUtils.ShowGamepadTextInput(inputMode, lineMode, description, Convert.ToUInt32(maxLength), currentText))
				{
					eventGamepadTextInputShown.Invoke();
					return true;
				}
				return false;
			}
		}
	}
}
