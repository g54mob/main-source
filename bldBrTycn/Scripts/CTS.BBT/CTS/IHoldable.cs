using UnityEngine;

namespace CTS
{
	public interface IHoldable<T> where T : Component
	{
		float Weight { get; }

		bool IsHeld { get; }

		bool TryGrabHoldable(T p_parent);

		void DropHoldable();
	}
}
