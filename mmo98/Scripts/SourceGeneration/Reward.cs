using System;

[Serializable]
public struct Reward
{
	public RewardType type;

	public CalculationType calculation;

	public double value;

	public int HandleInt(double baseValue)
	{
		return (int)Math.Round(Handle(value), MidpointRounding.AwayFromZero);
	}

	public float HandleFloat(double baseValue)
	{
		return (float)calculation.GetOperation()(baseValue, value);
	}

	public double HandleDouble(double baseValue)
	{
		return calculation.GetOperation()(baseValue, value);
	}

	public double Handle(double baseValue)
	{
		return calculation.GetOperation()(baseValue, value);
	}
}
