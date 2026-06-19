using System.Collections.Generic;

public class RadicalMainMenuOption_JoinGame : RadicalMainMenuOption
{
	public override void OnActivated()
	{
		base.OnActivated();
		if (Manager.filesystemManager.BackingStorageIsFull())
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Error/BackingStorageFull", null, menuInputCooldown: true, 0f, 5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, null, new List<string>(), 10f, 0f, 0, 20f);
			return;
		}
		Manager.networking.OfflineSession = false;
		Manager.input.DisableSystemInput();
		bool checkNetworking = false;
		Manager.networking.CanUserPlayMultiplayer(HasPrivilegesCallback, joining: true, showUI: true, doInBackground: false, checkNetworking);
	}

	private void HasPrivilegesCallback(bool hasAllRequestedPrivileges)
	{
		Manager.input.EnableSystemInput();
		if (hasAllRequestedPrivileges)
		{
			Manager.menu.PushMenu(RadicalMenu.MenuType.JOIN_GAME);
		}
	}
}
