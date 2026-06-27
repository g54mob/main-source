namespace Alekrus.UnivarsalPlatform.UserProfiles
{
	public interface IUserProfileInfo
	{
		ILocalUserId LocalUserId { get; }

		IAccountId AccountId { get; }

		string DisplayName { get; }

		Image GetIcon(ImageSize parImageSize);
	}
}
