using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EmptyObjects<T>
	{
		private static T[] MHrpKPSmIyPSdBajdKTerCRXLIi;

		private static IList<T> PTWeGNvOzlghxIzSqpODqRAeqiXA;

		public static T[] array => MHrpKPSmIyPSdBajdKTerCRXLIi ?? (MHrpKPSmIyPSdBajdKTerCRXLIi = new T[0]);

		public static IList<T> EmptyReadOnlyIListT => PTWeGNvOzlghxIzSqpODqRAeqiXA ?? (PTWeGNvOzlghxIzSqpODqRAeqiXA = new ReadOnlyCollection<T>(new List<T>()));
	}
}
