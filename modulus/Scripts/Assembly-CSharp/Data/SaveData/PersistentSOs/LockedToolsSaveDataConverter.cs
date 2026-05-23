using System;
using System.Collections.Generic;

namespace Data.SaveData.PersistentSOs
{
	public class LockedToolsSaveDataConverter : SaveDataConverter<LockedToolsSaveData>
	{
		private class Version0 : IPreviousSaveVersion, ISaveVersion
		{
			public List<string> _lockedToolsNames;

			public ISaveVersion ToNextVersion()
			{
				return new LockedToolsSaveData(_lockedToolsNames);
			}
		}

		public LockedToolsSaveDataConverter()
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
