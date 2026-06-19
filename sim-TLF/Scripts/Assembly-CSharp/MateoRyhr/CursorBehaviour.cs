using UnityEngine;

namespace MateoRyhr
{
	public class CursorBehaviour : MonoBehaviour
	{
		private CursorHandler _cursorHandler;

		private void Awake()
		{
			_cursorHandler = new CursorHandler();
		}

		public void HideCursor()
		{
			_cursorHandler.HideCursor();
		}

		public void ShowCursor()
		{
			_cursorHandler.ShowCursor();
		}

		public void ConfinCursor()
		{
			_cursorHandler.ConfinCursor();
		}

		public void LockCursor()
		{
			_cursorHandler.LockCursor();
		}
	}
}
