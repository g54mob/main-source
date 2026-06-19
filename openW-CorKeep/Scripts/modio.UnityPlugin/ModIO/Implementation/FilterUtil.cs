namespace ModIO.Implementation
{
	internal static class FilterUtil
	{
		public static string ConvertToURL(SearchFilter searchFilter)
		{
			string text = string.Empty;
			string text2 = (searchFilter.isSortAscending ? "_sort=" : "_sort=-");
			switch (searchFilter.sortBy)
			{
			case SortModsBy.Name:
				text = text + "&" + text2 + "name";
				break;
			case SortModsBy.Rating:
				text = text + "&" + text2 + "rating";
				break;
			case SortModsBy.Popular:
				text = text + "&" + text2 + "popular";
				break;
			case SortModsBy.Downloads:
				text = text + "&" + text2 + "downloads";
				break;
			case SortModsBy.Subscribers:
				text = text + "&" + text2 + "subscribers";
				break;
			case SortModsBy.DateSubmitted:
				text = text + "&" + text2 + "id";
				break;
			}
			foreach (string searchPhrase in searchFilter.searchPhrases)
			{
				if (!string.IsNullOrWhiteSpace(searchPhrase))
				{
					text = text + "&_q=" + searchPhrase;
				}
			}
			if (searchFilter.tags.Count > 0)
			{
				text += "&tags=";
				foreach (string tag in searchFilter.tags)
				{
					text = text + tag + ",";
				}
				text = text.Trim(',');
			}
			if (searchFilter.users.Count > 0)
			{
				text += "&submitted_by=";
				foreach (long user in searchFilter.users)
				{
					text += $"{user},";
				}
				text = text.Trim(',');
			}
			return text;
		}

		public static string AddPagination(SearchFilter filter, string url)
		{
			int num = 100;
			int num2 = filter.pageIndex * filter.pageSize;
			url += string.Format("&{0}{1}&{2}{3}", "_limit=", num, "_offset=", num2);
			return url;
		}

		public static string LastEntryPagination()
		{
			return string.Format("&{0}id&{1}{2}&{3}{4}", "_sort=-", "_limit=", 1, "_offset=", 0);
		}
	}
}
