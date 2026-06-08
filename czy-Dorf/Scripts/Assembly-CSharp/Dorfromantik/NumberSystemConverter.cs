using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dorfromantik
{
	public class NumberSystemConverter : ScriptableObject
	{
		[SerializeField]
		private Vector2Int minMaxValues = new Vector2Int(int.MinValue, int.MaxValue);

		[SerializeField]
		private int debug_DecodedNumber;

		[SerializeField]
		private string debug_EncodedNumber;

		[SerializeField]
		private char[] excludedChars = new char[10] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

		[SerializeField]
		private Vector2Int[] unicodeAreas = new Vector2Int[3]
		{
			new Vector2Int(48, 57),
			new Vector2Int(65, 90),
			new Vector2Int(97, 122)
		};

		[FormerlySerializedAs("power")]
		[SerializeField]
		private int numberBase;

		[SerializeField]
		private List<char> unicodeLetters;

		private void OnValidate()
		{
			numberBase = 0;
			unicodeLetters.Clear();
			Vector2Int[] array = unicodeAreas;
			for (int i = 0; i < array.Length; i++)
			{
				Vector2Int vector2Int = array[i];
				for (int j = vector2Int.x; j <= vector2Int.y; j++)
				{
					char value = Convert.ToChar(j);
					if (!Enumerable.Contains(excludedChars, value))
					{
						unicodeLetters.Add(Convert.ToChar(j));
						numberBase++;
					}
				}
			}
		}

		public string EncodeNumber(int input = -1, int targetStringLength = 0, bool alsoEncodeNegativeNumbers = true)
		{
			if (input == -1)
			{
				input = debug_DecodedNumber;
			}
			long num = input;
			if (alsoEncodeNegativeNumbers)
			{
				num = num + int.MaxValue + 1;
			}
			List<int> list = new List<int>();
			if (num == 0L)
			{
				list.Add(0);
			}
			while (num > 0)
			{
				int item = Convert.ToInt32(num % numberBase);
				list.Add(item);
				num /= numberBase;
			}
			list.Reverse();
			string text = "";
			foreach (int item2 in list)
			{
				text += unicodeLetters[item2];
			}
			if (targetStringLength > 0 && text.Length < targetStringLength)
			{
				for (int i = text.Length; i < targetStringLength; i++)
				{
					text = "0" + text;
				}
			}
			debug_EncodedNumber = text;
			return text;
		}

		public int DecodeNumber(string encodedNumber, bool numberCanBeNegative = true)
		{
			if (string.IsNullOrWhiteSpace(encodedNumber))
			{
				encodedNumber = debug_EncodedNumber;
			}
			return (int)DecodeNumberAsLong(encodedNumber, numberCanBeNegative);
		}

		public List<int> DecodeNumberAsDigits(string encodedNumber, int newBase = 10)
		{
			List<int> list = MathUtility.DigitsOf(DecodeNumberAsLong(encodedNumber, numberCanBeNegative: false), newBase);
			list.Reverse();
			return list;
		}

		public long DecodeNumberAsLong(string encodedNumber, bool numberCanBeNegative = true)
		{
			long num = 0L;
			char[] array = encodedNumber.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				int num2 = unicodeLetters.IndexOf(array[i]);
				if (num2 == -1)
				{
					num2 = 0;
				}
				if (!unicodeLetters.Contains(array[i]))
				{
					Debug.Log($"{array[i]} not valid -> index is {unicodeLetters.IndexOf(array[i])}");
				}
				BigInteger bigInteger = BigInteger.Pow(numberBase, array.Length - 1 - i);
				num += num2 * (long)bigInteger;
			}
			if (numberCanBeNegative)
			{
				num = num - int.MaxValue - 1;
			}
			return num;
		}

		private void DebugUnicodeRanges()
		{
			Vector2Int[] array = unicodeAreas;
			for (int i = 0; i < array.Length; i++)
			{
				Vector2Int vector2Int = array[i];
				Debug.Log("Unicode Area");
				for (int j = vector2Int.x; j <= vector2Int.y; j++)
				{
					Debug.Log($"{j} -> {char.ConvertFromUtf32(j)}");
				}
			}
		}

		public bool IsEncodedCharValid(char charToValidate)
		{
			return unicodeLetters.Contains(charToValidate);
		}

		public bool IsEncodedCharInRange(char charToValidate)
		{
			if (!unicodeLetters.Contains(charToValidate))
			{
				return Enumerable.Contains(excludedChars, charToValidate);
			}
			return true;
		}

		public bool IsEncodedStringInRange(string encodedString)
		{
			long num = DecodeNumberAsLong(encodedString);
			Debug.Log($"{num} >= {int.MinValue}? {num >= int.MinValue} |" + $" {num} <= {int.MaxValue}? {num <= int.MaxValue}");
			if (num >= int.MinValue)
			{
				return num <= int.MaxValue;
			}
			return false;
		}

		private List<int> ConvertFromBaseToBase(long value, int currentBase, int newBase)
		{
			List<int> list = MathUtility.DigitsOf(value);
			List<int> list2 = new List<int>(list);
			list2.Reverse();
			Debug.Log($"Current number: {value}, Base: {currentBase}, Digits: {ListHelper.ListDebugString(list2)}");
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				num += (int)(list[i] * BigInteger.Pow(currentBase, i));
			}
			Debug.Log($"Decimal: {num}");
			List<int> list3 = new List<int>();
			while (num > 0)
			{
				list3.Add(num % newBase);
				num /= newBase;
			}
			list3.Reverse();
			Debug.Log($"New Digits base {newBase}: {ListHelper.ListDebugString(list3)}");
			return list3;
		}

		private void TestIntToFloatConversion()
		{
			Debug.Log($"int: {minMaxValues.x}, float: {(float)minMaxValues.x:R}, back and forth: {(int)(float)minMaxValues.x}");
			Debug.Log($"int: {minMaxValues.y}, float: {(float)minMaxValues.y:R}, back and forth: {(int)(float)minMaxValues.y}");
		}
	}
}
