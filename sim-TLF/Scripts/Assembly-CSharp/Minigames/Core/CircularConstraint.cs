using UnityEngine;

namespace Minigames.Core
{
	public class CircularConstraint
	{
		private RectTransform _parentTransform;

		private RectTransform _centerTransform;

		public CircularConstraint(RectTransform parentTransform, RectTransform centerTransform)
		{
			_parentTransform = parentTransform;
			_centerTransform = centerTransform;
		}

		public Vector2 ClampToCircle(Vector2 desiredLocalPos, float radius)
		{
			Vector2 vector = _parentTransform.TransformPoint(desiredLocalPos);
			Vector2 vector2 = _centerTransform.position;
			Vector2 vector3 = vector - vector2;
			if (vector3.magnitude < radius)
			{
				Vector2 vector4 = vector2 + vector3.normalized * radius;
				return _parentTransform.InverseTransformPoint(vector4);
			}
			return desiredLocalPos;
		}

		public Vector2 ClampToRing(Vector2 desiredLocalPos, float innerRadius, float outerRadius)
		{
			Vector2 vector = _parentTransform.TransformPoint(desiredLocalPos);
			Vector2 vector2 = _centerTransform.position;
			Vector2 vector3 = vector - vector2;
			float magnitude = vector3.magnitude;
			if (magnitude < innerRadius)
			{
				Vector2 vector4 = vector2 + vector3.normalized * innerRadius;
				return _parentTransform.InverseTransformPoint(vector4);
			}
			if (magnitude > outerRadius)
			{
				Vector2 vector5 = vector2 + vector3.normalized * outerRadius;
				return _parentTransform.InverseTransformPoint(vector5);
			}
			return desiredLocalPos;
		}

		public bool IsInRing(Vector2 worldPos, float innerRadius, float outerRadius)
		{
			float num = Vector2.Distance(worldPos, _centerTransform.position);
			if (num >= innerRadius)
			{
				return num <= outerRadius;
			}
			return false;
		}

		public float GetAngleAroundCenter(Vector2 worldPos)
		{
			Vector2 vector = worldPos - (Vector2)_centerTransform.position;
			return Mathf.Atan2(vector.y, vector.x) * 57.29578f;
		}
	}
}
