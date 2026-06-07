using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class TorusShape3D : Shape3D
	{
		public enum WireRenderFlags
		{
			None = 0,
			TubeSlices = 1,
			AxialSlices = 2,
			All = 3
		}

		public class WireRenderDescriptor
		{
			private WireRenderFlags _wireFlags = WireRenderFlags.AxialSlices;

			private int _numTubeSlices = 30;

			private int _numAxialSlices = 30;

			public int NumTubeSlices
			{
				get
				{
					return _numTubeSlices;
				}
				set
				{
					_numTubeSlices = Mathf.Max(0, value);
				}
			}

			public int NumAxialSlices
			{
				get
				{
					return _numAxialSlices;
				}
				set
				{
					_numAxialSlices = Mathf.Max(2, value);
				}
			}

			public WireRenderFlags WireFlags
			{
				get
				{
					return _wireFlags;
				}
				set
				{
					_wireFlags = value;
				}
			}
		}

		private float _coreRadius = 1f;

		private float _tubeRadius = 1f;

		private Vector3 _center = ModelCenter;

		private Quaternion _rotation = Quaternion.identity;

		private TorusEpsilon _epsilon;

		private WireRenderDescriptor _wireRenderDesc = new WireRenderDescriptor();

		public float CoreRadius
		{
			get
			{
				return _coreRadius;
			}
			set
			{
				_coreRadius = Mathf.Abs(value);
			}
		}

		public float TubeRadius
		{
			get
			{
				return _tubeRadius;
			}
			set
			{
				_tubeRadius = Mathf.Abs(value);
			}
		}

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

		public Vector3 Right => _rotation * ModelRight;

		public Vector3 Up => _rotation * ModelUp;

		public Vector3 Look => _rotation * ModelLook;

		public TorusEpsilon Epsilon
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

		public float TubeRadiusEps
		{
			get
			{
				return _epsilon.TubeRadiusEps;
			}
			set
			{
				_epsilon.TubeRadiusEps = value;
			}
		}

		public WireRenderDescriptor WireRenderDesc => _wireRenderDesc;

		public static Vector3 ModelRight => Vector3.right;

		public static Vector3 ModelUp => Vector3.up;

		public static Vector3 ModelLook => Vector3.forward;

		public static Vector3 ModelCenter => Vector3.zero;

		public override bool Raycast(Ray ray, out float t)
		{
			return TorusMath.Raycast(ray, out t, _center, _coreRadius, _tubeRadius, _rotation, _epsilon);
		}

		public override void RenderSolid()
		{
			Graphics.DrawMeshNow(Singleton<MeshPool>.Get.UnitTorus, Matrix4x4.TRS(_center, _rotation, Vector3.one));
		}

		public override void RenderWire()
		{
			Mesh unitWireCircleXY = Singleton<MeshPool>.Get.UnitWireCircleXY;
			if (_wireRenderDesc.NumTubeSlices != 0 && (_wireRenderDesc.WireFlags & WireRenderFlags.TubeSlices) != WireRenderFlags.None)
			{
				Vector3 s = new Vector3(_tubeRadius, _tubeRadius, 1f);
				float num = 360f / (float)_wireRenderDesc.NumTubeSlices;
				for (int i = 0; i < _wireRenderDesc.NumTubeSlices; i++)
				{
					float f = num * (float)i * ((float)Math.PI / 180f);
					float num2 = Mathf.Cos(f);
					float num3 = Mathf.Sin(f);
					Vector3 vector = _center + Right * num2 * _coreRadius + Look * num3 * _coreRadius;
					Vector3 normalized = Vector3.Cross(vector - _center, Up).normalized;
					Graphics.DrawMeshNow(unitWireCircleXY, Matrix4x4.TRS(vector, Quaternion.LookRotation(normalized, Up), s));
				}
			}
			if (_wireRenderDesc.NumAxialSlices != 0 && (_wireRenderDesc.WireFlags & WireRenderFlags.AxialSlices) != WireRenderFlags.None)
			{
				Quaternion q = _rotation * Quaternion.Euler(90f, 0f, 0f);
				float num4 = 360f / (float)_wireRenderDesc.NumAxialSlices;
				for (int j = 0; j < _wireRenderDesc.NumAxialSlices; j++)
				{
					float f2 = num4 * (float)j * ((float)Math.PI / 180f);
					float num5 = Mathf.Cos(f2);
					float num6 = Mathf.Sin(f2);
					float num7 = _coreRadius - _tubeRadius * num6;
					float num8 = _tubeRadius * num5;
					Graphics.DrawMeshNow(unitWireCircleXY, Matrix4x4.TRS(s: new Vector3(num7, num7, 1f), pos: _center + Up * num8, q: q));
				}
			}
		}

		public List<Vector3> GetHrzExtents()
		{
			return TorusMath.Calc3DHrzExtentPoints(_center, _coreRadius, _tubeRadius, _rotation);
		}

		public override AABB GetAABB()
		{
			float num = TorusMath.CalcSphereRadius(_coreRadius, _tubeRadius);
			return new AABB(_center, Vector3Ex.FromValue(num * 2f));
		}
	}
}
