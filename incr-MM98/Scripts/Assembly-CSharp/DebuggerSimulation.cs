using System.Collections.Generic;
using System.Linq;
using R3;
using UnityEngine;
using ZLinq;

[CreateAssetMenu(menuName = "Data/Simulation/Debugger", fileName = "DebuggerSimulation")]
public class DebuggerSimulation : ScriptableObject, IIncrementalSimulation
{
	[SerializeField]
	private float refreshInterval = 30f;

	public void Registered(UIRegistry? registry)
	{
		Database.State.Debugger.RefreshTimer.StartTimer(refreshInterval);
		if (!Database.State.Debugger.GlitchTimer.Value.IsActive)
		{
			Database.State.Debugger.GlitchTimer.StartTimer(CalculateGlitchInterval());
		}
	}

	public void Unregistered()
	{
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		HandleDebuggerRefresh(deltaTime);
		HandleHexGlitch(deltaTime);
		HandleCompilation(deltaTime);
		HandleAutomation(deltaTime);
	}

	private void HandleDebuggerRefresh(float deltaTime)
	{
		Database.State.Debugger.RefreshTimer.AdvanceTimer(deltaTime);
	}

	private void HandleHexGlitch(float deltaTime)
	{
		if (!(Database.State.Resources.Bugs.Value <= 1f))
		{
			EnsureGlitchTimer();
			if (Database.State.Debugger.GlitchTimer.AdvanceTimer(deltaTime))
			{
				TrySpawnGlitch();
				Database.State.Debugger.GlitchTimer.StartTimer(CalculateGlitchInterval());
			}
		}
	}

	private float CalculateGlitchInterval()
	{
		float t = MathUtility.Pressure(Database.State.Resources.Bugs.Value, Database.Derived.BugSoftCapacity.CurrentValue);
		float b = Mathf.Lerp(ModifierType.DebuggerHexGlitchIntervalMaximum.Float(), ModifierType.DebuggerHexGlitchIntervalMinimum.Float(), t);
		return Mathf.Max(0.1f, b);
	}

	private void TrySpawnGlitch()
	{
		if (Database.State.Debugger.Glitched.Count < ModifierType.DebuggerHexGlitchMaximum.Int())
		{
			float t = MathUtility.Pressure(Database.State.Resources.Bugs.Value, ModifierType.BugsSoftCapBase.Float());
			int num = Mathf.RoundToInt(Mathf.Lerp(ModifierType.DebuggerHexGlitchCountMinimum.Float(), ModifierType.DebuggerHexGlitchCountMaximum.Float(), t));
			for (int i = 0; i < num; i++)
			{
				Database.Commands.Debugger.GlitchHex(BiteRandom.NextInt(0, ModifierType.DebuggerHexCount.Int()));
			}
		}
	}

	private void HandleCompilation(float deltaTime)
	{
		if (Database.State.Debugger.InProgress)
		{
			float num = (Database.State.Debugger.Hotfixing.Value ? ModifierType.DebuggerHotfixingSpeed.Float() : ModifierType.DebuggerCompilationSpeed.Float());
			if (Database.State.Debugger.Progress.AdvanceTimer(num * deltaTime))
			{
				Database.Commands.Debugger.Finished();
			}
		}
	}

	private void HandleAutomation(float deltaTime)
	{
		DatabaseState.DebuggerState state = Database.State.Debugger;
		float num = ModifierType.DebuggerAutomationSpeed.Float();
		foreach (KeyValuePair<int, ReactiveProperty<TimerData>> item in state.Automated.ToList())
		{
			item.Deconstruct(out var _, out var value);
			value.AdvanceTimer(deltaTime * num);
		}
		if (state.Automated.Count < ModifierType.DebuggerAutomationAmount.Int() && state.Automated.Count < state.Glitched.Count && state.Staged.Count < ModifierType.DebuggerMaxStaging.Int())
		{
			int key2 = (from g in state.Glitched.AsValueEnumerable()
				where !state.Automated.ContainsKey(g)
				select g).Random();
			state.Automated.Add(key2, new ReactiveProperty<TimerData>(new TimerData(1f)));
		}
	}

	private void EnsureGlitchTimer()
	{
		if (!Database.State.Debugger.GlitchTimer.Value.IsActive)
		{
			Database.State.Debugger.GlitchTimer.StartTimer(CalculateGlitchInterval());
		}
	}
}
