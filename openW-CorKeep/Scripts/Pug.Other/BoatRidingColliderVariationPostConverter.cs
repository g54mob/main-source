using PlayerState;
using Pug.Conversion;
using Unity.Entities;
using Unity.Physics;
using UnityEngine;

public class BoatRidingColliderVariationPostConverter : PostConverter
{
	public override void PostConvert(GameObject authoring)
	{
		Entity entity = GetEntity(authoring);
		if (base.EntityManager.HasComponent<BoatRidingStateCD>(entity) && base.EntityManager.HasComponent<PhysicsCollider>(entity))
		{
			if (PostConverter.TryGetActiveComponent<RotationAuthoring>(authoring, out var _))
			{
				Debug.LogError("Does not support both RotationAuthoring and BoatRidingCD on the same entity.");
				return;
			}
			PhysicsCollider componentData = base.EntityManager.GetComponentData<PhysicsCollider>(entity);
			BlobAssetReference<Unity.Physics.Collider> value = componentData.Value;
			CollisionFilter collisionFilter = value.Value.GetCollisionFilter();
			CollisionFilter collisionFilter2 = collisionFilter;
			collisionFilter2.CollidesWith &= 4294836223u;
			collisionFilter2.CollidesWith |= 262144u;
			value.Value.SetCollisionFilter(collisionFilter2);
			BlobAssetReference<Unity.Physics.Collider> blobAsset = value.Value.Clone();
			base.BlobAssetStore.TryAdd(ref blobAsset);
			value.Value.SetCollisionFilter(collisionFilter);
			PlayerColliderCD componentData2 = base.EntityManager.GetComponentData<PlayerColliderCD>(entity);
			componentData2.boatRidingCollider = blobAsset;
			componentData2.defaultCollider = componentData.Value;
			base.EntityManager.SetComponentData(entity, componentData2);
		}
	}
}
