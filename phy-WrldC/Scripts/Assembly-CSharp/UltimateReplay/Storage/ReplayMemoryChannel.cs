using System.Collections.Generic;

namespace UltimateReplay.Storage
{
	internal struct ReplayMemoryChannel
	{
		public List<ReplaySnapshot> states;

		public ReplayInitialDataBuffer initialStateBuffer;

		public string sceneName;
	}
}
