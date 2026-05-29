using System;
using System.Collections.Generic;
using System.Diagnostics;
using ExitGames.Client.Photon;

namespace Photon.Realtime
{
	public class LoadBalancingPeer : PhotonPeer
	{
		private readonly Pool<ParameterDictionary> paramDictionaryPool;

		[Obsolete("Use RegionHandler.PingImplementation directly.")]
		protected internal static Type PingImplementation
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public LoadBalancingPeer(ConnectionProtocol protocolType)
			: base(default(ConnectionProtocol))
		{
		}

		public LoadBalancingPeer(IPhotonPeerListener listener, ConnectionProtocol protocolType)
			: base(default(ConnectionProtocol))
		{
		}

		[Conditional("SUPPORTED_UNITY")]
		private void ConfigUnitySockets()
		{
		}

		public virtual bool OpGetRegions(string appId)
		{
			return false;
		}

		public virtual bool OpJoinLobby(TypedLobby lobby = null)
		{
			return false;
		}

		public virtual bool OpLeaveLobby()
		{
			return false;
		}

		private void RoomOptionsToOpParameters(Dictionary<byte, object> op, RoomOptions roomOptions, bool usePropertiesKey = false)
		{
		}

		public virtual bool OpCreateRoom(EnterRoomParams opParams)
		{
			return false;
		}

		public virtual bool OpJoinRoom(EnterRoomParams opParams)
		{
			return false;
		}

		public virtual bool OpJoinRandomRoom(OpJoinRandomRoomParams opJoinRandomRoomParams)
		{
			return false;
		}

		public virtual bool OpJoinRandomOrCreateRoom(OpJoinRandomRoomParams opJoinRandomRoomParams, EnterRoomParams createRoomParams)
		{
			return false;
		}

		public virtual bool OpLeaveRoom(bool becomeInactive, bool sendAuthCookie = false)
		{
			return false;
		}

		public virtual bool OpGetGameList(TypedLobby lobby, string queryData)
		{
			return false;
		}

		public virtual bool OpFindFriends(string[] friendsToFind, FindFriendsOptions options = null)
		{
			return false;
		}

		public bool OpSetCustomPropertiesOfActor(int actorNr, Hashtable actorProperties)
		{
			return false;
		}

		protected internal bool OpSetPropertiesOfActor(int actorNr, Hashtable actorProperties, Hashtable expectedProperties = null, WebFlags webflags = null)
		{
			return false;
		}

		protected bool OpSetPropertyOfRoom(byte propCode, object value)
		{
			return false;
		}

		public bool OpSetCustomPropertiesOfRoom(Hashtable gameProperties)
		{
			return false;
		}

		protected internal bool OpSetPropertiesOfRoom(Hashtable gameProperties, Hashtable expectedProperties = null, WebFlags webflags = null)
		{
			return false;
		}

		public virtual bool OpAuthenticate(string appId, string appVersion, AuthenticationValues authValues, string regionCode, bool getLobbyStatistics)
		{
			return false;
		}

		public virtual bool OpAuthenticateOnce(string appId, string appVersion, AuthenticationValues authValues, string regionCode, EncryptionMode encryptionMode, ConnectionProtocol expectedProtocol)
		{
			return false;
		}

		public virtual bool OpChangeGroups(byte[] groupsToRemove, byte[] groupsToAdd)
		{
			return false;
		}

		public virtual bool OpRaiseEvent(byte eventCode, object customEventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
		{
			return false;
		}

		public virtual bool OpSettings(bool receiveLobbyStats)
		{
			return false;
		}
	}
}
