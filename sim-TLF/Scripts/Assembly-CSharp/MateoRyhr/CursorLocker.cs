using UnityEngine;

namespace MateoRyhr
{
	public class CursorLocker : MonoBehaviour
	{
		private CursorHandler _cursorHandler;

		private void Awake()
		{
			_cursorHandler = new CursorHandler();
		}

		private void OnEnable()
		{
			_cursorHandler.HideCursor();
			_cursorHandler.LockCursor();
		}

		private void OnDisable()
		{
			_cursorHandler.ShowCursor();
			_cursorHandler.ReleaseCursor();
		}
	}
}
