using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Assets.Nimbatus.Scripts.Common.Helpers;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.Common
{
	public class TerrainTaskManager : MonoBehaviour
	{
		public static readonly ConcurrentQueue<Action> MainThreadQueue = new ConcurrentQueue<Action>();

		public List<NimbatusTerrainChunk> ChunkList = new List<NimbatusTerrainChunk>();

		private bool _stopThreads;

		public void Awake()
		{
			lock (MainThreadQueue)
			{
				MainThreadQueue.Clear();
			}
			_stopThreads = false;
			BackgroundWorker backgroundWorker = new BackgroundWorker();
			backgroundWorker.DoWork += RebuildChunks;
			backgroundWorker.RunWorkerAsync();
		}

		private void RebuildChunks(object sender, DoWorkEventArgs e)
		{
			while (!_stopThreads)
			{
				try
				{
					foreach (NimbatusTerrainChunk chunk2 in ChunkList)
					{
						if (chunk2.NeedsRebuilding && !chunk2.IsRebuilding)
						{
							chunk2.NeedsRebuilding = false;
							chunk2.IsRebuilding = true;
							chunk2.BuildTerrainMesh();
							NimbatusTerrainChunk chunk1 = chunk2;
							MainThreadQueue.Enqueue(delegate
							{
								ApplyMesh(chunk1);
							});
						}
					}
				}
				catch (Exception ex)
				{
					Debug.Log("RebuildChunks Thread:" + ex.Message);
					Thread.Sleep(1);
				}
				Thread.Sleep(1);
			}
		}

		public void Update()
		{
			int num = 0;
			while (MainThreadQueue.Count > 0 && num <= 15)
			{
				Action value;
				if (MainThreadQueue.TryDequeue(out value) && value != null)
				{
					try
					{
						value();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
				num++;
			}
		}

		private void ApplyMesh(NimbatusTerrainChunk chunk)
		{
			chunk.ApplyTerrainMesh();
			chunk.IsRebuilding = false;
		}

		public void OnDestroy()
		{
			_stopThreads = true;
			ChunkList.Clear();
			MainThreadQueue.Clear();
		}

		public void OnApplicationQuit()
		{
			_stopThreads = true;
		}

		public void SetChunkList(List<NimbatusTerrainChunk> chunkList)
		{
			ChunkList = chunkList;
		}
	}
}
