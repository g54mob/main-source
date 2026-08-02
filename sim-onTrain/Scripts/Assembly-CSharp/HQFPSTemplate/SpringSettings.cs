using System;

namespace HQFPSTemplate
{
	[Serializable]
	public struct SpringSettings
	{
		public Spring.Data Position;

		public Spring.Data Rotation;

		public static SpringSettings Default => new SpringSettings
		{
			Position = Spring.Data.Default,
			Rotation = Spring.Data.Default
		};

		public SpringSettings(Spring.Data positionData, Spring.Data rotationData)
		{
			Position = positionData;
			Rotation = rotationData;
		}
	}
}
