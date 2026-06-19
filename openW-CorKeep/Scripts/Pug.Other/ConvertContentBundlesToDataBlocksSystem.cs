using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using UnityEngine;

[DisableAutoCreation]
public struct ConvertContentBundlesToDataBlocksSystem : ISystem, ISystemCompilerGenerated
{
	private struct TypeHandle
	{
		public BufferLookup<ActivatedContentBundlesSerializedBuffer> __ActivatedContentBundlesSerializedBuffer_RW_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__ActivatedContentBundlesSerializedBuffer_RW_BufferLookup = state.GetBufferLookup<ActivatedContentBundlesSerializedBuffer>();
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1158046243_0;

	private EntityQuery __query_1158046243_1;

	public void OnUpdate(ref SystemState state)
	{
		state.Enabled = false;
		if (__query_1158046243_0.TryGetSingleton<WorldVersionSerializedCD>(out var value) && value.Version >= 11)
		{
			return;
		}
		Debug.Log($"World version is {value.Version} < 11, converting activated content bundles to data block addresses.");
		if (!__query_1158046243_1.TryGetSingletonBuffer(out DynamicBuffer<ActivatedContentBundlesSerializedBufferOld> value2, false))
		{
			Debug.Log("No activated content bundles to convert.");
			return;
		}
		Entity entity = state.EntityManager.CreateSingletonBuffer<ActivatedContentBundlesSerializedBuffer>();
		DynamicBuffer<ActivatedContentBundlesSerializedBuffer> bufferAfterCompletingDependency = InternalCompilerInterface.GetBufferAfterCompletingDependency(ref __TypeHandle.__ActivatedContentBundlesSerializedBuffer_RW_BufferLookup, ref state, entity);
		foreach (ActivatedContentBundlesSerializedBufferOld item in value2)
		{
			if (ContentBundleDataBlock.TryMapLegacyIDToDataBlockAddress(item.ContentBundle, out var address))
			{
				bufferAfterCompletingDependency.Add(new ActivatedContentBundlesSerializedBuffer
				{
					ContentBundle = address
				});
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldVersionSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1158046243_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ActivatedContentBundlesSerializedBufferOld>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1158046243_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((ConvertContentBundlesToDataBlocksSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ConvertContentBundlesToDataBlocksSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}
}
