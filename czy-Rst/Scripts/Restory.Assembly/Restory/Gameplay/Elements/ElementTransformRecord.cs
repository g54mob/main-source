using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public record ElementTransformRecord
	{
		public readonly ElementBase Element;

		public readonly Vector3 Position;

		public readonly Quaternion Rotation;

		public ElementTransformRecord(ElementBase element, Vector3 position, Quaternion rotation)
		{
			Element = element;
			Position = position;
			Rotation = rotation;
		}
	}
}
