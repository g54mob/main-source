using System;

namespace CTS
{
	[Serializable]
	public struct GraphSaveStruct
	{
		public int currentMounth;

		public bool hasPastOneYear;

		public GraphPerMounthData[] dataPerMounth;
	}
}
