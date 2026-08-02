using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace HQFPSTemplate
{
	public static class Extensions
	{
		public static string DoUnityLikeNameFormat(this string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return string.Empty;
			}
			if (str.Length > 2 && str[0] == 'm' && str[1] == '_')
			{
				str = str.Remove(0, 2);
			}
			if (str.Length > 1 && str[0] == '_')
			{
				str = str.Remove(0);
			}
			StringBuilder stringBuilder = new StringBuilder(str.Length * 2);
			stringBuilder.Append(str[0]);
			for (int i = 1; i < str.Length; i++)
			{
				bool flag = char.IsUpper(str[i - 1]);
				bool flag2 = str[i - 1] == ' ';
				bool flag3 = char.IsDigit(str[i - 1]);
				if (char.IsUpper(str[i]) && !flag && !flag2)
				{
					stringBuilder.Append(' ');
				}
				if (char.IsDigit(str[i]) && !flag3 && !flag && !flag2)
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(str[i]);
			}
			return stringBuilder.ToString();
		}

		public static Transform FindDeepChild(this Transform parent, string childName)
		{
			Transform transform = parent.Find(childName);
			if ((bool)transform)
			{
				return transform;
			}
			for (int i = 0; i < parent.childCount; i++)
			{
				transform = parent.GetChild(i).FindDeepChild(childName);
				if ((bool)transform)
				{
					return transform;
				}
			}
			return null;
		}

		public static bool IndexIsValid<T>(this List<T> list, int index)
		{
			if (index >= 0)
			{
				return index < list.Count;
			}
			return false;
		}

		public static List<T> CopyOther<T>(this List<T> list, List<T> toCopy)
		{
			if (toCopy == null || toCopy.Count == 0)
			{
				return null;
			}
			list = new List<T>();
			for (int i = 0; i < toCopy.Count; i++)
			{
				list.Add(toCopy[i]);
			}
			return list;
		}

		public static bool IsInRangeLimits(this float f, float l1, float l2)
		{
			if (f > l1)
			{
				return f < l2;
			}
			return false;
		}

		public static void ResetLocal(this Transform transform, bool clearParent = false)
		{
			if (clearParent)
			{
				transform.SetParent(null);
			}
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
		}

		public static void ResetWorld(this Transform transform, bool clearParent = false)
		{
			if (clearParent)
			{
				transform.SetParent(null);
			}
			transform.position = Vector3.zero;
			transform.rotation = Quaternion.identity;
			transform.localScale = Vector3.one;
		}
	}
}
