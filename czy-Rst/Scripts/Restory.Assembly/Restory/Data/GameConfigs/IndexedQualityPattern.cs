using System;
using Restory.Gameplay.GameSettings;

namespace Restory.Data.GameConfigs
{
	[Serializable]
	public struct IndexedQualityPattern
	{
		public GameSettingsManager.GraphicsPattern Quality;

		public int UnityPlayerQualityIndex;
	}
}
