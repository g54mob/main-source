using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class MonumentsPersistentSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public bool greyMonument;

		public bool blueMonument;

		public bool yellowMonument;

		public bool gNNGateFinished;

		public MonumentsPersistentSaveData(bool grey, bool blue, bool yellow, bool gNNGateFinished)
			: base(0)
		{
			greyMonument = grey;
			blueMonument = blue;
			yellowMonument = yellow;
			this.gNNGateFinished = gNNGateFinished;
		}
	}
}
