using System;
using System.Collections.Generic;
using System.Reflection;
using MoonSharp.Interpreter.Interop;
using MoonSharp.Interpreter.Interop.BasicDescriptors;
using MoonSharp.Interpreter.Interop.RegistrationPolicies;

namespace MoonSharp.Interpreter
{
	public class UserData : RefIdObject
	{
		public DynValue UserValue { get; set; }

		public object Object { get; private set; }

		public IUserDataDescriptor Descriptor { get; private set; }

		public static IRegistrationPolicy RegistrationPolicy
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static InteropAccessMode DefaultAccessMode
		{
			get
			{
				return default(InteropAccessMode);
			}
			set
			{
			}
		}

		private UserData()
		{
		}

		static UserData()
		{
		}

		public static IUserDataDescriptor RegisterType<T>(InteropAccessMode accessMode = InteropAccessMode.Default, string friendlyName = null)
		{
			return null;
		}

		public static IUserDataDescriptor RegisterType(Type type, InteropAccessMode accessMode = InteropAccessMode.Default, string friendlyName = null)
		{
			return null;
		}

		public static IUserDataDescriptor RegisterProxyType(IProxyFactory proxyFactory, InteropAccessMode accessMode = InteropAccessMode.Default, string friendlyName = null)
		{
			return null;
		}

		public static IUserDataDescriptor RegisterProxyType<TProxy, TTarget>(Func<TTarget, TProxy> wrapDelegate, InteropAccessMode accessMode = InteropAccessMode.Default, string friendlyName = null) where TProxy : class where TTarget : class
		{
			return null;
		}

		public static IUserDataDescriptor RegisterType<T>(IUserDataDescriptor customDescriptor)
		{
			return null;
		}

		public static IUserDataDescriptor RegisterType(Type type, IUserDataDescriptor customDescriptor)
		{
			return null;
		}

		public static IUserDataDescriptor RegisterType(IUserDataDescriptor customDescriptor)
		{
			return null;
		}

		public static void RegisterAssembly(Assembly asm = null, bool includeExtensionTypes = false)
		{
		}

		public static bool IsTypeRegistered(Type t)
		{
			return false;
		}

		public static bool IsTypeRegistered<T>()
		{
			return false;
		}

		public static void UnregisterType<T>()
		{
		}

		public static void UnregisterType(Type t)
		{
		}

		public static DynValue Create(object o, IUserDataDescriptor descr)
		{
			return null;
		}

		public static DynValue Create(object o)
		{
			return null;
		}

		public static DynValue CreateStatic(IUserDataDescriptor descr)
		{
			return null;
		}

		public static DynValue CreateStatic(Type t)
		{
			return null;
		}

		public static DynValue CreateStatic<T>()
		{
			return null;
		}

		public static void RegisterExtensionType(Type type, InteropAccessMode mode = InteropAccessMode.Default)
		{
		}

		public static List<IOverloadableMemberDescriptor> GetExtensionMethodsByNameAndType(string name, Type extendedType)
		{
			return null;
		}

		public static int GetExtensionMethodsChangeVersion()
		{
			return 0;
		}

		public static IUserDataDescriptor GetDescriptorForType<T>(bool searchInterfaces)
		{
			return null;
		}

		public static IUserDataDescriptor GetDescriptorForType(Type type, bool searchInterfaces)
		{
			return null;
		}

		public static IUserDataDescriptor GetDescriptorForObject(object o)
		{
			return null;
		}

		public static Table GetDescriptionOfRegisteredTypes(bool useHistoricalData = false)
		{
			return null;
		}

		public static IEnumerable<Type> GetRegisteredTypes(bool useHistoricalData = false)
		{
			return null;
		}
	}
}
