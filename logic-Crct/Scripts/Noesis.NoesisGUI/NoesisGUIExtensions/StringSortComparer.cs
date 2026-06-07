namespace NoesisGUIExtensions
{
	public class StringSortComparer : SortComparer
	{
		public delegate string GetItemTextCallback(object item);

		public delegate bool NeedsRefreshCallback(object item, string propertyName);

		private bool _isCaseSensitive;

		private GetItemTextCallback _getItemText;

		private NeedsRefreshCallback _needsRefresh;

		public StringSortComparer(bool isCaseSensitive = false, GetItemTextCallback getItemText = null, NeedsRefreshCallback needsRefresh = null)
		{
		}

		public override int Compare(object i0, object i1)
		{
			return 0;
		}

		public override bool NeedsRefresh(object item, string propertyName)
		{
			return false;
		}
	}
}
