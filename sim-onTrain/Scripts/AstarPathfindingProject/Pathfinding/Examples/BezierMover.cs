using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("https://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_bezier_mover.php")]
	public class BezierMover : MonoBehaviour
	{
		public Transform[] points;

		public float speed = 1f;

		public float tiltAmount = 1f;

		public float tiltSmoothing = 1f;

		private float time;

		private Vector3 averageCurvature;

		private Vector3 Evaluate(float t, out Vector3 derivative, out Vector3 secondDerivative, out Vector3 curvature)
		{
			int num = points.Length;
			int num2 = (Mathf.FloorToInt(t) + num) % num;
			Vector3 position = points[(num2 - 1 + num) % num].position;
			Vector3 position2 = points[num2].position;
			Vector3 position3 = points[(num2 + 1) % num].position;
			Vector3 position4 = points[(num2 + 2) % num].position;
			float t2 = t - (float)Mathf.FloorToInt(t);
			CatmullRomToBezier(position, position2, position3, position4, out var c, out var c2, out var c3, out var c4);
			derivative = AstarSplines.CubicBezierDerivative(c, c2, c3, c4, t2);
			secondDerivative = AstarSplines.CubicBezierSecondDerivative(c, c2, c3, c4, t2);
			curvature = Curvature(derivative, secondDerivative);
			return AstarSplines.CubicBezier(c, c2, c3, c4, t2);
		}

		private static void CatmullRomToBezier(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, out Vector3 c0, out Vector3 c1, out Vector3 c2, out Vector3 c3)
		{
			c0 = p1;
			c1 = (-p0 + 6f * p1 + 1f * p2) * (1f / 6f);
			c2 = (p1 + 6f * p2 - p3) * (1f / 6f);
			c3 = p2;
		}

		private static Vector3 Curvature(Vector3 derivate, Vector3 secondDerivative)
		{
			float magnitude = derivate.magnitude;
			if (magnitude < 1E-06f)
			{
				return Vector3.zero;
			}
			return Vector3.Cross(derivate, secondDerivative) / (magnitude * magnitude * magnitude);
		}

		private void Update()
		{
			float num = time;
			float num2 = time + 1f;
			while (num2 - num > 0.0001f)
			{
				float num3 = (num + num2) / 2f;
				if ((Evaluate(num3, out var _, out var _, out var _) - base.transform.position).sqrMagnitude > speed * Time.deltaTime * (speed * Time.deltaTime))
				{
					num2 = num3;
				}
				else
				{
					num = num3;
				}
			}
			time = (num + num2) / 2f;
			base.transform.position = Evaluate(time, out var derivative2, out var _, out var curvature2);
			averageCurvature = Vector3.Lerp(averageCurvature, curvature2, Time.deltaTime);
			Vector3 vector = -Vector3.Cross(derivative2.normalized, averageCurvature);
			Vector3 upwards = new Vector3(0f, 1f / (tiltAmount + 1E-05f), 0f) + vector;
			base.transform.rotation = Quaternion.LookRotation(derivative2, upwards);
		}

		private void OnDrawGizmos()
		{
			if (points.Length < 3)
			{
				return;
			}
			for (int i = 0; i < points.Length; i++)
			{
				if (points[i] == null)
				{
					return;
				}
			}
			Gizmos.color = Color.white;
			Vector3 derivative;
			Vector3 secondDerivative;
			Vector3 curvature;
			Vector3 vector = Evaluate(0f, out derivative, out secondDerivative, out curvature);
			for (int j = 0; j < points.Length; j++)
			{
				for (int k = 1; k <= 100; k++)
				{
					Vector3 vector2 = Evaluate((float)j + (float)k / 100f, out derivative, out secondDerivative, out curvature);
					Gizmos.DrawLine(vector, vector2);
					vector = vector2;
				}
			}
		}
	}
}
