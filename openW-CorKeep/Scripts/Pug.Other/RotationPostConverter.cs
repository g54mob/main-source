using Pug.Conversion;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;

public class RotationPostConverter : PostConverter
{
	public unsafe override void PostConvert(GameObject authoring)
	{
		if (!PostConverter.TryGetActiveComponent<RotationAuthoring>(authoring, out var component) || !component.rotatePhysics)
		{
			return;
		}
		Entity entity = GetEntity(authoring);
		if (!base.EntityManager.HasComponent<PhysicsCollider>(entity))
		{
			Debug.LogWarning($"{authoring} has RotationAuthoring.rotatePhysics set to true, but no collider is present.");
			return;
		}
		int2 prefabTileSize;
		int2 prefabOffset;
		if (PostConverter.TryGetActiveComponent<EntityMonoBehaviourData>(authoring, out var component2))
		{
			prefabTileSize = component2.objectInfo.prefabTileSize.ToInt2();
			prefabOffset = component2.objectInfo.prefabCornerOffset.ToInt2();
		}
		else
		{
			if (!PostConverter.TryGetActiveComponent<PlaceableObjectAuthoring>(authoring, out var component3))
			{
				Debug.LogError(string.Format("Cannot create rotated colliders for {0} with no {1}/{2} component.", authoring, "EntityMonoBehaviourData", "ObjectAuthoring"));
				return;
			}
			prefabTileSize = component3.prefabTileSize.ToInt2();
			prefabOffset = component3.prefabCornerOffset.ToInt2();
		}
		PhysicsCollider componentData = base.EntityManager.GetComponentData<PhysicsCollider>(entity);
		DynamicBuffer<PhysicsRotations> dynamicBuffer = base.EntityManager.AddBuffer<PhysicsRotations>(entity);
		PhysicsCollider physicsCollider = componentData;
		int num = 2;
		for (int i = 0; i < 4; i++)
		{
			Unity.Physics.Collider* colliderPtr = componentData.ColliderPtr;
			if (physicsCollider.Value.Value.Type == ColliderType.Compound)
			{
				CompoundCollider* ptr = (CompoundCollider*)colliderPtr;
				NativeArray<CompoundCollider.ColliderBlobInstance> children = new NativeArray<CompoundCollider.ColliderBlobInstance>(ptr->NumChildren, Allocator.Temp);
				for (int j = 0; j < ptr->NumChildren; j++)
				{
					BlobAssetReference<Unity.Physics.Collider> blobAsset = CreateRotatedCollider(ptr->Children[j].Collider, num, prefabTileSize, prefabOffset);
					base.BlobAssetStore.TryAdd(ref blobAsset);
					children[j] = new CompoundCollider.ColliderBlobInstance
					{
						Collider = blobAsset,
						CompoundFromChild = ptr->Children[j].CompoundFromChild,
						Entity = ptr->Children[j].Entity
					};
				}
				BlobAssetReference<Unity.Physics.Collider> blobAsset2 = CompoundCollider.Create(children);
				base.BlobAssetStore.TryAdd(ref blobAsset2);
				dynamicBuffer.Add(new PhysicsRotations
				{
					Value = blobAsset2
				});
				children.Dispose();
			}
			else
			{
				BlobAssetReference<Unity.Physics.Collider> blobAsset3 = CreateRotatedCollider(colliderPtr, num, prefabTileSize, prefabOffset);
				base.BlobAssetStore.TryAdd(ref blobAsset3);
				dynamicBuffer.Add(new PhysicsRotations
				{
					Value = blobAsset3
				});
			}
			num = (num + 1) % 4;
		}
	}

	private unsafe BlobAssetReference<Unity.Physics.Collider> CreateRotatedCollider(Unity.Physics.Collider* colliderPtr, int rotationIndex, int2 prefabTileSize, int2 prefabOffset)
	{
		ColliderType type = colliderPtr->Type;
		quaternion newOrientation2;
		switch (type)
		{
		case ColliderType.Sphere:
		{
			SphereGeometry geometry4 = ((Unity.Physics.SphereCollider*)colliderPtr)->Geometry;
			DirectionCD.RotateTransform(quaternion.identity, geometry4.Center, rotationIndex, prefabOffset, prefabTileSize, out newOrientation2, out var newTranslation5);
			return Unity.Physics.SphereCollider.Create(new SphereGeometry
			{
				Center = newTranslation5,
				Radius = ((Unity.Physics.SphereCollider*)colliderPtr)->Radius
			}, ((Unity.Physics.SphereCollider*)colliderPtr)->GetCollisionFilter(), ((Unity.Physics.SphereCollider*)colliderPtr)->Material);
		}
		case ColliderType.Cylinder:
		{
			CylinderGeometry geometry3 = ((CylinderCollider*)colliderPtr)->Geometry;
			DirectionCD.RotateTransform(geometry3.Orientation, geometry3.Center, rotationIndex, prefabOffset, prefabTileSize, out var newOrientation3, out var newTranslation4);
			return CylinderCollider.Create(new CylinderGeometry
			{
				Center = newTranslation4,
				Radius = ((CylinderCollider*)colliderPtr)->Radius,
				Height = ((CylinderCollider*)colliderPtr)->Height,
				Orientation = newOrientation3,
				BevelRadius = ((CylinderCollider*)colliderPtr)->BevelRadius,
				SideCount = ((CylinderCollider*)colliderPtr)->SideCount
			}, ((CylinderCollider*)colliderPtr)->GetCollisionFilter(), ((CylinderCollider*)colliderPtr)->Material);
		}
		case ColliderType.Capsule:
		{
			CapsuleGeometry geometry2 = ((Unity.Physics.CapsuleCollider*)colliderPtr)->Geometry;
			DirectionCD.RotateTransform(quaternion.identity, geometry2.Vertex0, rotationIndex, prefabOffset, prefabTileSize, out newOrientation2, out var newTranslation2);
			DirectionCD.RotateTransform(quaternion.identity, geometry2.Vertex1, rotationIndex, prefabOffset, prefabTileSize, out newOrientation2, out var newTranslation3);
			return Unity.Physics.CapsuleCollider.Create(new CapsuleGeometry
			{
				Radius = ((Unity.Physics.CapsuleCollider*)colliderPtr)->Radius,
				Vertex0 = newTranslation2,
				Vertex1 = newTranslation3
			}, ((Unity.Physics.CapsuleCollider*)colliderPtr)->GetCollisionFilter(), ((Unity.Physics.CapsuleCollider*)colliderPtr)->Material);
		}
		case ColliderType.Box:
		{
			BoxGeometry geometry = ((Unity.Physics.BoxCollider*)colliderPtr)->Geometry;
			DirectionCD.RotateTransform(geometry.Orientation, geometry.Center, rotationIndex, prefabOffset, prefabTileSize, out var newOrientation, out var newTranslation);
			return Unity.Physics.BoxCollider.Create(new BoxGeometry
			{
				Center = newTranslation,
				Orientation = newOrientation,
				Size = ((Unity.Physics.BoxCollider*)colliderPtr)->Size,
				BevelRadius = ((Unity.Physics.BoxCollider*)colliderPtr)->BevelRadius
			}, ((Unity.Physics.BoxCollider*)colliderPtr)->GetCollisionFilter(), ((Unity.Physics.BoxCollider*)colliderPtr)->Material);
		}
		default:
			Debug.LogError("Does not support rotating collider type " + type);
			return BlobAssetReference<Unity.Physics.Collider>.Null;
		}
	}
}
