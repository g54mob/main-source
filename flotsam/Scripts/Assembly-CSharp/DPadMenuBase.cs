using UnityEngine;

public abstract class DPadMenuBase : SceneBehaviour
{
	[SerializeField]
	private DPadMenuId _id;

	[SerializeField]
	private bool _pauseGame;

	[Header("Input")]
	[SerializeField]
	private bool _handlesInput = true;

	[SerializeField]
	[ConditionalHide("_handlesInput", true)]
	private RewiredAction _interact = new RewiredAction(93, "UI_Interact");

	[SerializeField]
	[ConditionalHide("_handlesInput", true)]
	private RewiredAction _cancel = new RewiredAction(102, "UI_Cancel");

	[SerializeField]
	[ConditionalHide("_handlesInput", true)]
	private float _triggerUpThreshold = 2f;

	private float _triggerDownTime;

	private bool _triggerOnUp;

	public DPadMenuId Id => _id;

	public bool IsEnabled { get; private set; }

	public int TriggerAction { get; private set; }

	public bool HandlesInput
	{
		get
		{
			if (_handlesInput)
			{
				return FlotsamInputManager.HasActiveInput(InputFlags.Joystick);
			}
			return false;
		}
	}

	protected virtual void Update()
	{
		if (!HandlesInput)
		{
			return;
		}
		if (_triggerOnUp)
		{
			if (FlotsamInputManager.GetButton(TriggerAction))
			{
				_triggerDownTime += Time.unscaledDeltaTime;
				return;
			}
			if (_triggerUpThreshold < _triggerDownTime)
			{
				Trigger();
			}
			_triggerOnUp = false;
		}
		if (_interact.GetButtonUp())
		{
			Trigger();
		}
		if (_cancel.GetButtonUp())
		{
			Disable();
		}
	}

	public virtual void Enable(int triggerAction, bool handleInput = false)
	{
		TriggerAction = triggerAction;
		_triggerDownTime = 0f;
		_triggerOnUp = true;
		if (_pauseGame && GameSpeedManager.GameSpeed != GameSpeed.Zero)
		{
			GameSpeedManager.ToggleGameSpeedZero();
		}
	}

	public abstract void Trigger();

	public virtual void Disable()
	{
		if (_pauseGame && GameSpeedManager.GameSpeed == GameSpeed.Zero)
		{
			GameSpeedManager.ToggleGameSpeedZero();
		}
	}
}
