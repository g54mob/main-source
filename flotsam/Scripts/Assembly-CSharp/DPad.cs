using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DPad : MonoBehaviour
{
	[SerializeField]
	private DPadProperties defaultProperties;

	[SerializeField]
	private Image _iconUp;

	[SerializeField]
	private Image _iconRight;

	[SerializeField]
	private Image _iconDown;

	[SerializeField]
	private Image _iconLeft;

	[SerializeField]
	private DPadMenuBase[] _menus;

	[SerializeField]
	private bool _handleInput = true;

	[SerializeField]
	private Tween _tween;

	private DPadProperties _properties;

	private DPadMenuBase _menu;

	private int _menuActionId;

	private void Awake()
	{
		GameEventDispatcher.AddListener(GameEventType.UIFlagsUpdated, OnUIFlagsUpdated);
	}

	private IEnumerator Start()
	{
		while (LoadingScreen.IsLoading)
		{
			yield return null;
		}
		OverrideDPadProperties(null);
	}

	private void LateUpdate()
	{
		if (UIManager.HasFlagsSet(PanelContainerFlags.BlockDPadInput))
		{
			return;
		}
		if ((bool)_menu)
		{
			if (!_menu.HandlesInput)
			{
				if (FlotsamInputManager.GetUICancel())
				{
					_menu.Disable();
				}
				else
				{
					if (!FlotsamInputManager.GetButtonUp(_menu.TriggerAction))
					{
						return;
					}
					_menu.Trigger();
				}
			}
			else if (_menu.isActiveAndEnabled)
			{
				return;
			}
			_menu = null;
		}
		else if (!TryOpenMenu(_properties.Up, 120) && !TryOpenMenu(_properties.Right, 121) && !TryOpenMenu(_properties.Down, 122))
		{
			TryOpenMenu(_properties.Left, 123);
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.UIFlagsUpdated, OnUIFlagsUpdated);
	}

	public void OverrideDPadProperties(DPadProperties dPadProperties)
	{
		if ((bool)_properties)
		{
			_properties.Up?.Disable();
			_properties.Right?.Disable();
			_properties.Down?.Disable();
			_properties.Left?.Disable();
		}
		if (dPadProperties == null)
		{
			_properties = defaultProperties;
		}
		else
		{
			_properties = dPadProperties;
		}
		SetIcon(_iconUp, _properties.Up);
		SetIcon(_iconRight, _properties.Right);
		SetIcon(_iconDown, _properties.Down);
		SetIcon(_iconLeft, _properties.Left);
	}

	public void RemoveOverrideDPadProperties(DPadProperties dPadProperties)
	{
		if (_properties == dPadProperties)
		{
			OverrideDPadProperties(null);
		}
	}

	private void SetIcon(Image image, DPadButtonProperties button)
	{
		if ((bool)button)
		{
			image.gameObject.SetActive(value: true);
			button.Enable(image);
		}
		else
		{
			image.gameObject.SetActive(value: false);
		}
	}

	private bool TryOpenMenu(DPadButtonProperties button, int actionId)
	{
		if (button != null && button.Interactable && FlotsamInputManager.GetButtonDown(actionId) && TryGetMenu(button.MenuId, out _menu))
		{
			_menuActionId = actionId;
			_menu.Enable(actionId, !_handleInput);
			return true;
		}
		return false;
	}

	private bool TryGetMenu(DPadMenuId menuId, out DPadMenuBase menu)
	{
		menu = null;
		DPadMenuBase[] menus = _menus;
		foreach (DPadMenuBase dPadMenuBase in menus)
		{
			if (dPadMenuBase.Id == menuId)
			{
				menu = dPadMenuBase;
				break;
			}
		}
		return menu != null;
	}

	private void OnUIFlagsUpdated(GameEvent gameEvent)
	{
		_tween.Play(UIManager.HasFlagsSet(PanelContainerFlags.BlockDPadInput));
	}
}
