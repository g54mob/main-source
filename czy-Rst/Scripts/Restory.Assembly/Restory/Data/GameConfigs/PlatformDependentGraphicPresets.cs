using System;

namespace Restory.Data.GameConfigs
{
	[Serializable]
	public struct PlatformDependentGraphicPresets
	{
		public GraphicsPlatformType Platform;

		public IndexedQualityPattern[] Patterns;
	}
}
