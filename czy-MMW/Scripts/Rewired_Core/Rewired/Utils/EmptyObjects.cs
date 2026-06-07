using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EmptyObjects<T>
	{
		private static T[] ETSdPqxxrUVYbhyBxHLhQpbdSfke;

		private static IList<T> BmxeePdfboRREFumEAKuEZgUzmzD;

		public static T[] array => ETSdPqxxrUVYbhyBxHLhQpbdSfke ?? (ETSdPqxxrUVYbhyBxHLhQpbdSfke = new T[0]);

		public static IList<T> EmptyReadOnlyIListT => BmxeePdfboRREFumEAKuEZgUzmzD ?? (BmxeePdfboRREFumEAKuEZgUzmzD = new ReadOnlyCollection<T>(new List<T>()));
	}
}
