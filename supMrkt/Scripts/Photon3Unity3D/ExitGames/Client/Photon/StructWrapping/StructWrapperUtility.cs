using System;
using System.Collections.Generic;

namespace ExitGames.Client.Photon.StructWrapping
{
	public static class StructWrapperUtility
	{
		public static Type GetWrappedType(this object obj)
		{
			return null;
		}

		public static StructWrapper<T> Wrap<T>(this T value, bool persistant)
		{
			return null;
		}

		public static StructWrapper<T> Wrap<T>(this T value)
		{
			return null;
		}

		public static StructWrapper<byte> Wrap(this byte value)
		{
			return null;
		}

		public static StructWrapper<bool> Wrap(this bool value)
		{
			return null;
		}

		public static bool IsType<T>(this object obj)
		{
			return false;
		}

		public static T DisconnectPooling<T>(this T table)
		{
			return default(T);
		}

		public static List<object> ReleaseAllWrappers(this List<object> collection)
		{
			return null;
		}

		public static object[] ReleaseAllWrappers(this object[] collection)
		{
			return null;
		}

		public static Hashtable ReleaseAllWrappers(this Hashtable table)
		{
			return null;
		}

		public static void BoxAll(this Hashtable table, bool recursive = false)
		{
		}

		public static T Unwrap<T>(this object obj)
		{
			return default(T);
		}

		public static T Get<T>(this object obj)
		{
			return default(T);
		}

		public static T Unwrap<T>(this Hashtable table, object key)
		{
			return default(T);
		}

		public static bool TryUnwrapValue<T>(this Hashtable table, byte key, out T value) where T : new()
		{
			value = default(T);
			return false;
		}

		public static bool TryGetValue<T>(this Hashtable table, byte key, out T value) where T : new()
		{
			value = default(T);
			return false;
		}

		public static bool TryGetValue<T>(this Hashtable table, object key, out T value) where T : new()
		{
			value = default(T);
			return false;
		}

		public static bool TryUnwrapValue<T>(this Hashtable table, object key, out T value) where T : new()
		{
			value = default(T);
			return false;
		}

		public static T Unwrap<T>(this Hashtable table, byte key)
		{
			return default(T);
		}

		public static T Get<T>(this Hashtable table, byte key)
		{
			return default(T);
		}
	}
}
