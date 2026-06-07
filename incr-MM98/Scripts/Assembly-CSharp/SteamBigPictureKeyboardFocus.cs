using System;
using MessagePipe;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

[RequireComponent(typeof(TMP_InputField))]
public class SteamBigPictureKeyboardFocus : MonoBehaviour
{
	[SerializeField]
	private LocalizedString description;

	private TMP_InputField _inputField;

	private IDisposable _disposable;

	private void Awake()
	{
		if (SteamManager.Input.IsBigPicture())
		{
			_inputField = GetComponent<TMP_InputField>();
			_inputField.onSelect.AddListener(HandleOnScreenKeyboard);
		}
	}

	private void OnDestroy()
	{
		_disposable?.Dispose();
	}

	private void HandleOnScreenKeyboard(string _)
	{
		_disposable?.Dispose();
		_disposable = EventHub.Scene.Subscribe(InputDismissed, Array.Empty<MessageHandlerFilter<GamepadTextInputDismissed>>());
		SteamManager.Input.ShowKeyboard(_inputField.text, description.GetLocalizedString(), (_inputField.characterLimit > 0) ? ((uint)_inputField.characterLimit) : 31u);
	}

	private void InputDismissed(GamepadTextInputDismissed ctx)
	{
		_disposable?.Dispose();
		if (!ctx.IsCancelled)
		{
			_inputField.text = ctx.Text;
		}
	}
}
