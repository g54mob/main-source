using System;
using ModApi.Planet;
using UnityEngine;

namespace ModApi.Math
{
	public static class MathUtils
	{
		public static float AverageComponentLength(Vector3 v)
		{
			return (v.x + v.y + v.z) / 3f;
		}

		public static float CalculateBurnDuration(float thrust, float mass, float deltaV)
		{
			float num = thrust / mass;
			if (num > 0f)
			{
				return deltaV / num;
			}
			return 0f;
		}

		public static float CalculateDeltaV(float startingMass, float endingMass, float isp)
		{
			endingMass = Mathf.Max(endingMass, 1f);
			startingMass = Mathf.Max(startingMass, 1f);
			return Mathf.Log(startingMass / endingMass) * isp * 9.80665f;
		}

		public static float CalculateIsp(float thrust, float massFlowRate)
		{
			return thrust / (massFlowRate * 9.80665f);
		}

		public static double CalculatePlanetDensity(double mass, double radius)
		{
			return mass / CalculateVolumeOfSphere(radius);
		}

		public static double CalculateVolumeOfSphere(double r)
		{
			return 4.1887902047863905 * r * r * r;
		}

		public static Vector3 ComputeRotationContributions(Vector3 forcePos, Vector3 forceDir, Transform axisOrientedCom, bool invertContributions, bool singleAxis, float contributionThreshold = 0.1f)
		{
			float z = 0f;
			float x = 0f;
			float y = 0f;
			Vector3 vector = Vector3.Cross(axisOrientedCom.InverseTransformPoint(forcePos), axisOrientedCom.InverseTransformDirection(forceDir));
			Vector3 vector2 = Utilities.Abs(vector);
			float num = ((!invertContributions) ? 1 : (-1));
			if (vector2.x > vector2.y && vector2.x > contributionThreshold)
			{
				x = 1f * Mathf.Sign(vector.x) * num;
			}
			else if (vector2.y > contributionThreshold)
			{
				y = 1f * Mathf.Sign(vector.y) * num;
			}
			if (vector2.z > contributionThreshold)
			{
				z = -1f * Mathf.Sign(vector.z) * num;
			}
			Vector3 result;
			if (singleAxis)
			{
				float x2 = vector2.x;
				float y2 = vector2.y;
				float z2 = vector2.z;
				float num2 = Mathf.Max(Mathf.Max(x2, y2), z2);
				result = ((num2 == x2) ? new Vector3(x, 0f, 0f) : ((num2 != y2) ? new Vector3(0f, 0f, z) : new Vector3(0f, y, 0f)));
			}
			else
			{
				result = new Vector3(x, y, z);
			}
			return result;
		}

		public static Vector3 ComputeTranslationContributions(Vector3 forcePos, Vector3 forceDir, Transform axisOrientedCom, bool invertContributions, bool singleAxis, float contributionThreshold = 0.9f)
		{
			float num = Vector3.Dot(forceDir, axisOrientedCom.forward);
			float num2 = Vector3.Dot(forceDir, axisOrientedCom.right);
			float num3 = Vector3.Dot(forceDir, axisOrientedCom.up);
			if (Mathf.Abs(num) < contributionThreshold)
			{
				num = 0f;
			}
			if (Mathf.Abs(num2) < contributionThreshold)
			{
				num2 = 0f;
			}
			if (Mathf.Abs(num3) < contributionThreshold)
			{
				num3 = 0f;
			}
			Vector3 result;
			if (singleAxis)
			{
				float num4 = Mathf.Max(Mathf.Max(num2, num3), num);
				result = ((num4 == num2) ? new Vector3(num2, 0f, 0f) : ((num4 != num3) ? new Vector3(0f, 0f, num) : new Vector3(0f, num3, 0f)));
			}
			else
			{
				result = new Vector3(num2, num3, num);
			}
			return result;
		}

		public static Vector3 ConvertAngularToLinearVelocity(Vector3 angularVelocity, Vector3 centerOfRotation, Vector3 linearVelocitySamplePoint)
		{
			return Vector3.Cross(angularVelocity, linearVelocitySamplePoint - centerOfRotation);
		}

		public static Vector3d FmodComponents(Vector3d vec, double mod)
		{
			vec.x %= mod;
			vec.y %= mod;
			vec.z %= mod;
			return vec;
		}

		public static Vector2d GetClosestPointOnEllipse(double semiMajorAxis, double semiMinorAxis, Vector2d queryPoint)
		{
			double distance;
			return GetClosestPointOnEllipse(semiMajorAxis, semiMinorAxis, queryPoint, out distance);
		}

		public static Vector2d GetClosestPointOnEllipse(double semiMajorAxis, double semiMinorAxis, Vector2d queryPoint, out double distance)
		{
			double x = 0.0;
			double x2 = 0.0;
			if (queryPoint.x > 0.0)
			{
				if (queryPoint.y > 0.0)
				{
					distance = DistancePointEllipse(semiMajorAxis, semiMinorAxis, queryPoint.x, queryPoint.y, ref x, ref x2);
				}
				else
				{
					distance = DistancePointEllipse(semiMajorAxis, semiMinorAxis, queryPoint.x, 0.0 - queryPoint.y, ref x, ref x2);
					x2 = 0.0 - x2;
				}
			}
			else if (queryPoint.y > 0.0)
			{
				distance = DistancePointEllipse(semiMajorAxis, semiMinorAxis, 0.0 - queryPoint.x, queryPoint.y, ref x, ref x2);
				x = 0.0 - x;
			}
			else
			{
				distance = DistancePointEllipse(semiMajorAxis, semiMinorAxis, 0.0 - queryPoint.x, 0.0 - queryPoint.y, ref x, ref x2);
				x = 0.0 - x;
				x2 = 0.0 - x2;
			}
			return new Vector2d(x, x2);
		}

		public static double GetEccentricAnomalyForClosestPointOnEllipse(double semiMajorAxis, double semiMinorAxis, Vector2d queryPoint)
		{
			double distance;
			return GetEccentricAnomalyForClosestPointOnEllipse(semiMajorAxis, semiMinorAxis, queryPoint, out distance);
		}

		public static double GetEccentricAnomalyForClosestPointOnEllipse(double semiMajorAxis, double semiMinorAxis, Vector2d queryPoint, out double distance)
		{
			double x = 0.0;
			double x2 = 0.0;
			if (queryPoint.x > 0.0)
			{
				if (queryPoint.y > 0.0)
				{
					distance = DistancePointEllipse(semiMajorAxis, semiMinorAxis, queryPoint.x, queryPoint.y, ref x, ref x2);
					return Mathd.Acos(x / semiMajorAxis);
				}
				distance = DistancePointEllipse(semiMajorAxis, semiMinorAxis, queryPoint.x, 0.0 - queryPoint.y, ref x, ref x2);
				return System.Math.PI * 2.0 - Mathd.Acos(x / semiMajorAxis);
			}
			if (queryPoint.y > 0.0)
			{
				distance = DistancePointEllipse(semiMajorAxis, semiMinorAxis, 0.0 - queryPoint.x, queryPoint.y, ref x, ref x2);
				return System.Math.PI - Mathd.Acos(x / semiMajorAxis);
			}
			distance = DistancePointEllipse(semiMajorAxis, semiMinorAxis, 0.0 - queryPoint.x, 0.0 - queryPoint.y, ref x, ref x2);
			return System.Math.PI + Mathd.Acos(x / semiMajorAxis);
		}

		public static bool GetFirstExternalRayIntersectionWithSphere(Vector3d spherePosition, double sphereRadius, Ray3d ray, out Vector3d result)
		{
			Vector3d lhs = spherePosition - ray.Origin;
			double num = Vector3d.Dot(lhs, ray.Direction);
			if (num < 0.0)
			{
				result = default(Vector3d);
				return false;
			}
			double num2 = lhs.sqrMagnitude - num * num;
			double num3 = sphereRadius * sphereRadius;
			if (num2 > num3)
			{
				result = default(Vector3d);
				return false;
			}
			double num4 = Mathd.Sqrt(num3 - num2);
			double num5 = num - num4;
			if (num5 < 0.0)
			{
				result = default(Vector3d);
				return false;
			}
			result = ray.Origin + ray.Direction * num5;
			return true;
		}

		public static bool GetIntersectionWithRadius(double x1, double y1, double x2, double y2, double r, out double x, out double y)
		{
			double num = r * r;
			double num2 = num * x1 * x1 - 2.0 * num * x1 * x2 + num * x2 * x2 + num * y1 * y1 - 2.0 * num * y1 * y2 + num * y2 * y2 - x1 * x1 * y2 * y2 + 2.0 * x1 * x2 * y1 * y2 - x2 * x2 * y1 * y1;
			if (num2 >= 0.0)
			{
				double num3 = System.Math.Sqrt(num2);
				double num4 = num3 - x1 * x2 + x2 * x2 - y1 * y2 + y2 * y2;
				double num5 = x1 * x1 - 2.0 * x1 * x2 + x2 * x2 + y1 * y1 - 2.0 * y1 * y2 + y2 * y2;
				if (num5 >= 0.0)
				{
					double num6 = num4 / num5;
					if (num6 < 0.0 || num6 > 1.0)
					{
						num6 = (0.0 - num3 - x1 * x2 + x2 * x2 - y1 * y2 + y2 * y2) / num5;
						if (num6 < 0.0 || num6 > 1.0)
						{
							x = 0.0;
							y = 0.0;
							return false;
						}
					}
					x = x1 * num6 + x2 * (1.0 - num6);
					y = y1 * num6 + y2 * (1.0 - num6);
					return true;
				}
			}
			x = 0.0;
			y = 0.0;
			return false;
		}

		public static bool GetIntersectionWithSphere(Vector3d sphereCenter, double sphereRadius, Vector3d pointInsideSphere, Vector3d directionToOutside, out Vector3d intersectionPoint)
		{
			double magnitude = (sphereCenter - pointInsideSphere).magnitude;
			if (magnitude > sphereRadius)
			{
				Debug.LogErrorFormat("GetIntersectionWithSphere: intersectingRay must be inside sphere: it is {0}m from sphere of radius: {1}", magnitude, sphereRadius);
				intersectionPoint = Vector3d.NaN;
				return false;
			}
			if (directionToOutside.sqrMagnitude == 0.0)
			{
				Debug.LogError("GetIntersectionWithSphere: intersectingRay.direction cannot be zero");
				intersectionPoint = Vector3d.NaN;
				return false;
			}
			Vector3d vector3d = pointInsideSphere + directionToOutside * sphereRadius;
			Vector3d lhs = vector3d - sphereCenter;
			double sqrMagnitude = lhs.sqrMagnitude;
			double num = Vector3d.Dot(lhs, directionToOutside);
			double num2 = sqrMagnitude - num * num;
			if (Utilities.CompareDoubles(num2, 0.0))
			{
				intersectionPoint = sphereCenter + directionToOutside * sphereRadius;
			}
			else
			{
				double num3 = System.Math.Sqrt(num2);
				double num4 = System.Math.Sqrt(sphereRadius * sphereRadius - num3 * num3);
				intersectionPoint = vector3d - directionToOutside * (num - num4);
			}
			return true;
		}

		public static double Haversine(double lat1, double lon1, double lat2, double lon2, double r)
		{
			double num = System.Math.Sin((lat2 - lat1) / 2.0);
			double num2 = System.Math.Sin((lon2 - lon1) / 2.0);
			double d = num * num + System.Math.Cos(lat1) * System.Math.Cos(lat2) * num2 * num2;
			return 2.0 * r * System.Math.Asin(System.Math.Sqrt(d));
		}

		public static Vector3d LatitudeLongitudeToSphereUnitVector(double latitude, double longitude)
		{
			return new Vector3d(Mathd.Cos(latitude) * Mathd.Sin(0.0 - longitude), Mathd.Sin(latitude), Mathd.Cos(latitude) * Mathd.Cos(0.0 - longitude)).normalized;
		}

		public static double LimitAngle0to2PI(double angle)
		{
			angle %= System.Math.PI * 2.0;
			if (angle < 0.0)
			{
				angle += System.Math.PI * 2.0;
			}
			return angle;
		}

		public static double LimitAngleNegPItoPI(double angle)
		{
			angle %= System.Math.PI * 2.0;
			if (angle > System.Math.PI)
			{
				angle -= System.Math.PI * 2.0;
			}
			else if (angle < -System.Math.PI)
			{
				angle += System.Math.PI * 2.0;
			}
			return angle;
		}

		public static float PercentBetween(float val, float min, float max, bool clamp = true)
		{
			float num = max - min;
			if (num != 0f)
			{
				float num2 = (val - min) / num;
				if (!clamp)
				{
					return num2;
				}
				return Mathf.Clamp01(num2);
			}
			return (val > max) ? 1 : 0;
		}

		public static Vector2d RotatePointAroundOrigin(Vector2d point, double angle)
		{
			return new Vector2d
			{
				x = point.x * System.Math.Cos(angle) - point.y * System.Math.Sin(angle),
				y = point.x * System.Math.Sin(angle) + point.y * System.Math.Cos(angle)
			};
		}

		public static Vector3 RoundToGrid(Vector3 vector, float gridSize)
		{
			return new Vector3(Utilities.SnapToGrid(vector.x, gridSize), Utilities.SnapToGrid(vector.y, gridSize), Utilities.SnapToGrid(vector.z, gridSize));
		}

		public static int RoundToOdd(int x, bool roundUp)
		{
			if (x % 2 == 0)
			{
				if (!roundUp)
				{
					return x - 1;
				}
				return x + 1;
			}
			return x;
		}

		public static int RoundToOdd(double x)
		{
			if ((int)x % 2 == 0)
			{
				return (int)System.Math.Ceiling(x);
			}
			return (int)x;
		}

		public static double SolarEnergyFlux(IPlanetData star, double solarSquareDistance)
		{
			return 5.670374392252597E-08 * System.Math.Pow(star.AtmosphereData.MeanSurfaceTemperature, 4.0) * star.RadiusSquared / solarSquareDistance;
		}

		private static double DistancePointEllipse(double e0, double e1, double y0, double y1, ref double x0, ref double x1)
		{
			if (y1 > 0.0)
			{
				if (y0 > 0.0)
				{
					double num = y0 / e0;
					double num2 = y1 / e1;
					double num3 = Sqr(num) + Sqr(num2) - 1.0;
					if (num3 != 0.0)
					{
						double num4 = Sqr(e0 / e1);
						double num5 = GetRoot(num4, num, num2, num3);
						x0 = num4 * y0 / (num5 + num4);
						x1 = y1 / (num5 + 1.0);
						return System.Math.Sqrt(Sqr(x0 - y0) + Sqr(x1 - y1));
					}
					x0 = y0;
					x1 = y1;
					return 0.0;
				}
				x0 = 0.0;
				x1 = e1;
				return System.Math.Abs(y1 - e1);
			}
			double num6 = e0 * y0;
			double num7 = Sqr(e0) - Sqr(e1);
			if (num6 < num7)
			{
				double num8 = num6 / num7;
				x0 = e0 * num8;
				x1 = e1 * System.Math.Sqrt(1.0 - num8 * num8);
				return System.Math.Sqrt(Sqr(x0 - y0) + Sqr(x1));
			}
			x0 = e0;
			x1 = 0.0;
			return System.Math.Abs(y0 - e0);
			static double GetRoot(double r0, double z0, double z1, double g)
			{
				double num9 = r0 * z0;
				double num10 = z1 - 1.0;
				double num11 = ((g < 0.0) ? 0.0 : (RobustLength(num9, z1) - 1.0));
				double num12 = 0.0;
				for (int i = 0; i < 1074; i++)
				{
					num12 = (num10 + num11) / 2.0;
					if (num12 == num10 || num12 == num11)
					{
						break;
					}
					double value = num9 / (num12 + r0);
					double value2 = z1 / (num12 + 1.0);
					g = Sqr(value) + Sqr(value2) - 1.0;
					if (g > 0.0)
					{
						num10 = num12;
					}
					else
					{
						if (!(g < 0.0))
						{
							break;
						}
						num11 = num12;
					}
				}
				return num12;
			}
			static double RobustLength(double v0, double v1)
			{
				double num9 = System.Math.Abs(v0);
				double num10 = System.Math.Abs(v1);
				if (num9 > num10)
				{
					return num9 * System.Math.Sqrt(1.0 + Sqr(v1 / v0));
				}
				return num10 * System.Math.Sqrt(1.0 + Sqr(v0 / v1));
			}
			static double Sqr(double value)
			{
				return value * value;
			}
		}
	}
}
