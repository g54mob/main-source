using UnityEngine;

namespace Minigames.Core
{
	public interface IFastener
	{
		RectTransform Transform { get; }

		int Slots { get; }

		float SlotAngle { get; }

		bool IsAlignedWith(ITool tool, float initialOffset, float tolerance);

		void Rotate(float angleDelta);

		float GetCurrentRotation();
	}
}
