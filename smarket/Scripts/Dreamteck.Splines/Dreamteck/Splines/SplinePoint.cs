using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dreamteck.Splines
{
	[Serializable]
	public struct SplinePoint
	{
		public enum Type
		{
			SmoothMirrored = 0,
			Broken = 1,
			SmoothFree = 2
		}

		[NonSerialized]
		public bool isDirty;

		[FormerlySerializedAs("type")]
		[SerializeField]
		[HideInInspector]
		private Type _type;

		[HideInInspector]
		[FormerlySerializedAs("_position")]
		public Vector3 position;

		[HideInInspector]
		[FormerlySerializedAs("_color")]
		public Color color;

		[HideInInspector]
		[FormerlySerializedAs("_normal")]
		public Vector3 normal;

		[HideInInspector]
		[FormerlySerializedAs("_size")]
		public float size;

		[HideInInspector]
		[FormerlySerializedAs("_tangent")]
		public Vector3 tangent;

		[HideInInspector]
		[FormerlySerializedAs("_tangent2")]
		public Vector3 tangent2;

		public Type type
		{
			get
			{
				return default(Type);
			}
			set
			{
			}
		}

		public static SplinePoint Lerp(SplinePoint a, SplinePoint b, float t)
		{
			return default(SplinePoint);
		}

		private static void GetInterpolatedTangents(SplinePoint a, SplinePoint b, float t, ref SplinePoint target)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		private bool EqualsFast(SplinePoint obj)
		{
			return false;
		}

		public static bool operator ==(SplinePoint p1, SplinePoint p2)
		{
			return false;
		}

		public static bool operator !=(SplinePoint p1, SplinePoint p2)
		{
			return false;
		}

		public void SetPosition(Vector3 pos)
		{
		}

		public void SetTangentPosition(Vector3 pos)
		{
		}

		public void SetTangent2Position(Vector3 pos)
		{
		}

		public SplinePoint(Vector3 p)
		{
			isDirty = false;
			_type = default(Type);
			position = default(Vector3);
			color = default(Color);
			normal = default(Vector3);
			size = 0f;
			tangent = default(Vector3);
			tangent2 = default(Vector3);
		}

		public SplinePoint(Vector3 p, Vector3 t)
		{
			isDirty = false;
			_type = default(Type);
			position = default(Vector3);
			color = default(Color);
			normal = default(Vector3);
			size = 0f;
			tangent = default(Vector3);
			tangent2 = default(Vector3);
		}

		public SplinePoint(Vector3 pos, Vector3 tan, Vector3 nor, float s, Color col)
		{
			isDirty = false;
			_type = default(Type);
			position = default(Vector3);
			color = default(Color);
			normal = default(Vector3);
			size = 0f;
			tangent = default(Vector3);
			tangent2 = default(Vector3);
		}

		public SplinePoint(Vector3 pos, Vector3 tan, Vector3 tan2, Vector3 nor, float s, Color col)
		{
			isDirty = false;
			_type = default(Type);
			position = default(Vector3);
			color = default(Color);
			normal = default(Vector3);
			size = 0f;
			tangent = default(Vector3);
			tangent2 = default(Vector3);
		}

		public SplinePoint(SplinePoint source)
		{
			isDirty = false;
			_type = default(Type);
			position = default(Vector3);
			color = default(Color);
			normal = default(Vector3);
			size = 0f;
			tangent = default(Vector3);
			tangent2 = default(Vector3);
		}

		public void Flatten(LinearAlgebraUtility.Axis axis, float flatValue = 0f)
		{
		}

		public void SetPositionX(float value)
		{
		}

		public void SetPositionY(float value)
		{
		}

		public void SetPositionZ(float value)
		{
		}

		public void SetTangentX(float value)
		{
		}

		public void SetTangentY(float value)
		{
		}

		public void SetTangentZ(float value)
		{
		}

		public void SetTangent2X(float value)
		{
		}

		public void SetTangent2Y(float value)
		{
		}

		public void SetTangent2Z(float value)
		{
		}

		public void SetNormalX(float value)
		{
		}

		public void SetNormalY(float value)
		{
		}

		public void SetNormalZ(float value)
		{
		}

		public void SetColorR(float value)
		{
		}

		public void SetColorG(float value)
		{
		}

		public void SetColorB(float value)
		{
		}

		public void SetColorA(float value)
		{
		}

		private void SmoothMirrorTangent2()
		{
		}

		private void SmoothMirrorTangent()
		{
		}

		private void SmoothFreeTangent2()
		{
		}

		private void SmoothFreeTangent()
		{
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
