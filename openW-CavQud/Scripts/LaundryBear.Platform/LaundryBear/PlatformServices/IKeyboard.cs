using System;

namespace LaundryBear.PlatformServices
{
	public interface IKeyboard
	{
		void ShowKeyboard(KeyboardArgs keyboardArgs, string initialText, Action<KeyboardResult, string> onComplete);
	}
}
