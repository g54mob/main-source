using System;
using Data.Statistics;

namespace Data.SaveData.PersistentSOs
{
	public class StatisticsSaveDataConverter : SaveDataConverter<StatisticsSaveData>
	{
		private class Version0 : IPreviousSaveVersion, ISaveVersion
		{
			public ISaveVersion ToNextVersion()
			{
				throw new NotImplementedException();
			}
		}

		public StatisticsSaveDataConverter()
			: base(0)
		{
		}

		public override Type GetPreviousVersion(int version)
		{
			if (version == 0)
			{
				return typeof(Version0);
			}
			return null;
		}
	}
}
