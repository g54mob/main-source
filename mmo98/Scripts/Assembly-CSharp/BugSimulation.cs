using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Simulation/Bug", fileName = "BugSimulation")]
public class BugSimulation : ScriptableObject, IIncrementalSimulation
{
	[SerializeField]
	private float refreshInterval = 30f;

	public void Registered(UIRegistry? registry)
	{
		Database.State.Debugger.RefreshTimer.StartTimer(refreshInterval);
	}

	public void Unregistered()
	{
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		if (Database.State.Game.Launched.Value)
		{
			HandleBugAccumulation(deltaTime);
		}
	}

	private void HandleBugAccumulation(float deltaTime)
	{
		float num = CalculateBugGenerationRate() * MathUtility.Resistance(Database.State.Resources.Bugs.Value, Database.Derived.BugSoftCapacity.CurrentValue, 3f);
		if (!Database.State.Debugger.BonusDecayTimer.Value.IsDone)
		{
			Database.State.Debugger.BonusDecayTimer.AdvanceTimer(deltaTime);
			num = Mathf.Max(0f, num * Database.State.Debugger.BonusDecayRate.Value);
		}
		if (Database.State.Resources.Bugs.Value > Database.Derived.BugHardCapacity.CurrentValue)
		{
			num = 0f;
		}
		Database.State.Resources.Bugs.AddValue(num * deltaTime);
	}

	private float CalculateBugGenerationRate()
	{
		float num = Mathf.Log10((float)Math.Max(1.0, Database.State.Resources.Players.Value)) * ModifierType.BugsPlayerScaling.Float();
		float num2 = 0.5f + Database.State.Resources.Load.Value;
		return (ModifierType.BugsGenerationRate.Float() + num) * num2;
	}
}
