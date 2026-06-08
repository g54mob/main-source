using UnityEngine;

[RequireComponent(typeof(ModalFade))]
public class PopUpModalScreen : AsciiObject
{
	public enum State
	{
		Disabled = 0,
		In = 1,
		Out = 2,
		Idle = 3
	}

	public AsciiSprite background;

	public DialogButton closeButton;

	public bool isFullScreen = true;

	protected ModalFade modalFade;

	private float outAcceleration = 1.8f;

	private float inVelocity = 6f;

	private float inBounceThreshold = 6f;

	private float inBounceAcceleration = 1.6f;

	private float inBounceMaxVelocity = 1f;

	private float transitionMaxPosition = 29f;

	protected float transitionOffsetY;

	private float transitionVelocity;

	public State currentState { get; private set; }

	public int stateElapsedTics { get; private set; }

	public bool canBack { get; set; }

	public virtual void Show()
	{
		SetState(State.In);
	}

	public virtual void Hide()
	{
		SetState(State.Out);
	}

	protected virtual void SetState(State newState)
	{
		if (modalFade != null)
		{
			modalFade.active = newState != State.Disabled && newState != State.Out;
		}
		switch (newState)
		{
		case State.In:
			transitionOffsetY = transitionMaxPosition;
			transitionVelocity = 0f - inVelocity;
			break;
		case State.Out:
		case State.Idle:
			transitionOffsetY = 0f;
			transitionVelocity = 0f;
			break;
		case State.Disabled:
			transitionOffsetY = transitionMaxPosition;
			transitionVelocity = 0f;
			break;
		}
		currentState = newState;
		stateElapsedTics = 0;
	}

	public override void UpdateTic()
	{
		stateElapsedTics++;
		if (currentState == State.Out)
		{
			transitionVelocity += outAcceleration;
			transitionOffsetY += transitionVelocity;
			if (transitionOffsetY > transitionMaxPosition)
			{
				SetState(State.Disabled);
			}
		}
		else if (currentState == State.In)
		{
			bool flag = transitionOffsetY >= 0f && transitionVelocity >= 0f;
			if (transitionOffsetY > inBounceThreshold)
			{
				transitionOffsetY += transitionVelocity;
			}
			else
			{
				transitionVelocity = Mathf.Min(inBounceMaxVelocity, transitionVelocity + inBounceAcceleration);
				transitionOffsetY += transitionVelocity;
				if (transitionOffsetY >= 0f && transitionVelocity >= 0f)
				{
					flag = true;
				}
			}
			if (flag)
			{
				SetState(State.Idle);
			}
		}
		else if (currentState == State.Idle && canBack)
		{
			closeButton.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (modalFade != null)
		{
			modalFade.Draw(r);
		}
		offsetX += PositionX + (Width >> 1);
		offsetY += PositionY + (int)transitionOffsetY;
		if (isFullScreen && currentState == State.Idle)
		{
			r.Clear();
		}
		if (currentState != State.Disabled)
		{
			if (background != null)
			{
				background.Draw(r, offsetX, offsetY);
			}
			if (canBack)
			{
				closeButton.Draw(r, offsetX, offsetY);
			}
		}
	}

	private void HandleCloseButtonPressed(DialogButton button)
	{
		Hide();
	}

	protected virtual void Update()
	{
		if (currentState == State.Idle && Input.GetKeyDown(KeyCode.Escape) && canBack)
		{
			HandleCloseButtonPressed(null);
		}
	}

	protected virtual void Start()
	{
		if (closeButton != null)
		{
			closeButton.OnPressed += HandleCloseButtonPressed;
		}
	}

	protected virtual void OnDestroy()
	{
		if (closeButton != null)
		{
			closeButton.OnPressed -= HandleCloseButtonPressed;
		}
	}

	protected virtual void Awake()
	{
		modalFade = GetComponent<ModalFade>();
		canBack = closeButton != null;
	}
}
