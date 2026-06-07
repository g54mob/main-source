using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class ConeShape3D : Shape3D
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

			private int _numDetailAxialSegments = 20;

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

			public int NumDetailAxialSegments
			{
				get
				{
					return _numDetailAxialSegments;
				}
				set
				{
					_numDetailAxialSegments = Mathf.Max(2, value);
				}
			}
		}

		private WireRenderDescriptor _wireRenderDesc = new WireRenderDescriptor();

		private Vector3 _baseCenter = ModelBaseCenter;

		private Quaternion _rotation = Quaternion.identity;

		private float _baseRadius = 1f;

		private float _height = 1f;

		private ConeEpsilon _epsilon;

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

		public Vector3 Tip
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

		public Vector3 CentralAxis => Up;

		public Vector3 Right => _rotation * ModelRight;

		public Vector3 Up => _rotation * ModelUp;

		public Vector3 Look => _rotation * ModelLook;

		public ConeEpsilon Epsilon
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

		public float HrzEps
		{
			get
			{
				return _epsilon.HrzEps;
			}
			set
			{
				_epsilon.HrzEps = value;
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

		public WireRenderDescriptor WireRenderDesc => _wireRenderDesc;

		public static Vector3 ModelRight => Vector3.right;

		public static Vector3 ModelUp => Vector3.up;

		public static Vector3 ModelLook => Vector3.forward;

		public static Vector3 ModelBaseCenter => Vector3.zero;

		public void AlignTip(Vector3 axis)
		{
			Rotation = QuaternionEx.FromToRotation3D(CentralAxis, axis, Look) * _rotation;
		}

		public override void RenderSolid()
		{
			Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitCone, Matrix4x4.TRS(_baseCenter, _rotation, new Vector3(_baseRadius, _height, _baseRadius)));
		}

		public override void RenderWire()
		{
			Vector3 tip = Tip;
			if (_wireRenderDesc.WireMode == WireRenderMode.Basic)
			{
				Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitWireCircleXY, Matrix4x4.TRS(_baseCenter, _rotation * Quaternion.AngleAxis(90f, Vector3.right), new Vector3(_baseRadius, _baseRadius, 1f)));
				List<Vector3> baseExtents = GetBaseExtents();
				GLRenderer.DrawLines3D(new List<Vector3>
				{
					baseExtents[0],
					tip,
					baseExtents[1],
					tip,
					baseExtents[2],
					tip,
					baseExtents[3],
					tip
				});
				return;
			}
			Vector3 centralAxis = CentralAxis;
			Quaternion q = Quaternion.AngleAxis(90f, Vector3.right);
			float num = _height / (float)(_wireRenderDesc.NumDetailAxialRings - 1);
			float num2 = _height / Mathf.Max(_baseRadius, 1E-05f);
			for (int i = 0; i < _wireRenderDesc.NumDetailAxialRings; i++)
			{
				float num3 = num * (float)i;
				Vector3 pos = _baseCenter + centralAxis * num * i;
				float num4 = (_height - num3) / num2;
				Graphics.DrawMeshNow(matrix: Matrix4x4.TRS(pos, q, new Vector3(num4, num4, 1f)), mesh: Singleton<MeshPool>.Get.UnitWireCircleXY);
			}
			List<Vector3> list = new List<Vector3>(_wireRenderDesc.NumDetailAxialSegments * 2);
			float num5 = 360f / (float)_wireRenderDesc.NumDetailAxialSegments;
			for (int j = 0; j < _wireRenderDesc.NumDetailAxialSegments; j++)
			{
				Vector3 normalized = (Quaternion.AngleAxis((float)j * num5, centralAxis) * Vector3.right).normalized;
				Vector3 item = _baseCenter + normalized * _baseRadius;
				list.Add(item);
				list.Add(tip);
			}
			GLRenderer.DrawLines3D(list);
		}

		public override bool Raycast(Ray ray, out float t)
		{
			return ConeMath.Raycast(ray, out t, _baseCenter, _baseRadius, _height, _rotation);
		}

		public bool ContainsPoint(Vector3 point)
		{
			return ConeMath.ContainsPoint(point, _baseCenter, _baseRadius, _height, _rotation);
		}

		public List<Vector3> GetBaseExtents()
		{
			return ConeMath.CalcConeBaseExtentPoints(_baseCenter, _baseRadius, _rotation);
		}

		public override AABB GetAABB()
		{
			AABB result = new AABB(GetBaseExtents());
			result.Encapsulate(Tip);
			return result;
		}
	}
}
