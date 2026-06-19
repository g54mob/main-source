using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public class BiomeRangesInitializeSystem : SystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct TypeHandle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
		}
	}

	private uint seed = 3024937327u;

	private EntityQuery paramQ;

	private readonly int biomeStartsShaderID = Shader.PropertyToID("biomeStarts");

	private readonly int biomeEndsShaderID = Shader.PropertyToID("biomeEnds");

	private readonly int biomeStartAnglesShaderID = Shader.PropertyToID("biomeStartAngles");

	private readonly int biomeEndAnglesShaderID = Shader.PropertyToID("biomeEndAngles");

	private EntityQuery _biomeSamplesQuery;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_291357970_0;

	private EntityQuery __query_291357970_1;

	private EntityQuery __query_291357970_2;

	[Preserve]
	protected override void OnCreate()
	{
		RequireForUpdate<ServerSeedCD>();
		if (base.World.IsServer())
		{
			RequireForUpdate<WorldGenerationTypeCD>();
		}
		paramQ = GetEntityQuery(typeof(BiomeParametersCD));
		RequireForUpdate(paramQ);
		_biomeSamplesQuery = GetEntityQuery(ComponentType.ReadOnly<BiomeSamplesCD>());
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (base.World.IsServer() && __query_291357970_0.GetSingleton<WorldGenerationTypeCD>().Value == WorldGenerationType.FullRelease && _biomeSamplesQuery.IsEmpty)
		{
			return;
		}
		NativeArray<BiomeParametersCD> nativeArray = paramQ.ToComponentDataArray<BiomeParametersCD>(Allocator.Temp);
		BiomeRangesCD componentData = default(BiomeRangesCD);
		NativeArray<int2> centroids = new NativeArray<int2>(12, Allocator.Persistent);
		ServerSeedCD singleton = __query_291357970_1.GetSingleton<ServerSeedCD>();
		componentData.Value.Length = 12;
		List<float> list = new List<float>();
		List<float> list2 = new List<float>();
		List<float> list3 = new List<float>();
		List<float> list4 = new List<float>();
		for (int i = 0; i < 75; i++)
		{
			list.Add(0f);
			list2.Add(0f);
			list3.Add(0f);
			list4.Add(0f);
		}
		for (int j = 0; j < nativeArray.Length; j++)
		{
			Unity.Mathematics.Random random = Unity.Mathematics.Random.CreateFromIndex(singleton.Value ^ (seed + nativeArray[j].ringLayerIndex));
			int biome = (int)nativeArray[j].Value.biome;
			float num = random.NextFloat(10f, 350f);
			for (float num2 = num; num2 < 720f; num2 += nativeArray[j].Value.angleWitdhPerBiome)
			{
				if (num2 < 10f || (num2 > 350f && num2 < 370f) || num2 > 710f)
				{
					num += 20f;
					break;
				}
			}
			BiomeRanges biomeRangesFromParameters = BiomesTable.GetBiomeRangesFromParameters(nativeArray[j].Value, num);
			componentData.Value[biome] = biomeRangesFromParameters;
			if (biomeRangesFromParameters.start < float.Epsilon)
			{
				centroids[biome] = int2.zero;
			}
			else
			{
				float num3 = (float.IsPositiveInfinity(biomeRangesFromParameters.end) ? (biomeRangesFromParameters.start * 1.5f) : ((biomeRangesFromParameters.start + biomeRangesFromParameters.end) / 2f));
				centroids[biome] = (BiomeRanges.GetDirectionToMiddleOfBiome(biomeRangesFromParameters) * num3).RoundToInt2();
			}
			list[biome] = componentData.Value[biome].shaderStart;
			list2[biome] = componentData.Value[biome].shaderEnd;
			list3[biome] = componentData.Value[biome].startAngle;
			list4[biome] = componentData.Value[biome].endAngle;
		}
		Entity entity = base.EntityManager.CreateEntity(typeof(BiomeRangesCD));
		base.EntityManager.SetComponentData(entity, componentData);
		base.EntityManager.DestroyEntity(paramQ);
		if (!__query_291357970_2.HasSingleton<BiomeCentroidsCD>() && base.World.IsServer())
		{
			Entity entity2 = base.EntityManager.CreateEntity(typeof(BiomeCentroidsCD));
			base.EntityManager.SetComponentData(entity2, new BiomeCentroidsCD
			{
				Centroids = centroids
			});
		}
		else
		{
			centroids.Dispose();
		}
		Shader.SetGlobalFloatArray(biomeStartsShaderID, list);
		Shader.SetGlobalFloatArray(biomeEndsShaderID, list2);
		Shader.SetGlobalFloatArray(biomeStartAnglesShaderID, list3);
		Shader.SetGlobalFloatArray(biomeEndAnglesShaderID, list4);
		base.Enabled = false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_291357970_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerSeedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_291357970_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeCentroidsCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_291357970_2 = entityQueryBuilder2.Build(ref state);
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
	public BiomeRangesInitializeSystem()
	{
	}
}
