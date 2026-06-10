using System;

namespace ModIO
{
	[Serializable]
	public struct CommentPage
	{
		public ModComment[] CommentObjects;

		public long totalSearchResultsFound;
	}
}
