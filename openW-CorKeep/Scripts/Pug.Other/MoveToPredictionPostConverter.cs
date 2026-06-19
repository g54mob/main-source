using Pug.Conversion;
using Unity.Entities;
using Unity.NetCode;
using UnityEngine;

public class MoveToPredictionPostConverter : PostConverter
{
	public override void PostConvert(GameObject authoring)
	{
		if (authoring.GetComponent<GhostAuthoringComponent>() == null)
		{
			return;
		}
		Entity entity = GetEntity(authoring);
		if (!base.IsServer)
		{
			GetGhostConfig(authoring, entity, out var config);
			base.EntityManager.AddComponent<GhostLocalSpawnTickCD>(entity);
			base.EntityManager.AddComponent<MoveToPredictedByCombatOrInventoryInteractionCD>(entity);
			base.EntityManager.AddComponent<MoveToPredictedByEntityDestroyedCD>(entity);
			base.EntityManager.AddComponent<MoveToPredictedByPushbackCD>(entity);
			if (config.OptimizationMode == GhostOptimizationMode.Static)
			{
				base.EntityManager.AddComponent<StaticGhostChangeCD>(entity);
				base.EntityManager.SetComponentEnabled<StaticGhostChangeCD>(entity, value: false);
			}
		}
	}
}
