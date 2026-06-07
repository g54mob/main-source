using System;
using FluffyUnderware.Curvy.ThirdParty.LibTessDotNet;
using JetBrains.Annotations;
using ToolBuddy.Pooling.Collections;
using UnityEngine;

namespace FluffyUnderware.Curvy.Utils
{
	[Serializable]
	public class SplinePolyLine
	{
		public enum VertexCalculation
		{
			ByApproximation = 0,
			ByAngle = 1
		}

		public ContourOrientation Orientation;

		public CurvySpline Spline;

		public VertexCalculation VertexMode;

		public float Angle;

		public float Distance;

		public Space Space;

		public bool IsClosed => false;

		public SplinePolyLine(CurvySpline spline)
		{
		}

		public SplinePolyLine(CurvySpline spline, float angle, float distance)
		{
		}

		private SplinePolyLine(CurvySpline spline, VertexCalculation vertexMode, float angle, float distance, Space space = Space.World)
		{
		}

		[UsedImplicitly]
		[Obsolete("No more used in Curvy. Will get removed. Copy it if you still need it")]
		public Vector3[] GetVertices()
		{
			return null;
		}

		public SubArray<Vector3> GetVertexList()
		{
			return default(SubArray<Vector3>);
		}

		private static SubArrayList<Vector3> GetPolygon(CurvySpline spline, float fromTF, float toTF, float maxAngle, float minDistance, float maxDistance, bool includeEndPoint = true, float stepSize = 0.01f)
		{
			return default(SubArrayList<Vector3>);
		}
	}
}
