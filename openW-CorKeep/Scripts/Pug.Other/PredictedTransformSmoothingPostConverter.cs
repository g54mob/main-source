using Pug.Conversion;
using Unity.Entities;
using Unity.NetCode;
using Unity.Physics.GraphicsIntegration;
using Unity.Transforms;
using UnityEngine;

public class PredictedTransformSmoothingPostConverter : PostConverter
{
	public override void PostConvert(GameObject authoring)
	{
		if (!(authoring.GetComponent<GhostAuthoringComponent>() == null))
		{
			Entity entity = GetEntity(authoring);
			if (base.EntityManager.HasComponent<LocalTransform>(entity))
			{
				base.EntityManager.AddComponentData(entity, new PredictedLocalTransformSmoothingCD
				{
					physicsTicksToInterpolate = 1
				});
				base.EntityManager.AddComponent<InitializedPredictedSmoothedPositionTagCD>(entity);
				base.EntityManager.SetComponentEnabled<InitializedPredictedSmoothedPositionTagCD>(entity, value: false);
			}
		}
	}
}
