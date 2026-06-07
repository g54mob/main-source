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

		private readonly CustomPlatformConfigVars ukGbLXrYCSMpnnLxJInHsdxuZTKf;

		private readonly bool vkAIKDvoDNwqgtMvHbFvgDBWYMtcA;

		private readonly bool faGoklJHRBGiiXOWSvjxZuHiFBpn;

		private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

		protected CustomPlatformInputSource(CustomPlatformConfigVars P_0, InitOptions P_1)
			: base(100, (P_1 != null && P_1.unifiedKeyboardSource != null && P_0.useNativeKeyboard) ? new uXRbSEVfGQCLlftPgMLAbfDDulMW(P_1.unifiedKeyboardSource) : null, (P_1 != null && P_1.unifiedMouseSource != null && P_0.useNativeMouse) ? new FcydRLXcArmgLNfBZbNrUGfkywzC(P_1.unifiedMouseSource) : null)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("configVars");
			}
			ukGbLXrYCSMpnnLxJInHsdxuZTKf = P_0;
			if (P_1 == null || P_1.unifiedKeyboardSource == null)
			{
				P_0.useNativeKeyboard = false;
			}
			if (P_1 == null || P_1.unifiedMouseSource == null)
			{
				P_0.useNativeMouse = false;
			}
			vkAIKDvoDNwqgtMvHbFvgDBWYMtcA = P_0.useNativeKeyboard;
			faGoklJHRBGiiXOWSvjxZuHiFBpn = P_0.useNativeMouse;
		}

		internal override void TlzckGoQDITHcUYaslQXPQBOhTwq()
		{
			base.TlzckGoQDITHcUYaslQXPQBOhTwq();
			if (vkAIKDvoDNwqgtMvHbFvgDBWYMtcA && ufjIvKCyejCncZnncxoHsJXMAdU() is ZXKvjUzfyuJYVxAVSCshLFZhsgYw)
			{
				(ufjIvKCyejCncZnncxoHsJXMAdU() as ZXKvjUzfyuJYVxAVSCshLFZhsgYw).TlzckGoQDITHcUYaslQXPQBOhTwq();
			}
			if (faGoklJHRBGiiXOWSvjxZuHiFBpn && IIhpAaXiKsDxxPRINWMLIdgMdsoS() is ZXKvjUzfyuJYVxAVSCshLFZhsgYw)
			{
				(IIhpAaXiKsDxxPRINWMLIdgMdsoS() as ZXKvjUzfyuJYVxAVSCshLFZhsgYw).TlzckGoQDITHcUYaslQXPQBOhTwq();
			}
		}

		internal override void cwOErHdoGDKEsFmyGHskstVlrOhbB()
		{
			base.cwOErHdoGDKEsFmyGHskstVlrOhbB();
			IList<CustomInputSource.Joystick> joysticks = GetJoysticks();
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				joysticks[i].bxYiqDXXeENnZsQaaUdUCxkYeQOq();
				joysticks[i].Update();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!wFtxnVROnubhehGUBaPWAtQsiPAD)
			{
				wFtxnVROnubhehGUBaPWAtQsiPAD = true;
				base.Dispose(disposing);
			}
		}
	}
}
