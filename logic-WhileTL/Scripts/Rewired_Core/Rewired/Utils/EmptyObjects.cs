using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EmptyObjects<T>
	{
		private static T[] mggYCeqGblCBmIEfiOfqlhelwzZl;

		private static IList<T> vXZBQqDhOivdagDYlkmHLbxOvJqu;

		public static T[] array => mggYCeqGblCBmIEfiOfqlhelwzZl ?? (mggYCeqGblCBmIEfiOfqlhelwzZl = new T[0]);

		public static IList<T> EmptyReadOnlyIListT => vXZBQqDhOivdagDYlkmHLbxOvJqu ?? (vXZBQqDhOivdagDYlkmHLbxOvJqu = new ReadOnlyCollection<T>(new List<T>()));
	}
}
