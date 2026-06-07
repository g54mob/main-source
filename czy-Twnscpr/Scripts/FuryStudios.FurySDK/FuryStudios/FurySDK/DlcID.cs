using System;

namespace FuryStudios.FurySDK
{
	[Serializable]
	public struct DlcID
	{
		public string id;

		public DlcID(string id)
		{
			this.id = null;
		}

		public static explicit operator string(DlcID achievement)
		{
			return null;
		}

		public static implicit operator DlcID(string id)
		{
			return default(DlcID);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
