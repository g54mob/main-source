using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct EnemyStagesStateRequest : IStateRequester
{
	public bool ShouldUpdate(Entity entity, ref StateRequestData d, ref StateRequestContainers c)
	{
		if (c._enemyStagesGroup.HasComponent(entity))
		{
			return c._healthGroup.HasComponent(entity);
		}
		return false;
	}

	public void OnUpdate(Entity entity, EntityCommandBuffer ecb, ref StateRequestData d, ref StateRequestContainers c, ref StateInfoCD stateInfo)
	{
		if (stateInfo.HasState(StateID.StageTransition))
		{
			return;
		}
		EnemyStagesStateCD value = c._enemyStagesGroup[entity];
		int currentStage = value.GetCurrentStage(c._healthGroup[entity].Normalized);
		if (value.currentStage != currentStage)
		{
			value.currentStage = currentStage;
			if (currentStage != value.maxStages - 1)
			{
				stateInfo.EnterState(StateID.StageTransition);
			}
		}
		c._enemyStagesGroup[entity] = value;
	}
}
