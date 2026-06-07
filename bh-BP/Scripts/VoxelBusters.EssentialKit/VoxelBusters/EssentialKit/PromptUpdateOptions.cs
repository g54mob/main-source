namespace VoxelBusters.EssentialKit
{
	public class PromptUpdateOptions
	{
		public class Builder
		{
			private PromptUpdateOptions m_options;

			public Builder SetIsForceUpdate(bool isForceUpdate)
			{
				return null;
			}

			public Builder SetPromptTitle(string promptTitle)
			{
				return null;
			}

			public Builder SetPromptMessage(string message)
			{
				return null;
			}

			public Builder SetAllowInstallationIfDownloaded(bool allowInstallationIfDownloaded)
			{
				return null;
			}

			public PromptUpdateOptions Build()
			{
				return null;
			}
		}

		public bool IsForceUpdate { get; private set; }

		public string Title { get; private set; }

		public string Message { get; private set; }

		public bool AllowInstallationIfDownloaded { get; private set; }

		private PromptUpdateOptions()
		{
		}
	}
}
