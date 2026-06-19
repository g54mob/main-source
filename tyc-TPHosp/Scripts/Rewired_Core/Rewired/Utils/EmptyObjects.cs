using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class EmptyObjects<T>
	{
		private static T[] YDiWHoGivIfdThkTSDalbHHbBzrD;

		private static IList<T> XGZaJcbjQFgBZGAiaHzMjtWBuTeA;

		public static T[] array => YDiWHoGivIfdThkTSDalbHHbBzrD ?? (YDiWHoGivIfdThkTSDalbHHbBzrD = new T[0]);

		public static IList<T> EmptyReadOnlyIListT => XGZaJcbjQFgBZGAiaHzMjtWBuTeA ?? (XGZaJcbjQFgBZGAiaHzMjtWBuTeA = new ReadOnlyCollection<T>(new List<T>()));
	}
}
