using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pug.Automation;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(TransformSystemGroup), OrderLast = true)]
public class ShaderTexturesSystem : SystemBase
{
	private struct GroundFogData
	{
		public float r;

		public float g;

		public float b;

		public float intensity;
	}

	[NoAlias]
	[BurstCompile]
	private struct ShaderTexturesSystem_6A0878D7_LambdaJob_0_Job : IJobChunk
	{
		public int minX;

		public int maxX;

		public int minZ;

		public int maxZ;

		public NativeArray<Color32> ignoreVertexOffset;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public int widthLocal;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __objectDataTypeHandle;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in LocalTransform transform, [NoAlias] in ObjectDataCD objectData)
		{
			float3 float5 = math.round(transform.Position);
			if (!(float5.x >= (float)minX) || !(float5.x < (float)maxX) || !(float5.z >= (float)minZ) || !(float5.z < (float)maxZ))
			{
				return;
			}
			ref PugDatabase.EntityObjectInfo entityObjectInfo = ref PugDatabase.GetEntityObjectInfo(objectData.objectID, databaseLocal);
			int2 size = entityObjectInfo.prefabTileSize;
			int2 offset = entityObjectInfo.prefabCornerOffset;
			if (__DirectionCD_ComponentLookup.HasComponent(entity))
			{
				__DirectionCD_ComponentLookup[entity].GetPrefabOffsetAndTileSize(offset, size, out offset, out size);
			}
			int num = (int)float5.x - minX + ((int)float5.z - minZ) * widthLocal;
			for (int i = offset.x; i < size.x + offset.x; i++)
			{
				for (int j = offset.y; j < size.y + offset.y; j++)
				{
					int num2 = num + i + j * 36;
					if (num2 >= 0 && num2 < ignoreVertexOffset.Length)
					{
						Color32 value = ignoreVertexOffset[num2];
						value.r = byte.MaxValue;
						ignoreVertexOffset[num2] = value;
					}
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __objectDataTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ObjectDataCD>(nativeArrayPtr3, l));
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct ShaderTexturesSystem_6A0878D7_LambdaJob_1_Job : IJobChunk
	{
		public int minX;

		public int maxX;

		public int minZ;

		public int maxZ;

		public NativeArray<Color32> electricityStrength;

		public int widthLocal;

		[ReadOnly]
		public ComponentTypeHandle<ElectricityCD> __electricityCDTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] in ElectricityCD electricityCD, [NoAlias] in LocalTransform transform)
		{
			float3 float5 = math.round(transform.Position);
			int num = 0;
			if (electricityCD.circuitType == CircuitType.None || (electricityCD.circuitType == CircuitType.Condition && !electricityCD.blocksElectricity))
			{
				num = electricityCD.electricityAmount + electricityCD.sourceEnergy;
			}
			else if (electricityCD.circuitType == CircuitType.Delay)
			{
				num = electricityCD.sourceEnergy;
			}
			num--;
			if (electricityCD.deprioritize || (electricityCD.circuitConnectionMode & CircuitConnectionMode.BlockingDirectionCircuitTypes) != CircuitConnectionMode.None)
			{
				num--;
			}
			if (num > 0 && float5.x >= (float)minX && float5.x < (float)maxX && float5.z >= (float)minZ && float5.z < (float)maxZ)
			{
				int index = (int)float5.x - minX + ((int)float5.z - minZ) * widthLocal;
				Color32 color = electricityStrength[index];
				int x = (int)math.floor(255f * math.min(1f, (float)(num + 2) / 10f));
				x = math.max(x, color.r);
				Color32 value = new Color32((byte)x, 0, 0, color.a);
				electricityStrength[index] = value;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __electricityCDTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<ElectricityCD>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct ShaderTexturesSystem_6A0878D7_LambdaJob_2_Job : IJobChunk
	{
		public int minX;

		public int maxX;

		public int minZ;

		public int maxZ;

		public NativeArray<Color32> electricityStrength;

		public int widthLocal;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<AncientElectricityConnectionCD> __electricityConnectionCDTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __transformTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in AncientElectricityConnectionCD electricityConnectionCD, [NoAlias] in LocalTransform transform)
		{
			float3 float5 = math.round(transform.Position);
			if (electricityConnectionCD.electricityAmount > 0 && float5.x >= (float)minX && float5.x < (float)maxX && float5.z >= (float)minZ && float5.z < (float)maxZ)
			{
				int index = (int)float5.x - minX + ((int)float5.z - minZ) * widthLocal;
				Color32 value = electricityStrength[index];
				value.g = (byte)math.floor(255f * math.min(1f, (float)(electricityConnectionCD.electricityAmount + electricityConnectionCD.sourceEnergy + 2) / 10f));
				electricityStrength[index] = value;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __electricityConnectionCDTypeHandle);
			IntPtr nativeArrayPtr3 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __transformTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AncientElectricityConnectionCD>(nativeArrayPtr2, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AncientElectricityConnectionCD>(nativeArrayPtr2, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AncientElectricityConnectionCD>(nativeArrayPtr2, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<AncientElectricityConnectionCD>(nativeArrayPtr2, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<LocalTransform>(nativeArrayPtr3, l));
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct ShaderTexturesSystem_6A0878D7_LambdaJob_3_Job : IJobChunk
	{
		public NativeArray<bool> greatWallShouldOffsetVertices;

		[ReadOnly]
		public ComponentTypeHandle<TheGreatWallAnimationSystem.TheGreatWallanimationBuffer> __greatWallAnimationTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody([NoAlias] in TheGreatWallAnimationSystem.TheGreatWallanimationBuffer greatWallAnimation)
		{
			greatWallShouldOffsetVertices[0] = greatWallAnimation.animationTimer < 3f;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __greatWallAnimationTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TheGreatWallAnimationSystem.TheGreatWallanimationBuffer>(nativeArrayPtr, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TheGreatWallAnimationSystem.TheGreatWallanimationBuffer>(nativeArrayPtr, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TheGreatWallAnimationSystem.TheGreatWallanimationBuffer>(nativeArrayPtr, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<TheGreatWallAnimationSystem.TheGreatWallanimationBuffer>(nativeArrayPtr, l));
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct ShaderTexturesSystem_6A0878D7_LambdaJob_4_Job : IJob
	{
		public int minX;

		public int maxX;

		public int minZ;

		public int maxZ;

		public NativeArray<Color32> ignoreVertexOffset;

		public Color32 blackLocal;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody()
		{
			for (int i = minZ; i < maxZ; i++)
			{
				for (int j = minX; j < maxX; j++)
				{
					int index = j - minX + (i - minZ) * 36;
					ignoreVertexOffset[index] = blackLocal;
				}
			}
		}

		public void Execute()
		{
			OriginalLambdaBody();
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct ShaderTexturesSystem_6A0878D7_LambdaJob_5_Job : IJob
	{
		public int minX;

		public int maxX;

		public int minZ;

		public int maxZ;

		public NativeArray<Color32> electricityStrength;

		public Color32 blackLocal;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody()
		{
			for (int i = minZ; i < maxZ; i++)
			{
				for (int j = minX; j < maxX; j++)
				{
					int index = j - minX + (i - minZ) * 36;
					electricityStrength[index] = blackLocal;
				}
			}
		}

		public void Execute()
		{
			OriginalLambdaBody();
		}
	}

	[NoAlias]
	[BurstCompile]
	private struct ShaderTexturesSystem_6A0878D7_LambdaJob_6_Job : IJob
	{
		public int minX;

		public int maxX;

		public int minZ;

		public int maxZ;

		public NativeArray<Color32> groundFogTint;

		public NativeArray<Color32> ignoreVertexOffset;

		public BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal;

		public NativeArray<bool> greatWallShouldOffsetVertices;

		[ReadOnly]
		public SinglePugMap.TileLayerLookup tileLookup;

		public NativeParallelHashMap<TileInfo, int> groundFogLookupLocal;

		public NativeArray<GroundFogData> groundFogDataLocal;

		[ReadOnly]
		public ComponentLookup<IgnoreVertexOffsetsCD> __IgnoreVertexOffsetsCD_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody()
		{
			NativeParallelHashMap<TileInfo, ObjectID> nativeParallelHashMap = new NativeParallelHashMap<TileInfo, ObjectID>(128, Allocator.Temp);
			NativeParallelHashMap<int, bool> nativeParallelHashMap2 = new NativeParallelHashMap<int, bool>(128, Allocator.Temp);
			for (int i = minZ; i < maxZ; i++)
			{
				for (int j = minX; j < maxX; j++)
				{
					int index = j - minX + (i - minZ) * 36;
					int2 int5 = new int2(j, i);
					bool hasWater;
					TileInfo topTileAndCheckWater = tileLookup.GetTopTileAndCheckWater(int5, out hasWater);
					ObjectID objectID;
					if (nativeParallelHashMap.ContainsKey(topTileAndCheckWater))
					{
						objectID = nativeParallelHashMap[topTileAndCheckWater];
					}
					else
					{
						objectID = PugDatabase.GetObjectID(topTileAndCheckWater.tileset, topTileAndCheckWater.tileType, databaseLocal);
						nativeParallelHashMap.Add(topTileAndCheckWater, objectID);
					}
					Color32 value = ignoreVertexOffset[index];
					Color32 value2 = groundFogTint[index];
					if (objectID != ObjectID.None)
					{
						bool flag = true;
						if (objectID != ObjectID.GreatWallBlock || greatWallShouldOffsetVertices[0])
						{
							flag = (nativeParallelHashMap2.ContainsKey((int)objectID) ? nativeParallelHashMap2[(int)objectID] : (nativeParallelHashMap2[(int)objectID] = __IgnoreVertexOffsetsCD_ComponentLookup.HasComponent(PugDatabase.GetPrimaryPrefabEntity(objectID, databaseLocal))));
							if (!flag && tileLookup.AllTiles.TryGetFirstValue(int5, out var item, out var it))
							{
								do
								{
									if (item.tileType.GetSurfacePriorityFromJob() != -1)
									{
										ObjectID objectID2;
										if (nativeParallelHashMap.ContainsKey(item))
										{
											objectID2 = nativeParallelHashMap[item];
										}
										else
										{
											objectID2 = PugDatabase.GetObjectID(item.tileset, item.tileType, databaseLocal);
											nativeParallelHashMap.Add(item, objectID2);
										}
										flag = (nativeParallelHashMap2.ContainsKey((int)objectID2) ? nativeParallelHashMap2[(int)objectID2] : (nativeParallelHashMap2[(int)objectID2] = __IgnoreVertexOffsetsCD_ComponentLookup.HasComponent(PugDatabase.GetPrimaryPrefabEntity(objectID2, databaseLocal))));
										if (flag)
										{
											break;
										}
									}
								}
								while (tileLookup.AllTiles.TryGetNextValue(out item, ref it));
							}
						}
						bool flag4 = groundFogLookupLocal.ContainsKey(topTileAndCheckWater);
						TileInfo key = topTileAndCheckWater;
						if (!flag4 && tileLookup.AllTiles.TryGetFirstValue(int5, out var item2, out var it2))
						{
							do
							{
								flag4 = groundFogLookupLocal.ContainsKey(item2);
								key = item2;
							}
							while (!flag4 && tileLookup.AllTiles.TryGetNextValue(out item2, ref it2));
						}
						if (flag)
						{
							value.r = byte.MaxValue;
						}
						if (hasWater)
						{
							value.g = 100;
						}
						else if (flag4)
						{
							value.g = 150;
							int num = groundFogLookupLocal[key];
							GroundFogData groundFogData = groundFogDataLocal[num];
							value2.r = (byte)(groundFogData.r * 255f);
							value2.g = (byte)(groundFogData.g * 255f);
							value2.b = (byte)(groundFogData.b * 255f);
							value2.a = (byte)(groundFogData.intensity * 255f);
							value.a = (byte)num;
						}
						else if (objectID == ObjectID.Pit || objectID == ObjectID.GreatWallBlock || objectID == ObjectID.WoodBridge)
						{
							value.g = byte.MaxValue;
						}
						if (objectID == ObjectID.WallHiveBlock)
						{
							value.b = 50;
						}
					}
					if (value.b == 0 && (topTileAndCheckWater.tileType == TileType.wall || topTileAndCheckWater.tileType == TileType.ore))
					{
						value.b = byte.MaxValue;
					}
					ignoreVertexOffset[index] = value;
					groundFogTint[index] = value2;
				}
			}
			nativeParallelHashMap2.Dispose();
			nativeParallelHashMap.Dispose();
		}

		public void Execute()
		{
			OriginalLambdaBody();
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<ObjectDataCD> __ObjectDataCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentTypeHandle<ElectricityCD> __Pug_Automation_ElectricityCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<AncientElectricityConnectionCD> __AncientElectricityConnectionCD_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<TheGreatWallAnimationSystem.TheGreatWallanimationBuffer> __TheGreatWallAnimationSystem_TheGreatWallanimationBuffer_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<IgnoreVertexOffsetsCD> __IgnoreVertexOffsetsCD_RO_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			__ObjectDataCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
			__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
			__Pug_Automation_ElectricityCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricityCD>(isReadOnly: true);
			__AncientElectricityConnectionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AncientElectricityConnectionCD>(isReadOnly: true);
			__TheGreatWallAnimationSystem_TheGreatWallanimationBuffer_RO_ComponentTypeHandle = state.GetComponentTypeHandle<TheGreatWallAnimationSystem.TheGreatWallanimationBuffer>(isReadOnly: true);
			__IgnoreVertexOffsetsCD_RO_ComponentLookup = state.GetComponentLookup<IgnoreVertexOffsetsCD>(isReadOnly: true);
		}
	}

	private const int width = 36;

	private const int height = 24;

	private const int halfWidth = 18;

	private const int halfHeight = 12;

	private readonly Color32 black = Color.black;

	private Vector2 textureSize = new Vector2(36f, 24f);

	private ShaderTexturesFinalizeSystem finalizeSystem;

	private BlobAssetReference<PugDatabase.PugDatabaseBank> database;

	private static readonly int EffectsTextureSize = Shader.PropertyToID("effectsTextureSize");

	private NativeParallelHashMap<TileInfo, int> groundFogLookup;

	private NativeArray<GroundFogData> groundFogData;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1870338569_0;

	private EntityQuery __query_1870338569_1;

	private EntityQuery __query_1870338569_2;

	private EntityQuery __query_1870338569_3;

	private EntityQuery __query_1870338569_4;

	public JobHandle GetOutputDependency()
	{
		return base.Dependency;
	}

	[Preserve]
	protected override void OnCreate()
	{
		Shader.SetGlobalVector(EffectsTextureSize, textureSize);
		finalizeSystem = base.World.GetOrCreateSystemManaged<ShaderTexturesFinalizeSystem>();
		RequireForUpdate<PugDatabase.DatabaseBankCD>();
		UpdateGroundFogLookup();
	}

	private void UpdateGroundFogLookup()
	{
		groundFogLookup.Dispose();
		groundFogData.Dispose();
		IReadOnlyList<GroundFogDataBlock> dataBlocks = ScriptableData.GetDataBlocks<GroundFogDataBlock>();
		int num = 0;
		if (dataBlocks != null && dataBlocks.Count > 0)
		{
			num = dataBlocks.Count;
		}
		groundFogLookup = new NativeParallelHashMap<TileInfo, int>(num, Allocator.Persistent);
		groundFogData = new NativeArray<GroundFogData>(num, Allocator.Persistent);
		if (dataBlocks != null)
		{
			for (int i = 0; i < dataBlocks.Count; i++)
			{
				GroundFogDataBlock groundFogDataBlock = dataBlocks[i];
				TileInfo key = new TileInfo
				{
					tileset = (int)groundFogDataBlock.tileset,
					tileType = groundFogDataBlock.tileType,
					state = 0
				};
				groundFogLookup[key] = i;
				groundFogData[i] = new GroundFogData
				{
					r = groundFogDataBlock.tint.r,
					g = groundFogDataBlock.tint.g,
					b = groundFogDataBlock.tint.b,
					intensity = groundFogDataBlock.tint.a
				};
			}
		}
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		database = __query_1870338569_4.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (Manager.sceneHandler.isInGame)
		{
			Vector3Int renderOrigo = Manager.camera.RenderOrigo;
			int minX = renderOrigo.x - 18;
			int maxX = renderOrigo.x + 18;
			int minZ = renderOrigo.z - 12;
			int maxZ = renderOrigo.z + 12;
			NativeArray<Color32> rawTextureData = finalizeSystem.electricityTex.GetRawTextureData<Color32>();
			NativeArray<Color32> rawTextureData2 = finalizeSystem.groundFogTintTex.GetRawTextureData<Color32>();
			NativeArray<Color32> ignoreVertexOffset = finalizeSystem.BeginWriteIgnoreVertexOffsets();
			BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal = database;
			int widthLocal = 36;
			Color32 blackLocal = black;
			ShaderTexturesSystem_6A0878D7_LambdaJob_4_Execute(minX, maxX, minZ, maxZ, ignoreVertexOffset, blackLocal);
			ShaderTexturesSystem_6A0878D7_LambdaJob_0_Execute(minX, maxX, minZ, maxZ, ignoreVertexOffset, databaseLocal, widthLocal);
			ShaderTexturesSystem_6A0878D7_LambdaJob_5_Execute(minX, maxX, minZ, maxZ, rawTextureData, blackLocal);
			ShaderTexturesSystem_6A0878D7_LambdaJob_1_Execute(minX, maxX, minZ, maxZ, rawTextureData, widthLocal);
			ShaderTexturesSystem_6A0878D7_LambdaJob_2_Execute(minX, maxX, minZ, maxZ, rawTextureData, widthLocal);
			NativeArray<bool> greatWallShouldOffsetVertices = CollectionHelper.CreateNativeArray<bool>(1, base.World.UpdateAllocator.Handle);
			greatWallShouldOffsetVertices[0] = true;
			ShaderTexturesSystem_6A0878D7_LambdaJob_3_Execute(greatWallShouldOffsetVertices);
			base.Dependency = Manager.multiMap.GetTileLayerLookup(base.Dependency, out var tileLayerLookup);
			NativeParallelHashMap<TileInfo, int> groundFogLookupLocal = groundFogLookup;
			NativeArray<GroundFogData> groundFogDataLocal = groundFogData;
			ShaderTexturesSystem_6A0878D7_LambdaJob_6_Execute(minX, maxX, minZ, maxZ, rawTextureData2, ignoreVertexOffset, databaseLocal, greatWallShouldOffsetVertices, tileLayerLookup, groundFogLookupLocal, groundFogDataLocal);
			Manager.multiMap.AddTileLayerLookupDependency(base.Dependency);
		}
	}

	[Preserve]
	protected override void OnDestroy()
	{
		groundFogLookup.Dispose();
		groundFogData.Dispose();
		base.OnDestroy();
	}

	private void ShaderTexturesSystem_6A0878D7_LambdaJob_0_Execute(int minX, int maxX, int minZ, int maxZ, NativeArray<Color32> ignoreVertexOffset, BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, int widthLocal)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__DirectionCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		ShaderTexturesSystem_6A0878D7_LambdaJob_0_Job jobData = new ShaderTexturesSystem_6A0878D7_LambdaJob_0_Job
		{
			minX = minX,
			maxX = maxX,
			minZ = minZ,
			maxZ = maxZ,
			ignoreVertexOffset = ignoreVertexOffset,
			databaseLocal = databaseLocal,
			widthLocal = widthLocal,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle,
			__objectDataTypeHandle = __TypeHandle.__ObjectDataCD_RO_ComponentTypeHandle,
			__DirectionCD_ComponentLookup = __TypeHandle.__DirectionCD_RO_ComponentLookup
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1870338569_0, base.CheckedStateRef.Dependency);
	}

	private void ShaderTexturesSystem_6A0878D7_LambdaJob_1_Execute(int minX, int maxX, int minZ, int maxZ, NativeArray<Color32> electricityStrength, int widthLocal)
	{
		__TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		ShaderTexturesSystem_6A0878D7_LambdaJob_1_Job jobData = new ShaderTexturesSystem_6A0878D7_LambdaJob_1_Job
		{
			minX = minX,
			maxX = maxX,
			minZ = minZ,
			maxZ = maxZ,
			electricityStrength = electricityStrength,
			widthLocal = widthLocal,
			__electricityCDTypeHandle = __TypeHandle.__Pug_Automation_ElectricityCD_RO_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1870338569_1, base.CheckedStateRef.Dependency);
	}

	private void ShaderTexturesSystem_6A0878D7_LambdaJob_2_Execute(int minX, int maxX, int minZ, int maxZ, NativeArray<Color32> electricityStrength, int widthLocal)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__AncientElectricityConnectionCD_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		ShaderTexturesSystem_6A0878D7_LambdaJob_2_Job jobData = new ShaderTexturesSystem_6A0878D7_LambdaJob_2_Job
		{
			minX = minX,
			maxX = maxX,
			minZ = minZ,
			maxZ = maxZ,
			electricityStrength = electricityStrength,
			widthLocal = widthLocal,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__electricityConnectionCDTypeHandle = __TypeHandle.__AncientElectricityConnectionCD_RO_ComponentTypeHandle,
			__transformTypeHandle = __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1870338569_2, base.CheckedStateRef.Dependency);
	}

	private void ShaderTexturesSystem_6A0878D7_LambdaJob_3_Execute(NativeArray<bool> greatWallShouldOffsetVertices)
	{
		__TypeHandle.__TheGreatWallAnimationSystem_TheGreatWallanimationBuffer_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		ShaderTexturesSystem_6A0878D7_LambdaJob_3_Job jobData = new ShaderTexturesSystem_6A0878D7_LambdaJob_3_Job
		{
			greatWallShouldOffsetVertices = greatWallShouldOffsetVertices,
			__greatWallAnimationTypeHandle = __TypeHandle.__TheGreatWallAnimationSystem_TheGreatWallanimationBuffer_RO_ComponentTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_1870338569_3, base.CheckedStateRef.Dependency);
	}

	private void ShaderTexturesSystem_6A0878D7_LambdaJob_4_Execute(int minX, int maxX, int minZ, int maxZ, NativeArray<Color32> ignoreVertexOffset, Color32 blackLocal)
	{
		ShaderTexturesSystem_6A0878D7_LambdaJob_4_Job jobData = new ShaderTexturesSystem_6A0878D7_LambdaJob_4_Job
		{
			minX = minX,
			maxX = maxX,
			minZ = minZ,
			maxZ = maxZ,
			ignoreVertexOffset = ignoreVertexOffset,
			blackLocal = blackLocal
		};
		base.CheckedStateRef.Dependency = IJobExtensions.Schedule(jobData, base.CheckedStateRef.Dependency);
	}

	private void ShaderTexturesSystem_6A0878D7_LambdaJob_5_Execute(int minX, int maxX, int minZ, int maxZ, NativeArray<Color32> electricityStrength, Color32 blackLocal)
	{
		ShaderTexturesSystem_6A0878D7_LambdaJob_5_Job jobData = new ShaderTexturesSystem_6A0878D7_LambdaJob_5_Job
		{
			minX = minX,
			maxX = maxX,
			minZ = minZ,
			maxZ = maxZ,
			electricityStrength = electricityStrength,
			blackLocal = blackLocal
		};
		base.CheckedStateRef.Dependency = IJobExtensions.Schedule(jobData, base.CheckedStateRef.Dependency);
	}

	private void ShaderTexturesSystem_6A0878D7_LambdaJob_6_Execute(int minX, int maxX, int minZ, int maxZ, NativeArray<Color32> groundFogTint, NativeArray<Color32> ignoreVertexOffset, BlobAssetReference<PugDatabase.PugDatabaseBank> databaseLocal, NativeArray<bool> greatWallShouldOffsetVertices, SinglePugMap.TileLayerLookup tileLookup, NativeParallelHashMap<TileInfo, int> groundFogLookupLocal, NativeArray<GroundFogData> groundFogDataLocal)
	{
		__TypeHandle.__IgnoreVertexOffsetsCD_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		ShaderTexturesSystem_6A0878D7_LambdaJob_6_Job jobData = new ShaderTexturesSystem_6A0878D7_LambdaJob_6_Job
		{
			minX = minX,
			maxX = maxX,
			minZ = minZ,
			maxZ = maxZ,
			groundFogTint = groundFogTint,
			ignoreVertexOffset = ignoreVertexOffset,
			databaseLocal = databaseLocal,
			greatWallShouldOffsetVertices = greatWallShouldOffsetVertices,
			tileLookup = tileLookup,
			groundFogLookupLocal = groundFogLookupLocal,
			groundFogDataLocal = groundFogDataLocal,
			__IgnoreVertexOffsetsCD_ComponentLookup = __TypeHandle.__IgnoreVertexOffsetsCD_RO_ComponentLookup
		};
		base.CheckedStateRef.Dependency = IJobExtensions.Schedule(jobData, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<TileCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<IgnoreVertexOffsetsCD>();
		__query_1870338569_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ElectricityCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		__query_1870338569_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<AncientElectricityConnectionCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<LocalTransform>();
		__query_1870338569_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TheGreatWallAnimationSystem.TheGreatWallanimationBuffer>();
		__query_1870338569_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1870338569_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public ShaderTexturesSystem()
	{
	}
}
