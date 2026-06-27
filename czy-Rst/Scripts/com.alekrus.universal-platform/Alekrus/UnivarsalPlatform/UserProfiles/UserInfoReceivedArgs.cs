namespace Alekrus.UnivarsalPlatform.UserProfiles
{
	public class UserInfoReceivedArgs : ResultArgs
	{
		public ILocalUserId UserId { get; }

		public UserInfoReceivedArgs(ILocalUserId parUserId, IResult parResult)
			: base(parResult)
		{
			UserId = parUserId;
		}
	}
}
