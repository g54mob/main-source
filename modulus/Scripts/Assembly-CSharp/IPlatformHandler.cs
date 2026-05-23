using System;

public interface IPlatformHandler
{
	bool Ready { get; set; }

	Action OnPlatformReady { get; set; }

	void OpenWebPage(string url, bool forceWebLink = false);

	string GetUserId();

	string GetUserName();

	void GetAuthToken(Action<string> authComplete, Action<string> authError);

	void SetSupportersEditionAppId(string value);

	bool HasSupportersEdition();

	void CancelAuthToken();
}
