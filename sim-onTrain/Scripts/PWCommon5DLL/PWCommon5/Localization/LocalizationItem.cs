using System.Collections.Generic;

namespace PWCommon5.Localization
{
	public class LocalizationItem
	{
		public string Key;

		public string Val = "";

		public string Tooltip = "";

		public string Help = "";

		public string Context = "";

		public List<OnlineHelpItem> OnlineHelpItems = new List<OnlineHelpItem>();

		public override string ToString()
		{
			return Key;
		}
	}
}
