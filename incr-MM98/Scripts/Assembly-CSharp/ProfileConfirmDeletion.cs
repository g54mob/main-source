public readonly struct ProfileConfirmDeletion
{
	public readonly int Profile;

	public readonly string Studio;

	public ProfileConfirmDeletion(int profile, string studio)
	{
		Profile = profile;
		Studio = studio;
	}
}
