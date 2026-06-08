public class SpacerHint : IHint
{
	private float delay;

	public int Priority
	{
		get
		{
			return 0;
		}
	}

	public bool IsCompleting
	{
		get
		{
			return true;
		}
	}

	public bool HasStarted { get; private set; }

	public bool CompleteTriggersNextStep { get; private set; }

	public bool OnlyAllowCompleteIfStarted
	{
		get
		{
			return false;
		}
	}

	private SpacerHint()
	{
	}

	public SpacerHint(float delay)
	{
		this.delay = delay;
	}

	IHintState IHint.Start()
	{
		HasStarted = true;
		if (HintManager.HintText != null)
		{
			HintManager.HintText.text = string.Empty;
		}
		return new DelayHintState(delay);
	}

	public void Update()
	{
	}

	public IHintState GetNextState()
	{
		return null;
	}

	public IHintState Completed()
	{
		return null;
	}

	public IHintState Terminate()
	{
		return null;
	}
}
