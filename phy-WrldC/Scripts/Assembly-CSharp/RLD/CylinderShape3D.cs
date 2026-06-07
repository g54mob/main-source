using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class CylinderShape3D : Shape3D
	{
		private Vector3 _baseCenter = ModelBaseCenter;

		private float _radius = 1f;

		private float _height = 1f;

		private Quaternion _rotation = Quaternion.identity;

		private CylinderEpsilon _epsilon;

		public Vector3 BaseCenter
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

		public Vector3 TopCenter
		{
			get
			{
				return _baseCenter + CentralAxis * _height;
			}
			set
			{
				BaseCenter = value - CentralAxis * _height;
			}
		}

		public Vector3 Center
		{
			get
			{
				return _baseCenter + CentralAxis * _height * 0.5f;
			}
			set
			{
				BaseCenter = value - CentralAxis * _height * 0.5f;
			}
		}

		public float Radius
		{
			get
			{
				return _radius;
			}
			set
			{
				_radius = Mathf.Abs(value);
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

		public CylinderEpsilon Epsilon
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

		public float RadiusEps
		{
			get
			{
				return _epsilon.RadiusEps;
			}
			set
			{
				_epsilon.RadiusEps = value;
			}
		}

		public float VertEps
		{
			get
			{
				return _epsilon.VertEps;
			}
			set
			{
				_epsilon.VertEps = value;
			}
		}

		public Vector3 CentralAxis => _rotation * ModelUp;

		public Vector3 Right => _rotation * ModelRight;

		public Vector3 Up => _rotation * ModelUp;

		public Vector3 Look => _rotation * ModelLook;

		public static Vector3 ModelRight => Vector3.right;

		public static Vector3 ModelUp => Vector3.up;

		public static Vector3 ModelLook => Vector3.forward;

		public static Vector3 ModelBaseCenter => Vector3.zero;

		public void AlignCentralAxis(Vector3 axis)
		{
			Rotation = QuaternionEx.FromToRotation3D(CentralAxis, axis, Look) * _rotation;
		}

		public override void RenderSolid()
		{
			Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitCylinder, Matrix4x4.TRS(_baseCenter, _rotation, new Vector3(_radius, _height, _radius)));
		}

		public override void RenderWire()
		{
			Vector3 s = new Vector3(_radius, _radius, 1f);
			Quaternion q = _rotation * Quaternion.AngleAxis(90f, Vector3.right);
			Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitWireCircleXY, Matrix4x4.TRS(_baseCenter, q, s));
			Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitWireCircleXY, Matrix4x4.TRS(TopCenter, q, s));
			List<Vector3> bottomCapExtentPoints = GetBottomCapExtentPoints();
			List<Vector3> topCapExtentPoints = GetTopCapExtentPoints();
			GLRenderer.DrawLinePairs3D(new List<Vector3>
			{
				bottomCapExtentPoints[0],
				topCapExtentPoints[0],
				bottomCapExtentPoints[1],
				topCapExtentPoints[1],
				bottomCapExtentPoints[2],
				topCapExtentPoints[2],
				bottomCapExtentPoints[3],
				topCapExtentPoints[3]
			});
		}

		public override bool Raycast(Ray ray, out float t)
		{
			return CylinderMath.Raycast(ray, out t, _baseCenter, TopCenter, _radius, _height, _epsilon);
		}

		public bool ContainsPoint(Vector3 point)
		{
			return CylinderMath.ContainsPoint(point, _baseCenter, TopCenter, _radius, _height, _epsilon);
		}

		public List<Vector3> GetBottomCapExtentPoints()
		{
			return CylinderMath.CalcExtentPoints(_baseCenter, _radius, _rotation);
		}

		public List<Vector3> GetTopCapExtentPoints()
		{
			return CylinderMath.CalcExtentPoints(TopCenter, _radius, _rotation);
		}

		public AABB GetModelAABB()
		{
			float num = _radius * 2f;
			return new AABB(ModelBaseCenter + ModelUp * _height * 2f, new Vector3(num, _height, num));
		}

		public override AABB GetAABB()
		{
			AABB modelAABB = GetModelAABB();
			modelAABB.Transform(Matrix4x4.TRS(_baseCenter, _rotation, Vector3.one));
			return modelAABB;
		}
	}
}
