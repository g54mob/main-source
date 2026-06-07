using UnityEngine;

public class CursorPropertyUIInteractable : UIInteractable
{
	[Tooltip("Cursor properties of the marker that will be activated when interacting with this UI element.")]
	[SerializeField]
	private CursorProperties _cursorProperties;

	public override void Interact()
	{
		base.Interact();
		if (GameManager.CursorManager.Properties == _cursorProperties)
		{
			GameManager.CursorManager.Deactivate(cancelled: true);
		}
		else
		{
			GameManager.CursorManager.Activate(_cursorProperties);
		}
	}
}
