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

		[FormerlySerializedAs("type")]
		[SerializeField]
		[HideInInspector]
		private Type _type;

		public Vector3 position;

		public Color color;

		public Vector3 normal;

		public float size;

		public Vector3 tangent;

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

		private static void GetInterpolatedTangents(SplinePoint a, SplinePoint b, float t, out Vector3 t1, out Vector3 t2)
		{
			t1 = default(Vector3);
			t2 = default(Vector3);
		}

		public static bool AreDifferent(ref SplinePoint a, ref SplinePoint b)
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
			_type = default(Type);
			position = default(Vector3);
			color = default(Color);
			normal = default(Vector3);
			size = 0f;
			tangent = default(Vector3);
			tangent2 = default(Vector3);
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
	}
}
