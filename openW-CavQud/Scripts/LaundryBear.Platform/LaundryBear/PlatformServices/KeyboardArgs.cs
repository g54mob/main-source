namespace LaundryBear.PlatformServices
{
	public struct KeyboardArgs
	{
		public KeyboardType type;

		public bool isPassword;

		public bool isMultiline;

		public int minLength;

		public int maxLength;

		public string title;

		public string description;

		public static KeyboardArgs CreateKeyboardArgs()
		{
			return new KeyboardArgs
			{
				type = KeyboardType.Default,
				isPassword = false,
				isMultiline = false,
				minLength = -1,
				maxLength = -1,
				title = "",
				description = ""
			};
		}
	}
}
