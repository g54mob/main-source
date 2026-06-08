using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProtoBuf.Internal
{
	internal static class TypeCompatibilityHelper
	{
		private static readonly Dictionary<Module, CompatibilityLevel> s_ByModule = new Dictionary<Module, CompatibilityLevel>();

		internal static CompatibilityLevel GetModuleCompatibilityLevel(Module module)
		{
			if ((object)module == null)
			{
				return CompatibilityLevel.NotSpecified;
			}
			lock (s_ByModule)
			{
				if (s_ByModule.TryGetValue(module, out var value))
				{
					return value;
				}
			}
			CompatibilityLevel compatibilityLevel = Calculate(module);
			lock (s_ByModule)
			{
				s_ByModule[module] = compatibilityLevel;
				return compatibilityLevel;
			}
			static CompatibilityLevel Calculate(Module module2)
			{
				if (Attribute.GetCustomAttribute(module2, typeof(CompatibilityLevelAttribute), inherit: true) is CompatibilityLevelAttribute compatibilityLevelAttribute && compatibilityLevelAttribute.Level > CompatibilityLevel.NotSpecified)
				{
					return compatibilityLevelAttribute.Level;
				}
				Assembly assembly = module2.Assembly;
				if ((object)assembly != null && Attribute.GetCustomAttribute(assembly, typeof(CompatibilityLevelAttribute), inherit: true) is CompatibilityLevelAttribute compatibilityLevelAttribute2 && compatibilityLevelAttribute2.Level > CompatibilityLevel.NotSpecified)
				{
					return compatibilityLevelAttribute2.Level;
				}
				return CompatibilityLevel.NotSpecified;
			}
		}

		internal static CompatibilityLevel GetTypeCompatibilityLevel(Type type, CompatibilityLevel defaultLevel)
		{
			if (Attribute.GetCustomAttribute(type, typeof(CompatibilityLevelAttribute), inherit: true) is CompatibilityLevelAttribute compatibilityLevelAttribute && compatibilityLevelAttribute.Level > CompatibilityLevel.NotSpecified)
			{
				return compatibilityLevelAttribute.Level;
			}
			CompatibilityLevel moduleCompatibilityLevel = GetModuleCompatibilityLevel(type.Module);
			if (moduleCompatibilityLevel > CompatibilityLevel.NotSpecified)
			{
				return moduleCompatibilityLevel;
			}
			if (defaultLevel >= CompatibilityLevel.Level200)
			{
				return defaultLevel;
			}
			return CompatibilityLevel.Level200;
		}

		internal static CompatibilityLevel GetMemberCompatibilityLevel(MemberInfo member, CompatibilityLevel typeLevel)
		{
			if (!(Attribute.GetCustomAttribute(member, typeof(CompatibilityLevelAttribute), inherit: true) is CompatibilityLevelAttribute compatibilityLevelAttribute) || compatibilityLevelAttribute.Level <= CompatibilityLevel.NotSpecified)
			{
				return typeLevel;
			}
			return compatibilityLevelAttribute.Level;
		}
	}
}
