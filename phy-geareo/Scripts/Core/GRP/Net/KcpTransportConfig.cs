using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace GRP.Net
{
	[CreateAssetMenu(fileName = "KcpTransport", menuName = "GRP/Net/KcpTransport")]
	public class KcpTransportConfig : NetTransportConfig
	{
		[Tooltip("DualMode listens to IPv6 and IPv4 simultaneously. Disable if the platform only supports IPv4.")]
		public bool DualMode;

		[Tooltip("NoDelay is recommended to reduce latency. This also scales better without buffers getting full.")]
		public bool NoDelay;

		[Tooltip("KCP internal update interval. 100ms is KCP default, but a lower interval is recommended to minimize latency and to scale to more networked entities.")]
		public uint Interval;

		[Tooltip("KCP timeout in milliseconds. Note that KCP sends a ping automatically.")]
		public int Timeout;

		[Tooltip("Socket receive buffer size. Large buffer helps support more connections. Increase operating system socket buffer size limits if needed.")]
		public int RecvBufferSize;

		[Tooltip("Socket send buffer size. Large buffer helps support more connections. Increase operating system socket buffer size limits if needed.")]
		public int SendBufferSize;

		[Header("Advanced")]
		[Tooltip("KCP fastresend parameter. Faster resend for the cost of higher bandwidth. 0 in normal mode, 2 in turbo mode.")]
		public int FastResend;

		[Tooltip("KCP congestion window. Restricts window size to reduce congestion. Results in only 2-3 MTU messages per Flush even on loopback. Best to keept his disabled.")]
		private bool CongestionWindow;

		[Tooltip("KCP window size can be modified to support higher loads. This also increases max message size.")]
		public uint ReceiveWindowSize;

		[Tooltip("KCP window size can be modified to support higher loads.")]
		public uint SendWindowSize;

		[Tooltip("KCP will try to retransmit lost messages up to MaxRetransmit (aka dead_link) before disconnecting.")]
		public uint MaxRetransmit;

		[Tooltip("Enable to automatically set client & server send/recv buffers to OS limit. Avoids issues with too small buffers under heavy load, potentially dropping connections. Increase the OS limit if this is still too small.")]
		[FormerlySerializedAs("MaximizeSendReceiveBuffersToOSLimit")]
		public bool MaximizeSocketBuffers;

		[Header("Allowed Max Message Sizes\nBased on Receive Window Size")]
		[Tooltip("KCP reliable max message size shown for convenience. Can be changed via ReceiveWindowSize.")]
		[ReadOnly]
		public int ReliableMaxMessageSize;

		[Tooltip("KCP unreliable channel max message size for convenience. Not changeable.")]
		[ReadOnly]
		public int UnreliableMaxMessageSize;

		private const int MTU = 1200;

		private void OnValidate()
		{
		}

		public override NetTransport CreateTransport()
		{
			return null;
		}
	}
}
