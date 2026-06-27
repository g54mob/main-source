namespace Alekrus.UnivarsalPlatform.UserProfiles
{
	public interface ILocalUserProfiles : IInitializable, IUpdatable, ISubInterface<IMain>
	{
		event LocalUsersInfoChangedEventHandler LocalUsersInfoChanged;

		event UserInfoReceivedEventHandler UserInfoReceived;

		int GetCountLocalUsers();

		ILocalUserId GetPrimaryLocalUserId();

		ILocalUserId GetLocalUserId(int parUserIndex);

		int GetProfileIndex(ILocalUserId parUserId);

		IUserProfileInfo GetUserProfileInfo(ILocalUserId parUserId);

		bool RequestUserInfo(ILocalUserId parUserId);
	}
}
