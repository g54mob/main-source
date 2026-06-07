using Unity.Burst.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings
{
	public static class Geometry2D
	{
		public static void Arc(this NativeList<Point> points, float2 center, float angleFrom, float angleTo, float radius, [AssumeRange(2L, 2147483647L)] int segments, bool includeEnds, PointFlags flags = PointFlags.Smooth | PointFlags.JoinProportionally)
		{
			float num = (angleTo - angleFrom) / (float)(includeEnds ? (segments - 1) : (segments + 1));
			float num2 = angleFrom + (includeEnds ? 0f : num);
			float2 float5 = default(float2);
			for (int i = 0; i < segments; i++)
			{
				math.sincos(num2, out float5.x, out float5.y);
				points.Add(new Point(center + float5 * radius, flags));
				num2 += num;
			}
		}
	}
}
