using UnityEngine;

namespace VampireSurvivors.App.Scripts.Framework.Curves
{
	public class QuadraticBezierCurve
	{
		private Vector2 _p0;

		private Vector2 _p1;

		private Vector2 _p2;

		public QuadraticBezierCurve(Vector2 p0, Vector2 p1, Vector2 p2)
		{
		}

		public Vector2 GetPoint(float t)
		{
			return default(Vector2);
		}

		public Vector3[] GetPoints(int points)
		{
			return null;
		}

		private float P0(float t, float p)
		{
			return 0f;
		}

		private float P1(float t, float p)
		{
			return 0f;
		}

		private float P2(float t, float p)
		{
			return 0f;
		}

		private float QuadraticBezierInterpolation(float t, float p0, float p1, float p2)
		{
			return 0f;
		}
	}
}
