using System;

public interface IParentalControl
{
	public struct FriendInfo
	{
		public Platform Platform;

		public ulong FriendID;

		public bool HasSamePlatform => Manager.platform.Platform == Platform;
	}

	void UpdateInfo();

	void RestrictInput(string textInput, Action<string> callback);

	bool MultiplayerAllowed(bool showUI);

	bool UGCAllowed(bool showUI);

	bool CommunicationAllowed(bool showUI);

	void CommunicationAllowed(bool showUI, FriendInfo[] friendInfos, Action<bool> callback);

	bool CrossPlayAllowed(bool showUI);
}
