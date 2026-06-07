using System.Collections.Generic;
using UnityEngine;

namespace DV.UIFramework
{
	public static class Util
	{
		public static T FindInChildren<T>(GameObject go, string namePrefix, bool logMissing = true) where T : Behaviour
		{
			Transform transform = go.transform.Find(namePrefix);
			if ((bool)transform)
			{
				return transform.GetComponent<T>();
			}
			T[] componentsInChildren = go.GetComponentsInChildren<T>(includeInactive: true);
			foreach (T val in componentsInChildren)
			{
				if (val.name.StartsWith(namePrefix))
				{
					return val;
				}
			}
			if (logMissing)
			{
				Debug.LogError(typeof(T).Name + " starting with '" + namePrefix + "' not found in '" + go.name + "'", go);
			}
			return null;
		}

		public static void FindInChildrenAndAddMultiple<T>(GameObject go, string namePrefix, List<T> listToAddTo, bool logMissing = true) where T : Behaviour
		{
			bool flag = false;
			T[] componentsInChildren = go.GetComponentsInChildren<T>(includeInactive: true);
			foreach (T val in componentsInChildren)
			{
				if (val.name.StartsWith(namePrefix))
				{
					flag = true;
					if (!listToAddTo.Contains(val))
					{
						listToAddTo.Add(val);
					}
				}
			}
			if (!flag && logMissing)
			{
				Debug.LogError("Couldn't find any " + typeof(T).Name + " starting with '" + namePrefix + "' found in '" + go.name + "'", go);
			}
		}
	}
}
