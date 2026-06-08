using System;

namespace KitchenMods
{
	public class ModPackLoadException : Exception
	{
		public ModPackLoadException(string msg)
			: base(msg)
		{
		}
	}
}
