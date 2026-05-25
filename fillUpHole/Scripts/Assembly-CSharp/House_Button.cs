using UnityEngine;

public class House_Button : MonoBehaviour
{
	public enum StateEnum
	{
		Off = 0,
		On = 1,
		Click = 2
	}

	public House Parent;

	public Sprite ButtonOff;

	public Sprite ButtonOn;

	public Sprite ButtonClick;

	private SpriteRenderer _renderer;

	private Color _normalColor = Color.white;

	public StateEnum State;

	public void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
	}

	public void Start()
	{
		ChangeState(StateEnum.Off);
	}

	public void Activate()
	{
		ChangeState(StateEnum.On);
	}

	public void Inactivate()
	{
		ChangeState(StateEnum.Off);
	}

	public void SetColor(Color c)
	{
		_normalColor = c;
		ChangeColor();
	}

	private void ChangeState(StateEnum newState)
	{
		State = newState;
		switch (State)
		{
		case StateEnum.Off:
			_renderer.sprite = ButtonOff;
			break;
		case StateEnum.On:
			_renderer.sprite = ButtonOn;
			break;
		case StateEnum.Click:
			_renderer.sprite = ButtonClick;
			break;
		}
		ChangeColor();
	}

	private void ChangeColor()
	{
		switch (State)
		{
		case StateEnum.Off:
			_renderer.color = _normalColor;
			break;
		case StateEnum.On:
			_renderer.color = _normalColor;
			break;
		case StateEnum.Click:
			_renderer.color = GameController.EvilColor;
			break;
		}
	}

	private void OnMouseOver()
	{
		if (House.GlobalInfo.CanHighlightDevice() && State != StateEnum.Click)
		{
			_renderer.color = Color.yellow;
		}
	}

	private void OnMouseExit()
	{
		if (House.GlobalInfo.CanHighlightDevice() && State != StateEnum.Click)
		{
			_renderer.color = Color.white;
		}
	}

	private void OnMouseDown()
	{
		if (!Sign.PreventEvent && State == StateEnum.On)
		{
			ChangeState(StateEnum.Click);
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_click);
		}
	}
}
