using UnityEngine;

namespace Minigames.Core
{
	public class WrenchTool : MonoBehaviour, ITool
	{
		[SerializeField]
		private RectTransform _transform;

		[SerializeField]
		private RectTransform _jawPoint;

		[SerializeField]
		private float _rotationOffset;

		[SerializeField]
		private float _snapDistance = 40f;

		public RectTransform Transform => _transform;

		public RectTransform InteractionPoint => _jawPoint;

		public float RotationOffset => _rotationOffset;

		public float SnapDistance => _snapDistance;

		public void UpdatePosition(Vector2 localPosition)
		{
			_transform.localPosition = localPosition;
		}

		public void UpdateRotation(float angle)
		{
			_transform.rotation = Quaternion.Euler(0f, 0f, angle + _rotationOffset);
		}

		public bool CanEngage(IFastener fastener)
		{
			return Vector2.Distance(_jawPoint.position, fastener.Transform.position) <= _snapDistance;
		}

		public bool IsFacingFastener(IFastener fastener, float tolerance)
		{
			Vector2 vector = (_jawPoint.position - _transform.position).normalized;
			Vector2 to = (fastener.Transform.position - _jawPoint.position).normalized;
			return Vector2.Angle(vector, to) <= tolerance;
		}
	}
}
