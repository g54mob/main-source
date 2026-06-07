using System.Linq;
using DV.Utils;
using Steamworks;
using TMPro;
using UnityEngine;

namespace DV.Platform.Steam
{
	public static class SteamGamepadKeyboardHandler
	{
		private const float STEAM_KEYBOARD_REOPEN_SECONDS = 1f;

		private static float lastKeyboardCloseTime;

		private static Option<APlatformProvider.TextInputRequest> pendingInputRequest;

		private static bool ShouldActivate
		{
			get
			{
				if (!DVSteamworks.IsSteamDeck)
				{
					if (DVSteamworks.IsSteamInBigPictureMode)
					{
						return SteamInput.Controllers.Any();
					}
					return false;
				}
				return true;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void Initialize()
		{
			APlatformProvider instance = SingletonBehaviour<APlatformProvider>.Instance;
			instance.OnCanStartTextInput.Add(CanStartTextInput);
			instance.OnTextInputStarted += OnTextInputStarted;
		}

		private static bool CanStartTextInput()
		{
			if (ShouldActivate)
			{
				return Time.realtimeSinceStartup - lastKeyboardCloseTime > 1f;
			}
			return true;
		}

		private static void OnTextInputStarted(APlatformProvider.TextInputRequest inputRequest)
		{
			if (!ShouldActivate)
			{
				return;
			}
			if (pendingInputRequest.IsSome())
			{
				OnGamepadTextInputDismissed(success: false);
				SingletonBehaviour<APlatformProvider>.Instance.RequestTextInput(inputRequest);
				return;
			}
			pendingInputRequest = inputRequest;
			if (!SteamUtils.ShowGamepadTextInput((inputRequest.InputField.contentType == TMP_InputField.ContentType.Password) ? GamepadTextInputMode.Password : GamepadTextInputMode.Normal, inputRequest.IsMultiLine ? GamepadTextInputLineMode.MultipleLines : GamepadTextInputLineMode.SingleLine, inputRequest.Description, (inputRequest.InputField.characterLimit == 0) ? int.MaxValue : inputRequest.InputField.characterLimit, inputRequest.InputField.text))
			{
				pendingInputRequest = default(Option<APlatformProvider.TextInputRequest>);
			}
			else
			{
				SteamUtils.OnGamepadTextInputDismissed += OnGamepadTextInputDismissed;
			}
		}

		private static void OnGamepadTextInputDismissed(bool success)
		{
			SteamUtils.OnGamepadTextInputDismissed -= OnGamepadTextInputDismissed;
			if (pendingInputRequest.IsSome(out var value))
			{
				value.OnTextInput?.Invoke(new APlatformProvider.TextInputResult(isFinished: true, success, success ? SteamUtils.GetEnteredGamepadText() : null));
				SingletonBehaviour<APlatformProvider>.Instance.FinishTextInput();
				lastKeyboardCloseTime = Time.realtimeSinceStartup;
				pendingInputRequest = default(Option<APlatformProvider.TextInputRequest>);
			}
		}
	}
}
