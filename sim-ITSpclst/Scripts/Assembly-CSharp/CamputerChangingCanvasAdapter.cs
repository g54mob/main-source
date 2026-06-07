using UnityEngine;

public class CamputerChangingCanvasAdapter : MonoBehaviour
{
	public Camera camera;

	public ComputerChangingCanvasPosition ComputerChangingCanvasPosition;

	public int id;

	public Vector2 mouseRange;

	public Vector2 mouseRangeMaxMargin;

	private void Update()
	{
	}

	public void ChangedCanvas()
	{
	}

	private bool IsMouseOverMonitor()
	{
		return false;
	}

	private void RotateCameraBasedOnMouse()
	{
	}
}
