using UnityEngine;
using UnityEngine.EventSystems;

public class CustomInputModule : StandaloneInputModule
{
	public delegate void PressChangeDelegate(bool dragState);

	public PressChangeDelegate pressChangeDelegate;

	private GameObject lastHighlightedObject;

	protected override void Awake()
	{
		base.Awake();
	}

	public override void Process()
	{
		base.Process();
		MouseButtonEventData eventData = GetMousePointerEventData(0).GetButtonState(PointerEventData.InputButton.Left).eventData;
		if (eventData.PressedThisFrame())
		{
			pressChangeDelegate?.Invoke(dragState: true);
		}
		else if (eventData.ReleasedThisFrame())
		{
			pressChangeDelegate?.Invoke(dragState: false);
		}
		GameObject gameObject = eventData.buttonData.pointerCurrentRaycast.gameObject;
		if (gameObject != lastHighlightedObject)
		{
			lastHighlightedObject = gameObject;
			MenuManager.Instance.SetHighlighted(lastHighlightedObject);
		}
	}
}
