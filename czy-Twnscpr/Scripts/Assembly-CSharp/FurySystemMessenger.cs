using System;
using FuryStudios.FurySDK.Utils;

public sealed class FurySystemMessenger : PlatformSystemMessengerBase
{
	protected override bool IsShowingMessage => false;

	protected override bool IsReadyToShowMessage => false;

	protected override void OnShowOverlay(string message)
	{
	}

	protected override void OnDiscardOverlay()
	{
	}

	protected override void OnShowConfirm(string message, string okButtonText, Action okButtonCallback)
	{
	}

	protected override void OnShowPrompt(string message, string yesButtonText, string noButtonText, Action yesButtonCallback, Action noButtonCallback)
	{
	}

	protected override void OnDiscardMessage(string message)
	{
	}
}
