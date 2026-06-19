using System;

namespace TH20.Analytics
{
	[Serializable]
	public struct GameEventInfo
	{
		public string Name;

		public int EventID;

		public int EventRevision;

		public bool Enabled;
	}
}
