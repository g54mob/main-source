using System;
using System.Collections.Generic;

namespace Rewired.Platforms.Custom
{
	public abstract class CustomPlatformInputSource : CustomInputSource
	{
		public new abstract class Joystick : CustomInputSource.Joystick
		{
			protected Joystick(string P_0, long P_1, int P_2, int P_3)
				: base(P_0, P_1, P_2, P_3)
			{
				_isConnected = true;
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
			: base(100, (P_1 != null && P_1.unifiedKeyboardSource != null && P_0.useNativeKeyboard) ? new lDzBwqAAxuLubNdqFaocEtZGUlXRA(P_1.unifiedKeyboardSource) : null, (P_1 != null && P_1.unifiedMouseSource != null && P_0.useNativeMouse) ? new CvKmvXQVgJPRofODkGXpUKCnedye(P_1.unifiedMouseSource) : null)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("configVars");
			}
			KFgiFVvwaoNWcODBiOUMnpdpNMSA = P_0;
			if (P_1 == null || P_1.unifiedKeyboardSource == null)
			{
				P_0.useNativeKeyboard = false;
			}
			if (P_1 == null || P_1.unifiedMouseSource == null)
			{
				P_0.useNativeMouse = false;
			}
			blastmzerkYYMkqAXHAuLooIwmzd = P_0.useNativeKeyboard;
			RpCgtigHmIYBsFhUOKDCeQojZYpIB = P_0.useNativeMouse;
		}

		internal virtual void XIpQtaDjyFnHemLiKdIiUKvQZqcJ()
		{
			base.ClXPqQHQbxEYbLGYANIBDPkrIbwHA();
			if (blastmzerkYYMkqAXHAuLooIwmzd && VfDFosXAxNHisBveamNjBMdoEblEA() is IdkykkkfBQChDFVijwXXDJFqlgNRA)
			{
				(VfDFosXAxNHisBveamNjBMdoEblEA() as IdkykkkfBQChDFVijwXXDJFqlgNRA).oFpVdjVtxBKxUElfpPSLutCFqvFm();
			}
			if (RpCgtigHmIYBsFhUOKDCeQojZYpIB && KNNmHhsEvsKWVztdXBolepStAmgc() is IdkykkkfBQChDFVijwXXDJFqlgNRA)
			{
				(KNNmHhsEvsKWVztdXBolepStAmgc() as IdkykkkfBQChDFVijwXXDJFqlgNRA).oFpVdjVtxBKxUElfpPSLutCFqvFm();
			}
		}

		internal virtual void toggbBIpRRxHXdvRaparoMKLkCcP()
		{
			base.yJJiJyHClDKYfyDcnimKwpopQEQH();
			IList<CustomInputSource.Joystick> joysticks = GetJoysticks();
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				joysticks[i].jXjAOOeiVexXqEZIVMalnsxHhMjC();
				joysticks[i].Update();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!qCapJThGTCjGbhliNvVlLKmQLoto)
			{
				qCapJThGTCjGbhliNvVlLKmQLoto = true;
				base.Dispose(disposing);
			}
		}
	}
}
