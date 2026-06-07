using System;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.ImportExport
{
	[Serializable]
	public class SerializedCurvySpline
	{
		public string Name;

		public Vector3 Position;

		public Vector3 Rotation;

		public CurvyInterpolation Interpolation;

		public bool RestrictTo2D;

		public bool Closed;

		public bool AutoEndTangents;

		public CurvyOrientation Orientation;

		public float AutoHandleDistance;

		public int CacheDensity;

		public float MaxPointsPerUnit;

		public bool UsePooling;

		public bool UseThreading;

		public bool CheckTransform;

		public CurvyUpdateMethod UpdateIn;

		public bool IsBSplineClamped;

		public int BSplineDegree;

		public SerializedCurvySplineSegment[] ControlPoints;

		public SerializedCurvySpline()
		{
		}

		public SerializedCurvySpline([NotNull] CurvySpline spline, CurvySerializationSpace space)
		{
		}

		public void WriteIntoSpline([NotNull] CurvySpline deserializedSpline, CurvySerializationSpace space)
		{
		}
	}
}
