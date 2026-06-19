using Pug.Conversion;
using Unity.Entities;
using UnityEngine;

public class EntityDestroyedConverter : Converter
{
	private const float BossDestroyTime = 10f;

	private const float ExplosionDestroyTime = 2f;

	private const float SnakeDestroyTime = 4f;

	public override void Convert(GameObject authoring)
	{
		if (authoring.TryGetComponent<EntityMonoBehaviourData>(out var _) || authoring.TryGetComponent<ObjectAuthoring>(out var _))
		{
			float seconds = 2f;
			ExplosionAuthoring component4;
			SnakeMovementStateAuthoring component5;
			if (authoring.TryGetComponent<BossAuthoring>(out var _))
			{
				seconds = 10f;
			}
			else if (authoring.TryGetComponent<ExplosionAuthoring>(out component4))
			{
				seconds = 2f;
			}
			else if (authoring.TryGetComponent<SnakeMovementStateAuthoring>(out component5))
			{
				seconds = 4f;
			}
			Entity primaryEntity = base.PrimaryEntity;
			uint simulationTickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
			AddComponentData(primaryEntity, new EntityDestroyedCD
			{
				destroyTimer = new TickTimer(seconds, simulationTickRate)
			}, componentIsEnabled: false);
		}
	}
}
