using System;
using Data.FactoryFloor.Resources;
using Data.SaveData;
using Newtonsoft.Json;

namespace SaveData.FactoryFloor.SaveStates.Versions
{
	public class SorterBehaviourConfigurationConverter : SaveDataConverter<SorterBehaviourConfigurationDto>
	{
		[Serializable]
		private class Version0 : IPreviousSaveVersion, ISaveVersion
		{
			[JsonProperty("hash")]
			public string FilterHash;

			[JsonProperty("id")]
			public int FilterId;

			public ISaveVersion ToNextVersion()
			{
				return new SorterBehaviourConfigurationDto
				{
					FilteredResource = new ResourceDto
					{
						ResourceID = FilterId,
						Hash = FilterHash
					}
				};
			}
		}

		public SorterBehaviourConfigurationConverter()
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
