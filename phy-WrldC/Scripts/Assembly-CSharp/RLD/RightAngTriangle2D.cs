using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class RightAngTriangle2D : Shape2D
	{
		private Vector2 _rightAngleCorner = ModelRightAngleCorner;

		private float _XLength = 1f;

		private float _YLength = 1f;

		private float _rotationDegrees;

		private TriangleEpsilon _epsilon;

		public Vector2 RightAngleCorner
		{
			get
			{
				return _rightAngleCorner;
			}
			set
			{
				_rightAngleCorner = value;
			}
		}

		public float XLength
		{
			get
			{
				return _XLength;
			}
			set
			{
				_XLength = Mathf.Abs(value);
			}
		}

		public float YLength
		{
			get
			{
				return _YLength;
			}
			set
			{
				_YLength = Mathf.Abs(value);
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
				_rotationDegrees = value;
			}
		}

		public Vector2 Right => Quaternion.AngleAxis(_rotationDegrees, Vector3.forward) * ModelRight;

		public Vector2 Up => Quaternion.AngleAxis(_rotationDegrees, Vector3.forward) * ModelUp;

		public TriangleEpsilon Epsilon
		{
			get
			{
				return _epsilon;
			}
			set
			{
				_epsilon = value;
			}
		}

		public float AreaEps
		{
			get
			{
				return _epsilon.AreaEps;
			}
			set
			{
				_epsilon.AreaEps = value;
			}
		}

		public static Vector2 ModelRight => Vector2.right;

		public static Vector2 ModelUp => Vector2.up;

		public static Vector2 ModelRightAngleCorner => Vector2.zero;

		public override void RenderArea(Camera camera)
		{
			List<Vector2> points = GetPoints();
			Vector2 origin = points[0];
			points.RemoveAt(0);
			GLRenderer.DrawTriangleFan2D(origin, points, camera);
		}

		public override void RenderBorder(Camera camera)
		{
			GLRenderer.DrawLineLoop2D(GetPoints(), camera);
		}

		public List<Vector2> GetPoints()
		{
			return TriangleMath.CalcRATriangle2DPoints(_rightAngleCorner, _XLength, _YLength, _rotationDegrees);
		}

		public override bool ContainsPoint(Vector2 point)
		{
			List<Vector2> points = GetPoints();
			return TriangleMath.Contains2DPoint(point, points[0], points[1], points[2], _epsilon);
		}

		public override Rect GetEncapsulatingRect()
		{
			return RectEx.FromPoints(GetPoints());
		}
	}
}
