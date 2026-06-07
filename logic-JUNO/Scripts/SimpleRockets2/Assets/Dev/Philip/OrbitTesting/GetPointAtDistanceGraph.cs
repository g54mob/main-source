using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Dev.Philip.OrbitTesting
{
	public class GetPointAtDistanceGraph : MonoBehaviour
	{
		public static bool CompareOrbitPoints(IOrbitPoint a, IOrbitPoint b, double epsilon)
		{
			if (Utilities.CompareVector3ds(a.Position, b.Position, epsilon) && Utilities.CompareVector3ds(a.Velocity, b.Velocity, epsilon) && Utilities.CompareDoubles(a.Time, b.Time, epsilon) && Utilities.CompareDoubles(a.TrueAnomaly, b.TrueAnomaly, epsilon))
			{
				return Utilities.CompareDoubles(a.EccentricAnomaly, b.EccentricAnomaly, epsilon);
			}
			return false;
		}

		public void Start()
		{
			Vector3d p = new Vector3d(-164238247.473826, -1442363.30047346, -131435613.683117);
			Vector3d v = new Vector3d(-510.848072677182, 2.087361723607, 178.004468601794);
			double primaryMass = 2.38361904101986E+23;
			double time = 1566201.04308565;
			Orbit orbit = new Orbit(p, v, time, primaryMass);
			double num = 100000.0;
			double num2 = 1000000000.0;
			double num3 = orbit.ApoapsisDistance - orbit.PeriapsisDistance;
			int num4 = 0;
			bool flag = true;
			for (double num5 = 0.0; num5 < num2; num5 += num)
			{
				if (num5 > orbit.ApoapsisDistance)
				{
					_ = num5 % num3;
					_ = orbit.PeriapsisDistance;
				}
				else
				{
					_ = num5 % orbit.PeriapsisDistance;
				}
				IOrbitPoint pointAtDistance = OrbitMath.GetPointAtDistance(orbit, num5, ascent: true);
				bool flag2 = num5 < orbit.PeriapsisDistance;
				if (flag)
				{
				}
				double num6 = 0.0;
				double num7 = 0.0;
				if (!Utilities.IsNan(pointAtDistance.Position))
				{
					num6 = pointAtDistance.Position.magnitude;
					num7 = pointAtDistance.TrueAnomaly;
					flag = false;
				}
				else
				{
					flag = true;
				}
				GraphIt.Log("points", "inputDist", (float)num5);
				float x = num4;
				DebugGraph.MultiDraw("distances", Color.red, new Vector2(x, (float)num5));
				DebugGraph.MultiDraw("distances", Color.blue, new Vector2(x, (float)num6));
				DebugGraph.MultiDraw("distances", Color.green, new Vector2(x, (float)num7));
				num4++;
			}
		}
	}
}
