namespace Kamgam.SettingsGenerator
{
	public class MouseInvertYConnection : Connection<bool>
	{
		private bool value;

		private static bool currentValue;

		public static bool CurrentValue => currentValue;

		public override bool Get()
		{
			return value;
		}

		public override void Set(bool mouseInvertY)
		{
			value = mouseInvertY;
			currentValue = value;
			NotifyListenersIfChanged(mouseInvertY);
		}
	}
}
