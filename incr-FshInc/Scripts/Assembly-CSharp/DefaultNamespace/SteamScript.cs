using Steamworks;
using UnityEngine;

namespace DefaultNamespace
{
	public class SteamScript : MonoBehaviour
	{
		private void Start()
		{
			if (SteamManager.Initialized)
			{
				string personaName = SteamFriends.GetPersonaName();
				Debug.Log("Name" + personaName);
			}
		}
	}
}
