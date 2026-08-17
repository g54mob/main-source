namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;

public abstract class IPlayerProfile
{
	public abstract bool HasContactEmailAddress();

	public abstract string GetContactEmailAddress();

	public abstract bool IsContactEmailAddressVerified();
}
