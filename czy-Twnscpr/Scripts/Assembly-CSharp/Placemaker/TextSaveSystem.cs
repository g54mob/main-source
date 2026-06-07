using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Placemaker
{
	public class TextSaveSystem : MonoBehaviour
	{
		public interface ITextSaver
		{
			void SaveToText(List<int> values);

			void LoadFromText(BitArray bitArray, ref int bitIndex);
		}

		[SerializeField]
		private WorldMaster master;

		private static BitArray bitArray;

		private static char[] chars;

		private static readonly int bitsPerCharacter;

		private const int bitCountBitCount = 5;

		private const int typeCountBitCount = 4;

		public static string GetSpacedString(string srcString)
		{
			return null;
		}

		private static int GetBitsPerCharacter()
		{
			return 0;
		}

		public static void AddValue(List<int> values, int value, int bitCount)
		{
		}

		public static int ReadValue(BitArray bitArray, ref int index, int bitCount)
		{
			return 0;
		}

		private static int GetBitCount(int biggestValue)
		{
			return 0;
		}

		public static string SaveToString(List<SaveData.C> corners, List<SaveData.V> voxels)
		{
			return null;
		}

		public static bool LoadFromString(string saveString, List<SaveData.C> corners, List<SaveData.V> voxels)
		{
			return false;
		}

		private void LogBitArray(int bitCount)
		{
		}
	}
}
