using Timberborn.Common;
using Timberborn.Multithreading;

namespace Timberborn.SoilMoistureSystem
{
	internal readonly struct WaterEvaporationCalculationTask : IParallelizerLoopTask
	{
		private readonly float[] _evaporationModifiers;

		private readonly ReadOnlyArray<byte> _columnCounts;

		private readonly ReadOnlyArray<byte> _clusterSaturations;

		private readonly ReadOnlyArray<float> _saturationToEvaporationMap;

		private readonly int _xMapSize;

		private readonly int _stride;

		private readonly int _verticalStride;

		public WaterEvaporationCalculationTask(float[] evaporationModifiers, in ReadOnlyArray<byte> columnCounts, in ReadOnlyArray<byte> clusterSaturations, in ReadOnlyArray<float> saturationToEvaporationMap, int xMapSize, int stride, int verticalStride)
		{
			_evaporationModifiers = evaporationModifiers;
			_columnCounts = columnCounts;
			_clusterSaturations = clusterSaturations;
			_saturationToEvaporationMap = saturationToEvaporationMap;
			_xMapSize = xMapSize;
			_stride = stride;
			_verticalStride = verticalStride;
		}

		public void Run(int y)
		{
			int num = (y + 1) * _stride;
			for (int i = 0; i < _xMapSize; i++)
			{
				int num2 = i + 1 + num;
				byte b = _columnCounts[num2];
				for (int j = 0; j < b; j++)
				{
					int num3 = num2 + j * _verticalStride;
					byte b2 = _clusterSaturations[num3];
					float num4 = ((b2 == 0) ? 1f : _saturationToEvaporationMap[b2]);
					_evaporationModifiers[num3] = num4;
				}
			}
		}
	}
}
