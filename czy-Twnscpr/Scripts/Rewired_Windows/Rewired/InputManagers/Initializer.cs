using Rewired.Data;
using Rewired.Interfaces;

namespace Rewired.InputManagers
{
	[Rewired.CustomClassObfuscation]
	[Rewired.CustomObfuscation]
	internal class Initializer : Rewired.PlatformInitializer
	{
		private static Rewired.PlatformInitializer instance;

		public static Rewired.PlatformInitializer GetPlatformInitializer()
		{
			return null;
		}

		public override object Initialize(Rewired.Data.IConfigVars_Internal configVars)
		{
			return null;
		}

		public override Rewired.Interfaces.IElementIdentifierTool CreateTool(string inputSourceString)
		{
			return null;
		}
	}
}
