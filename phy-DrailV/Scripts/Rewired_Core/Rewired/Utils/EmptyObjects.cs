using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class EmptyObjects<T>
	{
		private static T[] ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb;

		private static IList<T> QhHGBlKlomYGMvTeGdAbnQSNKNoZ;

		public static T[] array => ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb ?? (ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb = new T[0]);

		public static IList<T> EmptyReadOnlyIListT => QhHGBlKlomYGMvTeGdAbnQSNKNoZ ?? (QhHGBlKlomYGMvTeGdAbnQSNKNoZ = new ReadOnlyCollection<T>(new List<T>()));
	}
}
