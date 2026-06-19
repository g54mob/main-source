using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using PugTilemap.Quads;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace PugTilemap
{
	[BurstCompile]
	public class SinglePugMap : MonoBehaviour
	{
		private struct TileChangeRequest
		{
			public int2 WorldPosition;

			public TileInfo Tile;

			public bool Add;
		}

		[BurstCompile]
		public struct TileLayerLookup
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate bool HasTileInternal_00006C97_0024PostfixBurstDelegate(in int2 worldPosition, TileType type, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles);

			internal static class HasTileInternal_00006C97_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<HasTileInternal_00006C97_0024PostfixBurstDelegate>(HasTileInternal).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static bool Invoke(in int2 worldPosition, TileType type, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							return ((delegate* unmanaged[Cdecl]<ref int2, TileType, ref NativeParallelMultiHashMap<int2, TileInfo>, bool>)functionPointer)(ref worldPosition, type, ref allTiles);
						}
					}
					return HasTileInternal_0024BurstManaged(in worldPosition, type, ref allTiles);
				}
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate bool HasTileInternal_00006C99_0024PostfixBurstDelegate(in int2 worldPosition, TileType type, int tileset, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles);

			internal static class HasTileInternal_00006C99_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<HasTileInternal_00006C99_0024PostfixBurstDelegate>(HasTileInternal).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static bool Invoke(in int2 worldPosition, TileType type, int tileset, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							return ((delegate* unmanaged[Cdecl]<ref int2, TileType, int, ref NativeParallelMultiHashMap<int2, TileInfo>, bool>)functionPointer)(ref worldPosition, type, tileset, ref allTiles);
						}
					}
					return HasTileInternal_0024BurstManaged(in worldPosition, type, tileset, ref allTiles);
				}
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate bool TryGetTileInfoInternal_00006C9B_0024PostfixBurstDelegate(in int2 worldPosition, TileType type, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles, out TileInfo tileInfo);

			internal static class TryGetTileInfoInternal_00006C9B_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<TryGetTileInfoInternal_00006C9B_0024PostfixBurstDelegate>(TryGetTileInfoInternal).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static bool Invoke(in int2 worldPosition, TileType type, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles, out TileInfo tileInfo)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							return ((delegate* unmanaged[Cdecl]<ref int2, TileType, ref NativeParallelMultiHashMap<int2, TileInfo>, ref TileInfo, bool>)functionPointer)(ref worldPosition, type, ref allTiles, ref tileInfo);
						}
					}
					return TryGetTileInfoInternal_0024BurstManaged(in worldPosition, type, ref allTiles, out tileInfo);
				}
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void GetTopTileInternal_00006C9F_0024PostfixBurstDelegate(in int2 worldPosition, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles, out TileInfo topTile);

			internal static class GetTopTileInternal_00006C9F_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<GetTopTileInternal_00006C9F_0024PostfixBurstDelegate>(GetTopTileInternal).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static void Invoke(in int2 worldPosition, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles, out TileInfo topTile)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<ref int2, ref NativeParallelMultiHashMap<int2, TileInfo>, ref TileInfo, void>)functionPointer)(ref worldPosition, ref allTiles, ref topTile);
							return;
						}
					}
					GetTopTileInternal_0024BurstManaged(in worldPosition, ref allTiles, out topTile);
				}
			}

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void GetTopTileAndCheckWaterInternal_00006CA1_0024PostfixBurstDelegate(in int2 worldPosition, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles, out TileInfo topTile, out bool hasWater);

			internal static class GetTopTileAndCheckWaterInternal_00006CA1_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				[BurstDiscard]
				private static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = BurstCompiler.CompileFunctionPointer<GetTopTileAndCheckWaterInternal_00006CA1_0024PostfixBurstDelegate>(GetTopTileAndCheckWaterInternal).Value;
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public unsafe static void Invoke(in int2 worldPosition, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles, out TileInfo topTile, out bool hasWater)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<ref int2, ref NativeParallelMultiHashMap<int2, TileInfo>, ref TileInfo, ref bool, void>)functionPointer)(ref worldPosition, ref allTiles, ref topTile, ref hasWater);
							return;
						}
					}
					GetTopTileAndCheckWaterInternal_0024BurstManaged(in worldPosition, ref allTiles, out topTile, out hasWater);
				}
			}

			public NativeParallelMultiHashMap<int2, TileInfo> AllTiles;

			public bool HasTile(int2 worldPosition, TileType type)
			{
				return HasTileInternal(in worldPosition, type, ref AllTiles);
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(HasTileInternal_00006C97_0024PostfixBurstDelegate))]
			private static bool HasTileInternal(in int2 worldPosition, TileType type, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles)
			{
				return HasTileInternal_00006C97_0024BurstDirectCall.Invoke(in worldPosition, type, ref allTiles);
			}

			public bool HasTile(int2 worldPosition, TileType type, int tileset)
			{
				return HasTileInternal(in worldPosition, type, tileset, ref AllTiles);
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(HasTileInternal_00006C99_0024PostfixBurstDelegate))]
			private static bool HasTileInternal(in int2 worldPosition, TileType type, int tileset, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles)
			{
				return HasTileInternal_00006C99_0024BurstDirectCall.Invoke(in worldPosition, type, tileset, ref allTiles);
			}

			public bool TryGetTileInfo(int2 worldPosition, TileType type, out TileInfo tileInfo)
			{
				return TryGetTileInfoInternal(in worldPosition, type, ref AllTiles, out tileInfo);
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(TryGetTileInfoInternal_00006C9B_0024PostfixBurstDelegate))]
			private static bool TryGetTileInfoInternal(in int2 worldPosition, TileType type, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles, out TileInfo tileInfo)
			{
				return TryGetTileInfoInternal_00006C9B_0024BurstDirectCall.Invoke(in worldPosition, type, ref allTiles, out tileInfo);
			}

			public bool TryGetTileset(int2 worldPosition, TileType type, out int tileset)
			{
				if (TryGetTileInfo(worldPosition, type, out var tileInfo))
				{
					tileset = tileInfo.tileset;
					return true;
				}
				tileset = 0;
				return false;
			}

			public NativeParallelMultiHashMap<int2, TileInfo>.Enumerator GetTiles(int2 worldPosition)
			{
				return AllTiles.GetValuesForKey(worldPosition);
			}

			public TileInfo GetTopTile(int2 worldPosition)
			{
				GetTopTileInternal(in worldPosition, ref AllTiles, out var topTile);
				return topTile;
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(GetTopTileInternal_00006C9F_0024PostfixBurstDelegate))]
			private static void GetTopTileInternal(in int2 worldPosition, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles, out TileInfo topTile)
			{
				GetTopTileInternal_00006C9F_0024BurstDirectCall.Invoke(in worldPosition, ref allTiles, out topTile);
			}

			public TileInfo GetTopTileAndCheckWater(int2 worldPosition, out bool hasWater)
			{
				GetTopTileAndCheckWaterInternal(in worldPosition, ref AllTiles, out var topTile, out hasWater);
				return topTile;
			}

			[BurstCompile]
			[MonoPInvokeCallback(typeof(GetTopTileAndCheckWaterInternal_00006CA1_0024PostfixBurstDelegate))]
			private static void GetTopTileAndCheckWaterInternal(in int2 worldPosition, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles, out TileInfo topTile, out bool hasWater)
			{
				GetTopTileAndCheckWaterInternal_00006CA1_0024BurstDirectCall.Invoke(in worldPosition, ref allTiles, out topTile, out hasWater);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static bool HasTileInternal_0024BurstManaged(in int2 worldPosition, TileType type, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles)
			{
				foreach (TileInfo item in allTiles.GetValuesForKey(worldPosition))
				{
					if (item.tileType == type)
					{
						return true;
					}
				}
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static bool HasTileInternal_0024BurstManaged(in int2 worldPosition, TileType type, int tileset, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles)
			{
				foreach (TileInfo item in allTiles.GetValuesForKey(worldPosition))
				{
					if (item.tileType == type && item.tileset == tileset)
					{
						return true;
					}
				}
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static bool TryGetTileInfoInternal_0024BurstManaged(in int2 worldPosition, TileType type, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles, out TileInfo tileInfo)
			{
				NativeParallelMultiHashMap<int2, TileInfo>.Enumerator valuesForKey = allTiles.GetValuesForKey(worldPosition);
				while (valuesForKey.MoveNext())
				{
					if (valuesForKey.Current.tileType == type)
					{
						tileInfo = valuesForKey.Current;
						return true;
					}
				}
				tileInfo = default(TileInfo);
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void GetTopTileInternal_0024BurstManaged(in int2 worldPosition, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles, out TileInfo topTile)
			{
				topTile = default(TileInfo);
				foreach (TileInfo item in allTiles.GetValuesForKey(worldPosition))
				{
					if (item.tileType.GetSurfacePriority() > topTile.tileType.GetSurfacePriority())
					{
						topTile = item;
					}
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			internal static void GetTopTileAndCheckWaterInternal_0024BurstManaged(in int2 worldPosition, ref NativeParallelMultiHashMap<int2, TileInfo> allTiles, out TileInfo topTile, out bool hasWater)
			{
				hasWater = false;
				topTile = default(TileInfo);
				foreach (TileInfo item in allTiles.GetValuesForKey(worldPosition))
				{
					if (item.tileType.GetSurfacePriority() > topTile.tileType.GetSurfacePriority())
					{
						topTile = item;
					}
					hasWater |= item.tileType == TileType.water;
				}
			}
		}

		private struct TileUpdatesLayer
		{
			public int start;

			public int length;

			public int layerKey;

			public int extraLayersStart;

			public int extraLayersLength;
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void ApplyTileUpdateLayers_00006C86_0024PostfixBurstDelegate(ref NativeList<NativeParallelHashMap<int2, int>> layerDataUpdates, ref NativeList<bool> layerDataUpdatesDirty, in NativeList<SendClientSubMapToPugMapSystem.TileUpdate> sortedTileUpdates, in NativeList<TileUpdatesLayer> tileUpdatesLayers, in NativeList<int> extraLayerKeys);

		internal static class ApplyTileUpdateLayers_00006C86_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<ApplyTileUpdateLayers_00006C86_0024PostfixBurstDelegate>(ApplyTileUpdateLayers).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref NativeList<NativeParallelHashMap<int2, int>> layerDataUpdates, ref NativeList<bool> layerDataUpdatesDirty, in NativeList<SendClientSubMapToPugMapSystem.TileUpdate> sortedTileUpdates, in NativeList<TileUpdatesLayer> tileUpdatesLayers, in NativeList<int> extraLayerKeys)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref NativeList<NativeParallelHashMap<int2, int>>, ref NativeList<bool>, ref NativeList<SendClientSubMapToPugMapSystem.TileUpdate>, ref NativeList<TileUpdatesLayer>, ref NativeList<int>, void>)functionPointer)(ref layerDataUpdates, ref layerDataUpdatesDirty, ref sortedTileUpdates, ref tileUpdatesLayers, ref extraLayerKeys);
						return;
					}
				}
				ApplyTileUpdateLayers_0024BurstManaged(ref layerDataUpdates, ref layerDataUpdatesDirty, in sortedTileUpdates, in tileUpdatesLayers, in extraLayerKeys);
			}
		}

		private List<PugMapLayer2> allLayers = new List<PugMapLayer2>();

		private NativeParallelMultiHashMap<int2, TileInfo> allTilesAtPosition;

		private NativeParallelHashMap<int2, TileInfo> topTileAtPosition;

		private JobHandle tileLookupJobHandle;

		private bool tileLookupJobCompleted;

		private List<JobHandle> tileLookupDependencies = new List<JobHandle>();

		private NativeParallelMultiHashMap<int2, TileInfo> hiddenTileLookup;

		private List<TileChangeRequest> hiddenTileChangeRequests = new List<TileChangeRequest>();

		private List<TileChangeRequest> setTileRequests = new List<TileChangeRequest>();

		private NativeList<TileInfo> layerDataUpdateKeys;

		private NativeList<NativeParallelHashMap<int2, int>> layerDataUpdates;

		private NativeList<bool> layerDataUpdatesDirty;

		private Dictionary<int2, Material> materialCache = new Dictionary<int2, Material>();

		private Mesh.MeshDataArray meshDataArray;

		private List<PugMapLayer2> layersToUpdate = new List<PugMapLayer2>();

		private List<Mesh> meshesToUpdate = new List<Mesh>();

		public bool IsEmpty
		{
			get
			{
				if (allTilesAtPosition.IsEmpty)
				{
					return hiddenTileLookup.IsEmpty;
				}
				return false;
			}
		}

		public void Start()
		{
			Reset();
		}

		private void Update()
		{
			if (!Manager.ecs.WorldsAreLoaded)
			{
				return;
			}
			if (Application.isPlaying)
			{
				Manager.ecs.ClientWorld.GetExistingSystemManaged<SendClientSubMapToPugMapSystem>().Apply(this);
			}
			foreach (TileChangeRequest hiddenTileChangeRequest in hiddenTileChangeRequests)
			{
				_SetHiddenInCache(hiddenTileChangeRequest);
			}
			hiddenTileChangeRequests.Clear();
			foreach (TileChangeRequest setTileRequest in setTileRequests)
			{
				if (setTileRequest.Add)
				{
					_SetTile(setTileRequest.WorldPosition, setTileRequest.Tile.tileset, setTileRequest.Tile.tileType, setTileRequest.Tile.state);
				}
				else if (setTileRequest.Tile.tileset == 75)
				{
					_ClearTileOfType(setTileRequest.WorldPosition, setTileRequest.Tile.tileType);
				}
				else
				{
					_ClearTileOfTypeAndTileset(setTileRequest.WorldPosition, setTileRequest.Tile.tileType, setTileRequest.Tile.tileset);
				}
			}
			setTileRequests.Clear();
			foreach (JobHandle tileLookupDependency in tileLookupDependencies)
			{
				tileLookupDependency.Complete();
			}
			tileLookupDependencies.Clear();
			Build();
		}

		private void LateUpdate()
		{
			LateBuild();
		}

		public void ResetParticles()
		{
			foreach (PugMapLayer2 allLayer in allLayers)
			{
				allLayer.ResetParticles();
			}
		}

		public void Reset()
		{
			if (!allTilesAtPosition.IsCreated)
			{
				allTilesAtPosition = new NativeParallelMultiHashMap<int2, TileInfo>(245760, Allocator.Persistent);
			}
			if (!topTileAtPosition.IsCreated)
			{
				topTileAtPosition = new NativeParallelHashMap<int2, TileInfo>(4096, Allocator.Persistent);
			}
			if (!hiddenTileLookup.IsCreated)
			{
				hiddenTileLookup = new NativeParallelMultiHashMap<int2, TileInfo>(8192, Allocator.Persistent);
			}
			allTilesAtPosition.Clear();
			topTileAtPosition.Clear();
			hiddenTileLookup.Clear();
			if (!layerDataUpdateKeys.IsCreated)
			{
				layerDataUpdateKeys = new NativeList<TileInfo>(Allocator.Persistent);
			}
			if (!layerDataUpdates.IsCreated)
			{
				layerDataUpdates = new NativeList<NativeParallelHashMap<int2, int>>(Allocator.Persistent);
			}
			if (!layerDataUpdatesDirty.IsCreated)
			{
				layerDataUpdatesDirty = new NativeList<bool>(Allocator.Persistent);
			}
			foreach (NativeParallelHashMap<int2, int> layerDataUpdate in layerDataUpdates)
			{
				if (layerDataUpdate.IsCreated)
				{
					layerDataUpdate.Dispose();
				}
			}
			layerDataUpdateKeys.Clear();
			layerDataUpdates.Clear();
			layerDataUpdatesDirty.Clear();
			foreach (PugMapLayer2 allLayer in allLayers)
			{
				allLayer.Dispose();
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(allLayer.gameObject);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(allLayer.gameObject);
				}
			}
			allLayers.Clear();
		}

		private void OnDestroy()
		{
			foreach (PugMapLayer2 allLayer in allLayers)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(allLayer.gameObject);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(allLayer.gameObject);
				}
			}
			if (meshDataArray.Length != 0)
			{
				meshDataArray.Dispose();
			}
			Dispose();
		}

		public void Dispose()
		{
			if (allTilesAtPosition.IsCreated)
			{
				allTilesAtPosition.Dispose();
			}
			if (topTileAtPosition.IsCreated)
			{
				topTileAtPosition.Dispose();
			}
			if (hiddenTileLookup.IsCreated)
			{
				hiddenTileLookup.Dispose();
			}
			foreach (PugMapLayer2 allLayer in allLayers)
			{
				allLayer.Dispose();
			}
			if (layerDataUpdates.IsCreated)
			{
				foreach (NativeParallelHashMap<int2, int> layerDataUpdate in layerDataUpdates)
				{
					if (layerDataUpdate.IsCreated)
					{
						layerDataUpdate.Dispose();
					}
				}
				layerDataUpdates.Dispose();
			}
			if (layerDataUpdateKeys.IsCreated)
			{
				layerDataUpdateKeys.Dispose();
			}
			if (layerDataUpdatesDirty.IsCreated)
			{
				layerDataUpdatesDirty.Dispose();
			}
		}

		private GameObject NewInternalMapGO(string name, Transform parent)
		{
			GameObject obj = new GameObject(name);
			obj.transform.SetParent(parent, worldPositionStays: false);
			return obj;
		}

		private PugMapLayer2 CreateLayer(int tilesetKey, LayerName key)
		{
			Transform parent = ((!Application.isPlaying) ? base.transform : Manager.camera.VolatileRenderAnchor);
			string text = null;
			PugMapLayer2 pugMapLayer = NewInternalMapGO(text, parent).AddComponent<PugMapLayer2>();
			pugMapLayer.Init(tilesetKey, key);
			if (pugMapLayer.quadGenerator == null)
			{
				return null;
			}
			if (pugMapLayer.quadGenerator.isDataLayer)
			{
				TileType dataTile = pugMapLayer.quadGenerator.dataTile;
				TileInfo value = new TileInfo
				{
					tileset = tilesetKey,
					tileType = dataTile
				};
				pugMapLayer.layerDataLookupKey = layerDataUpdateKeys.Length;
				layerDataUpdateKeys.Add(in value);
				layerDataUpdatesDirty.Add(false);
				layerDataUpdates.Add(new NativeParallelHashMap<int2, int>(64, Allocator.Persistent));
			}
			else
			{
				TileType targetTile = pugMapLayer.quadGenerator.targetTile;
				TileInfo value2 = new TileInfo
				{
					tileset = tilesetKey,
					tileType = targetTile
				};
				if (!layerDataUpdateKeys.Contains(value2))
				{
					Debug.LogError("didn't find " + value2.tileType);
				}
				pugMapLayer.layerDataLookupKey = layerDataUpdateKeys.IndexOf(value2);
			}
			allLayers.Add(pugMapLayer);
			foreach (QuadGenerator layersDependentOnMyDatum in pugMapLayer.quadGenerator.layersDependentOnMyData)
			{
				EnsureLayerPresent(pugMapLayer.tilesetKey, layersDependentOnMyDatum.layerName);
			}
			for (int i = 0; i < allLayers.Count; i++)
			{
				for (int j = i + 1; j < allLayers.Count; j++)
				{
					PugMapLayer2 pugMapLayer2 = allLayers[i];
					PugMapLayer2 pugMapLayer3 = allLayers[j];
					UpdateDependency(pugMapLayer2, pugMapLayer3);
					UpdateDependency(pugMapLayer3, pugMapLayer2);
				}
			}
			return pugMapLayer;
		}

		private void UpdateDependency(PugMapLayer2 layer1, PugMapLayer2 layer2)
		{
			QuadGenerator quadGenerator = layer1.quadGenerator;
			QuadGenerator quadGenerator2 = layer2.quadGenerator;
			if (layer1.layerDataLookupKey != layer2.layerDataLookupKey && !layer1.extraDependentLayers.Contains(layer2) && quadGenerator.isDataLayer && quadGenerator2.isDataLayer)
			{
				TileType dataTile = quadGenerator.dataTile;
				TileType tileType = ((quadGenerator2.overrideTileTypeForMeshAdjustments > TileType.none) ? quadGenerator2.overrideTileTypeForMeshAdjustments : quadGenerator2.dataTile);
				if ((!quadGenerator2.onlyAdaptToOwnTileset && dataTile == tileType) || (quadGenerator2.dontAdaptIfTilePresent != TileType.none && quadGenerator2.dontAdaptIfTilePresent == dataTile) || (quadGenerator.dataTile == TileType.wall && quadGenerator2.dataTile == TileType.wall) || (quadGenerator.dataTile == TileType.ground && quadGenerator2.dataTile == TileType.ground))
				{
					layer1.extraDependentLayers.Add(layer2);
				}
				else if (tileType.ShouldUseFenceLikeAdaptionTowardsTileType(dataTile))
				{
					layer1.extraDependentLayers.Add(layer2);
				}
				else if (quadGenerator2.hideUnderNonTransparentWall && quadGenerator.dataTile == TileType.wall)
				{
					layer1.extraDependentLayers.Add(layer2);
				}
			}
		}

		public PugMapLayer2 GetLayer(int tileset, TileType tileType)
		{
			foreach (PugMapLayer2 allLayer in allLayers)
			{
				if (allLayer.tilesetKey == tileset && allLayer.quadGenerator.dataTile == tileType)
				{
					return allLayer;
				}
			}
			return null;
		}

		private PugMapLayer2 EnsureLayerPresent(int tileset, LayerName key)
		{
			bool flag = false;
			PugMapLayer2 result = null;
			foreach (PugMapLayer2 allLayer in allLayers)
			{
				if (allLayer.tilesetKey == tileset && allLayer.layerDefKey == key)
				{
					flag = true;
					result = allLayer;
					break;
				}
			}
			if (!flag)
			{
				result = CreateLayer(tileset, key);
			}
			return result;
		}

		public bool Build()
		{
			foreach (TileChangeRequest setTileRequest in setTileRequests)
			{
				if (setTileRequest.Add)
				{
					_SetTile(setTileRequest.WorldPosition, setTileRequest.Tile.tileset, setTileRequest.Tile.tileType, setTileRequest.Tile.state);
				}
				else if (setTileRequest.Tile.tileset == 75)
				{
					_ClearTileOfType(setTileRequest.WorldPosition, setTileRequest.Tile.tileType);
				}
				else
				{
					_ClearTileOfTypeAndTileset(setTileRequest.WorldPosition, setTileRequest.Tile.tileType, setTileRequest.Tile.tileset);
				}
			}
			setTileRequests.Clear();
			bool flag = false;
			foreach (PugMapLayer2 allLayer in allLayers)
			{
				if (flag || layerDataUpdatesDirty[allLayer.layerDataLookupKey])
				{
					layersToUpdate.Add(allLayer);
				}
			}
			if (layersToUpdate.Count == 0)
			{
				return false;
			}
			JobHandle dependency = default(JobHandle);
			foreach (PugMapLayer2 item2 in layersToUpdate)
			{
				NativeParallelHashMap<int2, int> nativeParallelHashMap = layerDataUpdates[item2.layerDataLookupKey];
				dependency = item2.PreBuild(dependency, materialCache, ref allTilesAtPosition, ref nativeParallelHashMap, flag);
			}
			tileLookupJobHandle = dependency;
			tileLookupJobCompleted = false;
			int length = 0;
			for (int i = 0; i < layersToUpdate.Count; i++)
			{
				PugMapLayer2 pugMapLayer = layersToUpdate[i];
				NativeParallelHashMap<int2, int> nativeParallelHashMap2 = layerDataUpdates[pugMapLayer.layerDataLookupKey];
				if (pugMapLayer.Build(dependency, allTilesAtPosition, hiddenTileLookup, nativeParallelHashMap2))
				{
					layersToUpdate[length++] = pugMapLayer;
				}
			}
			layersToUpdate.Resize(null, length);
			if (PugMapLayer2.UseJobs)
			{
				meshDataArray = Mesh.AllocateWritableMeshData(layersToUpdate.Count);
				foreach (PugMapLayer2 item3 in layersToUpdate)
				{
					Mesh mesh = item3.ScheduleMeshJob(meshDataArray[meshesToUpdate.Count]);
					if (mesh == null)
					{
						Debug.LogError("Got unexpected null mesh");
					}
					else
					{
						meshesToUpdate.Add(mesh);
					}
				}
			}
			else
			{
				foreach (PugMapLayer2 item4 in layersToUpdate)
				{
					Mesh item = item4.CreateMesh();
					meshesToUpdate.Add(item);
				}
				for (int j = 0; j < layerDataUpdates.Length; j++)
				{
					layerDataUpdates[j].Clear();
				}
			}
			return layersToUpdate.Count > 0;
		}

		public void LateBuild()
		{
			tileLookupJobHandle.Complete();
			foreach (PugMapLayer2 item in layersToUpdate)
			{
				item.CompleteMeshJob();
			}
			if (PugMapLayer2.UseJobs && meshDataArray.Length != 0)
			{
				Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, meshesToUpdate, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontRecalculateBounds);
				meshDataArray = default(Mesh.MeshDataArray);
			}
			foreach (PugMapLayer2 item2 in layersToUpdate)
			{
				item2.ApplyMesh();
			}
			for (int i = 0; i < layerDataUpdates.Length; i++)
			{
				layerDataUpdatesDirty[i] = false;
				layerDataUpdates[i].Clear();
			}
			meshesToUpdate.Clear();
			layersToUpdate.Clear();
		}

		public TileLayerLookup GetTileLayerLookup()
		{
			if (!tileLookupJobCompleted)
			{
				tileLookupJobCompleted = true;
				tileLookupJobHandle.Complete();
			}
			return new TileLayerLookup
			{
				AllTiles = allTilesAtPosition
			};
		}

		public JobHandle GetTileLayerLookup(JobHandle combineDependency, out TileLayerLookup tileLayerLookup)
		{
			tileLayerLookup = new TileLayerLookup
			{
				AllTiles = allTilesAtPosition
			};
			if (!tileLookupJobCompleted)
			{
				return JobHandle.CombineDependencies(combineDependency, tileLookupJobHandle);
			}
			return combineDependency;
		}

		public void AddTileLayerLookupDependency(JobHandle dependency)
		{
			tileLookupDependencies.Add(dependency);
		}

		public bool RaycastWalls(float2 worldPosition, float2 direction, float maxDist, out TileHitInfo hitInfo)
		{
			return RayCastWallsBurstCompiled.RaycastWalls(GetTileLayerLookup(), in worldPosition, in direction, maxDist, out hitInfo);
		}

		public static bool RaycastWalls(float2 worldPosition, float2 direction, float maxDist, out TileHitInfo hitInfo, TileAccessor tileAccessor)
		{
			hitInfo = default(TileHitInfo);
			if (maxDist > 999f)
			{
				Debug.LogError("Raycast max distance was too long!");
				return false;
			}
			float num = math.length(direction);
			if (num < 1.1920929E-07f)
			{
				Debug.LogError("Raycast direction was zero!");
				return false;
			}
			direction /= num;
			float2 x = worldPosition + 0.5f;
			int2 int5 = (int2)math.floor(x);
			float2 float5 = math.frac(x);
			int2 int6 = (int2)math.sign(direction);
			float2 float6 = 1f / math.abs(direction);
			float2 float7 = new float2((int6.x > 0) ? (1f - float5.x) : float5.x, (int6.y > 0) ? (1f - float5.y) : float5.y) * float6;
			float num2 = 0f;
			hitInfo.distance = -1f;
			int num3 = 0;
			while (num2 < maxDist)
			{
				if (tileAccessor.GetTop(int5).tileType.IsWallTile())
				{
					hitInfo.distance = num2;
					hitInfo.point = worldPosition + direction * num2;
					hitInfo.tile = int5;
					break;
				}
				if (num3 > 999)
				{
					Debug.LogError("Reached max iteration count!");
					break;
				}
				if ((float7.x < float7.y && !float.IsNaN(float7.x)) || float.IsNaN(float7.y))
				{
					int5.x += int6.x;
					num2 = float7.x;
					float7.x += float6.x;
				}
				else
				{
					int5.y += int6.y;
					num2 = float7.y;
					float7.y += float6.y;
				}
				if (num2 > maxDist)
				{
					break;
				}
			}
			return hitInfo.distance >= 0f;
		}

		public static bool RaycastNonWalkableTiles(float2 worldPosition, float2 direction, float maxDist, out TileHitInfo hitInfo, TileAccessor tileAccessor)
		{
			hitInfo = default(TileHitInfo);
			if (maxDist > 999f)
			{
				Debug.LogError("Raycast max distance was too long!");
				return false;
			}
			float num = math.length(direction);
			if (num < 1.1920929E-07f)
			{
				Debug.LogError("Raycast direction was zero!");
				return false;
			}
			direction /= num;
			float2 x = worldPosition + 0.5f;
			int2 int5 = (int2)math.floor(x);
			float2 float5 = math.frac(x);
			int2 int6 = (int2)math.sign(direction);
			float2 float6 = 1f / math.abs(direction);
			float2 float7 = new float2((int6.x > 0) ? (1f - float5.x) : float5.x, (int6.y > 0) ? (1f - float5.y) : float5.y) * float6;
			float num2 = 0f;
			hitInfo.distance = -1f;
			int num3 = 0;
			while (num2 < maxDist)
			{
				if (!tileAccessor.GetTop(int5).tileType.IsWalkableTile())
				{
					hitInfo.distance = num2;
					hitInfo.point = worldPosition + direction * num2;
					hitInfo.tile = int5;
					break;
				}
				if (num3 > 999)
				{
					Debug.LogError("Reached max iteration count!");
					break;
				}
				if ((float7.x < float7.y && !float.IsNaN(float7.x)) || float.IsNaN(float7.y))
				{
					int5.x += int6.x;
					num2 = float7.x;
					float7.x += float6.x;
				}
				else
				{
					int5.y += int6.y;
					num2 = float7.y;
					float7.y += float6.y;
				}
				if (num2 > maxDist)
				{
					break;
				}
			}
			return hitInfo.distance >= 0f;
		}

		public static bool RaycastSolidTiles(float2 worldPosition, float2 direction, float maxDist, out TileHitInfo hitInfo, TileAccessor tileAccessor)
		{
			hitInfo = default(TileHitInfo);
			if (maxDist > 999f)
			{
				Debug.LogError("Raycast max distance was too long!");
				return false;
			}
			float num = math.length(direction);
			if (num < 1.1920929E-07f)
			{
				Debug.LogError("Raycast direction was zero!");
				return false;
			}
			direction /= num;
			float2 x = worldPosition + 0.5f;
			int2 int5 = (int2)math.floor(x);
			float2 float5 = math.frac(x);
			int2 int6 = (int2)math.sign(direction);
			float2 float6 = 1f / math.abs(direction);
			float2 float7 = new float2((int6.x > 0) ? (1f - float5.x) : float5.x, (int6.y > 0) ? (1f - float5.y) : float5.y) * float6;
			float num2 = 0f;
			hitInfo.distance = -1f;
			int num3 = 0;
			while (num2 < maxDist)
			{
				if (!tileAccessor.GetTop(int5).tileType.IsNonSolidTile())
				{
					hitInfo.distance = num2;
					hitInfo.point = worldPosition + direction * num2;
					hitInfo.tile = int5;
					break;
				}
				if (num3 > 999)
				{
					Debug.LogError("Reached max iteration count!");
					break;
				}
				if ((float7.x < float7.y && !float.IsNaN(float7.x)) || float.IsNaN(float7.y))
				{
					int5.x += int6.x;
					num2 = float7.x;
					float7.x += float6.x;
				}
				else
				{
					int5.y += int6.y;
					num2 = float7.y;
					float7.y += float6.y;
				}
				if (num2 > maxDist)
				{
					break;
				}
			}
			return hitInfo.distance >= 0f;
		}

		public static void RaycastTilePositions(float2 startPosition, float2 stopPosition, NativeList<int2> tilePositions)
		{
			float2 x = startPosition + 0.5f;
			int2 value = (int2)math.floor(x);
			tilePositions.Add(in value);
			float2 x2 = stopPosition - startPosition;
			float num = math.length(x2);
			if (num < 1.1920929E-07f)
			{
				return;
			}
			x2 /= num;
			float2 float5 = math.frac(x);
			int2 int5 = (int2)math.sign(x2);
			float2 float6 = 1f / math.abs(x2);
			float2 float7 = new float2((int5.x > 0) ? (1f - float5.x) : float5.x, (int5.y > 0) ? (1f - float5.y) : float5.y) * float6;
			float num2 = 0f;
			float num3 = math.length(stopPosition - startPosition);
			while (num2 < num3)
			{
				if ((float7.x < float7.y && !float.IsNaN(float7.x)) || float.IsNaN(float7.y))
				{
					value.x += int5.x;
					num2 = float7.x;
					float7.x += float6.x;
				}
				else
				{
					value.y += int5.y;
					num2 = float7.y;
					float7.y += float6.y;
				}
				tilePositions.Add(in value);
				if (num2 > num3)
				{
					break;
				}
			}
		}

		public void ApplySortedTileUpdates(NativeList<SendClientSubMapToPugMapSystem.TileUpdate> sortedTileUpdates)
		{
			NativeList<TileUpdatesLayer> tileUpdatesLayers = new NativeList<TileUpdatesLayer>(Allocator.Temp);
			NativeList<int> extraLayerKeys = new NativeList<int>(Allocator.Temp);
			int num = -1;
			TileType tileType = TileType.none;
			int num2 = 0;
			int num3 = 0;
			foreach (SendClientSubMapToPugMapSystem.TileUpdate item in sortedTileUpdates)
			{
				if (item.tileset != num || item.tileType != tileType)
				{
					AddTileUpdateLayer(tileUpdatesLayers, extraLayerKeys, num, tileType, sortedTileUpdates, num2, num3);
					num = item.tileset;
					tileType = item.tileType;
					num2 += num3;
					num3 = 0;
				}
				num3++;
			}
			AddTileUpdateLayer(tileUpdatesLayers, extraLayerKeys, num, tileType, sortedTileUpdates, num2, num3);
			ApplyTileUpdateLayers(ref layerDataUpdates, ref layerDataUpdatesDirty, in sortedTileUpdates, in tileUpdatesLayers, in extraLayerKeys);
			sortedTileUpdates.Clear();
		}

		private void AddTileUpdateLayer(NativeList<TileUpdatesLayer> layers, NativeList<int> extraLayerKeys, int tileset, TileType tileType, NativeList<SendClientSubMapToPugMapSystem.TileUpdate> tileUpdates, int start, int length)
		{
			if (length == 0 || tileType == TileType.none)
			{
				return;
			}
			PugMapLayer2 pugMapLayer = EnsureLayerPresent(tileset, TileTypeToLayerName.GetLayerName(tileType));
			if (pugMapLayer == null)
			{
				Debug.LogError("no such tileset/type");
				return;
			}
			if (Application.isPlaying && tileType.ShouldRerenderLights())
			{
				for (int i = 0; i < length; i++)
				{
					SendClientSubMapToPugMapSystem.TileUpdate tileUpdate = tileUpdates[start + i];
					if (tileUpdate.triggerLightUpdate)
					{
						Manager.lights.UpdateShadowsAtTilePosition(tileUpdate.pos);
					}
				}
			}
			layers.Add(new TileUpdatesLayer
			{
				start = start,
				length = length,
				layerKey = pugMapLayer.layerDataLookupKey,
				extraLayersStart = extraLayerKeys.Length,
				extraLayersLength = pugMapLayer.extraDependentLayers.Count
			});
			for (int j = 0; j < pugMapLayer.extraDependentLayers.Count; j++)
			{
				extraLayerKeys.Add(pugMapLayer.extraDependentLayers[j].layerDataLookupKey);
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(PugTilemap_002EApplyTileUpdateLayers_00006C86_0024PostfixBurstDelegate))]
		private static void ApplyTileUpdateLayers(ref NativeList<NativeParallelHashMap<int2, int>> layerDataUpdates, ref NativeList<bool> layerDataUpdatesDirty, in NativeList<SendClientSubMapToPugMapSystem.TileUpdate> sortedTileUpdates, in NativeList<TileUpdatesLayer> tileUpdatesLayers, in NativeList<int> extraLayerKeys)
		{
			ApplyTileUpdateLayers_00006C86_0024BurstDirectCall.Invoke(ref layerDataUpdates, ref layerDataUpdatesDirty, in sortedTileUpdates, in tileUpdatesLayers, in extraLayerKeys);
		}

		public void ClearTileOfType(int2 worldPosition, TileType tileType)
		{
			setTileRequests.Add(new TileChangeRequest
			{
				WorldPosition = worldPosition,
				Tile = new TileInfo
				{
					tileset = 75,
					tileType = tileType
				},
				Add = false
			});
		}

		private void _ClearTileOfType(int2 worldPosition, TileType type)
		{
			if (Application.isPlaying && type.ShouldRerenderLights())
			{
				Manager.lights.UpdateShadowsAtTilePosition(worldPosition);
			}
			foreach (PugMapLayer2 allLayer in allLayers)
			{
				if (allLayer.quadGenerator.dataTile == type)
				{
					NativeParallelHashMap<int2, int> nativeParallelHashMap = layerDataUpdates[allLayer.layerDataLookupKey];
					nativeParallelHashMap[worldPosition] = -1;
					layerDataUpdatesDirty[allLayer.layerDataLookupKey] = true;
					for (int i = 0; i < allLayer.extraDependentLayers.Count; i++)
					{
						int layerDataLookupKey = allLayer.extraDependentLayers[i].layerDataLookupKey;
						layerDataUpdates[layerDataLookupKey].TryAdd(worldPosition, -2);
						layerDataUpdatesDirty[layerDataLookupKey] = true;
					}
				}
			}
		}

		public void ClearTileOfTypeAndTileset(int2 worldPosition, TileType tileType, int tileset)
		{
			setTileRequests.Add(new TileChangeRequest
			{
				WorldPosition = worldPosition,
				Tile = new TileInfo
				{
					tileset = tileset,
					tileType = tileType
				},
				Add = false
			});
		}

		private void _ClearTileOfTypeAndTileset(int2 worldPosition, TileType type, int tileset)
		{
			if (Application.isPlaying && type.ShouldRerenderLights())
			{
				Manager.lights.UpdateShadowsAtTilePosition(worldPosition);
			}
			foreach (PugMapLayer2 allLayer in allLayers)
			{
				if (allLayer.quadGenerator.dataTile == type && allLayer.tilesetKey == tileset)
				{
					NativeParallelHashMap<int2, int> nativeParallelHashMap = layerDataUpdates[allLayer.layerDataLookupKey];
					nativeParallelHashMap[worldPosition] = -1;
					layerDataUpdatesDirty[allLayer.layerDataLookupKey] = true;
					for (int i = 0; i < allLayer.extraDependentLayers.Count; i++)
					{
						int layerDataLookupKey = allLayer.extraDependentLayers[i].layerDataLookupKey;
						layerDataUpdates[layerDataLookupKey].TryAdd(worldPosition, -2);
						layerDataUpdatesDirty[layerDataLookupKey] = true;
					}
					break;
				}
			}
		}

		public void SetTile(int2 worldPosition, int tileset, TileType tileType, int state = 0)
		{
			int2 int5 = (Application.isPlaying ? Manager.camera.RenderOrigo.ToInt2() : int2.zero);
			if (!(math.lengthsq(worldPosition - int5) > 22500f))
			{
				setTileRequests.Add(new TileChangeRequest
				{
					WorldPosition = worldPosition,
					Tile = new TileInfo
					{
						tileset = tileset,
						tileType = tileType,
						state = state
					},
					Add = true
				});
			}
		}

		private void _SetTile(int2 worldPosition, int tileset, TileType tileType, int state = 0)
		{
			if (Application.isPlaying && tileType.ShouldRerenderLights())
			{
				Manager.lights.UpdateShadowsAtTilePosition(worldPosition);
			}
			PugMapLayer2 pugMapLayer = EnsureLayerPresent(tileset, TileTypeToLayerName.GetLayerName(tileType));
			if (pugMapLayer == null)
			{
				Debug.LogError("no such tileset/type");
			}
			else if (pugMapLayer.quadGenerator.isDataLayer)
			{
				NativeParallelHashMap<int2, int> nativeParallelHashMap = layerDataUpdates[pugMapLayer.layerDataLookupKey];
				nativeParallelHashMap[worldPosition] = state;
				layerDataUpdatesDirty[pugMapLayer.layerDataLookupKey] = true;
				for (int i = 0; i < pugMapLayer.extraDependentLayers.Count; i++)
				{
					int layerDataLookupKey = pugMapLayer.extraDependentLayers[i].layerDataLookupKey;
					layerDataUpdates[layerDataLookupKey].TryAdd(worldPosition, -2);
					layerDataUpdatesDirty[layerDataLookupKey] = true;
				}
			}
		}

		public void SetHiddenTile(int2 worldPosition, int tileset, TileType tiletype, int state)
		{
			hiddenTileChangeRequests.Add(new TileChangeRequest
			{
				WorldPosition = worldPosition,
				Tile = new TileInfo
				{
					tileType = tiletype,
					tileset = tileset,
					state = state
				},
				Add = true
			});
		}

		public bool HasHiddenTile(int2 worldPosition, int tileset, TileType tileType)
		{
			using NativeParallelMultiHashMap<int2, TileInfo>.Enumerator enumerator = hiddenTileLookup.GetValuesForKey(worldPosition);
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.tileType == tileType && enumerator.Current.tileset == tileset && enumerator.Current.tileType == tileType)
				{
					return true;
				}
			}
			return false;
		}

		public void ClearHiddenTileOfType(int2 worldPosition, TileType tileType)
		{
			hiddenTileChangeRequests.Add(new TileChangeRequest
			{
				WorldPosition = worldPosition,
				Tile = new TileInfo
				{
					tileType = tileType,
					tileset = -1,
					state = 0
				},
				Add = false
			});
		}

		public void ClearHiddenTileOfTypeAndTileset(int2 worldPosition, TileType tileType, int tileset)
		{
			hiddenTileChangeRequests.Add(new TileChangeRequest
			{
				WorldPosition = worldPosition,
				Tile = new TileInfo
				{
					tileType = tileType,
					tileset = tileset,
					state = 0
				},
				Add = false
			});
		}

		private void _SetHiddenInCache(TileChangeRequest request)
		{
			using NativeParallelMultiHashMap<int2, TileInfo>.Enumerator enumerator = hiddenTileLookup.GetValuesForKey(request.WorldPosition);
			bool flag = false;
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.tileType == request.Tile.tileType && (request.Tile.tileset == -1 || enumerator.Current.tileset == request.Tile.tileset))
				{
					if (request.Add && enumerator.Current.tileset == request.Tile.tileset && enumerator.Current.state == request.Tile.state)
					{
						flag = true;
					}
					else
					{
						hiddenTileLookup.Remove(request.WorldPosition, enumerator.Current);
						SetDirty(request.WorldPosition, enumerator.Current);
					}
					if (request.Tile.tileset != -1)
					{
						break;
					}
				}
			}
			if (request.Add && !flag)
			{
				hiddenTileLookup.Add(request.WorldPosition, request.Tile);
				SetDirty(request.WorldPosition, request.Tile);
			}
		}

		private void SetDirty(int2 worldPosition, TileInfo tile)
		{
			PugMapLayer2 layer = GetLayer(tile.tileset, tile.tileType);
			if (!(layer == null))
			{
				layerDataUpdates[layer.layerDataLookupKey].TryAdd(worldPosition, -2);
				layerDataUpdatesDirty[layer.layerDataLookupKey] = true;
				for (int i = 0; i < layer.extraDependentLayers.Count; i++)
				{
					int layerDataLookupKey = layer.extraDependentLayers[i].layerDataLookupKey;
					layerDataUpdates[layerDataLookupKey].TryAdd(worldPosition, -2);
					layerDataUpdatesDirty[layerDataLookupKey] = true;
				}
			}
		}

		public Sprite GetSpriteOfSurfaceTile(int2 worldPosition, out Material material)
		{
			material = null;
			TileInfo topTile = GetTileLayerLookup().GetTopTile(worldPosition);
			if (topTile.tileType != TileType.none)
			{
				return GetSpriteOfTile(worldPosition, topTile.tileset, topTile.tileType, out material);
			}
			return null;
		}

		private Sprite GetSpriteOfTile(int2 worldPosition, int tileset, TileType tileType, out Material material)
		{
			material = null;
			Quad quad = default(Quad);
			PugMapLayer2 layer = GetLayer(tileset, tileType);
			if (layer != null)
			{
				quad = layer.GetQuad(worldPosition);
				Texture2D texture = layer.texture;
				material = layer.material;
				if (texture != null)
				{
					Vector2Int size = texture.GetSize();
					Rect rect = new Rect(quad.spriteUV.min * size, quad.spriteUV.size * size);
					return Sprite.Create(texture, rect, Vector2.one * 0.5f, 16f);
				}
			}
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void ApplyTileUpdateLayers_0024BurstManaged(ref NativeList<NativeParallelHashMap<int2, int>> layerDataUpdates, ref NativeList<bool> layerDataUpdatesDirty, in NativeList<SendClientSubMapToPugMapSystem.TileUpdate> sortedTileUpdates, in NativeList<TileUpdatesLayer> tileUpdatesLayers, in NativeList<int> extraLayerKeys)
		{
			foreach (TileUpdatesLayer tileUpdatesLayer in tileUpdatesLayers)
			{
				layerDataUpdatesDirty[tileUpdatesLayer.layerKey] = true;
				NativeParallelHashMap<int2, int> nativeParallelHashMap = layerDataUpdates[tileUpdatesLayer.layerKey];
				for (int i = 0; i < tileUpdatesLayer.length; i++)
				{
					SendClientSubMapToPugMapSystem.TileUpdate tileUpdate = sortedTileUpdates[tileUpdatesLayer.start + i];
					nativeParallelHashMap[tileUpdate.pos] = ((!tileUpdate.add) ? (-1) : 0);
					for (int j = 0; j < tileUpdatesLayer.extraLayersLength; j++)
					{
						int index = extraLayerKeys[tileUpdatesLayer.extraLayersStart + j];
						layerDataUpdatesDirty[index] = true;
						layerDataUpdates[index].TryAdd(tileUpdate.pos, -2);
					}
				}
			}
		}
	}
}
