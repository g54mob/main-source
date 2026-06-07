using System.Collections.Generic;

namespace ModApi.Planet.CustomData
{
	public static class CustomPlanetModKeywords
	{
		private class CustomPlanetModKeywordsRegistration
		{
			public string Keyword { get; }

			public bool ShowInPlanetStudio { get; }

			public CustomPlanetModKeywordsRegistration(string keyword, bool showInPlanetStudio)
			{
				Keyword = keyword;
				ShowInPlanetStudio = showInPlanetStudio;
			}
		}

		private static List<string> _registeredKeywords = new List<string>();

		private static Dictionary<string, CustomPlanetModKeywordsRegistration> _registrations = new Dictionary<string, CustomPlanetModKeywordsRegistration>();

		public static IReadOnlyList<string> RegisteredKeywords => _registeredKeywords;

		public static bool IsRegistered(string keyword)
		{
			return _registeredKeywords.Contains(keyword);
		}

		public static void Register(string keyword, bool showInPlanetStudio)
		{
			if (!IsRegistered(keyword))
			{
				_registeredKeywords.Add(keyword);
				_registrations.Add(keyword, new CustomPlanetModKeywordsRegistration(keyword, showInPlanetStudio));
			}
		}

		public static bool ShowInPlanetStudio(string keyword)
		{
			if (!_registrations.TryGetValue(keyword, out var value))
			{
				return false;
			}
			return value.ShowInPlanetStudio;
		}

		public static void Unregister(string keyword)
		{
			if (IsRegistered(keyword))
			{
				_registeredKeywords.Remove(keyword);
				_registrations.Remove(keyword);
			}
		}
	}
}
