using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.Utility.Settings
{
	public abstract class BaseSettings : ScriptableObject
	{
		private static Dictionary<Type, BaseSettings> _instances = new Dictionary<Type, BaseSettings>();

		internal static BaseSettings GetInstance(Type type)
		{
			if (!type.IsSubclassOf(typeof(BaseSettings)))
			{
				return null;
			}
			if (!_instances.TryGetValue(type, out var value) || value == null)
			{
				UnityEngine.Object[] array = Resources.LoadAll("Settings", type);
				if (array != null && array.Length != 0)
				{
					value = array[0] as BaseSettings;
					_instances[type] = value;
				}
			}
			return value;
		}
	}
}
