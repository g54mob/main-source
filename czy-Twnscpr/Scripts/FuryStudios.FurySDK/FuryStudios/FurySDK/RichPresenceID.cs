using System;

namespace FuryStudios.FurySDK
{
	[Serializable]
	public struct RichPresenceID
	{
		public string id;

		public RichPresenceID(string id)
		{
			this.id = null;
		}

		public static explicit operator string(RichPresenceID richPresence)
		{
			return null;
		}

		public static implicit operator RichPresenceID(string id)
		{
			return default(RichPresenceID);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
