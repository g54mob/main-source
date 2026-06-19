using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;
using UnityEngine;

namespace Pug.Conversion
{
	public class GhostPostConverter : PostConverter
	{
		public override bool CanRunInStagingWorld => false;

		public override void PostConvert(GameObject authoring)
		{
			GhostAuthoringComponent component = authoring.GetComponent<GhostAuthoringComponent>();
			if (component == null)
			{
				return;
			}
			BatchedArchetypeChangeECB batchedArchetypeChangeECB = new BatchedArchetypeChangeECB(base.EntityManager, Allocator.Temp);
			Entity entity = GetEntity(authoring);
			EntityManager entityManager = base.EntityManager;
			EntityQueryBuilder queriesDesc = new EntityQueryBuilder(Allocator.Temp);
			queriesDesc = queriesDesc.WithAll<GhostComponentSerializerCollectionData>();
			using EntityQuery entityQuery = entityManager.CreateEntityQuery(in queriesDesc);
			GhostComponentSerializerCollectionData singleton = entityQuery.GetSingleton<GhostComponentSerializerCollectionData>();
			GetGhostConfig(authoring, entity, out var config);
			if (component.HasOwner)
			{
				batchedArchetypeChangeECB.AddComponent(entity, new GhostOwner
				{
					NetworkId = -1
				});
				batchedArchetypeChangeECB.AddComponent<GhostOwnerIsLocal>(entity);
			}
			if (component.SupportAutoCommandTarget && component.HasOwner)
			{
				batchedArchetypeChangeECB.AddComponent(entity, new AutoCommandTarget
				{
					Enabled = true
				});
			}
			if (component.TrackInterpolationDelay && component.HasOwner)
			{
				batchedArchetypeChangeECB.AddComponent(entity, default(CommandDataInterpolationDelay));
			}
			if (component.GhostGroup)
			{
				batchedArchetypeChangeECB.AddBuffer<GhostGroup>(entity);
			}
			entityManager = base.EntityManager;
			if (!entityManager.HasBuffer<LinkedEntityGroup>(entity))
			{
				batchedArchetypeChangeECB.AddBuffer<LinkedEntityGroup>(entity);
			}
			GhostType ghostType = new GhostPrefabCreation.SHA1((FixedString128Bytes)("d998efe2a32054a4ab8e34ea9509d96d" + authoring.name)).ToGhostType();
			GetOverridesFromInspector(entity, component, out var overrides);
			NetcodeConversionTarget target = (base.IsServer ? NetcodeConversionTarget.Server : NetcodeConversionTarget.Client);
			GhostPrefabCreation.ConvertToGhostPrefab(batchedArchetypeChangeECB, entity, ghostType, target, config, singleton, base.BlobAssetStore, overrides);
			overrides.Dispose();
			batchedArchetypeChangeECB.Playback(base.EntityManager);
			batchedArchetypeChangeECB.Dispose();
		}

		private void GetOverridesFromInspector(Entity entity, GhostAuthoringComponent ghostAuthoring, out NativeParallelHashMap<GhostPrefabCreation.Component, GhostPrefabCreation.ComponentOverride> overrides)
		{
			List<(GameObject, GhostAuthoringInspectionComponent.ComponentOverride)> list = GhostAuthoringInspectionComponent.CollectAllComponentOverridesInInspectionComponents(ghostAuthoring, validate: true);
			overrides = new NativeParallelHashMap<GhostPrefabCreation.Component, GhostPrefabCreation.ComponentOverride>(list.Count, Allocator.Temp);
			DynamicBuffer<LinkedEntityGroup> buffer = base.EntityManager.GetBuffer<LinkedEntityGroup>(entity);
			foreach (var item in list)
			{
				bool flag = item.Item2.PrefabType != (GhostPrefabType)(-1);
				bool flag2 = item.Item2.SendTypeOptimization != (GhostSendType)(-1);
				bool flag3 = item.Item2.VariantHash != 0;
				GhostPrefabCreation.ComponentOverrideType componentOverrideType = GhostPrefabCreation.ComponentOverrideType.None;
				componentOverrideType = (GhostPrefabCreation.ComponentOverrideType)((int)componentOverrideType | (flag ? 1 : 0));
				componentOverrideType = (GhostPrefabCreation.ComponentOverrideType)((int)componentOverrideType | (flag2 ? 2 : 0));
				componentOverrideType = (GhostPrefabCreation.ComponentOverrideType)((int)componentOverrideType | (flag3 ? 8 : 0));
				Entity entity2 = GetEntity(item.Item1);
				if (entity2 == Entity.Null)
				{
					throw new Exception("Ghost componentOverride on a non converted entity");
				}
				int childIndex = 0;
				for (int i = 0; i < buffer.Length; i++)
				{
					if (!(buffer[i].Value != entity2))
					{
						childIndex = i;
						break;
					}
				}
				Type type = FindTypeFromFullTypeNameInAllAssemblies(item.Item2.FullTypeName);
				overrides.Add(new GhostPrefabCreation.Component
				{
					ComponentType = new ComponentType(type),
					ChildIndex = childIndex
				}, new GhostPrefabCreation.ComponentOverride
				{
					OverrideType = componentOverrideType,
					PrefabType = item.Item2.PrefabType,
					SendMask = item.Item2.SendTypeOptimization,
					Variant = item.Item2.VariantHash
				});
			}
		}

		private static Type FindTypeFromFullTypeNameInAllAssemblies(string fullName)
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				Type type = assemblies[i].GetType(fullName, throwOnError: false);
				if (type != null)
				{
					return type;
				}
			}
			return null;
		}
	}
}
