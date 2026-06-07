using System;
using System.Collections.Generic;
using System.Linq;
using Data.Operator;

namespace Data.SaveData.PersistentSOs
{
	public class UnlockedFactoryObjectsSaveDataConverter : SaveDataConverter<UnlockedFactoryObjectsSaveData>
	{
		private class Version0 : IPreviousSaveVersion, ISaveVersion
		{
			public List<string> _blockedObjectsNames;

			public ISaveVersion ToNextVersion()
			{
				if (_blockedObjectsNames == null)
				{
					return new UnlockedFactoryObjectsSaveData(Array.Empty<int>());
				}
				List<FactoryObjectData> list = LockedFactoryObjectsPersistentSO.FindAllFactoryObjectDatas().ToList();
				for (int num = list.Count - 1; num >= 0; num--)
				{
					if (_blockedObjectsNames.Contains(list[num].name))
					{
						list.RemoveAt(num);
					}
				}
				return new UnlockedFactoryObjectsSaveData(list.Select((FactoryObjectData x) => x.ID));
			}
		}

		public UnlockedFactoryObjectsSaveDataConverter()
			: base(1)
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
