using System;

namespace Brewery.UI.Components
{
	public readonly struct BadgeDefinition
	{
		public string Key { get; }

		public string ElementId { get; }

		public Func<bool> Predicate { get; }

		public Func<string> ValueProvider { get; }

		public BadgeDefinition(string key, string elementId, Func<bool> predicate, Func<string> valueProvider = null)
		{
			Key = null;
			ElementId = null;
			Predicate = null;
			ValueProvider = null;
		}
	}
}
