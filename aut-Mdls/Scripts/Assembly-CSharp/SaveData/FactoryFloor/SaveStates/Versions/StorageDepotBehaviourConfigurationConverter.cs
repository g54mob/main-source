using System;
using Data.FactoryFloor.Resources;
using Data.SaveData;

namespace SaveData.FactoryFloor.SaveStates.Versions
{
	public class StorageDepotBehaviourConfigurationConverter : SaveDataConverter<StorageDepotBehaviourConfigurationDto>
	{
		[Serializable]
		private class Version0 : IPreviousSaveVersion, ISaveVersion
		{
			public Resource StoredResource;

			public ISaveVersion ToNextVersion()
			{
				return new StorageDepotBehaviourConfigurationDto();
			}
		}

		[Serializable]
		private class Version1 : IPreviousSaveVersion, ISaveVersion
		{
			public ISaveVersion ToNextVersion()
			{
				return new StorageDepotBehaviourConfigurationDto();
			}
		}

		public StorageDepotBehaviourConfigurationConverter()
			: base(2)
		{
		}

		public override Type GetPreviousVersion(int version)
		{
			return version switch
			{
				0 => typeof(Version0), 
				1 => typeof(Version1), 
				_ => null, 
			};
		}
	}
}
