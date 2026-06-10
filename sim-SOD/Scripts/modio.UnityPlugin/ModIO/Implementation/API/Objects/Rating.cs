using System;

namespace ModIO.Implementation.API.Objects
{
	[Serializable]
	public struct Rating
	{
		public ModId modId;

		public ModRating rating;

		public DateTime dateAdded;
	}
}
