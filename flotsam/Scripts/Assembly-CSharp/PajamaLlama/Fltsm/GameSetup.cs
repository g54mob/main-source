using System;

namespace PajamaLlama.Fltsm
{
	[Serializable]
	public struct GameSetup
	{
		public TileProperties TileProperties;

		public bool IsTutorial;

		public BuildableProperties TownheartProperties;
	}
}
