using Assets.Source.Player;
using UnityEngine;

public class SecretButton : MonoBehaviour
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
	private int _secretId;

	[SerializeField]
	private Collider2D _collider;

	private bool _active = true;

	private bool _mouseOver;

	private void Start()
	{
		if (GamePlayer.Current.GetSecretButton(_secretId))
		{
			_active = false;
		}
	}

	private void Update()
	{
		if ((bool)_button)
		{
			_collider.enabled = _active;
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
		if (!GamePlayer.Current.GetSecretButton(_secretId))
		{
			_active = active;
		}
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
			GamePlayer.Current.TriggerSecretButton(_secretId);
			_active = false;
		}
	}

	private void OnMouseUpAsButton()
	{
		_buttonClicked();
	}
}
