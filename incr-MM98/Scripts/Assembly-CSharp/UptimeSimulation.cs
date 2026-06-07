using System.Collections.Generic;
using R3;
using UnityEngine;
using ZLinq;

[CreateAssetMenu(menuName = "Data/Simulation/Uptime", fileName = "UptimeSimulation")]
public class UptimeSimulation : ScriptableObject, IIncrementalSimulation
{
	public void Registered(UIRegistry? _)
	{
	}

	public void Unregistered()
	{
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		float num = GetDatacenterWeight() / (1f + (float)Database.State.Datacenters.Details.Count);
		float t = 1f - Mathf.Pow(1f - num, 1f);
		float num2 = Mathf.Lerp(0f, 1f, t);
		float num3 = ((num2 > Database.State.Resources.Uptime.Value) ? ModifierType.UptimeRecovery.Float() : ModifierType.UptimeDegradation.Float());
		Database.State.Resources.Uptime.SetValue(Mathf.MoveTowards(Database.State.Resources.Uptime.Value, num2, num3 * deltaTime));
	}

	private float GetDatacenterWeight()
	{
		float nominal = ModifierType.UptimeNominalWeight.Float();
		float degraded = ModifierType.UptimeDegradedWeight.Float();
		float critical = ModifierType.UptimeCriticalWeight.Float();
		return 1f + (from x in Database.State.Datacenters.Details.AsValueEnumerable()
			select x.Value.State).Sum(delegate(ReactiveProperty<DatacenterState> state)
		{
			switch (state.Value)
			{
			case DatacenterState.Nominal:
			case DatacenterState.Construction:
				return nominal;
			case DatacenterState.Degraded:
				return degraded;
			case DatacenterState.Critical:
				return critical;
			default:
				return 0f;
			}
		});
	}
}
