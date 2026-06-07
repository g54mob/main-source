namespace VoxelBusters.EssentialKit
{
	public class AppShortcutItem
	{
		public class Builder
		{
			private readonly string m_identifier;

			private readonly string m_title;

			private string m_subtitle;

			private string m_iconFileName;

			public Builder(string identifier, string title)
			{
			}

			public Builder SetSubtitle(string subtitle)
			{
				return null;
			}

			public Builder SetIconFileName(string iconFileNameWithExtension)
			{
				return null;
			}

			public AppShortcutItem Build()
			{
				return null;
			}
		}

		public string Identifier { get; private set; }

		public string Title { get; private set; }

		public string Subtitle { get; private set; }

		public string IconFileName { get; private set; }
	}
}
