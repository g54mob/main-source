using UnityEngine;

public class VisibilityUIInteractable : UIInteractable
{
	[SerializeField]
	[Tooltip("Game object that will be enabled / disabled when interacting with this UI element.")]
	private GameObject _displayObject;

	public override void Interact()
	{
		base.Interact();
		_displayObject.SetActive(!_displayObject.activeSelf);
	}
}
