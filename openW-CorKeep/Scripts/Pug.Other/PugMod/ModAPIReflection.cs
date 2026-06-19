using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using RoslynCSharp;

namespace PugMod
{
	public class ModAPIReflection : IReflection
	{
		private InvokeChecker _checker = new InvokeChecker();

		public Assembly CallingAssembly => Assembly.GetCallingAssembly();

		public Type[] AllTypes()
		{
			return AccessTools.AllAssemblies().SelectMany(delegate(Assembly x)
			{
				try
				{
					return x.GetTypes();
				}
				catch (ReflectionTypeLoadException ex)
				{
					return ex.Types.Where((Type type) => type != null).ToArray();
				}
			}).ToArray();
		}

		public Type[] GetTypes(long modId)
		{
			List<Type> list = new List<Type>();
			foreach (Loader.Mod mod in Loader.Instance.Mods)
			{
				foreach (ScriptAssembly loadedAssembly in mod.LoadedAssemblies)
				{
					try
					{
						list.AddRange(loadedAssembly.SystemAssembly.GetTypes());
					}
					catch (ReflectionTypeLoadException ex)
					{
						list.AddRange(ex.Types.Where((Type type) => type != null));
					}
				}
			}
			return list.ToArray();
		}

		public Type[] GetTypesFromCurrentAssembly()
		{
			throw new NotImplementedException();
		}

		public object Invoke(MemberInfo memberInfoInternal, object obj, params object[] parameters)
		{
			System.Reflection.MemberInfo memberInfo = memberInfoInternal;
			if (!_checker.CheckType(memberInfo.DeclaringType))
			{
				throw new InvalidOperationException("Not allowed to access " + memberInfo.Name);
			}
			if (memberInfo is MethodInfo methodInfo)
			{
				return methodInfo.Invoke(obj, parameters);
			}
			throw new InvalidOperationException("The provided member is not a method: " + memberInfo.Name);
		}

		public object GetValue(MemberInfo memberInfoInternal, object obj)
		{
			System.Reflection.MemberInfo memberInfo = memberInfoInternal;
			if (!_checker.CheckType(memberInfo.DeclaringType))
			{
				throw new InvalidOperationException("Not allowed to access " + memberInfo.Name);
			}
			if (memberInfo is FieldInfo fieldInfo)
			{
				return fieldInfo.GetValue(obj);
			}
			if (memberInfo is PropertyInfo propertyInfo)
			{
				return propertyInfo.GetValue(obj);
			}
			throw new InvalidOperationException("The provided member is neither a field nor a property: " + memberInfo.Name);
		}

		public void SetValue(MemberInfo memberInfoInternal, object obj, object value)
		{
			System.Reflection.MemberInfo memberInfo = memberInfoInternal;
			if (!_checker.CheckType(memberInfo.DeclaringType))
			{
				throw new InvalidOperationException("Not allowed to access " + memberInfo.Name);
			}
			if (memberInfo is FieldInfo fieldInfo)
			{
				fieldInfo.SetValue(obj, value);
				return;
			}
			if (memberInfo is PropertyInfo propertyInfo)
			{
				if (propertyInfo.CanWrite)
				{
					propertyInfo.SetValue(obj, value);
					return;
				}
				throw new InvalidOperationException("The property " + memberInfo.Name + " is read-only.");
			}
			throw new InvalidOperationException("The provided member is neither a field nor a property: " + memberInfo.Name);
		}
	}
}
