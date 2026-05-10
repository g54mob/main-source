using Photon.Realtime;
using UnityEngine;

namespace Photon.Pun.UtilityScripts
{
	public class StatesGui : MonoBehaviour
	{
		public Rect GuiOffset;

		public bool DontDestroy;

		public bool ServerTimestamp;

		public bool DetailedConnection;

		public bool Server;

		public bool AppVersion;

		public bool UserId;

		public bool Room;

		public bool RoomProps;

		public bool EventsIn;

		public bool LocalPlayer;

		public bool PlayerProps;

		public bool Others;

		public bool Buttons;

		public bool ExpectedUsers;

		private Rect GuiRect;

		private static StatesGui Instance;

		private float native_width;

		private float native_height;

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		private void OnGUI()
		{
		}

		private string PlayerToString(Player player)
		{
			return null;
		}
	}
}
