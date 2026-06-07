using UnityEngine;

namespace RLD
{
	public class SphereShape3D : Shape3D
	{
		public enum WireRenderMode
		{
			Basic = 0,
			Detailed = 1
		}

		public class WireRenderDescriptor
		{
			private WireRenderMode _wireMode;

			private int _numDetailAxialRings = 20;

			private int _numDetailSliceRings = 20;

			private float _radiusAdd;

			public WireRenderMode WireMode
			{
				get
				{
					return _wireMode;
				}
				set
				{
					_wireMode = value;
				}
			}

			public int NumDetailAxialRings
			{
				get
				{
					return _numDetailAxialRings;
				}
				set
				{
					_numDetailAxialRings = Mathf.Max(2, value);
				}
			}

			public int NumDetailSliceRings
			{
				get
				{
					return _numDetailSliceRings;
				}
				set
				{
					_numDetailSliceRings = Mathf.Max(0, value);
				}
			}

			public float RadiusAdd
			{
				get
				{
					return _radiusAdd;
				}
				set
				{
					_radiusAdd = value;
				}
			}
		}

		private float _radius = 1f;

		private Vector3 _center = ModelCenter;

		private Quaternion _rotation = Quaternion.identity;

		private SphereEpsilon _epsilon;

		private WireRenderDescriptor _wireRenderDesc = new WireRenderDescriptor();

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

		public float WireRadius => _wireRenderDesc.RadiusAdd + _radius;

		public Vector3 Center
		{
			get
			{
				return _center;
			}
			set
			{
				_center = value;
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

		public SphereEpsilon Epsilon
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

		public WireRenderDescriptor WireRenderDesc => _wireRenderDesc;

		public Vector3 CentralAxis => Up;

		public Vector3 Right => _rotation * ModelRight;

		public Vector3 Up => _rotation * ModelUp;

		public Vector3 Look => _rotation * ModelLook;

		public static Vector3 ModelRight => Vector3.right;

		public static Vector3 ModelUp => Vector3.up;

		public static Vector3 ModelLook => Vector3.forward;

		public static Vector3 ModelCenter => Vector3.zero;

		public override void RenderSolid()
		{
			Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitSphere, Matrix4x4.TRS(Center, Quaternion.identity, Vector3Ex.FromValue(Radius)));
		}

		public override void RenderWire()
		{
			float wireRadius = WireRadius;
			if (_wireRenderDesc.WireMode == WireRenderMode.Basic)
			{
				Vector3 s = new Vector3(wireRadius, wireRadius, 1f);
				Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitWireCircleXY, Matrix4x4.TRS(_center, _rotation, s));
				Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitWireCircleXY, Matrix4x4.TRS(_center, _rotation * Quaternion.Euler(90f, 0f, 0f), s));
				Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitWireCircleXY, Matrix4x4.TRS(_center, _rotation * Quaternion.Euler(0f, -90f, 0f), s));
				return;
			}
			if (_wireRenderDesc.NumDetailSliceRings != 0)
			{
				Vector3 s2 = new Vector3(wireRadius, wireRadius, 1f);
				float num = 360f / (float)Mathf.Max(1, _wireRenderDesc.NumDetailSliceRings - 1);
				for (int i = 0; i < _wireRenderDesc.NumDetailSliceRings; i++)
				{
					float angle = num * (float)i;
					Matrix4x4 matrix = Matrix4x4.TRS(_center, _rotation * Quaternion.AngleAxis(angle, Vector3.up), s2);
					Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitWireCircleXY, matrix);
				}
			}
			Quaternion q = _rotation * Quaternion.AngleAxis(90f, Vector3.right);
			Vector3 vector = _center + Vector3.up * wireRadius;
			float num2 = 2f * wireRadius / (float)_wireRenderDesc.NumDetailAxialRings;
			for (int j = 0; j < _wireRenderDesc.NumDetailAxialRings; j++)
			{
				Vector3 vector2 = vector - Vector3.up * num2 * j;
				float num3 = Mathf.Sqrt(wireRadius * wireRadius - (vector2 - _center).sqrMagnitude);
				Graphics.DrawMeshNow(matrix: Matrix4x4.TRS(vector2, q, new Vector3(num3, num3, 1f)), mesh: Singleton<MeshPool>.Get.UnitWireCircleXY);
			}
		}

		public override bool Raycast(Ray ray, out float t)
		{
			return SphereMath.Raycast(ray, out t, _center, _radius, _epsilon);
		}

		public bool ContainsPoint(Vector3 point)
		{
			return SphereMath.ContainsPoint(point, _center, _radius, _epsilon);
		}

		public override AABB GetAABB()
		{
			return new AABB(_center, Vector3Ex.FromValue(_radius * 2f));
		}
	}
}
