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
		internal const string initErrorMsg = "";

		private static PlatformInitializer nqrOjmLfgKzuVZiZBAyOdoLIjFqHA;

		public static PlatformInitializer GetPlatformInitializer()
		{
			if (nqrOjmLfgKzuVZiZBAyOdoLIjFqHA == null)
			{
				nqrOjmLfgKzuVZiZBAyOdoLIjFqHA = new Initializer();
			}
			return nqrOjmLfgKzuVZiZBAyOdoLIjFqHA;
		}

		public override object Initialize(IConfigVars_Internal configVars)
		{
			if (UnityTools.platform == Platform.Windows || UnityTools.platform == Platform.WindowsAppStore)
			{
				ConfigVars configVars2 = (ConfigVars)configVars;
				if (UnityTools.platform == Platform.Windows && configVars2.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.SDL2)
				{
					try
					{
						if (new hjLwTMfqoinFghIVhUAHNSmddwlk(configVars2, ReInput.GetHardwareJoystickMap_InputManager, ReInput.GetNewJoystickId, true, false, false) == null)
						{
							throw new Exception();
						}
					}
					catch
					{
						Logger.LogError("SDL2 could not be initialized! Make sure you have the SDL2 library installed. Please see the documentation for more information. Rewired will fall back to Unity input. Certain features may not be available.");
					}
					return null;
				}
				try
				{
					return new fFefNhCbntXshSNsZQmcBeOGabccA(configVars2, ReInput.GetHardwareJoystickMap_InputManager, ReInput.GetNewJoystickId);
				}
				catch (Exception)
				{
					Logger.LogWarning("Rewired will fall back to Unity input. Certain features may not be available.\n");
					return null;
				}
			}
			return null;
		}

		public override IElementIdentifierTool CreateTool(string inputSourceString)
		{
			if (inputSourceString == "DirectInput")
			{
				return new SCugXTcGgQeaugsEHNkauvnIVnHo();
			}
			if (inputSourceString == "RawInput")
			{
				return new msQNZbobIYYXLUApZmkTmfWFdCkH();
			}
			return null;
		}
	}
}
