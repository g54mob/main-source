using UnityEngine.UIElements;

namespace Brewery.Localization
{
	public static class LocExtensions
	{
		public static void SetLocalized(this TextElement element, string table, string key)
		{
		}

		public static void SetLocalized(this TextElement element, string table, string key, params (string name, object value)[] args)
		{
		}

		public static void SetLocalizedTooltip(this VisualElement element, string table, string key)
		{
		}
	}
}
