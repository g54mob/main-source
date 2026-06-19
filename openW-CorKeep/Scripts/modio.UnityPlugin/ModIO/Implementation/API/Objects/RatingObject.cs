using System;

namespace ModIO.Implementation.API.Objects
{
	[Serializable]
	public struct RatingObject
	{
		public uint game_id;

		public long mod_id;

		public int rating;

		public long date_added;
	}
}
