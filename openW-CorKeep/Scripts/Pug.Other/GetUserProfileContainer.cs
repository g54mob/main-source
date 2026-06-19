using System;

public class GetUserProfileContainer
{
	public PlatformUserID PlatformUserID;

	public UserImageSize TargetSize;

	public Action<UserPlatformProfile> CallbackGetUserDisplayProfile;

	public GetUserProfileContainer(PlatformUserID platformUserID, UserImageSize targetSize, Action<UserPlatformProfile> callbackGetUserDisplayProfile)
	{
		PlatformUserID = platformUserID;
		TargetSize = targetSize;
		CallbackGetUserDisplayProfile = callbackGetUserDisplayProfile;
	}
}
