using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EmptyObjects<T>
	{
		private static T[] tIhanOklbsAskcDIqgcjvFlYQXV;

		private static IList<T> qUSfVOXfWjqAkAHphIpGNJqnBjkF;

		public static T[] array
		{
			get
			{
				return tIhanOklbsAskcDIqgcjvFlYQXV ?? (tIhanOklbsAskcDIqgcjvFlYQXV = new T[0]);
			}
		}

		public static IList<T> EmptyReadOnlyIListT
		{
			get
			{
				return qUSfVOXfWjqAkAHphIpGNJqnBjkF ?? (qUSfVOXfWjqAkAHphIpGNJqnBjkF = new ReadOnlyCollection<T>(new List<T>()));
			}
		}
	}
}
