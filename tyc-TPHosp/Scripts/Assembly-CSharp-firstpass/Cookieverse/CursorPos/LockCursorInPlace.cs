using UnityEngine;

namespace Cookieverse.CursorPos
{
	public class LockCursorInPlace : MonoBehaviour
	{
		public bool Locked;

		public bool HideCursorWhenLocked = true;

		private bool _windowFocus;

		private bool _wasLocked;

		private Vector2 _lastMousePosition;

		private void Start()
		{
			_windowFocus = Application.isFocused;
			if (CursorPosition.Accessor == null)
			{
				Debug.LogWarning("CursorPosition is not supported on this platform. Falling back to Cursor.LockMode");
			}
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			_windowFocus = hasFocus;
			if (hasFocus)
			{
				try
				{
					_lastMousePosition = CursorPosition.Get();
					return;
				}
				catch (OsCursorException ex)
				{
					Debug.LogError("Failed to get the cursor position: " + ex);
					return;
				}
			}
			TryReleaseConfine();
		}

		private void TryReleaseConfine()
		{
			if (Locked && _wasLocked && CursorPosition.CanConfineToRect())
			{
				CursorPosition.ReleaseConfine();
				_wasLocked = false;
			}
		}

		private void OnDisable()
		{
			TryReleaseConfine();
		}

		private void OnDestroy()
		{
			TryReleaseConfine();
		}

		private void LateUpdate()
		{
			if (CursorPosition.Accessor == null)
			{
				Cursor.visible = !HideCursorWhenLocked || !Locked;
				Cursor.lockState = (Locked ? CursorLockMode.Locked : CursorLockMode.None);
			}
			else
			{
				if (!_windowFocus)
				{
					return;
				}
				if (!_wasLocked)
				{
					try
					{
						_lastMousePosition = CursorPosition.Get();
					}
					catch (OsCursorException ex)
					{
						Debug.LogError("Failed to get the cursor position: " + ex);
						return;
					}
				}
				Cursor.visible = !HideCursorWhenLocked || !Locked;
				if (CursorPosition.CanConfineToRect())
				{
					try
					{
						if (Locked && !_wasLocked)
						{
							CursorPosition.ConfineToRect(_lastMousePosition, _lastMousePosition + new Vector2(1f, 1f));
						}
						else if (!Locked && _wasLocked)
						{
							CursorPosition.ReleaseConfine();
						}
					}
					catch (OsCursorException)
					{
						Debug.LogError("Failed to set/release the cursor confine");
					}
				}
				else if (Locked)
				{
					Cursor.lockState = CursorLockMode.Confined;
					try
					{
						CursorPosition.Set(_lastMousePosition);
					}
					catch (OsCursorException ex3)
					{
						Debug.LogError("Failed to set the cursor position: " + ex3);
					}
				}
				else
				{
					Cursor.lockState = CursorLockMode.None;
				}
				_wasLocked = Locked;
			}
		}

		public void Lock()
		{
			Locked = true;
		}

		public void Unlock()
		{
			Locked = false;
		}

		public void ToggleLock()
		{
			Locked = !Locked;
		}
	}
}
