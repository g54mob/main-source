using UnityEngine;

namespace MG_BlocksEngine2.Core
{
	public interface I_BE2_InputManager
	{
		Vector3 ScreenPointerPosition { get; }

		Vector3 CanvasPointerPosition { get; }

		void OnUpdate();
	}
}
