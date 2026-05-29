using System;
using UnityEngine;

namespace TinyGiantStudio.Text
{
	[Serializable]
	internal class ContourData
	{
		public Vector2 maxPoint;

		public Vector2 minPoint;

		public Vector2[] points;

		public bool[] onCurves;

		public Vector2[] renderedPoints;

		public Side side;

		public ContourData(Vector2[] points, bool[] onCurves)
		{
		}
	}
}
