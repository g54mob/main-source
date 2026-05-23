using System;
using UnityEngine;

namespace Barmetler.RoadSystem
{
	public static class RoadUtilities
	{
		public static void SetRotationAtWorldSpace(Road road, int i, Quaternion q)
		{
			if (i % 3 != 0)
			{
				throw new ArgumentException("i must be divisible by 3");
			}
			if ((i != 0 || !(road.start != null)) && (i != road.NumPoints - 1 || !(road.end != null)))
			{
				Vector3 vector = road.transform.InverseTransformDirection(q * Vector3.forward);
				Vector3 normal = road.transform.InverseTransformDirection(q * Vector3.up);
				if (i < road.NumPoints - 1)
				{
					float magnitude = (road[i + 1] - road[i]).magnitude;
					road.MovePoint(i + 1, road[i] + vector * magnitude);
				}
				else
				{
					float magnitude2 = (road[i - 1] - road[i]).magnitude;
					road.MovePoint(i - 1, road[i] - vector * magnitude2);
				}
				road.MoveNormal(i / 3, normal);
			}
		}

		public static Quaternion GetRotationAtWorldSpace(Road road, int i)
		{
			Vector3 forwards;
			Vector3 upwards;
			return GetRotationAtWorldSpace(road, i, out forwards, out upwards);
		}

		public static Quaternion GetRotationAtWorldSpace(Road road, int i, out Vector3 forwards, out Vector3 upwards)
		{
			i = road.LoopIndex(i);
			if (i % 3 != 0)
			{
				throw new ArgumentException("i must be divisible by 3");
			}
			int j = i;
			int num = i;
			for (; j < road.NumPoints - 1 && Vector3.Distance(road[j], road[i]) < 0.01f; j++)
			{
			}
			while (num > 0 && Vector3.Distance(road[num], road[j]) < 0.01f)
			{
				num--;
			}
			if (Vector3.Distance(road[num], road[j]) < 0.01f)
			{
				forwards = road.transform.TransformDirection(Vector3.forward);
			}
			forwards = (road[j] - road[num]).normalized;
			forwards = forwards.normalized;
			upwards = road.transform.TransformDirection(road.GetNormal(i / 3));
			forwards = road.transform.TransformDirection(forwards);
			return Quaternion.LookRotation(forwards, upwards);
		}
	}
}
