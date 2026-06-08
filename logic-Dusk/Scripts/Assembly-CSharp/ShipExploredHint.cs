using UnityEngine;

public class ShipExploredHint : IHint
{
	private enum MyStateEnum
	{
		None = 0,
		TransitionIn = 1,
		TransitionOff = 2,
		Delay = 3,
		ShowingMessage = 4,
		ExitHint = 5
	}

	private MyStateEnum currentState;

	private ExitHint exitHint;

	public int Priority
	{
		get
		{
			return 0;
		}
	}

	public bool IsCompleting { get; private set; }

	public bool HasStarted { get; private set; }

	public bool CompleteTriggersNextStep { get; private set; }

	public bool OnlyAllowCompleteIfStarted
	{
		get
		{
			return true;
		}
	}

	public IHintState Start()
	{
		HasStarted = true;
		currentState = MyStateEnum.Delay;
		CompleteTriggersNextStep = true;
		if (HintManager.HintText != null)
		{
			HintManager.HintText.text = string.Format("To exit: Return all drones to docking bay (r1)\r\n'navigate 1 2 3 r1 or navigate all r1'");
		}
		else
		{
			Debug.LogWarning("HintManager.HintText == null!!!");
		}
		return new DelayHintState(20f);
	}

	public void Update()
	{
	}

	public IHintState GetNextState()
	{
		switch (currentState)
		{
		case MyStateEnum.Delay:
			currentState = MyStateEnum.TransitionIn;
			return new TransitionSlideHintState(HintManager.OffScreenPosition, HintManager.OnScreenPosition, 0.5f);
		case MyStateEnum.TransitionIn:
			currentState = MyStateEnum.ShowingMessage;
			return new PulseHintState(0.75f, 0f);
		case MyStateEnum.ShowingMessage:
			CompleteTriggersNextStep = false;
			if (!GameSaveFile.Get("HNT_EXIT", false))
			{
				exitHint = new ExitHint();
				CompleteTriggersNextStep = false;
				currentState = MyStateEnum.ExitHint;
				return exitHint.Start();
			}
			currentState = MyStateEnum.TransitionOff;
			return new TransitionSlideHintState(HintManager.OnScreenPosition, HintManager.OffScreenPosition, 0.25f);
		case MyStateEnum.ExitHint:
			return exitHint.GetNextState();
		default:
			return null;
		}
	}

	public virtual IHintState Completed()
	{
		IsCompleting = true;
		currentState = MyStateEnum.TransitionOff;
		GameSaveFile.Save("HNT_SHIPEXPLORED", true);
		return new TransitionSlideHintState(HintManager.OnScreenPosition, HintManager.OffScreenPosition, 0.25f);
	}

	public IHintState Terminate()
	{
		IsCompleting = true;
		currentState = MyStateEnum.TransitionOff;
		return new TransitionSlideHintState(HintManager.OnScreenPosition, HintManager.OffScreenPosition, 0.25f);
	}
}
