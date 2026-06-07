namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal abstract class LowLevelEvent
	{
		public uint id;

		public float timestamp;

		private static uint gypMNglUDVaVhjAuaWACqLIDhGg;

		protected static uint GetNextId()
		{
			if (gypMNglUDVaVhjAuaWACqLIDhGg == uint.MaxValue)
			{
				gypMNglUDVaVhjAuaWACqLIDhGg = 0u;
				return uint.MaxValue;
			}
			return ++gypMNglUDVaVhjAuaWACqLIDhGg;
		}
	}
}
