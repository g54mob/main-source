using System;
using System.Collections.Generic;

public interface IPlatformUserManager
{
	List<PlatformUserID> PlatformFriends { get; }

	event Action<UserSignInCompleteVO> UserSignInComplete;

	void GetLocalUserName(Action<string> callback);

	void GetUserProfile(PlatformUserID userId, UserImageSize size, Action<UserPlatformProfile> callback);

	void OpenUserProfile(PlatformUserID userId);

	void GetUserDisplayImage(PlatformUserID userId, UserImageSize size, Action<UserPlatformProfile> callback);

	void SignInDefaultUser();

	PlatformUserID GetPlatformUserID();

	bool IsUserIdValid(PlatformUserID id);

	void RefreshPlatformFriends(bool getProfiles = false);

	void SendInvitation(string sessionId, List<PlatformUserID> invitees, Action<bool> callback);
}
