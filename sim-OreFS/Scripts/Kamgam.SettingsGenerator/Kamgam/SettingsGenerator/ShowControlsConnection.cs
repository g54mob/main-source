namespace Kamgam.SettingsGenerator
{
	public class ShowControlsConnection : Connection<bool>
	{
		private bool value = true;

		private static bool currentValue;

		public static bool CurrentValue => currentValue;

		public override bool Get()
		{
			return value;
		}

		public override void Set(bool showControls)
		{
			value = showControls;
			currentValue = value;
			NotifyListenersIfChanged(showControls);
		}
	}
}
