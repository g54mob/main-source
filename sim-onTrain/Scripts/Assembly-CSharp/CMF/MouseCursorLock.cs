using UnityEngine;

namespace CMF
{
	public class MouseCursorLock : MonoBehaviour
	{
		public bool lockCursorAtGameStart = true;

		public KeyCode unlockKeyCode = KeyCode.Escape;

		public KeyCode lockKeyCode = KeyCode.Mouse0;

		private void Start()
		{
		}
	}
}
