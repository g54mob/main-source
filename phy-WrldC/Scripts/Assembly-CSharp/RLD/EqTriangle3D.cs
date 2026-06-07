using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class EqTriangle3D : Shape3D
	{
		private float _sideLength = 1f;

		private Quaternion _rotation = Quaternion.identity;

		private TriangleEpsilon _epsilon;

		private Vector3[] _points = new Vector3[3];

		private Vector3 _centroid = ModelCentroid;

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

		public Vector3 Centroid
		{
			get
			{
				return _centroid;
			}
			set
			{
				Vector3 vector = value - _centroid;
				_centroid = value;
				_points[0] += vector;
				_points[1] += vector;
				_points[2] += vector;
			}
		}

		public float Altitude => _sideLength * TriangleMath.EqTriangleAltFactor;

		public float CentroidAltitude => Altitude / 3f;

		public Quaternion Rotation
		{
			get
			{
				return _rotation;
			}
			set
			{
				_rotation = value;
			}
		}

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

		public float ExtrudeEps
		{
			get
			{
				return _epsilon.ExtrudeEps;
			}
			set
			{
				_epsilon.ExtrudeEps = value;
			}
		}

		public float WireEps
		{
			get
			{
				return _epsilon.WireEps;
			}
			set
			{
				_epsilon.WireEps = value;
			}
		}

		public Vector3 Normal => Look;

		public Vector3 Right => _rotation * ModelRight;

		public Vector3 Up => _rotation * ModelUp;

		public Vector3 Look => _rotation * ModelLook;

		public static Vector3 ModelRight => Vector3.right;

		public static Vector3 ModelUp => Vector3.up;

		public static Vector3 ModelLook => Vector3.forward;

		public static Vector3 ModelCentroid => Vector3.zero;

		public void AlignNormal(Vector3 axis)
		{
			Rotation = QuaternionEx.FromToRotation3D(Normal, axis, Right) * _rotation;
		}

		public void AlignRight(Vector3 axis)
		{
			Rotation = QuaternionEx.FromToRotation3D(Right, axis, Up) * _rotation;
		}

		public void AlignUp(Vector3 axis)
		{
			Rotation = QuaternionEx.FromToRotation3D(Up, axis, Normal) * _rotation;
		}

		public Vector3 GetPoint(EqTrianglePoint point)
		{
			if (_arePointsDirty)
			{
				OnPointsFoundDirty();
			}
			return _points[(int)point];
		}

		public void SetPoint(EqTrianglePoint point, Vector3 pointValue)
		{
			Vector3 vector = pointValue - GetPoint(point);
			_points[0] += vector;
			_points[1] += vector;
			_points[2] += vector;
		}

		public Vector3 GetEdgeMidPoint(EqTriangleEdge edge)
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

		public Vector3 GetEdge(EqTriangleEdge edge)
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

		public override void RenderSolid()
		{
			Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitEqTriangleXY, Matrix4x4.TRS(_centroid, _rotation, new Vector3(_sideLength, _sideLength, 1f)));
		}

		public override void RenderWire()
		{
			Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitWireEqTriangleXY, Matrix4x4.TRS(_centroid, _rotation, new Vector3(_sideLength, _sideLength, 1f)));
		}

		public override bool Raycast(Ray ray, out float t)
		{
			return TriangleMath.Raycast(ray, out t, GetPoint(EqTrianglePoint.Left), GetPoint(EqTrianglePoint.Top), GetPoint(EqTrianglePoint.Right), _epsilon);
		}

		public override bool RaycastWire(Ray ray, out float t)
		{
			return TriangleMath.RaycastWire(ray, out t, GetPoint(EqTrianglePoint.Left), GetPoint(EqTrianglePoint.Top), GetPoint(EqTrianglePoint.Right), _epsilon);
		}

		public override AABB GetAABB()
		{
			if (_arePointsDirty)
			{
				OnPointsFoundDirty();
			}
			return new AABB(_points);
		}

		private void OnPointsFoundDirty()
		{
			List<Vector3> list = TriangleMath.CalcEqTriangle3DPoints(_centroid, _sideLength, _rotation);
			_points[0] = list[0];
			_points[1] = list[1];
			_points[2] = list[2];
			_arePointsDirty = false;
		}
	}
}
