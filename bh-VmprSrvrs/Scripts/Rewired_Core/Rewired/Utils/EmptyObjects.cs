using System.Collections.Generic;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EmptyObjects<T>
	{
		private static T[] EVJHClsGBaKvuiGGHdqBjFaiqjpm;

		private static IList<T> ZqeKqzmELCUrgELAisJwxXOLNJyG;

		public static T[] array => null;

		public static IList<T> EmptyReadOnlyIListT => null;
	}
}
