using System.Collections.Generic;

namespace ExitGames.Client.Photon
{
	internal class TPeer : PeerBase
	{
		internal const int TCP_HEADER_BYTES = 7;

		internal const int MSG_HEADER_BYTES = 2;

		public const int ALL_HEADER_BYTES = 9;

		private Queue<StreamBuffer> incomingList;

		internal List<StreamBuffer> outgoingStream;

		private int lastPingActivity;

		private readonly byte[] pingRequest;

		private readonly ParameterDictionary pingParamDict;

		internal static readonly byte[] tcpFramedMessageHead;

		internal static readonly byte[] tcpMsgHead;

		protected internal bool DoFraming;

		private bool waitForInitResponse;

		internal override int QueuedIncomingCommandsCount => 0;

		internal override int QueuedOutgoingCommandsCount => 0;

		internal TPeer()
		{
		}

		internal override bool IsTransportEncrypted()
		{
			return false;
		}

		internal override void Reset()
		{
		}

		internal override bool Connect(string serverAddress, string proxyServerAddress, string appID, object photonToken)
		{
			return false;
		}

		public override void OnConnect()
		{
		}

		internal override void Disconnect()
		{
		}

		internal override void StopConnection()
		{
		}

		internal override void FetchServerTimestamp()
		{
		}

		private void EnqueueInit(byte[] data)
		{
		}

		internal override bool DispatchIncomingCommands()
		{
			return false;
		}

		internal override bool SendOutgoingCommands()
		{
			return false;
		}

		internal override bool SendAcksOnly()
		{
			return false;
		}

		internal override bool EnqueuePhotonMessage(StreamBuffer opBytes, SendOptions sendParams)
		{
			return false;
		}

		internal bool EnqueueMessageAsPayload(DeliveryMode deliveryMode, StreamBuffer opMessage, byte channelId)
		{
			return false;
		}

		internal void SendPing()
		{
		}

		internal PhotonSocketError SendData(byte[] data, int length)
		{
			return default(PhotonSocketError);
		}

		internal override void ReceiveIncomingCommands(byte[] inbuff, int dataLength)
		{
		}

		private void ReadPingResult(byte[] inbuff)
		{
		}

		protected internal void ReadPingResult(OperationResponse operationResponse)
		{
		}
	}
}
