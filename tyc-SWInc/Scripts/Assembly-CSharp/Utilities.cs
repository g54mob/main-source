using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Achievements;
using ClipperLib;
using LibTessDotNet;
using Tyd;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class Utilities
{
	public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
	{
		public int Compare(TKey x, TKey y)
		{
			int num = x.CompareTo(y);
			if (num != 0)
			{
				return num;
			}
			return 1;
		}
	}

	public class DuplicateReverseKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
	{
		public int Compare(TKey x, TKey y)
		{
			int num = x.CompareTo(y);
			return -((num == 0) ? 1 : num);
		}
	}

	[Flags]
	public enum Direction
	{
		None = 0,
		North = 1,
		East = 2,
		South = 4,
		West = 8
	}

	private struct EdgeKey : IEquatable<EdgeKey>
	{
		public int A;

		public int B;

		public EdgeKey(int a, int b)
		{
			if (a < b)
			{
				A = a;
				B = b;
			}
			else
			{
				A = b;
				B = a;
			}
		}

		public bool Equals(EdgeKey other)
		{
			if (A == other.A)
			{
				return B == other.B;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			object obj2;
			if ((obj2 = obj) is EdgeKey)
			{
				EdgeKey other = (EdgeKey)obj2;
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (A * 397) ^ B;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _003C_003Ec__DisplayClass673_0
	{
		public Dictionary<EdgeKey, int> edgeCounts;

		public Dictionary<int, List<int>> adjacency;
	}

	public const string UserAgent = "Swinc User Agent";

	private const float Epsilon = 1.1E-44f;

	private static List<int> _VBOIndexCache = new List<int>();

	public const float ClippingScaleFactor = 12000f;

	private static ObjectPool<PolyTree> _polyTreePool = new ObjectPool<PolyTree>(() => new PolyTree(), null, delegate(PolyTree x)
	{
		x.Clear();
	});

	private static ObjectPool<List<float>> _holeSortKeys = new ObjectPool<List<float>>(() => new List<float>(), null, delegate(List<float> x)
	{
		x.Clear();
	});

	public static Tess LibTess = new Tess
	{
		NoEmptyPolygons = true
	};

	private static ObjectPool<Tess> _tessPool = new ObjectPool<Tess>(() => new Tess
	{
		NoEmptyPolygons = true
	});

	public static float TessTime = 0f;

	private static List<float> _medianList = new List<float>();

	private static List<float> _medianList2 = new List<float>();

	private static string _rootCache = null;

	private static Dictionary<object, int> _modeDict = new Dictionary<object, int>();

	private static readonly char[] VowelChars = "aeiouyæøåαεηιουωаеёиоуыэюя".ToCharArray();

	private static List<Furniture> _updateFurnParentCache = new List<Furniture>();

	private static int[] _lengthPrimes = new int[100]
	{
		3, 3, 5, 3, 3, 5, 3, 3, 5, 3,
		3, 5, 3, 3, 7, 3, 3, 5, 3, 3,
		5, 3, 3, 5, 3, 3, 5, 3, 3, 7,
		3, 3, 5, 3, 3, 5, 3, 3, 5, 3,
		3, 5, 3, 3, 7, 3, 3, 5, 3, 3,
		5, 3, 3, 5, 3, 3, 5, 3, 3, 7,
		3, 3, 5, 3, 3, 5, 3, 3, 5, 3,
		3, 5, 3, 3, 7, 3, 3, 5, 3, 3,
		5, 3, 3, 5, 3, 3, 5, 3, 3, 7,
		3, 3, 5, 3, 3, 5, 3, 3, 5, 3
	};

	public static System.Random RNG
	{
		get
		{
			return SafeRandom.Rnd;
		}
	}

	public static float RandomValue
	{
		get
		{
			return (float)RNG.NextDouble();
		}
	}

	public static T GetRandomWeighted<T>(List<KeyValuePair<float, T>> values)
	{
		if (values == null || values.Count == 0)
		{
			UnityEngine.Debug.LogError("Tried to get weighted random value with empty list of values");
			return default(T);
		}
		float num = UnityEngine.Random.value * values.Sum((KeyValuePair<float, T> x) => x.Key);
		float num2 = 0f;
		foreach (KeyValuePair<float, T> value in values)
		{
			num2 += value.Key;
			if (num <= num2)
			{
				return value.Value;
			}
		}
		throw new UnityException("Somehow random choice failed");
	}

	public static int CompareNumber<T>(Func<T, float> f, T x, T y)
	{
		return f(x).CompareTo(f(y));
	}

	public static int CompareNumber<T>(Func<T, double> f, T x, T y)
	{
		return f(x).CompareTo(f(y));
	}

	public static int CompareString<T>(Func<T, string> f, T x, T y)
	{
		string text = f(x);
		string text2 = f(y);
		if (text == null)
		{
			if (text2 == null)
			{
				return 0;
			}
			return -1;
		}
		if (text2 == null)
		{
			return 1;
		}
		return text.CompareTo(text2);
	}

	public static float RandomGauss(float mean, float deviation, System.Random rnd = null)
	{
		rnd = rnd ?? RNG;
		float num;
		for (num = rnd.NextFloat(); num == 0f; num = rnd.NextFloat())
		{
		}
		float num2 = rnd.NextFloat();
		float num3 = Mathf.Sqrt(-2f * Mathf.Log(num)) * Mathf.Sin((float)Math.PI * 2f * num2);
		return mean + deviation * num3;
	}

	public static float RandomGaussClamped(float mean = 0.5f, float deviation = 0.2f, System.Random rnd = null)
	{
		float num = RandomGauss(mean, deviation, rnd);
		if (num < 0f)
		{
			num = 0f - num;
		}
		if (num > 1f)
		{
			num = 1f - (num - 1f);
		}
		return num;
	}

	public static int GaussRange(float mean, int min, int max, float deviation = 0.2f)
	{
		float num = RandomGaussClamped(mean, deviation);
		return Mathf.Clamp(min + Mathf.FloorToInt(num * (float)(max - min + 1)), min, max);
	}

	public static float GaussRangeFloat(float mean, float min, float max, float deviation = 0.2f)
	{
		float num = RandomGaussClamped(mean, deviation);
		return min + num * (max - min);
	}

	public static Rect Expand(this Rect input, float x, float y)
	{
		return new Rect(input.x - x / 2f, input.y - y / 2f, input.width + x, input.height + y);
	}

	public static string CurrencyDiff(this float x, bool ext = true)
	{
		return ((double)x).CurrencyDiff(ext);
	}

	public static string CurrencyDiff(this double x, bool ext = true)
	{
		return ((x > 0.0) ? "+" : "") + x.Currency(ext);
	}

	public static string Currency(this float x, bool ext = true, bool forceDecimal = false)
	{
		return ((double)x).Currency(ext, forceDecimal);
	}

	public static string Currency(this double x, bool ext = true, bool forceDecimal = false)
	{
		Currency currency = GameData.GetCurrency(Options.Currency);
		double num = Math.Abs(x * (double)currency.Rate);
		string text = (forceDecimal ? "N2" : "N0");
		string text2;
		if (num >= 0.01 && num < 10.0 && Math.Floor(num) < num)
		{
			text2 = num.ToString("N2");
		}
		else if (Options.CurrencyShortForm)
		{
			if (num > 1000000000.0)
			{
				num /= 1000000000.0;
				text2 = num.ToString(PickDecimalCurrencyShortform(num)) + "BillionPost".Loc();
			}
			else if (num > 1000000.0)
			{
				num /= 1000000.0;
				text2 = num.ToString(PickDecimalCurrencyShortform(num)) + "MillionPost".Loc();
			}
			else
			{
				text2 = num.ToString(text);
			}
		}
		else
		{
			text2 = num.ToString(text);
		}
		return ((x < 0.0) ? "-" : "") + (ext ? currency.Prefix : "") + text2 + (ext ? currency.Postfix : "");
	}

	private static string PickDecimalCurrencyShortform(double num)
	{
		if (num < 10.0)
		{
			return "N2";
		}
		if (num < 100.0)
		{
			return "N1";
		}
		return "N0";
	}

	public static string CurrencyInt(this int x, bool ext = true)
	{
		return Currency(x, ext);
	}

	public static float CurrencyMul(this float x)
	{
		return x * GameData.GetCurrency(Options.Currency).Rate;
	}

	public static double CurrencyMul(this double x)
	{
		return x * (double)GameData.GetCurrency(Options.Currency).Rate;
	}

	public static float CurrencyMulInt(this int x)
	{
		return (float)x * GameData.GetCurrency(Options.Currency).Rate;
	}

	public static float FromCurrency(this float x)
	{
		return x / GameData.GetCurrency(Options.Currency).Rate;
	}

	public static double FromCurrency(this double x)
	{
		return x / (double)GameData.GetCurrency(Options.Currency).Rate;
	}

	public static float CurrencyRoundUpToNearest(this float x, float multiple)
	{
		float rate = GameData.GetCurrency(Options.Currency).Rate;
		return Mathf.Ceil(x * rate / multiple) * multiple / rate;
	}

	public static float CurrencyRoundDownToNearest(this float x, float multiple)
	{
		float rate = GameData.GetCurrency(Options.Currency).Rate;
		return Mathf.Floor(x * rate / multiple) * multiple / rate;
	}

	public static float RoundUpToNearest(this float x, int multiple)
	{
		return Mathf.Ceil(x / (float)multiple) * (float)multiple;
	}

	public static float RoundDownToNearest(this float x, int multiple)
	{
		return Mathf.Floor(x / (float)multiple) * (float)multiple;
	}

	public static bool Approximate(this Vector3 v1, Vector3 v2)
	{
		if (Mathf.Approximately(v1.x, v2.x) && Mathf.Approximately(v1.y, v2.y))
		{
			return Mathf.Approximately(v1.z, v2.z);
		}
		return false;
	}

	public static bool Approximate(this Vector3 v1, Vector3 v2, float off)
	{
		if (Mathf.Abs(v1.x - v2.x) <= off && Mathf.Abs(v1.y - v2.y) <= off)
		{
			return Mathf.Abs(v1.z - v2.z) <= off;
		}
		return false;
	}

	public static bool Approximate(this Vector2 v1, Vector2 v2)
	{
		if (Mathf.Approximately(v1.x, v2.x))
		{
			return Mathf.Approximately(v1.y, v2.y);
		}
		return false;
	}

	public static bool Approximate(this Vector2 v1, Vector2 v2, float off)
	{
		if (Mathf.Abs(v1.x - v2.x) <= off)
		{
			return Mathf.Abs(v1.y - v2.y) <= off;
		}
		return false;
	}

	public static bool Approximate(this Color32 v1, Color32 v2)
	{
		if (Mathf.Abs(v1.r - v2.r) <= 1 && Mathf.Abs(v1.g - v2.g) <= 1 && Mathf.Abs(v1.b - v2.b) <= 1)
		{
			return Mathf.Abs(v1.a - v2.a) <= 1;
		}
		return false;
	}

	public static bool Approximate(this Color v1, Color32 v2)
	{
		return v2.Approximate(v1);
	}

	public static T MaxInstance<T>(this IEnumerable<T> list, Func<T, float> maxFunc)
	{
		float num = float.MinValue;
		T result = default(T);
		foreach (T item in list)
		{
			float num2 = maxFunc(item);
			if (num2 > num)
			{
				num = num2;
				result = item;
			}
		}
		return result;
	}

	public static T MaxInstance<T>(this IEnumerable<T> list, Func<T, double> maxFunc)
	{
		double num = double.MinValue;
		T result = default(T);
		foreach (T item in list)
		{
			double num2 = maxFunc(item);
			if (num2 > num)
			{
				num = num2;
				result = item;
			}
		}
		return result;
	}

	public static T MaxInstance<T>(this IList<T> list, Func<T, float> maxFunc)
	{
		float num = float.MinValue;
		T result = default(T);
		for (int i = 0; i < list.Count; i++)
		{
			T val = list[i];
			float num2 = maxFunc(val);
			if (num2 > num)
			{
				num = num2;
				result = val;
			}
		}
		return result;
	}

	public static T MaxInstance<T>(this IList<T> list, Func<T, double> maxFunc)
	{
		double num = double.MinValue;
		T result = default(T);
		for (int i = 0; i < list.Count; i++)
		{
			T val = list[i];
			double num2 = maxFunc(val);
			if (num2 > num)
			{
				num = num2;
				result = val;
			}
		}
		return result;
	}

	public static T MinInstance<T>(this IEnumerable<T> list, Func<T, float> maxFunc)
	{
		float num = float.MaxValue;
		T result = default(T);
		foreach (T item in list)
		{
			float num2 = maxFunc(item);
			if (num2 < num)
			{
				num = num2;
				result = item;
			}
		}
		return result;
	}

	public static T MinMaxInstance<T>(this IEnumerable<T> list, params KeyValuePair<Func<T, int>, bool>[] maxFunc)
	{
		int[] array = new int[maxFunc.Length];
		for (int i = 0; i < maxFunc.Length; i++)
		{
			array[i] = (maxFunc[i].Value ? int.MaxValue : int.MinValue);
		}
		T result = default(T);
		foreach (T item in list)
		{
			int num = -1;
			for (int j = 0; j < maxFunc.Length; j++)
			{
				int num2 = maxFunc[j].Key(item);
				if (num2 != array[j])
				{
					if ((num2 > array[j]) ^ maxFunc[j].Value)
					{
						array[j] = num2;
						result = item;
						num = j;
						break;
					}
					if ((num2 < array[j]) ^ maxFunc[j].Value)
					{
						break;
					}
				}
			}
			if (num >= 0)
			{
				for (int k = num + 1; k < maxFunc.Length; k++)
				{
					array[k] = maxFunc[k].Key(item);
				}
			}
		}
		return result;
	}

	public static T MinInstance<T>(this IList<T> list, Func<T, float> maxFunc)
	{
		float num = float.MaxValue;
		T result = default(T);
		for (int i = 0; i < list.Count; i++)
		{
			T val = list[i];
			float num2 = maxFunc(val);
			if (num2 < num)
			{
				num = num2;
				result = val;
			}
		}
		return result;
	}

	public static T MinInstanceRandom<T>(this IList<T> list, Func<T, float> maxFunc)
	{
		T result = default(T);
		if (list.Count > 0)
		{
			float num = float.MaxValue;
			int num2 = RandomRange(0, list.Count - 1);
			for (int i = 0; i < list.Count; i++)
			{
				T val = list[num2];
				float num3 = maxFunc(val);
				if (num3 < num)
				{
					num = num3;
					result = val;
				}
				num2++;
				if (num2 >= list.Count)
				{
					num2 = 0;
				}
			}
		}
		return result;
	}

	public static IEnumerable<T> ReverseEnum<T>(this IList<T> list)
	{
		for (int i = list.Count - 1; i >= 0; i--)
		{
			yield return list[i];
		}
	}

	public static int AddHour(this int x, int amount)
	{
		return (int)Modulo((float)x + (float)amount, 24f);
	}

	public static float PerHour(float perHour, float delta, bool useGameSpeed = true)
	{
		return perHour / 60f * delta * (useGameSpeed ? GameSettings.GameSpeed : 1f);
	}

	public static float PerHour(float perHour, bool useGameSpeed = true)
	{
		return PerHour(perHour, Time.deltaTime, useGameSpeed);
	}

	public static float PerDay(float perDay, float delta, bool useGameSpeed = true)
	{
		return perDay / (float)GameSettings.DaysPerMonth / 60f / 24f * delta * (useGameSpeed ? GameSettings.GameSpeed : 1f);
	}

	public static float PerDay(float perDay, bool useGameSpeed = true)
	{
		return PerDay(perDay, Time.deltaTime, useGameSpeed);
	}

	public static float Modulo(float a, float b)
	{
		return a - b * Mathf.Floor(a / b);
	}

	public static bool IsEmpty(this string a)
	{
		return string.IsNullOrEmpty(a.Trim());
	}

	public static int Sign(float num)
	{
		if (!(num < 0f))
		{
			if (!(num > 0f))
			{
				return 0;
			}
			return 1;
		}
		return -1;
	}

	public static int Sign(int num)
	{
		if (num >= 0)
		{
			if (num <= 0)
			{
				return 0;
			}
			return 1;
		}
		return -1;
	}

	public static float AngleDistance(float a1, float a2)
	{
		float num = Mathf.Abs(a1 - a2);
		if (num > 180f)
		{
			num = 360f - num;
		}
		return num;
	}

	public static bool AnglePassed(float a1, float a2, float anchor)
	{
		Vector3 lhs = new Vector3(Mathf.Cos(a1 / 180f * (float)Math.PI), Mathf.Sin(a1 / 180f * (float)Math.PI), 0f);
		Vector3 lhs2 = new Vector3(Mathf.Cos(a2 / 180f * (float)Math.PI), Mathf.Sin(a2 / 180f * (float)Math.PI), 0f);
		Vector3 rhs = new Vector3(Mathf.Cos(anchor / 180f * (float)Math.PI), Mathf.Sin(anchor / 180f * (float)Math.PI), 0f);
		Vector3 vector = Vector3.Cross(lhs, rhs);
		Vector3 vector2 = Vector3.Cross(lhs2, rhs);
		return Sign(vector.z) != Sign(vector2.z);
	}

	public static bool Straight(Vector2 v1, Vector2 v2, Vector2 v3)
	{
		Vector2 vector = v2 - v1;
		Vector2 vector2 = v3 - v2;
		return Mathf.Approximately(Mathf.Atan2(vector.y, vector.x), Mathf.Atan2(vector2.y, vector2.x));
	}

	public static bool Straight(Vector3 v1, Vector3 v2, Vector3 v3)
	{
		Vector3 vector = v2 - v1;
		Vector3 vector2 = v3 - v2;
		return Mathf.Approximately(Mathf.Atan2(vector.z, vector.x), Mathf.Atan2(vector2.z, vector2.x));
	}

	public static List<Vector3> Bezier(int iterations, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
	{
		List<Vector3> list = new List<Vector3> { p0 };
		for (int i = 0; i < iterations - 1; i++)
		{
			float t = (float)(i + 1) / (float)iterations;
			list.Add(CalculateBezierPoint(t, p0, p1, p2, p3));
		}
		list.Add(p3);
		return list;
	}

	private static Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
	{
		float num = 1f - t;
		float num2 = num * num;
		float num3 = num2 * num;
		float num4 = t * t;
		float num5 = num4 * t;
		return num3 * p0 + 3f * num2 * t * p1 + 3f * num * num4 * p2 + num5 * p3;
	}

	public static float MapRange(this float x, float a, float b, float c, float d, bool clamp = false)
	{
		if (clamp)
		{
			if (a > b)
			{
				if (x >= a)
				{
					return c;
				}
				if (x <= b)
				{
					return d;
				}
			}
			else
			{
				if (x >= b)
				{
					return d;
				}
				if (x <= a)
				{
					return c;
				}
			}
		}
		float num = b - a;
		float num2 = ((num == 0f) ? (x - a) : ((x - a) / num));
		float num3 = d - c;
		return num2 * num3 + c;
	}

	public static float MapRange(this int x, float a, float b, float c, float d, bool clamp = false)
	{
		return ((float)x).MapRange(a, b, c, d, clamp);
	}

	public static double MapRange(this int x, double a, double b, double c, double d, bool clamp = false)
	{
		return ((double)x).MapRange(a, b, c, d, clamp);
	}

	public static double MapRange(this double x, double a, double b, double c, double d, bool clamp = false)
	{
		if (clamp)
		{
			if (a > b)
			{
				if (x >= a)
				{
					return c;
				}
				if (x <= b)
				{
					return d;
				}
			}
			else
			{
				if (x >= b)
				{
					return d;
				}
				if (x <= a)
				{
					return c;
				}
			}
		}
		double num = b - a;
		double num2 = ((num == 0.0) ? (x - a) : ((x - a) / num));
		double num3 = d - c;
		return num2 * num3 + c;
	}

	public static float PosNeg(float x, float low, float high)
	{
		if (x > 1f)
		{
			return 1f + (x - 1f) * (high - 1f);
		}
		if (x < 1f)
		{
			return low + x * (1f - low);
		}
		return 1f;
	}

	public static Vector3 RGBToHSV(Color c)
	{
		float num = Mathf.Min(c.r, c.g, c.b);
		float num2 = Mathf.Max(c.r, c.g, c.b);
		float num3 = num2 - num;
		float y;
		float num4;
		if (num2 != 0f)
		{
			y = num3 / num2;
			num4 = ((c.r == num2) ? ((c.g - c.b) / num3) : ((c.g != num2) ? (4f + (c.r - c.g) / num3) : (2f + (c.b - c.r) / num3)));
			num4 *= 60f;
			if (num4 < 0f)
			{
				num4 += 360f;
			}
			return new Vector3(num4 / 360f, y, num2);
		}
		y = 0f;
		num4 = 0f;
		return new Vector3(num4, y, num2);
	}

	public static Color HSVToRGBA(float h, float S, float V, float a = 1f)
	{
		return HSVToRGB(h * 360f, S, V).ToVector4(a);
	}

	public static Vector3 HSVToRGB(float h, float S, float V)
	{
		float num;
		for (num = h; num < 0f; num += 360f)
		{
		}
		while (num >= 360f)
		{
			num -= 360f;
		}
		float x;
		float y;
		float z;
		if (V <= 0f)
		{
			x = (y = (z = 0f));
		}
		else if (S <= 0f)
		{
			x = (y = (z = V));
		}
		else
		{
			float num2 = num / 60f;
			int num3 = Mathf.FloorToInt(num2);
			float num4 = num2 - (float)num3;
			float num5 = V * (1f - S);
			float num6 = V * (1f - S * num4);
			float num7 = V * (1f - S * (1f - num4));
			switch (num3)
			{
			case 0:
				x = V;
				y = num7;
				z = num5;
				break;
			case 1:
				x = num6;
				y = V;
				z = num5;
				break;
			case 2:
				x = num5;
				y = V;
				z = num7;
				break;
			case 3:
				x = num5;
				y = num6;
				z = V;
				break;
			case 4:
				x = num7;
				y = num5;
				z = V;
				break;
			case 5:
				x = V;
				y = num5;
				z = num6;
				break;
			case 6:
				x = V;
				y = num7;
				z = num5;
				break;
			case -1:
				x = V;
				y = num5;
				z = num6;
				break;
			default:
				x = (y = (z = V));
				break;
			}
		}
		return new Vector3(x, y, z);
	}

	public static T GetRandom<T>(this IList<T> arr)
	{
		if (arr.Count != 0)
		{
			return arr[RandomRange(0, arr.Count)];
		}
		return default(T);
	}

	public static T GetRandom<T>(this IList<T> arr, System.Random rnd)
	{
		if (arr.Count != 0)
		{
			return arr[rnd.Next(arr.Count)];
		}
		return default(T);
	}

	public static T GetRandom<T>(this IEnumerable<T> list, int count, System.Random rnd)
	{
		if (count != 0)
		{
			return list.GetAt(rnd.Next(0, count));
		}
		return default(T);
	}

	public static T GetRandom<T>(this IEnumerable<T> list, int count)
	{
		return list.GetRandom(count, RNG);
	}

	public static T GetRandom<T>(this IEnumerable<T> list)
	{
		return list.ToList().GetRandom();
	}

	public static T GetRandom<T>(this IEnumerable<T> list, System.Random rnd)
	{
		return list.ToList().GetRandom(rnd);
	}

	public static T GetRandomWhereOffset<T>(this IList<T> list, Func<T, bool> pred)
	{
		int num = RNG.Next(list.Count);
		for (int i = num; i < list.Count; i++)
		{
			if (pred(list[i]))
			{
				return list[i];
			}
		}
		for (int j = 0; j < num; j++)
		{
			if (pred(list[j]))
			{
				return list[j];
			}
		}
		return default(T);
	}

	public static T GetRandomWhere<T>(this IList<T> list, Func<T, bool> pred, System.Random rng = null)
	{
		rng = rng ?? RNG;
		int num = 0;
		int num2 = -1;
		for (int i = 0; i < list.Count; i++)
		{
			if (pred(list[i]))
			{
				if (num2 == -1)
				{
					num2 = i;
				}
				num++;
			}
		}
		if (num == 0)
		{
			return default(T);
		}
		num = rng.Next(num);
		int num3 = 0;
		for (int j = num2; j < list.Count; j++)
		{
			if (pred(list[j]))
			{
				if (num3 == num)
				{
					return list[j];
				}
				num3++;
			}
		}
		return default(T);
	}

	public static T GetRandomWhere<T>(this IEnumerable<T> list, Func<T, bool> pred)
	{
		T result = default(T);
		IEnumerator<T> enumerator = list.GetEnumerator();
		enumerator.Reset();
		GetRandomWhereSub(enumerator, pred, 0, ref result);
		return result;
	}

	public static int GetRandomWhereSub<T>(IEnumerator<T> list, Func<T, bool> pred, int c, ref T result)
	{
		if (list.MoveNext())
		{
			T current = list.Current;
			bool flag = false;
			if (pred(current))
			{
				flag = true;
				c++;
			}
			int randomWhereSub = GetRandomWhereSub(list, pred, c, ref result);
			if (flag && c - 1 == randomWhereSub)
			{
				result = current;
			}
			return randomWhereSub;
		}
		if (c != 0)
		{
			return RandomRange(0, c);
		}
		return -1;
	}

	public static T GetRandom<T>(this IEnumerable<T> list, Func<T, int> priority)
	{
		List<T> list2 = list.ToList();
		List<T> list3 = new List<T>();
		int num = int.MaxValue;
		for (int i = 0; i < list2.Count; i++)
		{
			int num2 = priority(list2[i]);
			if (num2 < num)
			{
				list3.Clear();
				list3.Add(list2[i]);
				num = num2;
			}
			else if (num2 == num)
			{
				list3.Add(list2[i]);
			}
		}
		return list3.GetRandom();
	}

	public static string HourString(int hour)
	{
		if (SDateTime.AMPM)
		{
			string text = "AM";
			if (hour > 11)
			{
				text = "PM";
				if (hour > 12)
				{
					hour -= 12;
				}
			}
			hour = ((hour == 0) ? 12 : hour);
			return hour + " " + text;
		}
		return hour.ToString("D2");
	}

	public static string ReadAllText(string filename)
	{
		return ReadOnlyReadAllText(filename);
	}

	public static void ForEachEnum<T>(this HashSet<T> input, Action<T> action)
	{
		foreach (T item in input)
		{
			action(item);
		}
	}

	public static void AddRange<T>(this HashSet<T> input, IList<T> range)
	{
		for (int i = 0; i < range.Count; i++)
		{
			input.Add(range[i]);
		}
	}

	public static void AddRange<T>(this HashSet<T> input, IEnumerable<T> range)
	{
		foreach (T item in range)
		{
			input.Add(item);
		}
	}

	public static void AddRangeQuick<T>(this List<T> input, IList<T> range)
	{
		for (int i = 0; i < range.Count; i++)
		{
			input.Add(range[i]);
		}
	}

	public static void RemoveRange<T>(this ICollection<T> input, IEnumerable<T> range)
	{
		foreach (T item in range)
		{
			input.Remove(item);
		}
	}

	public static void RemoveRange<T>(this ICollection<T> input, IList<T> range)
	{
		for (int i = 0; i < range.Count; i++)
		{
			input.Remove(range[i]);
		}
	}

	public static void RemoveAll<T>(this HashSet<T> input, Func<T, bool> predicate)
	{
		List<T> list = null;
		foreach (T item in input)
		{
			if (predicate(item))
			{
				if (list == null)
				{
					list = new List<T>(1);
				}
				list.Add(item);
			}
		}
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				input.Remove(list[i]);
			}
		}
	}

	public static void RemoveAll<T>(this HashList<T> input, Func<T, bool> predicate)
	{
		T[] array = input.ToArray();
		foreach (T val in array)
		{
			if (predicate(val))
			{
				input.Remove(val);
			}
		}
	}

	public static float AverageOrDefault<T>(this IList<T> input, Func<T, float> func, float def = 0f)
	{
		if (input.Count <= 0)
		{
			return def;
		}
		return input.Average(func);
	}

	public static double AverageOrDefault<T>(this IList<T> input, Func<T, double> func, double def = 0.0)
	{
		if (input.Count <= 0)
		{
			return def;
		}
		return input.Average(func);
	}

	public static float AverageOrDefault<T>(this HashSet<T> input, Func<T, float> func, float def)
	{
		if (!input.Any())
		{
			return def;
		}
		return input.Average(func);
	}

	public static int MinOrDefault(this IEnumerable<int> input, int def)
	{
		if (!input.Any())
		{
			return def;
		}
		return input.Min();
	}

	public static float MinOrDefault(this IEnumerable<float> input, float def)
	{
		if (!input.Any())
		{
			return def;
		}
		return input.Min();
	}

	public static int MaxOrDefault(this IEnumerable<int> input, int def)
	{
		if (!input.Any())
		{
			return def;
		}
		return input.Max();
	}

	public static float MaxOrDefault(this IEnumerable<float> input, float def)
	{
		if (!input.Any())
		{
			return def;
		}
		return input.Max();
	}

	public static HashSet<T> ToHashSet<T>(this IList<T> list)
	{
		HashSet<T> hashSet = new HashSet<T>();
		hashSet.AddRange(list);
		return hashSet;
	}

	public static HashSet<T> ToHashSet<T>(this IEnumerable<T> list)
	{
		HashSet<T> hashSet = new HashSet<T>();
		foreach (T item in list)
		{
			hashSet.Add(item);
		}
		return hashSet;
	}

	public static SHashSet<T> ToSHashSet<T>(this IList<T> list)
	{
		SHashSet<T> sHashSet = new SHashSet<T>();
		sHashSet.AddRange(list);
		return sHashSet;
	}

	public static SHashSet<T> ToSHashSet<T>(this IEnumerable<T> list)
	{
		SHashSet<T> sHashSet = new SHashSet<T>();
		foreach (T item in list)
		{
			sHashSet.Add(item);
		}
		return sHashSet;
	}

	public static void WriteMultipleFiles(string filename, Dictionary<string, byte[]> data)
	{
		using (FileStream fileStream = File.Create(filename))
		{
			foreach (KeyValuePair<string, byte[]> datum in data)
			{
				byte[] bytesFromString = GetBytesFromString(datum.Key);
				fileStream.Write(GetBytesFromInt(bytesFromString.Length), 0, 4);
				fileStream.Write(bytesFromString, 0, bytesFromString.Length);
				fileStream.Write(GetBytesFromInt(datum.Value.Length), 0, 4);
				fileStream.Write(datum.Value, 0, datum.Value.Length);
			}
			fileStream.Flush();
		}
	}

	public static byte[] ReadData(string filename, string header)
	{
		using (FileStream file = File.OpenRead(filename))
		{
			return ReadData(file, header);
		}
	}

	public static byte[] ReadData(byte[] fileData, string header)
	{
		using (MemoryStream file = new MemoryStream(fileData))
		{
			return ReadData(file, header);
		}
	}

	public static byte[] ReadData(Stream file, string header)
	{
		long num = 0L;
		int num2 = 0;
		while (true)
		{
			byte[] array = new byte[4];
			if (file.Read(array, 0, array.Length) != array.Length)
			{
				throw new Exception(string.Format("File corrupted, header: {0}, incomplete header length. Labels: {1}, read: {2} kb", header, num2, num / 1024));
			}
			int intFromBytes = GetIntFromBytes(array);
			if (intFromBytes < 0 || intFromBytes > 1024)
			{
				throw new Exception(string.Format("File corrupted, header: {0} wrong header length: {1} Labels: {2}, read: {3} kb", header, intFromBytes, num2, num / 1024));
			}
			byte[] array2 = new byte[intFromBytes];
			if (file.Read(array2, 0, intFromBytes) != intFromBytes)
			{
				throw new Exception(string.Format("File corrupted, header: {0}, incomplete header name. Labels: {1}, read: {2} kb", header, num2, num / 1024));
			}
			if (file.Read(array, 0, array.Length) != array.Length)
			{
				throw new Exception(string.Format("File corrupted, header: {0}, incomplete data length. Labels: {1}, read: {2} kb", header, num2, num / 1024));
			}
			string stringFromBytes = GetStringFromBytes(array2);
			int intFromBytes2 = GetIntFromBytes(array);
			if (stringFromBytes.Equals(header))
			{
				byte[] array3 = new byte[intFromBytes2];
				if (file.Read(array3, 0, array3.Length) != array3.Length)
				{
					throw new Exception(string.Format("File corrupted, header: {0}, incomplete data. Labels: {1}, read: {2} kb", header, num2, num / 1024));
				}
				return array3;
			}
			num2++;
			if (num2 > 32)
			{
				throw new Exception(string.Format("File corrupted, header: {0}, over 32 labels. Labels: {1}, read: {2} kb", header, num2, num / 1024));
			}
			num = file.Position + intFromBytes2;
			if (num >= file.Length)
			{
				break;
			}
			file.Position += intFromBytes2;
		}
		throw new Exception(string.Format("File corrupted, header: {0} missing. Labels: {1}, read: {2} kb", header, num2, num / 1024));
	}

	public static byte[] GetBytesFromInt(int integer)
	{
		byte[] bytes = BitConverter.GetBytes(integer);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse((Array)bytes);
		}
		return bytes;
	}

	public static int GetIntFromBytes(byte[] bytes)
	{
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse((Array)bytes);
		}
		return BitConverter.ToInt32(bytes, 0);
	}

	public static byte[] GetBytesFromFloats(float[] floats)
	{
		int num = 4;
		byte[] array = new byte[num * floats.Length];
		for (int i = 0; i < floats.Length; i++)
		{
			byte[] bytes = BitConverter.GetBytes(floats[i]);
			for (int j = 0; j < bytes.Length; j++)
			{
				int num2 = j;
				if (BitConverter.IsLittleEndian)
				{
					num2 = bytes.Length - 1 - j;
				}
				array[i * num + j] = bytes[num2];
			}
		}
		return array;
	}

	public static float[] GetFloatsFromBytes(byte[] bytes)
	{
		int num = 4;
		int num2 = bytes.Length / num;
		float[] array = new float[num2];
		if (BitConverter.IsLittleEndian)
		{
			for (int i = 0; i < num2; i++)
			{
				Array.Reverse((Array)bytes, i * num, num);
			}
		}
		for (int j = 0; j < num2; j++)
		{
			array[j] = BitConverter.ToSingle(bytes, j * num);
		}
		return array;
	}

	public static byte[] GetBytesFromString(string str)
	{
		byte[] array = new byte[str.Length * 2];
		Buffer.BlockCopy(str.ToCharArray(), 0, array, 0, array.Length);
		return array;
	}

	public static string GetStringFromBytes(byte[] bytes)
	{
		char[] array = new char[bytes.Length / 2];
		Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
		return new string(array);
	}

	public static float Dist(this Vector2 p1, Vector2 p2)
	{
		return Mathf.Sqrt(p1.SqrDist(p2));
	}

	public static float SqrDist(this Vector2 p1, Vector2 p2)
	{
		float num = p2.x - p1.x;
		float num2 = p2.y - p1.y;
		return num * num + num2 * num2;
	}

	public static bool ContainsEntirely(this Rect rect, Vector2 p)
	{
		if (p.x >= rect.xMin && p.x <= rect.xMax && p.y >= rect.yMin)
		{
			return p.y <= rect.yMax;
		}
		return false;
	}

	public static bool ContainsEntirely(this Rect rect, Vector2 p, float expand)
	{
		if (p.x >= rect.xMin - expand && p.x <= rect.xMax + expand && p.y >= rect.yMin - expand)
		{
			return p.y <= rect.yMax + expand;
		}
		return false;
	}

	public static bool CompletelyWithin(this Rect rect, Vector2 p)
	{
		if (p.x > rect.xMin && p.x < rect.xMax && p.y > rect.yMin)
		{
			return p.y < rect.yMax;
		}
		return false;
	}

	public static bool CompletelyWithin(this Rect rect, float x, float y)
	{
		if (x > rect.xMin && x < rect.xMax && y > rect.yMin)
		{
			return y < rect.yMax;
		}
		return false;
	}

	public static bool Contains(this Rect rect, float x, float y)
	{
		if (x >= rect.xMin && x < rect.xMax && y >= rect.yMin)
		{
			return y < rect.yMax;
		}
		return false;
	}

	public static float FullAngleBetween(this Vector2 b, Vector2 a, Vector2 c)
	{
		float num = Mathf.Acos(Vector2.Dot((a - b).normalized, (c - b).normalized)) * 57.29578f;
		if (IsLeft(b, a, c) > 0)
		{
			num += 180f;
		}
		return num;
	}

	public static float AngleBetween(this Vector2 b, Vector2 a, Vector2 c)
	{
		return Mathf.Abs(Mathf.Acos(Mathf.Clamp(Vector2.Dot((a - b).normalized, (c - b).normalized), -1f, 1f)) * 57.29578f);
	}

	public static bool ProjectToLine(Vector2 p, Vector2 a, Vector2 b, out Vector2 res, float eps = 0f)
	{
		res = Vector2.zero;
		if (a.x == b.x && a.y == b.y)
		{
			return false;
		}
		float num = (p.x - a.x) * (b.x - a.x) + (p.y - a.y) * (b.y - a.y);
		if (num < 0f - eps)
		{
			return false;
		}
		float num2 = Mathf.Pow(b.x - a.x, 2f) + Mathf.Pow(b.y - a.y, 2f);
		if (num > num2 + eps)
		{
			return false;
		}
		num /= num2;
		res = new Vector2(a.x + num * (b.x - a.x), a.y + num * (b.y - a.y));
		return true;
	}

	public static bool ProjectToLine(Vector2 p, Vector2 a, Vector2 b, out Vector2 res)
	{
		res = Vector2.zero;
		if (a.x == b.x && a.y == b.y)
		{
			return false;
		}
		float num = (p.x - a.x) * (b.x - a.x) + (p.y - a.y) * (b.y - a.y);
		if (num < 0f)
		{
			return false;
		}
		float num2 = Mathf.Pow(b.x - a.x, 2f) + Mathf.Pow(b.y - a.y, 2f);
		if (num > num2)
		{
			return false;
		}
		num /= num2;
		res = new Vector2(a.x + num * (b.x - a.x), a.y + num * (b.y - a.y));
		return true;
	}

	public static Vector2 ProjectToLineEndless(Vector2 p, Vector2 a, Vector2 b)
	{
		if (a.x == b.x && a.y == b.y)
		{
			return a;
		}
		float num = (p.x - a.x) * (b.x - a.x) + (p.y - a.y) * (b.y - a.y);
		float num2 = Mathf.Pow(b.x - a.x, 2f) + Mathf.Pow(b.y - a.y, 2f);
		num /= num2;
		return new Vector2(a.x + num * (b.x - a.x), a.y + num * (b.y - a.y));
	}

	public static float ProjectToLineEndlessMag(Vector2 p, Vector2 a, Vector2 b, bool squared)
	{
		if (a.x == b.x && a.y == b.y)
		{
			return 0f;
		}
		float num = (p.x - a.x) * (b.x - a.x) + (p.y - a.y) * (b.y - a.y);
		float num2 = Mathf.Pow(b.x - a.x, 2f) + Mathf.Pow(b.y - a.y, 2f);
		if (squared)
		{
			num2 = Mathf.Sqrt(num2);
		}
		return num / num2;
	}

	public static Vector2 ProjectToLineEndlessClamped(Vector2 p, Vector2 a, Vector2 b)
	{
		if (a.x == b.x && a.y == b.y)
		{
			return a;
		}
		float num = (p.x - a.x) * (b.x - a.x) + (p.y - a.y) * (b.y - a.y);
		float num2 = Mathf.Pow(b.x - a.x, 2f) + Mathf.Pow(b.y - a.y, 2f);
		num = Mathf.Clamp01(num / num2);
		return new Vector2(a.x + num * (b.x - a.x), a.y + num * (b.y - a.y));
	}

	public static int IsLeft(Vector2 p1, Vector2 p2, Vector2 p3)
	{
		float num = (p2.x - p1.x) * (p3.y - p1.y) - (p3.x - p1.x) * (p2.y - p1.y);
		if (num > 1.1E-44f)
		{
			return 1;
		}
		if (num < -1.1E-44f)
		{
			return -1;
		}
		return 0;
	}

	public static float GetOverlap(float a, float b, float c, float d)
	{
		return Mathf.Max(0f, Mathf.Min(b, d) - Mathf.Max(a, c));
	}

	public static bool Overlap(float a, float b, float c, float d)
	{
		if (!Mathf.Approximately(a, b))
		{
			return !Mathf.Approximately(GetOverlap(a, b, c, d), 0f);
		}
		if (c <= a)
		{
			return a <= d;
		}
		return false;
	}

	public static bool RelaxedOverlap(float a, float b, float c, float d)
	{
		if (!a.Appx(b))
		{
			return !Mathf.Max(0f, Mathf.Min(b, d) - Mathf.Max(a, c)).Appx(0f);
		}
		if (c <= a)
		{
			return a <= d;
		}
		return false;
	}

	public static bool StrictOverlap(float a, float b, float c, float d)
	{
		if (b != c && a != d)
		{
			return !Mathf.Approximately(Mathf.Max(0f, Mathf.Min(b, d) - Mathf.Max(a, c)), 0f);
		}
		return true;
	}

	public static bool IsStrictlyInside(Vector2 p, Vector2[] polygon)
	{
		bool flag = false;
		int num = polygon.Count() - 1;
		for (int i = 0; i < polygon.Count(); i++)
		{
			if (((polygon[i].y < p.y && polygon[num].y > p.y) || (polygon[num].y < p.y && polygon[i].y > p.y)) && polygon[i].x + (p.y - polygon[i].y) / (polygon[num].y - polygon[i].y) * (polygon[num].x - polygon[i].x) < p.x)
			{
				flag = !flag;
			}
			num = i;
		}
		return flag;
	}

	public static bool IsInside(Vector2 p, IList<Vector2> polygon)
	{
		bool flag = false;
		int num = 0;
		int index = polygon.Count - 1;
		while (num < polygon.Count)
		{
			if (polygon[num].y > p.y != polygon[index].y > p.y && p.x < (polygon[index].x - polygon[num].x) * (p.y - polygon[num].y) / (polygon[index].y - polygon[num].y) + polygon[num].x)
			{
				flag = !flag;
			}
			index = num++;
		}
		return flag;
	}

	public static bool IsInside(Vector2 p, IList<Vector2> polygon, float offset)
	{
		bool flag = false;
		int num = 0;
		int i = polygon.Count - 1;
		while (num < polygon.Count)
		{
			Vector2 offset2 = GetOffset(num, polygon, offset, true);
			Vector2 offset3 = GetOffset(i, polygon, offset, true);
			if (offset2.y > p.y != offset3.y > p.y && p.x < (offset3.x - offset2.x) * (p.y - offset2.y) / (offset3.y - offset2.y) + offset2.x)
			{
				flag = !flag;
			}
			i = num++;
		}
		return flag;
	}

	public static bool IsInside(Vector2 p, List<WallEdge> polygon)
	{
		bool flag = false;
		int num = 0;
		int index = polygon.Count - 1;
		while (num < polygon.Count)
		{
			if (polygon[num].Pos.y > p.y != polygon[index].Pos.y > p.y && p.x < (polygon[index].Pos.x - polygon[num].Pos.x) * (p.y - polygon[num].Pos.y) / (polygon[index].Pos.y - polygon[num].Pos.y) + polygon[num].Pos.x)
			{
				flag = !flag;
			}
			index = num++;
		}
		return flag;
	}

	public static bool IsInsideSnap(Vector2 p, IList<Vector2> polygon, float dist)
	{
		int num = 0;
		for (int i = 0; i < polygon.Count; i++)
		{
			Vector2 vector = polygon[i];
			Vector2 vector2 = polygon[(i + 1) % polygon.Count];
			Vector2 res;
			if (ProjectToLine(p, vector, vector2, out res) && res.Dist(p) < dist)
			{
				return false;
			}
			if (vector.y <= p.y)
			{
				if (vector2.y > p.y && IsLeft(vector, vector2, p) > 0)
				{
					num++;
				}
			}
			else if (vector2.y <= p.y && IsLeft(vector, vector2, p) < 0)
			{
				num--;
			}
		}
		return num != 0;
	}

	public static bool IsZero(this float x)
	{
		if (x >= 0f - Mathf.Epsilon)
		{
			return x <= Mathf.Epsilon;
		}
		return false;
	}

	public static Vector2? GetLineIntersection(Vector2 p, Vector2 p2, Vector2 q, Vector2 q2, bool includeEnds = true)
	{
		Vector2 vector = p2 - p;
		Vector2 b = q2 - q;
		float num = vector.Cross(b);
		if (num.IsZero())
		{
			return null;
		}
		float num2 = (q - p).Cross(b) / num;
		float num3 = (q - p).Cross(vector) / num;
		if (includeEnds)
		{
			if (0f <= num2 && num2 <= 1f && 0f <= num3 && num3 <= 1f)
			{
				return p + vector * num2;
			}
		}
		else if (0.001f < num2 && num2 < 0.999f && 0.001f < num3 && num3 < 0.999f)
		{
			return p + vector * num2;
		}
		return null;
	}

	public static bool GetLineIntersectionClamped(Vector2 p, Vector2 p2, Vector2 q, Vector2 q2, float min, float max, out Vector2 res)
	{
		res = Vector2.zero;
		float num = p2.x - p.x;
		float num2 = p2.y - p.y;
		float num3 = q2.x - q.x;
		float num4 = q2.y - q.y;
		float num5 = num * num4 - num2 * num3;
		if (num5.IsZero())
		{
			return false;
		}
		float num6 = q.x - p.x;
		float num7 = q.y - p.y;
		float num8 = (num6 * num4 - num7 * num3) / num5;
		if (num8 > min && num8 < max)
		{
			float num9 = Mathf.Clamp01(num8);
			res = new Vector2(p.x + num * num9, p.y + num2 * num9);
			return true;
		}
		return false;
	}

	public static float Cross(this Vector2 a, Vector2 b)
	{
		return Cross(a.x, a.y, b.x, b.y);
	}

	public static float Cross(float x1, float y1, float x2, float y2)
	{
		return x1 * y2 - y1 * x2;
	}

	public static bool FasterLineSegmentIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
	{
		float num = p2.x - p1.x;
		float num2 = p2.y - p1.y;
		float num3 = p3.x - p4.x;
		float num4 = p3.y - p4.y;
		float num5 = p1.x - p3.x;
		float num6 = p1.y - p3.y;
		float num7 = num4 * num5 - num3 * num6;
		float num8 = num2 * num3 - num * num4;
		if (num8.IsZero())
		{
			return false;
		}
		float num9 = num * num6 - num2 * num5;
		if (num8.IsZero())
		{
			return false;
		}
		if (num8 > 0f)
		{
			if (num7 < 0f || num7 > num8)
			{
				return false;
			}
		}
		else if (num7 > 0f || num7 < num8)
		{
			return false;
		}
		if (num8 > 0f)
		{
			if (num9 < 0f || num9 > num8)
			{
				return false;
			}
		}
		else if (num9 > 0f || num9 < num8)
		{
			return false;
		}
		return true;
	}

	public static bool LinesIntersect(Vector2 p, Vector2 p2, Vector2 q, Vector2 q2, bool allowColinear, bool includePoints)
	{
		return LinesIntersect(p, p2, q, q2, allowColinear, includePoints, includePoints);
	}

	public static bool LinesIntersect(Vector2 p, Vector2 p2, Vector2 q, Vector2 q2, bool allowColinear, bool includePointsA, bool includePointsB)
	{
		Vector2 vector = p2 - p;
		Vector2 vector2 = q2 - q;
		float num = vector.Cross(vector2);
		float x = (q - p).Cross(vector);
		if (num.IsZero() && x.IsZero())
		{
			if (!allowColinear)
			{
				float num2 = Vector2.Dot(q - p, vector);
				float num3 = Vector2.Dot(vector, vector);
				float num4 = Vector2.Dot(p - q, vector2);
				float num5 = Vector2.Dot(vector2, vector2);
				if (((0f <= num2 && num2 <= num3) || (0f <= num4 && num4 <= num5)) && vector.normalized != vector2.normalized)
				{
					return true;
				}
			}
			return false;
		}
		if (num.IsZero() && !x.IsZero())
		{
			return false;
		}
		float num6 = (q - p).Cross(vector2) / num;
		float num7 = (q - p).Cross(vector) / num;
		if (num.IsZero())
		{
			return false;
		}
		bool num8;
		if (!includePointsA)
		{
			if (0.0001 < (double)num6)
			{
				num8 = (double)num6 < 0.9999;
				goto IL_011c;
			}
		}
		else if (0f <= num6)
		{
			num8 = num6 <= 1f;
			goto IL_011c;
		}
		goto IL_011e;
		IL_011c:
		if (num8)
		{
			if (!includePointsB)
			{
				if (0.0001 < (double)num7)
				{
					return (double)num7 < 0.9999;
				}
				return false;
			}
			if (0f <= num7)
			{
				return num7 <= 1f;
			}
			return false;
		}
		goto IL_011e;
		IL_011e:
		return false;
	}

	public static List<Vector2> ComputeConvexHull(List<Vector2> points)
	{
		List<Vector2> list = new List<Vector2>();
		if (points.Count == 0)
		{
			return list;
		}
		int num = 0;
		int num2 = 0;
		foreach (Vector2 item in from x in points
			orderby x.x descending, x.y descending
			select x)
		{
			Vector2 vector;
			while (num >= 2 && ((vector = list.Last()) - list[list.Count - 2]).Cross(item - vector) >= 0f)
			{
				list.RemoveAt(list.Count - 1);
				num--;
			}
			list.Add(item);
			num++;
			while (num2 >= 2 && ((vector = list.First()) - list[1]).Cross(item - vector) <= 0f)
			{
				list.RemoveAt(0);
				num2--;
			}
			if (num2 != 0)
			{
				list.Insert(0, item);
			}
			num2++;
		}
		list.RemoveAt(list.Count - 1);
		return list;
	}

	public static List<Vector2> ComputeConcaveHull(List<Vector2> points)
	{
		HashSet<Vector2> hashSet = new HashSet<Vector2>(points);
		List<Vector2> list = ComputeConvexHull(points);
		if (Clockwise(list))
		{
			list.Reverse();
		}
		for (int i = 0; i < list.Count; i++)
		{
			hashSet.Remove(list[i]);
		}
		bool flag = true;
		while (hashSet.Count > 0 && flag)
		{
			flag = false;
			int num = 0;
			Vector2? vector = null;
			float num2 = float.MaxValue;
			for (int j = 0; j < list.Count; j++)
			{
				Vector2 vector2 = list[j];
				Vector2 vector3 = list[(j + 1) % list.Count];
				float sqrMagnitude = (vector2 - vector3).sqrMagnitude;
				foreach (Vector2 item in hashSet)
				{
					Vector2 res;
					if (ProjectToLine(item, vector2, vector3, out res))
					{
						float sqrMagnitude2 = (item - res).sqrMagnitude;
						if (sqrMagnitude2 < sqrMagnitude && sqrMagnitude2 < num2)
						{
							vector = item;
							num2 = sqrMagnitude2;
							num = j;
						}
					}
				}
			}
			if (vector.HasValue)
			{
				flag = true;
				list.Insert(num + 1, vector.Value);
				hashSet.Remove(vector.Value);
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			Vector2 vector4 = list[(k == 0) ? (list.Count - 1) : (k - 1)];
			Vector2 vector5 = list[k];
			Vector2 vector6 = list[(k + 1) % list.Count];
			if ((vector5 - vector4).normalized == (vector5 - vector6).normalized)
			{
				list.RemoveAt(k);
				k--;
			}
		}
		return list;
	}

	public static bool Clockwise(IList<Vector2> s)
	{
		float num = 0f;
		for (int i = 0; i < s.Count; i++)
		{
			Vector2 vector = s[i];
			Vector2 vector2 = s[(i + 1) % s.Count];
			num += (vector2.x - vector.x) * (vector2.y + vector.y);
		}
		return num > 0f;
	}

	public static float SumSafe<T>(this IList<T> list, Func<T, float> convert)
	{
		float num = 0f;
		for (int i = 0; i < list.Count; i++)
		{
			num += convert(list[i]);
		}
		return num;
	}

	public static double SumSafe<T>(this IList<T> list, Func<T, double> convert)
	{
		double num = 0.0;
		for (int i = 0; i < list.Count; i++)
		{
			num += convert(list[i]);
		}
		return num;
	}

	public static float SumSafe<T>(this IList<T> list, Func<T, int, float> convert)
	{
		float num = 0f;
		for (int i = 0; i < list.Count; i++)
		{
			num += convert(list[i], i);
		}
		return num;
	}

	public static float SumSafe<T>(this IEnumerable<T> list, Func<T, float> convert)
	{
		float num = 0f;
		foreach (T item in list)
		{
			num += convert(item);
		}
		return num;
	}

	public static double SumSafe<T>(this IEnumerable<T> list, Func<T, double> convert)
	{
		double num = 0.0;
		foreach (T item in list)
		{
			num += convert(item);
		}
		return num;
	}

	public static int SumSafe<T>(this IList<T> list, Func<T, int> convert)
	{
		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			num += convert(list[i]);
		}
		return num;
	}

	public static int SumSafe<T>(this IEnumerable<T> list, Func<T, int> convert)
	{
		int num = 0;
		foreach (T item in list)
		{
			num += convert(item);
		}
		return num;
	}

	public static uint SumSafe<T>(this IList<T> list, Func<T, uint> convert)
	{
		uint num = 0u;
		for (int i = 0; i < list.Count; i++)
		{
			num += convert(list[i]);
		}
		return num;
	}

	public static float MaxSafe<T>(this IEnumerable<T> list, Func<T, float> convert, float defValue = float.MinValue)
	{
		float num = defValue;
		foreach (T item in list)
		{
			num = Mathf.Max(num, convert(item));
		}
		return num;
	}

	public static double MaxSafe<T>(this IEnumerable<T> list, Func<T, double> convert, double defValue = double.MinValue)
	{
		double num = defValue;
		foreach (T item in list)
		{
			num = Math.Max(num, convert(item));
		}
		return num;
	}

	public static uint MaxSafeUint<T>(this IEnumerable<T> list, Func<T, uint> convert, uint defValue = 0u)
	{
		uint num = defValue;
		foreach (T item in list)
		{
			uint num2 = convert(item);
			if (num2 > num)
			{
				num = num2;
			}
		}
		return num;
	}

	public static void AddRange<T>(this IList<T> l, params T[] a)
	{
		if (a.Length == 1)
		{
			l.Add(a[0]);
			return;
		}
		for (int i = 0; i < a.Length; i++)
		{
			l.Add(a[i]);
		}
	}

	public static void AddRange<T>(this IList<T> l, IEnumerable<T> a)
	{
		foreach (T item in a)
		{
			l.Add(item);
		}
	}

	public static float MaxSafe<T>(this IList<T> list, Func<T, float> convert, float defValue = float.MinValue, float empty = 0f)
	{
		if (list.Count == 0)
		{
			return empty;
		}
		float num = defValue;
		for (int i = 0; i < list.Count; i++)
		{
			float num2 = convert(list[i]);
			if (num2 > num)
			{
				num = num2;
			}
		}
		return num;
	}

	public static int MaxSafeInt<T>(this IList<T> list, Func<T, int> convert, int defValue = int.MinValue, int empty = 0)
	{
		if (list.Count == 0)
		{
			return empty;
		}
		int num = defValue;
		for (int i = 0; i < list.Count; i++)
		{
			int num2 = convert(list[i]);
			if (num2 > num)
			{
				num = num2;
			}
		}
		return num;
	}

	public static uint MaxSafeUInt<T>(this IList<T> list, Func<T, uint> convert, uint defValue = 0u, uint empty = 0u)
	{
		if (list.Count == 0)
		{
			return empty;
		}
		uint num = defValue;
		for (int i = 0; i < list.Count; i++)
		{
			uint num2 = convert(list[i]);
			if (num2 > num)
			{
				num = num2;
			}
		}
		return num;
	}

	public static int MaxSafeInt<T>(this IEnumerable<T> list, Func<T, int> convert, int defValue = int.MinValue)
	{
		int num = defValue;
		foreach (T item in list)
		{
			int num2 = convert(item);
			if (num2 > num)
			{
				num = num2;
			}
		}
		return num;
	}

	public static int MaxSafeInt(this IList<int> list, int defValue = int.MinValue)
	{
		int num = defValue;
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] > num)
			{
				num = list[i];
			}
		}
		return num;
	}

	public static int MaxSafeInt(this IEnumerable<int> list, int defValue = int.MinValue)
	{
		int num = defValue;
		foreach (int item in list)
		{
			if (item > num)
			{
				num = item;
			}
		}
		return num;
	}

	public static float MinSafe<T>(this IList<T> list, Func<T, float> convert, float defValue = float.MaxValue, float empty = 0f)
	{
		if (list.Count == 0)
		{
			return empty;
		}
		float num = defValue;
		for (int i = 0; i < list.Count; i++)
		{
			float num2 = convert(list[i]);
			if (num2 < num)
			{
				num = num2;
			}
		}
		return num;
	}

	public static int MinSafeInt<T>(this IList<T> list, Func<T, int> convert, int defValue = int.MaxValue, int empty = 0)
	{
		if (list.Count == 0)
		{
			return empty;
		}
		int num = defValue;
		for (int i = 0; i < list.Count; i++)
		{
			int num2 = convert(list[i]);
			if (num2 < num)
			{
				num = num2;
			}
		}
		return num;
	}

	public static float PolygonArea(IList<Vector2> polygon)
	{
		float num = 0f;
		for (int i = 0; i < polygon.Count; i++)
		{
			int index = (i + 1) % polygon.Count;
			num += (polygon[index].x - polygon[i].x) * (polygon[index].y + polygon[i].y) / 2f;
		}
		return Mathf.Abs(num);
	}

	public static float PolygonArea(IList<WallEdge> polygon)
	{
		float num = 0f;
		for (int i = 0; i < polygon.Count; i++)
		{
			int index = (i + 1) % polygon.Count;
			num += (polygon[index].Pos.x - polygon[i].Pos.x) * (polygon[index].Pos.y + polygon[i].Pos.y) / 2f;
		}
		return Mathf.Abs(num);
	}

	public static Vector3 MinVector(Vector3 v, Vector3 v2)
	{
		return new Vector3(Mathf.Min(v.x, v2.x), Mathf.Min(v.y, v2.y), Mathf.Min(v.z, v2.z));
	}

	public static Vector3 MaxVector(Vector3 v, Vector3 v2)
	{
		return new Vector3(Mathf.Max(v.x, v2.x), Mathf.Max(v.y, v2.y), Mathf.Max(v.z, v2.z));
	}

	public static IEnumerable<T> Concate<T>(this IEnumerable<T> input, T item)
	{
		foreach (T item2 in input)
		{
			yield return item2;
		}
		yield return item;
	}

	public static IEnumerable<T> Concate<T>(this T item, IEnumerable<T> input)
	{
		yield return item;
		foreach (T item2 in input)
		{
			yield return item2;
		}
	}

	public static void VBOToMesh(List<UIVertex> vertices, Mesh result)
	{
		VertexHelper vertexHelper = new VertexHelper();
		for (int i = 0; i < vertices.Count; i++)
		{
			vertexHelper.AddVert(vertices[i]);
			if (i % 4 == 0)
			{
				vertexHelper.AddTriangle(i, i + 1, i + 2);
				vertexHelper.AddTriangle(i + 2, i + 3, i);
			}
		}
		vertexHelper.FillMesh(result);
	}

	public static void VBOToHelper(List<UIVertex> vertices, VertexHelper result)
	{
		_VBOIndexCache.Clear();
		for (int i = 0; i < vertices.Count; i += 4)
		{
			_VBOIndexCache.Add(i);
			_VBOIndexCache.Add(i + 1);
			_VBOIndexCache.Add(i + 2);
			_VBOIndexCache.Add(i + 2);
			_VBOIndexCache.Add(i + 3);
			_VBOIndexCache.Add(i);
		}
		result.AddUIVertexStream(vertices, _VBOIndexCache);
		_VBOIndexCache.Clear();
	}

	public static PolyTree HolePolygon(Vector2[] polygon, List<Vector2[]> holes, int fixHoles, List<Vector3> holeTr)
	{
		if (holes.Count > 1)
		{
			List<float> list;
			lock (_holeSortKeys)
			{
				list = _holeSortKeys.Get();
			}
			for (int i = 0; i < holes.Count; i++)
			{
				list.Add(holes[i].Min((Vector2 x) => x.x + x.y));
			}
			FloatListSorter.SortByFloatKeys(holes, list);
			lock (_holeSortKeys)
			{
				_holeSortKeys.Release(list, true);
			}
		}
		Clipper clipper = new Clipper();
		clipper.AddPath(polygon.SelectInPlaceList((Vector2 x) => new IntPoint(x.x * 12000f, x.y * 12000f)), PolyType.ptSubject, true);
		if (fixHoles == 0)
		{
			FixHoleBoundary(holes, polygon);
		}
		switch (fixHoles)
		{
		case 2:
			FixHoles2(holes, holeTr);
			break;
		case 1:
			FixHoles(holes, holeTr);
			break;
		}
		clipper.AddPaths(holes.SelectInPlaceList((Vector2[] y) => y.SelectInPlaceList((Vector2 x) => new IntPoint(x.x * 12000f, x.y * 12000f))), PolyType.ptClip, true);
		PolyTree polyTree;
		lock (_polyTreePool)
		{
			polyTree = _polyTreePool.Get();
		}
		clipper.Execute(ClipType.ctDifference, polyTree, PolyFillType.pftPositive, PolyFillType.pftPositive);
		return polyTree;
	}

	public static KeyValuePair<Vector2[], int[]> SubtractAndTriangulate(Vector2[] polygon, List<Vector2[]> holes, int fixHoles, bool divide, List<Vector3> holeTr = null)
	{
		int t = 0;
		List<Vector2> list = new List<Vector2>();
		List<int> list2 = new List<int>();
		PolyTree polyTree = HolePolygon(polygon, holes, fixHoles, holeTr);
		for (int i = 0; i < polyTree.Childs.Count; i++)
		{
			t = ProcessPolygon(polyTree.Childs[i], t, list, list2, 0, divide);
		}
		lock (_polyTreePool)
		{
			_polyTreePool.Release(polyTree);
		}
		return new KeyValuePair<Vector2[], int[]>(list.SelectInPlace((Vector2 x) => x * 8.333333E-05f), list2.ToArray());
	}

	private static bool PolyInPoly(IList<Vector2> p1, IList<Vector2> outer)
	{
		for (int i = 0; i < p1.Count; i++)
		{
			if (!IsInside(p1[i], outer))
			{
				return false;
			}
		}
		return true;
	}

	private static void DrawPolygon(IList<Vector2> v, float y, Color col)
	{
		for (int i = 0; i < v.Count; i++)
		{
			Vector2 vector = v[i] * 8.333333E-05f;
			Vector2 vector2 = v[(i + 1) % v.Count] * 8.333333E-05f;
			UnityEngine.Debug.DrawLine(new Vector3(vector.x, y, vector.y), new Vector3(vector2.x, y, vector2.y), col, 30f);
		}
	}

	private static void FixHoleBoundary(IList<Vector2[]> holes, IList<Vector2> polygon)
	{
		for (int i = 0; i < holes.Count; i++)
		{
			for (int j = 0; j < holes[i].Length; j++)
			{
				for (int k = 0; k < polygon.Count; k++)
				{
					int index = (k + 1) % polygon.Count;
					Vector2 res;
					if (holes[i][j] != polygon[k] && holes[i][j] != polygon[index] && ProjectToLine(holes[i][j], polygon[k], polygon[index], out res) && (res - holes[i][j]).sqrMagnitude < 4.1666666E-05f)
					{
						holes[i][j] = holes[i][j] - (polygon[index] - polygon[k]).Turn90().normalized * 0.004166667f;
					}
					index = (j + 1) % holes[i].Length;
					int index2 = ((k == 0) ? (polygon.Count - 1) : (k - 1));
					int index3 = (k + 1) % polygon.Count;
					Vector2 res2;
					if (holes[i][j] != polygon[k] && holes[i][index] != polygon[k] && ProjectToLine(polygon[k], holes[i][j], holes[i][index], out res2) && (res2 - polygon[k]).sqrMagnitude < 4.1666666E-05f && (!Alike(polygon[index2], polygon[k], polygon[index3], 4.1666666E-05f) || !LinesIntersect(holes[i][j], holes[i][index], polygon[k] + (polygon[index2] - polygon[k]) * 100f, polygon[k] + (polygon[index3] - polygon[k]) * 100f, true, false)))
					{
						List<Vector2> list = holes[i].ToList();
						list.Insert(j + 1, polygon[k]);
						list[j + 1] -= ((polygon[index3] - polygon[k]).Turn90().normalized + (polygon[k] - polygon[index2]).Turn90().normalized) * 0.004166667f;
						holes[i] = list.ToArray();
						j++;
					}
				}
			}
		}
	}

	private static void AddSquare(Vector2 p, IList<Vector2[]> holes)
	{
		Vector2[] item = new Vector2[4]
		{
			new Vector2(p.x, p.y + 0.05f),
			new Vector2(p.x - 0.05f, p.y),
			new Vector2(p.x, p.y - 0.05f),
			new Vector2(p.x + 0.05f, p.y)
		};
		holes.Add(item);
	}

	private static void FixHoles2(IList<Vector2[]> holes, IList<Vector3> holeTr)
	{
		int count = holes.Count;
		for (int i = 0; i < count; i++)
		{
			Vector3 vector = Vector3.zero;
			if (holeTr != null)
			{
				vector = holeTr[i];
			}
			for (int j = i + 1; j < count; j++)
			{
				if (holeTr != null)
				{
					Vector3 vector2 = holeTr[j];
					if ((vector - vector2).sqrMagnitude > 20f)
					{
						continue;
					}
				}
				for (int k = 0; k < holes[i].Length; k++)
				{
					for (int l = 0; l < holes[j].Length; l++)
					{
						int num = (k + 1) % holes[i].Length;
						int num2 = (l + 1) % holes[j].Length;
						float num3 = holes[i][k].SqrDist(holes[j][l]);
						if (num3 < 8.333333E-05f)
						{
							AddSquare(holes[i][k], holes);
							break;
						}
						Vector2 res;
						if (num3 >= 8.333333E-05f && holes[i][k].SqrDist(holes[j][num2]) >= 8.333333E-05f && ProjectToLine(holes[i][k], holes[j][l], holes[j][num2], out res) && res.SqrDist(holes[i][k]) < 8.333333E-05f)
						{
							AddSquare(holes[i][k], holes);
							break;
						}
						Vector2 res2;
						if (num3 >= 8.333333E-05f && holes[j][l].SqrDist(holes[i][num]) >= 8.333333E-05f && ProjectToLine(holes[j][l], holes[i][k], holes[i][num], out res2) && res2.SqrDist(holes[j][l]) < 8.333333E-05f)
						{
							AddSquare(holes[j][l], holes);
						}
					}
				}
			}
		}
	}

	private static void FixHoles(IList<Vector2[]> holes, IList<Vector3> holeTr)
	{
		for (int i = 0; i < holes.Count; i++)
		{
			Vector3 vector = Vector3.zero;
			if (holeTr != null)
			{
				vector = holeTr[i];
			}
			for (int j = i + 1; j < holes.Count; j++)
			{
				if (holeTr != null)
				{
					Vector3 vector2 = holeTr[j];
					if ((vector - vector2).sqrMagnitude > 16f)
					{
						continue;
					}
				}
				for (int k = 0; k < holes[i].Length; k++)
				{
					for (int l = 0; l < holes[j].Length; l++)
					{
						int num = ((k == 0) ? (holes[i].Length - 1) : (k - 1));
						int num2 = ((l == 0) ? (holes[j].Length - 1) : (l - 1));
						int num3 = (k + 1) % holes[i].Length;
						int num4 = (l + 1) % holes[j].Length;
						float num5 = holes[i][k].SqrDist(holes[j][l]);
						if (num5 < 8.333333E-05f && holes[i][num3].SqrDist(holes[j][num2]) >= 8.333333E-05f && holes[i][num].SqrDist(holes[j][num4]) >= 8.333333E-05f)
						{
							Vector2 vector3 = holes[j][l];
							holes[i][k] = holes[i][k] - ((holes[i][num] + holes[i][num3]) * 0.5f - vector3).normalized * 0.0005833333f;
						}
						else if (num5 < 8.333333E-05f)
						{
							holes[i][k] = holes[j][l];
						}
						Vector2 res;
						if (num5 >= 8.333333E-05f && holes[i][k].SqrDist(holes[j][num4]) >= 8.333333E-05f && ProjectToLine(holes[i][k], holes[j][l], holes[j][num4], out res) && res.SqrDist(holes[i][k]) < 8.333333E-05f)
						{
							holes[i][k] = holes[i][k] + (holes[j][num4] - holes[j][l]).Turn90().normalized * 0.0005833333f;
							break;
						}
						Vector2 res2;
						if (num5 >= 8.333333E-05f && holes[j][l].SqrDist(holes[i][num3]) >= 8.333333E-05f && ProjectToLine(holes[j][l], holes[i][k], holes[i][num3], out res2) && res2.SqrDist(holes[j][l]) < 8.333333E-05f)
						{
							holes[j][l] = holes[j][l] + (holes[i][num3] - holes[i][k]).Turn90().normalized * 0.0005833333f;
						}
					}
				}
			}
		}
	}

	public static Vector2 Turn90(this Vector2 v)
	{
		return new Vector2(0f - v.y, v.x);
	}

	private static void FixParallelIssue(IList<Vector2> v)
	{
		Dictionary<object, int> dictionary = new Dictionary<object, int>();
		for (int i = 0; i < v.Count; i++)
		{
			int value;
			if (dictionary.TryGetValue(v[i], out value))
			{
				v[i] = GetOffset(i, v, -100f);
			}
			dictionary[v[i]] = i;
		}
	}

	private static int ProcessPolygon(PolyNode poly, int t, List<Vector2> finalPolygon, List<int> triangulation, int layer, bool divide)
	{
		List<Vector2> list = poly.Contour.SelectInPlaceList((IntPoint x) => new Vector2(x.X, x.Y));
		if (Clockwise(list))
		{
			list.Reverse();
		}
		if (divide)
		{
			EnsureLength(list, 48000f);
		}
		FixParallelIssue(list);
		int num = Mathf.Min(poly.Childs.Count, 1024);
		Dictionary<PolyNode, List<Vector2>> dictionary = new Dictionary<PolyNode, List<Vector2>>(num);
		for (int num2 = 0; num2 < num; num2++)
		{
			PolyNode polyNode = poly.Childs[num2];
			dictionary[polyNode] = polyNode.Contour.SelectInPlaceList((IntPoint z) => new Vector2(z.X, z.Y));
		}
		List<KeyValuePair<PolyNode, List<Vector2>>> list2 = null;
		List<Vector2> list3 = null;
		for (int num3 = 0; num3 < poly.Childs.Count; num3++)
		{
			PolyNode polyNode2 = poly.Childs[num3];
			for (int num4 = 0; num4 < polyNode2.Childs.Count; num4++)
			{
				PolyNode polyNode3 = polyNode2.Childs[num4];
				if (list3 == null)
				{
					list3 = new List<Vector2>(polyNode3.Contour.Count);
				}
				else
				{
					list3.Clear();
				}
				for (int num5 = 0; num5 < polyNode3.Contour.Count; num5++)
				{
					IntPoint intPoint = polyNode3.Contour[num5];
					list3.Add(new Vector2(intPoint.X, intPoint.Y));
				}
				if (list2 != null)
				{
					list2.Clear();
				}
				else
				{
					list2 = new List<KeyValuePair<PolyNode, List<Vector2>>>(dictionary.Count);
				}
				list2.AddRange(dictionary);
				for (int num6 = 0; num6 < list2.Count; num6++)
				{
					KeyValuePair<PolyNode, List<Vector2>> keyValuePair = list2[num6];
					if (keyValuePair.Key != polyNode2 && PolyInPoly(keyValuePair.Value, list3))
					{
						dictionary.Remove(keyValuePair.Key);
						polyNode3.AddChild(keyValuePair.Key);
					}
				}
			}
		}
		foreach (PolyNode key in dictionary.Keys)
		{
			for (int num7 = 0; num7 < key.Childs.Count; num7++)
			{
				t = ProcessPolygon(key.Childs[num7], t, finalPolygon, triangulation, layer + 1, divide);
			}
		}
		foreach (List<Vector2> value in dictionary.Values)
		{
			if (Clockwise(value))
			{
				value.Reverse();
			}
			FixParallelIssue(value);
		}
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		ValueTuple<Vector2[], int[]> valueTuple = SwincBooster.Tesselate(list, dictionary.Values, true);
		TessTime += (float)stopwatch.ElapsedMilliseconds / 1000f;
		finalPolygon.AddRange(valueTuple.Item1);
		int t2 = t;
		triangulation.AddRange(valueTuple.Item2.Select((int x) => x + t2));
		t += valueTuple.Item1.Length;
		return t;
	}

	public static string PolyToString(PolyNode p)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < p.Contour.Count; i++)
		{
			stringBuilder.Append((float)p.Contour[i].X / 12000f + ";" + (float)p.Contour[i].Y / 12000f + "|");
		}
		return stringBuilder.ToString();
	}

	public static string PolyToString(List<Vector2> p)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < p.Count; i++)
		{
			stringBuilder.Append(p[i].x / 12000f + ";" + p[i].y / 12000f + "|");
		}
		return stringBuilder.ToString();
	}

	private static void EnsureLength(IList<Vector2> pol, float len)
	{
		for (int i = 0; i < pol.Count; i++)
		{
			int index = (i + 1) % pol.Count;
			if (pol[index].Dist(pol[i]) > len)
			{
				pol.Insert(i + 1, (pol[i] + pol[index]) * 0.5f);
				i--;
			}
		}
	}

	public static Vector2 GetHalfway(Vector2 first, Vector2 second, Vector2 third)
	{
		if ((second - first).normalized == (third - second).normalized)
		{
			Vector2 normalized = (third - second).normalized;
			return second + new Vector2(0f - normalized.y, normalized.x);
		}
		Vector3 vector = new Vector3(second.x, 0f, second.y);
		Vector3 vector2 = new Vector3(first.x, 0f, first.y);
		Vector3 vector3 = new Vector3(third.x, 0f, third.y);
		Quaternion a = Quaternion.LookRotation(vector2 - vector);
		Quaternion b = Quaternion.LookRotation(vector3 - vector);
		Vector3 vector4 = (Quaternion.Lerp(a, b, 0.5f) * Vector3.forward).normalized;
		float y = Vector3.Cross(vector2 - vector, vector3 - vector).y;
		if (!Mathf.Approximately(y, 0f) && y < 0f)
		{
			vector4 = -vector4;
		}
		return new Vector2(vector4.x, vector4.z);
	}

	public static List<List<T>> SimpleClustering<T>(this List<T> input, Func<T, T, float> distance, float minDist)
	{
		List<List<T>> list = new List<List<T>>();
		if (input.Count == 0)
		{
			return list;
		}
		list.Add(new List<T>());
		list[0].Add(input[0]);
		for (int i = 1; i < input.Count; i++)
		{
			bool flag = false;
			for (int j = 0; j < list.Count; j++)
			{
				for (int k = 0; k < list[j].Count; k++)
				{
					if (distance(input[i], list[j][k]) < minDist)
					{
						list[j].Add(input[i]);
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (!flag)
			{
				list.Add(new List<T> { input[i] });
			}
		}
		for (int l = 0; l < list.Count; l++)
		{
			for (int m = l + 1; m < list.Count; m++)
			{
				for (int n = 0; n < list[l].Count; n++)
				{
					bool flag2 = false;
					for (int num = 0; num < list[m].Count; num++)
					{
						if (distance(list[l][n], list[m][num]) < minDist)
						{
							list[l].AddRange(list[m]);
							list.RemoveAt(m);
							m--;
							flag2 = true;
							break;
						}
					}
					if (flag2)
					{
						break;
					}
				}
			}
		}
		return list;
	}

	public static Vector2 GetTriangleCentroid(IList<Vector2> points)
	{
		return GetTriangleCentroid(points[0], points[1], points[2]);
	}

	public static Vector2 GetTriangleCentroid(Vector2 a, Vector2 b, Vector2 c)
	{
		float accumulatedArea = 0f;
		float centerX = 0f;
		float centerY = 0f;
		OneTriangleIteration(a, c, ref accumulatedArea, ref centerX, ref centerY);
		OneTriangleIteration(b, a, ref accumulatedArea, ref centerX, ref centerY);
		OneTriangleIteration(c, b, ref accumulatedArea, ref centerX, ref centerY);
		if (Mathf.Abs(accumulatedArea) < 0.001f)
		{
			return new Vector2((a.x + b.x + c.x) / 3f, (a.y + b.y + c.y) / 3f);
		}
		accumulatedArea *= 3f;
		return new Vector2(centerX / accumulatedArea, centerY / accumulatedArea);
	}

	private static void OneTriangleIteration(Vector2 a, Vector2 c, ref float accumulatedArea, ref float centerX, ref float centerY)
	{
		float num = a.x * c.y - c.x * a.y;
		accumulatedArea += num;
		centerX += (a.x + c.x) * num;
		centerY += (a.y + c.y) * num;
	}

	public static Vector2 GetPolygonCentroid(IList<WallEdge> polygon)
	{
		if (polygon.Count == 0)
		{
			return Vector2.zero;
		}
		if (polygon.Count == 1)
		{
			return polygon[0].Pos;
		}
		if (polygon.Count == 2)
		{
			return (polygon[0].Pos + polygon[1].Pos) * 0.5f;
		}
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		for (int i = 0; i < polygon.Count; i++)
		{
			float x = polygon[i].Pos.x;
			float y = polygon[i].Pos.y;
			int index = (i + 1) % polygon.Count;
			float x2 = polygon[index].Pos.x;
			float y2 = polygon[index].Pos.y;
			float num4 = x * y2 - x2 * y;
			num3 += num4;
			num += (x + x2) * num4;
			num2 += (y + y2) * num4;
		}
		num3 *= 3f;
		num /= num3;
		num2 /= num3;
		return new Vector2(num, num2);
	}

	public static Vector2 GetPolygonCentroid(IList<Vector2> polygon)
	{
		if (polygon.Count == 0)
		{
			return Vector2.zero;
		}
		if (polygon.Count == 1)
		{
			return polygon[0];
		}
		if (polygon.Count == 2)
		{
			return (polygon[0] + polygon[1]) * 0.5f;
		}
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		for (int i = 0; i < polygon.Count; i++)
		{
			float x = polygon[i].x;
			float y = polygon[i].y;
			int index = (i + 1) % polygon.Count;
			float x2 = polygon[index].x;
			float y2 = polygon[index].y;
			float num4 = x * y2 - x2 * y;
			num3 += num4;
			num += (x + x2) * num4;
			num2 += (y + y2) * num4;
		}
		num3 *= 3f;
		num /= num3;
		num2 /= num3;
		return new Vector2(num, num2);
	}

	private static Vector2 Transform2DPoint(Vector2 v, Matrix4x4 trans)
	{
		return trans.MultiplyPoint(v.ToVector3(0f)).FlattenVector3();
	}

	public static Vector2 GetPolygonCentroid(IList<Vector2> polygon, Matrix4x4 trans)
	{
		if (polygon.Count == 0)
		{
			return Vector2.zero;
		}
		if (polygon.Count == 1)
		{
			return Transform2DPoint(polygon[0], trans);
		}
		if (polygon.Count == 2)
		{
			return (Transform2DPoint(polygon[0], trans) + Transform2DPoint(polygon[1], trans)) * 0.5f;
		}
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		for (int i = 0; i < polygon.Count; i++)
		{
			Vector2 vector = Transform2DPoint(polygon[i], trans);
			Vector2 vector2 = Transform2DPoint(polygon[(i + 1) % polygon.Count], trans);
			float num4 = vector.x * vector2.y - vector2.x * vector.y;
			num3 += num4;
			num += (vector.x + vector2.x) * num4;
			num2 += (vector.y + vector2.y) * num4;
		}
		num3 *= 3f;
		num /= num3;
		num2 /= num3;
		return new Vector2(num, num2);
	}

	public static int RandomRange(int min, int max)
	{
		return RNG.Next(min, max);
	}

	public static float RandomRange(float min, float max)
	{
		return min + (float)RNG.NextDouble() * (max - min);
	}

	public static float Range(this System.Random rnd, float min, float max)
	{
		return min + (float)rnd.NextDouble() * (max - min);
	}

	public static float NextFloat(this System.Random rnd)
	{
		return (float)rnd.NextDouble();
	}

	public static bool Appx(this float a, float b, float eps = 0.0001f)
	{
		return Mathf.Abs(a - b) < eps;
	}

	public static bool Appx(this double a, double b, double eps = 0.0001)
	{
		return Math.Abs(a - b) < eps;
	}

	public static bool Alike(Vector2 p1, Vector2 p2, Vector2 p3)
	{
		return Mathf.Approximately((p2.x - p1.x) * (p3.y - p2.y) - (p3.x - p2.x) * (p2.y - p1.y), 0f);
	}

	public static bool Alike(Vector2 p1, Vector2 p2, Vector2 p3, float delta)
	{
		return ((p2.x - p1.x) * (p3.y - p2.y) - (p3.x - p2.x) * (p2.y - p1.y)).Appx(0f, delta);
	}

	public static string ReadOnlyReadAllText(string filename)
	{
		using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
		{
			using (StreamReader streamReader = new StreamReader(stream))
			{
				return streamReader.ReadToEnd();
			}
		}
	}

	public static string GetListAbbrev<T>(this IList<T> teams, string loc, Func<T, string> conv = null)
	{
		if (teams.Count > 1)
		{
			return loc.LocPlural(teams.Count);
		}
		if (teams.Count == 1)
		{
			T val = teams[0];
			if (conv != null)
			{
				return conv(val);
			}
			return val as string;
		}
		return "None".Loc();
	}

	public static string GetListAbbrev<T>(this HashSet<T> teams, string loc, Func<T, string> conv = null)
	{
		if (teams.Count > 1)
		{
			return loc.LocPlural(teams.Count);
		}
		if (teams.Count == 1)
		{
			T val = teams.First();
			if (conv != null)
			{
				return conv(val);
			}
			return val as string;
		}
		return "None".Loc();
	}

	public static string Bandwidth(this float val)
	{
		if (val < 999f)
		{
			return Mathf.CeilToInt(val) + " Mbps";
		}
		if (val < 999999f)
		{
			return (val / 1000f).ToString("F1") + " Gbps";
		}
		return (val / 1000000f).ToString("F1") + " Tbps";
	}

	public static string WithPlusN(this float val, string format = "N2")
	{
		if (!(val > 0f))
		{
			return val.ToString(format);
		}
		return "+" + val.ToString(format);
	}

	public static string ByteSize(this float val, bool withPlus = false)
	{
		string text = ((val < 0f) ? "-" : ((val > 0f && withPlus) ? "+" : ""));
		val = Mathf.Abs(val);
		if (val < 1f)
		{
			return text + Mathf.RoundToInt(val * 1024f) + "KB";
		}
		if (val < 1024f)
		{
			return text + val.ToString("F1") + "MB";
		}
		if (val < 1048576f)
		{
			return text + (val / 1024f).ToString("F1") + "GB";
		}
		return text + (val / 1024f / 1024f).ToString("F1") + "TB";
	}

	public static string ByteSize(this uint val)
	{
		if (val < 1024)
		{
			return val + "B";
		}
		double num = (double)val / 1024.0;
		if (num < 1024.0)
		{
			return num.ToString("F1") + "KB";
		}
		num /= 1024.0;
		if (num < 1024.0)
		{
			return num.ToString("F1") + "MB";
		}
		num /= 1024.0;
		if (num < 1024.0)
		{
			return num.ToString("F1") + "GB";
		}
		return (num / 1024.0).ToString("F1") + "TB";
	}

	public static int ChancePerInGameMinute(float chance, float delta)
	{
		float num = delta * GameSettings.GameSpeed;
		if (chance > 1f)
		{
			if (num * chance > RandomValue)
			{
				return Mathf.CeilToInt(num * chance * RandomValue);
			}
		}
		else if (num * chance > RandomValue)
		{
			return 1;
		}
		return 0;
	}

	public static float BandwidthFactor(this float bandwidth, SDateTime time)
	{
		float num = (float)time.ToInt() / 12f / (float)GameSettings.DaysPerMonth / 24f / 60f;
		return bandwidth * (0.75f + Mathf.Log10(num - 69f));
	}

	public static IEnumerable<T> RandomOffset<T>(this List<T> input)
	{
		int offset = RandomRange(0, input.Count);
		for (int i = 0; i < input.Count; i++)
		{
			yield return input[(i + offset) % input.Count];
		}
	}

	public static IEnumerable<T> Offset<T>(this List<T> input, int offset)
	{
		for (int i = 0; i < input.Count; i++)
		{
			yield return input[(i + offset) % input.Count];
		}
	}

	public static float GetHypeFactor(float devtime, float premarketing, float rep, float price, SDateTime releaseDate, SDateTime time)
	{
		float months = SDateTime.GetMonths(time, releaseDate);
		if (months > devtime)
		{
			return 0f;
		}
		float num = ((!(months < 0f)) ? (1f - months / devtime) : (1f / Mathf.Max(1f, -2f * months)));
		float num2 = ((price < 1f) ? devtime : (devtime / price));
		return Mathf.Clamp01(0f - Mathf.Sqrt(Mathf.Abs(num - 1f)) + 1f) * premarketing * rep * num2;
	}

	public static float Diameter(this Rect r)
	{
		return Mathf.Sqrt(r.width * r.width + r.height * r.height);
	}

	public static T[] ReplaceValue<T>(this T[] arr, int i, T value)
	{
		arr[i] = value;
		return arr;
	}

	public static float? AverageOutlier<T>(this List<T> input, Func<T, float> conv, float rejection)
	{
		if (input.Count == 0)
		{
			return 0f;
		}
		List<float> list = new List<float>(input.Count);
		float num = 0f;
		int num2 = 0;
		for (int i = 0; i < input.Count; i++)
		{
			float num3 = conv(input[i]);
			list.Add(num3);
			num += num3;
			num2++;
		}
		if (num == 0f)
		{
			return 0f;
		}
		num /= (float)num2;
		float num4 = 0f;
		num2 = 0;
		for (int j = 0; j < list.Count; j++)
		{
			if (Mathf.Abs(list[j] - num) / num < rejection)
			{
				num4 += list[j];
				num2++;
			}
		}
		if (num2 == 0)
		{
			return null;
		}
		return num4 / (float)num2;
	}

	public static float Median(this IList<float> list)
	{
		if (list.Count == 0)
		{
			return 0f;
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		if (list.Count == 2)
		{
			return (list[0] + list[1]) / 2f;
		}
		int num = 0;
		float num2 = 0f;
		int num3 = list.Count / 2;
		bool flag = list.Count % 2 != 0;
		foreach (float item in list.OrderBy((float x) => x))
		{
			if (!flag && num == num3 - 1)
			{
				num2 = item;
			}
			else if (num == num3)
			{
				num2 = ((!flag) ? item : ((item + num2) / 2f));
				break;
			}
			num++;
		}
		return num2;
	}

	public static double Median<T>(this IList<T> list, Func<T, double> conv)
	{
		if (list.Count == 0)
		{
			return 0.0;
		}
		if (list.Count == 1)
		{
			return conv(list[0]);
		}
		if (list.Count == 2)
		{
			return (conv(list[0]) + conv(list[1])) / 2.0;
		}
		int num = 0;
		double num2 = 0.0;
		int num3 = list.Count / 2;
		bool flag = list.Count % 2 != 0;
		foreach (double item in from x in list.Select(conv)
			orderby x
			select x)
		{
			if (double.IsNaN(item))
			{
				num3--;
				continue;
			}
			if (!flag && num == num3 - 1)
			{
				num2 = item;
			}
			else if (num == num3)
			{
				num2 = ((!flag) ? ((item + num2) / 2.0) : item);
				break;
			}
			num++;
		}
		return num2;
	}

	public static float MedianNonThreaded<T>(this IList<T> list, Func<T, float> conv)
	{
		List<float> list2 = _medianList;
		List<float> list3 = _medianList2;
		list2.Clear();
		for (int i = 0; i < list.Count; i++)
		{
			T arg = list[i];
			list2.Add(conv(arg));
		}
		if (list2.Count == 0)
		{
			return 0f;
		}
		if (list2.Count == 2)
		{
			return (list2[0] + list2[1]) * 0.5f;
		}
		int want = list2.Count / 2;
		while (list2.Count > 2)
		{
			list3.Clear();
			MedianStep(list2, list3, ref want);
			List<float> list4 = list3;
			list3 = list2;
			list2 = list4;
		}
		if (list2.Count == 1)
		{
			return list2[0];
		}
		float num = list2[0];
		for (int j = 0; j < list2.Count; j++)
		{
			num = Mathf.Min(num, list2[j]);
		}
		return num;
	}

	private static void MedianStep(List<float> use, List<float> keep, ref int want)
	{
		int index = UnityEngine.Random.Range(0, use.Count);
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < use.Count; i++)
		{
			if (use[i] == use[index])
			{
				keep.Insert(num, use[i]);
				num2++;
			}
			else if (use[i] <= use[index])
			{
				keep.Insert(0, use[i]);
				num++;
			}
			else
			{
				keep.Add(use[i]);
			}
		}
		if (want < num)
		{
			keep.RemoveRange(num, keep.Count - num);
		}
		else if (want < num + num2)
		{
			keep.Clear();
			keep.Add(use[index]);
		}
		else
		{
			want -= num + num2;
			keep.RemoveRange(0, num + num2);
		}
	}

	public static List<T> OrderByDependency<T>(this IEnumerable<T> list, Func<T, T[]> dependencies, Func<T, bool> first)
	{
		Dictionary<T, T[]> dictionary = list.ToDictionary((T x) => x, dependencies);
		List<T> list2 = new List<T>();
		T val = dictionary.Keys.First(first);
		list2.Add(val);
		dictionary.Remove(val);
		foreach (KeyValuePair<T, T[]> item in dictionary.Where((KeyValuePair<T, T[]> x) => x.Value.Length == 0).ToList())
		{
			list2.Add(item.Key);
			dictionary.Remove(item.Key);
		}
		while (dictionary.Count > 0)
		{
			foreach (KeyValuePair<T, T[]> item2 in dictionary.ToList())
			{
				for (int num = 0; num < item2.Value.Length; num++)
				{
					int num2 = list2.IndexOf(item2.Value[num]);
					if (num2 > -1)
					{
						list2.Insert(num2 + 1, item2.Key);
						dictionary.Remove(item2.Key);
						break;
					}
				}
			}
		}
		return list2;
	}

	public static Vector2 FlattenVector3(this Vector3 v)
	{
		return new Vector2(v.x, v.z);
	}

	public static Vector2 ToVector2(this Vector3 v)
	{
		return new Vector2(v.x, v.y);
	}

	public static Vector3 FlattenVector4(this Vector4 v)
	{
		return new Vector3(v.x, v.y, v.z);
	}

	public static Vector2 FlattenVector4XZ(this Vector4 v)
	{
		return new Vector2(v.x, v.z);
	}

	public static Vector3 ReplaceY(this Vector3 v, float y)
	{
		return new Vector3(v.x, y, v.z);
	}

	public static Vector3 ReplaceX(this Vector3 v, float x)
	{
		return new Vector3(x, v.y, v.z);
	}

	public static Vector3 ToVector3(this Vector2 v, float y)
	{
		return new Vector3(v.x, y, v.y);
	}

	public static Vector4 ToVector4(this Vector2 v, float y, float w = 0f)
	{
		return new Vector4(v.x, y, v.y, w);
	}

	public static Vector4 ToVector4(this Vector3 v, float w)
	{
		return new Vector4(v.x, v.y, v.z, w);
	}

	public static Quaternion Invert(this Quaternion q)
	{
		return Quaternion.Inverse(q);
	}

	public static T GetLastOrDefault<T>(this List<T> l, T def)
	{
		if (l.Count != 0)
		{
			return l[l.Count - 1];
		}
		return def;
	}

	public static void ReverseListPart<T>(this T[] list, int from, int to)
	{
		int num = from + (to - from) / 2;
		for (int i = from; i < num; i++)
		{
			int num2 = to - (i - from) - 1;
			T val = list[i];
			list[i] = list[num2];
			list[num2] = val;
		}
	}

	public static Vector2 GetOffset(int i, IList<Vector2> l, float offset, bool angleOffset = false)
	{
		return GetOffset((i == 0) ? l[l.Count - 1] : l[i - 1], third: l[(i + 1) % l.Count], second: l[i], offset: offset, angleOffset: angleOffset);
	}

	public static Vector2 GetOffset(Vector2 first, Vector2 second, Vector2 third, float offset, bool angleOffset = false)
	{
		if (Alike(first, second, third, 0.0001f))
		{
			Vector2 vector = (third - second).normalized * offset;
			return second + new Vector2(0f - vector.y, vector.x);
		}
		float num = Mathf.Atan2(first.y - second.y, first.x - second.x) * 57.29578f;
		float num2 = Mathf.Atan2(third.y - second.y, third.x - second.x) * 57.29578f;
		float num3 = Mathf.LerpAngle(num, num2, 0.5f);
		float num4 = 1f;
		if (angleOffset)
		{
			num4 = Mathf.DeltaAngle(num, num2);
			num4 = Mathf.Abs(Mathf.Sin(num4 * ((float)Math.PI / 180f) / 2f));
		}
		num3 *= (float)Math.PI / 180f;
		Vector2 vector2 = new Vector2(Mathf.Cos(num3), Mathf.Sin(num3)) * (offset / num4);
		float num5 = (second.y - first.y) * (third.x - second.x) - (second.x - first.x) * (third.y - second.y);
		if (!Mathf.Approximately(num5, 0f) && num5 < 0f)
		{
			vector2 = -vector2;
		}
		return second - vector2;
	}

	public static bool ConvertToBool(this string input, string variableName)
	{
		try
		{
			return Convert.ToBoolean(input);
		}
		catch (Exception)
		{
			throw new Exception("Failed converting " + variableName + " to boolean");
		}
	}

	public static int ConvertToInt(this string input, string variableName)
	{
		try
		{
			return Convert.ToInt32(input);
		}
		catch (Exception)
		{
			throw new Exception("Failed converting " + variableName + " to integer");
		}
	}

	public static float ConvertToFloat(this string input, string variableName)
	{
		try
		{
			return (float)Convert.ToDouble(input);
		}
		catch (Exception)
		{
			throw new Exception("Failed converting " + variableName + " to float");
		}
	}

	public static bool ConvertToBoolDef(this string input, bool defaultValue)
	{
		try
		{
			return Convert.ToBoolean(input);
		}
		catch (Exception)
		{
			return defaultValue;
		}
	}

	public static int ConvertToIntDef(this string input, int defaultValue)
	{
		try
		{
			return Convert.ToInt32(input);
		}
		catch (Exception)
		{
			return defaultValue;
		}
	}

	public static uint ConvertToUIntDef(this string input, uint defaultValue)
	{
		try
		{
			return Convert.ToUInt32(input);
		}
		catch (Exception)
		{
			return defaultValue;
		}
	}

	public static float ConvertToFloatDef(this string input, float defaultValue)
	{
		try
		{
			return (float)Convert.ToDouble(input);
		}
		catch (Exception)
		{
			return defaultValue;
		}
	}

	public static double ConvertToDoubleDef(this string input, double defaultValue)
	{
		try
		{
			return Convert.ToDouble(input);
		}
		catch (Exception)
		{
			return defaultValue;
		}
	}

	public static bool ConvertToFloatTry(this string input, out float output, float defaultValue = 0f)
	{
		try
		{
			output = (float)Convert.ToDouble(input);
			return true;
		}
		catch (Exception)
		{
			output = defaultValue;
			return false;
		}
	}

	public static bool TryConvertToType(this string input, Type type, out object result)
	{
		try
		{
			if (type == typeof(Resolution))
			{
				string[] array = input.Split('x');
				result = ((array.Length > 2) ? new Resolution
				{
					width = array[0].ConvertToIntDef(1024),
					height = array[1].ConvertToIntDef(768),
					refreshRate = array[2].ConvertToIntDef(60)
				} : Options.FindRes(1024, 768, 60));
				return true;
			}
			if (type == typeof(ValueTuple<int, int>))
			{
				string[] array2 = input.Split('x');
				if (array2.Length > 1)
				{
					result = new ValueTuple<int, int>(array2[0].ConvertToIntDef(1024), array2[1].ConvertToIntDef(768));
				}
				else
				{
					result = new ValueTuple<int, int>(1024, 768);
				}
				return true;
			}
			result = TypeDescriptor.GetConverter(type).ConvertFrom(input);
			return true;
		}
		catch (Exception)
		{
			result = null;
			return false;
		}
	}

	public static bool VeryStrictlyBelow(this float x, float y)
	{
		if (!x.Appx(y, 0.00015f))
		{
			return x < y;
		}
		return false;
	}

	public static Vector2 ClosestPointOnTriangle(Vector2[] triangle, Vector2 point, float offset)
	{
		return ClosestPointOnTriangle(GetOffset(triangle[2], triangle[0], triangle[1], offset), GetOffset(triangle[0], triangle[1], triangle[2], offset), GetOffset(triangle[1], triangle[2], triangle[0], offset), point);
	}

	public static Vector2 ClosestPointOnTriangle(Vector2[] triangle, Vector2 point)
	{
		return ClosestPointOnTriangle(triangle[0], triangle[1], triangle[2], point);
	}

	public static Vector2 ClosestPointOnTriangle(Vector2 tr0, Vector2 tr1, Vector2 tr2, Vector2 point)
	{
		float num = tr1.x - tr0.x;
		float num2 = tr1.y - tr0.y;
		float num3 = tr2.x - tr0.x;
		float num4 = tr2.y - tr0.y;
		float num5 = num * num + num2 * num2;
		float num6 = num * num3 + num2 * num4;
		float num7 = num3 * num3 + num4 * num4;
		float num8 = num5 * num7 - num6 * num6;
		if (num8 <= Mathf.Epsilon)
		{
			if (num5 <= Mathf.Epsilon && num7 <= Mathf.Epsilon)
			{
				return tr0;
			}
			Vector2 vector;
			Vector2 vector2;
			if (num5 >= num7)
			{
				vector = tr0;
				vector2 = tr1;
			}
			else
			{
				vector = tr0;
				vector2 = tr2;
			}
			Vector2 vector3 = vector2 - vector;
			float num9 = ((point.x - vector.x) * vector3.x + (point.y - vector.y) * vector3.y) / (vector3.x * vector3.x + vector3.y * vector3.y);
			num9 = ((num9 < 0f) ? 0f : ((num9 > 1f) ? 1f : num9));
			return new Vector2(vector.x + num9 * vector3.x, vector.y + num9 * vector3.y);
		}
		float num10 = tr0.x - point.x;
		float num11 = tr0.y - point.y;
		float num12 = num10 * num + num11 * num2;
		float num13 = num10 * num3 + num11 * num4;
		float num14 = num6 * num13 - num7 * num12;
		float num15 = num6 * num12 - num5 * num13;
		if (num14 + num15 <= num8)
		{
			if (num14 < 0f)
			{
				if (num15 < 0f)
				{
					if (num12 < 0f)
					{
						num15 = 0f;
						num14 = ((!(0f - num12 >= num5)) ? ((0f - num12) / num5) : 1f);
					}
					else
					{
						num14 = 0f;
						num15 = ((num13 >= 0f) ? 0f : ((!(0f - num13 >= num7)) ? ((0f - num13) / num7) : 1f));
					}
				}
				else
				{
					num14 = 0f;
					num15 = ((num13 >= 0f) ? 0f : ((!(0f - num13 >= num7)) ? ((0f - num13) / num7) : 1f));
				}
			}
			else if (num15 < 0f)
			{
				num15 = 0f;
				num14 = ((num12 >= 0f) ? 0f : ((!(0f - num12 >= num5)) ? ((0f - num12) / num5) : 1f));
			}
			else
			{
				float num16 = 1f / num8;
				num14 *= num16;
				num15 *= num16;
			}
		}
		else if (num14 < 0f)
		{
			float num17 = num6 + num12;
			float num18 = num7 + num13;
			if (num18 > num17)
			{
				float num19 = num18 - num17;
				float num20 = num5 - 2f * num6 + num7;
				if (num19 >= num20)
				{
					num14 = 1f;
					num15 = 0f;
				}
				else
				{
					num14 = num19 / num20;
					num15 = 1f - num14;
				}
			}
			else
			{
				num14 = 0f;
				num15 = ((num18 <= 0f) ? 1f : ((!(num13 >= 0f)) ? ((0f - num13) / num7) : 0f));
			}
		}
		else if (num15 < 0f)
		{
			float num17 = num6 + num13;
			float num18 = num5 + num12;
			if (num18 > num17)
			{
				float num19 = num18 - num17;
				float num20 = num5 - 2f * num6 + num7;
				if (num19 >= num20)
				{
					num15 = 1f;
					num14 = 0f;
				}
				else
				{
					num15 = num19 / num20;
					num14 = 1f - num15;
				}
			}
			else
			{
				num15 = 0f;
				num14 = ((num18 <= 0f) ? 1f : ((!(num12 >= 0f)) ? ((0f - num12) / num5) : 0f));
			}
		}
		else
		{
			float num19 = num7 + num13 - num6 - num12;
			if (num19 <= 0f)
			{
				num14 = 0f;
				num15 = 1f;
			}
			else
			{
				float num20 = num5 - 2f * num6 + num7;
				if (num19 >= num20)
				{
					num14 = 1f;
					num15 = 0f;
				}
				else
				{
					num14 = num19 / num20;
					num15 = 1f - num14;
				}
			}
		}
		return new Vector2(tr0.x + num14 * num + num15 * num3, tr0.y + num14 * num2 + num15 * num4);
	}

	public static void ForEachEnum<T>(this IEnumerable<T> items, Action<T> action)
	{
		foreach (T item in items)
		{
			action(item);
		}
	}

	public static void ForEachEnum<T>(this IList<T> items, Action<T> action)
	{
		for (int i = 0; i < items.Count; i++)
		{
			action(items[i]);
		}
	}

	public static Mesh Duplicate(this Mesh m)
	{
		return new Mesh
		{
			vertices = m.vertices,
			normals = m.normals,
			uv = m.uv,
			uv2 = m.uv2,
			tangents = m.tangents,
			colors = m.colors,
			triangles = m.triangles
		};
	}

	public static float ManhattanDist(this Vector3 v1, Vector3 v2)
	{
		return Mathf.Abs(v1.x - v2.x) + Mathf.Abs(v1.z - v2.z);
	}

	public static float ManhattanDist3D(this Vector3 v1, Vector3 v2)
	{
		return Mathf.Abs(v1.x - v2.x) + Mathf.Abs(v1.y - v2.y) + Mathf.Abs(v1.z - v2.z);
	}

	public static float ManhattanDist(this Vector2 v1, Vector2 v2)
	{
		return Mathf.Abs(v1.x - v2.x) + Mathf.Abs(v1.y - v2.y);
	}

	public static float MinDist(this Vector2 v1, Vector2 v2)
	{
		return Mathf.Min(Mathf.Abs(v1.x - v2.x), Mathf.Abs(v1.y - v2.y));
	}

	public static float MinDist(this Vector3 v1, Vector3 v2)
	{
		return Mathf.Min(Mathf.Abs(v1.x - v2.x), Mathf.Abs(v1.y - v2.y), Mathf.Abs(v1.z - v2.z));
	}

	public static float MinDist(this Vector2 v)
	{
		return Mathf.Min(Mathf.Abs(v.x), Mathf.Abs(v.y));
	}

	public static float MaxDist(this Vector2 v1, Vector2 v2)
	{
		return Mathf.Max(Mathf.Abs(v1.x - v2.x), Mathf.Abs(v1.y - v2.y));
	}

	public static float MaxDist(this Vector2 v)
	{
		return Mathf.Max(Mathf.Abs(v.x), Mathf.Abs(v.y));
	}

	public static float MaxDist(this Vector3 v1, Vector3 v2)
	{
		return Mathf.Max(Mathf.Abs(v1.x - v2.x), Mathf.Abs(v1.y - v2.y), Mathf.Abs(v1.z - v2.z));
	}

	public static Rect GetBounds(params Vector2[] list)
	{
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MinValue;
		for (int i = 0; i < list.Length; i++)
		{
			Vector2 vector = list[i];
			num = Mathf.Min(num, vector.x);
			num2 = Mathf.Min(num2, vector.y);
			num3 = Mathf.Max(num3, vector.x);
			num4 = Mathf.Max(num4, vector.y);
		}
		return new Rect(num, num2, num3 - num, num4 - num2);
	}

	public static Rect GetBounds(this IList<Vector2> list)
	{
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MinValue;
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			Vector2 vector = list[i];
			num = Mathf.Min(num, vector.x);
			num2 = Mathf.Min(num2, vector.y);
			num3 = Mathf.Max(num3, vector.x);
			num4 = Mathf.Max(num4, vector.y);
		}
		return new Rect(num, num2, num3 - num, num4 - num2);
	}

	public static Rect GetBounds(this IEnumerable<Vector2> list)
	{
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MinValue;
		foreach (Vector2 item in list)
		{
			num = Mathf.Min(num, item.x);
			num2 = Mathf.Min(num2, item.y);
			num3 = Mathf.Max(num3, item.x);
			num4 = Mathf.Max(num4, item.y);
		}
		return new Rect(num, num2, num3 - num, num4 - num2);
	}

	public static Rect GetBounds<T>(this IEnumerable<T> list, Func<T, Vector2> conv)
	{
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		float num3 = float.MinValue;
		float num4 = float.MinValue;
		foreach (T item in list)
		{
			Vector2 vector = conv(item);
			num = Mathf.Min(num, vector.x);
			num2 = Mathf.Min(num2, vector.y);
			num3 = Mathf.Max(num3, vector.x);
			num4 = Mathf.Max(num4, vector.y);
		}
		return new Rect(num, num2, num3 - num, num4 - num2);
	}

	public static bool InBasement(int floor)
	{
		return floor < 0;
	}

	public static Rect Flatten(this Bounds bound)
	{
		return new Rect(bound.min.x, bound.min.z, bound.size.x, bound.size.z);
	}

	public static Color Alpha(this Color c, float a)
	{
		return new Color(c.r, c.g, c.b, a);
	}

	public static void PushRange<T>(this Stack<T> stack, IEnumerable<T> items)
	{
		foreach (T item in items)
		{
			stack.Push(item);
		}
	}

	public static void SetEnum<T>(this Animator obj, string id, T anim)
	{
		obj.SetInteger(id, (int)(object)anim);
	}

	public static bool IsEnum<T>(this Animator obj, string id, T anim)
	{
		return obj.GetInteger(id) == (int)(object)anim;
	}

	public static byte[] ReadAllBytes(this BinaryReader reader)
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			byte[] array = new byte[4096];
			int count;
			while ((count = reader.Read(array, 0, array.Length)) != 0)
			{
				memoryStream.Write(array, 0, count);
			}
			return memoryStream.ToArray();
		}
	}

	public static bool Append<T1, T2>(this Dictionary<T1, List<T2>> dict, T1 key, T2 element)
	{
		bool result = false;
		List<T2> value;
		if (!dict.TryGetValue(key, out value))
		{
			value = (dict[key] = new List<T2>());
			result = true;
		}
		value.Add(element);
		return result;
	}

	public static void Append<T1, T2>(this Dictionary<T1, List<T2>> dict, T1 key, T2 element, ReaderWriterLockSlim lo)
	{
		bool num = lo.TryEnterReadLock(-1);
		List<T2> value;
		bool flag = dict.TryGetValue(key, out value);
		if (num)
		{
			lo.ExitReadLock();
		}
		if (!flag)
		{
			value = new List<T2> { element };
			lo.EnterWriteLock();
			dict[key] = value;
			lo.ExitWriteLock();
			return;
		}
		lock (value)
		{
			value.Add(element);
		}
	}

	public static bool Append<T1, T2>(this Dictionary<T1, HashSet<T2>> dict, T1 key, T2 element)
	{
		HashSet<T2> value;
		if (!dict.TryGetValue(key, out value))
		{
			value = (dict[key] = new HashSet<T2>());
		}
		return value.Add(element);
	}

	public static void Append<T1, T2>(this Dictionary<T1, SHashSet<T2>> dict, T1 key, T2 element)
	{
		SHashSet<T2> value;
		if (!dict.TryGetValue(key, out value))
		{
			value = (dict[key] = new SHashSet<T2>());
		}
		value.Add(element);
	}

	public static void Append<T1, T2>(this Dictionary<T1, HashList<T2>> dict, T1 key, T2 element)
	{
		HashList<T2> value;
		if (!dict.TryGetValue(key, out value))
		{
			value = (dict[key] = new HashList<T2>());
		}
		value.Add(element);
	}

	public static Dictionary<T2, T3> Append<T1, T2, T3>(this Dictionary<T1, Dictionary<T2, T3>> dict, T1 key)
	{
		Dictionary<T2, T3> value;
		if (!dict.TryGetValue(key, out value))
		{
			value = (dict[key] = new Dictionary<T2, T3>());
		}
		return value;
	}

	public static void AddUp<T>(this Dictionary<T, float> dict, T key, float value)
	{
		float value2;
		if (dict.TryGetValue(key, out value2))
		{
			dict[key] = value2 + value;
		}
		else
		{
			dict[key] = value;
		}
	}

	public static void AddUp<T>(this Dictionary<T, double> dict, T key, double value)
	{
		double value2;
		if (dict.TryGetValue(key, out value2))
		{
			dict[key] = value2 + value;
		}
		else
		{
			dict[key] = value;
		}
	}

	public static void AddUp<T>(this Dictionary<T, float[]> dict, T key, float[] value)
	{
		float[] value2;
		if (dict.TryGetValue(key, out value2))
		{
			value2.AddArray(value);
		}
		else
		{
			dict[key] = value.ToArray();
		}
	}

	public static void AddUp<T>(this Dictionary<T, double[]> dict, T key, double[] value)
	{
		double[] value2;
		if (dict.TryGetValue(key, out value2))
		{
			value2.AddArray(value);
		}
		else
		{
			dict[key] = value.ToArray();
		}
	}

	public static void AddTo<T1, T2>(this Dictionary<T1, T2> dict, T1 key, T2 value, Func<T2, T2, T2> change)
	{
		T2 value2;
		if (dict.TryGetValue(key, out value2))
		{
			dict[key] = change(value2, value);
		}
		else
		{
			dict[key] = value;
		}
	}

	public static void AddTo<T1, T2>(this Dictionary<T1, T2[]> dict, T1 key, T2[] value, Func<T2, T2, T2> change)
	{
		T2[] value2;
		if (dict.TryGetValue(key, out value2))
		{
			for (int i = 0; i < value2.Length; i++)
			{
				value2[i] = change(value2[i], value[i]);
			}
		}
		else
		{
			dict[key] = value.ToArray();
		}
	}

	public static bool AddUp<T>(this Dictionary<T, uint> dict, T key, uint value)
	{
		uint value2;
		if (dict.TryGetValue(key, out value2))
		{
			dict[key] = value2 + value;
			return false;
		}
		dict[key] = value;
		return true;
	}

	public static void AddUp<T>(this Dictionary<T, int> dict, T key, int value = 1)
	{
		int value2;
		if (dict.TryGetValue(key, out value2))
		{
			dict[key] = value2 + value;
		}
		else
		{
			dict[key] = value;
		}
	}

	public static int Quantize(this float score, int buckets)
	{
		return Mathf.Clamp(Mathf.FloorToInt(score * (float)buckets), 0, buckets - 1);
	}

	public static bool Any<T>(this IList<T> l, Func<T, bool> predicate)
	{
		for (int i = 0; i < l.Count; i++)
		{
			if (predicate(l[i]))
			{
				return true;
			}
		}
		return false;
	}

	public static int Count<T>(this IList<T> l, Func<T, bool> predicate)
	{
		int num = 0;
		for (int i = 0; i < l.Count; i++)
		{
			if (predicate(l[i]))
			{
				num++;
			}
		}
		return num;
	}

	public static void CopyTo(this Stream source, Stream destination, int bufferSize = 81920)
	{
		byte[] array = new byte[bufferSize];
		int count;
		while ((count = source.Read(array, 0, array.Length)) != 0)
		{
			destination.Write(array, 0, count);
		}
	}

	public static byte[] Compress(this byte[] input)
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, false))
			{
				gZipStream.Write(input, 0, input.Length);
			}
			return memoryStream.ToArray();
		}
	}

	public static byte[] Decompress(this byte[] input)
	{
		using (MemoryStream stream = new MemoryStream(input))
		{
			using (GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress, false))
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					gZipStream.CopyTo(memoryStream, 16384);
					return memoryStream.ToArray();
				}
			}
		}
	}

	public static float SpreadPercentage(this float p, int spread)
	{
		if (spread == 1 || Mathf.Approximately(p, 1f))
		{
			return p;
		}
		if (p < 0.65f || p > 1.32f)
		{
			return Mathf.Pow(p, 1f / (float)spread);
		}
		return 1f + (p - 1f) / (float)spread;
	}

	public static double SpreadPercentage(this double p, int spread)
	{
		if (spread == 1 || Math.Abs(p - 1.0) < 1E-05)
		{
			return p;
		}
		if (p < 0.65 || p > 1.32)
		{
			return Math.Pow(p, 1.0 / (double)spread);
		}
		return 1.0 + (p - 1.0) / (double)spread;
	}

	public static float SpreadChance(this float p, int spread)
	{
		if (spread == 1 || Mathf.Approximately(p, 1f))
		{
			return p;
		}
		if (p < 0.25f)
		{
			return p / (float)spread;
		}
		return 1f - Mathf.Pow(10f, Mathf.Log10(1f - p) / (float)spread);
	}

	public static int Sum(this int[] list)
	{
		int num = 0;
		for (int i = 0; i < list.Length; i++)
		{
			num += list[i];
		}
		return num;
	}

	public static float Min<T>(this IList<T> list, Func<T, float> selector, float defaultVal = 0f)
	{
		if (list == null || list.Count == 0)
		{
			return defaultVal;
		}
		float num = float.MaxValue;
		for (int i = 0; i < list.Count; i++)
		{
			num = Mathf.Min(num, selector(list[i]));
		}
		return num;
	}

	public static int Min<T>(this IList<T> list, Func<T, int> selector, int defaultVal = 0)
	{
		if (list == null || list.Count == 0)
		{
			return defaultVal;
		}
		int num = int.MaxValue;
		for (int i = 0; i < list.Count; i++)
		{
			num = Mathf.Min(num, selector(list[i]));
		}
		return num;
	}

	public static uint Min<T>(this IList<T> list, Func<T, uint> selector)
	{
		if (list == null || list.Count == 0)
		{
			return 0u;
		}
		uint num = uint.MaxValue;
		for (int i = 0; i < list.Count; i++)
		{
			num = Math.Min(num, selector(list[i]));
		}
		return num;
	}

	public static float Max<T>(this IList<T> list, Func<T, float> selector, float defaultVal = 0f)
	{
		if (list == null || list.Count == 0)
		{
			return defaultVal;
		}
		float num = float.MinValue;
		for (int i = 0; i < list.Count; i++)
		{
			num = Mathf.Max(num, selector(list[i]));
		}
		return num;
	}

	public static int Max<T>(this IList<T> list, Func<T, int> selector, int defaultVal = 0)
	{
		if (list == null || list.Count == 0)
		{
			return defaultVal;
		}
		int num = int.MinValue;
		for (int i = 0; i < list.Count; i++)
		{
			num = Mathf.Max(num, selector(list[i]));
		}
		return num;
	}

	public static uint Max<T>(this IList<T> list, Func<T, uint> selector)
	{
		if (list == null || list.Count == 0)
		{
			return 0u;
		}
		uint num = 0u;
		for (int i = 0; i < list.Count; i++)
		{
			num = Math.Max(num, selector(list[i]));
		}
		return num;
	}

	public static int CountLetter(this string input, char c)
	{
		int num = 0;
		for (int i = 0; i < input.Length; i++)
		{
			if (input[i] == c)
			{
				num++;
			}
		}
		return num;
	}

	public static bool IsValidFloat(this float v)
	{
		if (!float.IsInfinity(v))
		{
			return !float.IsNaN(v);
		}
		return false;
	}

	public static bool IsValidDouble(this double v)
	{
		if (!double.IsInfinity(v))
		{
			return !double.IsNaN(v);
		}
		return false;
	}

	public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
	{
		TValue value;
		if (!dict.TryGetValue(key, out value))
		{
			return defaultValue;
		}
		return value;
	}

	public static TResult GetOrDefault<TKey, TValue, TResult>(this IDictionary<TKey, TValue> dict, TKey key, Func<TValue, TResult> conv, TResult defaultValue = default(TResult))
	{
		TValue value;
		if (!dict.TryGetValue(key, out value))
		{
			return defaultValue;
		}
		return conv(value);
	}

	public static TValue GetOrNull<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key) where TValue : class
	{
		TValue value;
		if (!dict.TryGetValue(key, out value))
		{
			return null;
		}
		return value;
	}

	public static TValue? GetOrNullable<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key) where TValue : struct
	{
		TValue value;
		if (!dict.TryGetValue(key, out value))
		{
			return null;
		}
		return value;
	}

	public static TSource LastOrDefault<TSource>(this IList<TSource> source)
	{
		if (source != null && source.Count != 0)
		{
			return source[source.Count - 1];
		}
		return default(TSource);
	}

	public static TSource LastOrDefault<TSource>(this IList<TSource> source, Func<TSource, bool> check)
	{
		if (source == null || source.Count == 0)
		{
			return default(TSource);
		}
		for (int num = source.Count - 1; num >= 0; num--)
		{
			if (check(source[num]))
			{
				return source[num];
			}
		}
		return default(TSource);
	}

	public static IEnumerable<TOut> SelectNotNull<T, TOut>(this IEnumerable<T> input, Func<T, TOut> selector)
	{
		foreach (T item in input)
		{
			TOut val = selector(item);
			if (val != null)
			{
				yield return val;
			}
		}
	}

	public static IEnumerable<TOut> SelectNotNull<T, TOut>(this IList<T> input, Func<T, TOut> selector)
	{
		for (int j = 0; j < input.Count; j++)
		{
			T arg = input[j];
			TOut val = selector(arg);
			if (val != null)
			{
				yield return val;
			}
		}
	}

	public static IEnumerable<TOut> SelectNotNullable<T, TOut>(this IList<T> input, Func<T, TOut?> selector) where TOut : struct
	{
		for (int j = 0; j < input.Count; j++)
		{
			T arg = input[j];
			TOut? val = selector(arg);
			if (val.HasValue)
			{
				yield return val.Value;
			}
		}
	}

	public static IEnumerable<TOut> NotNullSelect<T, TOut>(this IList<T> input, Func<T, TOut> selector)
	{
		for (int j = 0; j < input.Count; j++)
		{
			T val = input[j];
			if (val != null)
			{
				yield return selector(val);
			}
		}
	}

	public static Dictionary<TKey, TValue> DictionaryNotNull<TIn, TKey, TValue>(this IEnumerable<TIn> input, Func<TIn, TKey> key, Func<TIn, TValue> value)
	{
		Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
		foreach (TIn item in input)
		{
			TValue val = value(item);
			if (val != null)
			{
				TKey key2 = key(item);
				dictionary[key2] = val;
			}
		}
		return dictionary;
	}

	public static float WeightOne(this float number, float weight)
	{
		return 1f - weight + weight * number;
	}

	public static double WeightOne(this double number, double weight)
	{
		return 1.0 - weight + weight * number;
	}

	public static void Swap<T>(this HashSet<T> set, T f, T s)
	{
		if (set.Remove(f))
		{
			set.Add(s);
		}
	}

	public static string ToDB(this float num)
	{
		return (10f + Mathf.Sqrt(num) * 60f).ToString("F0") + " Db";
	}

	public static void AddOrReplace<T>(this List<T> l, int index, T value)
	{
		if (index < l.Count)
		{
			l[index] = value;
		}
		else
		{
			l.Add(value);
		}
	}

	public static float GetMarketingEffort(float retention)
	{
		return 14f * Mathf.Log(retention / 8f + 1.2f) - 3.3f;
	}

	public static string Format(this string format, params object[] args)
	{
		return RobustStringFormat(format, false, false, args);
	}

	public static string FormatColor(this string format, params object[] args)
	{
		return RobustStringFormat(format, true, false, args);
	}

	public static string ToPercent(this double value, bool includeDecimal = true, bool includeSign = false)
	{
		string text = (includeDecimal ? ((value * 100.0).ToString("0.#") + "%") : ((value * 100.0).ToString("F0") + "%"));
		if (includeSign && value > 0.0)
		{
			text = "+" + text;
		}
		return text;
	}

	public static string ToPercent(this float value, bool includeDecimal = true, bool includeSign = false)
	{
		return ((double)value).ToPercent(includeDecimal, includeSign);
	}

	public static string GetRoot()
	{
		if (_rootCache == null)
		{
			_rootCache = Path.GetDirectoryName(Application.dataPath);
		}
		return _rootCache;
	}

	public static string CleanFileName(string filename)
	{
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
		StringBuilder stringBuilder = new StringBuilder(filename);
		for (int num = stringBuilder.Length - 1; num >= 0; num--)
		{
			for (int i = 0; i < invalidFileNameChars.Length; i++)
			{
				if (stringBuilder[num] == invalidFileNameChars[i])
				{
					stringBuilder.Remove(num, 1);
					break;
				}
			}
		}
		return stringBuilder.ToString();
	}

	public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (predicate == null)
		{
			throw new ArgumentNullException("predicate");
		}
		foreach (TSource item in source)
		{
			if (predicate(item))
			{
				return false;
			}
		}
		return true;
	}

	public static bool None<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (predicate == null)
		{
			throw new ArgumentNullException("predicate");
		}
		for (int i = 0; i < source.Count; i++)
		{
			if (predicate(source[i]))
			{
				return false;
			}
		}
		return true;
	}

	public static bool All<TSource>(this IList<TSource> source, Func<TSource, bool> predicate)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (predicate == null)
		{
			throw new ArgumentNullException("predicate");
		}
		for (int i = 0; i < source.Count; i++)
		{
			if (!predicate(source[i]))
			{
				return false;
			}
		}
		return true;
	}

	public static string YesNo(this bool b)
	{
		if (!b)
		{
			return "No".Loc();
		}
		return "Yes".Loc();
	}

	public static PointerEventData PopulateDefault(this PointerEventData pd)
	{
		pd.pointerId = -1;
		pd.position = Input.mousePosition;
		return pd;
	}

	public static bool IsReferenceNull(this UnityEngine.Object obj)
	{
		return (object)obj == null;
	}

	public static T[] AppendSelfArray<T>(this IList<T> list)
	{
		T[] array = new T[list.Count * 2];
		for (int i = 0; i < list.Count; i++)
		{
			array[i] = list[i];
			array[i + list.Count] = list[i];
		}
		return array;
	}

	public static T[] AppendSelfArray<T>(this IList<T> list, Func<T, T> transform)
	{
		T[] array = new T[list.Count * 2];
		for (int i = 0; i < list.Count; i++)
		{
			array[i] = list[i];
			array[i + list.Count] = transform(list[i]);
		}
		return array;
	}

	public static T2[] AppendSelfArray<T1, T2>(this IList<T1> list, Func<T1, T2> transform1, Func<T1, T2> transform2)
	{
		T2[] array = new T2[list.Count * 2];
		for (int i = 0; i < list.Count; i++)
		{
			array[i] = transform1(list[i]);
			array[i + list.Count] = transform2(list[i]);
		}
		return array;
	}

	public static Vector2[] ToPolygon(this Rect area)
	{
		return new Vector2[4]
		{
			new Vector2(area.xMax, area.yMin),
			new Vector2(area.xMax, area.yMax),
			new Vector2(area.xMin, area.yMax),
			new Vector2(area.xMin, area.yMin)
		};
	}

	public static bool IsBetween(this float x, float a, float b)
	{
		if (a < x)
		{
			return x < b;
		}
		return false;
	}

	public static bool IsBetween(this double x, double a, double b)
	{
		if (a < x)
		{
			return x < b;
		}
		return false;
	}

	public static bool IsBetween(this int x, int a, int b)
	{
		if (a < x)
		{
			return x < b;
		}
		return false;
	}

	public static Vector2 GetRandomTrianglePoint(this IList<Vector2> points)
	{
		float randomValue = RandomValue;
		float randomValue2 = RandomValue;
		float num = Mathf.Sqrt(randomValue);
		return (1f - num) * points[0] + num * (1f - randomValue2) * points[1] + num * randomValue2 * points[2];
	}

	public static T[] RepeatValue<T>(T value, int num)
	{
		T[] array = new T[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = value;
		}
		return array;
	}

	public static T[] RepeatValue<T>(T[] values, int num)
	{
		T[] array = new T[num * values.Length];
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < values.Length; j++)
			{
				array[i * values.Length + j] = values[j];
			}
		}
		return array;
	}

	public static T2[] SelectInPlace<T1, T2>(this IList<T1> arr, Func<T1, T2> select)
	{
		T2[] array = new T2[arr.Count];
		for (int i = 0; i < arr.Count; i++)
		{
			array[i] = select(arr[i]);
		}
		return array;
	}

	public static List<T2> SelectInPlaceList<T1, T2>(this IList<T1> arr, Func<T1, T2> select)
	{
		List<T2> list = new List<T2>(arr.Count);
		for (int i = 0; i < arr.Count; i++)
		{
			list.Add(select(arr[i]));
		}
		return list;
	}

	public static T2[] SelectInPlace<T1, T2>(this IList<T1> arr, Func<T1, int, T2> select)
	{
		T2[] array = new T2[arr.Count];
		for (int i = 0; i < arr.Count; i++)
		{
			array[i] = select(arr[i], i);
		}
		return array;
	}

	public static T2[] SelectInPlace<T1, T2>(this HashSet<T1> arr, Func<T1, T2> select)
	{
		T2[] array = new T2[arr.Count];
		int num = 0;
		foreach (T1 item in arr)
		{
			array[num] = select(item);
			num++;
		}
		return array;
	}

	public static IEnumerable<T2> Select<T1, T2>(this IList<T1> l, Func<T1, T2> conv)
	{
		for (int i = 0; i < l.Count; i++)
		{
			yield return conv(l[i]);
		}
	}

	public static T2 SelectFirstOrDefault<T1, T2>(this IList<T1> l, Func<T1, T2> conv, Func<T2, bool> pred)
	{
		for (int i = 0; i < l.Count; i++)
		{
			T2 val = conv(l[i]);
			if (pred(val))
			{
				return val;
			}
		}
		return default(T2);
	}

	public static float Average<T>(this IList<T> l, Func<T, float> conv)
	{
		if (l.Count == 0)
		{
			return 0f;
		}
		if (l.Count == 1)
		{
			return conv(l[0]);
		}
		float num = 0f;
		for (int i = 0; i < l.Count; i++)
		{
			num += conv(l[i]);
		}
		return num / (float)l.Count;
	}

	public static float Average(this IList<float> l)
	{
		if (l.Count == 0)
		{
			return 0f;
		}
		if (l.Count == 1)
		{
			return l[0];
		}
		float num = 0f;
		for (int i = 0; i < l.Count; i++)
		{
			num += l[i];
		}
		return num / (float)l.Count;
	}

	public static T[] ConcatArray<T>(this T[] arr, T[] arr2)
	{
		T[] array = new T[arr.Length + arr2.Length];
		for (int i = 0; i < arr.Length; i++)
		{
			array[i] = arr[i];
		}
		for (int j = 0; j < arr2.Length; j++)
		{
			array[j + arr.Length] = arr2[j];
		}
		return array;
	}

	public static T[] ReverseArray<T>(this T[] arr)
	{
		Array.Reverse((Array)arr);
		return arr;
	}

	public static Vector3 Inverse(this Vector3 v)
	{
		return new Vector3(1f / v.x, 1f / v.y, 1f / v.z);
	}

	public static void JoinThreads(this IList<Thread> ts)
	{
		for (int i = 0; i < ts.Count; i++)
		{
			ts[i].Join();
		}
	}

	public static IEnumerable<Transform> GetChildren(this Transform t)
	{
		for (int i = 0; i < t.childCount; i++)
		{
			yield return t.GetChild(i);
		}
	}

	public static IEnumerable<Transform> GetChildren(this Scene s)
	{
		GameObject[] rootGameObjects = s.GetRootGameObjects();
		foreach (GameObject item in rootGameObjects.OrderBy((GameObject x) => x.transform.GetSiblingIndex()))
		{
			yield return item.transform;
		}
	}

	public static int TimeToHour(this string input, int defaultValue)
	{
		string text = input.Trim().ToLower();
		if (text.Length > 0 && char.IsDigit(text[0]))
		{
			int num;
			try
			{
				num = ((text.Length <= 1 || !char.IsDigit(text[1])) ? Convert.ToInt32(text.Substring(0, 1)) : Convert.ToInt32(text.Substring(0, 2)));
			}
			catch (Exception)
			{
				return defaultValue;
			}
			if (text.Contains("pm") && num <= 11)
			{
				num += 12;
			}
			if (num == 12 && text.Contains("am"))
			{
				num = 0;
			}
			if (num >= 0 && num <= 23)
			{
				return num;
			}
		}
		return defaultValue;
	}

	public static string HourToTime(int hour, bool AMPM, bool shortForm = false)
	{
		if (AMPM)
		{
			string arg = (shortForm ? "a" : "AM");
			if (hour > 11)
			{
				arg = (shortForm ? "p" : "PM");
				if (hour > 12)
				{
					hour -= 12;
				}
			}
			hour = ((hour == 0) ? 12 : hour);
			return string.Format("{0}{2}{1}", hour, arg, shortForm ? "" : " ");
		}
		return hour.ToString("D2");
	}

	public static string HourToTime(int hour, int minutes, bool AMPM, bool shortForm = false)
	{
		if (AMPM)
		{
			string text = (shortForm ? "a" : "AM");
			if (hour > 11)
			{
				text = (shortForm ? "p" : "PM");
				if (hour > 12)
				{
					hour -= 12;
				}
			}
			hour = ((hour == 0) ? 12 : hour);
			return string.Format("{0}:{1:D2}{3}{2}", hour, minutes, text, shortForm ? "" : " ");
		}
		return string.Format("{0:D2}:{1:D2}", hour, minutes);
	}

	public static T2 Mode<T1, T2>(this IEnumerable<T1> list, Func<T1, T2> getValue, T2 defaultValue = default(T2))
	{
		Dictionary<T2, int> dictionary = new Dictionary<T2, int>();
		foreach (T1 item in list)
		{
			T2 val = getValue(item);
			if (val != null)
			{
				dictionary.AddTo(val, 1, (int x, int y) => x + y);
			}
		}
		if (dictionary.Count <= 0)
		{
			return defaultValue;
		}
		return dictionary.MaxInstance((KeyValuePair<T2, int> x) => x.Value).Key;
	}

	public static T2 Mode<T1, T2>(this IList<T1> list, Func<T1, T2> getValue, T2 defaultValue = default(T2))
	{
		if (list.Count == 0)
		{
			return defaultValue;
		}
		if (list.Count == 1)
		{
			return getValue(list[0]);
		}
		_modeDict.Clear();
		for (int i = 0; i < list.Count; i++)
		{
			_modeDict.AddUp(getValue(list[i]));
		}
		T2 result = ((_modeDict.Count > 0) ? ((T2)_modeDict.MaxInstance((KeyValuePair<object, int> x) => x.Value).Key) : defaultValue);
		_modeDict.Clear();
		return result;
	}

	public static bool Mode<T>(this IList<T> list, Func<T, bool> getValue, bool defaultValue = false)
	{
		if (list == null || list.Count == 0)
		{
			return defaultValue;
		}
		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (getValue(list[i]))
			{
				num++;
			}
		}
		return num * 2 >= list.Count;
	}

	public static IEnumerable<T> PickFrom<T>(this IList<T> input, IList<bool> selected)
	{
		int max = Mathf.Min(input.Count, selected.Count);
		for (int i = 0; i < max; i++)
		{
			if (selected[i])
			{
				yield return input[i];
			}
		}
	}

	public static string Temperature(this float t, bool diff)
	{
		if (diff)
		{
			if (!Options.Celsius)
			{
				return (t * 1.8f).WithPlusN("N0") + " F";
			}
			return t.WithPlusN("N0") + "C";
		}
		if (!Options.Celsius)
		{
			return (t * 1.8f + 32f).ToString("N0") + " F";
		}
		return t.ToString("N0") + "C";
	}

	public static T ToEnum<T>(this string value)
	{
		return (T)Enum.Parse(typeof(T), value);
	}

	public static bool ToEnum<T>(this string value, out T res)
	{
		try
		{
			res = (T)Enum.Parse(typeof(T), value);
			return true;
		}
		catch (Exception)
		{
			res = default(T);
			return false;
		}
	}

	public static T ToEnum<T>(this string value, T defaultValue)
	{
		try
		{
			return (T)Enum.Parse(typeof(T), value);
		}
		catch (Exception)
		{
			return defaultValue;
		}
	}

	public static float EulerAngleY(float x, float y)
	{
		float num = Mathf.Atan2(x, y) * 57.29578f;
		if (num < 0f)
		{
			return num + 360f;
		}
		return num;
	}

	public static float EulerAngleY(float x1, float y1, float x2, float y2)
	{
		return EulerAngleY(x2 - x1, y2 - y1);
	}

	public static float GetFlatAngle(this Vector3 v1, Vector3 v2)
	{
		return EulerAngleY(v1.x, v1.z, v2.x, v2.z);
	}

	public static float GetFlatAngle(this Vector3 v1)
	{
		return EulerAngleY(v1.x, v1.z);
	}

	public static void ChangeMainColor(this Button button, Color color, bool keepAlpha)
	{
		ColorBlock colors = button.colors;
		colors.normalColor = (keepAlpha ? color.Alpha(colors.normalColor.a) : color);
		button.colors = colors;
	}

	public static void GetCorners(this RectTransform rectTransform, out Vector2 corner1, out Vector2 corner2)
	{
		corner1.x = 0f;
		corner1.y = 1f;
		corner2.x = 1f;
		corner2.y = 0f;
		corner1.x -= rectTransform.pivot.x;
		corner1.y -= rectTransform.pivot.y;
		corner2.x -= rectTransform.pivot.x;
		corner2.y -= rectTransform.pivot.y;
		corner1.x *= rectTransform.rect.width;
		corner1.y *= rectTransform.rect.height;
		corner2.x *= rectTransform.rect.width;
		corner2.y *= rectTransform.rect.height;
	}

	public static Rect ToScreenSpace(this RectTransform transform)
	{
		Vector3[] array = new Vector3[4];
		transform.GetWorldCorners(array);
		float num = 1f / Options.UISize;
		array[0] = GetUIScreenPosition(array[0]) * num;
		array[2] = GetUIScreenPosition(array[2]) * num;
		return new Rect(array[0].x / Options.UISize, array[0].y - (float)Screen.height / Options.UISize, array[2].x - array[0].x, array[2].y - array[0].y);
	}

	public static Vector3 Multiply(this Vector3 v, float x, float y, float z)
	{
		return new Vector3(v.x * x, v.y * y, v.z * z);
	}

	public static T[] SubOrderTwoGroups<T>(this IList<T> input, Func<T, bool> inFirstGroup)
	{
		T[] array = new T[input.Count];
		int num = 0;
		int num2 = input.Count - 1;
		for (int i = 0; i < input.Count; i++)
		{
			if (inFirstGroup(input[i]))
			{
				array[num] = input[i];
				num++;
			}
			else
			{
				array[num2] = input[i];
				num2--;
			}
		}
		array.ReverseListPart(num, array.Length);
		return array;
	}

	public static T FirstOrDefault<T>(this IList<T> list, T def = default(T))
	{
		if (list.Count <= 0)
		{
			return def;
		}
		return list[0];
	}

	public static T FirstOrDefault<T>(this IList<T> list, Func<T, bool> predicate, T def = default(T))
	{
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			T val = list[i];
			if (predicate(val))
			{
				return val;
			}
		}
		return def;
	}

	public static Color ChangeSaturation(this Color col, float sat)
	{
		float H;
		float S;
		float V;
		Color.RGBToHSV(col, out H, out S, out V);
		return Color.HSVToRGB(H, sat, V);
	}

	public static Color ChangeValue(this Color col, float value)
	{
		float H;
		float S;
		float V;
		Color.RGBToHSV(col, out H, out S, out V);
		return Color.HSVToRGB(H, S, value);
	}

	public static Color ChangeValueSaturation(this Color col, float value, float sat)
	{
		float H;
		float S;
		float V;
		Color.RGBToHSV(col, out H, out S, out V);
		return Color.HSVToRGB(H, sat, value);
	}

	public static T2 FirstOrDefaultOf<T1, T2>(this IEnumerable<T1> l, Func<T1, bool> predicate, Func<T1, T2> convert)
	{
		foreach (T1 item in l)
		{
			if (predicate(item))
			{
				return convert(item);
			}
		}
		return default(T2);
	}

	public static T2 FirstOrDefaultOf<T1, T2>(this IList<T1> l, Func<T1, bool> predicate, Func<T1, T2> convert)
	{
		for (int i = 0; i < l.Count; i++)
		{
			T1 arg = l[i];
			if (predicate(arg))
			{
				return convert(arg);
			}
		}
		return default(T2);
	}

	public static T FirstOrDefaultOf<T>(this IList l, Func<T, bool> predicate) where T : class
	{
		for (int i = 0; i < l.Count; i++)
		{
			T val;
			if ((val = l[i] as T) != null && predicate(val))
			{
				return val;
			}
		}
		return null;
	}

	public static T FirstOrDefaultOf<T>(this IList l) where T : class
	{
		for (int i = 0; i < l.Count; i++)
		{
			T result;
			if ((result = l[i] as T) != null)
			{
				return result;
			}
		}
		return null;
	}

	public static T FirstOrDefaultOf<T>(this IEnumerable l) where T : class
	{
		foreach (object item in l)
		{
			T result;
			if ((result = item as T) != null)
			{
				return result;
			}
		}
		return null;
	}

	public static IEnumerable<T> InOrder<T>(this IList<T> list, Func<T, int> byOrder)
	{
		if (list.Count == 1)
		{
			yield return list[0];
		}
		else
		{
			if (list.Count <= 0)
			{
				yield break;
			}
			int min = int.MaxValue;
			int max = int.MinValue;
			for (int i = 0; i < list.Count; i++)
			{
				int num = byOrder(list[i]);
				min = ((num < min) ? num : min);
				max = ((num > max) ? num : max);
			}
			int j;
			if (min == max)
			{
				for (j = 0; j < list.Count; j++)
				{
					yield return list[j];
				}
				yield break;
			}
			j = min;
			while (true)
			{
				min = int.MaxValue;
				for (int k = 0; k < list.Count; k++)
				{
					T val = list[k];
					int num2 = byOrder(val);
					if (num2 == j)
					{
						yield return val;
					}
					else if (num2 > j && num2 < min)
					{
						min = num2;
					}
				}
				if (j != max)
				{
					j = min;
					continue;
				}
				break;
			}
		}
	}

	private static int GetIntFromStringNaive(string num)
	{
		if (num.Length == 0)
		{
			return -1;
		}
		if (num.Length == 1)
		{
			return num[0] - 48;
		}
		int num2 = 1;
		int num3 = 0;
		for (int num4 = num.Length - 1; num4 >= 0; num4--)
		{
			num3 += (num[num4] - 48) * num2;
			num2 *= 10;
		}
		return num3;
	}

	private static void SkipTo(string s, ref int i, char target)
	{
		while (s[i] != target && i < s.Length)
		{
			i++;
		}
	}

	private static string[] GetFunction(string s, ref int i)
	{
		string[] array = new string[2];
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		int num2 = 0;
		while (i < s.Length && (s[i] != '}' || num2 > 0))
		{
			if (s[i] == '\\' && i + 1 < s.Length && s[i + 1] == ':')
			{
				i++;
				continue;
			}
			stringBuilder.Append(s[i]);
			if (s[i] == '{')
			{
				num2++;
			}
			else if (s[i] == '}')
			{
				num2--;
			}
			i++;
			if (i < s.Length && s[i] == ':')
			{
				if (num < 2)
				{
					array[num] = stringBuilder.ToString();
					num++;
				}
				stringBuilder.Clear();
				i++;
			}
		}
		if (num < 2)
		{
			array[num] = stringBuilder.ToString();
		}
		return array;
	}

	public static bool StartsWithVowelSound(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			return false;
		}
		if (char.IsDigit(s[0]))
		{
			if (s.Length > 1 && char.IsDigit(s[1]) && s[0] == '1')
			{
				if (s[1] != '8')
				{
					return s[1] == '1';
				}
				return true;
			}
			return s[0] == '8';
		}
		if (s.Length > 1 && ((char.IsUpper(s[0]) && char.IsUpper(s[1])) || s[1] == ' ' || char.IsDigit(s[1])))
		{
			return "aefhilmnorsx".IndexOf(char.ToLower(s[0])) >= 0;
		}
		return "aeiou".IndexOf(char.ToLower(s[0])) >= 0;
	}

	public static bool IsVowel(char inputChar)
	{
		char c = inputChar.ToString().Normalize(NormalizationForm.FormD)[0];
		return VowelChars.Contains(char.ToLowerInvariant(c));
	}

	private static void ExecuteFunc(string func, string arg, object target, StringBuilder sb, bool color, bool forceColor)
	{
		if ("H".Equals(func))
		{
			if (arg != null)
			{
				if (color)
				{
					sb.Append(arg.BlueHighlight());
				}
				else
				{
					sb.Append(arg);
				}
			}
		}
		else if ("Vowel".Equals(func))
		{
			if (arg != null)
			{
				string[] array = arg.Split(',');
				if (array.Length == 2)
				{
					sb.Append(StartsWithVowelSound(GetObjectString(target, false, false)) ? array[0] : array[1]);
				}
			}
		}
		else if ("Time".Equals(func))
		{
			int result;
			if (arg != null && int.TryParse(arg, out result))
			{
				sb.Append(HourString(result));
			}
		}
		else if ("Plural".Equals(func))
		{
			if (arg == null)
			{
				return;
			}
			object obj = target;
			if (obj == null)
			{
				return;
			}
			bool flag;
			object obj2;
			if ((obj2 = obj) is byte)
			{
				byte b = (byte)obj2;
				flag = b == 1;
			}
			else if ((obj2 = obj) is int)
			{
				int num = (int)obj2;
				flag = num == 1;
			}
			else if ((obj2 = obj) is uint)
			{
				uint num2 = (uint)obj2;
				flag = num2 == 1;
			}
			else if ((obj2 = obj) is float)
			{
				float a = (float)obj2;
				flag = Mathf.Approximately(a, 1f);
			}
			else
			{
				IList list;
				if ((list = obj as IList) == null)
				{
					return;
				}
				flag = list.Count == 1;
			}
			string[] array2 = arg.Split(',');
			if (array2.Length == 2)
			{
				sb.Append(GetObjectString(flag ? array2[1] : array2[0], color, forceColor));
			}
		}
		else if ("PluralKey".Equals(func))
		{
			if (arg == null)
			{
				return;
			}
			object obj;
			int number;
			if ((obj = target) is int)
			{
				int num3 = (int)obj;
				number = num3;
			}
			else
			{
				IList list2;
				if ((list2 = target as IList) == null)
				{
					return;
				}
				number = list2.Count;
			}
			sb.Append(GetObjectString(arg.LocPlural(number), color, forceColor));
		}
		else if ("FirstOrCount".Equals(func))
		{
			IList list3;
			if ((list3 = target as IList) != null)
			{
				if (list3.Count <= 3)
				{
					AppendList(list3, sb, color, forceColor);
				}
				else
				{
					sb.Append((arg != null) ? GetObjectString(list3.Count + " " + arg, color, forceColor) : GetObjectString(list3.Count.ToString(), color, forceColor));
				}
			}
		}
		else if ("NotNull".Equals(func))
		{
			if (arg != null && target != null)
			{
				string objectString = GetObjectString(target, color, forceColor);
				sb.Append(arg.Replace("*", objectString));
			}
		}
		else if ("Currency".Equals(func))
		{
			if (arg != null)
			{
				try
				{
					float x = (float)Convert.ToDouble(arg);
					sb.Append(x.Currency());
				}
				catch (Exception)
				{
				}
			}
		}
		else if ("KeyBind".Equals(func))
		{
			if (arg != null)
			{
				try
				{
					string fullKeyBindString = InputController.GetFullKeyBindString((InputController.Keys)Enum.Parse(typeof(InputController.Keys), arg), false);
					sb.Append(color ? GetObjectString(fullKeyBindString, true, true) : fullKeyBindString);
				}
				catch (Exception)
				{
				}
			}
		}
		else if ("KeyBindAlt".Equals(func))
		{
			if (arg != null)
			{
				try
				{
					string fullKeyBindString2 = InputController.GetFullKeyBindString((InputController.Keys)Enum.Parse(typeof(InputController.Keys), arg), true);
					sb.Append(color ? GetObjectString(fullKeyBindString2, true, true) : fullKeyBindString2);
				}
				catch (Exception)
				{
				}
			}
		}
		else if ("Constant".Equals(func))
		{
			if (arg != null)
			{
				string text = null;
				switch (arg)
				{
				case "NightShiftStart":
					text = HourToTime(18, SDateTime.AMPM);
					break;
				case "NightShiftEnd":
					text = HourToTime(5, SDateTime.AMPM);
					break;
				case "LeadCar":
					text = 300000f.Currency();
					break;
				case "LeadMeal":
					text = (3000f / (float)GameSettings.DaysPerMonth).Currency();
					break;
				case "LeadRoyalty":
					text = 0.05f.ToPercent(false);
					break;
				case "LeadGolden":
					text = 5.ToString();
					break;
				case "Spec3Boost":
					text = 0.15f.ToPercent(false);
					break;
				case "AssemblerMaxQueue":
					text = 20.ToString();
					break;
				case "CompanyName":
					text = (GameSettings.Instance.IsReferenceNull() ? "#ERROR#" : GameSettings.Instance.MyCompany.Name);
					break;
				case "PostMarketingPrice":
					text = MarketingPlan.PostMarketingPrice.Currency();
					break;
				case "CampaignRival":
					text = MissionGuide.Instance.GetCharacter("Bob").Name;
					break;
				case "CampignRivalCompany":
					text = "Rocketz Rule";
					break;
				case "CourierBoxes":
					text = AI.MaxBoxesDPM.ToString();
					break;
				case "DayOrMonth":
					text = ((GameSettings.DaysPerMonth > 1) ? "Day".Loc().ToLower() : "Month".Loc().ToLower());
					break;
				}
				if (text != null)
				{
					sb.Append(color ? GetObjectString(text, true, true) : text);
				}
			}
		}
		else if ("ToLower".Equals(func))
		{
			if (target != null)
			{
				sb.Append(GetObjectString(target.ToString().ToLower(), color, forceColor));
			}
		}
		else if ("Uncapitalize".Equals(func))
		{
			if (target != null)
			{
				string text2 = target.ToString();
				sb.Append(GetObjectString(text2.Substring(0, 1).ToLower() + text2.Substring(1), color, forceColor));
			}
		}
		else if ("Warning".Equals(func))
		{
			if (arg != null)
			{
				sb.Append("<b><color=#990000>" + arg + "</color></b>");
			}
		}
		else
		{
			if (!"FeaturesLeft".Equals(func))
			{
				return;
			}
			int featuresLeft = AchievementController.GetFeaturesLeft();
			if (featuresLeft > 3)
			{
				sb.Append("(" + "TimeDiffLeft".Loc(AchievementController.GetFeaturesLeft().ToString()) + ")");
			}
			else if (featuresLeft > 0)
			{
				string text3 = Newspaper.MakeList((from mechanics in AchievementController.GetAllFeaturesLeft()
					select mechanics.ToString().Loc()).ToList(), true, true);
				sb.Append("(" + "MissingThing".Loc(text3) + ")");
			}
		}
	}

	private static void AppendList(IList values, StringBuilder sb, bool color, bool forceColor)
	{
		if (values.Count == 0)
		{
			sb.Append(GetObjectString("Nobody".Loc(), true, true));
			return;
		}
		if (values.Count == 1)
		{
			sb.Append(GetObjectString(values[0], color, forceColor));
			return;
		}
		for (int i = 0; i < values.Count - 1; i++)
		{
			if (i > 0)
			{
				sb.Append(", ");
			}
			sb.Append(GetObjectString(values[i], color, forceColor));
		}
		sb.Append("AndSeperator".Loc());
		sb.Append(GetObjectString(values[values.Count - 1], color, forceColor));
	}

	private static string GetObjectString(object obj, bool color, bool forceColor)
	{
		if (obj == null)
		{
			return "";
		}
		IFormatColorObject formatColorObject;
		if ((formatColorObject = obj as IFormatColorObject) != null)
		{
			if (!color)
			{
				return formatColorObject.GetActualString();
			}
			return formatColorObject.GetActualString().BlueHighlight();
		}
		if (color && forceColor)
		{
			return obj.ToString().BlueHighlight();
		}
		return obj.ToString();
	}

	public static string BlueHighlight(this string s)
	{
		return "<Color=#312CDA>" + s + "</Color>";
	}

	public static string RobustStringFormat(string s, bool color, bool forceColor, params object[] args)
	{
		if (s == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder(s.Length);
		StringBuilder stringBuilder2 = new StringBuilder();
		bool flag = false;
		for (int i = 0; i < s.Length; i++)
		{
			if (flag)
			{
				if (s[i] == ':')
				{
					int intFromStringNaive = GetIntFromStringNaive(stringBuilder2.ToString());
					if (intFromStringNaive >= 0 && intFromStringNaive < args.Length)
					{
						i++;
						string[] function = GetFunction(s, ref i);
						ExecuteFunc(function[0], function[1], args[intFromStringNaive], stringBuilder, color, forceColor);
					}
					else
					{
						SkipTo(s, ref i, '}');
					}
					stringBuilder2.Clear();
					flag = false;
				}
				else if (s[i] == '}')
				{
					int intFromStringNaive2 = GetIntFromStringNaive(stringBuilder2.ToString());
					if (intFromStringNaive2 >= 0 && intFromStringNaive2 < args.Length)
					{
						stringBuilder.Append(GetObjectString(args[intFromStringNaive2], color, forceColor));
					}
					else
					{
						stringBuilder.Append("ERR#" + intFromStringNaive2);
					}
					stringBuilder2.Clear();
					flag = false;
				}
				else if (char.IsDigit(s[i]))
				{
					stringBuilder2.Append(s[i]);
				}
				else if (char.IsLetter(s[i]) && stringBuilder2.Length == 0)
				{
					string[] function2 = GetFunction(s, ref i);
					ExecuteFunc(function2[0], function2[1], null, stringBuilder, color, forceColor);
					flag = false;
				}
				else
				{
					stringBuilder.Append("{");
					stringBuilder.Append(stringBuilder2);
					stringBuilder.Append(s[i]);
					stringBuilder2.Clear();
					flag = false;
				}
			}
			else if (s[i] == '{')
			{
				flag = true;
			}
			else
			{
				stringBuilder.Append(s[i]);
			}
		}
		return stringBuilder.ToString();
	}

	public static bool Remove<T1, T2>(this List<T1> list, T2 item) where T1 : class
	{
		T1 item2;
		if ((item2 = item as T1) != null)
		{
			return list.Remove(item2);
		}
		return false;
	}

	public static T2 GetOrAdd<T1, T2>(this Dictionary<T1, T2> dict, T1 key, Func<T1, T2> create)
	{
		T2 value;
		if (!dict.TryGetValue(key, out value))
		{
			return dict[key] = create(key);
		}
		return value;
	}

	public static Vector2[] GetOffset(this IList<Vector2> polygon, float offset, bool angleOffset = true)
	{
		Vector2[] array = new Vector2[polygon.Count];
		for (int i = 0; i < polygon.Count; i++)
		{
			Vector2 first = polygon[(i == 0) ? (polygon.Count - 1) : (i - 1)];
			Vector2 second = polygon[i];
			Vector2 third = polygon[(i + 1) % polygon.Count];
			array[i] = GetOffset(first, second, third, offset, angleOffset);
		}
		return array;
	}

	public static Vector2[] GetRelativeOffset(this IList<Vector2> polygon, float percent, float max, bool angleOffset = true)
	{
		Vector2[] array = new Vector2[polygon.Count];
		for (int i = 0; i < polygon.Count; i++)
		{
			Vector2 vector = polygon[(i == 0) ? (polygon.Count - 1) : (i - 1)];
			Vector2 vector2 = polygon[i];
			Vector2 vector3 = polygon[(i + 1) % polygon.Count];
			Vector2 vector4 = (vector + vector3) * 0.5f;
			array[i] = GetOffset(vector, vector2, vector3, Mathf.Min(max, (vector2 - vector4).magnitude * percent), angleOffset);
		}
		return array;
	}

	public static Vector2 NormalizePoint(this Vector2 v, Rect inner, Rect outer)
	{
		return new Vector2(v.x.MapRange(inner.xMin, inner.xMax, outer.xMin, outer.xMax), v.y.MapRange(inner.yMin, inner.yMax, outer.yMin, outer.yMax));
	}

	public static Rect Move(this Rect r, float x, float y)
	{
		return new Rect(r.x + x, r.y + y, r.width, r.height);
	}

	public static void CleanUpPolygon(this List<Vector2> points, float maxDegrees = 3f)
	{
		for (int i = 0; i < points.Count; i++)
		{
			int index = (i + 1) % points.Count;
			if (points[i].Dist(points[index]) < 0.01f)
			{
				points.RemoveAt(i);
				i--;
				continue;
			}
			int index2 = ((i == 0) ? (points.Count - 1) : (i - 1));
			Vector2 normalized = (points[i] - points[index2]).normalized;
			Vector2 normalized2 = (points[index] - points[i]).normalized;
			if (Mathf.Abs(Mathf.Acos(Vector2.Dot(normalized, normalized2))) < maxDegrees * ((float)Math.PI / 180f))
			{
				points.RemoveAt(i);
				i--;
			}
		}
	}

	public static T2[] ZipArray<T1, T2>(this IList<T1> l, Func<T1, T1, T2> conv)
	{
		if (l.Count % 2 == 1)
		{
			throw new Exception("Trying to zip odd numbered list");
		}
		T2[] array = new T2[l.Count / 2];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = conv(l[i * 2], l[i * 2 + 1]);
		}
		return array;
	}

	public static List<T2> ZipList<T1, T2>(this IList<T1> l, Func<T1, T1, T2> conv)
	{
		if (l.Count % 2 == 1)
		{
			throw new Exception("Trying to zip odd numbered list");
		}
		List<T2> list = new List<T2>();
		int num = l.Count / 2;
		for (int i = 0; i < num; i++)
		{
			list.Add(conv(l[i * 2], l[i * 2 + 1]));
		}
		return list;
	}

	public static KeyValuePair<List<T2>, int[]> UnZip<T1, T2>(this IList<T1> l, Func<T1, bool, T2> conv)
	{
		Dictionary<T2, int> dictionary = new Dictionary<T2, int>();
		int[] array = new int[l.Count * 2];
		List<T2> list = new List<T2>();
		for (int i = 0; i < l.Count; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				T2 val = conv(l[i], j == 0);
				int value;
				if (!dictionary.TryGetValue(val, out value))
				{
					value = (dictionary[val] = list.Count);
					list.Add(val);
				}
				array[i * 2 + j] = value;
			}
		}
		return new KeyValuePair<List<T2>, int[]>(list, array);
	}

	public static int GetMinAbove<T>(this IList<T> l, int above, Func<T, int> conv)
	{
		int num = above;
		for (int i = 0; i < l.Count; i++)
		{
			int num2 = conv(l[i]);
			if (num2 > above && (num == above || num2 < num))
			{
				num = num2;
			}
		}
		return num;
	}

	public static int ShortestDelta(int a, int b, int wrap)
	{
		int num = wrap / 2;
		return (a - b + num) % wrap - num;
	}

	public static bool Contains<T>(this IList<T> l, T element)
	{
		for (int i = 0; i < l.Count; i++)
		{
			if (element.Equals(l[i]))
			{
				return true;
			}
		}
		return false;
	}

	public static float Atan2(this Vector2 a, Vector2 b)
	{
		return Mathf.Atan2(b.y - a.y, b.x - a.x) * 57.29578f;
	}

	public static void Parallellize<T>(this IEnumerable<T> input, Action<T> act, ThreadCountdown counter)
	{
		foreach (T item in input)
		{
			ThreadPool.QueueUserWorkItem(delegate(object o)
			{
				T obj = (T)o;
				try
				{
					act(obj);
				}
				catch (Exception ex)
				{
					ErrorLogging.AddException(ex);
				}
				finally
				{
					counter.FinishTask();
				}
			}, item);
		}
		counter.Wait();
	}

	public static void LogColor(string msg, Color color)
	{
		UnityEngine.Debug.Log("<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + msg + "</color>");
	}

	public static Dictionary<T1, T2> ToDictionary<T1, T2>(this IEnumerable<KeyValuePair<T1, T2>> list)
	{
		Dictionary<T1, T2> dictionary = new Dictionary<T1, T2>();
		foreach (KeyValuePair<T1, T2> item in list)
		{
			dictionary[item.Key] = item.Value;
		}
		return dictionary;
	}

	public static Dictionary<T2, T3> ToDictionaryNotNull<T1, T2, T3>(this IEnumerable<T1> list, Func<T1, T2> keySel, Func<T1, T3> valSel)
	{
		Dictionary<T2, T3> dictionary = new Dictionary<T2, T3>();
		foreach (T1 item in list)
		{
			T2 val = keySel(item);
			if (val != null)
			{
				dictionary[val] = valSel(item);
			}
		}
		return dictionary;
	}

	public static Quaternion GetQuaternion(this Matrix4x4 m)
	{
		return Quaternion.LookRotation(m.GetColumn(2), m.GetColumn(1));
	}

	public static Vector3 GetTranslation(this Matrix4x4 m)
	{
		return m.GetColumn(3);
	}

	public static void ExtractTRS(this Matrix4x4 m, out Vector3 position, out Quaternion rotation, out Vector3 scale)
	{
		position = m.GetColumn(3);
		Vector3 vector = m.GetColumn(2).ToVector3();
		rotation = ((vector == Vector3.zero) ? Quaternion.identity : Quaternion.LookRotation(vector, m.GetColumn(1)));
		scale = new Vector3(m.GetColumn(0).magnitude, m.GetColumn(1).magnitude, m.GetColumn(2).magnitude);
	}

	public static Transform FindTransformPath(string path, Transform startFrom = null)
	{
		Transform transform = startFrom;
		bool flag = transform == null;
		if (path.StartsWith("/"))
		{
			path = path.Substring(1);
			flag = true;
		}
		string[] array = path.Split('/');
		int i = 0;
		if (flag && array.Length != 0)
		{
			transform = FindElement(array[0], SceneManager.GetActiveScene().GetRootGameObjects());
			i = 1;
		}
		for (; i < array.Length; i++)
		{
			transform = FindElement(array[i], transform);
			if (transform == null)
			{
				return null;
			}
		}
		return transform;
	}

	private static int GetFindIndex(ref string name)
	{
		int result = 0;
		int num = name.IndexOf("[");
		if (num > 0)
		{
			int num2 = name.IndexOf("]");
			if (num2 > num)
			{
				try
				{
					result = Convert.ToInt32(name.Substring(num + 1, num2 - num - 1));
					name = name.Substring(0, num);
				}
				catch (Exception)
				{
				}
			}
		}
		return result;
	}

	private static Transform FindElement(string name, Transform t)
	{
		int num = GetFindIndex(ref name);
		for (int i = 0; i < t.childCount; i++)
		{
			Transform child = t.GetChild(i);
			if (child.name.Equals(name))
			{
				if (num <= 0)
				{
					return child;
				}
				num--;
			}
		}
		return null;
	}

	private static Transform FindElement(string name, IList<GameObject> ts)
	{
		int num = GetFindIndex(ref name);
		for (int i = 0; i < ts.Count; i++)
		{
			GameObject gameObject = ts[i];
			if (gameObject.name.Equals(name))
			{
				if (num <= 0)
				{
					return gameObject.transform;
				}
				num--;
			}
		}
		return null;
	}

	public static string SecondsToTime(this double t)
	{
		return ((float)t).SecondsToTime();
	}

	public static string SecondsToTime(this float t, bool superPrecise = true)
	{
		if (t < 0f)
		{
			t = 0f - t;
		}
		if (t < 1f)
		{
			float num = t * 1000f;
			if (superPrecise && num < 1f)
			{
				return num.ToString("F3") + " ms";
			}
			return num.ToString("F0") + " ms";
		}
		if (t < 60f)
		{
			if (!superPrecise)
			{
				return t.ToString("0.#") + " s";
			}
			return t.ToString("0.###") + " s";
		}
		int num2 = Mathf.FloorToInt(t / 60f);
		int num3 = Mathf.FloorToInt(t % 60f);
		if (num2 > 59)
		{
			int num4 = Mathf.FloorToInt((float)num2 / 60f);
			num2 %= 60;
			if (num4 >= 24)
			{
				int num5 = Mathf.FloorToInt((float)num4 / 24f);
				num4 %= 24;
				return num5 + " d + " + num4.ToString("00") + ":" + num2.ToString("00") + ":" + num3.ToString("00") + " h";
			}
			return num4.ToString("00") + ":" + num2.ToString("00") + ":" + num3.ToString("00") + " h";
		}
		return num2.ToString("00") + ":" + num3.ToString("00") + " m";
	}

	public static Vector3 ToVector3(this Vector4 v)
	{
		return v;
	}

	public static float? PointToLineDistance(Vector2 p, Vector2 a, Vector2 b)
	{
		Vector2 res;
		if (!ProjectToLine(p, a, b, out res))
		{
			return null;
		}
		return (res - p).magnitude;
	}

	public static bool PointWithinLineDistance(Vector2 p, Vector2 a, Vector2 b, float distSquared)
	{
		Vector2 res;
		if (ProjectToLine(p, a, b, out res))
		{
			return (res - p).sqrMagnitude < distSquared;
		}
		return false;
	}

	public static bool IsAlignedRectangle(this IList<WallEdge> poly)
	{
		if (poly.Count < 4)
		{
			return false;
		}
		bool first = true;
		bool followX = true;
		int sideSwitch = 0;
		Vector2 p = poly[poly.Count - 1].Pos;
		for (int i = 0; i < poly.Count; i++)
		{
			Vector2 pos = poly[i].Pos;
			if (!AlignedRectangleSub(p, pos, ref first, ref followX, ref sideSwitch))
			{
				return false;
			}
			p = pos;
		}
		if (sideSwitch != 3)
		{
			return sideSwitch == 4;
		}
		return true;
	}

	public static bool IsAlignedRectangle(this IList<Vector2> poly)
	{
		if (poly.Count < 4)
		{
			return false;
		}
		bool first = true;
		bool followX = true;
		int sideSwitch = 0;
		Vector2 p = poly[poly.Count - 1];
		for (int i = 0; i < poly.Count; i++)
		{
			Vector2 vector = poly[i];
			if (!AlignedRectangleSub(p, vector, ref first, ref followX, ref sideSwitch))
			{
				return false;
			}
			p = vector;
		}
		if (sideSwitch != 3)
		{
			return sideSwitch == 4;
		}
		return true;
	}

	private static bool AlignedRectangleSub(Vector2 p1, Vector2 p2, ref bool first, ref bool followX, ref int sideSwitch)
	{
		if (first)
		{
			first = false;
			if (p1.y == p2.y)
			{
				followX = false;
			}
			else if (p1.x != p2.x)
			{
				return false;
			}
		}
		else if (p1.x == p2.x)
		{
			if (!followX)
			{
				sideSwitch++;
			}
			followX = true;
		}
		else
		{
			if (p1.y != p2.y)
			{
				return false;
			}
			if (followX)
			{
				sideSwitch++;
			}
			followX = false;
		}
		return sideSwitch <= 4;
	}

	public static Vector2 GetRandomPoint(this Rect area)
	{
		return new Vector2(RandomRange(area.xMin, area.xMax), RandomRange(area.yMin, area.yMax));
	}

	public static Rect Scale(this Rect r, float s)
	{
		return new Rect(r.x * s, r.y * s, r.width * s, r.height * s);
	}

	public static T Last<T>(this IList<T> l)
	{
		if (l.Count <= 0)
		{
			return default(T);
		}
		return l[l.Count - 1];
	}

	public static T First<T>(this IList<T> l)
	{
		if (l.Count > 0)
		{
			return l[0];
		}
		throw new Exception("Tried to get first value of an empty list");
	}

	public static float InOutCurve(this float val)
	{
		if (val <= 0f)
		{
			return 0f;
		}
		if (val >= 1f)
		{
			return 1f;
		}
		return val * val * (3f - 2f * val);
	}

	public static double InOutCurve(this double val)
	{
		if (val <= 0.0)
		{
			return 0.0;
		}
		if (val >= 1.0)
		{
			return 1.0;
		}
		return val * val * (3.0 - 2.0 * val);
	}

	public static SoftwareCategory GetCategory(this KeyValuePair<string, string> key)
	{
		return MarketSimulation.Active.SoftwareTypes[key.Key].Categories[key.Value];
	}

	public static void AddArray(this IList<float> a1, IList<float> a2)
	{
		int num = Mathf.Min(a1.Count, a2.Count);
		for (int i = 0; i < num; i++)
		{
			a1[i] += a2[i];
		}
	}

	public static void AddArray(this IList<double> a1, IList<double> a2)
	{
		int num = Mathf.Min(a1.Count, a2.Count);
		for (int i = 0; i < num; i++)
		{
			a1[i] += a2[i];
		}
	}

	public static void ReplaceContent<T>(this IList<T> a1, IList<T> a2)
	{
		int num = Mathf.Min(a1.Count, a2.Count);
		for (int i = 0; i < num; i++)
		{
			a1[i] = a2[i];
		}
	}

	public static double SubmarketDistance(this double[] sub1, double[] sub2)
	{
		double num = 0.0;
		for (int i = 0; i < 3; i++)
		{
			double num2 = sub1[i] + sub2[i];
			num += Clamp01((num2 > 9.999999974752427E-07) ? (Math.Abs(sub1[i] - sub2[i]) / num2) : Math.Abs(sub1[i] - sub2[i]));
		}
		return 1.0 - num / 3.0;
	}

	public static double SubmarketScore(this double[] sub1, double[] sub2, double[] quality)
	{
		double num = 0.0;
		for (int i = 0; i < 3; i++)
		{
			num += Lerp(sub1[i] + sub2[i], Math.Abs(sub1[i] - sub2[i]), quality[i], true);
		}
		return 1.0 - num * 0.5;
	}

	public static double SubmarketScore(this double[] sub, double[] quality)
	{
		double num = 0.0;
		for (int i = 0; i < 3; i++)
		{
			num += ((sub[i] > 0.0) ? (Clamp01(quality[i] / sub[i]) * sub[i]) : 0.0);
		}
		return num;
	}

	public static double SubmarketScoreWasted(this double[] sub, double[] quality)
	{
		double num = 0.0;
		for (int i = 0; i < 3; i++)
		{
			num += ((sub[i] > 0.0) ? (Math.Max(0.0, quality[i] / sub[i] - 1.0) * sub[i]) : quality[i]);
		}
		return num;
	}

	public static IEnumerable<T2> SelectMany<T1, T2>(this IList<T1> list, Func<T1, IEnumerable<T2>> conv)
	{
		for (int i = 0; i < list.Count; i++)
		{
			IEnumerable<T2> enumerable = conv(list[i]);
			foreach (T2 item in enumerable)
			{
				yield return item;
			}
		}
	}

	public static IEnumerable<T2> SelectMany<T1, T2>(this IList<T1> list, Func<T1, IList<T2>> conv)
	{
		for (int i = 0; i < list.Count; i++)
		{
			IList<T2> it = conv(list[i]);
			for (int j = 0; j < it.Count; j++)
			{
				yield return it[j];
			}
		}
	}

	public static void DrawLine(Vector2 p1, Vector2 p2, float width, Color color, VertexHelper h)
	{
		Vector2 normalized = new Vector2(p1.y - p2.y, p2.x - p1.x).normalized;
		h.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				position = new Vector2(p1.x + normalized.x * width / 2f, p1.y + normalized.y * width / 2f),
				color = color
			},
			new UIVertex
			{
				position = new Vector2(p2.x + normalized.x * width / 2f, p2.y + normalized.y * width / 2f),
				color = color
			},
			new UIVertex
			{
				position = new Vector2(p2.x - normalized.x * width / 2f, p2.y - normalized.y * width / 2f),
				color = color
			},
			new UIVertex
			{
				position = new Vector2(p1.x - normalized.x * width / 2f, p1.y - normalized.y * width / 2f),
				color = color
			}
		});
	}

	public static T[] ToArray<T>(this IList<T> l)
	{
		T[] array = new T[l.Count];
		for (int i = 0; i < l.Count; i++)
		{
			array[i] = l[i];
		}
		return array;
	}

	public static T Pop<T>(this List<T> l)
	{
		if (l.Count > 0)
		{
			T result = l[l.Count - 1];
			l.RemoveAt(l.Count - 1);
			return result;
		}
		return default(T);
	}

	public static string FontSize(this string input, float size)
	{
		return "<size=" + size + ">" + input + "</size>";
	}

	public static string FontBold(this string input)
	{
		return "<b>" + input + "</b>";
	}

	public static string FontColor(this string input, Color c)
	{
		return "<color=#" + ColorUtility.ToHtmlStringRGB(c) + ">" + input + "</color>";
	}

	public static float[] MultNewArray(this float[] arr, float val)
	{
		float[] array = new float[arr.Length];
		for (int i = 0; i < arr.Length; i++)
		{
			array[i] = arr[i] * val;
		}
		return array;
	}

	public static double[] MultNewArray(this double[] arr, double val)
	{
		double[] array = new double[arr.Length];
		for (int i = 0; i < arr.Length; i++)
		{
			array[i] = arr[i] * val;
		}
		return array;
	}

	public static T2 FirstNotNull<T1, T2>(this IList<T1> l, Func<T1, T2> convert, T2 defaultValue = default(T2))
	{
		for (int i = 0; i < l.Count; i++)
		{
			T1 arg = l[i];
			T2 val = convert(arg);
			if (val != null)
			{
				return val;
			}
		}
		return defaultValue;
	}

	public static T2 FirstNotNull<T1, T2>(this IEnumerable<T1> l, Func<T1, T2> convert, T2 defaultValue = default(T2))
	{
		foreach (T1 item in l)
		{
			T2 val = convert(item);
			if (val != null)
			{
				return val;
			}
		}
		return defaultValue;
	}

	public static T2 LastNotNull<T1, T2>(this IList<T1> l, Func<T1, T2> convert, T2 defaultValue = default(T2))
	{
		for (int num = l.Count - 1; num >= 0; num--)
		{
			T1 arg = l[num];
			T2 val = convert(arg);
			if (val != null)
			{
				return val;
			}
		}
		return defaultValue;
	}

	public static T2? LastNotNull<T1, T2>(this IList<T1> l, Func<T1, T2?> convert, T2? defaultValue = null) where T2 : struct
	{
		for (int num = l.Count - 1; num >= 0; num--)
		{
			T1 arg = l[num];
			T2? val = convert(arg);
			if (val.HasValue)
			{
				return val.Value;
			}
		}
		return defaultValue;
	}

	public static T2 LastNotNull<T1, T2>(this IList<T1> l, Func<T1, T2?> convert, T2 defaultValue = default(T2)) where T2 : struct
	{
		for (int num = l.Count - 1; num >= 0; num--)
		{
			T1 arg = l[num];
			T2? val = convert(arg);
			if (val.HasValue)
			{
				return val.Value;
			}
		}
		return defaultValue;
	}

	public static Vector3 ToVector4(this IList<float> v)
	{
		if (v.Count == 0)
		{
			return Vector4.zero;
		}
		if (v.Count == 1)
		{
			return new Vector4(v[0], 0f, 0f, 0f);
		}
		if (v.Count == 2)
		{
			return new Vector4(v[0], v[1], 0f, 0f);
		}
		if (v.Count == 3)
		{
			return new Vector4(v[0], v[1], v[2], 0f);
		}
		return new Vector4(v[0], v[1], v[2], v[3]);
	}

	public static Vector3 ToVector3(this IList<float> v, float defaultValue = 0f)
	{
		if (v.Count == 0)
		{
			return new Vector3(defaultValue, defaultValue, defaultValue);
		}
		if (v.Count == 1)
		{
			return new Vector3(v[0], defaultValue, defaultValue);
		}
		if (v.Count == 2)
		{
			return new Vector3(v[0], v[1], defaultValue);
		}
		return new Vector3(v[0], v[1], v[2]);
	}

	public static Vector2 ToVector2(this IList<float> v)
	{
		if (v.Count == 0)
		{
			return Vector3.zero;
		}
		if (v.Count == 1)
		{
			return new Vector2(v[0], 0f);
		}
		return new Vector2(v[0], v[1]);
	}

	public static TydList ToTyd(this Vector2 v, string name = null)
	{
		TydList tydList = new TydList(name);
		tydList.AddChildren<TydString>(new TydString(null, v.x.ToString()), new TydString(null, v.y.ToString()));
		return tydList;
	}

	public static TydList ToTyd(this Vector3 v, string name = null)
	{
		TydList tydList = new TydList(name);
		tydList.AddChildren<TydString>(new TydString(null, v.x.ToString()), new TydString(null, v.y.ToString()), new TydString(null, v.z.ToString()));
		return tydList;
	}

	public static TydList ToTyd(this Vector4 v, string name = null)
	{
		TydList tydList = new TydList(name);
		tydList.AddChildren<TydString>(new TydString(null, v.x.ToString()), new TydString(null, v.y.ToString()), new TydString(null, v.z.ToString()), new TydString(null, v.w.ToString()));
		return tydList;
	}

	public static float FuzzyIndex(this IList<float> l, float idx)
	{
		int num = Mathf.FloorToInt(idx);
		if (num < 0)
		{
			return l[0];
		}
		if (num < l.Count - 1)
		{
			return Mathf.Lerp(l[num], l[num + 1], idx - (float)num);
		}
		return l[l.Count - 1];
	}

	public static string Strip(this string input, char remove)
	{
		if (input == null)
		{
			return null;
		}
		int num = 0;
		for (int i = 0; i < input.Length; i++)
		{
			if (input[i] == remove)
			{
				num++;
			}
		}
		if (num == 0)
		{
			return input;
		}
		StringBuilder stringBuilder = new StringBuilder(input.Length - num);
		for (int j = 0; j < input.Length; j++)
		{
			if (input[j] != remove)
			{
				stringBuilder.Append(input[j]);
			}
		}
		return stringBuilder.ToString();
	}

	public static float GetPercentLateNight(float from, float to)
	{
		if (from > to)
		{
			to += 24f;
		}
		float num = to - from;
		return (GetOverlap(from, to, 0f, 5f) + GetOverlap(from, to, 18f, 29f)) / num;
	}

	public static bool IsLateNight(SDateTime time, Actor act)
	{
		if (!act.AIScript.HasFlag(AI.NodeFlag.DisableAllNeeds))
		{
			if (!(time.HourFraction < 5f))
			{
				return time.HourFraction > 18f;
			}
			return true;
		}
		return false;
	}

	public static float GetLateNightDebuff(SDateTime time, Actor act)
	{
		if (!act.AIScript.HasFlag(AI.NodeFlag.DisableAllNeeds))
		{
			float hourFraction = time.HourFraction;
			if (hourFraction > 18f)
			{
				float num = 1f - act.GetBenefitValue("NightShiftCompensation") * 1.5f;
				if (hourFraction > 19f)
				{
					return num * 0.25f;
				}
				return (hourFraction - 18f) * num * 0.25f;
			}
			if (hourFraction < 5f)
			{
				float num2 = 1f - act.GetBenefitValue("NightShiftCompensation") * 1.5f;
				if (hourFraction < 4f)
				{
					return num2 * 0.25f;
				}
				return (5f - hourFraction) * num2 * 0.25f;
			}
		}
		return 0f;
	}

	public static void SetIsOnNoEvents(this Toggle t, bool isOn)
	{
		Toggle.ToggleEvent onValueChanged = t.onValueChanged;
		t.onValueChanged = new Toggle.ToggleEvent();
		t.isOn = isOn;
		t.onValueChanged = onValueChanged;
	}

	public static void SetActorAnim(this Animator anim, Actor.AnimationStates state, int sub = -1)
	{
		anim.SetInteger("AnimControl", (int)state);
		if (sub > 0)
		{
			anim.SetInteger("SubAnim", sub);
		}
	}

	public static bool IsActor(this Animator anim, Actor.AnimationStates state, int sub = -1)
	{
		if (anim.GetInteger("AnimControl") == (int)state)
		{
			if (sub >= 0)
			{
				return anim.GetInteger("SubAnim") == sub;
			}
			return true;
		}
		return false;
	}

	public static float Royalty(this SoftwareFramework framework, Company c = null)
	{
		if (framework != null)
		{
			if (c != null)
			{
				return framework.GetActualRoyalty(c);
			}
			return framework.GetRoyalty();
		}
		return 0f;
	}

	public static void DividedOrderedInsert<T>(this List<T> l, T item, Func<T, int> order, int start = -1, int end = -1)
	{
		int num;
		while (true)
		{
			if (l.Count == 0)
			{
				l.Add(item);
				return;
			}
			if (start == -1)
			{
				start = 0;
				end = l.Count;
			}
			num = (end - start) / 2;
			if (num == 0)
			{
				if (order(item) < order(l[start]))
				{
					l.Insert(start, item);
				}
				else
				{
					l.Insert(start + 1, item);
				}
				return;
			}
			num = start + num;
			int num2 = order(item);
			int num3 = order(l[num]);
			if (num2 == num3)
			{
				break;
			}
			if (num2 < num3)
			{
				end = num;
			}
			else
			{
				start = num;
			}
		}
		l.Insert(num, item);
	}

	public static void IfLargerSet<T>(this float val, T obj, ref float comp, ref T res)
	{
		if (val > comp)
		{
			comp = val;
			res = obj;
		}
	}

	public static void IfLargerSet<T>(this double val, T obj, ref double comp, ref T res)
	{
		if (val > comp)
		{
			comp = val;
			res = obj;
		}
	}

	public static bool Is(this GameReader.NewLoadMode lm, GameReader.NewLoadMode cmp)
	{
		return (lm & cmp) != 0;
	}

	public static T GetAt<T>(this IEnumerable<T> l, int index)
	{
		int num = 0;
		foreach (T item in l)
		{
			if (num == index)
			{
				return item;
			}
			num++;
		}
		return default(T);
	}

	public static Vector2 Abs(this Vector2 v)
	{
		return new Vector2(Mathf.Abs(v.x), Mathf.Abs(v.y));
	}

	public static Vector3 Abs(this Vector3 v)
	{
		return new Vector3(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
	}

	public static bool ScaleDown(this Texture2D tex, int w, int h)
	{
		if (tex.width == w && tex.height == h)
		{
			return true;
		}
		if (tex.width > w && tex.height > h)
		{
			Color32[] pixels = tex.GetPixels32(0);
			int num = tex.width / w;
			int num2 = tex.height / h;
			int width = tex.width;
			if (tex.Resize(w, h))
			{
				Color32[] array = new Color32[w * h];
				for (int i = 0; i < w; i++)
				{
					int num3 = i * num;
					for (int j = 0; j < h; j++)
					{
						int num4 = j * num2;
						array[j * w + i] = pixels[num4 * width + num3];
					}
				}
				tex.SetPixels32(array);
				tex.Apply();
				return true;
			}
		}
		return false;
	}

	public static List<T> GetSecondaryWhere<T>(this IEnumerable<T> i, Func<T, bool> where, Func<T, bool> where2, List<T> output = null)
	{
		if (output == null)
		{
			output = new List<T>();
		}
		else
		{
			output.Clear();
		}
		int num = 0;
		foreach (T item in i)
		{
			if (where(item))
			{
				if (where2(item))
				{
					output.Insert(num, item);
					num++;
				}
				else if (num == 0)
				{
					output.Add(item);
				}
			}
		}
		if (num > 0)
		{
			output.RemoveRange(num, output.Count - num);
		}
		return output;
	}

	public static int GetLineWidth(this Text textField, string t)
	{
		return textField.GetLineWidth(t, textField.fontSize, textField.fontStyle);
	}

	public static int GetLineWidth(this Text textField, string t, int fontSize, FontStyle fontStyle)
	{
		int num = 0;
		for (int i = 0; i < t.Length; i++)
		{
			num += textField.GetCharWidth(t[i], fontSize, fontStyle);
		}
		return num;
	}

	public static int GetLineWidth(this Font font, string t, int fontSize, FontStyle fontStyle)
	{
		int num = 0;
		for (int i = 0; i < t.Length; i++)
		{
			num += font.GetCharWidth(t[i], fontSize, fontStyle);
		}
		return num;
	}

	public static int GetCharWidth(this Text textField, char t)
	{
		return textField.GetCharWidth(t, textField.fontSize, textField.fontStyle);
	}

	public static int GetCharWidth(this Text textField, char t, int fontSize, FontStyle fontStyle)
	{
		return textField.font.GetCharWidth(t, fontSize, fontStyle);
	}

	public static int GetCharWidth(this Font font, char t, int fontSize, FontStyle fontStyle)
	{
		CharacterInfo info;
		if (font.GetCharacterInfo(t, out info, fontSize, fontStyle))
		{
			return info.advance;
		}
		if (ObjectDatabase.Instance.DefaultFont.GetCharacterInfo(t, out info, fontSize, fontStyle))
		{
			return info.advance;
		}
		return fontSize / 2;
	}

	public static int GetLineHeight(this Text textfield)
	{
		return Mathf.CeilToInt((float)textfield.fontSize / (float)textfield.font.fontSize * (float)textfield.font.lineHeight * textfield.lineSpacing);
	}

	public static float GetLineHeightFloat(this Text textfield)
	{
		return (float)textfield.fontSize / (float)textfield.font.fontSize * (float)textfield.font.lineHeight * textfield.lineSpacing;
	}

	public static float RandomBucketed(int val, int buckets, float min, float max)
	{
		float num = (max - min) / (float)(buckets + 1);
		float num2 = min + num * (float)val;
		return RandomRange(num2, num2 + num);
	}

	public static T2 GetIfDistinct<T1, T2>(this IList<T1> l, Func<T1, T2> f) where T2 : class
	{
		T2 val = null;
		for (int i = 0; i < l.Count; i++)
		{
			T2 val2 = f(l[i]);
			if (val == null)
			{
				val = val2;
			}
			else if (val2 != null && val2 != val)
			{
				return null;
			}
		}
		return val;
	}

	public static uint Min(this uint v1, uint v2)
	{
		if (v1 >= v2)
		{
			return v2;
		}
		return v1;
	}

	public static uint Max(this uint v1, uint v2)
	{
		if (v1 <= v2)
		{
			return v2;
		}
		return v1;
	}

	public static IEnumerable<T> TakeLast<T>(this IList<T> l, int count)
	{
		for (int i = Mathf.Max(0, l.Count - count); i < l.Count; i++)
		{
			yield return l[i];
		}
	}

	public static Vector2 GetUIScreenPosition(this Transform ui)
	{
		return GetUIScreenPosition(new Vector2(ui.position.x, ui.position.y));
	}

	public static Vector2 GetUIScreenPosition(Vector2 ui)
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return ui;
		}
		return ui + new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f);
	}

	public static Array ToArray(this IEnumerable e, Type type, out int count)
	{
		count = 0;
		IEnumerator enumerator = e.GetEnumerator();
		while (enumerator.MoveNext())
		{
			count++;
		}
		Array array = Array.CreateInstance(type, count);
		int num = 0;
		enumerator.Reset();
		while (enumerator.MoveNext())
		{
			array.SetValue(enumerator.Current, num);
			num++;
		}
		return array;
	}

	public static void ForEachNotNull<T>(this IList<T> l, Action<T> action) where T : UnityEngine.Object
	{
		for (int i = 0; i < l.Count; i++)
		{
			if (l[i] != null)
			{
				action(l[i]);
			}
		}
	}

	public static IEnumerable<T> Where<T>(this IList<T> l, Func<T, bool> predicate)
	{
		for (int i = 0; i < l.Count; i++)
		{
			T val = l[i];
			if (predicate(val))
			{
				yield return val;
			}
		}
	}

	public static IEnumerable<T2> WhereSelect<T1, T2>(this IList<T1> l, Func<T1, bool> predicate, Func<T1, T2> convert)
	{
		for (int i = 0; i < l.Count; i++)
		{
			T1 arg = l[i];
			if (predicate(arg))
			{
				yield return convert(arg);
			}
		}
	}

	public static IEnumerable<T2> WhereSelectNotNull<T1, T2>(this IList<T1> l, Func<T1, bool> predicate, Func<T1, T2> convert)
	{
		for (int i = 0; i < l.Count; i++)
		{
			T1 val = l[i];
			if (val != null && predicate(val))
			{
				T2 val2 = convert(val);
				if (val2 != null)
				{
					yield return val2;
				}
			}
		}
	}

	public static void DrawArrow(this VertexHelper h, Vector2 p1, Vector2 p2)
	{
		h.DrawLine(p1, p2, 2f, Color.black);
		float rot = Mathf.Atan2(p2.y - p1.y, p2.x - p1.x) * 57.29578f - 90f;
		int currentVertCount = h.currentVertCount;
		h.AddVert(TransformVec(new Vector2(0f, 0f), rot, p2), Color.black, Vector2.zero);
		h.AddVert(TransformVec(new Vector2(15f, -30f), rot, p2), Color.black, Vector2.zero);
		h.AddVert(TransformVec(new Vector2(-15f, -30f), rot, p2), Color.black, Vector2.zero);
		h.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
		currentVertCount = h.currentVertCount;
		h.AddVert(TransformVec(new Vector2(0f, -6f), rot, p2), Color.white, Vector2.zero);
		h.AddVert(TransformVec(new Vector2(11f, -28f), rot, p2), Color.white, Vector2.zero);
		h.AddVert(TransformVec(new Vector2(-11f, -28f), rot, p2), Color.white, Vector2.zero);
		h.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
	}

	public static void DrawArrow(this VertexHelper h, Vector2 p1, Vector2 p2, Color col, float headSize)
	{
		h.DrawLine(p1, p2, 2f, col);
		float rot = Mathf.Atan2(p2.y - p1.y, p2.x - p1.x) * 57.29578f - 90f;
		int currentVertCount = h.currentVertCount;
		h.AddVert(TransformVec(new Vector2(0f, 0f), rot, p2), col, Vector2.zero);
		h.AddVert(TransformVec(new Vector2(headSize / 2f, 0f - headSize), rot, p2), col, Vector2.zero);
		h.AddVert(TransformVec(new Vector2((0f - headSize) / 2f, 0f - headSize), rot, p2), col, Vector2.zero);
		h.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
	}

	public static void DrawLine(this VertexHelper h, Vector2 p1, Vector2 p2, float width, Color color)
	{
		Vector2 vector = new Vector2(p1.y - p2.y, p2.x - p1.x);
		float magnitude = vector.magnitude;
		float y = magnitude / width;
		vector *= 1f / magnitude;
		h.AddUIVertexQuad(new UIVertex[4]
		{
			MakeVert(new Vector2(p1.x + vector.x * width / 2f, p1.y + vector.y * width / 2f), color, new Vector2(0f, y)),
			MakeVert(new Vector2(p2.x + vector.x * width / 2f, p2.y + vector.y * width / 2f), color, new Vector2(0f, 0f)),
			MakeVert(new Vector2(p2.x - vector.x * width / 2f, p2.y - vector.y * width / 2f), color, new Vector2(1f, 0f)),
			MakeVert(new Vector2(p1.x - vector.x * width / 2f, p1.y - vector.y * width / 2f), color, new Vector2(1f, y))
		});
	}

	private static Vector2 TransformVec(Vector2 v, float rot, Vector2 g)
	{
		Vector3 vector = Quaternion.Euler(0f, 0f, rot) * v;
		return new Vector2(vector.x + g.x, vector.y + g.y);
	}

	private static UIVertex MakeVert(Vector2 p, Color color, Vector2 uv)
	{
		UIVertex simpleVert = UIVertex.simpleVert;
		simpleVert.position = p;
		simpleVert.color = color;
		simpleVert.uv0 = uv;
		return simpleVert;
	}

	public static void AddThreaded<T>(this List<T> l, T item)
	{
		lock (l)
		{
			l.Add(item);
		}
	}

	public static float AddHour(this float h, float add)
	{
		h += add;
		if (h < 0f)
		{
			h += 24f;
		}
		else if (h >= 24f)
		{
			h -= 24f;
		}
		return h;
	}

	public static bool CompatibleWith(this IStockable s, HardwareComponent c)
	{
		if (c.Parent.Type == s.SWType && c.Parent.Category == s.Manufacturing)
		{
			return (s.HardwareInputMask & c.Mask) != 0;
		}
		return false;
	}

	public static Transform GetChildName(this Transform t, string name)
	{
		for (int i = 0; i < t.childCount; i++)
		{
			Transform child = t.GetChild(i);
			if (name.Equals(child.name))
			{
				return child;
			}
		}
		return null;
	}

	public static DictionaryList<T1, T2> ToDictionaryList<T1, T2, T3>(this IList<T3> l, Func<T3, T1> key, Func<T3, T2> value)
	{
		DictionaryList<T1, T2> dictionaryList = new DictionaryList<T1, T2>();
		for (int i = 0; i < l.Count; i++)
		{
			T3 arg = l[i];
			dictionaryList.Add(key(arg), value(arg));
		}
		return dictionaryList;
	}

	public static float OffsetHeight(this float height, float y, int roomFloor)
	{
		return y.GetFloorOffset(roomFloor) + height;
	}

	public static float GetFloorOffset(this float y, int roomFloor)
	{
		return y - (float)(roomFloor * 2);
	}

	public static string Capitalize(this string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return input;
		}
		if (char.IsLower(input[0]))
		{
			return char.ToUpper(input[0]) + input.Substring(1);
		}
		return input;
	}

	public static int Clamp(this int value, int min, int max)
	{
		if (value > max)
		{
			return max;
		}
		if (value >= min)
		{
			return value;
		}
		return min;
	}

	public static double Clamp(this double value, double min, double max)
	{
		if (value > max)
		{
			return max;
		}
		if (!(value < min))
		{
			return value;
		}
		return min;
	}

	public static void AddTrigger(this EventTrigger ev, EventTriggerType eventID, UnityAction<BaseEventData> call)
	{
		for (int i = 0; i < ev.triggers.Count; i++)
		{
			EventTrigger.Entry entry = ev.triggers[i];
			if (entry.eventID == eventID)
			{
				entry.callback.RemoveAllListeners();
				entry.callback.AddListener(call);
				return;
			}
		}
		EventTrigger.TriggerEvent triggerEvent = new EventTrigger.TriggerEvent();
		triggerEvent.AddListener(call);
		ev.triggers.Add(new EventTrigger.Entry
		{
			eventID = eventID,
			callback = triggerEvent
		});
	}

	public static void ClearTrigger(this EventTrigger ev, EventTriggerType eventID)
	{
		for (int i = 0; i < ev.triggers.Count; i++)
		{
			EventTrigger.Entry entry = ev.triggers[i];
			if (entry.eventID == eventID)
			{
				entry.callback.RemoveAllListeners();
				break;
			}
		}
	}

	public static Direction ToDirection(this Vector2Int i)
	{
		if (i.x > 0)
		{
			return Direction.North;
		}
		if (i.x < 0)
		{
			return Direction.South;
		}
		if (i.y > 0)
		{
			return Direction.West;
		}
		if (i.y < 0)
		{
			return Direction.East;
		}
		return Direction.None;
	}

	public static Vector2Int ToVector(this Direction self)
	{
		switch (self)
		{
		case Direction.North:
			return new Vector2Int(1, 0);
		case Direction.East:
			return new Vector2Int(0, -1);
		case Direction.South:
			return new Vector2Int(-1, 0);
		case Direction.West:
			return new Vector2Int(0, 1);
		default:
			return new Vector2Int(0, 0);
		}
	}

	public static Vector3 ToNormal(this Direction self)
	{
		switch (self)
		{
		case Direction.North:
			return new Vector3(1f, 0f, 0f);
		case Direction.East:
			return new Vector3(0f, 0f, -1f);
		case Direction.South:
			return new Vector3(-1f, 0f, 0f);
		case Direction.West:
			return new Vector3(0f, 0f, 1f);
		default:
			return new Vector3(0f, 1f, 0f);
		}
	}

	public static Vector2 ToCenter(this Direction self, Rect r)
	{
		switch (self)
		{
		case Direction.North:
			return new Vector2(r.xMax, r.center.y);
		case Direction.East:
			return new Vector2(r.center.x, r.yMin);
		case Direction.South:
			return new Vector2(r.xMin, r.center.y);
		case Direction.West:
			return new Vector2(r.center.x, r.yMax);
		default:
			return new Vector2(0f, 0f);
		}
	}

	public static bool IsOpposite(this Direction self, Direction other)
	{
		switch (self)
		{
		case Direction.North:
			return other == Direction.South;
		case Direction.East:
			return other == Direction.West;
		case Direction.South:
			return other == Direction.North;
		case Direction.West:
			return other == Direction.East;
		default:
			return false;
		}
	}

	public static Direction ToOpposite(this Direction self)
	{
		switch (self)
		{
		case Direction.North:
			return Direction.South;
		case Direction.East:
			return Direction.West;
		case Direction.South:
			return Direction.North;
		case Direction.West:
			return Direction.East;
		default:
			return Direction.None;
		}
	}

	public static StringBuilder AppendLine(this StringBuilder sb, string value, int fontSize)
	{
		return sb.AppendLine(value.FontSize(fontSize));
	}

	public static StringBuilder AppendLine(this StringBuilder sb, string value, int fontSize, Color fontColor)
	{
		return sb.AppendLine(value.FontSize(fontSize).FontColor(fontColor));
	}

	public static bool IsOnScreen(this Vector3 v, int offset = 0)
	{
		Vector3 vector = CameraScript.Instance.SSAScript.WorldToScreenPoint(v);
		if (vector.z >= 0f && vector.x >= (float)(-offset) && vector.x <= (float)(Screen.width + offset) && vector.y >= (float)(-offset))
		{
			return vector.y <= (float)(Screen.height + offset);
		}
		return false;
	}

	public static T GetClampedIndex<T>(this IList<T> arr, int idx)
	{
		if (idx < 0)
		{
			return arr[0];
		}
		if (idx < arr.Count)
		{
			return arr[idx];
		}
		return arr[arr.Count - 1];
	}

	public static T GetIndexWhere<T>(this IList<T> l, int i, Func<T, bool> pred)
	{
		int num = 0;
		for (int j = 0; j < l.Count; j++)
		{
			if (pred(l[j]))
			{
				if (num == i)
				{
					return l[j];
				}
				num++;
			}
		}
		return default(T);
	}

	public static int FindIndexWhere<T>(this IList<T> l, Func<T, bool> pred, Func<T, bool> match)
	{
		int num = 0;
		for (int i = 0; i < l.Count; i++)
		{
			if (pred(l[i]))
			{
				if (match(l[i]))
				{
					return num;
				}
				num++;
			}
		}
		return -1;
	}

	public static int FindIndex<T>(this IEnumerable<T> l, Func<T, bool> match)
	{
		int num = 0;
		foreach (T item in l)
		{
			if (match(item))
			{
				return num;
			}
			num++;
		}
		return -1;
	}

	public static int FindIndex<T>(this IList<T> l, T match)
	{
		for (int i = 0; i < l.Count; i++)
		{
			T val = l[i];
			if (val != null && val.Equals(match))
			{
				return i;
			}
		}
		return -1;
	}

	public static bool AnyOf<T2>(this IEnumerable e, Func<T2, bool> pred) where T2 : class
	{
		foreach (object item in e)
		{
			T2 arg;
			if ((arg = item as T2) != null && pred(arg))
			{
				return true;
			}
		}
		return false;
	}

	public static Dictionary<T1, T2> ToDictionaryOverwrite<T1, T2, T3>(this IEnumerable<T3> l, Func<T3, T1> key, Func<T3, T2> value)
	{
		Dictionary<T1, T2> dictionary = new Dictionary<T1, T2>();
		foreach (T3 item in l)
		{
			dictionary[key(item)] = value(item);
		}
		return dictionary;
	}

	public static Vector3 RotatePerAxis(this Quaternion q, Vector3 v)
	{
		return q * new Vector3(v.x, 0f, 0f) + q * new Vector3(0f, v.y, 0f) + q * new Vector3(0f, 0f, v.z);
	}

	public static void IndexToBool(this IList<int> l, IList<bool> o)
	{
		for (int i = 0; i < o.Count; i++)
		{
			o[i] = false;
		}
		for (int j = 0; j < l.Count; j++)
		{
			o[l[j]] = true;
		}
	}

	public static int GetActiveChildCount(this Transform t, Transform ignore = null)
	{
		int num = 0;
		for (int i = 0; i < t.childCount; i++)
		{
			Transform child = t.GetChild(i);
			if (child != ignore && child.gameObject.activeSelf)
			{
				num++;
			}
		}
		return num;
	}

	public static ulong GetRandomBit(ulong v)
	{
		ulong num = v - ((v >> 1) & 0x5555555555555555L);
		ulong num2 = (num & 0x3333333333333333L) + ((num >> 2) & 0x3333333333333333L);
		ulong num3 = (num2 + (num2 >> 4)) & 0xF0F0F0F0F0F0F0FL;
		ulong num4 = (num3 + (num3 >> 8)) & 0xFF00FF00FF00FFL;
		ulong num5 = (num4 >> 32) + (num4 >> 48);
		int num6 = (int)(num3 * 72340172838076673L >> 56);
		ulong num7 = (ulong)RNG.Next(1, num6 + 1);
		ulong num8 = 64uL;
		num8 -= ((num5 - num7) & 0x100) >> 3;
		num7 -= num5 & (num5 - num7 >> 8);
		num5 = (num4 >> (int)(num8 - 16)) & 0xFF;
		num8 -= ((num5 - num7) & 0x100) >> 4;
		num7 -= num5 & (num5 - num7 >> 8);
		num5 = (num3 >> (int)(num8 - 8)) & 0xF;
		num8 -= ((num5 - num7) & 0x100) >> 5;
		num7 -= num5 & (num5 - num7 >> 8);
		num5 = (num2 >> (int)(num8 - 4)) & 7;
		num8 -= ((num5 - num7) & 0x100) >> 6;
		num7 -= num5 & (num5 - num7 >> 8);
		num5 = (num >> (int)(num8 - 2)) & 3;
		num8 -= ((num5 - num7) & 0x100) >> 7;
		num7 -= num5 & (num5 - num7 >> 8);
		num5 = (v >> (int)(num8 - 1)) & 1;
		num8 -= ((num5 - num7) & 0x100) >> 8;
		num8--;
		return (ulong)(1L << (int)num8);
	}

	public static void InitTraitUI(Employee.Trait traits, UITrait[] ui)
	{
		int num = 0;
		int num2 = 1;
		ulong num3 = (ulong)traits;
		int num4 = 0;
		ui.ForEachEnum(delegate(UITrait x)
		{
			x.gameObject.SetActive(false);
		});
		for (int num5 = 0; num5 < 64; num5++)
		{
			if ((num3 & 1) != 0L)
			{
				Employee.Trait trait = (Employee.Trait)(1L << num5);
				if ((Employee.Trait.FastLearner | Employee.Trait.Independant | Employee.Trait.BigBrain | Employee.Trait.Humble | Employee.Trait.Capacitor | Employee.Trait.WalkItOff | Employee.Trait.ThisIsFine | Employee.Trait.Sunshine | Employee.Trait.Skyscraper | Employee.Trait.RGBThumb | Employee.Trait.Clean).HasBits(trait))
				{
					int num6 = Mathf.Min(ui.Length - 1, num);
					ui[num6].SetTrait(trait);
					ui[num6].gameObject.SetActive(true);
					num += 2;
				}
				else if ((Employee.Trait.Stressed | Employee.Trait.Hypochondriac | Employee.Trait.SlowEater | Employee.Trait.NervousBladder | Employee.Trait.BumLeg | Employee.Trait.Forgetful | Employee.Trait.Cupholder | Employee.Trait.NeatFreak | Employee.Trait.SilentButDeadly | Employee.Trait.WalkInstead | Employee.Trait.UnderTheWeather | Employee.Trait.Claustrophobic).HasBits(trait))
				{
					int num7 = Mathf.Min(ui.Length - 1, num2);
					ui[num7].SetTrait(trait);
					ui[num7].gameObject.SetActive(true);
					num2 += 2;
				}
				else if (Employee.Trait.OldSole.HasBits(trait))
				{
					int num8 = ui.Length - 1;
					ui[num8].SetTrait(trait);
					ui[num8].gameObject.SetActive(true);
				}
				else
				{
					int num9 = Mathf.Min(ui.Length - 1, 2);
					ui[num9].SetTrait(trait);
					ui[num9].gameObject.SetActive(true);
				}
				num4++;
				if (num4 == ui.Length)
				{
					break;
				}
			}
			num3 >>= 1;
		}
	}

	public static bool GetRandomChance(SDateTime time, string name, int seed, int chance)
	{
		return (name + seed + time.Hour + time.Day + time.Month + time.Year).GetHashCode() % chance == 0;
	}

	public static float GetRandomNumber(string name, int seed)
	{
		return (float)Mathf.Abs((name + seed).GetHashCode() % 1024) / 1023f;
	}

	public static bool HasBits(this Employee.Trait a, Employee.Trait b)
	{
		return (a & b) == b;
	}

	public static T[] Resize<T>(this T[] l, int newSize)
	{
		if (l != null && l.Length == newSize)
		{
			return l;
		}
		T[] array = new T[newSize];
		if (l != null)
		{
			int num = Mathf.Min(l.Length, newSize);
			for (int i = 0; i < num; i++)
			{
				array[i] = l[i];
			}
		}
		return array;
	}

	public static uint GetUHash(this string s)
	{
		int hashCode = s.GetHashCode();
		return (uint)hashCode;
	}

	public static uint AddIntClamped(this uint x, int y)
	{
		if (y < 0)
		{
			if (-y > x)
			{
				return 0u;
			}
			return x - (uint)(-y);
		}
		return x + (uint)y;
	}

	public static Vector3[] GetBlendVertices(this Mesh m, int idx, Vector3[] output = null)
	{
		if (output == null)
		{
			output = new Vector3[m.vertexCount];
		}
		m.GetBlendShapeFrameVertices(idx, 0, output, null, null);
		return output;
	}

	public static Dictionary<HRManagement.EdNeed, int> GetNeed(this Dictionary<HRManagement.EdNeed, int>[] needs, Employee.EmployeeRole r)
	{
		return needs[(int)(r - 1)];
	}

	public static void InitializeDemands(Employee emp, Transform panel)
	{
		int num = 0;
		LeadDesignDemands.Demand demand = ((emp.MyActor != null) ? emp.MyActor.BreachedDemands : LeadDesignDemands.Demand.Fire);
		if (emp.DemandsMet != 0)
		{
			if (emp.UpfrontDemand > 0f)
			{
				InitializeDemand(panel.GetChild(0).gameObject, emp.UpfrontDemand);
				num++;
			}
			foreach (LeadDesignDemands.Demand item in Enum.GetValues(typeof(LeadDesignDemands.Demand)).Cast<LeadDesignDemands.Demand>())
			{
				if (item != LeadDesignDemands.Demand.Fire && (emp.DemandResults & item) != LeadDesignDemands.Demand.Fire)
				{
					if (num < panel.childCount)
					{
						InitializeDemand(panel.GetChild(num).gameObject, item, (item & demand) > LeadDesignDemands.Demand.Fire);
					}
					else
					{
						GameObject gameObject = UnityEngine.Object.Instantiate(panel.GetChild(0).gameObject);
						gameObject.transform.SetParent(panel, false);
						InitializeDemand(gameObject, item, (item & demand) > LeadDesignDemands.Demand.Fire);
					}
					num++;
				}
			}
		}
		for (int i = num; i < panel.childCount; i++)
		{
			panel.GetChild(i).gameObject.SetActive(false);
		}
	}

	public static void InitializeDemands(LeadDesignDemands.Demand[] demands, Transform panel, LeadDesignDemands.Demand breached)
	{
		int num = 0;
		if (demands.Length != 0)
		{
			foreach (LeadDesignDemands.Demand demand in demands)
			{
				if (demand != LeadDesignDemands.Demand.Fire)
				{
					if (num < panel.childCount)
					{
						InitializeDemand(panel.GetChild(num).gameObject, demand, (demand & breached) > LeadDesignDemands.Demand.Fire);
					}
					else
					{
						GameObject gameObject = UnityEngine.Object.Instantiate(panel.GetChild(0).gameObject);
						gameObject.transform.SetParent(panel, false);
						InitializeDemand(gameObject, demand, (demand & breached) > LeadDesignDemands.Demand.Fire);
					}
					num++;
				}
			}
		}
		for (int j = num; j < panel.childCount; j++)
		{
			panel.GetChild(j).gameObject.SetActive(false);
		}
	}

	private static void InitializeDemand(GameObject prefab, LeadDesignDemands.Demand demand, bool breached)
	{
		prefab.gameObject.SetActive(true);
		prefab.GetComponent<GUIToolTipper>().TooltipDescription = string.Concat("LeadDemand", demand, "Tip");
		prefab.GetComponentInChildren<Text>().text = ("LeadDemand" + demand).Loc();
		prefab.GetComponent<Image>().color = (breached ? Color.red : Color.white);
	}

	private static void InitializeDemand(GameObject prefab, float upfront)
	{
		prefab.gameObject.SetActive(true);
		prefab.GetComponent<GUIToolTipper>().TooltipDescription = "LeadDemandUpfrontTip";
		prefab.GetComponentInChildren<Text>().text = upfront.Currency();
	}

	public static void Shuffle<T>(this IList<T> list, System.Random rng = null)
	{
		rng = rng ?? RNG;
		int num = list.Count;
		while (num > 1)
		{
			num--;
			int index = rng.Next(num + 1);
			T value = list[index];
			list[index] = list[num];
			list[num] = value;
		}
	}

	public static Color Blink(Color c1, Color c2, float speed)
	{
		float num = Time.realtimeSinceStartup * speed % 2f;
		if (num > 1f)
		{
			num = 2f - num;
		}
		return Color.Lerp(c1, c2, num.InOutCurve());
	}

	public static float PingPong(this float v)
	{
		float num = v % 2f;
		if (num > 1f)
		{
			num = 2f - num;
		}
		return num;
	}

	public static Color MultColorPart(this Color c, float v)
	{
		return new Color(c.r * v, c.g * v, c.b * v, c.a);
	}

	public static Quaternion LookDir(this Vector3 v)
	{
		return v.LookDir(Quaternion.identity);
	}

	public static Quaternion LookDir(this Vector3 v, Quaternion def)
	{
		if (!(v != Vector3.zero))
		{
			return def;
		}
		return Quaternion.LookRotation(v);
	}

	public static Quaternion LookDir(this Vector3 v, Vector3 up, Quaternion def)
	{
		if (!(v != Vector3.zero))
		{
			return def;
		}
		return Quaternion.LookRotation(v, up);
	}

	public static void LeadDesignerIP(SoftwareProduct IP, Action ifBought = null)
	{
		if (IP.LeadDesigner == null)
		{
			IP.DesignerOwned = false;
			Action action = ifBought;
			if (action != null)
			{
				action();
			}
		}
		else if (IP.LeadDesigner.Retired)
		{
			IPDeal deal = new IPDeal(IP, true);
			WindowManager.Instance.ShowMessageBox("LeadDesignerOwnerSpecificWarning".LocColor(IP.LeadDesigner) + ".\n" + "LeadDesignerBuyIP".Loc(deal.Worth().Currency()), true, DialogWindow.DialogType.Question, delegate
			{
				UISoundFX.PlaySFX("Kaching");
				deal.BuyFromDesigner(GameSettings.Instance.MyCompany);
				Action action2 = ifBought;
				if (action2 != null)
				{
					action2();
				}
			});
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("LeadDesignerOwnerSpecificWarning".LocColor(IP.LeadDesigner), true, DialogWindow.DialogType.Error);
		}
	}

	public static int FastestIncrement(int a, int b, int n)
	{
		if (b > a)
		{
			if (b - a > n / 2)
			{
				return -1;
			}
			return 1;
		}
		if (a > b)
		{
			if (a - b > n / 2)
			{
				return 1;
			}
			return -1;
		}
		return 0;
	}

	public static int GetMinIndex<T>(this IList<T> l, Func<T, float> eval)
	{
		int result = -1;
		float num = float.MaxValue;
		for (int i = 0; i < l.Count; i++)
		{
			float num2 = eval(l[i]);
			if (num2 < num)
			{
				num = num2;
				result = i;
			}
		}
		return result;
	}

	public static int GetMinIndex<T>(this IList<T> l, Func<T, byte> eval)
	{
		int result = -1;
		int num = 256;
		for (int i = 0; i < l.Count; i++)
		{
			byte b = eval(l[i]);
			if (b < num)
			{
				num = b;
				result = i;
			}
		}
		return result;
	}

	public static IEnumerable<T2> UnZip<T1, T2>(this IEnumerable<T1> l, Func<T1, T2> selector1, Func<T1, T2> selector2)
	{
		foreach (T1 i in l)
		{
			yield return selector1(i);
			yield return selector2(i);
		}
	}

	public static TydNode FindNode(this TydNode root, string path, bool create = false, bool table = true)
	{
		string[] array = path.Split('/');
		for (int i = 0; i < array.Length; i++)
		{
			TydCollection tydCollection;
			if ((tydCollection = root as TydCollection) != null)
			{
				TydNode tydNode = tydCollection.GetChild(array[i]);
				if (tydNode == null)
				{
					if (!create)
					{
						break;
					}
					tydNode = tydCollection.AddChild((TydNode)(table ? ((TydCollection)new TydTable(array[i])) : ((TydCollection)new TydList(array[i]))));
				}
				root = tydNode;
				continue;
			}
			return null;
		}
		return root;
	}

	public static bool RemoveNode(this TydNode root, string path)
	{
		string[] array = path.Split('/');
		TydCollection tydCollection = null;
		for (int i = 0; i < array.Length; i++)
		{
			tydCollection = root as TydCollection;
			if (tydCollection != null)
			{
				TydNode child = tydCollection.GetChild(array[i]);
				if (child == null)
				{
					return false;
				}
				root = child;
				continue;
			}
			return false;
		}
		if (tydCollection != null)
		{
			return tydCollection.Nodes.Remove(root);
		}
		return false;
	}

	public static void SetNode(this TydNode root, string path, string value, bool create = false)
	{
		string[] array = path.Split('/');
		for (int i = 0; i < array.Length; i++)
		{
			TydCollection tydCollection;
			if ((tydCollection = root as TydCollection) == null)
			{
				return;
			}
			TydNode tydNode = tydCollection.GetChild(array[i]);
			if (tydNode == null)
			{
				if (!create)
				{
					break;
				}
				if (i == array.Length - 1)
				{
					tydCollection.AddChild(new TydString(array[i], value));
					return;
				}
				tydNode = tydCollection.AddChild(new TydTable(array[i]));
			}
			root = tydNode;
		}
		TydString tydString;
		if ((tydString = root as TydString) != null)
		{
			tydString.Value = value;
		}
	}

	public static void SetNode(this TydNode root, string path, TydNode value, int idx = -1)
	{
		string[] array = path.Split('/');
		for (int i = 0; i < array.Length; i++)
		{
			TydCollection tydCollection;
			if ((tydCollection = root as TydCollection) == null)
			{
				break;
			}
			TydNode child = tydCollection.GetChild(array[i]);
			if (child == null)
			{
				if (i == array.Length - 1)
				{
					if (idx >= 0)
					{
						tydCollection.InsertChild(value, idx);
					}
					else
					{
						tydCollection.AddChild(value);
					}
				}
				break;
			}
			if (i == array.Length - 1)
			{
				tydCollection.Nodes.Remove(child);
				if (idx >= 0)
				{
					tydCollection.InsertChild(value, idx);
				}
				else
				{
					tydCollection.AddChild(value);
				}
			}
			root = child;
		}
	}

	public static void RemoveElement<T>(ref T[] ar, T obj)
	{
		if (ar.Length == 0)
		{
			return;
		}
		T[] array = new T[ar.Length - 1];
		int num = 0;
		for (int i = 0; i < ar.Length; i++)
		{
			if (!ar[i].Equals(obj))
			{
				if (num >= array.Length)
				{
					return;
				}
				array[num] = ar[i];
				num++;
			}
		}
		ar = array;
	}

	public static void AddElement<T>(ref T[] ar, T obj)
	{
		T[] array = new T[ar.Length + 1];
		for (int i = 0; i < ar.Length; i++)
		{
			array[i] = ar[i];
		}
		array[ar.Length] = obj;
		ar = array;
	}

	public static void AddElement<T>(ref T[] ar, int index, T obj)
	{
		T[] array = new T[ar.Length + 1];
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (i == index)
			{
				array[i] = obj;
				continue;
			}
			array[i] = ar[num];
			num++;
		}
		ar = array;
	}

	public static object GetDefault(this Type type, bool instantiate)
	{
		if (type.IsValueType)
		{
			return Activator.CreateInstance(type);
		}
		if (!instantiate)
		{
			return null;
		}
		return type.GetConstructor(new Type[0]).Invoke(null);
	}

	public static string GetWatt(this double value, bool hour)
	{
		return ((float)value).GetWatt(hour);
	}

	public static string GetWatt(this float value, bool hour)
	{
		if (value >= 1000f)
		{
			float num = value / 1000f;
			if (num >= 1000f)
			{
				num /= 1000f;
				if (num >= 1000f)
				{
					return (num / 1000f).ToString("0.#") + " " + (hour ? "GigaWattHour" : "GigaWatt").Loc();
				}
				return num.ToString("0.#") + " " + (hour ? "MegaWattHour" : "MegaWatt").Loc();
			}
			return num.ToString("0.#") + " " + (hour ? "KiloWattHour" : "KiloWatt").Loc();
		}
		return value.ToString("0") + " " + (hour ? "WattHour" : "Watt").Loc();
	}

	public static T[] SortInPlace<T>(T[] arr, IComparer sort)
	{
		Array.Sort(arr, sort);
		return arr;
	}

	public static float DistanceToClosestCorner(this Rect r, Vector2 p)
	{
		float num = Mathf.Min(Mathf.Abs(r.xMin - p.x), Mathf.Abs(r.xMax - p.x));
		float num2 = Mathf.Min(Mathf.Abs(r.yMin - p.y), Mathf.Abs(r.yMax - p.y));
		return Mathf.Sqrt(num * num + num2 * num2);
	}

	public static void DrawDebug(this Rect r, Color c, float duration)
	{
		UnityEngine.Debug.DrawLine(new Vector3(r.xMin, 0f, r.yMin), new Vector3(r.xMax, 0f, r.yMin), c, duration);
		UnityEngine.Debug.DrawLine(new Vector3(r.xMax, 0f, r.yMin), new Vector3(r.xMax, 0f, r.yMax), c, duration);
		UnityEngine.Debug.DrawLine(new Vector3(r.xMax, 0f, r.yMax), new Vector3(r.xMin, 0f, r.yMax), c, duration);
		UnityEngine.Debug.DrawLine(new Vector3(r.xMin, 0f, r.yMax), new Vector3(r.xMin, 0f, r.yMin), c, duration);
	}

	public static float GetTriangleAreaSquared(Vector2 p1, Vector2 p2, Vector2 p3)
	{
		float magnitude = (p1 - p2).magnitude;
		float magnitude2 = (p2 - p3).magnitude;
		float magnitude3 = (p3 - p1).magnitude;
		float num = (magnitude + magnitude2 + magnitude3) / 2f;
		return num * (num - magnitude) * (num - magnitude2) * (num - magnitude3);
	}

	public static float GetTriangleArea(Vector2 p1, Vector2 p2, Vector2 p3)
	{
		return Mathf.Sqrt(GetTriangleAreaSquared(p1, p2, p3));
	}

	public static int RaycastTriangle(int[] tris, Vector3[] verts, Matrix4x4 mat, Ray mr)
	{
		float num = float.MaxValue;
		int result = -1;
		for (int i = 0; i < tris.Length; i += 3)
		{
			Vector3 p = mat.MultiplyPoint(verts[tris[i]]);
			Vector3 p2 = mat.MultiplyPoint(verts[tris[i + 1]]);
			Vector3 p3 = mat.MultiplyPoint(verts[tris[i + 2]]);
			float dist;
			if (TestTriangleIntersection(p, p2, p3, mr, out dist) && dist < num)
			{
				num = dist;
				result = i;
			}
		}
		return result;
	}

	public static int RaycastTriangle(IList<int> tris, IList<Vector3> verts, Matrix4x4 mat, Ray mr, out Vector3 hit)
	{
		float num = float.MaxValue;
		int num2 = -1;
		hit = Vector3.zero;
		Vector2 vector = Vector2.zero;
		for (int i = 0; i < tris.Count; i += 3)
		{
			Vector3 p = mat.MultiplyPoint(verts[tris[i]]);
			Vector3 p2 = mat.MultiplyPoint(verts[tris[i + 1]]);
			Vector3 p3 = mat.MultiplyPoint(verts[tris[i + 2]]);
			float dist;
			Vector2 baryCoord;
			if (TestTriangleIntersection(p, p2, p3, mr, out dist, out baryCoord) && dist < num)
			{
				num = dist;
				num2 = i;
				vector = baryCoord;
			}
		}
		if (num2 >= 0)
		{
			float num3 = 1f - (vector.x + vector.y);
			hit = mat.MultiplyPoint(verts[tris[num2]] * vector.x + verts[tris[num2 + 1]] * vector.y + verts[tris[num2 + 2]] * num3);
		}
		return num2;
	}

	public static bool TestTriangleIntersection(Vector3 p1, Vector3 p2, Vector3 p3, Ray ray, out float dist)
	{
		dist = float.PositiveInfinity;
		Vector3 vector = p2 - p1;
		Vector3 vector2 = p3 - p1;
		Vector3 rhs = Vector3.Cross(ray.direction, vector2);
		float num = Vector3.Dot(vector, rhs);
		if (num < 0.0001f)
		{
			return false;
		}
		Vector3 lhs = ray.origin - p1;
		float num2 = Vector3.Dot(lhs, rhs);
		if (num2 < 0f || num2 > num)
		{
			return false;
		}
		Vector3 rhs2 = Vector3.Cross(lhs, vector);
		float num3 = Vector3.Dot(ray.direction, rhs2);
		if (num3 < 0f || num2 + num3 > num)
		{
			return false;
		}
		dist = Vector3.Dot(vector2, rhs2);
		float num4 = 1f / num;
		dist *= num4;
		return true;
	}

	public static bool TestTriangleIntersection(Vector3 p1, Vector3 p2, Vector3 p3, Ray ray, out float dist, out Vector2 baryCoord)
	{
		dist = float.PositiveInfinity;
		Vector3 vector = p2 - p1;
		Vector3 vector2 = p3 - p1;
		baryCoord = Vector2.zero;
		Vector3 rhs = Vector3.Cross(ray.direction, vector2);
		float num = Vector3.Dot(vector, rhs);
		if (num < 1E-07f)
		{
			return false;
		}
		Vector3 lhs = ray.origin - p1;
		float num2 = Vector3.Dot(lhs, rhs);
		if (num2 < 0f || num2 > num)
		{
			return false;
		}
		Vector3 rhs2 = Vector3.Cross(lhs, vector);
		float num3 = Vector3.Dot(ray.direction, rhs2);
		if (num3 < 0f || num2 + num3 > num)
		{
			return false;
		}
		dist = Vector3.Dot(vector2, rhs2);
		float num4 = 1f / num;
		dist *= num4;
		baryCoord = new Vector2(num2 * num4, num3 * num4);
		return true;
	}

	public static float ProjectRayOnRay(Ray r, Ray t)
	{
		Vector3 lhs = t.origin - r.origin;
		float num = Vector3.Dot(r.direction, r.direction);
		float num2 = Vector3.Dot(t.direction, t.direction);
		float num3 = Vector3.Dot(t.direction, r.direction);
		float num4 = Vector3.Dot(lhs, r.direction);
		float num5 = Vector3.Dot(lhs, t.direction);
		float num6 = num3 * num3 - num * num2;
		if (Mathf.Approximately(num6, 0f))
		{
			return (0f - num4) / num3;
		}
		return ((0f - num4) * num3 + num2 * num5) / num6;
	}

	public static void InsertResize<T>(this List<T> l, int index, T element)
	{
		for (int i = l.Count; i <= index; i++)
		{
			l.Add(default(T));
		}
		l[index] = element;
	}

	public static void RemoveDuplicates<T>(this IList<T> l)
	{
		for (int i = 0; i < l.Count; i++)
		{
			for (int j = i + 1; j < l.Count - 1; j++)
			{
				if (l[i].Equals(l[j]))
				{
					l.RemoveAt(j);
					j--;
				}
			}
		}
	}

	public static void UpdateParentOfFurniture(this IList<Furniture> f, bool reverseSnap, List<UndoObject.UndoAction> undos = null)
	{
		if (f.Count <= 0)
		{
			return;
		}
		_updateFurnParentCache.Clear();
		_updateFurnParentCache.AddRange(f);
		if (undos != null)
		{
			if (reverseSnap)
			{
				_updateFurnParentCache.Sort((Furniture x, Furniture y) => y.GetSnappingDepth().CompareTo(x.GetSnappingDepth()));
			}
			else
			{
				_updateFurnParentCache.Sort((Furniture x, Furniture y) => x.GetSnappingDepth().CompareTo(y.GetSnappingDepth()));
			}
		}
		for (int num = 0; num < _updateFurnParentCache.Count; num++)
		{
			Furniture furniture = _updateFurnParentCache[num];
			if (!furniture.IsAliveNotNull())
			{
				continue;
			}
			if (!furniture.UpdateParent())
			{
				if (undos == null)
				{
					continue;
				}
				undos.Add(new UndoObject.UndoAction(furniture, false));
				foreach (Furniture item in furniture.IterateSnap())
				{
					if (item.IsAliveNotNull())
					{
						undos.Add(new UndoObject.UndoAction(item, false));
						item.DestroyGO();
					}
				}
				continue;
			}
			foreach (Furniture item2 in furniture.IterateSnap())
			{
				if (item2.Parent != furniture.Parent)
				{
					if (item2.Parent != null)
					{
						item2.Parent.RemoveFurniture(item2);
					}
					item2.Parent = furniture.Parent;
					if (item2.Parent != null)
					{
						item2.Parent.AddFurniture(item2);
					}
				}
			}
		}
	}

	public static T1 LookupKey<T1, T2>(this Dictionary<T1, T2> d, T2 value)
	{
		foreach (KeyValuePair<T1, T2> item in d)
		{
			if (item.Value.Equals(value))
			{
				return item.Key;
			}
		}
		return default(T1);
	}

	public static bool IsAliveNotNull(this Writeable w)
	{
		if (!w.IsReferenceNull())
		{
			return w.IsGOActive;
		}
		return false;
	}

	public static float WorldToUIDirection(Vector3 v1, Vector3 v2)
	{
		Vector3 vector = CameraScript.Instance.SSAScript.WorldToScreenPoint(v1);
		Vector3 vector2 = CameraScript.Instance.SSAScript.WorldToScreenPoint(v2);
		Vector3 vector3 = vector - vector2;
		return Mathf.Atan2(vector3.y, vector3.x) * 57.29578f;
	}

	public static string UIDirectionToIcon(float angle)
	{
		if (angle < 0f)
		{
			angle += 360f;
		}
		switch (Mathf.RoundToInt(angle % 360f / 45f) % 4)
		{
		case 0:
			return "HorizontalStretch";
		case 1:
			return "DiagonalStretchInvert";
		case 2:
			return "VerticalStretch";
		case 3:
			return "DiagonalStretch";
		default:
			return "Default";
		}
	}

	public static bool TryGetFirst<T>(this IList<T> l, Func<T, bool> pred, out T r)
	{
		r = default(T);
		for (int i = 0; i < l.Count; i++)
		{
			if (pred(l[i]))
			{
				r = l[i];
				return true;
			}
		}
		return false;
	}

	public static bool RemoveFirst<T>(this IList<T> l, Func<T, bool> pred)
	{
		for (int i = 0; i < l.Count; i++)
		{
			if (pred(l[i]))
			{
				l.RemoveAt(i);
				return true;
			}
		}
		return false;
	}

	public static Color GetDefaultSecondaryColor(this Color c)
	{
		return new SVector3(c.r * 0.5f, c.g * 0.5f, c.b * 0.5f, c.a);
	}

	public static float Clamp(this float x, float a = 0f, float b = 1f)
	{
		return Mathf.Clamp(x, a, b);
	}

	public static bool EqualsNull<T>(this T o, T o2) where T : class
	{
		if (o == null)
		{
			return o2 == null;
		}
		if (o2 != null)
		{
			return o.Equals(o2);
		}
		return false;
	}

	public static bool EqualsEmpty(this string o, string o2)
	{
		if (string.IsNullOrEmpty(o))
		{
			return string.IsNullOrEmpty(o2);
		}
		if (!string.IsNullOrEmpty(o2))
		{
			return o.Equals(o2);
		}
		return false;
	}

	public static bool FixedOverlaps(this Rect r1, Rect r2)
	{
		if (!(r1.xMin > r2.xMin + r2.width) && !(r1.xMin + r1.width < r2.xMin) && !(r1.yMin > r2.yMin + r2.height))
		{
			return !(r1.yMin + r1.height < r2.yMin);
		}
		return false;
	}

	public static Rect RectCenterSize(Vector2 center, Vector2 size)
	{
		return new Rect(center - size * 0.5f, size);
	}

	public static Rect FixNegativeSize(this Rect r)
	{
		float num = r.xMin;
		float num2 = r.xMax;
		float num3 = r.yMin;
		float num4 = r.yMax;
		if (r.width < 0f)
		{
			float num5 = num2;
			float num6 = num;
			num = num5;
			num2 = num6;
		}
		if (r.height < 0f)
		{
			float num7 = num4;
			float num6 = num3;
			num3 = num7;
			num4 = num6;
		}
		return new Rect(num, num3, num2 - num, num4 - num3);
	}

	public static Vector2 RotateFlat(this Vector2 v, Quaternion q)
	{
		return (q * v.ToVector3(0f)).FlattenVector3();
	}

	public static bool IsWork(this WorkItem.HasWorkReturn w)
	{
		if (w != WorkItem.HasWorkReturn.True)
		{
			return w == WorkItem.HasWorkReturn.Secondary;
		}
		return true;
	}

	public static float FixAngleDegrees(this float angle)
	{
		if (angle >= 0f)
		{
			return angle % 360f;
		}
		return 360f - Mathf.Abs(angle) % 360f;
	}

	public static Vector4 ToVector(this Rect r)
	{
		return new Vector4(r.xMin, r.yMin, r.width, r.height);
	}

	public static string ReceiveString(this UdpClient client, ref IPEndPoint remoteEndPoint)
	{
		return Encoding.UTF8.GetString(client.Receive(ref remoteEndPoint));
	}

	public static void SendString(this UdpClient client, string text, IPEndPoint remoteEndPoint)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(text);
		client.Send(bytes, bytes.Length, remoteEndPoint);
	}

	public static IEnumerable<T3> Unwind<T1, T2, T3>(this Dictionary<T1, T2> dict, Func<T1, T3> convKey, Func<T2, T3> convValue)
	{
		foreach (KeyValuePair<T1, T2> pair in dict)
		{
			yield return convKey(pair.Key);
			yield return convValue(pair.Value);
		}
	}

	public static Dictionary<T1, T2> WindUp<T1, T2, T3>(this IEnumerable<T3> l, Func<T3, T1> convKey, Func<T3, T2> convValue)
	{
		Dictionary<T1, T2> dictionary = new Dictionary<T1, T2>();
		using (IEnumerator<T3> enumerator = l.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				T1 key = convKey(enumerator.Current);
				if (!enumerator.MoveNext())
				{
					break;
				}
				dictionary[key] = convValue(enumerator.Current);
			}
		}
		return dictionary;
	}

	public static void FixMyReferences<T>(this T[] l) where T : IReferenceFix
	{
		if (l == null)
		{
			return;
		}
		int num;
		object obj;
		for (int i = 0; i < l.Length; l[num] = (T)obj, i++)
		{
			num = i;
			ref readonly T reference = ref l[i];
			T val = default(T);
			if (val == null)
			{
				val = reference;
				reference = ref val;
				if (val == null)
				{
					obj = null;
					continue;
				}
			}
			obj = reference.FixReferences();
		}
	}

	public static List<T> FixMyReferences<T>(this List<T> l, bool removeNull) where T : IReferenceFix
	{
		if (l != null)
		{
			for (int num = 0; num < l.Count; num++)
			{
				T val = l[num];
				ref T reference = ref val;
				T val2 = default(T);
				object obj;
				if (val2 == null)
				{
					val2 = reference;
					reference = ref val2;
					if (val2 == null)
					{
						obj = null;
						goto IL_0040;
					}
				}
				obj = reference.FixReferences();
				goto IL_0040;
				IL_0040:
				T val3 = (T)obj;
				if (!removeNull || val3 != null)
				{
					l[num] = val3;
				}
				else
				{
					l.RemoveAt(num);
					num--;
				}
			}
		}
		return l;
	}

	public static Dictionary<T1, T2> FixKeyReferences<T1, T2>(this IDictionary<T1, T2> l, bool removeNull) where T1 : IReferenceFix
	{
		if (l == null)
		{
			return null;
		}
		Dictionary<T1, T2> dictionary = new Dictionary<T1, T2>();
		foreach (KeyValuePair<T1, T2> item in l)
		{
			T1 val = (T1)item.Key.FixReferences();
			if (!removeNull || val != null)
			{
				dictionary[val] = item.Value;
			}
		}
		return dictionary;
	}

	public static Dictionary<T1, T2> FixValueReferences<T1, T2>(this IDictionary<T1, T2> l, bool removeNull) where T2 : IReferenceFix
	{
		if (l == null)
		{
			return null;
		}
		Dictionary<T1, T2> dictionary = new Dictionary<T1, T2>();
		foreach (KeyValuePair<T1, T2> item in l)
		{
			T2 val = (T2)item.Value.FixReferences();
			if (!removeNull || val != null)
			{
				dictionary[item.Key] = val;
			}
		}
		return dictionary;
	}

	public static KeyValuePair<TKey, TValue> ToKeyValuePair<TKey, TValue>(this ValueTuple<TKey, TValue> input)
	{
		return new KeyValuePair<TKey, TValue>(input.Item1, input.Item2);
	}

	public static string GetString(this TimeSpan span)
	{
		if (span.TotalDays >= 365.0)
		{
			return "TimeAgo".Loc("Year".LocPlural(Math.Round(span.TotalDays / 365.0 * 10.0) / 10.0));
		}
		if (span.TotalHours >= 24.0)
		{
			return "TimeAgo".Loc("Day".LocPlural((int)Math.Floor(span.TotalHours / 24.0)));
		}
		if (span.TotalMinutes >= 60.0)
		{
			return "TimeAgo".Loc("Hour".LocPlural((int)Math.Floor(span.TotalMinutes / 60.0)));
		}
		if (span.TotalMinutes >= 1.0)
		{
			return "TimeAgo".Loc("Minute".LocPlural((int)Math.Floor(span.TotalMinutes)));
		}
		return "Now".Loc();
	}

	public static List<T> GetFlagSplit<T>(this T value, Func<T, T, bool> hasFlag)
	{
		List<T> list = new List<T>();
		foreach (T value2 in Enum.GetValues(typeof(T)))
		{
			if (hasFlag(value, value2))
			{
				list.Add(value2);
			}
		}
		return list;
	}

	public static Dictionary<TKey2, TValue2> ToDictionaryMerge<TKey, TValue, TKey2, TValue2>(this Dictionary<TKey, TValue> d, Func<KeyValuePair<TKey, TValue>, TKey2> keySelector, Func<KeyValuePair<TKey, TValue>, TValue2> valueSelector, Func<TValue2, TValue2, TValue2> merge)
	{
		if (d == null)
		{
			return null;
		}
		Dictionary<TKey2, TValue2> dictionary = new Dictionary<TKey2, TValue2>();
		foreach (KeyValuePair<TKey, TValue> item in d)
		{
			TKey2 key = keySelector(item);
			TValue2 value;
			if (dictionary.TryGetValue(key, out value))
			{
				dictionary[key] = merge(value, valueSelector(item));
			}
			else
			{
				dictionary[key] = valueSelector(item);
			}
		}
		return dictionary;
	}

	public static bool TryGetComponent<T>(this UnityEngine.Component behaviour, out T component)
	{
		component = behaviour.GetComponent<T>();
		return component != null;
	}

	public static IEnumerable<bool> ReadBits(IList<byte> input, int from)
	{
		for (int i = from; i < input.Count; i++)
		{
			byte b = input[i];
			for (int j = 0; j < 8; j++)
			{
				yield return (b & 1) > 0;
				b >>= 1;
			}
		}
	}

	public static byte[] WriteBits<T>(IList<T> input, Func<T, bool> conv)
	{
		byte[] array = new byte[Mathf.CeilToInt((float)input.Count / 8f)];
		for (int i = 0; i < input.Count; i++)
		{
			int num = (conv(input[i]) ? 1 : 0) << i % 8;
			array[i / 8] |= (byte)num;
		}
		return array;
	}

	public static void WriteBits<T>(IList<T> input, Func<T, bool> conv, Stream st)
	{
		if (input.Count == 0)
		{
			return;
		}
		byte b = 0;
		for (int i = 0; i < input.Count; i++)
		{
			if (i > 0 && i % 8 == 0)
			{
				st.WriteByte(b);
				b = 0;
			}
			int num = (conv(input[i]) ? 1 : 0) << i % 8;
			b |= (byte)num;
		}
		st.WriteByte(b);
	}

	public static Color Invert(this Color c)
	{
		return new Color(1f - c.r, 1f - c.g, 1f - c.b, c.a);
	}

	public static string[] SplitByNewLines(this string input, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
	{
		return input.Split(new string[3]
		{
			"\r\n",
			Environment.NewLine,
			"\n"
		}, options);
	}

	public static string CombinePaths(params string[] paths)
	{
		if (paths == null)
		{
			throw new ArgumentNullException("paths");
		}
		if (paths.Length == 0)
		{
			return "";
		}
		string text = paths[0];
		for (int i = 1; i < paths.Length; i++)
		{
			text = Path.Combine(text, paths[i]);
		}
		return text;
	}

	public static Rect GetAtlasRect(this Sprite sprite)
	{
		Rect textureRect = sprite.textureRect;
		int width = sprite.texture.width;
		int height = sprite.texture.height;
		return new Rect(textureRect.x / (float)width, textureRect.y / (float)height, textureRect.width / (float)width, textureRect.height / (float)height);
	}

	public static int CeilToInt(double d)
	{
		return (int)Math.Ceiling(d);
	}

	public static int FloorToInt(double d)
	{
		return (int)Math.Floor(d);
	}

	public static int RoundToInt(double d)
	{
		return (int)Math.Round(d);
	}

	public static double Clamp01(double v)
	{
		return v.Clamp(0.0, 1.0);
	}

	public static double Lerp(double a, double b, double t, bool clamp)
	{
		if (clamp && t > 1.0)
		{
			return b;
		}
		if (clamp && t < 0.0)
		{
			return a;
		}
		return (b - a) * t + a;
	}

	public static float[] ToFloats(this double[] data)
	{
		float[] array = new float[data.Length];
		for (int i = 0; i < data.Length; i++)
		{
			array[i] = (float)data[i];
		}
		return array;
	}

	public static double[] ToDoubles(this float[] data)
	{
		double[] array = new double[data.Length];
		for (int i = 0; i < data.Length; i++)
		{
			array[i] = data[i];
		}
		return array;
	}

	public static double ToDouble(this float val)
	{
		return val;
	}

	public static Color32 ToCorrectColor32(this Color color)
	{
		return new Color32((byte)Mathf.Clamp(Mathf.RoundToInt(color.r * 255f), 0, 255), (byte)Mathf.Clamp(Mathf.RoundToInt(color.g * 255f), 0, 255), (byte)Mathf.Clamp(Mathf.RoundToInt(color.b * 255f), 0, 255), (byte)Mathf.Clamp(Mathf.RoundToInt(color.a * 255f), 0, 255));
	}

	public static string XTimes(this float val)
	{
		return val.ToString("0.#") + "x";
	}

	public static int MapToShuffledIndex(int input, int length)
	{
		if (length - 1 >= _lengthPrimes.Length)
		{
			return input;
		}
		int num = _lengthPrimes[length - 1];
		int num2 = length / 2;
		return (num * input + num2) % length;
	}

	public static void ThreadSafeForEach<T>(this IList<T> l, Action<T> act)
	{
		lock (l)
		{
			for (int i = 0; i < l.Count; i++)
			{
				act(l[i]);
			}
		}
	}

	public static bool ThreadSafeAny<T>(this IList<T> l, Func<T, bool> pred)
	{
		lock (l)
		{
			for (int i = 0; i < l.Count; i++)
			{
				if (pred(l[i]))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static Vector3 JumpTrajectory(Vector3 start, Vector3 end, float t, float height, Vector3 up)
	{
		Vector3 vector = Vector3.Lerp(start, end, t);
		float num = 4f * t * (1f - t);
		return vector + up * (height * num);
	}

	public static Vector3 JumpTrajectory(Vector3 start, Vector3 end, float t, float height)
	{
		return JumpTrajectory(start, end, t, height, Vector3.up);
	}

	public static IEnumerable<T> RandomOrder<T>(this IList<T> list, System.Random rng = null)
	{
		if (list == null)
		{
			throw new ArgumentNullException("list");
		}
		int n = list.Count;
		if (n <= 1)
		{
			if (n == 1)
			{
				yield return list[0];
			}
			yield break;
		}
		rng = rng ?? RNG;
		int a;
		do
		{
			a = rng.Next(1, n);
		}
		while (GCD(a, n) != 1);
		int b = rng.Next(n);
		for (int i = 0; i < n; i++)
		{
			int index = (int)(((long)a * (long)i + b) % n);
			yield return list[index];
		}
	}

	private static int GCD(int x, int y)
	{
		while (y != 0)
		{
			int num = x % y;
			x = y;
			y = num;
		}
		return x;
	}

	public static bool OpenFolder(string path)
	{
		string text;
		try
		{
			text = Path.GetFullPath(path);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log("OpenFolder: Invalid path. " + ex.Message);
			return false;
		}
		if (File.Exists(text))
		{
			text = Path.GetDirectoryName(text);
		}
		if (string.IsNullOrEmpty(text) || !Directory.Exists(text))
		{
			UnityEngine.Debug.Log("OpenFolder: Directory does not exist: " + text);
			return false;
		}
		switch (Application.platform)
		{
		case RuntimePlatform.WindowsPlayer:
		case RuntimePlatform.WindowsEditor:
			return StartFProc("explorer.exe", "\"" + text + "\"");
		case RuntimePlatform.OSXEditor:
		case RuntimePlatform.OSXPlayer:
			return StartFProc("/usr/bin/open", "\"" + text + "\"");
		case RuntimePlatform.LinuxPlayer:
		case RuntimePlatform.LinuxEditor:
			if (StartFProc("xdg-open", "\"" + text + "\"") || StartFProc("gio", "open \"" + text + "\"") || StartFProc("gnome-open", "\"" + text + "\"") || StartFProc("kde-open5", "\"" + text + "\"") || StartFProc("kde-open", "\"" + text + "\"") || StartFProc("exo-open", "--launch FileManager \"" + text + "\""))
			{
				return true;
			}
			UnityEngine.Debug.Log("OpenFolder: Could not find a suitable opener (xdg-open/gio).");
			return false;
		default:
			UnityEngine.Debug.Log(string.Format("OpenFolder: Unsupported platform: {0}", Application.platform));
			return false;
		}
	}

	private static bool StartFProc(string fileName, string arguments)
	{
		try
		{
			Process process = Process.Start(new ProcessStartInfo
			{
				FileName = fileName,
				Arguments = arguments,
				UseShellExecute = false,
				CreateNoWindow = true
			});
			return process != null && (!process.WaitForExit(100) || process.ExitCode == 0);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log("OpenFolder: Failed launching with " + fileName + ": " + ex.Message);
			return false;
		}
	}

	public static void DrawCylinder(Vector3 center, float height, float radius, Action<Vector3, Vector3> drawLine, int segments = 32)
	{
		Gizmos.color = Color.yellow;
		Vector3 center2 = center + Vector3.up * height;
		Vector3 vector = center + Vector3.left * radius;
		Vector3 vector2 = center - Vector3.left * radius;
		Vector3 vector3 = center + Vector3.forward * radius;
		Vector3 vector4 = center - Vector3.forward * radius;
		DrawCircle(center, radius, drawLine);
		DrawCircle(center2, radius, drawLine);
		DrawCircle(center2, radius, drawLine);
		drawLine(vector, vector + Vector3.up * height);
		drawLine(vector2, vector2 + Vector3.up * height);
		drawLine(vector3, vector3 + Vector3.up * height);
		drawLine(vector4, vector4 + Vector3.up * height);
	}

	public static void DrawCircle(Vector3 center, float radius, Action<Vector3, Vector3> drawLine, int segments = 32, Vector3? normal = null)
	{
		if (segments < 3)
		{
			segments = 3;
		}
		Vector3 lhs = normal ?? Vector3.up;
		lhs.Normalize();
		Vector3 vector = Vector3.Cross(lhs, Vector3.up);
		if (vector.sqrMagnitude < 0.001f)
		{
			vector = Vector3.Cross(lhs, Vector3.right);
		}
		vector.Normalize();
		Vector3 vector2 = Vector3.Cross(lhs, vector);
		float num = (float)Math.PI * 2f / (float)segments;
		Vector3 arg = center + vector * radius;
		for (int i = 1; i <= segments; i++)
		{
			float f = (float)i * num;
			Vector3 vector3 = center + (Mathf.Cos(f) * vector + Mathf.Sin(f) * vector2) * radius;
			drawLine(arg, vector3);
			arg = vector3;
		}
	}

	public static string SimplifyPolygonExcel(IList<Vector2> v)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i <= v.Count; i++)
		{
			Vector2 vector = v[i % v.Count];
			stringBuilder.AppendLine(vector.x + "\t" + vector.y);
		}
		return stringBuilder.ToString().TrimEnd();
	}

	public static void RemoveAll<T1, T2>(this IDictionary<T1, T2> d, Func<KeyValuePair<T1, T2>, bool> removal)
	{
		List<T1> list = null;
		foreach (KeyValuePair<T1, T2> item in d)
		{
			if (removal(item))
			{
				if (list == null)
				{
					list = new List<T1>();
				}
				list.Add(item.Key);
			}
		}
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				d.Remove(list[i]);
			}
		}
	}

	public static List<Vector2> ComputeOuterShell(Vector2[] vertices, int[] triangles, bool clockwise = false)
	{
		List<List<int>> list = ComputeBoundaryLoops(vertices, triangles);
		if (list.Count == 0)
		{
			return new List<Vector2>();
		}
		List<int> list2 = null;
		float num = -1f;
		foreach (List<int> item in list)
		{
			float num2 = Mathf.Abs(SignedArea(vertices, item));
			if (num2 > num)
			{
				num = num2;
				list2 = item;
			}
		}
		List<Vector2> list3 = new List<Vector2>(list2.Count);
		foreach (int item2 in list2)
		{
			list3.Add(vertices[item2]);
		}
		bool flag = SignedArea(list3) < 0f;
		if (clockwise != flag)
		{
			list3.Reverse();
		}
		return list3;
	}

	public static List<List<int>> ComputeBoundaryLoops(Vector2[] vertices, int[] triangles)
	{
		_003C_003Ec__DisplayClass673_0 _003C_003Ec__DisplayClass673_1 = default(_003C_003Ec__DisplayClass673_0);
		_003C_003Ec__DisplayClass673_1.edgeCounts = new Dictionary<EdgeKey, int>();
		for (int i = 0; i < triangles.Length; i += 3)
		{
			int num = triangles[i];
			int num2 = triangles[i + 1];
			int num3 = triangles[i + 2];
			_003CComputeBoundaryLoops_003Eg__AddEdge_007C673_0(num, num2, ref _003C_003Ec__DisplayClass673_1);
			_003CComputeBoundaryLoops_003Eg__AddEdge_007C673_0(num2, num3, ref _003C_003Ec__DisplayClass673_1);
			_003CComputeBoundaryLoops_003Eg__AddEdge_007C673_0(num3, num, ref _003C_003Ec__DisplayClass673_1);
		}
		_003C_003Ec__DisplayClass673_1.adjacency = new Dictionary<int, List<int>>();
		foreach (KeyValuePair<EdgeKey, int> item2 in _003C_003Ec__DisplayClass673_1.edgeCounts)
		{
			if (item2.Value == 1)
			{
				int a = item2.Key.A;
				int b = item2.Key.B;
				_003CComputeBoundaryLoops_003Eg__AddAdj_007C673_1(a, b, ref _003C_003Ec__DisplayClass673_1);
				_003CComputeBoundaryLoops_003Eg__AddAdj_007C673_1(b, a, ref _003C_003Ec__DisplayClass673_1);
			}
		}
		List<List<int>> list = new List<List<int>>();
		HashSet<EdgeKey> hashSet = new HashSet<EdgeKey>();
		foreach (KeyValuePair<int, List<int>> item3 in _003C_003Ec__DisplayClass673_1.adjacency)
		{
			int key = item3.Key;
			foreach (int item4 in item3.Value)
			{
				EdgeKey item = new EdgeKey(key, item4);
				if (hashSet.Contains(item))
				{
					continue;
				}
				List<int> list2 = new List<int>();
				int num4 = -1;
				int num5 = key;
				do
				{
					list2.Add(num5);
					List<int> value;
					if (!_003C_003Ec__DisplayClass673_1.adjacency.TryGetValue(num5, out value) || value.Count == 0)
					{
						list2.Clear();
						break;
					}
					int num6 = -1;
					num6 = ((num4 == -1) ? item4 : ((value.Count != 1) ? ((value[0] == num4) ? value[1] : value[0]) : value[0]));
					hashSet.Add(new EdgeKey(num5, num6));
					num4 = num5;
					num5 = num6;
				}
				while (num5 != key);
				if (list2.Count >= 3)
				{
					list.Add(list2);
				}
			}
		}
		return list;
	}

	public static float SignedArea(Vector2[] vertices, List<int> polygon)
	{
		float num = 0f;
		int count = polygon.Count;
		for (int i = 0; i < count; i++)
		{
			Vector2 vector = vertices[polygon[i]];
			Vector2 vector2 = vertices[polygon[(i + 1) % count]];
			num += vector.x * vector2.y - vector2.x * vector.y;
		}
		return num * 0.5f;
	}

	public static float SignedArea(List<Vector2> polygon)
	{
		float num = 0f;
		int count = polygon.Count;
		for (int i = 0; i < count; i++)
		{
			Vector2 vector = polygon[i];
			Vector2 vector2 = polygon[(i + 1) % count];
			num += vector.x * vector2.y - vector2.x * vector.y;
		}
		return num * 0.5f;
	}

	[CompilerGenerated]
	private static void _003CComputeBoundaryLoops_003Eg__AddEdge_007C673_0(int a, int b, ref _003C_003Ec__DisplayClass673_0 P_2)
	{
		EdgeKey key = new EdgeKey(a, b);
		int value;
		if (P_2.edgeCounts.TryGetValue(key, out value))
		{
			P_2.edgeCounts[key] = value + 1;
		}
		else
		{
			P_2.edgeCounts[key] = 1;
		}
	}

	[CompilerGenerated]
	private static void _003CComputeBoundaryLoops_003Eg__AddAdj_007C673_1(int a, int b, ref _003C_003Ec__DisplayClass673_0 P_2)
	{
		List<int> value;
		if (!P_2.adjacency.TryGetValue(a, out value))
		{
			value = new List<int>();
			P_2.adjacency[a] = value;
		}
		value.Add(b);
	}
}
