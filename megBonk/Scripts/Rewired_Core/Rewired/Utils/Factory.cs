using System;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class Factory
	{
		public static object CreateInstance(Type type, object[] args = null)
		{
			return null;
		}
	}
}
