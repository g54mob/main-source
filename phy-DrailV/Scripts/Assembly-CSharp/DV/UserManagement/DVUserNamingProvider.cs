using DV.Platform.Steam;
using DV.UserManagement.Integration;
using Steamworks;
using UnityEngine;

namespace DV.UserManagement
{
	[CreateAssetMenu(menuName = "DV/User Naming Provider")]
	public class DVUserNamingProvider : AUserNamingProvider
	{
		public override string DefaultName
		{
			get
			{
				if (!DVSteamworks.Success)
				{
					return "Player";
				}
				return SteamClient.Name;
			}
		}
	}
}
