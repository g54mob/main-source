using System.Collections.Generic;
using Timberborn.Common;
using Timberborn.MapIndexSystem;
using Timberborn.Multithreading;
using UnityEngine;

namespace Timberborn.WaterSystem
{
	internal readonly struct UpdateWaterChangesTask : IParallelizerSingleTask
	{
		private readonly MapIndexService _mapIndexService;

		private readonly WaterDepthSetter _waterDepthSetter;

		private readonly MutableWaterColumnRetriever _mutableWaterColumnRetriever;

		private readonly Dictionary<Vector3Int, WaterAmountChange> _removedWater;

		private readonly WaterColumn[] _waterColumns;

		private readonly ReadOnlyArray<byte> _waterColumnCounts;

		private readonly ReadOnlyList<WaterChange> _waterChanges;

		private readonly int _verticalStride;

		private readonly float _overflowPressureFactor;

		private readonly float _maxWaterContamination;

		public UpdateWaterChangesTask(MapIndexService mapIndexService, WaterDepthSetter waterDepthSetter, MutableWaterColumnRetriever mutableWaterColumnRetriever, Dictionary<Vector3Int, WaterAmountChange> removedWater, WaterColumn[] waterColumns, ReadOnlyArray<byte> waterColumnCounts, ReadOnlyList<WaterChange> waterChanges, int verticalStride, float overflowPressureFactor, float maxWaterContamination)
		{
			_mapIndexService = mapIndexService;
			_waterDepthSetter = waterDepthSetter;
			_mutableWaterColumnRetriever = mutableWaterColumnRetriever;
			_removedWater = removedWater;
			_waterColumns = waterColumns;
			_waterColumnCounts = waterColumnCounts;
			_waterChanges = waterChanges;
			_verticalStride = verticalStride;
			_overflowPressureFactor = overflowPressureFactor;
			_maxWaterContamination = maxWaterContamination;
		}

		public void Run()
		{
			_removedWater.Clear();
			for (int i = 0; i < _waterChanges.Count; i++)
			{
				WaterChange waterChange = _waterChanges[i];
				Vector3Int coordinates = waterChange.Coordinates;
				int index = _mapIndexService.CellToIndex(coordinates.XY());
				ref WaterColumn column = ref _mutableWaterColumnRetriever.GetColumn(_waterColumnCounts.AsSpan, _waterColumns, _verticalStride, index, coordinates.z);
				float num = column.WaterDepth + column.Overflow * _overflowPressureFactor;
				float contamination = column.Contamination;
				float num2 = num * (1f - contamination);
				float num3 = num * contamination;
				float depthChange = waterChange.DepthChange;
				float contaminationChange = waterChange.ContaminationChange;
				float num4 = num2 + depthChange * (1f - contaminationChange);
				num4 = ((num4 < 0f) ? 0f : num4);
				float num5 = num3 + depthChange * contaminationChange;
				num5 = ((num5 < 0f) ? 0f : num5);
				float num6 = num5 + num4;
				_waterDepthSetter.SetWaterDepth(num6 - num, ref column);
				UpdateContamination(ref column, num5, num6);
				if (waterChange.DepthChange < 0f)
				{
					float num7 = (column.WaterDepth + column.Overflow * _overflowPressureFactor) * (1f - column.Contamination);
					float num8 = (column.WaterDepth + column.Overflow * _overflowPressureFactor) * column.Contamination;
					float num9 = num2 - num7;
					float num10 = num3 - num8;
					if (_removedWater.TryGetValue(coordinates, out var value))
					{
						float cleanWaterChange = num9 + value.CleanWaterChange;
						float contaminatedWaterChange = num10 + value.ContaminatedWaterChange;
						_removedWater[coordinates] = new WaterAmountChange(cleanWaterChange, contaminatedWaterChange);
					}
					else
					{
						_removedWater[coordinates] = new WaterAmountChange(num9, num10);
					}
				}
			}
		}

		private void UpdateContamination(ref WaterColumn waterColumn, float contaminatedWater, float totalWater)
		{
			if (waterColumn.WaterDepth + waterColumn.Overflow * _overflowPressureFactor == 0f || totalWater <= 0f)
			{
				waterColumn.Contamination = 0f;
				return;
			}
			float num = contaminatedWater / totalWater;
			waterColumn.Contamination = ((num > _maxWaterContamination) ? _maxWaterContamination : num);
		}
	}
}
