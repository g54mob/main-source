using System;
using System.Collections.Generic;
using FishNet.Managing;
using FishNet.Object;

namespace FishNet.Connection
{
	internal class PacketBundle
	{
		private List<ByteBuffer> _buffers;

		private int _bufferIndex;

		private int _maximumTransportUnit;

		private int _reserve;

		private NetworkManager _networkManager;

		private PacketBundle _sendLastBundle;

		private bool _isSendLastBundle;

		internal bool HasData => false;

		public int WrittenBuffers => 0;

		internal PacketBundle(NetworkManager manager, int mtu, int reserve = 0, DataOrderType orderType = DataOrderType.Default)
		{
		}

		public void Dispose()
		{
		}

		private ByteBuffer AddBuffer()
		{
			return null;
		}

		internal void Reset(bool resetSendLast)
		{
		}

		internal void Write(ArraySegment<byte> segment, bool forceNewBuffer = false, DataOrderType orderType = DataOrderType.Default)
		{
		}

		internal PacketBundle GetSendLastBundle()
		{
			return null;
		}

		internal bool GetBuffer(int index, out ByteBuffer bb)
		{
			bb = null;
			return false;
		}

		internal static bool GetPacketBundle(int channel, List<PacketBundle> bundles, out PacketBundle mtuBuffer)
		{
			mtuBuffer = null;
			return false;
		}
	}
}
