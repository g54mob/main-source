using System;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class CreateClientSubMapSystem : PugSimulationSystemBase
{
	public struct ClientSubMapReferenceBuffer : ICleanupBufferElementData, IBufferElementData
	{
		public TileCD layer;

		public Entity entity;
	}

	[NoAlias]
	[BurstCompile]
	private struct CreateClientSubMapSystem_2B9C76AB_LambdaJob_0_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		public Entity clientSubmapPrefabEntityLocal;

		public NativeArray<TileCD> defaultTilesLocal;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PlayerGhost> __playerTypeHandle;

		[ReadOnly]
		public ComponentLookup<NetworkId> __Unity_NetCode_NetworkId_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, [NoAlias] in PlayerGhost player)
		{
			if (__Unity_NetCode_NetworkId_ComponentLookup.HasComponent(player.connection))
			{
				DynamicBuffer<ClientSubMapReferenceBuffer> dynamicBuffer = ecb.AddBuffer<ClientSubMapReferenceBuffer>(entity);
				for (int i = 0; i < defaultTilesLocal.Length; i++)
				{
					ClientSubMapLayerCD component = new ClientSubMapLayerCD
					{
						layer = defaultTilesLocal[i]
					};
					Entity entity2 = ecb.Instantiate(clientSubmapPrefabEntityLocal);
					ecb.SetComponent(entity2, component);
					NetworkId networkId = __Unity_NetCode_NetworkId_ComponentLookup[player.connection];
					ecb.SetComponent(entity2, new OnlyRelevantForConnectionCD
					{
						networkId = networkId.Value
					});
					ecb.SetComponent(entity2, new GhostOwner
					{
						NetworkId = networkId.Value
					});
					dynamicBuffer.Add(new ClientSubMapReferenceBuffer
					{
						layer = defaultTilesLocal[i],
						entity = entity2
					});
				}
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __playerTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, l));
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
	private struct CreateClientSubMapSystem_2B9C76AB_LambdaJob_1_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public BufferTypeHandle<ClientSubMapReferenceBuffer> __clientRefBufferTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, DynamicBuffer<ClientSubMapReferenceBuffer> clientRefBuffer)
		{
			for (int i = 0; i < clientRefBuffer.Length; i++)
			{
				ecb.DestroyEntity(clientRefBuffer[i].entity);
			}
			ecb.RemoveComponent<ClientSubMapReferenceBuffer>(entity);
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			BufferAccessor<ClientSubMapReferenceBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __clientRefBufferTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), bufferAccessor[i]);
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), bufferAccessor[j]);
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), bufferAccessor[k]);
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), bufferAccessor[l]);
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
	private struct CreateClientSubMapSystem_2B9C76AB_LambdaJob_2_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		[ReadOnly]
		public NativeParallelHashMap<int2, Entity> subMapIndex;

		public Entity clientSubmapPrefabEntityLocal;

		[ReadOnly]
		public BufferLookup<SubMapLayerBuffer> submapLayerBufferLookup;

		public NativeArray<TileCD> defaultTilesLocal;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		public BufferTypeHandle<ClientSubMapReferenceBuffer> __subMapReferenceBufferTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PlayerGhost> __playerGhostTypeHandle;

		public ComponentLookup<ClientSubMapLayerCD> __ClientSubMapLayerCD_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<NetworkId> __Unity_NetCode_NetworkId_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity, DynamicBuffer<ClientSubMapReferenceBuffer> subMapReferenceBuffer, [NoAlias] in PlayerGhost playerGhost)
		{
			int2 int5 = 64;
			int2 int6 = new int2(64, 48);
			if (playerGhost.connection == Entity.Null)
			{
				return;
			}
			int2 int7 = playerGhost.cameraPosition.RoundToInt2();
			for (int i = 0; i < subMapReferenceBuffer.Length; i++)
			{
				ClientSubMapLayerCD value = __ClientSubMapLayerCD_ComponentLookup[subMapReferenceBuffer[i].entity];
				value.data.viewPoint = int7;
				value.data.Clear();
				Entity entity2 = subMapReferenceBuffer[i].entity;
				__ClientSubMapLayerCD_ComponentLookup[entity2] = value;
			}
			int2 int8 = int7 - int6 / 2;
			int2 int9 = int8 + (int6 - 1);
			int2 int10 = (int8 & -64) >> 6;
			int2 int11 = (int9 & -64) >> 6;
			NativeList<ClientSubMapLayerCD> layers = new NativeList<ClientSubMapLayerCD>(Allocator.Temp);
			for (int j = int10.x; j <= int11.x; j++)
			{
				for (int k = int10.y; k <= int11.y; k++)
				{
					int2 int12 = new int2(j, k);
					if (!subMapIndex.ContainsKey(int12))
					{
						continue;
					}
					int2 obj = int12 * int5;
					DynamicBuffer<SubMapLayer> dynamicBuffer = submapLayerBufferLookup[subMapIndex[int12]].Reinterpret<SubMapLayer>();
					int2 int13 = obj;
					int2 x = obj + int5 - 1;
					int2 intersectStart = math.max(int13, int8);
					int2 intersectEnd = math.min(x, int9);
					for (int l = 0; l < dynamicBuffer.Length; l++)
					{
						SubMapLayer srcLayer = dynamicBuffer[l];
						int m;
						for (m = 0; m < subMapReferenceBuffer.Length && !srcLayer.layer.Equals(subMapReferenceBuffer[m].layer); m++)
						{
						}
						ClientSubMapLayerCD value2;
						if (m == subMapReferenceBuffer.Length)
						{
							if (TryGetLayerIndex(layers, srcLayer.layer, out var index))
							{
								value2 = layers[index];
							}
							else
							{
								value2 = new ClientSubMapLayerCD
								{
									layer = srcLayer.layer,
									data = new ClientSubMapLayer
									{
										viewPoint = int7
									}
								};
								layers.Add(in value2);
							}
						}
						else
						{
							value2 = __ClientSubMapLayerCD_ComponentLookup[subMapReferenceBuffer[m].entity];
						}
						PackSrcIntoDest(intersectStart, intersectEnd, int13, int8, ref srcLayer, ref value2.data);
						if (m == subMapReferenceBuffer.Length)
						{
							if (TryGetLayerIndex(layers, srcLayer.layer, out var index2))
							{
								layers[index2] = value2;
							}
						}
						else
						{
							Entity entity3 = subMapReferenceBuffer[m].entity;
							__ClientSubMapLayerCD_ComponentLookup[entity3] = value2;
						}
					}
				}
			}
			for (int num = subMapReferenceBuffer.Length - 1 + layers.Length; num >= 0; num--)
			{
				ClientSubMapLayerCD clientSubMapLayerCD = ((num >= subMapReferenceBuffer.Length) ? layers[num - subMapReferenceBuffer.Length] : __ClientSubMapLayerCD_ComponentLookup[subMapReferenceBuffer[num].entity]);
				bool flag = IsEmpty(ref clientSubMapLayerCD.data);
				if (num < subMapReferenceBuffer.Length)
				{
					Entity entity4 = subMapReferenceBuffer[num].entity;
					__ClientSubMapLayerCD_ComponentLookup[entity4] = clientSubMapLayerCD;
					if (flag && num >= defaultTilesLocal.Length)
					{
						ecb.DestroyEntity(subMapReferenceBuffer[num].entity);
						subMapReferenceBuffer.RemoveAtSwapBack(num);
					}
				}
				else if (!flag)
				{
					layers[num - subMapReferenceBuffer.Length] = clientSubMapLayerCD;
					Entity entity5 = ecb.Instantiate(clientSubmapPrefabEntityLocal);
					ecb.SetComponent(entity5, clientSubMapLayerCD);
					NetworkId networkId = __Unity_NetCode_NetworkId_ComponentLookup[playerGhost.connection];
					ecb.SetComponent(entity5, new OnlyRelevantForConnectionCD
					{
						networkId = networkId.Value
					});
					ecb.SetComponent(entity5, new GhostOwner
					{
						NetworkId = networkId.Value
					});
					ecb.AppendToBuffer(entity, new ClientSubMapReferenceBuffer
					{
						layer = clientSubMapLayerCD.layer,
						entity = entity5
					});
				}
			}
			ClientSubMapLayerCD clientSubMapLayerCD2 = new ClientSubMapLayerCD
			{
				data = new ClientSubMapLayer
				{
					viewPoint = int7
				}
			};
			for (int n = 0; n < int6.y; n++)
			{
				clientSubMapLayerCD2.data.Row(n) = ulong.MaxValue;
			}
			for (int num2 = 0; num2 < subMapReferenceBuffer.Length; num2++)
			{
				ClientSubMapLayerCD clientSubMapLayerCD3 = __ClientSubMapLayerCD_ComponentLookup[subMapReferenceBuffer[num2].entity];
				for (int num3 = 0; num3 < int6.y; num3++)
				{
					clientSubMapLayerCD2.data.Row(num3) &= ~clientSubMapLayerCD3.data.Row(num3);
				}
			}
			for (int num4 = 0; num4 < layers.Length; num4++)
			{
				ClientSubMapLayerCD clientSubMapLayerCD4 = layers[num4];
				for (int num5 = 0; num5 < int6.y; num5++)
				{
					clientSubMapLayerCD2.data.Row(num5) &= ~clientSubMapLayerCD4.data.Row(num5);
				}
			}
			for (int num6 = 0; num6 < defaultTilesLocal.Length; num6++)
			{
				ClientSubMapLayerCD value3 = __ClientSubMapLayerCD_ComponentLookup[subMapReferenceBuffer[num6].entity];
				for (int num7 = 0; num7 < int6.y; num7++)
				{
					value3.data.Row(num7) |= clientSubMapLayerCD2.data.Row(num7);
				}
				Entity entity6 = subMapReferenceBuffer[num6].entity;
				__ClientSubMapLayerCD_ComponentLookup[entity6] = value3;
			}
			layers.Dispose();
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			BufferAccessor<ClientSubMapReferenceBuffer> bufferAccessor = chunk.GetBufferAccessor(ref __subMapReferenceBufferTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __playerGhostTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), bufferAccessor[i], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), bufferAccessor[j], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), bufferAccessor[k], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), bufferAccessor[l], in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<PlayerGhost>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<PlayerGhost> __PlayerGhost_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentLookup<NetworkId> __Unity_NetCode_NetworkId_RO_ComponentLookup;

		[ReadOnly]
		public BufferTypeHandle<ClientSubMapReferenceBuffer> __CreateClientSubMapSystem_ClientSubMapReferenceBuffer_RO_BufferTypeHandle;

		public BufferTypeHandle<ClientSubMapReferenceBuffer> __CreateClientSubMapSystem_ClientSubMapReferenceBuffer_RW_BufferTypeHandle;

		public ComponentLookup<ClientSubMapLayerCD> __ClientSubMapLayerCD_RW_ComponentLookup;

		[ReadOnly]
		public BufferLookup<SubMapLayerBuffer> __SubMapLayerBuffer_RO_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__PlayerGhost_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PlayerGhost>(isReadOnly: true);
			__Unity_NetCode_NetworkId_RO_ComponentLookup = state.GetComponentLookup<NetworkId>(isReadOnly: true);
			__CreateClientSubMapSystem_ClientSubMapReferenceBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ClientSubMapReferenceBuffer>(isReadOnly: true);
			__CreateClientSubMapSystem_ClientSubMapReferenceBuffer_RW_BufferTypeHandle = state.GetBufferTypeHandle<ClientSubMapReferenceBuffer>();
			__ClientSubMapLayerCD_RW_ComponentLookup = state.GetComponentLookup<ClientSubMapLayerCD>();
			__SubMapLayerBuffer_RO_BufferLookup = state.GetBufferLookup<SubMapLayerBuffer>(isReadOnly: true);
		}
	}

	private Entity clientSubmapPrefabEntity;

	private NativeArray<TileCD> defaultTiles;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_526967125_0;

	private EntityQuery __query_526967125_1;

	private EntityQuery __query_526967125_2;

	private EntityQuery __query_526967125_3;

	private EntityQuery __query_526967125_4;

	[Preserve]
	protected override void OnCreate()
	{
		if (Manager.saves.IsWorldModeEnabled(WorldMode.Creative) || Manager.sceneHandler.isDev)
		{
			defaultTiles = new NativeArray<TileCD>(0, Allocator.Persistent);
		}
		else
		{
			defaultTiles = new NativeArray<TileCD>(2, Allocator.Persistent);
			defaultTiles[0] = new TileCD
			{
				tileset = 2,
				tileType = TileType.ground
			};
			defaultTiles[1] = new TileCD
			{
				tileset = 2,
				tileType = TileType.wall
			};
		}
		RequireForUpdate<PugPrefabBuffer>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnDestroy()
	{
		defaultTiles.Dispose();
		base.OnDestroy();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		if (clientSubmapPrefabEntity != Entity.Null)
		{
			base.OnStartRunning();
			return;
		}
		DynamicBuffer<PugPrefabBuffer> singletonBuffer = __query_526967125_3.GetSingletonBuffer<PugPrefabBuffer>();
		for (int i = 0; i < singletonBuffer.Length; i++)
		{
			if (HasComponent<ClientSubMapLayerCD>(singletonBuffer[i].Value))
			{
				clientSubmapPrefabEntity = singletonBuffer[i].Value;
			}
		}
		if (clientSubmapPrefabEntity == Entity.Null)
		{
			Debug.LogError("No client submap prefab entity in pug prefab buffer");
			base.Enabled = false;
		}
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (!(clientSubmapPrefabEntity == Entity.Null))
		{
			EntityCommandBuffer ecb = CreateCommandBuffer();
			NativeParallelHashMap<int2, Entity> indexToEntity = __query_526967125_4.GetSingleton<SubMapRegistry>().IndexToEntity;
			Entity clientSubmapPrefabEntityLocal = clientSubmapPrefabEntity;
			BufferLookup<SubMapLayerBuffer> bufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SubMapLayerBuffer_RO_BufferLookup, ref base.CheckedStateRef);
			NativeArray<TileCD> defaultTilesLocal = defaultTiles;
			CreateClientSubMapSystem_2B9C76AB_LambdaJob_0_Execute(ecb, clientSubmapPrefabEntityLocal, defaultTilesLocal);
			CreateClientSubMapSystem_2B9C76AB_LambdaJob_1_Execute(ecb);
			CreateClientSubMapSystem_2B9C76AB_LambdaJob_2_Execute(ecb, indexToEntity, clientSubmapPrefabEntityLocal, bufferLookup, defaultTilesLocal);
			base.OnUpdate();
		}
	}

	private unsafe static bool TryGetLayerIndex(NativeList<ClientSubMapLayerCD> layers, TileCD tile, out int index)
	{
		ClientSubMapLayerCD* unsafeReadOnlyPtr = layers.GetUnsafeReadOnlyPtr();
		for (int i = 0; i < layers.Length; i++)
		{
			if (unsafeReadOnlyPtr[i].layer.Equals(tile))
			{
				index = i;
				return true;
			}
		}
		index = -1;
		return false;
	}

	private unsafe static void PackSrcIntoDest(int2 intersectStart, int2 intersectEnd, int2 sourceStart, int2 destStart, ref SubMapLayer srcLayer, ref ClientSubMapLayer dstLayer)
	{
		int num = destStart.x - sourceStart.x;
		ulong num2 = ((num >= 0) ? (ulong.MaxValue >> num) : ((ulong)(-1L << -num)));
		int num3 = intersectEnd.y - intersectStart.y + 1;
		Hint.Assume(num3 >= 0);
		Hint.Assume(num3 < 48);
		ulong* ptr = (ulong*)(srcLayer.bitfield.GetUnsafePtr() + (nint)intersectStart.y * (nint)8) - sourceStart.y;
		ulong* ptr2 = (ulong*)(dstLayer.bitfield.GetUnsafePtr() + (nint)intersectStart.y * (nint)8) - destStart.y;
		for (int i = 0; i < num3; i++)
		{
			ulong num4 = ptr[i];
			ulong num5 = ((num >= 0) ? (num4 >> num) : (num4 << -num));
			ptr2[i] |= num5 & num2;
		}
	}

	private static bool IsEmpty(ref ClientSubMapLayer layer)
	{
		for (int i = 0; i < 48; i++)
		{
			if (layer.Row(i) != 0L)
			{
				return false;
			}
		}
		return true;
	}

	private void CreateClientSubMapSystem_2B9C76AB_LambdaJob_0_Execute(EntityCommandBuffer ecb, Entity clientSubmapPrefabEntityLocal, NativeArray<TileCD> defaultTilesLocal)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerGhost_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_NetCode_NetworkId_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		CreateClientSubMapSystem_2B9C76AB_LambdaJob_0_Job jobData = new CreateClientSubMapSystem_2B9C76AB_LambdaJob_0_Job
		{
			ecb = ecb,
			clientSubmapPrefabEntityLocal = clientSubmapPrefabEntityLocal,
			defaultTilesLocal = defaultTilesLocal,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__playerTypeHandle = __TypeHandle.__PlayerGhost_RO_ComponentTypeHandle,
			__Unity_NetCode_NetworkId_ComponentLookup = __TypeHandle.__Unity_NetCode_NetworkId_RO_ComponentLookup
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_526967125_0, base.CheckedStateRef.Dependency);
	}

	private void CreateClientSubMapSystem_2B9C76AB_LambdaJob_1_Execute(EntityCommandBuffer ecb)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__CreateClientSubMapSystem_ClientSubMapReferenceBuffer_RO_BufferTypeHandle.Update(ref base.CheckedStateRef);
		CreateClientSubMapSystem_2B9C76AB_LambdaJob_1_Job jobData = new CreateClientSubMapSystem_2B9C76AB_LambdaJob_1_Job
		{
			ecb = ecb,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__clientRefBufferTypeHandle = __TypeHandle.__CreateClientSubMapSystem_ClientSubMapReferenceBuffer_RO_BufferTypeHandle
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_526967125_1, base.CheckedStateRef.Dependency);
	}

	private void CreateClientSubMapSystem_2B9C76AB_LambdaJob_2_Execute(EntityCommandBuffer ecb, NativeParallelHashMap<int2, Entity> subMapIndex, Entity clientSubmapPrefabEntityLocal, BufferLookup<SubMapLayerBuffer> submapLayerBufferLookup, NativeArray<TileCD> defaultTilesLocal)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__CreateClientSubMapSystem_ClientSubMapReferenceBuffer_RW_BufferTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__PlayerGhost_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__ClientSubMapLayerCD_RW_ComponentLookup.Update(ref base.CheckedStateRef);
		__TypeHandle.__Unity_NetCode_NetworkId_RO_ComponentLookup.Update(ref base.CheckedStateRef);
		CreateClientSubMapSystem_2B9C76AB_LambdaJob_2_Job jobData = new CreateClientSubMapSystem_2B9C76AB_LambdaJob_2_Job
		{
			ecb = ecb,
			subMapIndex = subMapIndex,
			clientSubmapPrefabEntityLocal = clientSubmapPrefabEntityLocal,
			submapLayerBufferLookup = submapLayerBufferLookup,
			defaultTilesLocal = defaultTilesLocal,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__subMapReferenceBufferTypeHandle = __TypeHandle.__CreateClientSubMapSystem_ClientSubMapReferenceBuffer_RW_BufferTypeHandle,
			__playerGhostTypeHandle = __TypeHandle.__PlayerGhost_RO_ComponentTypeHandle,
			__ClientSubMapLayerCD_ComponentLookup = __TypeHandle.__ClientSubMapLayerCD_RW_ComponentLookup,
			__Unity_NetCode_NetworkId_ComponentLookup = __TypeHandle.__Unity_NetCode_NetworkId_RO_ComponentLookup
		};
		base.CheckedStateRef.Dependency = InternalCompilerInterface.JobChunkInterface.Schedule(jobData, __query_526967125_2, base.CheckedStateRef.Dependency);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<ClientSubMapReferenceBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerGhost>();
		__query_526967125_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientSubMapReferenceBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<Disabled>();
		__query_526967125_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAllRW<ClientSubMapReferenceBuffer>();
		__query_526967125_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<PugPrefabBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_526967125_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<SubMapRegistry>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_526967125_4 = entityQueryBuilder2.Build(ref state);
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
	public CreateClientSubMapSystem()
	{
	}
}
