using System;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;

namespace Rewired.InputManagers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class Initializer : PlatformInitializer
	{
		private static PlatformInitializer dRDHeKkMbuLtkydatQmJkNgNvxLd;

		public static PlatformInitializer GetPlatformInitializer()
		{
			if (dRDHeKkMbuLtkydatQmJkNgNvxLd == null)
			{
				dRDHeKkMbuLtkydatQmJkNgNvxLd = new Initializer();
			}
			return dRDHeKkMbuLtkydatQmJkNgNvxLd;
		}

		public override object Initialize(IConfigVars_Internal configVars)
		{
			if (UnityTools.platform == Platform.Windows || UnityTools.platform == Platform.WindowsAppStore)
			{
				try
				{
					return new BZPKnCwfHeRXUlPbVSripebwRgXq((ConfigVars)configVars, ReInput.GetHardwareJoystickMap_InputManager, ReInput.GetNewJoystickId);
				}
				catch (Exception)
				{
					Logger.LogWarning("Rewired will fall back to Unity input. Certain features may not be available.\nPlease see the Installation section of the documentation for information on required libraries. Documentation can be found in the menu: Window -> Rewired -> Help -> Documentation.");
					return null;
				}
			}
			return null;
		}

		public override IElementIdentifierTool CreateTool(string inputSourceString)
		{
			if (inputSourceString == "DirectInput")
			{
				return new QoKyYpJcKqBZDFzoxWKxpOvTXAeK();
			}
			if (inputSourceString == "RawInput")
			{
				return new mfyFjNcFgckdwcnPApWAtdWBGPLHB();
			}
			return null;
		}
	}
}
