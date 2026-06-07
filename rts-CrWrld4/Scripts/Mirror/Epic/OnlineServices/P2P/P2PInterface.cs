using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.P2P
{
	public sealed class P2PInterface : Handle
	{
		public const int AcceptconnectionApiLatest = 1;

		public const int AddnotifyincomingpacketqueuefullApiLatest = 1;

		public const int AddnotifypeerconnectionclosedApiLatest = 1;

		public const int AddnotifypeerconnectionrequestApiLatest = 1;

		public const int CloseconnectionApiLatest = 1;

		public const int CloseconnectionsApiLatest = 1;

		public const int GetnattypeApiLatest = 1;

		public const int GetnextreceivedpacketsizeApiLatest = 2;

		public const int GetpacketqueueinfoApiLatest = 1;

		public const int GetportrangeApiLatest = 1;

		public const int GetrelaycontrolApiLatest = 1;

		public const int MaxConnections = 32;

		public const int MaxPacketSize = 1170;

		public const int MaxQueueSizeUnlimited = 0;

		public const int QuerynattypeApiLatest = 1;

		public const int ReceivepacketApiLatest = 2;

		public const int SendpacketApiLatest = 2;

		public const int SetpacketqueuesizeApiLatest = 1;

		public const int SetportrangeApiLatest = 1;

		public const int SetrelaycontrolApiLatest = 1;

		public const int SocketidApiLatest = 1;

		public P2PInterface()
		{
		}

		public P2PInterface(IntPtr innerHandle)
		{
		}

		public Result AcceptConnection(AcceptConnectionOptions options)
		{
			return default(Result);
		}

		public ulong AddNotifyIncomingPacketQueueFull(AddNotifyIncomingPacketQueueFullOptions options, object clientData, OnIncomingPacketQueueFullCallback incomingPacketQueueFullHandler)
		{
			return 0uL;
		}

		public ulong AddNotifyPeerConnectionClosed(AddNotifyPeerConnectionClosedOptions options, object clientData, OnRemoteConnectionClosedCallback connectionClosedHandler)
		{
			return 0uL;
		}

		public ulong AddNotifyPeerConnectionRequest(AddNotifyPeerConnectionRequestOptions options, object clientData, OnIncomingConnectionRequestCallback connectionRequestHandler)
		{
			return 0uL;
		}

		public Result CloseConnection(CloseConnectionOptions options)
		{
			return default(Result);
		}

		public Result CloseConnections(CloseConnectionsOptions options)
		{
			return default(Result);
		}

		public Result GetNATType(GetNATTypeOptions options, out NATType outNATType)
		{
			outNATType = default(NATType);
			return default(Result);
		}

		public Result GetNextReceivedPacketSize(GetNextReceivedPacketSizeOptions options, out uint outPacketSizeBytes)
		{
			outPacketSizeBytes = default(uint);
			return default(Result);
		}

		public Result GetPacketQueueInfo(GetPacketQueueInfoOptions options, out PacketQueueInfo outPacketQueueInfo)
		{
			outPacketQueueInfo = null;
			return default(Result);
		}

		public Result GetPortRange(GetPortRangeOptions options, out ushort outPort, out ushort outNumAdditionalPortsToTry)
		{
			outPort = default(ushort);
			outNumAdditionalPortsToTry = default(ushort);
			return default(Result);
		}

		public Result GetRelayControl(GetRelayControlOptions options, out RelayControl outRelayControl)
		{
			outRelayControl = default(RelayControl);
			return default(Result);
		}

		public void QueryNATType(QueryNATTypeOptions options, object clientData, OnQueryNATTypeCompleteCallback completionDelegate)
		{
		}

		public Result ReceivePacket(ReceivePacketOptions options, out ProductUserId outPeerId, out SocketId outSocketId, out byte outChannel, out byte[] outData)
		{
			outPeerId = null;
			outSocketId = null;
			outChannel = default(byte);
			outData = null;
			return default(Result);
		}

		public void RemoveNotifyIncomingPacketQueueFull(ulong notificationId)
		{
		}

		public void RemoveNotifyPeerConnectionClosed(ulong notificationId)
		{
		}

		public void RemoveNotifyPeerConnectionRequest(ulong notificationId)
		{
		}

		public Result SendPacket(SendPacketOptions options)
		{
			return default(Result);
		}

		public Result SetPacketQueueSize(SetPacketQueueSizeOptions options)
		{
			return default(Result);
		}

		public Result SetPortRange(SetPortRangeOptions options)
		{
			return default(Result);
		}

		public Result SetRelayControl(SetRelayControlOptions options)
		{
			return default(Result);
		}

		internal static void OnIncomingConnectionRequestCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnIncomingPacketQueueFullCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryNATTypeCompleteCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnRemoteConnectionClosedCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern Result EOS_P2P_AcceptConnection(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern ulong EOS_P2P_AddNotifyIncomingPacketQueueFull(IntPtr handle, IntPtr options, IntPtr clientData, OnIncomingPacketQueueFullCallbackInternal incomingPacketQueueFullHandler);

		[PreserveSig]
		internal static extern ulong EOS_P2P_AddNotifyPeerConnectionClosed(IntPtr handle, IntPtr options, IntPtr clientData, OnRemoteConnectionClosedCallbackInternal connectionClosedHandler);

		[PreserveSig]
		internal static extern ulong EOS_P2P_AddNotifyPeerConnectionRequest(IntPtr handle, IntPtr options, IntPtr clientData, OnIncomingConnectionRequestCallbackInternal connectionRequestHandler);

		[PreserveSig]
		internal static extern Result EOS_P2P_CloseConnection(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_P2P_CloseConnections(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_P2P_GetNATType(IntPtr handle, IntPtr options, ref NATType outNATType);

		[PreserveSig]
		internal static extern Result EOS_P2P_GetNextReceivedPacketSize(IntPtr handle, IntPtr options, ref uint outPacketSizeBytes);

		[PreserveSig]
		internal static extern Result EOS_P2P_GetPacketQueueInfo(IntPtr handle, IntPtr options, ref PacketQueueInfoInternal outPacketQueueInfo);

		[PreserveSig]
		internal static extern Result EOS_P2P_GetPortRange(IntPtr handle, IntPtr options, ref ushort outPort, ref ushort outNumAdditionalPortsToTry);

		[PreserveSig]
		internal static extern Result EOS_P2P_GetRelayControl(IntPtr handle, IntPtr options, ref RelayControl outRelayControl);

		[PreserveSig]
		internal static extern void EOS_P2P_QueryNATType(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryNATTypeCompleteCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern Result EOS_P2P_ReceivePacket(IntPtr handle, IntPtr options, ref IntPtr outPeerId, ref SocketIdInternal outSocketId, ref byte outChannel, IntPtr outData, ref uint outBytesWritten);

		[PreserveSig]
		internal static extern void EOS_P2P_RemoveNotifyIncomingPacketQueueFull(IntPtr handle, ulong notificationId);

		[PreserveSig]
		internal static extern void EOS_P2P_RemoveNotifyPeerConnectionClosed(IntPtr handle, ulong notificationId);

		[PreserveSig]
		internal static extern void EOS_P2P_RemoveNotifyPeerConnectionRequest(IntPtr handle, ulong notificationId);

		[PreserveSig]
		internal static extern Result EOS_P2P_SendPacket(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_P2P_SetPacketQueueSize(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_P2P_SetPortRange(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_P2P_SetRelayControl(IntPtr handle, IntPtr options);
	}
}
