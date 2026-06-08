using UnityEngine;

public class BaseMessageHint : IHint
{
	protected enum MyStateEnum
	{
		None = 0,
		TransitionIn = 1,
		TransitionOff = 2,
		Delay = 3,
		ShowingMessage = 4
	}

	protected MyStateEnum currentState;

	private string message = string.Empty;

	private object data;

	private float displayLength;

	private bool overrideHintColor;

	private Color hintColorOverride = Color.white;

	public int Priority { get; protected set; }

	public bool IsCompleting { get; private set; }

	public bool HasStarted { get; private set; }

	public bool CompleteTriggersNextStep { get; protected set; }

	public virtual bool OnlyAllowCompleteIfStarted
	{
		get
		{
			return false;
		}
	}

	private BaseMessageHint()
	{
	}

	public BaseMessageHint(string message, object data)
		: this(message, data, 0f)
	{
	}

	public BaseMessageHint(string message, object data, float displayLength)
		: this(message, data, displayLength, false, Color.white)
	{
	}

	public BaseMessageHint(string message, object data, float displayLength, bool overrideHintColor, Color hintColorOverride)
	{
		this.message = message;
		this.data = data;
		this.displayLength = displayLength;
		this.overrideHintColor = overrideHintColor;
		this.hintColorOverride = hintColorOverride;
	}

	public IHintState Start()
	{
		HasStarted = true;
		currentState = MyStateEnum.TransitionIn;
		if (HintManager.HintText != null)
		{
			HintManager.HintText.text = string.Format(message, data);
			return new TransitionSlideHintState(HintManager.OffScreenPosition, HintManager.OnScreenPosition, 0.5f, overrideHintColor, hintColorOverride);
		}
		HasStarted = false;
		currentState = MyStateEnum.None;
		Debug.LogError(string.Format("HintManager.HintText == null!!!  Hint message could not be displayed: {0}", message));
		return null;
	}

	public void Update()
	{
		if (HintManager.HintBackgroundObject != null)
		{
			RectTransform component = HintManager.HintText.gameObject.GetComponent<RectTransform>();
			RectTransform component2 = HintManager.HintBackgroundObject.GetComponent<RectTransform>();
			component2.sizeDelta = new Vector2(10f, component.rect.height + 7f);
		}
	}

	public virtual IHintState GetNextState()
	{
		switch (currentState)
		{
		case MyStateEnum.Delay:
			currentState = MyStateEnum.ShowingMessage;
			return new PulseHintState(0.75f, displayLength);
		case MyStateEnum.TransitionIn:
			currentState = MyStateEnum.Delay;
			return new DelayHintState(0.5f);
		case MyStateEnum.ShowingMessage:
			currentState = MyStateEnum.TransitionOff;
			return new TransitionSlideHintState(HintManager.OnScreenPosition, HintManager.OffScreenPosition, 0.25f);
		default:
			return null;
		}
	}

	public virtual IHintState Completed()
	{
		IsCompleting = true;
		currentState = MyStateEnum.TransitionOff;
		return new TransitionSlideHintState(HintManager.OnScreenPosition, HintManager.OffScreenPosition, 0.25f);
	}

	public IHintState Terminate()
	{
		IsCompleting = true;
		currentState = MyStateEnum.TransitionOff;
		return new TransitionSlideHintState(HintManager.OnScreenPosition, HintManager.OffScreenPosition, 0.25f);
	}
}
