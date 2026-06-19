using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MathUtil
{
	private static System.Random rng = new System.Random();

	private static char seperatorSymbol = '|';

	private static float tolerance = 0.0001f;

	public static int maxGeneLen = 20;

	private static int geneticEncodeSequenceLen = 20;

	private static List<char> separatorSequenceSymbols = new List<char>
	{
		':', ';', '<', '=', '>', '?', '@', '[', '#', ']',
		'^', '_', '*'
	};

	public static float GetDampPercentage(float curValue, float minValue, float maxValue, float minDampPercentage, float maxDampPercentage)
	{
		return (Mathf.Clamp(curValue, minValue, maxValue) - minValue) / (maxValue - minValue) * (maxDampPercentage - minDampPercentage) + minDampPercentage;
	}

	public static void ShuffleList<T>(ref List<T> list)
	{
		for (int num = list.Count - 1; num > 0; num--)
		{
			int index = rng.Next(num + 1);
			T value = list[index];
			list[index] = list[num];
			list[num] = value;
		}
	}

	public static float ColorDifference(Color a, Color b)
	{
		return 0f + Mathf.Abs(a.r - b.r) + Mathf.Abs(a.g - b.g) + Mathf.Abs(a.b - b.b) + Mathf.Abs(a.a - b.a);
	}

	public static void ColorToHSV(Color color, out float hue, out float saturation, out float value)
	{
		float num = Math.Max(color.r, Math.Max(color.g, color.b));
		float num2 = Math.Min(color.r, Math.Min(color.g, color.b));
		float num3 = num - num2;
		value = num;
		if (num3 == 0f)
		{
			hue = 0f;
			saturation = 0f;
			return;
		}
		saturation = num3 / num;
		float num4 = ((num - color.r) / 6f + num3 / 2f) / num3;
		float num5 = ((num - color.g) / 6f + num3 / 2f) / num3;
		float num6 = ((num - color.b) / 6f + num3 / 2f) / num3;
		if (color.r == num)
		{
			hue = num6 - num5;
		}
		else if (color.g == num)
		{
			hue = 1f / 3f + num4 - num6;
		}
		else
		{
			hue = 2f / 3f + num5 - num4;
		}
		if (hue < 0f)
		{
			hue += 1f;
		}
		if (hue > 1f)
		{
			hue -= 1f;
		}
	}

	public static Color ColorFromHSV(float hue, float saturation, float value)
	{
		if (saturation == 0f)
		{
			return new Color(value, value, value);
		}
		float num = hue * 6f;
		if (num == 6f)
		{
			num = 0f;
		}
		float num2 = (int)num;
		float num3 = value * (1f - saturation);
		float num4 = value * (1f - saturation * (num - num2));
		float num5 = value * (1f - saturation * (1f - (num - num2)));
		float obj = num2;
		if (!0f.Equals(obj))
		{
			if (!1f.Equals(obj))
			{
				if (!2f.Equals(obj))
				{
					if (!3f.Equals(obj))
					{
						if (4f.Equals(obj))
						{
							return new Color(num5, num3, value);
						}
						return new Color(value, num3, num4);
					}
					return new Color(num3, num4, value);
				}
				return new Color(num3, value, num5);
			}
			return new Color(num4, value, num3);
		}
		return new Color(value, num5, num3);
	}

	public static Color DesaturateColorByPercentage(Color c, float p, float minSaturation = 0f)
	{
		if (p == 0f)
		{
			return c;
		}
		p = Mathf.Min(p, 1f);
		ColorToHSV(c, out var hue, out var saturation, out var value);
		float num = saturation;
		saturation -= saturation * p;
		saturation = Mathf.Max(saturation, minSaturation);
		if (saturation > num)
		{
			saturation = num;
		}
		return ColorFromHSV(hue, saturation, value);
	}

	public static Vector3 GetNormal(Vector3 p1, Vector3 p2, Vector3 p3)
	{
		return Vector3.Normalize(Vector3.Cross(p2 - p1, p3 - p1));
	}

	public static int Mod(int a, int m)
	{
		return (a % m + m) % m;
	}

	public static float Mod(float a, float m)
	{
		return (a % m + m) % m;
	}

	public static string GetBinaryStringFromFloat(int val)
	{
		return Convert.ToString(val, 2);
	}

	public static string GetGeneSequenceFromValues(float neededVal, float minVal, float maxVal, int geneLen)
	{
		string text = "";
		if (minVal == 0f && maxVal == 0f)
		{
			while (text.Length < geneLen)
			{
				text += "0";
			}
			return text;
		}
		neededVal = Mathf.Clamp(neededVal, minVal, maxVal);
		int geneLen2 = geneLen;
		if (geneLen > maxGeneLen)
		{
			geneLen2 = maxGeneLen;
		}
		float num = maxVal - minVal;
		float num2 = GetNumBinaryPermutations(geneLen2);
		float num3 = num / num2;
		string binaryStringFromFloat = GetBinaryStringFromFloat(Mathf.RoundToInt(neededVal / num3));
		if (geneLen > maxGeneLen)
		{
			int num4 = geneLen / maxGeneLen;
			for (int i = 0; i < num4; i++)
			{
				text += binaryStringFromFloat;
			}
			text += GetGeneSequenceFromValues(neededVal, minVal, maxVal, geneLen % maxGeneLen);
		}
		else
		{
			text = binaryStringFromFloat;
		}
		while (text.Length < geneLen)
		{
			text = "0" + text;
		}
		if (text.Length > geneLen)
		{
			Debug.LogError("Invalid gene length! Shortening resultant gene.");
			text = text.Substring(0, geneLen);
		}
		return text;
	}

	public static float GetFloatFromBinaryString(string binary)
	{
		return Convert.ToUInt64(binary, 2);
	}

	public static int GetNumBinaryPermutations(string gene)
	{
		return GetNumBinaryPermutations(gene.Length);
	}

	public static int GetNumBinaryPermutations(int geneLen)
	{
		int num = Mathf.RoundToInt(Mathf.Pow(2f, geneLen) - 1f);
		if (num < 0)
		{
			num = int.MaxValue;
		}
		return num;
	}

	public static float GetFloatFromGeneSequence(string gene, float minVal, float maxVal)
	{
		gene = gene.Replace(seperatorSymbol.ToString(), "");
		if (gene.Length > maxGeneLen)
		{
			return GetFloatFromGeneSequence(gene.Substring(0, maxGeneLen), minVal, maxVal);
		}
		if (gene.Length == 0)
		{
			Debug.LogError("Tried to get a float from an empty gene sequence. Returning its minimum value.");
			return minVal;
		}
		float num = GetNumBinaryPermutations(gene);
		float num2 = (float)(int)GetFloatFromBinaryString(gene) / num;
		float num3 = maxVal - minVal;
		float num4 = num2 * num3 + minVal;
		float num5 = 0.1f;
		if (num4 - num5 > maxVal)
		{
			Debug.LogError("Generated a float " + num4 + " larger than its max value " + maxVal);
			num4 = maxVal;
		}
		if (num4 + num5 < minVal)
		{
			Debug.LogError("Generated a float " + num4 + " smaller than its min value " + minVal);
			num4 = minVal;
		}
		return Mathf.Clamp(num4, minVal, maxVal);
	}

	public static float Factorial(int num)
	{
		float num2 = 1f;
		while (num > 0)
		{
			num2 *= (float)num;
			num--;
		}
		return num2;
	}

	public static float GetAngle2D(Vector2 p1, Vector2 p2)
	{
		return Mathf.Atan2(p2.y - p1.y, p2.x - p1.x);
	}

	public static float GetSlope2D(Vector2 p1, Vector2 p2)
	{
		return (p2.y - p1.y) / (p2.x - p1.x);
	}

	public static Vector3 GetLineCenter(Vector3 p1, Vector3 p2)
	{
		return GetPointAlongLine(p1, p2, 0.5f);
	}

	public static Vector3 GetPointAlongLine(Vector3 p1, Vector3 p2, float distanceRatio)
	{
		return new Vector3((1f - distanceRatio) * p1.x + distanceRatio * p2.x, (1f - distanceRatio) * p1.y + distanceRatio * p2.y, (1f - distanceRatio) * p1.z + distanceRatio * p2.z);
	}

	public static Vector3 NearestPointOnLine(Vector3 start, Vector3 end, Vector3 referencePoint)
	{
		Vector3 vector = end - start;
		float magnitude = vector.magnitude;
		vector.Normalize();
		float value = Vector3.Dot(referencePoint - start, vector);
		value = Mathf.Clamp(value, 0f, magnitude);
		return start + vector * value;
	}

	public static bool DoSquaresIntersect2D(Vector3 a1, Vector3 b1, Vector3 c1, Vector3 d1, Vector3 a2, Vector3 b2, Vector3 c2, Vector3 d2)
	{
		List<Vector3> list = new List<Vector3> { a1, b1, c1, d1 };
		List<Vector3> list2 = new List<Vector3> { a2, b2, c2, d2 };
		List<List<Vector3>> list3 = new List<List<Vector3>> { list, list2 };
		for (int i = 0; i < list3.Count; i++)
		{
			for (int j = 0; j < list3[i].Count; j++)
			{
				int index = (j + 1) % list3[i].Count;
				Vector3 vector = list3[i][j];
				Vector3 vector2 = list3[i][index];
				Vector2 vector3 = new Vector2(vector2.z - vector.z, vector.x - vector2.x);
				float? num = null;
				float? num2 = null;
				for (int k = 0; k < list.Count; k++)
				{
					float num3 = vector3.x * list[k].x + vector3.y * list[k].z;
					if (!num.HasValue || num3 < num)
					{
						num = num3;
					}
					if (!num2.HasValue || num3 > num2)
					{
						num2 = num3;
					}
				}
				float? num4 = null;
				float? num5 = null;
				for (int l = 0; l < list2.Count; l++)
				{
					float num6 = vector3.x * list2[l].x + vector3.y * list2[l].z;
					if (!num4.HasValue || num6 < num4)
					{
						num4 = num6;
					}
					if (!num5.HasValue || num6 > num5)
					{
						num5 = num6;
					}
				}
				if (num2 < num4 || num5 < num)
				{
					return false;
				}
			}
		}
		return true;
	}

	public static float GetPercentageOfRange(float val, float minVal, float maxVal)
	{
		if (val == minVal && minVal == maxVal)
		{
			return 1f;
		}
		return (val - minVal) / (maxVal - minVal);
	}

	public static float GetValueOfRangePercentage(float percentage, float minVal, float maxVal)
	{
		float num = maxVal - minVal;
		float num2 = percentage * num;
		return minVal + num2;
	}

	public static bool AlmostEqual(float a, float b, float customTolerance = -1f)
	{
		if (a == b)
		{
			return true;
		}
		float num = tolerance;
		if (customTolerance != -1f)
		{
			num = customTolerance;
		}
		return Mathf.Abs(a - b) <= num;
	}

	public static bool Vector3AlmostEqual(Vector3 a, Vector3 b, float customTolerance = -1f)
	{
		if (a == b)
		{
			return true;
		}
		float customTolerance2 = tolerance;
		if (customTolerance != -1f)
		{
			customTolerance2 = customTolerance;
		}
		if (AlmostEqual(a.x, b.x, customTolerance2) && AlmostEqual(a.y, b.y, customTolerance2))
		{
			return AlmostEqual(a.z, b.z, customTolerance2);
		}
		return false;
	}

	public static int GetRandomSuccessNum_MoreAccurate(int numTries, float p)
	{
		float num = Mathf.Log(1f - p);
		float num2 = 0f;
		int num3 = 0;
		while (true)
		{
			num2 += Mathf.Log(UnityEngine.Random.value) / (float)(numTries - num3);
			if (num2 < num)
			{
				break;
			}
			num3++;
		}
		return num3;
	}

	public static int GetRandomSuccessNum(int numTries, float p)
	{
		int num = 10000;
		if (numTries <= num)
		{
			return GetRandomSuccessNumInternal(numTries, p);
		}
		int numTries2 = numTries % num;
		int num2 = numTries / num;
		return GetRandomSuccessNumInternal(numTries / num2, p) * num2 + GetRandomSuccessNumInternal(numTries2, p);
	}

	private static int GetRandomSuccessNumInternal(int numTries, float p)
	{
		int num = 0;
		for (int i = 0; i < numTries; i++)
		{
			if (UnityEngine.Random.value <= p)
			{
				num++;
			}
		}
		return num;
	}

	public static float Round(float value, int sigDig)
	{
		value = (float)Math.Round(value, sigDig);
		return value;
	}

	public static Vector2 GetRandomVector2InRange(float low, float high)
	{
		return new Vector2(UnityEngine.Random.Range(low, high), UnityEngine.Random.Range(low, high));
	}

	public static string GeneticEncode(string input)
	{
		string text = "";
		string text2 = "";
		for (int i = 0; i < input.Length; i++)
		{
			if (input[i] == seperatorSymbol)
			{
				text += EncodeLookup(text2);
				int num = ((i + 3 < input.Length) ? 3 : (3 - (i + 3 - input.Length)));
				text += GetEncodedCharForSeparatorSequence(input.Substring(i, num));
				i += num - 1;
				text2 = "";
				continue;
			}
			if (text2.Length > 0 && !text2.Contains("1") && input[i] == '1')
			{
				text += EncodePrecedingZeros(text2);
				text2 = "";
			}
			text2 += input[i];
			if (text2.Length == geneticEncodeSequenceLen || i == input.Length - 1)
			{
				text += EncodeLookup(text2);
				text2 = "";
			}
			else if (text2.Length > geneticEncodeSequenceLen)
			{
				Debug.LogError("Invliad SUB length.");
			}
		}
		return text;
	}

	public static string GeneticDecode(string input)
	{
		int num = geneticEncodeSequenceLen / 4;
		string text = "";
		string text2 = "";
		for (int i = 0; i < input.Length; i++)
		{
			if (separatorSequenceSymbols.Contains(input[i]))
			{
				text += DecodeLookup(text2);
				text += GetSeparatorSequenceForEncodedChar(input[i]);
				text2 = "";
				continue;
			}
			if (input[i] >= 'a' && input[i] <= 'z')
			{
				text += DecodeLookup(text2);
				text += DecodeLookup(input[i].ToString());
				text2 = "";
				continue;
			}
			text2 += input[i];
			if (text2.Length == num || i == input.Length - 1)
			{
				text += DecodeLookup(text2);
				text2 = "";
			}
			else if (text2.Length > num)
			{
				Debug.LogError("Invliad SUB length.");
			}
		}
		return text;
	}

	private static char GetEncodedCharForSeparatorSequence(string input)
	{
		switch (input)
		{
		case "|00":
			return separatorSequenceSymbols[0];
		case "|01":
			return separatorSequenceSymbols[1];
		case "|10":
			return separatorSequenceSymbols[2];
		case "|11":
			return separatorSequenceSymbols[3];
		case "||0":
			return separatorSequenceSymbols[4];
		case "||1":
			return separatorSequenceSymbols[5];
		case "|0|":
			return separatorSequenceSymbols[6];
		case "|1|":
			return separatorSequenceSymbols[7];
		case "|||":
			return separatorSequenceSymbols[8];
		case "|0":
			return separatorSequenceSymbols[9];
		case "|1":
			return separatorSequenceSymbols[10];
		case "||":
			return separatorSequenceSymbols[11];
		case "|":
			return separatorSequenceSymbols[12];
		default:
			Debug.LogError("No matching encode sequence found for input: " + input);
			return '|';
		}
	}

	private static string GetSeparatorSequenceForEncodedChar(char input)
	{
		switch (input)
		{
		case ':':
			return "|00";
		case ';':
			return "|01";
		case '<':
			return "|10";
		case '=':
			return "|11";
		case '>':
			return "||0";
		case '?':
			return "||1";
		case '@':
			return "|0|";
		case '[':
			return "|1|";
		case '#':
			return "|||";
		case ']':
			return "|0";
		case '^':
			return "|1";
		case '_':
			return "||";
		case '*':
			return "|";
		default:
			Debug.LogError("No matching decode sequence found for input: " + input);
			return "ERROR";
		}
	}

	private static string EncodePrecedingZeros(string input)
	{
		if (input.Length == 0)
		{
			return "";
		}
		if (input.IndexOf('1') != -1)
		{
			Debug.LogError("Invalid input to EncodePrecedingZeros().");
			return "";
		}
		string text = "";
		int num = 25;
		int num2 = input.Length;
		while (num2 > 0)
		{
			if (num2 > num)
			{
				text += (char)(96 + num);
				num2 -= num;
			}
			else
			{
				text += (char)(96 + num2);
				num2 = 0;
			}
		}
		return text;
	}

	private static string EncodeLookup(string input)
	{
		if (input.Length == 0)
		{
			return "";
		}
		string text = "";
		if (input.IndexOf('1') == -1)
		{
			return EncodePrecedingZeros(input);
		}
		if (input[0] == '0')
		{
			int num = input.IndexOf('1');
			text += EncodePrecedingZeros(input.Substring(0, num));
			input = input.Substring(num, input.Length - num);
		}
		return text + Convert.ToInt32(input, 2).ToString("X");
	}

	private static string DecodeLookup(string input)
	{
		if (input.Length == 0)
		{
			return "";
		}
		if (input.Length == 1 && input[0] >= 'a' && input[0] <= 'z')
		{
			return "".PadLeft(input[0] - 97 + 1, '0');
		}
		return Convert.ToString(Convert.ToInt32(input.ToString(), 16), 2);
	}

	public static ulong ConvertToBase10(string input, ulong baseValue)
	{
		ulong num = 1uL;
		ulong num2 = 0uL;
		for (int num3 = input.Length - 1; num3 >= 0; num3--)
		{
			ulong num4 = Base10ConverterVal(input[num3]);
			if (num4 >= baseValue)
			{
				Debug.LogError("Invalid input.");
				return 0uL;
			}
			num2 += num4 * num;
			num *= baseValue;
		}
		return num2;
	}

	public static string ConvertFromBase10(ulong input, ulong baseNum)
	{
		int num = 1 + Math.Max((int)Mathf.Log(input, baseNum), 0);
		char[] array = new char[num];
		int num2 = num - 1;
		do
		{
			array[num2--] = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"[(int)(input % baseNum)];
			input /= baseNum;
		}
		while (input != 0L);
		return new string(array);
	}

	private static ulong Base10ConverterVal(char c)
	{
		if (c >= '0' && c <= '9')
		{
			return (ulong)c - 48uL;
		}
		return (ulong)((long)c - 65L + 10);
	}

	public static string Scramble(string input)
	{
		string text = input;
		for (int i = 0; i < input.Length; i++)
		{
			text = InteriorScramble(text, i);
		}
		return text;
	}

	public static string Unscramble(string input)
	{
		string text = input;
		for (int num = input.Length - 1; num >= 0; num--)
		{
			text = InteriorScramble(text, num);
		}
		return text;
	}

	private static string InteriorScramble(string s, int i)
	{
		int num = s[(i + 1) % s.Length];
		int num2 = (i + num) % s.Length;
		if (num2 == (i + 1) % s.Length)
		{
			return s;
		}
		char c = s[i];
		char c2 = s[num2];
		s = s.Remove(i, 1);
		s = s.Insert(i, c2.ToString());
		s = s.Remove(num2, 1);
		s = s.Insert(num2, c.ToString());
		return s;
	}

	public static void GeneEncodingUnitTest()
	{
		string text = "|||||||||||||||||||||||";
		if (text != GeneticDecode(GeneticEncode(text)))
		{
			Debug.LogError("GENETIC ENCODING UNIT TEST FAILED");
			Debug.LogError(text);
			return;
		}
		MonoBehaviour.print("| GENETIC ENCODING UNIT TESTS PASSED!");
		string text2 = "000000000000000000000000000";
		if (text2 != GeneticDecode(GeneticEncode(text2)))
		{
			Debug.LogError("GENETIC ENCODING UNIT TEST FAILED");
			Debug.LogError(text2);
			return;
		}
		MonoBehaviour.print("0 GENETIC ENCODING UNIT TESTS PASSED!");
		string text3 = "111111111111111111111111111";
		if (text3 != GeneticDecode(GeneticEncode(text3)))
		{
			Debug.LogError("GENETIC ENCODING UNIT TEST FAILED");
			Debug.LogError(text3);
			return;
		}
		MonoBehaviour.print("1 GENETIC ENCODING UNIT TESTS PASSED!");
		for (int i = 0; i < 100; i++)
		{
			string text4 = GenerateRandomGeneOfSize(10);
			if (text4 != GeneticDecode(GeneticEncode(text4)))
			{
				Debug.LogError("GENETIC ENCODING UNIT TEST FAILED");
				Debug.LogError(text4);
				return;
			}
		}
		MonoBehaviour.print("10 LENGTH GENETIC ENCODING UNIT TESTS PASSED!");
		for (int j = 0; j < 100; j++)
		{
			string text5 = GenerateRandomGeneOfSize(100);
			if (text5 != GeneticDecode(GeneticEncode(text5)))
			{
				Debug.LogError("GENETIC ENCODING UNIT TEST FAILED");
				Debug.LogError(text5);
				return;
			}
		}
		MonoBehaviour.print("100 LENGTH GENETIC ENCODING UNIT TESTS PASSED!");
		for (int k = 0; k < 100; k++)
		{
			string text6 = GenerateRandomGeneOfSize(500);
			if (text6 != GeneticDecode(GeneticEncode(text6)))
			{
				Debug.LogError("GENETIC ENCODING UNIT TEST FAILED");
				Debug.LogError(text6);
				return;
			}
		}
		MonoBehaviour.print("500 LENGTH GENETIC ENCODING UNIT TESTS PASSED!");
		for (int l = 0; l < 100; l++)
		{
			string text7 = GenerateRandomGeneOfSize(1000);
			if (text7 != GeneticDecode(GeneticEncode(text7)))
			{
				Debug.LogError("GENETIC ENCODING UNIT TEST FAILED");
				Debug.LogError(text7);
				return;
			}
		}
		MonoBehaviour.print("1000 LENGTH GENETIC ENCODING UNIT TESTS PASSED!");
		MonoBehaviour.print("ENCODING UNIT TESTS ALL PASSED!");
	}

	public static void ScrambleUnitTest()
	{
		for (int i = 0; i < 100; i++)
		{
			string text = GenerateRandomStringOfSize(10);
			if (text != Unscramble(Scramble(text)))
			{
				Debug.LogError("SCRAMBLE UNIT TEST FAILED");
				Debug.LogError(text);
				return;
			}
		}
		MonoBehaviour.print("10 LENGTH SCRAMBLE UNIT TESTS PASSED!");
		for (int j = 0; j < 100; j++)
		{
			string text2 = GenerateRandomStringOfSize(100);
			if (text2 != Unscramble(Scramble(text2)))
			{
				Debug.LogError("SCRAMBLE UNIT TEST FAILED");
				Debug.LogError(text2);
				return;
			}
		}
		MonoBehaviour.print("100 LENGTH SCRAMBLE UNIT TESTS PASSED!");
		for (int k = 0; k < 100; k++)
		{
			string text3 = GenerateRandomStringOfSize(500);
			if (text3 != Unscramble(Scramble(text3)))
			{
				Debug.LogError("SCRAMBLE UNIT TEST FAILED");
				Debug.LogError(text3);
				return;
			}
		}
		MonoBehaviour.print("500 LENGTH SCRAMBLE UNIT TESTS PASSED!");
		for (int l = 0; l < 100; l++)
		{
			string text4 = GenerateRandomStringOfSize(1000);
			if (text4 != Unscramble(Scramble(text4)))
			{
				Debug.LogError("SCRAMBLE UNIT TEST FAILED");
				Debug.LogError(text4);
				return;
			}
		}
		MonoBehaviour.print("1000 LENGTH SCRAMBLE UNIT TESTS PASSED!");
		MonoBehaviour.print("SCRAMBLE UNIT TESTS ALL PASSED!");
	}

	private static string GenerateRandomStringOfSize(int size)
	{
		return new string((from _ in Enumerable.Range(1, size)
			select (char)UnityEngine.Random.Range(33, 127)).ToArray());
	}

	private static string GenerateRandomGeneOfSize(int size)
	{
		return new string(Enumerable.Range(1, size).Select((Func<int, char>)delegate
		{
			if (!(UnityEngine.Random.value >= 0.5f))
			{
				if (!(UnityEngine.Random.value >= 0.95f))
				{
					return '1';
				}
				return '|';
			}
			return (!(UnityEngine.Random.value >= 0.95f)) ? '0' : '|';
		}).ToArray());
	}
}
