using ExitGames.Client.Photon;

namespace Photon.Pun
{
	internal static class CustomTypes
	{
		public static readonly byte[] memPlayer;

		internal static void Register()
		{
		}

		private static short SerializePhotonPlayer(StreamBuffer outStream, object customobject)
		{
			return 0;
		}

		private static object DeserializePhotonPlayer(StreamBuffer inStream, short length)
		{
			return null;
		}
	}
}
