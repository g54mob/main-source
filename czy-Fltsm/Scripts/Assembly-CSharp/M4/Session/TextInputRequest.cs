using Steamworks;
using UnityEngine.Events;

namespace M4.Session
{
	public class TextInputRequest
	{
		private static TextInputRequest _instance;

		private UnityAction<TextInputRequest> _callback;

		private PlatformSteam _platformSteam;

		public string Description { get; private set; }

		public uint MaximumCharacterCount { get; private set; }

		public string Text { get; private set; }

		public bool Succes { get; private set; }

		public PlatformSteam Platform
		{
			get
			{
				if (_platformSteam == null)
				{
					_platformSteam = Session.Platform as PlatformSteam;
				}
				return _platformSteam;
			}
		}

		public static void SingleLine(string description, uint maximumCharacterCount, string text, UnityAction<TextInputRequest> callback)
		{
			Create();
			_instance.Description = description;
			_instance.MaximumCharacterCount = maximumCharacterCount;
			_instance.Text = text;
			_instance.Succes = false;
			_instance._callback = callback;
			_instance.SingleLine();
		}

		private static TextInputRequest Create()
		{
			if (_instance == null)
			{
				_instance = new TextInputRequest();
			}
			return _instance;
		}

		public void SingleLine()
		{
			if (SteamManager.Initialized && SteamUtils.ShowGamepadTextInput(EGamepadTextInputMode.k_EGamepadTextInputModeNormal, EGamepadTextInputLineMode.k_EGamepadTextInputLineModeSingleLine, Description, MaximumCharacterCount, Text))
			{
				Platform.RegisterGamePadTextInputDismissedHandler(OnCallback);
			}
			else
			{
				OnCallback(default(GamepadTextInputDismissed_t));
			}
		}

		public void OnCallback(GamepadTextInputDismissed_t callback)
		{
			if (callback.m_bSubmitted && SteamUtils.GetEnteredGamepadTextInput(out var pchText, SteamUtils.GetEnteredGamepadTextLength()))
			{
				Text = pchText;
				Succes = true;
			}
			else
			{
				Succes = false;
			}
			_callback(this);
		}
	}
}
