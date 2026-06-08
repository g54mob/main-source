using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Castle.DynamicProxy.Generators
{
	public class MethodFinder
	{
		private static readonly Dictionary<Type, MethodInfo[]> cachedMethodInfosByType = new Dictionary<Type, MethodInfo[]>();

		private static readonly object lockObject = new object();

		public static MethodInfo[] GetAllInstanceMethods(Type type, BindingFlags flags)
		{
			if ((flags & ~(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) != BindingFlags.Default)
			{
				throw new ArgumentException("MethodFinder only supports the Public, NonPublic, and Instance binding flags.", "flags");
			}
			MethodInfo[] value;
			lock (lockObject)
			{
				if (!cachedMethodInfosByType.TryGetValue(type, out value))
				{
					value = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Distinct(MethodSignatureComparer.Instance).ToArray();
					cachedMethodInfosByType.Add(type, value);
				}
			}
			return MakeFilteredCopy(value, flags & (BindingFlags.Public | BindingFlags.NonPublic));
		}

		private static MethodInfo[] MakeFilteredCopy(MethodInfo[] methodsInCache, BindingFlags visibilityFlags)
		{
			if ((visibilityFlags & ~(BindingFlags.Public | BindingFlags.NonPublic)) != BindingFlags.Default)
			{
				throw new ArgumentException("Only supports BindingFlags.Public and NonPublic.", "visibilityFlags");
			}
			bool flag = (visibilityFlags & BindingFlags.Public) == BindingFlags.Public;
			bool flag2 = (visibilityFlags & BindingFlags.NonPublic) == BindingFlags.NonPublic;
			List<MethodInfo> list = new List<MethodInfo>(methodsInCache.Length);
			foreach (MethodInfo methodInfo in methodsInCache)
			{
				if ((methodInfo.IsPublic && flag) || (!methodInfo.IsPublic && flag2))
				{
					list.Add(methodInfo);
				}
			}
			return list.ToArray();
		}
	}
}
