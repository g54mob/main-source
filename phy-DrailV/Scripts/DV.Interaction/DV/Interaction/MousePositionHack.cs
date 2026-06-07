using System;
using UnityEngine;

namespace DV.Interaction
{
	public class MousePositionHack
	{
		public static bool TryWarpCursorPosition(Vector2 unityScreenPosition)
		{
			try
			{
				Vector2Int vector2Int = new Vector2Int((int)unityScreenPosition.x, Screen.height - (int)unityScreenPosition.y);
				User32.POINT point = default(User32.POINT);
				User32.GetCursorPos(ref point);
				Vector2Int vector2Int2 = new Vector2Int(point.x, point.y);
				Vector2Int vector2Int3 = new Vector2Int((int)Input.mousePosition.x, Screen.height - (int)Input.mousePosition.y);
				Vector2Int vector2Int4 = vector2Int2 - vector2Int3;
				int x = vector2Int.x + vector2Int4.x;
				int y = vector2Int.y + vector2Int4.y;
				User32.SetCursorPos(x, y);
				return true;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return false;
			}
		}
	}
}
