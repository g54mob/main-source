using System.Collections.Generic;

namespace Factory.FieldData
{
	public class MachineInformation
	{
		public class CollectItemInfo
		{
			public eLuggage luggage;

			public int count;

			public int max;
		}

		public class MeasureInfo
		{
			public eLuggage luggage;

			public double measure;

			public double capacity;

			public double consumption;

			public MeasureInfo(double capacity)
			{
			}
		}

		public StructureGroupID groupID;

		public eMachine machine;

		public double productionTime;

		public double fixedProductionTime;

		public double productionSpeed;

		public int productionQuantity;

		public eLuggage product;

		public double deliverySpeed;

		public double utilization;

		public eMachine source;

		public double sourceCorrection;

		public double buffRate;

		public int convertionRateBefore;

		public int convertionRateAfter;

		public eLuggage measureLuggage;

		public double measure;

		public double capacity;

		public List<MeasureInfo> measureInfos;

		public double liquidConsumption;

		public double outputSpeedPerSec;

		public double efficiency;

		public int connectExtractor;

		public int connectExtractorMax;

		public double humanEfficiency;

		public List<CollectItemInfo> collectItemInfos;

		public double collectionEfficiency;

		public double sweetsEffectiveTime;

		public double outputPortUtilizationAverageMain;

		public double outputPortUtilizationAverageSub;

		public bool inserterError;

		public bool EqualMachine(MachineInformation other)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
