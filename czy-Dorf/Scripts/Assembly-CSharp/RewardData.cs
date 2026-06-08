using System;

[Serializable]
public class RewardData
{
	public string id;

	public int state;

	public RewardData(string id, RewardState state)
	{
		this.id = id;
		this.state = (int)state;
	}

	public void SetState(RewardState newState)
	{
		state = (int)newState;
	}
}
