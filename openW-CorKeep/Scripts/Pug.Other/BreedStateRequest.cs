using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct BreedStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._breedStateGroup.HasComponent(entity) && c._mealsEatenGroup.HasComponent(entity))
		{
			return c._chaseStateGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		BreedStateCD value = c._breedStateGroup[entity];
		if (stateInfo.HasState(StateID.Breed))
		{
			return;
		}
		Entity targetEntity = c._chaseStateGroup[entity].targetEntity;
		if (targetEntity == Entity.Null)
		{
			return;
		}
		bool flag = false;
		if (c._localTransformGroup.HasComponent(targetEntity) && c._localTransformGroup.HasComponent(entity))
		{
			LocalTransform localTransform = c._localTransformGroup[entity];
			if (math.length(c._localTransformGroup[targetEntity].Position - localTransform.Position) < value.minDistanceToBreed && c._breedStateGroup.HasComponent(entity) && c._eatStateGroup.HasComponent(entity) && c._objectDataGroup[targetEntity].objectID == c._objectDataGroup[entity].objectID && c._breedStateGroup.HasComponent(targetEntity) && c._eatStateGroup.HasComponent(targetEntity) && c._breedToggleGroup.HasComponent(targetEntity) && c._breedToggleGroup.HasComponent(entity))
			{
				bool num = c._breedStateGroup[entity].HasEatenEnough(c._mealsEatenGroup[entity]);
				bool flag2 = c._breedStateGroup[targetEntity].HasEatenEnough(c._mealsEatenGroup[entity]);
				bool flag3 = !c._breedToggleGroup[entity].breedingDisabled;
				bool flag4 = !c._breedToggleGroup[targetEntity].breedingDisabled;
				bool flag5 = c._objectDataGroup[entity].amount >= c._eatStateGroup[entity].maxFoodUntilFull;
				bool flag6 = c._objectDataGroup[targetEntity].amount >= c._eatStateGroup[targetEntity].maxFoodUntilFull;
				if (num && flag2 && flag5 && flag6 && flag3 && flag4)
				{
					value.partnerEntity = targetEntity;
					flag = true;
				}
			}
		}
		if (flag)
		{
			stateInfo.EnterState(StateID.Breed);
			c._breedStateGroup[entity] = value;
		}
	}
}
