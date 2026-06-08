using UnityEngine;

namespace GRP.Net
{
	public class NetPlayer
	{
		public Id id;

		public string username;

		public bool isProjectSession;

		public bool isSimSession;

		public Color color;

		public NetConn conn;

		public NetPlayerData Serialize()
		{
			return default(NetPlayerData);
		}

		public void Deserialize(NetPlayerData data)
		{
		}
	}
}
