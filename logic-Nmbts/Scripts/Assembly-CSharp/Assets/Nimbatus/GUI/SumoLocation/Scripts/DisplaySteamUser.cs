using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using I2.Loc;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SumoLocation.Scripts
{
	public class DisplaySteamUser : MonoBehaviour
	{
		public NimbatusDrone Drone;

		public UILabel NameLabel;

		private bool _wasInitialized;

		public void Update()
		{
			if (_wasInitialized)
			{
				return;
			}
			NameLabel.text = "";
			if (SteamManager.Initialized)
			{
				ulong userId = Drone.DroneData.UserId;
				if (userId != 0)
				{
					string friendPersonaName = SteamFriends.GetFriendPersonaName(new CSteamID(userId));
					NameLabel.text = LabelHelper.White + LocalizationManager.GetTermTranslation("Tournaments/BuiltBy") + " " + LabelHelper.DarkOrange + friendPersonaName;
					_wasInitialized = true;
				}
			}
		}
	}
}
