using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Tools
{
	public class PhaserSpline
	{
		private List<Vector2> _points;

		public PhaserSpline(List<Vector2> points)
		{
		}

		public PhaserSpline(List<float> points)
		{
		}

		public Vector2 GetPoint(float t)
		{
			return default(Vector2);
		}

		public void Dispose()
		{
		}

		private float CatmullRom(float t, float p0, float p1, float p2, float p3)
		{
			return 0f;
		}
	}
}
