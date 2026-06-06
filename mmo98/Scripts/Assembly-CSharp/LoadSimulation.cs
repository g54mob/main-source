using UnityEngine;

[CreateAssetMenu(menuName = "Data/Simulation/Load", fileName = "LoadSimulation")]
public class LoadSimulation : ScriptableObject, IIncrementalSimulation
{
	public void Registered(UIRegistry? _)
	{
	}

	public void Unregistered()
	{
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		double num = Database.Derived.PlayersCapacity.CurrentValue;
		if (num <= 0.0)
		{
			num = 1.0;
		}
		float num2 = (float)(Database.State.Resources.Players.Value / num);
		float value = num2 + ModifierType.LoadOverhead.Float() + ModifierType.Load.Float();
		Database.State.Resources.Load.SetValue(value);
		Database.State.Resources.LoadPlayers.SetValue(num2);
		Database.State.Resources.TickRate.SetValue(CalculateTickrate(value));
	}

	private static int CalculateTickrate(float value)
	{
		if (value <= 0.75f)
		{
			return 60;
		}
		if (value <= 1f)
		{
			return Mathf.RoundToInt(Mathf.Lerp(60f, 30f, (value - 0.75f) / 0.25f));
		}
		if (value <= 1.2f)
		{
			return Mathf.RoundToInt(Mathf.Lerp(30f, 10f, (value - 1f) / 0.2f));
		}
		return 10;
	}
}
