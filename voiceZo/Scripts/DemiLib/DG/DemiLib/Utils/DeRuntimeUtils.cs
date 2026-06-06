using System;
using UnityEngine;

namespace DG.DemiLib.Utils
{
	public static class DeRuntimeUtils
	{
		public static T[] GetOnlyComponentsInChildren<T>(GameObject go, bool includeInactive = false) where T : Component
		{
			T[] array = go.GetComponentsInChildren<T>(includeInactive);
			int num = array.Length;
			if (num == 0)
			{
				return array;
			}
			T component = go.GetComponent<T>();
			if (component == null)
			{
				return array;
			}
			T val = array[^1];
			num--;
			Array.Resize(ref array, num);
			bool flag = false;
			for (int i = 0; i < num; i++)
			{
				if (array[i] == component)
				{
					flag = true;
				}
				if (flag)
				{
					if (i < num - 1)
					{
						array[i] = array[i + 1];
					}
					else
					{
						array[i] = val;
					}
				}
			}
			return array;
		}

		public static T GetOnlyComponentInChildren<T>(GameObject go, bool includeInactive = false) where T : Component
		{
			T componentInChildren = go.GetComponentInChildren<T>(includeInactive);
			if (componentInChildren.transform == go.transform)
			{
				T[] componentsInChildren = go.GetComponentsInChildren<T>(includeInactive);
				if (componentsInChildren.Length > 1)
				{
					return componentsInChildren[1];
				}
				return null;
			}
			return componentInChildren;
		}

		public static string ToHex(Color32 color, bool includeAlpha = false)
		{
			string text = color.r.ToString("x2") + color.g.ToString("x2") + color.b.ToString("x2");
			if (includeAlpha)
			{
				text += color.a.ToString("x2");
			}
			return text;
		}

		public static string ToHex(Color color, bool includeAlpha = false)
		{
			return ToHex((Color32)color, includeAlpha);
		}
	}
}
