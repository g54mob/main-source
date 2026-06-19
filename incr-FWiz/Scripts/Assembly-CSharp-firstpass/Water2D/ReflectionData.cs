using System;
using UnityEngine;

namespace Water2D
{
	[Serializable]
	public class ReflectionData
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

		public Vector2 displacement;

		public float additionalTilt;

		public ReflectionData(Transform source, Transform reflectionPivot, ReflectionPivotSourceMode reflectionPivotSourceMode, Transform reflection, SpriteRenderer sourceSr, SpriteRenderer reflectionSr, bool flipX, Vector2 displacement, bool MSP_ReflectionGenerator, float addTilt)
		{
		}
	}
}
