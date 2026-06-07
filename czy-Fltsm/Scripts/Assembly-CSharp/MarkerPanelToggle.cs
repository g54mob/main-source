using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class MarkerPanelToggle : UIBehaviour, IPointerDownHandler, IEventSystemHandler
{
	[SerializeField]
	[Tooltip("The image that displays the toggle on/off icon.")]
	private Image _target;

	[SerializeField]
	[Tooltip("The sprite displayed when the toggle is on.")]
	private Sprite _on;

	[SerializeField]
	[Tooltip("The sprite displayed when the toggle is off.")]
	private Sprite _off;

	[SerializeField]
	[Tooltip("Is the toggle interactable?")]
	private bool _interactable;

	private UnityEvent _onToggleEvent = new UnityEvent();

	public bool IsOn { get; private set; }

	public UnityEvent OnToggleEvent => _onToggleEvent;

	protected override void OnEnable()
	{
		base.OnEnable();
		_target.enabled = true;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		_target.enabled = false;
	}

	public void Toggle(bool isOn, bool invokeOnToggleEvent = true)
	{
		if (isOn)
		{
			_target.sprite = _on;
		}
		else
		{
			_target.sprite = _off;
		}
		IsOn = isOn;
		if (invokeOnToggleEvent)
		{
			_onToggleEvent.Invoke();
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (_interactable && eventData.button == PointerEventData.InputButton.Left)
		{
			Toggle(!IsOn);
		}
	}
}
