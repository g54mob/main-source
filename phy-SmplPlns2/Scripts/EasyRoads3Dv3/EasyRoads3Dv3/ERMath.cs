using UnityEngine;

namespace EasyRoads3Dv3
{
	public class ERMath
	{
		public static Vector3 GetPosition(Vector3[] points, Vector3 position, ref float distance, ref int currentIndex, ref float t)
		{
			if (points == null)
			{
				return Vector3.zero;
			}
			if (currentIndex >= points.Length - 1)
			{
				return position;
			}
			Vector3 a = Vector3.Lerp(points[currentIndex], points[currentIndex + 1], t);
			bool flag = false;
			int num3;
			while (true)
			{
				float num = Vector3.Distance(a, points[currentIndex + 1]);
				if (num > distance)
				{
					float num2 = Vector3.Distance(points[currentIndex], points[currentIndex + 1]);
					t += distance / num2;
					num3 = currentIndex - 1;
					if (num3 < 0)
					{
						num3 = 0;
					}
					break;
				}
				distance -= num;
				t = 0f;
				if (currentIndex + 1 < points.Length - 1)
				{
					distance -= num;
					currentIndex++;
					a = points[currentIndex];
					continue;
				}
				return position;
			}
			int num4 = currentIndex + 2;
			if (num4 >= points.Length)
			{
				num4 = currentIndex + 1;
			}
			return ERModularRoad.OQQCQOQOOD(points[num3], points[currentIndex], points[currentIndex + 1], points[num4], t, 0.5f);
		}
	}
}
