namespace Heathen.SteamworksIntegration.UI
{
	public interface IUserProfile
	{
		UserData UserData { get; set; }

		void Apply(UserData user);
	}
}
