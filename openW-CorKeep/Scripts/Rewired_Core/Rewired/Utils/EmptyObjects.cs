using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EmptyObjects<T>
	{
		private static T[] EKZUcuEQGTldLakZRglEHkOQgZJmA;

		private static IList<T> HPcSrcQrSpdbPHMBgWqrdigvtmMaA;

		public static T[] array => EKZUcuEQGTldLakZRglEHkOQgZJmA ?? (EKZUcuEQGTldLakZRglEHkOQgZJmA = new T[0]);

		public static IList<T> EmptyReadOnlyIListT => HPcSrcQrSpdbPHMBgWqrdigvtmMaA ?? (HPcSrcQrSpdbPHMBgWqrdigvtmMaA = new ReadOnlyCollection<T>(new List<T>()));
	}
}
