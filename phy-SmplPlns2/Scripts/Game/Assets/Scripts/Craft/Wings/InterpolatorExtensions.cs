using System;
using Unity.Collections;

namespace Assets.Scripts.Craft.Wings
{
	public static class InterpolatorExtensions
	{
		public static void InterpolateFrom<T>(this NativeArray<T> interpolated, NativeArray<T> source) where T : struct, IInterpolatedData<T>
		{
			int index = 0;
			int index2 = 0;
			T other = source[index2];
			for (int i = 0; i < interpolated.Length; i++)
			{
				float position = interpolated[i].Position;
				while (other.Position < position)
				{
					index = index2++;
					other = source[index2];
				}
				interpolated[i] = source[index].Interpolate(other, position);
			}
		}

		public static void InterpolateFrom<T>(this Span<T> interpolated, NativeArray<T> source) where T : struct, IInterpolatedData<T>
		{
			int index = 0;
			int index2 = 0;
			T other = source[index2];
			for (int i = 0; i < interpolated.Length; i++)
			{
				float position = interpolated[i].Position;
				while (other.Position < position)
				{
					index = index2++;
					other = source[index2];
				}
				interpolated[i] = source[index].Interpolate(other, position);
			}
		}
	}
}
