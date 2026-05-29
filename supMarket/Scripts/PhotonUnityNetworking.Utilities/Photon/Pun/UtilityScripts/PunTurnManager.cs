using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Photon.Pun.UtilityScripts
{
	public class PunTurnManager : MonoBehaviourPunCallbacks, IOnEventCallback
	{
		private Player sender;

		public float TurnDuration;

		public IPunTurnManagerCallbacks TurnManagerListener;

		private readonly HashSet<Player> finishedPlayers;

		public const byte TurnManagerEventOffset = 0;

		public const byte EvMove = 1;

		public const byte EvFinalMove = 2;

		private bool _isOverCallProcessed;

		public int Turn
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public float ElapsedTimeInTurn => 0f;

		public float RemainingSecondsInTurn => 0f;

		public bool IsCompletedByAll => false;

		public bool IsFinishedByMe => false;

		public bool IsOver => false;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void BeginTurn()
		{
		}

		public void SendMove(object move, bool finished)
		{
		}

		public bool GetPlayerFinishedTurn(Player player)
		{
			return false;
		}

		private void ProcessOnEvent(byte eventCode, object content, int senderId)
		{
		}

		public void OnEvent(EventData photonEvent)
		{
		}

		public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
		{
		}
	}
}
