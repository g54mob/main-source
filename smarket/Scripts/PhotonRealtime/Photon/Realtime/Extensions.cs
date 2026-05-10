using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;

namespace Photon.Realtime
{
	public static class Extensions
	{
		private static readonly List<object> keysWithNullValue;

		public static void Merge(this IDictionary target, IDictionary addHash)
		{
		}

		public static void MergeStringKeys(this IDictionary target, IDictionary addHash)
		{
		}

		public static string ToStringFull(this IDictionary origin)
		{
			return null;
		}

		public static string ToStringFull<T>(this List<T> data)
		{
			return null;
		}

		public static string ToStringFull(this object[] data)
		{
			return null;
		}

		public static ExitGames.Client.Photon.Hashtable StripToStringKeys(this IDictionary original)
		{
			return null;
		}

		public static ExitGames.Client.Photon.Hashtable StripToStringKeys(this ExitGames.Client.Photon.Hashtable original)
		{
			return null;
		}

		public static void StripKeysWithNullValues(this IDictionary original)
		{
		}

		public static void StripKeysWithNullValues(this ExitGames.Client.Photon.Hashtable original)
		{
		}

		public static bool Contains(this int[] target, int nr)
		{
			return false;
		}
	}
}
