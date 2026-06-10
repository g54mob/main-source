using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PinnedPinButtonController : ButtonController, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Image mainColour;

	public Image mainOverlay;

	public Image pressedColour;

	public Image pressedOverlay;

	public RectTransform mainMOOverlay;

	public Sprite pinnedOverlay;

	public Sprite pinnedOverlayMO;

	public PinnedItemController pinnedController;

	public void Setup(PinnedItemController newItem)
	{
	}

	public void UpdatePinColour()
	{
	}

	private void OnEnable()
	{
	}

	public override void OnLeftClick()
	{
	}

	public override void OnLeftDoubleClick()
	{
	}
}
