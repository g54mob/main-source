using UnityEngine;

public class RadicalMainMenuOption_Singleplayer : RadicalMainMenuOption
{
	[Tooltip("Enable for UI elements which should start a strictly offline game even if network is available.")]
	[SerializeField]
	private bool _forceOffline;

	private bool _doNetworkCheckInBackground = true;

	public override void OnActivated()
	{
		base.OnActivated();
		Manager.networking.OfflineSession = _forceOffline;
		Manager.networking.ResetConnectSettings();
		if (_forceOffline)
		{
			Manager.menu.PushMenu(RadicalMenu.MenuType.SELECT_WORLD);
			return;
		}
		Manager.input.DisableSystemInput();
		Manager.networking.CanUserPlayMultiplayer(HasPrivilegesCallback, joining: false, showUI: true, _doNetworkCheckInBackground);
	}

	private void HasPrivilegesCallback(bool hasAllRequestedPrivileges)
	{
		Manager.input.EnableSystemInput();
		if (hasAllRequestedPrivileges)
		{
			Manager.menu.PushMenu(RadicalMenu.MenuType.SELECT_WORLD);
		}
	}
}
