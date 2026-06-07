namespace VoxelBusters.EssentialKit
{
	public class TextInputFieldOptions
	{
		public class Builder
		{
			private TextInputFieldOptions m_options;

			public Builder SetText(string text)
			{
				return null;
			}

			public Builder SetPlaceholderText(string placeholderText)
			{
				return null;
			}

			public Builder SetIsSecured(bool isSecured)
			{
				return null;
			}

			public Builder SetKeyboardInputType(KeyboardInputType type)
			{
				return null;
			}

			public TextInputFieldOptions Build()
			{
				return null;
			}
		}

		public string Text { get; private set; }

		public string PlaceholderText { get; private set; }

		public bool IsSecured { get; private set; }

		public KeyboardInputType KeyboardInputType { get; private set; }
	}
}
