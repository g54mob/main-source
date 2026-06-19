using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using PugWorldGen;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

[DisableAutoCreation]
public struct UpdateExplodingWallThresholdSystem : ISystem, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct TypeHandle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_899421278_0;

	private EntityQuery __query_899421278_1;

	public void OnUpdate(ref SystemState state)
	{
		state.Enabled = false;
		if (__query_899421278_0.TryGetSingleton<WorldVersionSerializedCD>(out var value) && value.Version >= 5)
		{
			return;
		}
		Debug.Log($"World version is {value.Version} < 5, updating explosive wall thresholds to new defaults");
		if (!__query_899421278_1.TryGetSingletonEntity<WorldGenerationParametersSerializedCD>(out var value2))
		{
			Debug.Log("No serialized parameters found, most likely classic world. Skipping explosive wall threshold update.");
			return;
		}
		WorldGenerationParametersSerializedCD componentData = state.EntityManager.GetComponentData<WorldGenerationParametersSerializedCD>(value2);
		if (!componentData.PackedJsonData.IsCreated)
		{
			Debug.Log("Serialized parameters are not populated, most likely classic world. Skipping explosive wall threshold update.");
			return;
		}
		List<LevelWorldGenerationSetting> worldGenerationSettings = Manager.saves.GetWorldInfo().worldGenerationSettings;
		CoreKeeperWorldParameters coreKeeperWorldParameters = UnityEngine.Object.Instantiate(Manager.worldGen.defaultWorldParameters);
		CoreKeeperGenerationSettings.ApplyToParameters(worldGenerationSettings, coreKeeperWorldParameters);
		float explosiveWallAmount = coreKeeperWorldParameters.dirt.explosiveWallAmount;
		float explosiveWallAmount2 = coreKeeperWorldParameters.clay.explosiveWallAmount;
		float explosiveWallAmount3 = coreKeeperWorldParameters.stone.explosiveWallAmount;
		float explosiveWallAmount4 = coreKeeperWorldParameters.forest.explosiveWallAmount;
		float explosiveWallAmount5 = coreKeeperWorldParameters.sea.explosiveWallAmount;
		float explosiveWallAmount6 = coreKeeperWorldParameters.desert.explosiveWallAmount;
		float explosiveWallAmount7 = coreKeeperWorldParameters.crystal.explosiveWallAmount;
		float explosiveWallAmount8 = coreKeeperWorldParameters.passage.explosiveWallAmount;
		JsonUtility.FromJsonOverwrite(BlobByteArray.DataToString(componentData.PackedJsonData), coreKeeperWorldParameters);
		OverwriteIfZero(ref coreKeeperWorldParameters.dirt.explosiveWallAmount, explosiveWallAmount);
		OverwriteIfZero(ref coreKeeperWorldParameters.clay.explosiveWallAmount, explosiveWallAmount2);
		OverwriteIfZero(ref coreKeeperWorldParameters.stone.explosiveWallAmount, explosiveWallAmount3);
		OverwriteIfZero(ref coreKeeperWorldParameters.forest.explosiveWallAmount, explosiveWallAmount4);
		OverwriteIfZero(ref coreKeeperWorldParameters.sea.explosiveWallAmount, explosiveWallAmount5);
		OverwriteIfZero(ref coreKeeperWorldParameters.desert.explosiveWallAmount, explosiveWallAmount6);
		OverwriteIfZero(ref coreKeeperWorldParameters.crystal.explosiveWallAmount, explosiveWallAmount7);
		OverwriteIfZero(ref coreKeeperWorldParameters.passage.explosiveWallAmount, explosiveWallAmount8);
		componentData.PackedJsonData = BlobByteArray.CreateFromString(JsonUtility.ToJson(coreKeeperWorldParameters));
		state.EntityManager.SetComponentData(value2, componentData);
		UnityEngine.Object.Destroy(coreKeeperWorldParameters);
	}

	private static void OverwriteIfZero(ref float oldValue, float newValue)
	{
		oldValue = ((oldValue == 0f) ? newValue : oldValue);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldVersionSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_899421278_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationParametersSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_899421278_1 = entityQueryBuilder2.Build(ref state);
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
		((UpdateExplodingWallThresholdSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((UpdateExplodingWallThresholdSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}
}
