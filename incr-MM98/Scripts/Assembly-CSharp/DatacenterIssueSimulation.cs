using System.Collections.Generic;
using UnityEngine;
using ZLinq;

[CreateAssetMenu(menuName = "Data/Simulation/Datacenter Issue", fileName = "DatacenterIssueSimulation")]
public class DatacenterIssueSimulation : ScriptableObject, IIntervalIncrementalSimulation, IIncrementalSimulation
{
	[field: SerializeField]
	public float UpdateInterval { get; private set; }

	public void Registered(UIRegistry? _)
	{
	}

	public void Unregistered()
	{
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		Database.State.Datacenters.RecentlyDegraded.AdvanceTime(deltaTime);
		if (Database.State.Game.Launched.Value && Database.State.Datacenters.Details.Count != 0)
		{
			TriggerDatacenterIssue();
		}
	}

	private void TriggerDatacenterIssue()
	{
		Datacenter datacenter = (from x in Database.State.Datacenters.Details.AsValueEnumerable()
			select x.Key).Random();
		if (!Database.State.Datacenters.RecentlyDegraded.Contains(datacenter) && Random.value <= ModifierType.DatacenterDegradeChance.Modified(datacenter.Data().crashChance))
		{
			Database.Commands.Datacenters.Degrade(datacenter);
		}
	}
}
