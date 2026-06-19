using Pug.Conversion;
using Unity.Entities;
using UnityEngine;

public class DisablePhysicsRestoreConverter : PostConverter
{
	public override void PostConvert(GameObject authoring)
	{
		Entity entity = GetEntity(authoring);
		if (base.EntityManager.HasComponent<DisablePhysicsCD>(entity) || base.EntityManager.HasComponent<EntityDestroyedCD>(entity))
		{
			base.EntityManager.AddComponentData(entity, default(DisablePhysicsRestoreCD));
		}
	}
}
