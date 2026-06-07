using UnityEngine;

public class Research_Button : MonoBehaviour
{
	public enum StateEnum
	{
		Full = 0,
		None = 1,
		Top = 2,
		Middle = 3,
		Bottom = 4
	}

	public Research Parent;

	public Sprite Book_Full;

	public Sprite Book_None;

	public Sprite Book_Top;

	public Sprite Book_Middle;

	public Sprite Book_Bottom;

	private SpriteRenderer _renderer;

	private Color _normalColor = Color.white;

	private bool _isLocked;

	private StateEnum _savedState;

	private StateEnum _currentState;

	public void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
		SetNewState();
	}

	private void FixedUpdate()
	{
		Helper.SetZForFocus(base.transform);
	}

	public void Lock()
	{
		_isLocked = true;
	}

	public void Unlock()
	{
		_isLocked = false;
	}

	public void SetNewState(bool ignoreNull = false)
	{
		if (ignoreNull)
		{
			int num = Random.Range(0, 4);
			if (num > 0)
			{
				num++;
			}
			_savedState = (StateEnum)num;
		}
		else
		{
			_savedState = (StateEnum)Random.Range(0, 5);
		}
		_currentState = StateEnum.None;
		DrawState(_savedState);
	}

	public void SetNullState()
	{
		_savedState = StateEnum.None;
		_currentState = StateEnum.None;
		DrawState(_savedState);
	}

	public void ShowUserInput()
	{
		DrawState(_currentState);
	}

	private void DrawState(StateEnum state)
	{
		switch (state)
		{
		case StateEnum.Full:
			_renderer.sprite = Book_Full;
			break;
		case StateEnum.None:
			_renderer.sprite = Book_None;
			break;
		case StateEnum.Top:
			_renderer.sprite = Book_Top;
			break;
		case StateEnum.Middle:
			_renderer.sprite = Book_Middle;
			break;
		case StateEnum.Bottom:
			_renderer.sprite = Book_Bottom;
			break;
		}
	}

	public bool SameState()
	{
		if (_savedState == _currentState)
		{
			return true;
		}
		return false;
	}

	public void SetEvilState(bool isEvil)
	{
		if (isEvil)
		{
			_renderer.color = GameController.EvilColor;
		}
		else
		{
			_renderer.color = _normalColor;
		}
	}

	public void SetColor(Color c)
	{
		_normalColor = c;
		_renderer.color = _normalColor;
	}

	private void OnMouseOver()
	{
		if (Research.GlobalInfo.CanHighlightDevice())
		{
			SetColor(Color.yellow);
		}
	}

	private void OnMouseExit()
	{
		if (Research.GlobalInfo.CanHighlightDevice())
		{
			SetColor(Color.white);
		}
	}

	private void OnMouseDown()
	{
		if (!Sign.PreventEvent && !_isLocked)
		{
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_click);
			int currentState = (int)_currentState;
			currentState++;
			if (currentState >= 5)
			{
				currentState = 0;
			}
			_currentState = (StateEnum)currentState;
			DrawState(_currentState);
		}
	}
}
