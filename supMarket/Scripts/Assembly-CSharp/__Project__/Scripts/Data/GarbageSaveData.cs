using System;

namespace __Project__.Scripts.Data
{
	[Serializable]
	public class GarbageSaveData
	{
		public TransformData transformData;

		public int garbageId;

		public GarbageSaveData()
		{
		}

		public GarbageSaveData(TransformData transformData, int garbageId)
		{
		}
	}
}
