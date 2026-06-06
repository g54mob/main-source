using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EmptyObjects<T>
	{
		private static T[] CMLrcdyuqHlsfNebWkiprlQjyAHp;

		private static IList<T> JRgOrdqScjtdztIhjXzUzXsArUAH;

		public static T[] array => CMLrcdyuqHlsfNebWkiprlQjyAHp ?? (CMLrcdyuqHlsfNebWkiprlQjyAHp = new T[0]);

		public static IList<T> EmptyReadOnlyIListT => JRgOrdqScjtdztIhjXzUzXsArUAH ?? (JRgOrdqScjtdztIhjXzUzXsArUAH = new ReadOnlyCollection<T>(new List<T>()));
	}
}
