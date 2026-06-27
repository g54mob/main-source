using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EmptyObjects<T>
	{
		private static T[] JRoaHwjBfDcLUjOnrSBdKATGVwur;

		private static IList<T> CMTbvsxBpfGVQRKvQWGGADnbvNpR;

		public static T[] array => JRoaHwjBfDcLUjOnrSBdKATGVwur ?? (JRoaHwjBfDcLUjOnrSBdKATGVwur = new T[0]);

		public static IList<T> EmptyReadOnlyIListT => CMTbvsxBpfGVQRKvQWGGADnbvNpR ?? (CMTbvsxBpfGVQRKvQWGGADnbvNpR = new ReadOnlyCollection<T>(new List<T>()));
	}
}
