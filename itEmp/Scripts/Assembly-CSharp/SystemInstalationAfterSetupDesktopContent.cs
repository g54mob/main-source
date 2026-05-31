using System;

[Serializable]
public class SystemInstalationAfterSetupDesktopContent
{
	[AppNameDropdown]
	public string nameInAppBase;

	public bool createShortcutOnDesktop;

	public bool notInstall;
}
