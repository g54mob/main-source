using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Photon.Pun.UtilityScripts
{
	public class PlayerNumbering : MonoBehaviourPunCallbacks
	{
		public delegate void PlayerNumberingChanged();

		public static PlayerNumbering instance;

		public static Player[] SortedPlayers;

		public const string RoomPlayerIndexedProp = "pNr";

		public bool dontDestroyOnLoad;

		public static event PlayerNumberingChanged OnPlayerNumberingChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Awake()
		{
		}

		public override void OnJoinedRoom()
		{
		}

		public override void OnLeftRoom()
		{
		}

		public override void OnPlayerEnteredRoom(Player newPlayer)
		{
		}

		public override void OnPlayerLeftRoom(Player otherPlayer)
		{
		}

		public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
		{
		}

		public void RefreshData()
		{
		}
	}
}
