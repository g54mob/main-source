using System;
using Data.FactoryFloor;
using Data.FactoryFloor.Resources;
using Data.SaveData;

namespace SaveData.FactoryFloor.SaveStates.Versions
{
	public class AssemblerBehaviourSaveStateConverter : SaveDataConverter<AssemblerBehaviourSaveStateDto>
	{
		[Serializable]
		private class Version0 : IPreviousSaveVersion, ISaveVersion
		{
			public int[] ResourcesAmount;

			public ISaveVersion ToNextVersion()
			{
				return new AssemblerBehaviourSaveStateDto
				{
					InputBufferSaveData = new InputBufferSaveData(Array.Empty<ResourceDto>())
				};
			}
		}

		public AssemblerBehaviourSaveStateConverter()
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
