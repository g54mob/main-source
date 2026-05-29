using System;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Utils
{
	public static class ArrayTools
	{
		public static int[] ConvertToIntArray(Array array)
		{
			return null;
		}

		public static T[] DeepClone<T>(T[] array) where T : class, IDeepCloneable
		{
			return null;
		}

		public static T[] ShallowCopy<T>(T[] array)
		{
			return null;
		}

		public static void ShallowCopy<T>(T[] sourceArray, T[] targetArray)
		{
		}

		public static void ShallowCopy(int[] sourceArray, int[] targetArray)
		{
		}

		public static void ShallowCopy(float[] sourceArray, float[] targetArray)
		{
		}

		public static void ShallowCopy(bool[] sourceArray, bool[] targetArray)
		{
		}

		public static byte[] CopyRange(byte[] inArray, int startPos, int length)
		{
			return null;
		}

		public static int[] CopyRange(int[] inArray, int startPos, int length)
		{
			return null;
		}

		public static float[] CopyRange(float[] inArray, int startPos, int length)
		{
			return null;
		}

		public static string[] CopyRange(string[] inArray, int startPos, int length)
		{
			return null;
		}

		public static byte[] Combine(byte[] inArray1, byte[] inArray2)
		{
			return null;
		}

		public static int[] Combine(int[] inArray1, int[] inArray2)
		{
			return null;
		}

		public static float[] Combine(float[] inArray1, float[] inArray2)
		{
			return null;
		}

		public static string[] Combine(string[] inArray1, string[] inArray2)
		{
			return null;
		}

		public static T[] ParseArray<T>(string line)
		{
			return null;
		}

		public static T[] SortAscending<T>(T[] array, out int[] sortedIndices) where T : IComparable<T>
		{
			sortedIndices = null;
			return null;
		}

		public static T[] SortDescending<T>(T[] array, out int[] sortedIndices, bool ascending = true) where T : IComparable<T>
		{
			sortedIndices = null;
			return null;
		}

		public static int Add<T>(ref T[] array, T item)
		{
			return 0;
		}

		public static int AddIfUnique<T>(ref T[] array, T item)
		{
			return 0;
		}

		public static int Insert<T>(ref T[] array, int index, T item)
		{
			return 0;
		}

		public static bool RemoveAt<T>(ref T[] array, int index)
		{
			return false;
		}

		public static bool Remove<T>(ref T[] array, T item)
		{
			return false;
		}

		public static void Combine<T>(ref T[] array1, T[] array2)
		{
		}

		public static T[] Add<T>(T[] array, T item)
		{
			return null;
		}

		public static T[] AddIfUnique<T>(T[] array, T item)
		{
			return null;
		}

		public static T[] Insert<T>(T[] array, int index, T item)
		{
			return null;
		}

		public static T[] RemoveAt<T>(T[] array, int index)
		{
			return null;
		}

		public static T[] Remove<T>(T[] array, T item)
		{
			return null;
		}

		public static T[] Combine<T>(T[] array1, T[] array2)
		{
			return null;
		}

		public static int IndexOf<T>(T[] array, T item)
		{
			return 0;
		}

		public static bool Contains<T>(T[] array, T item)
		{
			return false;
		}

		public static T Find<T>(T[] array, Predicate<T> predicate)
		{
			return default(T);
		}

		public static bool SubArray<T>(ref T[] array, int startIndex)
		{
			return false;
		}

		public static bool SubArray<T>(ref T[] array, int startIndex, int count)
		{
			return false;
		}

		public static void Expand<T>(ref T[] array, int length)
		{
		}

		public static void Trim(string[] array)
		{
		}

		public static RaycastHit[] SortNearToFar(RaycastHit[] hits)
		{
			return null;
		}

		public static void MoveEntryUp<T>(T[] array, int index)
		{
		}

		public static void MoveEntryDown<T>(T[] array, int index)
		{
		}

		public static void Compact<T>(ref T[] array) where T : class
		{
		}

		public static int IndexOf(int[] array, int value)
		{
			return 0;
		}

		public static int IndexOf(float[] array, float value)
		{
			return 0;
		}

		public static int IndexOf(short[] array, short value)
		{
			return 0;
		}

		public static int IndexOf(ushort[] array, ushort value)
		{
			return 0;
		}

		public static int IndexOf(uint[] array, uint value)
		{
			return 0;
		}

		public static int IndexOf(double[] array, double value)
		{
			return 0;
		}

		public static int IndexOf(bool[] array, bool value)
		{
			return 0;
		}

		public static int IndexOf(string[] array, string value)
		{
			return 0;
		}

		public static int IndexOf(string[] array, string value, StringComparison stringComparison)
		{
			return 0;
		}

		public static void Fill<T>(T[] array, T value)
		{
		}

		public static void Fill<T>(T[] array, T value, int startIndex)
		{
		}

		public static void Fill<T>(T[] array, T value, int startIndex, int length)
		{
		}

		public static void Populate<T>(T[] array, int startIndex, int length, Func<T> instantiator)
		{
		}

		public static void Populate<T>(T[] array, int startIndex, int length) where T : class, new()
		{
		}

		public static void Populate<T>(T[] array) where T : class, new()
		{
		}

		public static void Populate<T>(T[] array, Func<T> instantiator)
		{
		}

		public static int Count<T>(T[] array, Predicate<T> predicate)
		{
			return 0;
		}

		public static bool IsEqual(byte[] a1, byte[] a2)
		{
			return false;
		}

		public static bool Contains(string[] array, string item, bool ignoreCase)
		{
			return false;
		}

		public static int AddIfUnique(ref string[] array, string item, bool ignoreCase)
		{
			return 0;
		}

		public static void RemoveDuplicates(ref string[] array, bool ignoreCase)
		{
		}

		public static bool Remove(ref string[] array, string item, bool ignoreCase)
		{
			return false;
		}

		public static string[] ToLowerStripSpaces(string[] array)
		{
			return null;
		}

		public static int ToBitmask(bool[] array, int startIndex, int count = 32)
		{
			return 0;
		}

		public static bool IsNullOrEmpty<T>(T[] array)
		{
			return false;
		}
	}
}
