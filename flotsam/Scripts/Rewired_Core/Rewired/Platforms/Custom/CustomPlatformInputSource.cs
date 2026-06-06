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

		private readonly CustomPlatformConfigVars MwRauGFlCqPTmhojQJFbokrGsSAv;

		private readonly bool jRwdegLSGuHQkXYYEoQVAkezNxlt;

		private readonly bool PkGgjxtSKYnFECKkJFObFlsuCJzQ;

		private bool iyqrCWTpuGSVIMMiKKYEIcNjfnjB;

		protected CustomPlatformInputSource(CustomPlatformConfigVars P_0, InitOptions P_1)
			: base(100, (P_1 != null && P_1.unifiedKeyboardSource != null && P_0.useNativeKeyboard) ? new jdworecBqqUHwZUEraJqTXnkxHg(P_1.unifiedKeyboardSource) : null, (P_1 != null && P_1.unifiedMouseSource != null && P_0.useNativeMouse) ? new MuKsOykGjJRthCZmnTPmZdEWdocg(P_1.unifiedMouseSource) : null)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("configVars");
			}
			MwRauGFlCqPTmhojQJFbokrGsSAv = P_0;
			if (P_1 == null || P_1.unifiedKeyboardSource == null)
			{
				P_0.useNativeKeyboard = false;
			}
			if (P_1 == null || P_1.unifiedMouseSource == null)
			{
				P_0.useNativeMouse = false;
			}
			jRwdegLSGuHQkXYYEoQVAkezNxlt = P_0.useNativeKeyboard;
			PkGgjxtSKYnFECKkJFObFlsuCJzQ = P_0.useNativeMouse;
		}

		internal virtual void LgfExtxKRXtYSJMtDyOXBMbfOfaK()
		{
			base.AjJwsLldBlpITmjcHENsWTmMTamU();
			if (jRwdegLSGuHQkXYYEoQVAkezNxlt && VZDDvpxLFXkIreYsfAIRCvBwyrBb() is YFsnstQgfUozxyzUkSNqQIBNvLRi)
			{
				(VZDDvpxLFXkIreYsfAIRCvBwyrBb() as YFsnstQgfUozxyzUkSNqQIBNvLRi).cdhUdinUXBbjeznFyADwDrQawlLjA();
			}
			if (PkGgjxtSKYnFECKkJFObFlsuCJzQ && OnPuJOAXguOMgIKLSOoPvezSBQuK() is YFsnstQgfUozxyzUkSNqQIBNvLRi)
			{
				(OnPuJOAXguOMgIKLSOoPvezSBQuK() as YFsnstQgfUozxyzUkSNqQIBNvLRi).cdhUdinUXBbjeznFyADwDrQawlLjA();
			}
		}

		internal virtual void xUcgfWHenDgVtTKjzYnIpdUssZyAA()
		{
			base.ugDiQtlpJXWlRXrEwhijlruENhKI();
			IList<CustomInputSource.Joystick> joysticks = GetJoysticks();
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				joysticks[i].zdtEQHAhYudtnhGnCtRGmJeoXkvv();
				joysticks[i].Update();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!iyqrCWTpuGSVIMMiKKYEIcNjfnjB)
			{
				iyqrCWTpuGSVIMMiKKYEIcNjfnjB = true;
				base.Dispose(disposing);
			}
		}
	}
}
