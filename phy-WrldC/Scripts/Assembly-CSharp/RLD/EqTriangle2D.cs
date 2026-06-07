using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class EqTriangle2D : Shape2D
	{
		private float _sideLength = 1f;

		private float _rotationDegrees;

		private TriangleEpsilon _epsilon;

		private Vector2[] _points = new Vector2[3];

		private Vector2 _centroid = ModelCentroid;

		private bool _arePointsDirty = true;

		public float SideLength
		{
			get
			{
				return _sideLength;
			}
			set
			{
				_sideLength = Mathf.Abs(value);
				_arePointsDirty = true;
			}
		}

		public Vector2 Centroid
		{
			get
			{
				return _centroid;
			}
			set
			{
				Vector2 vector = value - _centroid;
				_centroid = value;
				_points[0] += vector;
				_points[1] += vector;
				_points[2] += vector;
			}
		}

		public float Altitude => _sideLength * TriangleMath.EqTriangleAltFactor;

		public float CentroidAltitude => Altitude / 3f;

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

		public Quaternion Rotation => Quaternion.AngleAxis(_rotationDegrees, Vector3.forward);

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

		public Vector2 Right => Quaternion.AngleAxis(_rotationDegrees, Vector3.forward) * ModelRight;

		public Vector2 Up => Quaternion.AngleAxis(_rotationDegrees, Vector3.forward) * ModelUp;

		public static Vector2 ModelRight => Vector2.right;

		public static Vector2 ModelUp => Vector2.up;

		public static Vector2 ModelCentroid => Vector2.zero;

		public Vector2 GetPoint(EqTrianglePoint point)
		{
			if (_arePointsDirty)
			{
				OnPointsFoundDirty();
			}
			return _points[(int)point];
		}

		public void SetPoint(EqTrianglePoint point, Vector2 pointValue)
		{
			Vector2 vector = pointValue - GetPoint(point);
			_points[0] += vector;
			_points[1] += vector;
			_points[2] += vector;
		}

		public Vector2 GetEdgeMidPoint(EqTriangleEdge edge)
		{
			switch (edge)
			{
			case EqTriangleEdge.LeftTop:
				return GetPoint(EqTrianglePoint.Left) + GetEdge(edge).normalized * 0.5f;
			case EqTriangleEdge.TopRight:
				return GetPoint(EqTrianglePoint.Top) + GetEdge(edge).normalized * 0.5f;
			default:
				return GetPoint(EqTrianglePoint.Right) + GetEdge(edge).normalized * 0.5f;
			}
		}

		public Vector2 GetEdge(EqTriangleEdge edge)
		{
			switch (edge)
			{
			case EqTriangleEdge.LeftTop:
				return GetPoint(EqTrianglePoint.Top) - GetPoint(EqTrianglePoint.Left);
			case EqTriangleEdge.TopRight:
				return GetPoint(EqTrianglePoint.Right) - GetPoint(EqTrianglePoint.Top);
			default:
				return GetPoint(EqTrianglePoint.Left) - GetPoint(EqTrianglePoint.Right);
			}
		}

		public override void RenderArea(Camera camera)
		{
			GLRenderer.DrawTriangleFan2D(GetPoint(EqTrianglePoint.Left), new List<Vector2>
			{
				GetPoint(EqTrianglePoint.Top),
				GetPoint(EqTrianglePoint.Right)
			}, camera);
		}

		public override void RenderBorder(Camera camera)
		{
			GLRenderer.DrawLineLoop2D(new List<Vector2>
			{
				GetPoint(EqTrianglePoint.Left),
				GetPoint(EqTrianglePoint.Top),
				GetPoint(EqTrianglePoint.Right)
			}, camera);
		}

		public override bool ContainsPoint(Vector2 point)
		{
			return TriangleMath.Contains2DPoint(point, GetPoint(EqTrianglePoint.Left), GetPoint(EqTrianglePoint.Top), GetPoint(EqTrianglePoint.Right), _epsilon);
		}

		public override Rect GetEncapsulatingRect()
		{
			if (_arePointsDirty)
			{
				OnPointsFoundDirty();
			}
			return RectEx.FromPoints(_points);
		}

		private void OnPointsFoundDirty()
		{
			List<Vector2> list = TriangleMath.CalcEqTriangle2DPoints(_centroid, _sideLength, Rotation);
			_points[0] = list[0];
			_points[1] = list[1];
			_points[2] = list[2];
			_arePointsDirty = false;
		}
	}
}
