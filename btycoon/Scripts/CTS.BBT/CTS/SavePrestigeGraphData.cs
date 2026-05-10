using System;

namespace CTS
{
	[Serializable]
	public struct SavePrestigeGraphData
	{
		public int currentMounth;

		public bool hasPastOneYear;

		public PrestigePerMounth[] prestigePerMounth;

		public static GraphSaveStruct ConvertToGraphSaveStruct(SavePrestigeGraphData data)
		{
			GraphPerMounthData[] array = new GraphPerMounthData[data.prestigePerMounth.Length];
			for (int i = 0; i < data.prestigePerMounth.Length; i++)
			{
				array[i] = data.prestigePerMounth[i].ConvertToGraphPerMounthData();
			}
			return new GraphSaveStruct
			{
				currentMounth = data.currentMounth,
				hasPastOneYear = data.hasPastOneYear,
				dataPerMounth = array
			};
		}

		public static SavePrestigeGraphData ConvertFromGraphSaveStruct(GraphSaveStruct data)
		{
			PrestigePerMounth[] array = new PrestigePerMounth[data.dataPerMounth.Length];
			for (int i = 0; i < data.dataPerMounth.Length; i++)
			{
				array[i] = PrestigePerMounth.ConvertFromGraphPerMounthData(data.dataPerMounth[i]);
			}
			return new SavePrestigeGraphData
			{
				currentMounth = data.currentMounth,
				hasPastOneYear = data.hasPastOneYear,
				prestigePerMounth = array
			};
		}
	}
}
