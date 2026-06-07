using System.Collections.Generic;
using Jundroo.Common.Settings;
using Jundroo.Common.Utils;

namespace Assets.Scripts.Settings
{
	public class CraftFilterSettings : SettingsCategory<CraftFilterSettings>
	{
		public StringSetting ActiveSubdirectories { get; private set; }

		public StringSetting ActiveSubdirectory { get; private set; }

		public StringSetting ActiveTags { get; private set; }

		public StringSetting FavoriteSubdirectories { get; private set; }

		public StringSetting FavoriteTags { get; private set; }

		public StringSetting SortMode { get; private set; }

		public CraftFilterSettings()
			: base("Craft Filters")
		{
			base.State = SettingState.Hidden;
		}

		public void GetActiveSubdirectories(ICollection<string> activeSubdirectories)
		{
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(ActiveSubdirectories.Value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				activeSubdirectories.Add(current);
			}
		}

		public void GetActiveTags(ICollection<string> activeTags)
		{
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(ActiveTags.Value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				activeTags.Add(current);
			}
		}

		public void GetFavoriteSubdirectories(ICollection<string> favoriteSubdirectories)
		{
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(FavoriteSubdirectories.Value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				favoriteSubdirectories.Add(current);
			}
		}

		public void GetFavoriteTags(ICollection<string> favoriteTags)
		{
			StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(FavoriteTags.Value, ',').GetEnumerator();
			while (enumerator.MoveNext())
			{
				StringUtility.StringSplitEntry current = enumerator.Current;
				favoriteTags.Add(current);
			}
		}

		public void SetActiveSubdirectories(IEnumerable<string> activeSubdirectories)
		{
			ActiveSubdirectories.Value = string.Join(",", activeSubdirectories);
			CommitChanges();
		}

		public void SetActiveTags(IEnumerable<string> activeTags)
		{
			ActiveTags.Value = string.Join(",", activeTags);
			CommitChanges();
		}

		public void SetFavoriteSubdirectories(IEnumerable<string> favoriteSubdirectories)
		{
			FavoriteSubdirectories.Value = string.Join(",", favoriteSubdirectories);
			CommitChanges();
		}

		public void SetFavoriteTags(IEnumerable<string> favoriteTags)
		{
			FavoriteTags.Value = string.Join(",", favoriteTags);
			CommitChanges();
		}

		protected override void InitializeSettings()
		{
			ActiveSubdirectory = CreateString("Active Subdirectory").SetDefault(string.Empty);
			ActiveTags = CreateString("Active Tags").SetDefault(string.Empty);
			ActiveSubdirectories = CreateString("Active Subdirectories").SetDefault(string.Empty);
			FavoriteTags = CreateString("Favorite Tags").SetDefault(string.Empty);
			FavoriteSubdirectories = CreateString("Favorite Subdirectories").SetDefault(string.Empty);
			SortMode = CreateString("Sort Mode").SetDefault("Name ▲");
		}
	}
}
