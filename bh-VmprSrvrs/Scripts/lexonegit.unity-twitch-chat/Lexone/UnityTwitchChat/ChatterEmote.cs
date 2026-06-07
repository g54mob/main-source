using System;

namespace Lexone.UnityTwitchChat
{
	[Serializable]
	public struct ChatterEmote
	{
		[Serializable]
		public struct Index
		{
			public int startIndex;

			public int endIndex;
		}

		public string id;

		public Index[] indexes;
	}
}
