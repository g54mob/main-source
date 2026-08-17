using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;

public class PlayFabPlayerProfile(string contactEmailAddress = "", bool isContactEmailAddressVerified = false) : IPlayerProfile
{
	private string _contactEmailAddress = contactEmailAddress;

	private bool _isContactEmailAddressVerified = isContactEmailAddressVerified;

	public override bool HasContactEmailAddress()
	{
		string contactEmailAddress = _contactEmailAddress;
		if (_contactEmailAddress != null && contactEmailAddress._stringLength > 0)
		{
			return true;
		}
		return false;
	}

	public override string GetContactEmailAddress()
	{
		return _contactEmailAddress;
	}

	public override bool IsContactEmailAddressVerified()
	{
		return _isContactEmailAddressVerified;
	}
}
