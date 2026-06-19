using System;
using UnityEngine;

namespace Water2D
{
	[Serializable]
	public class ReflectionSO
	{
		public Transform source;

		public Transform reflectionPivot;

		public ReflectionPivotSourceMode reflectionPivotSourceMode;

		public Transform reflection;

		public Transform customPivot;

		public SpriteRenderer sourceSr;

		public SpriteRenderer reflectionSr;

		public bool MSP_ReflectionGenerator;

		public bool flipX;

		public bool raymarched;

		public Vector2 displacement;

		public float additionalTilt;

		public ReflectionSO(Transform source, Transform reflectionPivot, ReflectionPivotSourceMode reflectionPivotSourceMode, Transform reflection, SpriteRenderer sourceSr, SpriteRenderer reflectionSr, bool flipX, Vector2 displacement, bool MSP_ReflectionGenerator, float addTilt, bool raymarched)
		{
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
