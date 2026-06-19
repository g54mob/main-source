using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct EvolveStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._evolveStateGroup.HasComponent(entity))
		{
			return c._mealsEatenGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		EvolveStateCD evolveStateCD = c._evolveStateGroup[entity];
		if (evolveStateCD.toEvolveInto != ObjectID.None && !stateInfo.HasState(StateID.Evolve) && c._mealsEatenGroup[entity].Value >= evolveStateCD.foodAmountToEvolve)
		{
			stateInfo.EnterState(StateID.Evolve);
		}
	}
}
