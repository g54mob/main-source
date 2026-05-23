using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EmptyObjects<T>
	{
		private static T[] AQbwABANpydSVGhHMkmtWznOOYQ;

		private static IList<T> NiQsSPdiGvjHXqbuFDrEksaxYyfN;

		public static T[] array
		{
			get
			{
				return AQbwABANpydSVGhHMkmtWznOOYQ ?? (AQbwABANpydSVGhHMkmtWznOOYQ = new T[0]);
			}
		}

		public static IList<T> EmptyReadOnlyIListT
		{
			get
			{
				return NiQsSPdiGvjHXqbuFDrEksaxYyfN ?? (NiQsSPdiGvjHXqbuFDrEksaxYyfN = new ReadOnlyCollection<T>(new List<T>()));
			}
		}
	}
}
