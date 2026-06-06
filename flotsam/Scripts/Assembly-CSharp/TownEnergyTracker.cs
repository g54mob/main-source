using System;
using UnityEngine;

public abstract class TownEnergyTracker : SceneBehaviour
{
	private enum Mode
	{
		Energy = 0,
		Distance = 1
	}

	[SerializeField]
	private Mode _mode;

	protected virtual void Update()
	{
		Engine engine = Community.PlayerCommunity.Engine;
		if ((bool)engine)
		{
			float num = engine.EnergyGrid.ReturnStorageEnergy();
			float num2 = engine.EnergyGrid.ReturnStorageCapacity();
			switch (_mode)
			{
			case Mode.Energy:
				SetValue(num, num2);
				break;
			case Mode.Distance:
				SetValue(engine.ReturnEnergyRange(num), engine.ReturnEnergyRange(num2));
				break;
			default:
				Debug.LogException(new NotImplementedException());
				break;
			}
		}
	}

	public abstract void SetValue(float value, float maxValue);
}
