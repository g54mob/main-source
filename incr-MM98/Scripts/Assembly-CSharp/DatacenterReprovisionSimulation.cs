using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Simulation/Datacenter Reprovision", fileName = "DatacenterReprovisionSimulation")]
public class DatacenterReprovisionSimulation : ScriptableObject, IIncrementalSimulation
{
	[SerializeField]
	private ResearchNode pooledEngineersResearch;

	public void Registered(UIRegistry? registry)
	{
	}

	public void Unregistered()
	{
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		foreach (var (datacenter2, datacenterDetails2) in Database.State.Datacenters.Details)
		{
			switch (datacenterDetails2.State.Value)
			{
			case DatacenterState.Construction:
				HandleDatacenterConstruction(datacenter2, datacenterDetails2, deltaTime);
				break;
			case DatacenterState.Degraded:
			case DatacenterState.Critical:
				HandleDatacenterReprovision(datacenter2, datacenterDetails2, deltaTime);
				break;
			}
		}
	}

	private void HandleDatacenterConstruction(Datacenter datacenter, DatacenterDetails details, float deltaTime)
	{
		float num = details.ReprovisionProgress.Value + ModifierType.DatacenterConstructionSpeed.Float() * deltaTime;
		if (num >= 1f)
		{
			Database.Commands.Datacenters.Construct(datacenter);
		}
		else
		{
			details.ReprovisionProgress.Value = num;
		}
	}

	private void HandleDatacenterReprovision(Datacenter datacenter, DatacenterDetails details, float deltaTime)
	{
		float num = details.ReprovisionProgress.Value + (float)GetAvailableEngineers(details) * ModifierType.ReprovisionTimeEngineer.Float() * deltaTime;
		if (num >= 1f)
		{
			Database.Commands.Datacenters.Restore(datacenter);
		}
		else
		{
			details.ReprovisionProgress.Value = num;
		}
	}

	private int GetAvailableEngineers(DatacenterDetails details)
	{
		if (!Database.State.Research.IsUnlocked(pooledEngineersResearch))
		{
			return details.Engineers.CurrentValue;
		}
		return Database.Derived.TotalEngineers.CurrentValue;
	}
}
