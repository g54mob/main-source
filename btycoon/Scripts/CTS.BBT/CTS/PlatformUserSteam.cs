using Steamworks;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Platforms/Steam/User")]
	public class PlatformUserSteam : ScriptableObject, IPlatformUser
	{
		public string GetUserID()
		{
			return SteamUser.GetSteamID().m_SteamID.ToString();
		}
	}
}
