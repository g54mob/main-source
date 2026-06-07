namespace FuryStudios.FurySDK
{
	public interface IUser
	{
		long UserID { get; }

		string DisplayName { get; }

		bool Authenticated { get; }
	}
}
