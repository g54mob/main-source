using UnityEngine;
using UnityEngine.Serialization;

public class InputDebugger : MonoBehaviour
{
	[FormerlySerializedAs("_inputRouter")]
	[SerializeField]
	private InputRouter inputRouter;

	private void Start()
	{
		inputRouter.OnMovePreviewTile += Debug_MoveTile;
		inputRouter.OnPlaceTile += Debug_PlaceTile;
		inputRouter.OnZoomCamera += Debug_Zoom;
		inputRouter.OnRotateCamera += Debug_RotateCamera;
		inputRouter.OnRotatePreviewTile += Debug_SwitchPreview;
	}

	private void Debug_OpenIngameMenu()
	{
		Debug.Log("Open Ingame menu");
	}

	private void Debug_SwitchPreview(int obj)
	{
		Debug.Log("Switch preview " + obj);
	}

	private void Debug_RotateCamera(Vector2 obj)
	{
		Vector2 vector = obj;
		Debug.Log("Rotate Camera " + vector.ToString());
	}

	private void Debug_Zoom(float amount)
	{
		Debug.Log("Zoom " + amount);
	}

	private void Debug_PlaceTile(TileSlot slot)
	{
		Debug.Log("Click on " + slot);
	}

	private void Debug_MoveTile(TileSlot slot)
	{
		Debug.Log("Hover over " + slot);
	}

	private void OnDestroy()
	{
		inputRouter.OnMovePreviewTile -= Debug_MoveTile;
		inputRouter.OnPlaceTile -= Debug_PlaceTile;
		inputRouter.OnZoomCamera -= Debug_Zoom;
		inputRouter.OnRotateCamera -= Debug_RotateCamera;
		inputRouter.OnRotatePreviewTile -= Debug_SwitchPreview;
	}
}
