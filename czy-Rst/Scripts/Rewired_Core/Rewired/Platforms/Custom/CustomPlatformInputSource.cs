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

		private readonly CustomPlatformConfigVars ZHeOyFKdNkYfDDNnfJwbNUadiwfQ;

		private readonly bool esZlihUVDakiRxiSvbtRHtvIKXQnA;

		private readonly bool CYfvRgcsBQlYvqgsklynyxOHveWG;

		private bool fFVUbXGKyIEokqqMlkrYjilELNUR;

		protected CustomPlatformInputSource(CustomPlatformConfigVars P_0, InitOptions P_1)
			: base(100, (P_1 != null && P_1.unifiedKeyboardSource != null && P_0.useNativeKeyboard) ? new aeOZqktgSqNSwELCbRUTHkKYnUan(P_1.unifiedKeyboardSource) : null, (P_1 != null && P_1.unifiedMouseSource != null && P_0.useNativeMouse) ? new BPfqezbKcXedMkxyKolamgBrBFTR(P_1.unifiedMouseSource) : null)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("configVars");
			}
			ZHeOyFKdNkYfDDNnfJwbNUadiwfQ = P_0;
			if (P_1 == null || P_1.unifiedKeyboardSource == null)
			{
				P_0.useNativeKeyboard = false;
			}
			if (P_1 == null || P_1.unifiedMouseSource == null)
			{
				P_0.useNativeMouse = false;
			}
			esZlihUVDakiRxiSvbtRHtvIKXQnA = P_0.useNativeKeyboard;
			CYfvRgcsBQlYvqgsklynyxOHveWG = P_0.useNativeMouse;
		}

		internal virtual void GAUhOueCCBUNxngjmdJVfqcCNmLFb()
		{
			base.PusaYVcABdgihSkdmyFkhbobGEPF();
			if (esZlihUVDakiRxiSvbtRHtvIKXQnA && WGiWTegEKFEInJWOSunAWtaqdWCUA() is TYDBaeHokSxRYAIWLanmrGOioRgn)
			{
				(WGiWTegEKFEInJWOSunAWtaqdWCUA() as TYDBaeHokSxRYAIWLanmrGOioRgn).lGMbHviaOFCRZPbJVAugACVZhJmcA();
			}
			if (CYfvRgcsBQlYvqgsklynyxOHveWG && BsgRyFJghmDeJarLdvjREaudnpHP() is TYDBaeHokSxRYAIWLanmrGOioRgn)
			{
				(BsgRyFJghmDeJarLdvjREaudnpHP() as TYDBaeHokSxRYAIWLanmrGOioRgn).lGMbHviaOFCRZPbJVAugACVZhJmcA();
			}
		}

		internal virtual void opNhPNloeBnPQinQQKlEGDADpTRe()
		{
			base.jVehwmutETkRglGYTdMvCzjrpzjL();
			IList<CustomInputSource.Joystick> joysticks = GetJoysticks();
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				joysticks[i].yBKSMAHvVuJLGNUzduiKTanNxIEN();
				joysticks[i].Update();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!fFVUbXGKyIEokqqMlkrYjilELNUR)
			{
				fFVUbXGKyIEokqqMlkrYjilELNUR = true;
				base.Dispose(disposing);
			}
		}
	}
}
