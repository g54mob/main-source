using System.Collections.Generic;
using System.IO;
using System.Text;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Digger.Modules.Core.Sources.TerrainInterface
{
	[DefaultExecutionOrder(-11)]
	public class TerrainCutter : MonoBehaviour
	{
		private class HolesEntry
		{
			public bool[,] TerrainHoles;

			public int[] DiggerHoles;
		}

		private struct DelayedHoles
		{
			public int XBase;

			public int YBase;

			public bool[,] Holes;
		}

		private class UndoRecord
		{
			public bool[,] UndoHoles;

			public List<int[,]> UndoDetails;

			public TreeInstance[] UndoTrees;
		}

		private const int LargeFileBufferSize = 32768;

		[SerializeField]
		private DiggerSystem digger;

		private bool mustApply;

		private bool mustPersist;

		private TerrainData terrainData;

		private TerrainCollider terrainCollider;

		private bool needsSync;

		private int holesResolution;

		private int voxResolution;

		private int sizeOfChunk;

		private int sizeOfChunkHoles;

		private Dictionary<Vector2i, HolesEntry> holesPerChunk;

		private readonly Queue<DelayedHoles> delayedHolesToApply = new Queue<DelayedHoles>(250);

		private readonly Dictionary<long, UndoRecord> undoRecords = new Dictionary<long, UndoRecord>();

		public void Apply(bool persist)
		{
			if (Application.isEditor && !Application.isPlaying)
			{
				ApplyInternal(persist);
				return;
			}
			mustApply = true;
			mustPersist = persist;
		}

		private void Update()
		{
			if (mustApply)
			{
				ApplyInternal(mustPersist);
				mustApply = false;
				mustPersist = false;
			}
		}

		public static TerrainCutter CreateInstance(DiggerSystem digger)
		{
			TerrainCutter terrainCutter = digger.gameObject.AddComponent<TerrainCutter>();
			terrainCutter.digger = digger;
			terrainCutter.Refresh();
			return terrainCutter;
		}

		public void Refresh()
		{
			terrainData = digger.Terrain.terrainData;
			terrainCollider = digger.Terrain.GetComponent<TerrainCollider>();
			terrainData.enableHolesTextureCompression = false;
			holesResolution = terrainData.holesResolution;
			voxResolution = digger.ResolutionMult;
			sizeOfChunk = digger.SizeVox;
			sizeOfChunkHoles = sizeOfChunk / voxResolution;
			holesPerChunk = new Dictionary<Vector2i, HolesEntry>(100, new Vector2iComparer());
			terrainData.SetHoles(0, 0, terrainData.GetHoles(0, 0, 1, 1));
		}

		private HolesEntry GetCreateHoles(Vector2i chunkPosition, Vector3i voxelPosition)
		{
			if (holesPerChunk.TryGetValue(chunkPosition, out var value))
			{
				return value;
			}
			int num = math.clamp(voxelPosition.x / voxResolution, 0, holesResolution - 1);
			int num2 = math.clamp(voxelPosition.z / voxResolution, 0, holesResolution - 1);
			int x = math.min(sizeOfChunkHoles, holesResolution - num);
			int x2 = math.min(sizeOfChunkHoles, holesResolution - num2);
			x = math.max(x, 1);
			x2 = math.max(x2, 1);
			bool[,] holes = terrainData.GetHoles(num, num2, x, x2);
			int[] array = new int[sizeOfChunk * sizeOfChunk];
			for (int i = 0; i < sizeOfChunk; i++)
			{
				for (int j = 0; j < sizeOfChunk; j++)
				{
					int num3 = math.min(i / voxResolution, holes.GetLength(0) - 1);
					int num4 = math.min(j / voxResolution, holes.GetLength(1) - 1);
					array[j * sizeOfChunk + i] = ((!holes[num3, num4]) ? 1 : 0);
				}
			}
			value = new HolesEntry
			{
				TerrainHoles = holes,
				DiggerHoles = array
			};
			holesPerChunk.Add(chunkPosition, value);
			return value;
		}

		public int[] GetHoles(Vector3i chunkPosition, Vector3i voxelPosition)
		{
			return GetCreateHoles(new Vector2i(chunkPosition.x, chunkPosition.z), voxelPosition).DiggerHoles;
		}

		public void Cut(NativeArray<int> chunkHoles, Vector3i voxelPosition, Vector3i chunkPosition)
		{
			HolesEntry createHoles = GetCreateHoles(new Vector2i(chunkPosition.x, chunkPosition.z), voxelPosition);
			for (int i = 0; i < createHoles.TerrainHoles.GetLength(1); i++)
			{
				for (int j = 0; j < createHoles.TerrainHoles.GetLength(0); j++)
				{
					bool flag = createHoles.TerrainHoles[j, i];
					for (int k = 0; k < voxResolution; k++)
					{
						for (int l = 0; l < voxResolution; l++)
						{
							int index = (i * voxResolution + k) * sizeOfChunk + (j * voxResolution + l);
							flag = flag && chunkHoles[index] == 0;
						}
					}
					createHoles.TerrainHoles[j, i] = flag;
				}
			}
			for (int m = 0; m < sizeOfChunk; m++)
			{
				for (int n = 0; n < sizeOfChunk; n++)
				{
					int num = math.min(m / voxResolution, createHoles.TerrainHoles.GetLength(0) - 1);
					int num2 = math.min(n / voxResolution, createHoles.TerrainHoles.GetLength(1) - 1);
					createHoles.DiggerHoles[n * sizeOfChunk + m] = ((!createHoles.TerrainHoles[num, num2]) ? 1 : 0);
				}
			}
			delayedHolesToApply.Enqueue(new DelayedHoles
			{
				XBase = voxelPosition.x / voxResolution,
				YBase = voxelPosition.z / voxResolution,
				Holes = createHoles.TerrainHoles
			});
			needsSync = true;
		}

		public void UnCut(NativeArray<int> chunkHoles, Vector3i voxelPosition, Vector3i chunkPosition)
		{
			HolesEntry createHoles = GetCreateHoles(new Vector2i(chunkPosition.x, chunkPosition.z), voxelPosition);
			for (int i = 0; i < createHoles.TerrainHoles.GetLength(1); i++)
			{
				for (int j = 0; j < createHoles.TerrainHoles.GetLength(0); j++)
				{
					bool flag = createHoles.TerrainHoles[j, i];
					for (int k = 0; k < voxResolution; k++)
					{
						for (int l = 0; l < voxResolution; l++)
						{
							int index = (i * voxResolution + k) * sizeOfChunk + (j * voxResolution + l);
							flag = flag || chunkHoles[index] == 0;
						}
					}
					for (int m = 0; m < voxResolution; m++)
					{
						for (int n = 0; n < voxResolution; n++)
						{
							int index2 = (i * voxResolution + m) * sizeOfChunk + (j * voxResolution + n);
							flag = flag && chunkHoles[index2] == 0;
						}
					}
					createHoles.TerrainHoles[j, i] = createHoles.TerrainHoles[j, i] || flag;
				}
			}
			for (int num = 0; num < sizeOfChunk; num++)
			{
				for (int num2 = 0; num2 < sizeOfChunk; num2++)
				{
					int num3 = math.min(num / voxResolution, createHoles.TerrainHoles.GetLength(0) - 1);
					int num4 = math.min(num2 / voxResolution, createHoles.TerrainHoles.GetLength(1) - 1);
					createHoles.DiggerHoles[num2 * sizeOfChunk + num] = ((!createHoles.TerrainHoles[num3, num4]) ? 1 : 0);
				}
			}
			delayedHolesToApply.Enqueue(new DelayedHoles
			{
				XBase = voxelPosition.x / voxResolution,
				YBase = voxelPosition.z / voxResolution,
				Holes = createHoles.TerrainHoles
			});
			needsSync = true;
		}

		private void ApplyInternal(bool persist)
		{
			if (needsSync)
			{
				needsSync = false;
				while (delayedHolesToApply.Count > 0)
				{
					DelayedHoles delayedHoles = delayedHolesToApply.Dequeue();
					terrainData.SetHolesDelayLOD(delayedHoles.XBase, delayedHoles.YBase, delayedHoles.Holes);
				}
				terrainData.SyncTexture(TerrainData.HolesTextureName);
				terrainCollider.enabled = false;
				terrainCollider.enabled = true;
			}
		}

		public void LoadFrom(string path)
		{
			if (!File.Exists(path))
			{
				return;
			}
			Refresh();
			TerrainData terrainData = digger.Terrain.terrainData;
			int num = terrainData.holesResolution;
			bool[,] array = new bool[num, num];
			using (Stream input = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 32768))
			{
				using BinaryReader binaryReader = new BinaryReader(input, Encoding.Default);
				if (binaryReader.ReadInt32() == num)
				{
					for (int i = 0; i < num; i++)
					{
						for (int j = 0; j < num; j++)
						{
							array[j, i] = binaryReader.ReadBoolean();
						}
					}
				}
			}
			terrainData.SetHoles(0, 0, array);
			terrainData.SyncTexture(TerrainData.HolesTextureName);
			if (terrainCollider != null)
			{
				terrainCollider.enabled = false;
				terrainCollider.enabled = true;
			}
		}

		public void SaveTo(string path)
		{
			TerrainData obj = digger.Terrain.terrainData;
			int num = obj.holesResolution;
			bool[,] holes = obj.GetHoles(0, 0, num, num);
			if (holes == null)
			{
				return;
			}
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			using FileStream output = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 32768);
			using BinaryWriter binaryWriter = new BinaryWriter(output, Encoding.Default);
			binaryWriter.Write(num);
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num; j++)
				{
					binaryWriter.Write(holes[j, i]);
				}
			}
		}

		public void Clear()
		{
			Refresh();
			undoRecords.Clear();
			int num = digger.Terrain.terrainData.holesResolution;
			bool[,] holes = digger.Terrain.terrainData.GetHoles(0, 0, num, num);
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num; j++)
				{
					holes[j, i] = true;
				}
			}
			digger.Terrain.terrainData.SetHoles(0, 0, holes);
			digger.Terrain.terrainData.SyncTexture(TerrainData.HolesTextureName);
			if (terrainCollider != null)
			{
				terrainCollider.enabled = false;
				terrainCollider.enabled = true;
			}
		}
	}
}
