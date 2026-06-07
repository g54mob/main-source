using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Simulation/Ping", fileName = "PingSimulation")]
public class PingSimulation : ScriptableObject, IIncrementalSimulation
{
	[SerializeField]
	private float maximumPing = 999f;

	public void Registered(UIRegistry? _)
	{
	}

	public void Unregistered()
	{
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		float num = CalculateLoadImpact(Database.State.Resources.Load.Value);
		float num2 = CalculateCongestionImpact();
		float value = ModifierType.Ping.Float() + num + num2;
		Database.State.Resources.Ping.SetValue(Mathf.Clamp(value, ModifierType.PingMinimum.Float(), maximumPing));
	}

	private float CalculateLoadImpact(float load)
	{
		if (load <= 0.85f)
		{
			if (load <= 0.5f)
			{
				return Mathf.Lerp(-8f, 0f, Mathf.InverseLerp(0f, 0.5f, load));
			}
			return 0f;
		}
		if (load <= 1f)
		{
			return Mathf.Lerp(0f, 18f, Mathf.InverseLerp(0.85f, 1f, load));
		}
		return 18f + Mathf.Pow((load - 1f) * 70f, 1.8f);
	}

	private float CalculateCongestionImpact()
	{
		double num = Math.Max(1.0, Database.Derived.DatacenterCapacity.CurrentValue);
		double num2 = Math.Max(0.0, Database.State.Resources.Players.Value - num);
		if (num2 <= 0.0)
		{
			return 0f;
		}
		float num3 = (float)(num2 / num);
		float num4 = 1f + num3 * num3 * 2f;
		return (float)(num2 * (double)num4 * (double)ModifierType.PingLagPerPlayer.Float());
	}
}
