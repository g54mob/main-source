using System;
using CTS.BBT;
using CTS.StockInventory;

namespace CTS
{
	public struct StockStack : IStackable<StockStack, StockItemSO>
	{
		private class QualityStackComparator : IStackComparator<StockStack, StockItemSO>
		{
			public int QualityTest;

			public ETest OperationTest;

			public bool IsValidStack(StockStack stack)
			{
				return OperationTest switch
				{
					ETest.GreaterThan => stack.Quality > (float)QualityTest, 
					ETest.GreaterOrEqualTo => stack.Quality >= (float)QualityTest, 
					ETest.LessThan => stack.Quality < (float)QualityTest, 
					ETest.LessOrEqualTo => stack.Quality <= (float)QualityTest, 
					ETest.EqualTo => stack.Quality == (float)QualityTest, 
					ETest.NotEqualTo => stack.Quality != (float)QualityTest, 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
		}

		private static readonly QualityStackComparator _qualityComparator = new QualityStackComparator();

		private float _quality;

		public int StackCount { get; private set; }

		public StockItemSO ItemData { get; private set; }

		public float Quality
		{
			readonly get
			{
				if (ItemData.StockType == Stocks.HumanStockType)
				{
					return 1f;
				}
				return _quality;
			}
			private set
			{
				_quality = value;
			}
		}

		public static IStackComparator<StockStack, StockItemSO> GetQualityComparator(ETest operation, int quality)
		{
			_qualityComparator.QualityTest = quality;
			_qualityComparator.OperationTest = operation;
			return _qualityComparator;
		}

		public StockStack(StockItemSO itemData, int stackCount, float quality)
		{
			ItemData = itemData;
			StackCount = stackCount;
			_quality = quality;
		}

		public bool CanAnythingBeAddedTo(StockStack other)
		{
			if (ItemData != other.ItemData)
			{
				return false;
			}
			return StackCount > 0;
		}

		public StockStack AddStack(ref StockStack stack)
		{
			return AddStack(ref stack, stack.StackCount);
		}

		public StockStack AddStack(ref StockStack stack, int maxCount)
		{
			float num = Quality * (float)StackCount;
			int num2 = Math.Min(stack.StackCount, maxCount);
			StackCount += num2;
			stack.StackCount -= num2;
			num += stack.Quality * (float)num2;
			Quality = ((StackCount > 0) ? (num / (float)StackCount) : 0f);
			return this;
		}

		public void SetupEmptyFrom(StockStack stack)
		{
			SetupEmptyFrom(stack.ItemData);
		}

		public void SetupEmptyFrom(StockItemSO data)
		{
			StackCount = 0;
			ItemData = data;
			Quality = 0f;
		}

		public readonly int GetBasePrice()
		{
			return ItemData.GetUnitPrice(Quality) * StackCount;
		}
	}
}
