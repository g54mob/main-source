using System.Collections.Generic;
using Timberborn.Common;
using Timberborn.Multithreading;

namespace Timberborn.WaterSystem
{
	internal readonly struct UpdateContaminationTask : IParallelizerLoopTask
	{
		private readonly WaterColumn[] _waterColumns;

		private readonly ReadOnlyArray<byte> _waterColumnCounts;

		private readonly ReadOnlyArray<float> _contaminationsBuffer;

		private readonly ReadOnlyArray<Diffusions> _baseLevelDiffusions;

		private readonly ReadOnlyArray<byte> _targetedDiffusionCount;

		private readonly ReadOnlyArray<List<TargetedDiffusion>> _targetedDiffusions;

		private readonly int _xMapSize;

		private readonly int _stride;

		private readonly int _verticalStride;

		private readonly float _deltaTime;

		private readonly float _maxContamination;

		private readonly float _diffusionRate;

		public UpdateContaminationTask(WaterColumn[] waterColumns, ReadOnlyArray<byte> waterColumnCounts, ReadOnlyArray<float> contaminationsBuffer, ReadOnlyArray<Diffusions> baseLevelDiffusions, ReadOnlyArray<byte> targetedDiffusionCount, ReadOnlyArray<List<TargetedDiffusion>> targetedDiffusions, int xMapSize, int stride, int verticalStride, float deltaTime, float maxContamination, float diffusionRate)
		{
			_waterColumns = waterColumns;
			_waterColumnCounts = waterColumnCounts;
			_contaminationsBuffer = contaminationsBuffer;
			_baseLevelDiffusions = baseLevelDiffusions;
			_targetedDiffusionCount = targetedDiffusionCount;
			_targetedDiffusions = targetedDiffusions;
			_xMapSize = xMapSize;
			_stride = stride;
			_verticalStride = verticalStride;
			_deltaTime = deltaTime;
			_maxContamination = maxContamination;
			_diffusionRate = diffusionRate;
		}

		public void Run(int y)
		{
			int num = (y + 1) * _stride;
			for (int i = 0; i < _xMapSize; i++)
			{
				int num2 = i + 1 + num;
				for (int j = 0; j < _waterColumnCounts[num2]; j++)
				{
					int num3 = num2 + j * _verticalStride;
					ref WaterColumn reference = ref _waterColumns[num3];
					if (reference.WaterDepth > 0f)
					{
						float num4 = _contaminationsBuffer[num3] + GetContaminationDiffusionChange(in reference, num2, num3);
						reference.Contamination = ((num4 > _maxContamination) ? _maxContamination : num4);
					}
					else
					{
						reference.Contamination = 0f;
					}
				}
			}
		}

		private float GetContaminationDiffusionChange(in WaterColumn waterColumn, int index, int index3D)
		{
			byte b = _targetedDiffusionCount[index3D];
			if (b > 0)
			{
				float diffusionFraction = 1f / (float)(int)b;
				float sourceContamination = _contaminationsBuffer[index3D];
				float waterDepth = waterColumn.WaterDepth;
				float num = 0f;
				if (index == index3D)
				{
					ref readonly Diffusions reference = ref _baseLevelDiffusions[index];
					if (reference.Bottom)
					{
						num += CalculateDiffusion(sourceContamination, waterDepth, index - _stride, diffusionFraction);
					}
					if (reference.Left)
					{
						num += CalculateDiffusion(sourceContamination, waterDepth, index - 1, diffusionFraction);
					}
					if (reference.Top)
					{
						num += CalculateDiffusion(sourceContamination, waterDepth, index + _stride, diffusionFraction);
					}
					if (reference.Right)
					{
						num += CalculateDiffusion(sourceContamination, waterDepth, index + 1, diffusionFraction);
					}
				}
				List<TargetedDiffusion> list = _targetedDiffusions[index];
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].OriginIndex3D == index3D)
					{
						int targetIndex3D = list[i].TargetIndex3D;
						num += CalculateDiffusion(sourceContamination, waterDepth, targetIndex3D, diffusionFraction);
					}
				}
				return num * _deltaTime;
			}
			return 0f;
		}

		private float CalculateDiffusion(float sourceContamination, float sourceWaterDepth, int targetIndex3D, float diffusionFraction)
		{
			ref WaterColumn reference = ref _waterColumns[targetIndex3D];
			float num = 1f / (float)(int)_targetedDiffusionCount[targetIndex3D];
			float num2 = _contaminationsBuffer[targetIndex3D];
			float waterDepth = reference.WaterDepth;
			float num3 = num2 - sourceContamination;
			float num5;
			if (num3 > 0f)
			{
				float num4 = num * num2;
				num5 = ((num3 < num4) ? num3 : num4);
			}
			else
			{
				float num6 = (0f - diffusionFraction) * sourceContamination;
				num5 = ((num3 > num6) ? num3 : num6);
			}
			return waterDepth / (sourceWaterDepth + waterDepth) * num5 * _diffusionRate;
		}
	}
}
