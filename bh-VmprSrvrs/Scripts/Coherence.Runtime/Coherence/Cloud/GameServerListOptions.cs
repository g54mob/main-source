namespace Coherence.Cloud
{
	public struct GameServerListOptions
	{
		public int Limit;

		public int MaxPlayers;

		public string Region;

		public string Size;

		public string Slug;

		public bool Suspended;

		public string Tag;

		public string QueryParams()
		{
			return null;
		}
	}
}
