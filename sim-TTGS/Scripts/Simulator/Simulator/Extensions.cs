using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Dhs5.Utility.Debuggers;
using Dhs5.Utility.Settings;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Simulator
{
	public static class Extensions
	{
		private const string InteractionHoldWord = "Hold";

		private const int InteractionHoldOffset = 14;

		private const int InteractionHoldLength = 3;

		private const string InteractionTapWord = "Tap";

		private const int InteractionTapOffset = 13;

		private const int InteractionTapLength = 3;

		private const string MoneyFormatFractional = "0.00";

		private const string MoneyFormatNotFractional = "0";

		private static readonly CultureInfo EnglishCultureInfo = new CultureInfo("en-US");

		private static readonly CultureInfo FrenchCultureInfo = new CultureInfo("fr-FR");

		public static void Anchor(this Transform transform, Transform anchor, bool parenting = true)
		{
			if (parenting)
			{
				transform.SetParent(anchor);
				transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			}
			else
			{
				transform.SetPositionAndRotation(anchor.position, anchor.rotation);
			}
		}

		public static List<T> GetComponentsInChildrenOnlyFirstDepth<T>(this Transform transform)
		{
			int childCount = transform.childCount;
			List<T> list = new List<T>((int)((float)childCount * 0.5f));
			for (int i = 0; i < childCount; i++)
			{
				if (transform.GetChild(i).TryGetComponent<T>(out var component))
				{
					list.Add(component);
				}
			}
			return list;
		}

		public static int ToInt(this bool value)
		{
			if (!value)
			{
				return 0;
			}
			return 1;
		}

		public static List<MemberInfo> GetAllMembers(this Type type, BindingFlags flags)
		{
			if (type == typeof(object))
			{
				return new List<MemberInfo>();
			}
			List<MemberInfo> allMembers = type.BaseType.GetAllMembers(flags);
			allMembers.AddRange(type.GetMembers(flags | BindingFlags.DeclaredOnly));
			return allMembers;
		}

		public static string PreParseFloat(this string str)
		{
			string text = "";
			for (int i = 0; i < str.Length; i++)
			{
				char c = str[i];
				if (char.IsDigit(c))
				{
					text += c;
					continue;
				}
				switch (c)
				{
				case '.':
					text += c;
					break;
				case ',':
					text += ".";
					break;
				}
			}
			return text.Trim();
		}

		public static bool TryParseFloat(this string str, out float f)
		{
			string text = "";
			for (int i = 0; i < str.Length; i++)
			{
				char c = str[i];
				if (char.IsDigit(c))
				{
					text += c;
					continue;
				}
				switch (c)
				{
				case '.':
					text += c;
					break;
				case ',':
					text += ".";
					break;
				}
			}
			return float.TryParse(text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out f);
		}

		public static bool ToBool(this int value)
		{
			return value != 0;
		}

		public static T GetRandom<T>(this IList<T> list)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}

		public static bool TryGetRandom<T>(this IList<T> list, Predicate<T> predicate, out T value)
		{
			value = default(T);
			List<T> list2 = list.Where((T item) => predicate(item)).ToList();
			if (list2.Count <= 0)
			{
				return false;
			}
			int index = UnityEngine.Random.Range(0, list2.Count);
			value = list2[index];
			return true;
		}

		public static string ToFriendlyName(this Enum value, bool useDescription = false)
		{
			if (value == null)
			{
				return string.Empty;
			}
			if (!Enum.IsDefined(value.GetType(), value))
			{
				return string.Empty;
			}
			if (useDescription)
			{
				FieldInfo field = value.GetType().GetField(value.ToString());
				if (field != null)
				{
					DescriptionAttribute customAttribute = field.GetCustomAttribute<DescriptionAttribute>(inherit: false);
					if (customAttribute != null)
					{
						return customAttribute.Description;
					}
				}
			}
			return value.ToString().ToFriendlyName();
		}

		public static string ToFriendlyName(this string value)
		{
			Span<char> destination = stackalloc char[value.Length];
			value.AsSpan().Trim().CopyTo(destination);
			destination[0] = char.ToUpperInvariant(destination[0]);
			Match match = Regex.Match(destination.ToString(), "([A-Z]+(?![a-z])|\\d+|[A-Z][a-z]+|(?![A-Z])[a-z]+)+");
			Span<char> span = stackalloc char[value.Length];
			int num = 0;
			while (match.Success)
			{
				string value2 = match.Value;
				int length = value2.Length;
				int num2 = num + length;
				int num3 = num;
				int num4 = 0;
				while (num3 < num2)
				{
					span[num3] = value2[num4];
					num3++;
					num4++;
				}
				if (num2 < value.Length)
				{
					span[num2] = ' ';
				}
				num = num2 + 1;
				match = match.NextMatch();
			}
			return span.ToString();
		}

		public static float Average(this List<float> values)
		{
			float num = 0f;
			foreach (float value in values)
			{
				num += value;
			}
			if (values.Count > 0)
			{
				return num / (float)values.Count;
			}
			return 0f;
		}

		public static float Average(this List<int> values)
		{
			float num = 0f;
			foreach (int value in values)
			{
				float num2 = value;
				num += num2;
			}
			if (values.Count > 0)
			{
				return num / (float)values.Count;
			}
			return 0f;
		}

		public static float Sum(this List<float> values)
		{
			float num = 0f;
			foreach (float value in values)
			{
				num += value;
			}
			return num;
		}

		public static int Sum(this List<int> values)
		{
			int num = 0;
			foreach (int value in values)
			{
				num += value;
			}
			return num;
		}

		public static bool Contains(this Vector2 vector, float value)
		{
			if (value >= vector.x)
			{
				return value <= vector.y;
			}
			return false;
		}

		public static bool Contains(this Vector2Int vector, int value)
		{
			if (value >= vector.x)
			{
				return value <= vector.y;
			}
			return false;
		}

		public static bool Contains(this Vector2Int vector, float value)
		{
			if (value >= (float)vector.x)
			{
				return value <= (float)vector.y;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsNull(this Vector3 vector)
		{
			if (Mathf.Approximately(vector.x, 0f) && Mathf.Approximately(vector.y, 0f))
			{
				return Mathf.Approximately(vector.z, 0f);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Max(this Vector3 vector)
		{
			return Mathf.Max(Mathf.Max(vector.x, vector.y), vector.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 Divide(this Vector3 vector, Vector3 scale)
		{
			if (Mathf.Approximately(scale.x * scale.y * scale.z, 0f))
			{
				return Vector3.zero;
			}
			return new Vector3(vector.x / scale.x, vector.y / scale.y, vector.z / scale.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 SetX(this Vector3 vector, float x)
		{
			return new Vector3(x, vector.y, vector.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 SetY(this Vector3 vector, float y)
		{
			return new Vector3(vector.x, y, vector.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 SetZ(this Vector3 vector, float z)
		{
			return new Vector3(vector.x, vector.y, z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4 SetX(this Vector4 vector, float x)
		{
			return new Vector4(x, vector.y, vector.z, vector.w);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4 SetY(this Vector4 vector, float y)
		{
			return new Vector4(vector.x, y, vector.z, vector.w);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4 SetZ(this Vector4 vector, float z)
		{
			return new Vector4(vector.x, vector.y, z, vector.w);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector4 SetW(this Vector4 vector, float w)
		{
			return new Vector4(vector.x, vector.y, vector.z, w);
		}

		public static Color SetAlpha(this Color color, float alpha)
		{
			return new Color(color.r, color.g, color.b, alpha);
		}

		public static void Init<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IList keys)
		{
			foreach (object key in keys)
			{
				dictionary.AddKeyAndCreateValueInstance((TKey)key);
			}
		}

		private static void AddKeyAndCreateValueInstance<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
		{
			dictionary.Add(key, Activator.CreateInstance<TValue>());
		}

		public static List<T> GetValuesFromBitField<T>(this T value) where T : Enum
		{
			List<T> list = new List<T>();
			int num = Marshal.SizeOf(Enum.GetUnderlyingType(typeof(T))) * 8;
			for (int i = 0; i < num; i++)
			{
				int num2 = Convert.ToInt32(value) & (1 << i);
				if (num2 != 0)
				{
					list.Add((T)Enum.ToObject(typeof(T), num2));
				}
			}
			return list;
		}

		public static InputsUISettings.Container[] GetSettingsAll(this InputAction inputAction)
		{
			return CustomSettings<InputsUISettings>.I.GetInputActionContainers(inputAction);
		}

		public static float GetHolInteractionDuration(this InputAction inputAction)
		{
			string interactions = inputAction.interactions;
			int num = interactions.IndexOf("Hold", StringComparison.Ordinal);
			if (num == -1)
			{
				throw new NullReferenceException("Interaction 'Hold' not found in '" + interactions + "'");
			}
			return float.Parse(interactions.AsSpan().Slice(num + 14, 3), NumberStyles.Float, CultureInfo.InvariantCulture);
		}

		public static float GetTapInteractionDuration(this InputAction inputAction)
		{
			string interactions = inputAction.interactions;
			int num = interactions.IndexOf("Tap", StringComparison.Ordinal);
			if (num == -1)
			{
				throw new NullReferenceException("Interaction 'Tap' not found in '" + interactions + "'");
			}
			return float.Parse(interactions.AsSpan().Slice(num + 13, 3), NumberStyles.Float, CultureInfo.InvariantCulture);
		}

		public static void RefreshLayoutGroupsImmediateAndRecursive(this LayoutGroup root)
		{
			LayoutGroup[] componentsInChildren = root.GetComponentsInChildren<LayoutGroup>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(componentsInChildren[i].GetComponent<RectTransform>());
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(root.GetComponent<RectTransform>());
		}

		public static string ToStringMoneyFormat(this float amount)
		{
			GameplayApplicationOptions.ECurrency value = GameplayApplicationOptions.Currency.Value;
			CultureInfo cultureInfo = ((value == GameplayApplicationOptions.ECurrency.DOLLAR) ? EnglishCultureInfo : FrenchCultureInfo);
			string text;
			if (amount >= 1f || amount == 0f || amount <= -1f)
			{
				text = ((amount % 1f == 0f) ? "0" : "0.00");
				string currencySymbol = cultureInfo.NumberFormat.CurrencySymbol;
				text = ((value != GameplayApplicationOptions.ECurrency.DOLLAR) ? (text + currencySymbol) : (currencySymbol + text));
			}
			else
			{
				amount = MathF.Round(amount % 1f * 100f);
				text = "0";
				text += "¢";
			}
			return amount.ToString(text, cultureInfo);
		}

		public static string ToStringPercentFormat(this float amount, int precision = 0)
		{
			string text = "F" + precision;
			if (amount >= 0f)
			{
				return "+" + amount.ToString(text) + "%";
			}
			return amount.ToString(text) + "%";
		}

		public static void Log<T>(this IList<T> list, EDebugCategory e, object prefixMessage, Func<T, string> func, int level = 2, bool onScreen = false, UnityEngine.Object context = null)
		{
			if (list == null || list.Count == 0)
			{
				Debugger<EDebugCategory>.Log(e, prefixMessage, level, onScreen, context);
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(prefixMessage);
			stringBuilder.AppendLine(":");
			for (int i = 0; i < list.Count; i++)
			{
				stringBuilder.AppendLine(func(list[i]));
			}
			Debugger<EDebugCategory>.Log(e, stringBuilder.ToString(), level, onScreen, context);
		}
	}
}
