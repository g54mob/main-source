using UnityEngine;
using UnityEngine.Events;

public class ClickOnTileSlotInput : MonoBehaviour
{
	[SerializeField]
	private UnityEvent onClickOnTileSlot;

	[SerializeField]
	private int mouseButton;

	private MouseController mouseController;

	private void Start()
	{
		mouseController = GetComponent<MouseController>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonUp(mouseButton) && (bool)mouseController.currentTileSlot && mouseController.TilePlacementAllowed)
		{
			onClickOnTileSlot?.Invoke();
		}
	}
}
