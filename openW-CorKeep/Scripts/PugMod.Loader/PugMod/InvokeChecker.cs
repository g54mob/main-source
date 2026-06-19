using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace PugMod
{
	public class InvokeChecker
	{
		private HashSet<Type> _disallowedTypes;

		private void LazyInit()
		{
			if (_disallowedTypes == null)
			{
				IEnumerable<Type> collection = from p in AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly s) => s.GetTypes())
					where p.GetCustomAttribute<DisallowPatching>() != null
					select p;
				_disallowedTypes = new HashSet<Type>(collection);
			}
		}

		public bool CheckType(Type type)
		{
			LazyInit();
			if (type == null)
			{
				return true;
			}
			if (_disallowedTypes.Contains(type))
			{
				Debug.Log($"Trying to patch disallowed type {type}");
				return false;
			}
			string fullName = type.Assembly.FullName;
			if (fullName.StartsWith("PugMod.Loader"))
			{
				Debug.Log("Patching mod loading not allowed");
				return false;
			}
			if (fullName.StartsWith("Pug"))
			{
				return true;
			}
			if (fullName.StartsWith("Unity"))
			{
				return true;
			}
			if (fullName.StartsWith("SpriteInstancing"))
			{
				return true;
			}
			if (fullName.StartsWith("I2"))
			{
				return true;
			}
			if (fullName.StartsWith("Rewired"))
			{
				return true;
			}
			Debug.Log($"Trying to patch type {type} from unknown assembly");
			return false;
		}
	}
}
