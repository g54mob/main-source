using System.Collections.Generic;

namespace PWCommon5.Localization
{
	public class LocalizationCategory
	{
		public string Name;

		public List<LocalizationItem> Items;

		public LocalizationCategory(string name)
		{
			Name = name;
			Items = new List<LocalizationItem>();
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
