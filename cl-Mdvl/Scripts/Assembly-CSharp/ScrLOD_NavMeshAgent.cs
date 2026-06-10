using FIMSpace.FOptimizing;
using UnityEngine;
using UnityEngine.AI;

public sealed class ScrLOD_NavMeshAgent : ScrLOD_Base
{
	[SerializeField]
	private LODI_NavMeshAgent settings;

	public override ILODInstance GetLODInstance()
	{
		return settings;
	}

	public ScrLOD_NavMeshAgent()
	{
		settings = new LODI_NavMeshAgent();
	}

	public override ScrLOD_Base GetScrLODInstance()
	{
		return ScriptableObject.CreateInstance<ScrLOD_NavMeshAgent>();
	}

	public override ScrLOD_Base CreateNewScrCopy()
	{
		ScrLOD_NavMeshAgent scrLOD_NavMeshAgent = ScriptableObject.CreateInstance<ScrLOD_NavMeshAgent>();
		scrLOD_NavMeshAgent.settings = settings.GetCopy() as LODI_NavMeshAgent;
		return scrLOD_NavMeshAgent;
	}

	public override ScriptableLODsController GenerateLODController(Component target, ScriptableOptimizer optimizer)
	{
		NavMeshAgent navMeshAgent = target as NavMeshAgent;
		if (!navMeshAgent)
		{
			navMeshAgent = target.GetComponentInChildren<NavMeshAgent>();
		}
		if ((bool)navMeshAgent && !optimizer.ContainsComponent(navMeshAgent))
		{
			return new ScriptableLODsController(optimizer, navMeshAgent, -1, "NavMeshAgent", this);
		}
		return null;
	}
}
