using Timberborn.Common;
using Timberborn.MapIndexSystem;

namespace Timberborn.WaterSystem
{
	internal class FlowLimitCalculator
	{
		private readonly MapIndexService _mapIndexService;

		public FlowLimitCalculator(MapIndexService mapIndexService)
		{
			_mapIndexService = mapIndexService;
		}

		public bool CanInflowInDirection(ReadOnlyArray<int> limitedDirections, int index, byte waterBase, int direction)
		{
			int index3D = _mapIndexService.Index2DTo3D(index, waterBase);
			return CanInflowInDirection(limitedDirections, index3D, direction);
		}

		public bool CanInflowInDirection(ReadOnlyArray<int> limitedDirections, int index3D, int direction)
		{
			int num = limitedDirections[index3D];
			if (num != 0)
			{
				return num == direction;
			}
			return true;
		}

		public bool CanOutflowInDirection(ReadOnlyArray<int> limitedDirections, int index, byte waterBase, int direction)
		{
			int index2 = _mapIndexService.Index2DTo3D(index, waterBase);
			int num = limitedDirections[index2];
			if (num != 0 && num != direction)
			{
				return num == -direction;
			}
			return true;
		}

		public float GetHeightLimit(ReadOnlyArray<float> heightLimits, int index, int waterBase, int waterHeight)
		{
			for (int i = waterBase; i < waterHeight; i++)
			{
				int index2 = _mapIndexService.Index2DTo3D(index, i);
				float num = heightLimits[index2];
				if (num >= 0f)
				{
					return num;
				}
			}
			return float.MinValue;
		}

		public bool HasFlowController(ReadOnlyArray<sbyte> flowControllers, int index, int waterHeight, out bool flowAllowed)
		{
			int index2 = _mapIndexService.Index2DTo3D(index, waterHeight);
			sbyte b = flowControllers[index2];
			flowAllowed = b == 1;
			return b != 0;
		}

		public bool HasInflowLimit(ReadOnlyArray<float> limitedValues, int index, int waterHeight)
		{
			int index2 = _mapIndexService.Index2DTo3D(index, waterHeight);
			return limitedValues[index2] >= 0f;
		}

		public float GetInflowLimit(ReadOnlyArray<float> inflowLimits, int index, byte waterBase)
		{
			int index2 = _mapIndexService.Index2DTo3D(index, waterBase);
			return inflowLimits[index2];
		}
	}
}
