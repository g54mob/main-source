using System.Collections.Generic;

namespace ModIO
{
	public class SearchFilter
	{
		private bool hasPageIndexBeenSet;

		private bool hasPageSizeBeenSet;

		internal string sortFieldName;

		internal bool isSortAscending;

		internal SortModsBy sortBy;

		internal int pageIndex;

		internal int pageSize;

		internal List<string> searchPhrases;

		internal List<string> tags;

		internal List<long> users;

		public void AddSearchPhrase(string phrase)
		{
		}

		public void AddTag(string tag)
		{
		}

		public void SortBy(SortModsBy category)
		{
		}

		public void SetToAscending(bool isAscending)
		{
		}

		public void SetPageIndex(int pageIndex)
		{
		}

		public void SetPageSize(int pageSize)
		{
		}

		public void AddUser(long userId)
		{
		}

		public bool IsSearchFilterValid(out Result result)
		{
			result = default(Result);
			return false;
		}
	}
}
