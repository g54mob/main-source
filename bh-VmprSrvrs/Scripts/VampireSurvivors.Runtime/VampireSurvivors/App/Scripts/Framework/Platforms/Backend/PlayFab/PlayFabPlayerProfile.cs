using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab
{
	public class PlayFabPlayerProfile : IPlayerProfile
	{
		private string _contactEmailAddress;

		private bool _isContactEmailAddressVerified;

		public PlayFabPlayerProfile(string contactEmailAddress = "", bool isContactEmailAddressVerified = false)
		{
		}

		public override bool HasContactEmailAddress()
		{
			return false;
		}

		public override string GetContactEmailAddress()
		{
			return null;
		}

		public override bool IsContactEmailAddressVerified()
		{
			return false;
		}
	}
}
