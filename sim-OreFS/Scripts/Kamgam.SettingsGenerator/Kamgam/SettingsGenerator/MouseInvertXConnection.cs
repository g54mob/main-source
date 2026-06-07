namespace Kamgam.SettingsGenerator
{
	public class MouseInvertXConnection : Connection<bool>
	{
		private bool value;

		private static bool currentValue;

		public static bool CurrentValue => currentValue;

		public override bool Get()
		{
			return value;
		}

		public override void Set(bool mouseInvertX)
		{
			value = mouseInvertX;
			currentValue = value;
			NotifyListenersIfChanged(mouseInvertX);
		}
	}
}
