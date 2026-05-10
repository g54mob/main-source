namespace Animancer
{
	public static class Strings
	{
		public static class DocsURLs
		{
			public const string Documentation = "https://kybernetik.com.au/animancer";

			public const string APIDocumentation = "https://kybernetik.com.au/animancer/api/Animancer";

			public const string ExampleAPIDocumentation = "https://kybernetik.com.au/animancer/api/Animancer.Examples.";

			public const string DeveloperEmail = "animancer@kybernetik.com.au";

			public const string LatestVersion = "https://kybernetik.com.au/animancer/latest-version.txt";

			public const string OptionalWarning = "https://kybernetik.com.au/animancer/api/Animancer/OptionalWarning";
		}

		public static class Tooltips
		{
			public const string MiddleClickReset = "\n• Middle Click = reset to default value";

			public const string FadeDuration = "The amount of time the transition will take, e.g:\n• 0s = Instant\n• 0.25s = quarter of a second (Default)\n• 0.25x = quarter of the animation length\n• x = Normalized, s = Seconds, f = Frame\n• Middle Click = reset to default value";

			public const string Speed = "How fast the animation will play, e.g:\n• 0x = paused\n• 1x = normal speed\n• -2x = double speed backwards";

			public const string OptionalSpeed = "How fast the animation will play, e.g:\n• 0x = paused\n• 1x = normal speed\n• -2x = double speed backwards\n• Disabled = keep previous speed\n• Middle Click = reset to default value";

			public const string NormalizedStartTime = "• Enabled = use FadeMode.FromStart and always restart at this time.\n• Disabled = use FadeMode.FixedSpeed and continue from the current time if already playing.\n• x = Normalized, s = Seconds, f = Frame";

			public const string EndTime = "The time when the End Callback will be triggered.\n• x = Normalized, s = Seconds, f = Frame\n\nDisabling the toggle automates the value:\n• Speed >= 0 ends at 1x\n• Speed < 0 ends at 0x";

			public const string CallbackTime = "The time when the Event Callback will be triggered.\n• x = Normalized, s = Seconds, f = Frame";
		}

		public const string ProductName = "Animancer";

		public const string MenuPrefix = "Animancer/";

		public const string CreateMenuPrefix = "Assets/Create/Animancer/";

		public const string ExamplesMenuPrefix = "Animancer/Examples/";

		public const string AnimancerToolsMenuPath = "Window/Animation/Animancer Tools";

		public const int AssetMenuOrder = 410;

		public const string UnityEditor = "UNITY_EDITOR";

		public const string Assertions = "UNITY_ASSERTIONS";

		public const string Indent = "    ";

		public const string ProOnlyTag = "";

		public const string MustBeFinite = "must not be NaN or Infinity";
	}
}
