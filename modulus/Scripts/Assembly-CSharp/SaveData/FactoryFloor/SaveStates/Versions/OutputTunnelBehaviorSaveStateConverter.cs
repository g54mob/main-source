using System;
using Data.FactoryFloor;
using Data.FactoryFloor.Resources;
using Data.SaveData;

namespace SaveData.FactoryFloor.SaveStates.Versions
{
	public class OutputTunnelBehaviorSaveStateConverter : SaveDataConverter<OutputTunnelBehaviorSaveStateDto>
	{
		[Serializable]
		private class Version0 : IPreviousSaveVersion, ISaveVersion
		{
			public ResourceDto Resource;

			public ISaveVersion ToNextVersion()
			{
				ResourceDto[] resourceDtos = new ResourceDto[1] { Resource };
				return new OutputTunnelBehaviorSaveStateDto
				{
					InputBufferSaveData = new InputBufferSaveData(resourceDtos)
				};
			}
		}

		public OutputTunnelBehaviorSaveStateConverter()
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
