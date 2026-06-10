using System.Collections.Generic;
using NSMedieval.CommanderAI;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Goap;
using NSMedieval.Village.Map;
using NodeCanvas.Framework;

public abstract class CommanderAIBTActionBase : ActionTask<CommanderAgentProxy>
{
	private bool isInitialized;

	private bool oneTickHappened;

	private Variable<IDamageTakingAgent> obstacleTargetVariable;

	protected VillageMap Map => base.agent.Map;

	protected ICollection<CommanderAIUnit> Units => base.agent.Units;

	protected CommanderAIUnit FirstUnit => base.agent.Agent.FirstUnit;

	protected override void OnExecute()
	{
		isInitialized = false;
		oneTickHappened = false;
	}

	protected override void OnUpdate()
	{
		if (!oneTickHappened)
		{
			oneTickHappened = true;
		}
		else if (!isInitialized)
		{
			isInitialized = true;
			OnStart();
		}
		else
		{
			OnTick();
		}
	}

	protected virtual void OnStart()
	{
	}

	protected virtual void OnTick()
	{
	}

	protected override void OnStop(bool interrupted)
	{
		base.OnStop(interrupted);
		isInitialized = false;
		oneTickHappened = false;
	}

	protected AttackOrder CreateAttackOrder(IDamageTakingAgent target)
	{
		if (obstacleTargetVariable == null)
		{
			obstacleTargetVariable = base.blackboard.GetVariable<IDamageTakingAgent>("obstacleToTarget");
			if (obstacleTargetVariable == null)
			{
				obstacleTargetVariable = base.ownerSystemBlackboard.GetVariable<IDamageTakingAgent>("obstacleToTarget");
			}
		}
		if (obstacleTargetVariable == null)
		{
			return new AttackOrder(target);
		}
		return new AttackOrder(target, obstacleTargetVariable.value == target);
	}
}
