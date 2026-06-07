using System;

[Serializable]
public class BalanceChangeData
{
	public long changeAmount;

	public PlayerProfile changer;

	public ChangeType changeType;

	public BalanceChangeData(long changeAmount, PlayerProfile changer, ChangeType changeType)
	{
		this.changeAmount = changeAmount;
		this.changer = changer;
		this.changeType = changeType;
	}
}
