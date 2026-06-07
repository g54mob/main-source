using System;

namespace Data.SaveData.PersistentSOs
{
	public class CurrencySaveDataConverter : SaveDataConverter<CurrencySaveData>
	{
		private class Version0 : IPreviousSaveVersion, ISaveVersion
		{
			public ISaveVersion ToNextVersion()
			{
				throw new NotImplementedException();
			}
		}

		public CurrencySaveDataConverter()
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
