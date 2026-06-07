using System;
using System.Runtime.InteropServices;
using Steamworks;
using UnityEngine;

namespace Mirror.FizzySteam
{
	public abstract class NextCommon : IDisposable
	{
		private const int MAX_PACKET_SIZE = 524288;

		protected const int MAX_MESSAGES = 256;

		private readonly byte[] buffer;

		private readonly GCHandle pinnedBuffer;

		private readonly IntPtr bufferPtr;

		private bool disposed;

		public NextCommon()
		{
			buffer = new byte[524288];
			pinnedBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			bufferPtr = pinnedBuffer.AddrOfPinnedObject();
		}

		protected EResult SendSocket(HSteamNetConnection conn, ArraySegment<byte> segment, int channelId)
		{
			int num = segment.Count + 1;
			if (num > 524288)
			{
				Debug.LogError($"Attempted to send oversize packet with {num} bytes on channel with ID {channelId}.");
				return EResult.k_EResultFail;
			}
			Array.Copy(segment.Array, segment.Offset, buffer, 0, segment.Count);
			buffer[segment.Count] = (byte)channelId;
			int nSendFlags = ((channelId != 1) ? 8 : 0);
			long pOutMessageNumber;
			EResult eResult = SteamNetworkingSockets.SendMessageToConnection(conn, bufferPtr, (uint)num, nSendFlags, out pOutMessageNumber);
			if (eResult != EResult.k_EResultOK)
			{
				Debug.LogWarning($"Send issue: {eResult}");
			}
			return eResult;
		}

		protected (ArraySegment<byte>, int) ProcessMessage(IntPtr ptrs)
		{
			SteamNetworkingMessage_t steamNetworkingMessage_t = Marshal.PtrToStructure<SteamNetworkingMessage_t>(ptrs);
			int cbSize = steamNetworkingMessage_t.m_cbSize;
			Marshal.Copy(steamNetworkingMessage_t.m_pData, buffer, 0, steamNetworkingMessage_t.m_cbSize);
			SteamNetworkingMessage_t.Release(ptrs);
			ArraySegment<byte> item = new ArraySegment<byte>(buffer, 0, cbSize - 1);
			int item2 = buffer[cbSize - 1];
			return (item, item2);
		}

		public virtual void Dispose()
		{
			if (!disposed)
			{
				pinnedBuffer.Free();
				disposed = true;
			}
		}
	}
}
