using System;
using System.Collections.Generic;
using System.Reflection;
using MoonSharp.Interpreter.Interop.RegistrationPolicies;

namespace MoonSharp.Interpreter.Interop.UserDataRegistries
{
	internal static class TypeDescriptorRegistry
	{
		private static object s_Lock;

		private static Dictionary<Type, IUserDataDescriptor> s_TypeRegistry;

		private static Dictionary<Type, IUserDataDescriptor> s_TypeRegistryHistory;

		private static InteropAccessMode s_DefaultAccessMode;

		internal static InteropAccessMode DefaultAccessMode
		{
			get
			{
				return default(InteropAccessMode);
			}
			set
			{
			}
		}

		public static IEnumerable<KeyValuePair<Type, IUserDataDescriptor>> RegisteredTypes => null;

		public static IEnumerable<KeyValuePair<Type, IUserDataDescriptor>> RegisteredTypesHistory => null;

		internal static IRegistrationPolicy RegistrationPolicy { get; set; }

		internal static void RegisterAssembly(Assembly asm = null, bool includeExtensionTypes = false)
		{
		}

		internal static bool IsTypeRegistered(Type type)
		{
			return false;
		}

		internal static void UnregisterType(Type t)
		{
		}

		internal static IUserDataDescriptor RegisterProxyType_Impl(IProxyFactory proxyFactory, InteropAccessMode accessMode, string friendlyName)
		{
			return null;
		}

		internal static IUserDataDescriptor RegisterType_Impl(Type type, InteropAccessMode accessMode, string friendlyName, IUserDataDescriptor descriptor)
		{
			return null;
		}

		private static IUserDataDescriptor PerformRegistration(Type type, IUserDataDescriptor newDescriptor, IUserDataDescriptor oldDescriptor)
		{
			return null;
		}

		internal static InteropAccessMode ResolveDefaultAccessModeForType(InteropAccessMode accessMode, Type type)
		{
			return default(InteropAccessMode);
		}

		internal static IUserDataDescriptor GetDescriptorForType(Type type, bool searchInterfaces)
		{
			return null;
		}

		private static bool FrameworkIsAssignableFrom(Type type)
		{
			return false;
		}

		public static bool IsTypeBlacklisted(Type t)
		{
			return false;
		}
	}
}
