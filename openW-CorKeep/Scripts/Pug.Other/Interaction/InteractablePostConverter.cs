using System;
using System.Collections.Generic;
using Pug.Conversion;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Interaction
{
	public class InteractablePostConverter : PostConverter
	{
		public override void PostConvert(GameObject authoring)
		{
			EntityMonoBehaviourData component = authoring.GetComponent<EntityMonoBehaviourData>();
			Entity entity = GetEntity(authoring);
			if (!base.EntityManager.HasComponent<TriggerUseInteractionBuffer>(entity) && !base.EntityManager.HasComponent<TriggerExitInteractionBuffer>(entity))
			{
				return;
			}
			ObjectInfo objectInfo = ((component != null) ? component.objectInfo : null);
			List<PrefabInfo> list = objectInfo?.prefabInfos;
			PrefabInfo prefabInfo = null;
			InteractableObject[] array = null;
			if (list == null)
			{
				ObjectAuthoring component2 = authoring.GetComponent<ObjectAuthoring>();
				if (component2 != null && component2.graphicalPrefab != null)
				{
					array = component2.graphicalPrefab.GetComponentsInChildren<InteractableObject>(includeInactive: true);
					PlaceableObjectAuthoring component3 = authoring.GetComponent<PlaceableObjectAuthoring>();
					objectInfo = new ObjectInfo
					{
						prefabTileSize = ((component3 != null) ? component3.prefabTileSize : Vector2Int.one),
						prefabCornerOffset = ((component3 != null) ? component3.prefabCornerOffset : Vector2Int.zero)
					};
					prefabInfo = new PrefabInfo
					{
						ecsPrefab = authoring,
						prefab = component2.graphicalPrefab.GetComponent<MonoBehaviour>()
					};
				}
			}
			else
			{
				array = list[0].prefab.GetComponentsInChildren<InteractableObject>(includeInactive: true);
				prefabInfo = list[0];
			}
			InteractableObject interactableObject = array[0];
			FourDirectionFloat2 fourDirectionFloat = default(FourDirectionFloat2);
			for (int i = 0; i < 4; i++)
			{
				int2 direction = Direction.allFourClockwise[i].f3.RoundToInt2();
				DirectionCD.RotateTransform(interactableObject.transform.rotation, interactableObject.transform.position, DirectionBasedOnVariationCD.GetVariationFromDirection(direction), objectInfo.prefabCornerOffset.ToInt2(), objectInfo.prefabTileSize.ToInt2(), out var _, out var newTranslation);
				fourDirectionFloat.SetDataInDirection(Direction.allFourClockwise[i].id, newTranslation.ToFloat2());
			}
			BlobAssetReference<InteractablePointOffsetsData> blobAsset = CreateInteractablePointsBlob(prefabInfo.prefab.gameObject, interactableObject, fourDirectionFloat, objectInfo);
			base.BlobAssetStore.TryAdd(ref blobAsset);
			InteractableData data = new InteractableData
			{
				interactRadiusSqr = interactableObject.radius * interactableObject.radius,
				requiredFactionToInteract = interactableObject.requiredFactionToInteract,
				allowToUseOnlyWhenClaimed = interactableObject.allowToUseOnlyWhenClaimed,
				weightMultiplier = interactableObject.weightMultiplier,
				directionOffset = fourDirectionFloat,
				ignorePlayerDirection = interactableObject.ignorePlayerDirection
			};
			BlobAssetReference<InteractableData> interactableData = CreateAndAddBlobAsset(data, 128);
			base.EntityManager.AddComponentData(entity, new InteractableCD
			{
				interactablePointOffsetsData = blobAsset,
				interactableData = interactableData
			});
			base.EntityManager.AddComponentData(entity, default(InteractableObjectReferenceCD));
			base.EntityManager.AddComponentData(entity, default(IsClosestLocalInteractableCD));
			base.EntityManager.SetComponentEnabled<IsClosestLocalInteractableCD>(entity, value: false);
		}

		private BlobAssetReference<T> CreateAndAddBlobAsset<T>(T data, int chunkSize = 65536) where T : unmanaged
		{
			using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp, chunkSize);
			blobBuilder.ConstructRoot<T>() = data;
			BlobAssetReference<T> blobAsset = blobBuilder.CreateBlobAssetReference<T>(Allocator.Persistent);
			base.BlobAssetStore.TryAdd(ref blobAsset);
			return blobAsset;
		}

		private BlobAssetReference<InteractablePointOffsetsData> CreateInteractablePointsBlob(GameObject visualPrefab, InteractableObject interactableObject, FourDirectionFloat2 interactionPointOffset, ObjectInfo objectInfo)
		{
			OffsetFromEntityDirectionOrVariation[] offsetComp = Array.Empty<OffsetFromEntityDirectionOrVariation>();
			BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp, 512);
			ref InteractablePointOffsetsData reference = ref blobBuilder.ConstructRoot<InteractablePointOffsetsData>();
			int count = interactableObject.interactingPoints.Count;
			BlobBuilderArray<InteractablePointsOffsetsInDirection> pointsByDirection = blobBuilder.Allocate(ref reference.pointOffsets, Direction.allFourClockwise.Length);
			for (int i = 0; i < Direction.allFourClockwise.Length; i++)
			{
				AddInteractablePointsByDirection(ref blobBuilder, ref pointsByDirection, count, interactableObject, i, offsetComp, interactionPointOffset, objectInfo);
			}
			BlobAssetReference<InteractablePointOffsetsData> result = blobBuilder.CreateBlobAssetReference<InteractablePointOffsetsData>(Allocator.Persistent);
			blobBuilder.Dispose();
			return result;
		}

		private void AddInteractablePointsByDirection(ref BlobBuilder blobBuilder, ref BlobBuilderArray<InteractablePointsOffsetsInDirection> pointsByDirection, int validPoints, InteractableObject interactableObject, int directionIndex, OffsetFromEntityDirectionOrVariation[] offsetComp, FourDirectionFloat2 interactionPointOffset, ObjectInfo objectInfo)
		{
			BlobBuilderArray<float3> blobBuilderArray = blobBuilder.Allocate(ref pointsByDirection[directionIndex].values, (validPoints <= 0) ? 1 : validPoints);
			Direction direction = Direction.allFourClockwise[directionIndex];
			int2 direction2 = direction.f3.RoundToInt2();
			if (validPoints > 0)
			{
				for (int i = 0; i < interactableObject.interactingPoints.Count; i++)
				{
					Transform transform = interactableObject.interactingPoints[i];
					DirectionCD.RotateTransform(transform.rotation, transform.position, DirectionBasedOnVariationCD.GetVariationFromDirection(direction2), objectInfo.prefabCornerOffset.ToInt2(), objectInfo.prefabTileSize.ToInt2(), out var _, out var newTranslation);
					blobBuilderArray[i] = newTranslation - interactionPointOffset.GetDataInDirection(direction.id, float2.zero).ToFloat3();
				}
			}
		}
	}
}
