using System;

namespace Jundroo.ModTools.Core.Events
{
	public class PostProcessEventArgs : EventArgs
	{
		public ModInfo Mod { get; private set; }

		public IModResourceLoader ResourceLoader { get; private set; }

		public PostProcessEventArgs(ModInfo mod, IModResourceLoader resourceLoader)
		{
			Mod = mod;
			ResourceLoader = resourceLoader;
		}
	}
}
