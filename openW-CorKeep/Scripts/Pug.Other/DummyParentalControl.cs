using System;

public class DummyParentalControl : IParentalControl
{
	public void UpdateInfo()
	{
	}

	public void RestrictInput(string textInput, Action<string> callback)
	{
		callback?.Invoke(textInput);
	}

	public bool MultiplayerAllowed(bool showUI)
	{
		return true;
	}

	public bool UGCAllowed(bool showUI)
	{
		return true;
	}

	public void CommunicationAllowed(bool showUI, IParentalControl.FriendInfo[] friendInfos, Action<bool> callback)
	{
		callback?.Invoke(CommunicationAllowed(showUI));
	}

	public bool CommunicationAllowed(bool showUI)
	{
		return true;
	}

	public bool CrossPlayAllowed(bool showUI)
	{
		return true;
	}
}
