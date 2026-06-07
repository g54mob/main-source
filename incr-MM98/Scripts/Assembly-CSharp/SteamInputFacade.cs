using Steamworks;

public class SteamInputFacade : SteamFacade
{
	private Callback<GamepadTextInputDismissed_t> _gamepadTextInputDismissedCallback;

	public override void Initialize()
	{
		base.Initialize();
		_gamepadTextInputDismissedCallback = Callback<GamepadTextInputDismissed_t>.Create(OnGamepadTextInputDismissed);
	}

	public bool IsBigPicture()
	{
		if (Initialized)
		{
			return SteamUtils.IsSteamInBigPictureMode();
		}
		return false;
	}

	public bool IsSteamDeck()
	{
		if (Initialized)
		{
			return SteamUtils.IsSteamRunningOnSteamDeck();
		}
		return false;
	}

	public bool IsVR()
	{
		if (Initialized)
		{
			return SteamUtils.IsSteamRunningInVR();
		}
		return false;
	}

	public void ShowKeyboard(string text, string description, uint maxLength, bool multiline = false)
	{
		EGamepadTextInputLineMode eLineInputMode = (multiline ? EGamepadTextInputLineMode.k_EGamepadTextInputLineModeMultipleLines : EGamepadTextInputLineMode.k_EGamepadTextInputLineModeSingleLine);
		SteamUtils.ShowGamepadTextInput(EGamepadTextInputMode.k_EGamepadTextInputModeNormal, eLineInputMode, description, maxLength, text);
	}

	private void OnGamepadTextInputDismissed(GamepadTextInputDismissed_t param)
	{
		if (!param.m_bSubmitted)
		{
			EventHub.Scene.Publish(GamepadTextInputDismissed.Cancelled);
			return;
		}
		uint enteredGamepadTextLength = SteamUtils.GetEnteredGamepadTextLength();
		if (!SteamUtils.GetEnteredGamepadTextInput(out var pchText, enteredGamepadTextLength + 1))
		{
			EventHub.Scene.Publish(GamepadTextInputDismissed.Cancelled);
		}
		else
		{
			EventHub.Scene.Publish(new GamepadTextInputDismissed(pchText));
		}
	}
}
