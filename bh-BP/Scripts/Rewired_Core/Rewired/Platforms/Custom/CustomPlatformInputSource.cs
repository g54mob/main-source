namespace Rewired.Platforms.Custom
{
	public abstract class CustomPlatformInputSource : CustomInputSource
	{
		public new abstract class Joystick : CustomInputSource.Joystick
		{
			protected Joystick(string P_0, long P_1, int P_2, int P_3)
				: base(null, 0L, 0, 0)
			{
			}
		}

		public sealed class InitOptions
		{
			public CustomPlatformUnifiedKeyboardSource unifiedKeyboardSource;

			public CustomPlatformUnifiedMouseSource unifiedMouseSource;
		}

		private readonly CustomPlatformConfigVars KFgiFVvwaoNWcODBiOUMnpdpNMSA;

		private readonly bool blastmzerkYYMkqAXHAuLooIwmzd;

		private readonly bool RpCgtigHmIYBsFhUOKDCeQojZYpIB;

		private bool qCapJThGTCjGbhliNvVlLKmQLoto;

		protected CustomPlatformInputSource(CustomPlatformConfigVars P_0, InitOptions P_1)
			: base(0)
		{
		}

		internal override void ClXPqQHQbxEYbLGYANIBDPkrIbwHA()
		{
		}

		internal override void yJJiJyHClDKYfyDcnimKwpopQEQH()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
