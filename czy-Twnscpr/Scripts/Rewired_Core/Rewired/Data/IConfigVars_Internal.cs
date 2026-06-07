using Rewired.Utils.Classes.Data;

namespace Rewired.Data
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IConfigVars_Internal
	{
		KeyedGetSetValueStore<string> values { get; }
	}
}
