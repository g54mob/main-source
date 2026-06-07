using System;
using ZLinq;

public class DatabaseRewards : IDisposable
{
	public void Apply<TEnumerator>(ValueEnumerable<TEnumerator, Reward> rewards) where TEnumerator : struct, IValueEnumerator<Reward>
	{
		using ValueEnumerator<TEnumerator, Reward> valueEnumerator = ValueEnumerableExtensions.GetEnumerator(in rewards);
		while (valueEnumerator.MoveNext())
		{
			Reward current = valueEnumerator.Current;
			Apply(current);
		}
	}

	public void Apply(Reward reward)
	{
		switch (reward.type)
		{
		case RewardType.Nodes:
			Database.State.Resources.Nodes.SetValue(Calculate(reward, Database.State.Resources.Nodes.Value));
			break;
		case RewardType.Players:
			Database.State.Resources.Players.SetValue(Calculate(reward, Database.State.Resources.Players.Value));
			break;
		case RewardType.Money:
			Database.State.Resources.Money.SetValue(Calculate(reward, Database.State.Resources.Money.Value));
			Database.State.Resources.MoneyLifetime.SetValue(Calculate(reward, Database.State.Resources.MoneyLifetime.Value));
			break;
		case RewardType.Bugs:
			Database.State.Resources.Bugs.SetValue(Calculate(reward, Database.State.Resources.Bugs.Value));
			break;
		default:
			throw new ArgumentOutOfRangeException();
		case RewardType.None:
			break;
		}
	}

	private int Calculate(Reward reward, int value)
	{
		return (int)Math.Round(reward.Handle(value), MidpointRounding.AwayFromZero);
	}

	private float Calculate(Reward reward, float value)
	{
		return (float)reward.Handle(value);
	}

	private double Calculate(Reward reward, double value)
	{
		return reward.Handle(value);
	}

	public void Dispose()
	{
	}
}
