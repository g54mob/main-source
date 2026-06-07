namespace NoesisGUIExtensions
{
	public class StringFilterPredicate : FilterPredicate
	{
		public delegate string GetItemTextCallback(object item);

		public delegate bool NeedsRefreshCallback(object item, string propertyName);

		private StringFilterMode _mode;

		private bool _isCaseSensitive;

		private GetItemTextCallback _getItemText;

		private NeedsRefreshCallback _needsRefresh;

		private string _filter;

		public string Filter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public StringFilterPredicate(StringFilterMode mode = StringFilterMode.StartsWith, bool isCaseSensitive = false, GetItemTextCallback getItemText = null, NeedsRefreshCallback needsRefresh = null)
		{
		}

		public override bool Matches(object item)
		{
			return false;
		}

		public override bool NeedsRefresh(object item, string propertyName)
		{
			return false;
		}
	}
}
