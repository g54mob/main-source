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

		private readonly CustomPlatformConfigVars hxbPruTbToeCzGaceFbObiWqfSFAb;

		private readonly bool AgSRNKBCTkcLzubPymswSWNFuzcM;

		private readonly bool mjijUJnXLQfKHxRbpvyCRxJAjJgW;

		private bool PkMGqpJiNABSapXYcwnYUTOTzqKc;

		protected CustomPlatformInputSource(CustomPlatformConfigVars P_0, InitOptions P_1)
			: base(100, (P_1 != null && P_1.unifiedKeyboardSource != null && P_0.useNativeKeyboard) ? new ApJBFPmUaorvODHNkPTioiBFwECG(P_1.unifiedKeyboardSource) : null, (P_1 != null && P_1.unifiedMouseSource != null && P_0.useNativeMouse) ? new hxycXAiSqHTUgzqdFOdDFlhyefffA(P_1.unifiedMouseSource) : null)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("configVars");
			}
			hxbPruTbToeCzGaceFbObiWqfSFAb = P_0;
			if (P_1 == null || P_1.unifiedKeyboardSource == null)
			{
				P_0.useNativeKeyboard = false;
			}
			if (P_1 == null || P_1.unifiedMouseSource == null)
			{
				P_0.useNativeMouse = false;
			}
			AgSRNKBCTkcLzubPymswSWNFuzcM = P_0.useNativeKeyboard;
			mjijUJnXLQfKHxRbpvyCRxJAjJgW = P_0.useNativeMouse;
		}

		internal virtual void gJZdHVzJGPkkJqIuhOysXmSBUqrg()
		{
			base.dipzRrboOzPXSHQrvmpVGGDsZefo();
			if (AgSRNKBCTkcLzubPymswSWNFuzcM && sMlcFzxGJhzRyPBLoqhjYWrIacIA() is tPGRFTYXuGFqwLQBERoDOsedxtCo)
			{
				(sMlcFzxGJhzRyPBLoqhjYWrIacIA() as tPGRFTYXuGFqwLQBERoDOsedxtCo).VrJMCCroCPHwrBSAEKbVbvzKcbSOA();
			}
			if (mjijUJnXLQfKHxRbpvyCRxJAjJgW && pZdBVaUjniuFnvHCmEeeCzCqaLzbb() is tPGRFTYXuGFqwLQBERoDOsedxtCo)
			{
				(pZdBVaUjniuFnvHCmEeeCzCqaLzbb() as tPGRFTYXuGFqwLQBERoDOsedxtCo).VrJMCCroCPHwrBSAEKbVbvzKcbSOA();
			}
		}

		internal virtual void AJKBGwFkiFPMsApkJTBxYxfImTtDA()
		{
			base.BEfVFJbaEZHDUohPIZLChbFkiDBZ();
			IList<CustomInputSource.Joystick> joysticks = GetJoysticks();
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				joysticks[i].UPHCvhWpNgGmuMtugfpncxPIRkon();
				joysticks[i].Update();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!PkMGqpJiNABSapXYcwnYUTOTzqKc)
			{
				PkMGqpJiNABSapXYcwnYUTOTzqKc = true;
				base.Dispose(disposing);
			}
		}
	}
}
