using System;

namespace FuryStudios.FurySDK
{
	public interface ISystemMessenger
	{
		void ShowOverlay(string message, float duration);

		void ShowConfirm(string message, string confirmButtonText, Action callback);

		void ShowPrompt(string message, string positiveButtonText, string negativeButtonText, Action<bool> callback);

		void Discard(string message);
	}
}
