using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[AddComponentMenu("UI/MultiButton", 31)]
public class MultiButton : Button
{
	[Tooltip("Button click event for right mouse clicks.")]
	[SerializeField]
	private ButtonClickedEvent _onRightClick = new ButtonClickedEvent();

	public override void OnPointerClick(PointerEventData eventData)
	{
		switch (eventData.button)
		{
		case PointerEventData.InputButton.Left:
			base.OnPointerClick(eventData);
			break;
		case PointerEventData.InputButton.Right:
			if (IsActive() && IsInteractable())
			{
				UISystemProfilerApi.AddMarker("MultiButton.rightClick", this);
				_onRightClick.Invoke();
			}
			break;
		}
	}
}
