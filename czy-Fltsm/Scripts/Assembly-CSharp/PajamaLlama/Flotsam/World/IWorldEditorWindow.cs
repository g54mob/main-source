using UnityEngine;

namespace PajamaLlama.Flotsam.World
{
	public interface IWorldEditorWindow
	{
		bool TryGetDataObject<T>(out T tileGenerator) where T : Object;

		Vector2 ReturnWorldToWindowPosition(Vector2 worldPosition);

		float ReturnWorldToWindow(float value);

		Vector2 ReturnWindowToWorldPosition(Vector2 windowPosition);

		Vector2 ReturnWindowToWorld(Vector2 point, bool flipY = false);

		Rect ToWindowSpace(Rect rect);
	}
}
