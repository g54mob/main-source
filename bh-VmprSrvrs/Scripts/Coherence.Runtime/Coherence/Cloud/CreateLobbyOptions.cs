using System.Collections.Generic;

namespace Coherence.Cloud
{
	public class CreateLobbyOptions
	{
		public string Region;

		public string Name;

		public string Tag;

		public int MaxPlayers;

		public bool Unlisted;

		public string Secret;

		public string SimulatorSlug;

		public List<CloudAttribute> LobbyAttributes;

		public List<CloudAttribute> PlayerAttributes;

		public static CreateLobbyOptions Default => null;
	}
}
