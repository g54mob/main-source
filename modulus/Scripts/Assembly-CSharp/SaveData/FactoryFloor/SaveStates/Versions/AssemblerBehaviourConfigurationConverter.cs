using System;
using System.Collections.Generic;
using Data.SaveData;
using Data.Shapes;

namespace SaveData.FactoryFloor.SaveStates.Versions
{
	public class AssemblerBehaviourConfigurationConverter : SaveDataConverter<AssemblerBehaviourConfigurationDto>
	{
		[Serializable]
		private class Version0 : IPreviousSaveVersion, ISaveVersion
		{
			public ShapeDto CombinedShapeDto;

			public List<ConfigAssemblerShapeDto> ConfigShapes;

			public ShapeDto[] ResourcesUsed;

			public bool IsConfigured;

			public ISaveVersion ToNextVersion()
			{
				return new AssemblerBehaviourConfigurationDto
				{
					CombinedShapeDto = CombinedShapeDto,
					ConfigShapes = ConfigShapes,
					IsConfigured = IsConfigured
				};
			}
		}

		public AssemblerBehaviourConfigurationConverter()
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
