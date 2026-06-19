using UnityEngine;

namespace Cookieverse.CursorPos
{
	public static class CursorPosition
	{
		public static ICursorPositionAccessor Accessor;

		static CursorPosition()
		{
			ICursorPositionAccessor[] array = new ICursorPositionAccessor[3]
			{
				new WinCursorPositionAccessor(),
				new OSXCursorPositionAccessor(),
				new X11CursorPositionAccessor()
			};
			foreach (ICursorPositionAccessor cursorPositionAccessor in array)
			{
				if (cursorPositionAccessor.IsSupported())
				{
					Accessor = cursorPositionAccessor;
					break;
				}
			}
			if (Accessor == null)
			{
				Debug.LogWarning("The selected OS is not supported by Cookieverse.CursorPos");
			}
		}

		public static bool CanConfineToRect()
		{
			if (Accessor == null)
			{
				throw new OsCursorException("Unsupported Operating System");
			}
			return Accessor.CanConfineToRect();
		}

		public static void ConfineToRect(Vector2 topLeft, Vector2 bottomRight)
		{
			if (Accessor == null)
			{
				throw new OsCursorException("Unsupported Operating System");
			}
			Accessor.ConfineToRect(topLeft, bottomRight);
		}

		public static void ReleaseConfine()
		{
			if (Accessor == null)
			{
				throw new OsCursorException("Unsupported Operating System");
			}
			Accessor.ReleaseConfine();
		}

		public static void Set(Vector2 position)
		{
			if (Accessor == null)
			{
				throw new OsCursorException("Unsupported Operating System");
			}
			Accessor.Set(position);
		}

		public static Vector2 Get()
		{
			if (Accessor == null)
			{
				throw new OsCursorException("Unsupported Operating System");
			}
			return Accessor.Get();
		}
	}
}
