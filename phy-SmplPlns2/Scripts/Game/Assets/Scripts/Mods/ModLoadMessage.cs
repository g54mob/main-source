using System;

namespace Assets.Scripts.Mods
{
	public class ModLoadMessage
	{
		public DateTime DateTime { get; private set; }

		public string Message { get; private set; }

		public ModInfo Mod { get; private set; }

		public ModLoadMessage(ModInfo mod, string message, params object[] args)
		{
			Mod = mod;
			Message = ((args == null || args.Length == 0) ? message : string.Format(message, args));
			DateTime = DateTime.Now;
		}
	}
}
