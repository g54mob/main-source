using Rewired.Dev;

namespace RewiredConsts
{
	public static class Player
	{
		[PlayerIdFieldInfo(friendlyName = "System")]
		public const int System = 9999999;

		[PlayerIdFieldInfo(friendlyName = "SP")]
		public const int SP = 0;
	}
}
