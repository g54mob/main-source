using Helpers.Extensions;
using UnityEngine;

namespace Mandragora.Utils
{
	public static class CursorUtils
	{
		public static void SetScaledIcon(Texture2D texture)
		{
			Vector2Int vector2Int = texture.SizeProportionalToScreen(3840f, 2160f);
			texture = texture.ScaledTexture(vector2Int.x, vector2Int.y);
			SetIcon(texture);
		}

		public static void SetIcon(Texture2D targetTexture, CursorMode mode = CursorMode.ForceSoftware)
		{
			Cursor.SetCursor(targetTexture, new Vector2((float)targetTexture.width / 2f, (float)targetTexture.height / 2f), mode);
		}
	}
}
