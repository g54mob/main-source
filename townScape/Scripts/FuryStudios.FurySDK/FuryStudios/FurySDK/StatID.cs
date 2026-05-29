using System;

namespace FuryStudios.FurySDK
{
	[Serializable]
	public struct StatID
	{
		public string id;

		public StatID(string id)
		{
			this.id = null;
		}

		public static explicit operator string(StatID stat)
		{
			return null;
		}

		public static implicit operator StatID(string id)
		{
			return default(StatID);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
