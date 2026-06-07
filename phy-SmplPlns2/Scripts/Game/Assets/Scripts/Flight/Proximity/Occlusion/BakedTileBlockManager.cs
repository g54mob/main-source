using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Jundroo.Common.Utils;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Flight.Proximity.Occlusion
{
	public class BakedTileBlockManager : MonoBehaviour
	{
		private static class Profile
		{
			public static readonly ProfilerMarker CoordString = new ProfilerMarker("BakedTileBlockManager.CoordString");

			public static readonly ProfilerMarker GetBlockFileName = new ProfilerMarker("BakedTileBlockManager.GetBlockFileName");

			public static readonly ProfilerMarker GetBlockForTile = new ProfilerMarker("BakedTileBlockManager.GetBlockForTile");

			public static readonly ProfilerMarker GetBlockKeyForTile = new ProfilerMarker("BakedTileBlockManager.GetBlockKeyForTile");

			public static readonly ProfilerMarker GetFolderPath = new ProfilerMarker("BakedTileBlockManager.GetFolderPath");

			public static readonly ProfilerMarker IsTileWithinBounds = new ProfilerMarker("BakedTileBlockManager.IsTileWithinBounds");

			public static readonly ProfilerMarker LoadBlock = new ProfilerMarker("BakedTileBlockManager.LoadBlock");

			public static readonly ProfilerMarker LoadBlockInBackground = new ProfilerMarker("BakedTileBlockManager.LoadBlockInBackground");

			public static readonly ProfilerMarker ProcessMainThreadActions = new ProfilerMarker("BakedTileBlockManager.ProcessMainThreadActions");

			public static readonly ProfilerMarker QueueNeighborBlocks = new ProfilerMarker("BakedTileBlockManager.QueueNeighborBlocks");
		}

		private readonly ConcurrentQueue<Action> _mainThreadActions = new ConcurrentQueue<Action>();

		[Header("Baking Settings")]
		[Tooltip("Half-count of blocks along the X-axis. (Total blocks in X = 2*this)")]
		[SerializeField]
		private int _blocksHalfCountX = 3;

		[Tooltip("Half-count of blocks along the Y-axis. (Total blocks in Y = 2*this)")]
		[SerializeField]
		private int _blocksHalfCountY = 4;

		[Tooltip("Number of tiles per block (uniform for both X and Y).")]
		[SerializeField]
		private int _blockSize = 10;

		[Tooltip("Folder where baked block files will be saved.")]
		[SerializeField]
		private string _folderName = "BakedBlocks";

		private Dictionary<Vector2Int, BakedTileBlock> _loadedBlocks = new Dictionary<Vector2Int, BakedTileBlock>();

		[Header("Tiling")]
		[Tooltip("Size of each tile in XZ (e.g., 1000m)")]
		[SerializeField]
		private float _tileSize = 1000f;

		public int BlocksHalfCountX => _blocksHalfCountX;

		public int BlocksHalfCountY => _blocksHalfCountY;

		public int BlockSize => _blockSize;

		public float TileSize => _tileSize;

		public string GetBlockFileName(int blockY, int blockX)
		{
			using (Profile.GetBlockFileName.Auto())
			{
				return "Block" + CoordString(blockY) + CoordString(blockX) + ".bytes";
			}
		}

		public BakedTileBlock GetBlockForTile(Vector2Int tileCoord)
		{
			using (Profile.GetBlockForTile.Auto())
			{
				Vector2Int blockKeyForTile = GetBlockKeyForTile(tileCoord);
				if (!_loadedBlocks.TryGetValue(blockKeyForTile, out var value))
				{
					string blockFileName = GetBlockFileName(blockKeyForTile.y, blockKeyForTile.x);
					value = LoadBlock(blockFileName);
					if (value == null)
					{
						return null;
					}
					_loadedBlocks[blockKeyForTile] = value;
				}
				QueueNeighborBlocks(blockKeyForTile);
				return value;
			}
		}

		public Vector2Int GetBlockKeyForTile(Vector2Int tileCoord)
		{
			using (Profile.GetBlockKeyForTile.Auto())
			{
				int x = Mathf.FloorToInt((float)tileCoord.x / (float)_blockSize);
				int y = Mathf.FloorToInt((float)tileCoord.y / (float)_blockSize);
				return new Vector2Int(x, y);
			}
		}

		public string GetFolderPath()
		{
			using (Profile.GetFolderPath.Auto())
			{
				return Path.Combine("Environment/OcclusionMaps", _folderName);
			}
		}

		public bool IsTileWithinBounds(Vector2Int tileCoord)
		{
			using (Profile.IsTileWithinBounds.Auto())
			{
				Vector2Int blockKeyForTile = GetBlockKeyForTile(tileCoord);
				return blockKeyForTile.x >= -BlocksHalfCountX && blockKeyForTile.x < BlocksHalfCountX && blockKeyForTile.y >= -BlocksHalfCountY && blockKeyForTile.y < BlocksHalfCountY;
			}
		}

		public void ProcessMainThreadActions()
		{
			using (Profile.ProcessMainThreadActions.Auto())
			{
				Action result;
				while (_mainThreadActions.TryDequeue(out result))
				{
					result();
				}
			}
		}

		private static string CoordString(int coord)
		{
			using (Profile.CoordString.Auto())
			{
				return (coord >= 0) ? $"+{coord}" : $"{coord}";
			}
		}

		private BakedTileBlock LoadBlock(string fileName)
		{
			using (Profile.LoadBlock.Auto())
			{
				try
				{
					using MemoryStream input = new MemoryStream(FileIOUtility.ReadStreamingAssetsFileAsBytes(Path.Combine(GetFolderPath(), fileName)));
					using BinaryReader reader = new BinaryReader(input, Encoding.UTF8);
					return BakedTileBlock.Deserialize(reader);
				}
				catch (Exception)
				{
					return null;
				}
			}
		}

		private void LoadBlockInBackground(Vector2Int blockKey)
		{
			using (Profile.LoadBlockInBackground.Auto())
			{
				if (_loadedBlocks.ContainsKey(blockKey))
				{
					return;
				}
				string fileName = GetBlockFileName(blockKey.y, blockKey.x);
				Task.Run(delegate
				{
					BakedTileBlock block = LoadBlock(fileName);
					_mainThreadActions.Enqueue(delegate
					{
						_loadedBlocks[blockKey] = block;
					});
				});
			}
		}

		private void QueueNeighborBlocks(Vector2Int currentBlockKey)
		{
			using (Profile.QueueNeighborBlocks.Auto())
			{
				for (int i = -1; i <= 1; i++)
				{
					for (int j = -1; j <= 1; j++)
					{
						if (i != 0 || j != 0)
						{
							Vector2Int vector2Int = new Vector2Int(currentBlockKey.x + i, currentBlockKey.y + j);
							if (!_loadedBlocks.ContainsKey(vector2Int))
							{
								LoadBlockInBackground(vector2Int);
							}
						}
					}
				}
			}
		}
	}
}
