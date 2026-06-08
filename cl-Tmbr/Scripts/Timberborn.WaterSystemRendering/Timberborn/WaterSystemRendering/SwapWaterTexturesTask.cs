using System;
using Timberborn.Multithreading;
using UnityEngine;

namespace Timberborn.WaterSystemRendering
{
	internal readonly struct SwapWaterTexturesTask : IParallelizerSingleTask
	{
		private readonly int _maxColumnCount;

		private readonly bool _anyColumnChanged;

		private readonly ColumnChangeTracker _columnChangeTracker;

		private readonly ColumnCountTracker _columnCountTracker;

		private readonly DataTextureArray<float> _waterDepths;

		private readonly DataTextureArray<Vector2> _outflows;

		private readonly DataTextureArray<byte> _contaminations;

		private readonly DataTextureArray<Vector2> _columns;

		private readonly DataTextureArray<Vector2> _linkBarriers;

		private readonly DataTextureArray<float> _flowLimits;

		private readonly bool[] _tilesWithWater;

		public SwapWaterTexturesTask(int maxColumnCount, bool anyColumnChanged, ColumnChangeTracker columnChangeTracker, ColumnCountTracker columnCountTracker, DataTextureArray<float> waterDepths, DataTextureArray<Vector2> outflows, DataTextureArray<byte> contaminations, DataTextureArray<Vector2> columns, DataTextureArray<Vector2> linkBarriers, DataTextureArray<float> flowLimits, bool[] tilesWithWater)
		{
			_maxColumnCount = maxColumnCount;
			_anyColumnChanged = anyColumnChanged;
			_columnChangeTracker = columnChangeTracker;
			_columnCountTracker = columnCountTracker;
			_waterDepths = waterDepths;
			_outflows = outflows;
			_contaminations = contaminations;
			_columns = columns;
			_linkBarriers = linkBarriers;
			_flowLimits = flowLimits;
			_tilesWithWater = tilesWithWater;
		}

		public void Run()
		{
			Array.Clear(_tilesWithWater, 0, _tilesWithWater.Length);
			_columnCountTracker.Update(_maxColumnCount);
			_columnChangeTracker.Update(_anyColumnChanged);
			_outflows.SwapDataAndClear(_columnCountTracker.MaxCount);
			_contaminations.SwapDataAndClear(_columnCountTracker.MaxCount);
			_waterDepths.SwapDataAndClear(_columnCountTracker.MaxCount);
			_flowLimits.SwapDataAndClear(_columnCountTracker.MaxCount);
			if (_columnChangeTracker.AnyColumnChanged())
			{
				_columns.SwapDataAndClear(_columnCountTracker.MaxCount);
				_linkBarriers.SwapDataAndClear(_columnCountTracker.MaxCount);
			}
		}
	}
}
