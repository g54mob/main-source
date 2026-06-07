using System;
using System.Collections.Generic;
using System.Linq;

namespace DV.Signs
{
	public static class SignPlacerUtils
	{
		public enum Operation
		{
			Insert = 0,
			Update = 1
		}

		public static List<List<float>> ChunkifyNumbers(List<float> numbers, float minSum)
		{
			if (numbers == null)
			{
				throw new ArgumentNullException("numbers");
			}
			if (numbers.Count == 0)
			{
				throw new ArgumentException("list can't be empty");
			}
			if (minSum <= 0f)
			{
				throw new ArgumentOutOfRangeException("minSum", "must be positive");
			}
			if (numbers.Any((float n) => n <= 0f))
			{
				throw new ArgumentOutOfRangeException("numbers", "all numbers must be positive");
			}
			List<List<float>> list = new List<List<float>>();
			if (numbers.Count == 1)
			{
				list.Add(new List<float> { numbers[0] });
				return list;
			}
			List<float> list2 = new List<float>();
			List<float> list3 = new List<float>();
			list3.AddRange(numbers);
			while (list2.Sum() < minSum && list3.Count >= 2 && list3.Sum() - list3[0] >= minSum)
			{
				list2.Add(list3[0]);
				list3.RemoveAt(0);
			}
			if (list2.Sum() < minSum || list3.Sum() < minSum)
			{
				list2.AddRange(list3);
				list.Add(list2);
				return list;
			}
			list.AddRange(ChunkifyNumbers(list2, minSum));
			list.AddRange(ChunkifyNumbers(list3, minSum));
			return list;
		}

		public static List<(Operation op, int index, float value)> MinimizeSpeedDifference(List<(float speed, float segmentLength)> signs, float speedDifferenceThreshold, float segmentLengthThreshold)
		{
			if (signs == null)
			{
				throw new ArgumentNullException("signs");
			}
			if (speedDifferenceThreshold <= 0f)
			{
				throw new ArgumentOutOfRangeException("speedDifferenceThreshold");
			}
			if (segmentLengthThreshold <= 0f)
			{
				throw new ArgumentOutOfRangeException("segmentLengthThreshold");
			}
			if (signs.Any(((float speed, float segmentLength) s) => s.segmentLength <= 0f))
			{
				throw new ArgumentOutOfRangeException("segment lengths must be positive");
			}
			List<(Operation, int, float)> list = new List<(Operation, int, float)>();
			if (signs.Count == 0)
			{
				return list;
			}
			signs = new List<(float, float)>(signs);
			for (int num = signs.Count - 2; num >= 0; num--)
			{
				(float, float) value = signs[num];
				(float, float) tuple = signs[num + 1];
				if (!(value.Item1 - tuple.Item1 <= speedDifferenceThreshold))
				{
					float num2 = GetMidpointSpeed(value.Item1, tuple.Item1);
					if (num2 - tuple.Item1 > speedDifferenceThreshold)
					{
						num2 = tuple.Item1 + speedDifferenceThreshold;
					}
					if (value.Item2 < segmentLengthThreshold)
					{
						value.Item1 = num2;
						signs[num] = value;
						list.Add((Operation.Update, num, value.Item1));
					}
					else
					{
						list.Add((Operation.Insert, num + 1, num2));
						if (value.Item1 - num2 > speedDifferenceThreshold)
						{
							value.Item1 = num2 + speedDifferenceThreshold;
							signs[num] = value;
							list.Add((Operation.Update, num, value.Item1));
						}
					}
				}
			}
			return list;
		}

		private static float GetMidpointSpeed(float a, float b)
		{
			float num = (a + b) / 2f;
			return num - num % 10f;
		}
	}
}
