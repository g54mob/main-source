using UnityEngine;

namespace Cookieverse.CursorPos
{
	public interface ICursorPositionAccessor
	{
		bool IsSupported();

		bool CanConfineToRect();

		void ConfineToRect(Vector2 topLeft, Vector2 bottomRight);

		void ReleaseConfine();

		void Set(Vector2 position);

		Vector2 Get();
	}
}
