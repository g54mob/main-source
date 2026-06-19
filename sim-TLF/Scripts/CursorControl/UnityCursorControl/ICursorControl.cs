using UnityEngine;

namespace UnityCursorControl
{
	internal interface ICursorControl
	{
		Vector2 GetGlobalCursorPos();

		void SetGlobalCursorPos(Vector2 pos);

		void SetLocalCursorPos(Vector2 pos);

		void SimulateLeftClick();

		void SimulateMiddleClick();

		void SimulateRightClick();
	}
}
