using UnityEngine;

namespace NSMedieval
{
	public static class InputUtils
	{
		public static Vector3 GetPosScaled(Vector2 position)
		{
			return new Vector3(Mathf.Clamp(position.x / (float)Screen.width * 2f - 1f, -1f, 1f), Mathf.Clamp(position.y / (float)Screen.height * 2f - 1f, -1f, 1f), 0f);
		}
	}
}
