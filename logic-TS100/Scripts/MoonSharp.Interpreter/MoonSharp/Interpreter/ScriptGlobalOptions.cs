using MoonSharp.Interpreter.Interop;
using MoonSharp.Interpreter.Platforms;

namespace MoonSharp.Interpreter
{
	public class ScriptGlobalOptions
	{
		public CustomConvertersCollection CustomConverters { get; set; }

		public IPlatformAccessor Platform { get; set; }

		internal ScriptGlobalOptions()
		{
			Platform = PlatformAutoDetector.GetDefaultPlatform();
			CustomConverters = new CustomConvertersCollection();
		}
	}
}
