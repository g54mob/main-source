using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct HatchWhenPlayerNearbyStateRequest : IStateRequester
{
	private const float SQR_DISTANCE_TO_PLAYER_TO_START_HATCH = 25f;

	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._hatchWhenPlayerNearbyStateGroup.HasComponent(entity) && c._objectDataGroup.HasComponent(entity) && c._localTransformGroup.HasComponent(entity))
		{
			return c._factionGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.HatchWhenPlayerNearby))
		{
			return;
		}
		HatchWhenPlayerNearbyStateCD value = c._hatchWhenPlayerNearbyStateGroup[entity];
		FactionCD factionCD = c._factionGroup[entity];
		ObjectDataCD objectDataCD = c._objectDataGroup[entity];
		LocalTransform localTransform = c._localTransformGroup[entity];
		if (value.internalState == 3 || objectDataCD.amount == 100)
		{
			value.hatchAnimationIsPlaying = false;
			stateInfo.EnterState(StateID.HatchWhenPlayerNearby);
		}
		else
		{
			for (int i = 0; i < d.playerEntities.Length; i++)
			{
				Entity entity2 = d.playerEntities[i];
				FactionCD targetFaction = c._factionGroup[entity2];
				if (factionCD.CanAttack(targetFaction, d.worldInfo) && math.distancesq(c._localTransformGroup[entity].Position, localTransform.Position) < 25f)
				{
					value.timer.Stop();
					value.internalState = 0;
					stateInfo.EnterState(StateID.HatchWhenPlayerNearby);
					break;
				}
			}
		}
		c._hatchWhenPlayerNearbyStateGroup[entity] = value;
	}
}
