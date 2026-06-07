using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class EmptyObjects<T>
	{
		private static T[] mHIHoAhEEDIKZGxjPoowvVovytZb;

		private static IList<T> fuzlgAAztSwsHFXAUphXnflIfZc;

		public static T[] array => mHIHoAhEEDIKZGxjPoowvVovytZb ?? (mHIHoAhEEDIKZGxjPoowvVovytZb = new T[0]);

		public static IList<T> EmptyReadOnlyIListT => fuzlgAAztSwsHFXAUphXnflIfZc ?? (fuzlgAAztSwsHFXAUphXnflIfZc = new ReadOnlyCollection<T>(new List<T>()));
	}
}
