using Assets.Behaviour.UI;
using UnityEngine;
using UnityEngine.Events;

public class FrameButton : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _button;

	[SerializeField]
	private Sprite _activeSprite;

	[SerializeField]
	private Sprite _highlightSprite;

	[SerializeField]
	private Sprite _disabledSprite;

	[SerializeField]
	private bool _mouseDownIsClick;

	[SerializeField]
	private UnityEvent _onClick;

	private bool _active = true;

	private bool _mouseOver;

	private ActiveWorldFrame _parentFrame;

	public ActiveWorldAnchor Anchor { get; private set; }

	private void Start()
	{
		_parentFrame = GetComponentInParent<ActiveWorldFrame>();
		Anchor = GetComponentInParent<ActiveWorldAnchor>();
		if (!GetComponent<Interactable>())
		{
			base.gameObject.AddComponent<Interactable>();
		}
	}

	private void Update()
	{
		if ((bool)_button)
		{
			if (!_active)
			{
				_button.sprite = _disabledSprite;
			}
			else if (_mouseOver)
			{
				_button.sprite = _highlightSprite;
			}
			else
			{
				_button.sprite = _activeSprite;
			}
		}
	}

	public void SetActive(bool active)
	{
		_active = active;
	}

	public bool IsActive()
	{
		return _active;
	}

	private void OnMouseEnter()
	{
		_mouseOver = true;
	}

	private void OnMouseExit()
	{
		_mouseOver = false;
	}

	private void _buttonClicked()
	{
		if (!GameUI.MenuVisible && _active)
		{
			UISounds.CraftStep();
			if ((bool)Anchor)
			{
				_parentFrame.ButtonClicked(this);
			}
			_onClick.Invoke();
		}
	}

	private void OnMouseUpAsButton()
	{
		if (!_mouseDownIsClick)
		{
			_buttonClicked();
		}
	}

	private void OnMouseDown()
	{
		if (_mouseDownIsClick)
		{
			_buttonClicked();
		}
	}
}
