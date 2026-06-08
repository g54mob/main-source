using UnityEngine;

public class DelayHintState : IHintState
{
	private float delay;

	public HintStateTypeEnum StateType
	{
		get
		{
			return HintStateTypeEnum.Unknown;
		}
	}

	private DelayHintState()
	{
	}

	public DelayHintState(float delay)
	{
		this.delay = delay;
	}

	public void Start()
	{
	}

	public bool Update()
	{
		delay -= Time.deltaTime;
		if (delay <= 0f)
		{
			return true;
		}
		return false;
	}

	public void Stop()
	{
	}
}
