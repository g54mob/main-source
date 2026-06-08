using System;

namespace Timberborn.WaterSystem
{
	internal class MutableWaterColumnRetriever
	{
		public ref WaterColumn GetColumn(ReadOnlySpan<byte> columnCounts, Span<WaterColumn> waterColumns, int verticalStride, int index, int height)
		{
			for (int i = 0; i < columnCounts[index]; i++)
			{
				ref WaterColumn reference = ref waterColumns[i * verticalStride + index];
				if (height < reference.Floor)
				{
					break;
				}
				if (height < reference.Ceiling)
				{
					return ref reference;
				}
			}
			throw new InvalidOperationException($"Column for index {index} and height {height} not found");
		}
	}
}
