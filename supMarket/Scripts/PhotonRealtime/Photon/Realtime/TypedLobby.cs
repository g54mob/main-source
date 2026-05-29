namespace Photon.Realtime
{
	public class TypedLobby
	{
		public string Name;

		public LobbyType Type;

		public static readonly TypedLobby Default;

		public bool IsDefault => false;

		internal TypedLobby()
		{
		}

		public TypedLobby(string name, LobbyType type)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
