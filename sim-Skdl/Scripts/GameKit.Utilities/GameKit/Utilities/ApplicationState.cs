namespace GameKit.Utilities
{
	public static class ApplicationState
	{
		private static bool _isQuitting;

		static ApplicationState()
		{
		}

		private static void Application_quitting()
		{
		}

		public static bool IsQuitting()
		{
			return false;
		}

		public static bool IsPlaying()
		{
			return false;
		}

		public static void Quit()
		{
		}
	}
}
