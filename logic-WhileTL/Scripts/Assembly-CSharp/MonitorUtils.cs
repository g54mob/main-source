using System.Drawing;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.InputSystem;

public static class MonitorUtils
{
	private static Camera _mainCamera;

	private static readonly Vector3[] corners = new Vector3[4];

	public static void GetMonitorRectCorners(this RectTransform rectTransform, Vector2Int[] output, bool isScreenSpaceCanvas = true, Camera camera = null)
	{
		if (!camera)
		{
			camera = GetMainCamera();
		}
		Vector2 position = Mouse.current.position.ReadValue();
		rectTransform.GetWorldCorners(corners);
		for (int i = 0; i < 4; i++)
		{
			if (!isScreenSpaceCanvas)
			{
				output[i] = WorldToMonitorPoint(corners[i], camera);
			}
			else
			{
				output[i] = ScreenToMonitorPoint(corners[i], camera);
			}
		}
		Mouse.current.WarpCursorPosition(position);
	}

	public static Vector2Int WorldToMonitorPoint(Vector3 worldPoint, Camera camera = null)
	{
		if (!camera)
		{
			camera = GetMainCamera();
		}
		return ScreenToMonitorPoint(camera.WorldToScreenPoint(worldPoint), camera);
	}

	public static Vector2Int ScreenToMonitorPoint(Vector3 screenPos, Camera camera = null)
	{
		if (!camera)
		{
			camera = GetMainCamera();
		}
		if (Mouse.current == null)
		{
			Debug.LogError("WTF mouse, ignoring snap");
			return -Vector2Int.one;
		}
		Mouse.current.WarpCursorPosition(screenPos);
		return GetSystemMousePosition();
	}

	private static Camera GetMainCamera()
	{
		if (!_mainCamera)
		{
			_mainCamera = Camera.main;
		}
		return _mainCamera;
	}

	private static Vector2Int GetSystemMousePosition()
	{
		Point position = System.Windows.Forms.Cursor.Position;
		return new Vector2Int(position.X, position.Y);
	}
}
