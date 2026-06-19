using System.Collections.Generic;
using ModIO.Implementation;

namespace ModIO
{
	public class SearchFilter
	{
		private bool hasPageIndexBeenSet;

		private bool hasPageSizeBeenSet;

		internal string sortFieldName = string.Empty;

		internal bool isSortAscending = true;

		internal SortModsBy sortBy = SortModsBy.DateSubmitted;

		internal int pageIndex;

		internal int pageSize;

		internal List<string> searchPhrases = new List<string>();

		internal List<string> tags = new List<string>();

		internal List<long> users = new List<long>();

		public void AddSearchPhrase(string phrase)
		{
			searchPhrases.Add(phrase);
		}

		public void AddTag(string tag)
		{
			tags.Add(tag);
		}

		public void SortBy(SortModsBy category)
		{
			sortBy = category;
		}

		public void SetToAscending(bool isAscending)
		{
			isSortAscending = isAscending;
		}

		public void SetPageIndex(int pageIndex)
		{
			this.pageIndex = pageIndex;
			hasPageIndexBeenSet = true;
		}

		public void SetPageSize(int pageSize)
		{
			this.pageSize = pageSize;
			hasPageSizeBeenSet = true;
		}

		public void AddUser(long userId)
		{
			users.Add(userId);
		}

		public bool IsSearchFilterValid(out Result result)
		{
			if (!hasPageIndexBeenSet || !hasPageSizeBeenSet)
			{
				result = ResultBuilder.Create(20201u);
				Logger.Log(LogLevel.Error, "The pagination parameters haven't been set for this filter. Make sure to use SetPageIndex(int) and SetPageSize(int) before using a filter.");
				return false;
			}
			result = ResultBuilder.Success;
			return true;
		}
	}
}
