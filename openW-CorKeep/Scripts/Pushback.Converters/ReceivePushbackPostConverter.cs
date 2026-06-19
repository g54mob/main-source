using Pug.Conversion;
using Unity.Entities;
using Unity.Physics;
using UnityEngine;

public class ReceivePushbackPostConverter : PostConverter
{
	public override void PostConvert(GameObject authoring)
	{
		Entity entity = GetEntity(authoring);
		if (base.EntityManager.HasComponent<PhysicsVelocity>(entity) && (base.EntityManager.HasComponent<HealthCD>(entity) || base.EntityManager.HasComponent<PetCD>(entity)))
		{
			base.EntityManager.AddComponentData(entity, default(ReceivedPushbackCD));
		}
	}
}
