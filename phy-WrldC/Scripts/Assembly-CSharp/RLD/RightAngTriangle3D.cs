using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class RightAngTriangle3D : Shape3D
	{
		private Vector3 _rightAngleCorner = ModelRightAngleCorner;

		private float _XLength = 1f;

		private float _YLength = 1f;

		private AxisSign _XLengthSign;

		private AxisSign _YLengthSign;

		private Quaternion _rotation = Quaternion.identity;

		private TriangleEpsilon _epsilon;

		private Shape3DRaycastMode _raycastMode;

		public Vector3 RightAngleCorner
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

		public float RealXLength => _XLength * ((_XLengthSign == AxisSign.Positive) ? 1f : (-1f));

		public float RealYLength => _YLength * ((_YLengthSign == AxisSign.Positive) ? 1f : (-1f));

		public AxisSign XLengthSign
		{
			get
			{
				return _XLengthSign;
			}
			set
			{
				_XLengthSign = value;
			}
		}

		public AxisSign YLengthSign
		{
			get
			{
				return _YLengthSign;
			}
			set
			{
				_YLengthSign = value;
			}
		}

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

		public Vector3 Right => _rotation * ModelRight;

		public Vector3 Up => _rotation * ModelUp;

		public Vector3 Look => _rotation * ModelLook;

		public Vector3 Normal => Look;

		public Plane Plane => new Plane(Normal, RightAngleCorner);

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

		public Shape3DRaycastMode RaycastMode
		{
			get
			{
				return _raycastMode;
			}
			set
			{
				_raycastMode = value;
			}
		}

		public static Vector3 ModelRight => Vector3.right;

		public static Vector3 ModelUp => Vector3.up;

		public static Vector3 ModelLook => Vector3.forward;

		public static Vector3 ModelRightAngleCorner => Vector3.zero;

		public static Vector3 ModelNormal => ModelLook;

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

		public override bool Raycast(Ray ray, out float t)
		{
			List<Vector3> points = GetPoints();
			if (_raycastMode == Shape3DRaycastMode.Solid)
			{
				return TriangleMath.Raycast(ray, out t, points[0], points[1], points[2], _epsilon);
			}
			return TriangleMath.RaycastWire(ray, out t, points[0], points[1], points[2], _epsilon);
		}

		public override bool RaycastWire(Ray ray, out float t)
		{
			List<Vector3> points = GetPoints();
			return TriangleMath.RaycastWire(ray, out t, points[0], points[1], points[2], _epsilon);
		}

		public override void RenderSolid()
		{
			Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitRightAngledTriangleXY, Matrix4x4.TRS(_rightAngleCorner, _rotation, new Vector3(RealXLength, RealYLength, 1f)));
		}

		public override void RenderWire()
		{
			Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitWireRightAngledTriangleXY, Matrix4x4.TRS(_rightAngleCorner, _rotation, new Vector3(RealXLength, RealYLength, 1f)));
		}

		public List<Vector3> GetPoints()
		{
			return TriangleMath.CalcRATriangle3DPoints(_rightAngleCorner, RealXLength, RealYLength, _rotation);
		}

		public override AABB GetAABB()
		{
			return new AABB(GetPoints());
		}

		public bool ContainsPoint(Vector3 point, bool checkOnPlane)
		{
			List<Vector3> points = GetPoints();
			return TriangleMath.Contains3DPoint(point, checkOnPlane, points[0], points[1], points[2], _epsilon);
		}
	}
}
