namespace Brewery.UI.Components
{
	public readonly struct TabDefinition
	{
		public string Key { get; }

		public string ButtonId { get; }

		public string ContentId { get; }

		public string Label { get; }

		public TabDefinition(string key, string buttonId, string contentId, string label)
		{
			Key = null;
			ButtonId = null;
			ContentId = null;
			Label = null;
		}
	}
}
