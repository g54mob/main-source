using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace DV.PointSet.MeshUtils
{
	[NativeContainer]
	public struct NativeEquiPointSet : IDisposable
	{
		private Allocator m_AllocatorLabel;

		[NativeDisableContainerSafetyRestriction]
		public NativeList<float3> positions;

		[NativeDisableContainerSafetyRestriction]
		public NativeList<float3> ups;

		[NativeDisableContainerSafetyRestriction]
		public NativeList<float3> forwards;

		[NativeDisableContainerSafetyRestriction]
		public NativeList<float> spans;

		public float Span => spans[spans.Length - 1];

		public NativeEquiPointSet(Allocator allocator)
		{
			m_AllocatorLabel = allocator;
			positions = new NativeList<float3>(8, allocator);
			ups = new NativeList<float3>(8, allocator);
			forwards = new NativeList<float3>(8, allocator);
			spans = new NativeList<float>(8, allocator);
		}

		public void LoadEquiPointSet(EquiPointSet pointSet)
		{
			EquiPointSet.Point[] points = pointSet.points;
			for (int i = 0; i < points.Length; i++)
			{
				EquiPointSet.Point point = points[i];
				positions.Add((Vector3)point.position);
				ups.Add(point.up);
				forwards.Add(point.forward);
				spans.Add((float)point.span);
			}
		}

		public void Sample(float span, out float3 position, out float3 forward, out float3 up)
		{
			span = Mathf.Clamp(span, 0f, Span);
			if (span == 0f)
			{
				position = positions[0];
				forward = forwards[0];
				up = ups[0];
				return;
			}
			if (span == Span)
			{
				position = positions[positions.Length - 1];
				forward = forwards[positions.Length - 1];
				up = ups[positions.Length - 1];
				return;
			}
			int num = 0;
			int num2 = 16;
			int num3 = 1;
			int num4 = 0;
			while (num2 > 0 && num4 < 3000)
			{
				num4++;
				bool flag = spans[num] <= span;
				int num5 = ((!(spans[num + 1] > span)) ? 1 : ((!flag) ? (-1) : 0));
				if (num5 != num3)
				{
					num3 = num5;
					if (num3 == 0)
					{
						int num6 = num;
						int value = num6 + 1;
						num6 = Mathf.Clamp(num6, 0, positions.Length - 1);
						value = Mathf.Clamp(value, 0, positions.Length - 1);
						float t = ((num6 == value) ? 0f : math.unlerp(spans[num6], spans[value], span));
						position = math.lerp(positions[num6], positions[value], t);
						forward = math.lerp(forwards[num6], forwards[value], t);
						up = math.lerp(ups[num6], ups[value], t);
						return;
					}
					num2 /= 2;
					num2 = math.max(num2, 1);
				}
				int num7 = ((num3 == 1) ? (positions.Length - 2 - num) : num);
				if (Mathf.Abs(num2 * num3) <= num7)
				{
					num += num2 * num3;
					continue;
				}
				num2 /= 2;
				num2 = math.max(num2, 1);
			}
			Debug.LogError($"Didn't find corresponding span! {span} {Span} {num} {num2} {num3}");
			position = default(float3);
			up = default(float3);
			forward = default(float3);
		}

		public void Clear()
		{
			positions.Clear();
			ups.Clear();
			forwards.Clear();
			spans.Clear();
		}

		public void Dispose()
		{
			positions.Dispose();
			ups.Dispose();
			forwards.Dispose();
			spans.Dispose();
		}
	}
}
