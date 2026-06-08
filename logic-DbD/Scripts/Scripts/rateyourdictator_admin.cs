public class rateyourdictator_admin : Website
{
	protected override void Start()
	{
		base.Start();
		if (!rateyourdictator_login.GetLogin())
		{
			LaunchInnerSite("rateyourdictator.gov/admin/login", playSound: false);
		}
	}
}
