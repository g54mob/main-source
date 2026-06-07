using MEC;
using UnityEngine;
using UnityEngine.UI;

public class ControllerCursorUI : MonoBehaviour
{
	public static ControllerCursorUI I;

	public Canvas Cvs;

	public CanvasScaler CvsScaler;

	public GraphicRaycaster Raycaster;

	public Image Img;

	public RectTransform Xfm;

	private CoroutineHandle _updateAnim;

	public void Activate()
	{
	}

	private void MyUpdate()
	{
	}

	public Vector3 GetWorldPos()
	{
		return default(Vector3);
	}

	public void Deactivate()
	{
	}

	public bool IsActive()
	{
		return false;
	}

	public void SetPos(Vector2 pos)
	{
	}

	public void MovePos(Vector2 dir)
	{
	}

	public Vector2 GetScreenPos()
	{
		return default(Vector2);
	}
}
