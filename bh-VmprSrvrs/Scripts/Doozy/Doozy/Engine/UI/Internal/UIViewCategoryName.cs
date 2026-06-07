using System;

namespace Doozy.Engine.UI.Internal
{
	[Serializable]
	public class UIViewCategoryName
	{
		private const string DEFAULT_CATEGORY = "General";

		private const string DEFAULT_NAME = "Unnamed";

		private const bool DEFAULT_INSTANT_ACTION = false;

		public string Category;

		public bool InstantAction;

		public string Name;

		public UIViewCategoryName()
		{
		}

		public UIViewCategoryName(string viewCategory, string viewName)
		{
		}

		public UIViewCategoryName(string viewCategory, string viewName, bool instantAction)
		{
		}

		public UIViewCategoryName Copy()
		{
			return null;
		}

		public void Reset()
		{
		}
	}
}
