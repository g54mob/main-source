using Timberborn.Common;
using Timberborn.MapIndexSystem;
using Timberborn.Multithreading;
using UnityEngine;

namespace Timberborn.WaterSystem
{
	internal readonly struct UpdateWaterSourcesTask : IParallelizerSingleTask
	{
		private readonly MapIndexService _mapIndexService;

		private readonly WaterDepthSetter _waterDepthSetter;

		private readonly MutableWaterColumnRetriever _mutableWaterColumnRetriever;

		private readonly WaterColumn[] _waterColumns;

		private readonly ReadOnlyArray<byte> _waterColumnCounts;

		private readonly ReadOnlyList<ThreadSafeWaterSource> _waterSources;

		private readonly int _verticalStride;

		private readonly float _deltaTime;

		private readonly float _overflowPressureFactor;

		private readonly float _maxWaterContamination;

		public UpdateWaterSourcesTask(MapIndexService mapIndexService, WaterDepthSetter waterDepthSetter, MutableWaterColumnRetriever mutableWaterColumnRetriever, WaterColumn[] waterColumns, ReadOnlyArray<byte> waterColumnCounts, ReadOnlyList<ThreadSafeWaterSource> waterSources, int verticalStride, float deltaTime, float overflowPressureFactor, float maxWaterContamination)
		{
			_mapIndexService = mapIndexService;
			_waterDepthSetter = waterDepthSetter;
			_mutableWaterColumnRetriever = mutableWaterColumnRetriever;
			_waterColumns = waterColumns;
			_waterColumnCounts = waterColumnCounts;
			_waterSources = waterSources;
			_verticalStride = verticalStride;
			_deltaTime = deltaTime;
			_overflowPressureFactor = overflowPressureFactor;
			_maxWaterContamination = maxWaterContamination;
		}

		public void Run()
		{
			for (int i = 0; i < _waterSources.Count; i++)
			{
				ThreadSafeWaterSource threadSafeWaterSource = _waterSources[i];
				float waterDepthChange = _deltaTime * threadSafeWaterSource.CurrentStrength / (float)threadSafeWaterSource.Coordinates.Length;
				for (int j = 0; j < threadSafeWaterSource.Coordinates.Length; j++)
				{
					Vector3Int value = threadSafeWaterSource.Coordinates[j];
					int index = _mapIndexService.CellToIndex(value.XY());
					ref WaterColumn column = ref _mutableWaterColumnRetriever.GetColumn(_waterColumnCounts.AsSpan, _waterColumns, _verticalStride, index, value.z);
					float initialWaterDepth = column.WaterDepth + column.Overflow * _overflowPressureFactor;
					_waterDepthSetter.SetWaterDepth(waterDepthChange, ref column);
					UpdateContaminationFromWaterChange(ref column, initialWaterDepth, threadSafeWaterSource.Contamination);
				}
			}
		}

		private void UpdateContaminationFromWaterChange(ref WaterColumn waterColumn, float initialWaterDepth, float contaminationChange)
		{
			float num = waterColumn.WaterDepth + waterColumn.Overflow * _overflowPressureFactor;
			if (num != 0f)
			{
				float num2 = contaminationChange * (num - initialWaterDepth);
				float num3 = (waterColumn.Contamination * initialWaterDepth + num2) / num;
				if (num3 < 0f)
				{
					waterColumn.Contamination = 0f;
				}
				else
				{
					waterColumn.Contamination = ((num3 > _maxWaterContamination) ? _maxWaterContamination : num3);
				}
			}
			else
			{
				waterColumn.Contamination = 0f;
			}
		}
	}
}
