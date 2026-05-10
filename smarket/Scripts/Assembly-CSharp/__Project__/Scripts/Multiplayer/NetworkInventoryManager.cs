using System;
using System.Collections.Generic;
using Photon.Pun;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkInventoryManager : NoktaSingletonPunCallbacks<NetworkInventoryManager>
	{
		private class Batch
		{
			public int Total;

			public int Receieved;

			public FurnitureBoxData[] Items;
		}

		private const int MaxChunkSize = 30000;

		private static readonly Random Rng;

		private readonly Dictionary<int, Batch> m_Batches;

		private void Awake()
		{
		}

		public void SyncInventoryData_Request(PlayerInstance _)
		{
		}

		[PunRPC]
		public void SyncInventoryData_Broadcast(string userId)
		{
		}

		[PunRPC]
		public void SyncInventoryData_RPC(object[] objects)
		{
		}

		private static void WriteInt(byte[] buffer, ref int index, int value)
		{
		}

		private static void WriteShort(byte[] buffer, ref int index, int value)
		{
		}

		private static byte[] SerializeToArray(FurnitureBoxData data)
		{
			return null;
		}

		public static List<byte[]> PackFurnitureBoxList(List<FurnitureBoxData> list, int batchId, int maxChunk = 30000)
		{
			return null;
		}

		[PunRPC]
		public void SyncFurnitureBoxData_Broadcast(string userId)
		{
		}

		private byte[] BuildPayload(List<FurnitureBoxData> list, int start, int total, out int startIndex, out int itemCount)
		{
			startIndex = default(int);
			itemCount = default(int);
			return null;
		}

		[PunRPC]
		private void ReceiveFurnitureListChunk_RPC(int batchId, int total, int startIndex, int itemCount, byte[] payload)
		{
		}
	}
}
