using System.Collections.Generic;
using System.Diagnostics;
using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Photon.Pun
{
	public class PhotonHandler : ConnectionHandler, IInRoomCallbacks, IMatchmakingCallbacks
	{
		private static PhotonHandler instance;

		public static int MaxDatagrams;

		public static bool SendAsap;

		private const int SerializeRateFrameCorrection = 8;

		protected internal int UpdateInterval;

		protected internal int UpdateIntervalOnSerialize;

		private readonly Stopwatch swSendOutgoing;

		private readonly Stopwatch swViewUpdate;

		private SupportLogger supportLoggerComponent;

		protected List<int> reusableIntList;

		internal static PhotonHandler Instance => null;

		protected override void Awake()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected void Start()
		{
		}

		protected override void OnDisable()
		{
		}

		protected void FixedUpdate()
		{
		}

		protected void LateUpdate()
		{
		}

		protected void Dispatch()
		{
		}

		public void OnCreatedRoom()
		{
		}

		public void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
		{
		}

		public void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
		{
		}

		public void OnMasterClientSwitched(Player newMasterClient)
		{
		}

		public void OnFriendListUpdate(List<FriendInfo> friendList)
		{
		}

		public void OnCreateRoomFailed(short returnCode, string message)
		{
		}

		public void OnJoinRoomFailed(short returnCode, string message)
		{
		}

		public void OnJoinRandomFailed(short returnCode, string message)
		{
		}

		public void OnJoinedRoom()
		{
		}

		public void OnLeftRoom()
		{
		}

		public void OnPlayerEnteredRoom(Player newPlayer)
		{
		}

		public void OnPlayerLeftRoom(Player otherPlayer)
		{
		}
	}
}
