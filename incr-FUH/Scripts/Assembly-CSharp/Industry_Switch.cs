using UnityEngine;

public class Industry_Switch : MonoBehaviour
{
	public enum StateEnum
	{
		Off = 0,
		On = 1
	}

	public Sprite SwitchOff;

	public Sprite SwitchOn;

	public Industry Parent;

	private SpriteRenderer _renderer;

	public StateEnum State;

	public void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		ChangeState(StateEnum.Off);
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		Helper.SetZForFocus(base.transform);
	}

	private void ChangeState(StateEnum newState)
	{
		State = newState;
		switch (State)
		{
		case StateEnum.On:
			GetComponent<SpriteRenderer>().sprite = SwitchOn;
			break;
		case StateEnum.Off:
			GetComponent<SpriteRenderer>().sprite = SwitchOff;
			break;
		}
	}

	private void OnMouseOver()
	{
		if (Industry.GlobalInfo.CanHighlightDevice())
		{
			_renderer.color = Color.yellow;
		}
	}

	private void OnMouseExit()
	{
		if (Industry.GlobalInfo.CanHighlightDevice())
		{
			_renderer.color = Color.white;
		}
	}

	private void OnMouseDown()
	{
		if (!Sign.PreventEvent)
		{
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_click);
			if (State == StateEnum.On)
			{
				ChangeState(StateEnum.Off);
			}
			else if (State == StateEnum.Off)
			{
				ChangeState(StateEnum.On);
			}
		}
	}
}
