using UnityEngine;
using UnityEngine.Events;

public class RewiredInteractable : RewiredComponent
{
	[Header("Rewired Interactable")]
	[SerializeField]
	private UnityEvent _onButtonDown;

	[SerializeField]
	private UnityEvent _onButtonUp;

	public UnityEvent ButtonUpEvent => _onButtonUp;

	protected override void OnButtonDown()
	{
		_onButtonDown.Invoke();
	}

	protected override void OnButtonUp()
	{
		_onButtonUp.Invoke();
	}
}
