using System;
using Steamworks;
using UnityEngine;

namespace Dorfromantik
{
	public class SteamKeyboardOpener : MonoBehaviour
	{
		[SerializeField]
		private NetworkEventRouter networkEventRouter;

		private Callback<GamepadTextInputDismissed_t> m_GamepadTextInputDismissed;

		private Callback<FloatingGamepadTextInputDismissed_t> m_FloatingGamepadTextInputDismissed;

		private Action<string> textEnteredCallback;

		private void Start()
		{
			if (SteamUtils.IsSteamRunningOnSteamDeck())
			{
				Debug.Log("Application is running on SteamDeck");
				m_GamepadTextInputDismissed = Callback<GamepadTextInputDismissed_t>.Create(OnGamepadTextInputDismissed);
				m_FloatingGamepadTextInputDismissed = Callback<FloatingGamepadTextInputDismissed_t>.Create(OnFloatingGamepadTextInputDismissed);
				networkEventRouter.OnRequestOpenSystemKeyboard += OpenKeyboard;
			}
		}

		public void OpenKeyboard(string descriptionLabel, int maxTextLength, string existingText, Action<string> textEnteredCallback)
		{
			if (SteamUtils.IsSteamRunningOnSteamDeck())
			{
				SteamUtils.ShowFloatingGamepadTextInput(EFloatingGamepadTextInputMode.k_EFloatingGamepadTextInputModeModeSingleLine, 200, 300, 500, 100);
			}
			this.textEnteredCallback = textEnteredCallback;
		}

		private void OnGamepadTextInputDismissed(GamepadTextInputDismissed_t param)
		{
			Debug.Log($"Floating Gamepad Text Input Dismissed {param.m_unSubmittedText}");
			Debug.Log("SteamUtils.GetEnteredGamepadTextLength() - " + SteamUtils.GetEnteredGamepadTextLength());
			string pchText;
			bool enteredGamepadTextInput = SteamUtils.GetEnteredGamepadTextInput(out pchText, param.m_unSubmittedText + 1);
			Debug.Log("SteamUtils.GetEnteredGamepadTextInput(out Text, pCallback.m_unSubmittedText + 1) - " + enteredGamepadTextInput + " -- " + pchText);
			if (enteredGamepadTextInput)
			{
				textEnteredCallback(pchText);
			}
		}

		private void OnFloatingGamepadTextInputDismissed(FloatingGamepadTextInputDismissed_t param)
		{
			Debug.Log("[" + 738 + " - FloatingGamepadTextInputDismissed], param: " + param);
			textEnteredCallback?.Invoke(string.Empty);
		}
	}
}
