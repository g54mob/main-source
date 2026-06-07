using UnityEngine;

public class OverlayUIInteractable : UIInteractable
{
	[SerializeField]
	private Overlays.Type _overlay;

	public override void Interact()
	{
		base.Interact();
		if (Overlays.OverlayType == _overlay)
		{
			Overlays.OverlayType = Overlays.Type.None;
		}
		else
		{
			Overlays.OverlayType = _overlay;
		}
	}
}
