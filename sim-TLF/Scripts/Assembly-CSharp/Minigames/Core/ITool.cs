using UnityEngine;

namespace Minigames.Core
{
	public interface ITool
	{
		RectTransform Transform { get; }

		RectTransform InteractionPoint { get; }

		float RotationOffset { get; }

		void UpdatePosition(Vector2 localPosition);

		void UpdateRotation(float angle);

		bool CanEngage(IFastener fastener);
	}
}
