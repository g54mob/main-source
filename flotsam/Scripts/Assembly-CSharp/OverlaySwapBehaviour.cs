using UnityEngine;

public abstract class OverlaySwapBehaviour : MonoBehaviour
{
	[SerializeField]
	protected Overlays.Type _type;

	private void OnEnable()
	{
		Swap(Overlays.OverlayType);
		GameEventDispatcher.AddListener(GameEventType.OverlayUpdate, OnOverlayToggled);
	}

	private void OnDisable()
	{
		Swap(Overlays.OverlayType);
		GameEventDispatcher.RemoveListener(GameEventType.OverlayUpdate, OnOverlayToggled);
	}

	protected abstract void Swap(Overlays.Type overlayType);

	private void OnOverlayToggled(GameEvent gameEvent)
	{
		OverlayEvent overlayEvent = gameEvent as OverlayEvent;
		Swap(overlayEvent.OverlayType);
	}
}
