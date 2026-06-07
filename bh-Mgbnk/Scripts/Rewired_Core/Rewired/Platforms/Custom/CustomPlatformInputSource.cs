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

		private readonly CustomPlatformConfigVars JZkQLwfopzUfnBKQwiZUPOXqymtH;

		private readonly bool sETGnEfjkxRrptWrsbAspmGRPcAI;

		private readonly bool SGnTVTBwsPNEFaoDbUjKeAWKNlIP;

		private bool xnDZxitqVHZHOyYrqzynfSMZNrSG;

		protected CustomPlatformInputSource(CustomPlatformConfigVars P_0, InitOptions P_1)
			: base(0)
		{
		}

		internal override void BHgDQnZQbcfBIQpPfoyJlySusCNV()
		{
		}

		internal override void niIJZPrTMHaYrfMOIYOAKpupbvf()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
