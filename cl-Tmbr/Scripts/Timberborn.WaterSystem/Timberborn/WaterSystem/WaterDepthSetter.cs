using Timberborn.BlueprintSystem;
using Timberborn.MapIndexSystem;
using Timberborn.SingletonSystem;

namespace Timberborn.WaterSystem
{
	internal class WaterDepthSetter : ILoadableSingleton
	{
		private readonly MapIndexService _mapIndexService;

		private readonly ISpecService _specService;

		private float _maxPressure;

		private float _overflowPressureFactorInverted;

		public WaterDepthSetter(MapIndexService mapIndexService, ISpecService specService)
		{
			_mapIndexService = mapIndexService;
			_specService = specService;
		}

		public void Load()
		{
			_maxPressure = _mapIndexService.TotalSize.z + 1;
			WaterSimulatorSpec singleSpec = _specService.GetSingleSpec<WaterSimulatorSpec>();
			_overflowPressureFactorInverted = 1f / singleSpec.OverflowPressureFactor;
		}

		public void SetWaterDepth(float waterDepthChange, ref WaterColumn waterColumn)
		{
			float num = waterColumn.WaterDepth + waterColumn.Overflow + waterDepthChange;
			int num2 = waterColumn.Ceiling - waterColumn.Floor;
			waterColumn.OldWaterDepth = waterColumn.WaterDepth;
			if (num < 0f)
			{
				waterColumn.WaterDepth = 0f;
				waterColumn.Overflow = 0f;
			}
			else if (num > (float)num2)
			{
				waterColumn.WaterDepth = num2;
				float num3 = num - (float)num2;
				float num4 = (_maxPressure - (float)(int)waterColumn.Ceiling) * _overflowPressureFactorInverted;
				waterColumn.Overflow = ((num3 > num4) ? num4 : num3);
			}
			else
			{
				waterColumn.WaterDepth = num;
				waterColumn.Overflow = 0f;
			}
		}
	}
}
