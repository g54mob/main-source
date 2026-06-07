using FishNet.Managing;
using UnityEngine;

namespace ScheduleOne.Networking
{
	[RequireComponent(typeof(NetworkManager))]
	public class AutoNetworkStart : MonoBehaviour
	{
		private enum EAutoStartType
		{
			Disabled = 0,
			Host = 1,
			Server = 2,
			Client = 3
		}

		[SerializeField]
		private EAutoStartType _autoStartType;
	}
}
