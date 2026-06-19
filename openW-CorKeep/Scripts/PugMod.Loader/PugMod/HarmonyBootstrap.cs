using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;

namespace PugMod
{
	public class HarmonyBootstrap
	{
		private Dictionary<string, Harmony> _patchers = new Dictionary<string, Harmony>();

		public bool Patch(string identifier, Assembly assembly, bool safetyCheck, InvokeChecker checker)
		{
			if (safetyCheck)
			{
				Type[] types = assembly.GetTypes();
				foreach (Type type in types)
				{
					if (!CheckAnnotations(type.GetCustomAttributes(), checker))
					{
						return false;
					}
					MethodInfo[] methods = type.GetMethods();
					foreach (MethodInfo element in methods)
					{
						if (!CheckAnnotations(element.GetCustomAttributes(), checker))
						{
							return false;
						}
					}
					PropertyInfo[] properties = type.GetProperties();
					foreach (PropertyInfo element2 in properties)
					{
						if (!CheckAnnotations(element2.GetCustomAttributes(), checker))
						{
							return false;
						}
					}
					FieldInfo[] fields = type.GetFields();
					foreach (FieldInfo element3 in fields)
					{
						if (!CheckAnnotations(element3.GetCustomAttributes(), checker))
						{
							return false;
						}
					}
					EventInfo[] events = type.GetEvents();
					foreach (EventInfo element4 in events)
					{
						if (!CheckAnnotations(element4.GetCustomAttributes(), checker))
						{
							return false;
						}
					}
				}
			}
			if (!_patchers.TryGetValue(identifier, out var value))
			{
				value = new Harmony(identifier);
				_patchers.Add(identifier, value);
			}
			value.PatchAll(assembly);
			return true;
		}

		public bool Patch(string identifier, Type type, bool safetyCheck, InvokeChecker checker)
		{
			if (safetyCheck)
			{
				if (!CheckAnnotations(type.GetCustomAttributes(), checker))
				{
					return false;
				}
				MethodInfo[] methods = type.GetMethods();
				foreach (MethodInfo element in methods)
				{
					if (!CheckAnnotations(element.GetCustomAttributes(), checker))
					{
						return false;
					}
				}
				PropertyInfo[] properties = type.GetProperties();
				foreach (PropertyInfo element2 in properties)
				{
					if (!CheckAnnotations(element2.GetCustomAttributes(), checker))
					{
						return false;
					}
				}
				FieldInfo[] fields = type.GetFields();
				foreach (FieldInfo element3 in fields)
				{
					if (!CheckAnnotations(element3.GetCustomAttributes(), checker))
					{
						return false;
					}
				}
				EventInfo[] events = type.GetEvents();
				foreach (EventInfo element4 in events)
				{
					if (!CheckAnnotations(element4.GetCustomAttributes(), checker))
					{
						return false;
					}
				}
			}
			if (!_patchers.TryGetValue(identifier, out var value))
			{
				value = new Harmony(identifier);
				_patchers.Add(identifier, value);
			}
			value.PatchAll(type);
			return true;
		}

		public void Unload(string identifier)
		{
			if (_patchers.TryGetValue(identifier, out var value))
			{
				value.UnpatchSelf();
				_patchers.Remove(identifier);
			}
		}

		private bool CheckAnnotations(IEnumerable<object> attributes, InvokeChecker checker)
		{
			foreach (object attribute in attributes)
			{
				if (attribute is HarmonyAttribute harmonyAttribute && !checker.CheckType(harmonyAttribute.info.declaringType))
				{
					return false;
				}
			}
			return true;
		}
	}
}
