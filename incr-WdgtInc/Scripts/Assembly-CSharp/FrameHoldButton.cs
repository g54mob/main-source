using Assets.Behaviour.UI;
using UnityEngine;
using UnityEngine.Events;

public class FrameHoldButton : MonoBehaviour
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
	private Sprite _downActiveSprite;

	[SerializeField]
	private Sprite _downHighlightSprite;

	[SerializeField]
	private Sprite _downDisabledSprite;

	[SerializeField]
	private UnityEvent _onHoldStart;

	[SerializeField]
	private UnityEvent _onHoldEnd;

	private bool _active = true;

	private bool _mouseOver;

	public bool IsDown { get; private set; }

	private void Start()
	{
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
				_button.sprite = (IsDown ? _downDisabledSprite : _disabledSprite);
			}
			else if (_mouseOver)
			{
				_button.sprite = (IsDown ? _downHighlightSprite : _highlightSprite);
			}
			else
			{
				_button.sprite = (IsDown ? _downActiveSprite : _activeSprite);
			}
		}
	}

	public void SetActive(bool active)
	{
		if (_active && !active && IsDown)
		{
			OnMouseUp();
		}
		_active = active;
	}

	private void OnMouseEnter()
	{
		_mouseOver = true;
	}

	private void OnMouseExit()
	{
		_mouseOver = false;
		if (IsDown)
		{
			OnMouseUp();
		}
	}

	private void OnMouseDown()
	{
		if (_active && !IsDown)
		{
			_onHoldStart.Invoke();
			IsDown = true;
		}
	}

	private void OnMouseUp()
	{
		if (_active && IsDown)
		{
			_onHoldEnd.Invoke();
			IsDown = false;
		}
	}
}
