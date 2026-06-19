using System;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public struct MyCursor
	{
		public Texture2D Texture;

		public Vector2 Hotspot;

		public void ApplyAsLockedCursor()
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.SetCursor(Texture, Hotspot, CursorMode.ForceSoftware);
		}

		public void ApplyAsFreeCursor()
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			Cursor.SetCursor(Texture, Hotspot, CursorMode.ForceSoftware);
		}

		public void ApplyAsConfinedCursor()
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.SetCursor(Texture, Hotspot, CursorMode.ForceSoftware);
		}
	}
}
