using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using MoonSharp.Interpreter.DataStructs;
using MoonSharp.Interpreter.Interop;
using MoonSharp.Interpreter.Interop.BasicDescriptors;

namespace MoonSharp.Interpreter
{
	public class UserData : RefIdObject
	{
		private static object s_Lock;

		private static Dictionary<Type, IUserDataDescriptor> s_Registry;

		private static InteropAccessMode s_DefaultAccessMode;

		private static MultiDictionary<string, IOverloadableMemberDescriptor> s_ExtensionMethodRegistry;

		private static int s_ExtensionMethodChangeVersion;

		public DynValue UserValue { get; set; }

		public object Object { get; private set; }

		public IUserDataDescriptor Descriptor { get; private set; }

		public static InteropRegistrationPolicy RegistrationPolicy { get; set; }

		public static InteropAccessMode DefaultAccessMode
		{
			get
			{
				return s_DefaultAccessMode;
			}
			set
			{
				if (value == InteropAccessMode.Default)
				{
					throw new ArgumentException("InteropAccessMode is InteropAccessMode.Default");
				}
				s_DefaultAccessMode = value;
			}
		}

		private UserData()
		{
		}

		static UserData()
		{
			s_Lock = new object();
			s_Registry = new Dictionary<Type, IUserDataDescriptor>();
			s_ExtensionMethodRegistry = new MultiDictionary<string, IOverloadableMemberDescriptor>();
			s_ExtensionMethodChangeVersion = 0;
			RegisterType<EventMemberDescriptor.EventFacade>(InteropAccessMode.NoReflectionAllowed);
			RegisterType<AnonWrapper>(InteropAccessMode.HideMembers);
			RegisterType<EnumerableWrapper>(InteropAccessMode.NoReflectionAllowed);
			s_DefaultAccessMode = InteropAccessMode.LazyOptimized;
		}

		public static void RegisterType<T>(InteropAccessMode accessMode = InteropAccessMode.Default, string friendlyName = null)
		{
			RegisterType_Impl(typeof(T), accessMode, friendlyName, null);
		}

		public static void RegisterType(Type type, InteropAccessMode accessMode = InteropAccessMode.Default, string friendlyName = null)
		{
			RegisterType_Impl(type, accessMode, friendlyName, null);
		}

		public static void RegisterType<T>(IUserDataDescriptor customDescriptor)
		{
			RegisterType_Impl(typeof(T), InteropAccessMode.Default, null, customDescriptor);
		}

		public static void RegisterType(Type type, IUserDataDescriptor customDescriptor)
		{
			RegisterType_Impl(type, InteropAccessMode.Default, null, customDescriptor);
		}

		public static void RegisterAssembly(Assembly asm = null, bool includeExtensionTypes = false)
		{
			asm = asm ?? Assembly.GetCallingAssembly();
			if (includeExtensionTypes)
			{
				var enumerable = from t in asm.GetTypes()
					let attributes = t.GetCustomAttributes(typeof(ExtensionAttribute), true)
					where attributes != null && attributes.Length > 0
					select new
					{
						Attributes = attributes,
						DataType = t
					};
				foreach (var item in enumerable)
				{
					RegisterExtensionType(item.DataType);
				}
			}
			var enumerable2 = from t in asm.GetTypes()
				let attributes = t.GetCustomAttributes(typeof(MoonSharpUserDataAttribute), true)
				where attributes != null && attributes.Length > 0
				select new
				{
					Attributes = attributes,
					DataType = t
				};
			foreach (var item2 in enumerable2)
			{
				RegisterType(item2.DataType, item2.Attributes.OfType<MoonSharpUserDataAttribute>().First().AccessMode);
			}
		}

		public static void UnregisterType<T>()
		{
			UnregisterType(typeof(T));
		}

		public static void UnregisterType(Type t)
		{
			lock (s_Lock)
			{
				if (s_Registry.ContainsKey(t))
				{
					s_Registry.Remove(t);
				}
			}
		}

		public static DynValue Create(object o, IUserDataDescriptor descr)
		{
			UserData userData = new UserData();
			userData.Descriptor = descr;
			userData.Object = o;
			return DynValue.NewUserData(userData);
		}

		public static DynValue Create(object o)
		{
			IUserDataDescriptor descriptorForObject = GetDescriptorForObject(o);
			if (descriptorForObject == null)
			{
				if (o is Type)
				{
					return CreateStatic((Type)o);
				}
				return null;
			}
			return Create(o, descriptorForObject);
		}

		public static DynValue CreateStatic(IUserDataDescriptor descr)
		{
			if (descr == null)
			{
				return null;
			}
			UserData userData = new UserData();
			userData.Descriptor = descr;
			userData.Object = null;
			return DynValue.NewUserData(userData);
		}

		public static DynValue CreateStatic(Type t)
		{
			return CreateStatic(GetDescriptorForType(t, false));
		}

		public static DynValue CreateStatic<T>()
		{
			return CreateStatic(GetDescriptorForType(typeof(T), false));
		}

		public static void RegisterExtensionType(Type type, InteropAccessMode mode = InteropAccessMode.Default)
		{
			lock (s_Lock)
			{
				foreach (MethodInfo item in from _mi in type.GetMethods()
					where _mi.IsStatic
					select _mi)
				{
					if (MethodMemberDescriptor.CheckMethodIsCompatible(item, false) && item.GetCustomAttributes(typeof(ExtensionAttribute), false).Length != 0)
					{
						MethodMemberDescriptor value = new MethodMemberDescriptor(item, mode);
						s_ExtensionMethodRegistry.Add(item.Name, value);
						s_ExtensionMethodChangeVersion++;
					}
				}
			}
		}

		public static IEnumerable<IOverloadableMemberDescriptor> GetExtensionMethodsByName(string name)
		{
			lock (s_Lock)
			{
				return s_ExtensionMethodRegistry.Find(name);
			}
		}

		public static int GetExtensionMethodsChangeVersion()
		{
			return s_ExtensionMethodChangeVersion;
		}

		private static IUserDataDescriptor RegisterType_Impl(Type type, InteropAccessMode accessMode, string friendlyName, IUserDataDescriptor descriptor)
		{
			if (accessMode == InteropAccessMode.Default)
			{
				MoonSharpUserDataAttribute moonSharpUserDataAttribute = type.GetCustomAttributes(true).OfType<MoonSharpUserDataAttribute>().SingleOrDefault();
				if (moonSharpUserDataAttribute != null)
				{
					accessMode = moonSharpUserDataAttribute.AccessMode;
				}
			}
			if (accessMode == InteropAccessMode.Default)
			{
				accessMode = s_DefaultAccessMode;
			}
			lock (s_Lock)
			{
				if (!s_Registry.ContainsKey(type))
				{
					if (descriptor == null)
					{
						if (type.GetInterfaces().Any((Type ii) => ii == typeof(IUserDataType)))
						{
							AutoDescribingUserDataDescriptor autoDescribingUserDataDescriptor = new AutoDescribingUserDataDescriptor(type, friendlyName);
							s_Registry.Add(type, autoDescribingUserDataDescriptor);
							return autoDescribingUserDataDescriptor;
						}
						if (type.IsEnum)
						{
							StandardEnumUserDataDescriptor standardEnumUserDataDescriptor = new StandardEnumUserDataDescriptor(type, friendlyName);
							s_Registry.Add(type, standardEnumUserDataDescriptor);
							return standardEnumUserDataDescriptor;
						}
						StandardUserDataDescriptor udd = new StandardUserDataDescriptor(type, accessMode, friendlyName);
						s_Registry.Add(type, udd);
						if (accessMode == InteropAccessMode.BackgroundOptimized)
						{
							ThreadPool.QueueUserWorkItem(delegate
							{
								((IOptimizableDescriptor)udd).Optimize();
							});
						}
						return udd;
					}
					s_Registry.Add(type, descriptor);
					return descriptor;
				}
				return s_Registry[type];
			}
		}

		private static IUserDataDescriptor GetDescriptorForType<T>(bool searchInterfaces)
		{
			return GetDescriptorForType(typeof(T), searchInterfaces);
		}

		private static IUserDataDescriptor GetDescriptorForType(Type type, bool searchInterfaces)
		{
			lock (s_Lock)
			{
				IUserDataDescriptor userDataDescriptor = null;
				if (s_Registry.ContainsKey(type))
				{
					return s_Registry[type];
				}
				if (RegistrationPolicy == InteropRegistrationPolicy.Automatic && !typeof(Delegate).IsAssignableFrom(type))
				{
					return RegisterType_Impl(type, DefaultAccessMode, type.FullName, null);
				}
				for (Type type2 = type; type2 != null; type2 = type2.BaseType)
				{
					IUserDataDescriptor value;
					if (s_Registry.TryGetValue(type2, out value))
					{
						userDataDescriptor = value;
						break;
					}
				}
				if (!searchInterfaces)
				{
					return userDataDescriptor;
				}
				List<IUserDataDescriptor> list = new List<IUserDataDescriptor>();
				if (userDataDescriptor != null)
				{
					list.Add(userDataDescriptor);
				}
				if (searchInterfaces)
				{
					Type[] interfaces = type.GetInterfaces();
					foreach (Type key in interfaces)
					{
						IUserDataDescriptor value2;
						if (s_Registry.TryGetValue(key, out value2))
						{
							list.Add(value2);
						}
					}
				}
				if (list.Count == 1)
				{
					return list[0];
				}
				if (list.Count == 0)
				{
					return null;
				}
				return new CompositeUserDataDescriptor(list, type);
			}
		}

		private static IUserDataDescriptor GetDescriptorForObject(object o)
		{
			return GetDescriptorForType(o.GetType(), true);
		}
	}
}
