using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TH20
{
	public class MethodInfoCache
	{
		public struct CachedMethodInfo
		{
			public string Name;

			public string DeclaringTypeName;

			public string ParameterSignature;
		}

		private static MethodInfoCache _instance;

		private readonly Dictionary<MethodBase, CachedMethodInfo> _cachedMethodInfos = new Dictionary<MethodBase, CachedMethodInfo>();

		public static MethodInfoCache Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new MethodInfoCache();
				}
				return _instance;
			}
		}

		public CachedMethodInfo Get(MethodBase method)
		{
			if (_cachedMethodInfos.TryGetValue(method, out var value))
			{
				return value;
			}
			CachedMethodInfo cachedMethodInfo = CreateMethodCachedInfo(method);
			_cachedMethodInfos.Add(method, cachedMethodInfo);
			return cachedMethodInfo;
		}

		private static CachedMethodInfo CreateMethodCachedInfo(MethodBase method)
		{
			ParameterInfo[] parameters = method.GetParameters();
			StringBuilder builder = StringBuilderPool.GlobalStringBuilderPool.GetBuilder(parameters.Length * 20);
			for (int i = 0; i < parameters.Length; i++)
			{
				builder.AppendFormat((i + 1 < parameters.Length) ? "{0} {1}," : "{0} {1}", parameters[i].ParameterType, parameters[i].Name);
			}
			string parameterSignature = builder.ToString();
			StringBuilderPool.GlobalStringBuilderPool.ReturnBuilder(builder);
			return new CachedMethodInfo
			{
				DeclaringTypeName = method.DeclaringType.Name,
				Name = method.Name,
				ParameterSignature = parameterSignature
			};
		}
	}
}
