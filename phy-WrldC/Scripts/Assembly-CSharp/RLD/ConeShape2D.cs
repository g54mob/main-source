using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class ConeShape2D : Shape2D
	{
		private Vector2 _baseCenter = ModelBaseCenter;

		private float _rotationDegrees;

		private float _baseRadius = 15f;

		private float _height = 15f;

		public Vector2 BaseCenter
		{
			get
			{
				return _baseCenter;
			}
			set
			{
				_baseCenter = value;
			}
		}

		public Vector2 BaseLeft
		{
			get
			{
				return _baseCenter - Right * _baseRadius;
			}
			set
			{
				_baseCenter = value + Right * _baseRadius;
			}
		}

		public Vector2 BaseRight
		{
			get
			{
				return _baseCenter + Right * _baseRadius;
			}
			set
			{
				_baseCenter = value - Right * _baseRadius;
			}
		}

		public Vector2 Tip
		{
			get
			{
				return _baseCenter + CentralAxis * _height;
			}
			set
			{
				_baseCenter = value - CentralAxis * _height;
			}
		}

		public float BaseRadius
		{
			get
			{
				return _baseRadius;
			}
			set
			{
				_baseRadius = Mathf.Abs(value);
			}
		}

		public float Height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = Mathf.Abs(value);
			}
		}

		public float RotationDegrees
		{
			get
			{
				return _rotationDegrees;
			}
			set
			{
				_rotationDegrees = value % 360f;
			}
		}

		public Quaternion Rotation => Quaternion.AngleAxis(_rotationDegrees, Vector3.forward);

		public Vector2 CentralAxis => Up;

		public Vector2 Right => Rotation * ModelRight;

		public Vector2 Up => Rotation * ModelUp;

		public static Vector2 ModelRight => Vector2.right;

		public static Vector2 ModelUp => Vector2.up;

		public static Vector2 ModelBaseCenter => Vector2.zero;

		public override void RenderArea(Camera camera)
		{
			GLRenderer.DrawTriangleFan2D(BaseLeft, new List<Vector2> { Tip, BaseRight }, camera);
		}

		public override void RenderBorder(Camera camera)
		{
			GLRenderer.DrawLineLoop2D(new List<Vector2> { BaseLeft, Tip, BaseRight }, camera);
		}

		public override bool ContainsPoint(Vector2 point)
		{
			return TriangleMath.Contains2DPoint(point, BaseLeft, Tip, BaseRight);
		}

		public override Rect GetEncapsulatingRect()
		{
			return RectEx.FromPoints(new List<Vector2> { BaseLeft, Tip, BaseRight });
		}
	}
}
