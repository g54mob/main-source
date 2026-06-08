using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Xml;
using Castle.Components.DictionaryAdapter.Xml;
using Castle.Core.Internal;

namespace Castle.Components.DictionaryAdapter
{
	public class DictionaryAdapterFactory : IDictionaryAdapterFactory
	{
		private readonly SynchronizedDictionary<Type, DictionaryAdapterMeta> interfaceToMeta = new SynchronizedDictionary<Type, DictionaryAdapterMeta>();

		private static readonly PropertyInfo AdapterGetMeta = typeof(IDictionaryAdapter).GetProperty("Meta");

		private static readonly ConstructorInfo BaseCtor = typeof(DictionaryAdapterBase).GetConstructors()[0];

		private static readonly Type[] ConstructorParameterTypes = new Type[1] { typeof(DictionaryAdapterInstance) };

		private static readonly MethodInfo AdapterGetProperty = typeof(IDictionaryAdapter).GetMethod("GetProperty");

		private static readonly MethodInfo AdapterSetProperty = typeof(IDictionaryAdapter).GetMethod("SetProperty");

		private static readonly HashSet<Type> InfrastructureTypes = new HashSet<Type>
		{
			typeof(IEditableObject),
			typeof(IDictionaryEdit),
			typeof(IChangeTracking),
			typeof(IRevertibleChangeTracking),
			typeof(IDictionaryNotify),
			typeof(IDataErrorInfo),
			typeof(IDictionaryValidate),
			typeof(IDictionaryAdapter)
		};

		public T GetAdapter<T>(IDictionary dictionary)
		{
			return (T)GetAdapter(typeof(T), dictionary);
		}

		public object GetAdapter(Type type, IDictionary dictionary)
		{
			return InternalGetAdapter(type, dictionary, null);
		}

		public object GetAdapter(Type type, IDictionary dictionary, PropertyDescriptor descriptor)
		{
			return InternalGetAdapter(type, dictionary, descriptor);
		}

		public T GetAdapter<T, R>(IDictionary<string, R> dictionary)
		{
			return (T)GetAdapter(typeof(T), dictionary);
		}

		public object GetAdapter<R>(Type type, IDictionary<string, R> dictionary)
		{
			GenericDictionaryAdapter<R> dictionary2 = new GenericDictionaryAdapter<R>(dictionary);
			return InternalGetAdapter(type, dictionary2, null);
		}

		public T GetAdapter<T>(NameValueCollection nameValues)
		{
			return GetAdapter<T>(new NameValueCollectionAdapter(nameValues));
		}

		public object GetAdapter(Type type, NameValueCollection nameValues)
		{
			return GetAdapter(type, new NameValueCollectionAdapter(nameValues));
		}

		public T GetAdapter<T>(XmlNode xmlNode)
		{
			return (T)GetAdapter(typeof(T), xmlNode);
		}

		public object GetAdapter(Type type, XmlNode xmlNode)
		{
			XmlAdapter behavior = new XmlAdapter(xmlNode);
			return GetAdapter(type, new Hashtable(), new PropertyDescriptor().AddBehavior(XmlMetadataBehavior.Default).AddBehavior(behavior));
		}

		public DictionaryAdapterMeta GetAdapterMeta(Type type)
		{
			return GetAdapterMeta(type, (PropertyDescriptor)null);
		}

		public DictionaryAdapterMeta GetAdapterMeta(Type type, PropertyDescriptor descriptor)
		{
			return InternalGetAdapterMeta(type, descriptor, null);
		}

		public DictionaryAdapterMeta GetAdapterMeta(Type type, DictionaryAdapterMeta other)
		{
			return InternalGetAdapterMeta(type, null, other);
		}

		private DictionaryAdapterMeta InternalGetAdapterMeta(Type type, PropertyDescriptor descriptor, DictionaryAdapterMeta other)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (!type.IsInterface)
			{
				throw new ArgumentException("Only interfaces can be adapted to a dictionary", "type");
			}
			return interfaceToMeta.GetOrAdd(type, delegate
			{
				if (descriptor == null && other != null)
				{
					descriptor = other.CreateDescriptor();
				}
				TypeBuilder typeBuilder = CreateTypeBuilder(type);
				return CreateAdapterMeta(type, typeBuilder, descriptor);
			});
		}

		private object InternalGetAdapter(Type type, IDictionary dictionary, PropertyDescriptor descriptor)
		{
			return InternalGetAdapterMeta(type, descriptor, null).CreateInstance(dictionary, descriptor);
		}

		private static TypeBuilder CreateTypeBuilder(Type type)
		{
			ModuleBuilder moduleBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("CastleDictionaryAdapterAssembly"), AssemblyBuilderAccess.Run).DefineDynamicModule("CastleDictionaryAdapterModule");
			return CreateAdapterType(type, moduleBuilder);
		}

		private static TypeBuilder CreateAdapterType(Type type, ModuleBuilder moduleBuilder)
		{
			TypeBuilder typeBuilder = moduleBuilder.DefineType("CastleDictionaryAdapterType", TypeAttributes.Public | TypeAttributes.BeforeFieldInit);
			typeBuilder.AddInterfaceImplementation(type);
			typeBuilder.SetParent(typeof(DictionaryAdapterBase));
			Type[] types = new Type[1] { typeof(Type) };
			ConstructorInfo constructor = typeof(DictionaryAdapterAttribute).GetConstructor(types);
			object[] constructorArgs = new Type[1] { type };
			CustomAttributeBuilder customAttribute = new CustomAttributeBuilder(constructor, constructorArgs);
			typeBuilder.SetCustomAttribute(customAttribute);
			Type[] types2 = new Type[1] { typeof(string) };
			ConstructorInfo constructor2 = typeof(DebuggerDisplayAttribute).GetConstructor(types2);
			constructorArgs = new string[1] { "Type: {Meta.Type.FullName,nq}" };
			CustomAttributeBuilder customAttribute2 = new CustomAttributeBuilder(constructor2, constructorArgs);
			typeBuilder.SetCustomAttribute(customAttribute2);
			return typeBuilder;
		}

		private DictionaryAdapterMeta CreateAdapterMeta(Type type, TypeBuilder typeBuilder, PropertyDescriptor descriptor)
		{
			FieldAttributes attributes = FieldAttributes.Public | FieldAttributes.Static;
			FieldBuilder field = typeBuilder.DefineField("__meta", typeof(DictionaryAdapterMeta), attributes);
			ConstructorInfo constructor = CreateAdapterConstructor(typeBuilder);
			CreateAdapterFactoryMethod(typeBuilder, constructor);
			PropertyDescriptor propertyDescriptor = new PropertyDescriptor();
			object[] typeBehaviors;
			Dictionary<string, PropertyDescriptor> propertyDescriptors = GetPropertyDescriptors(type, propertyDescriptor, out typeBehaviors);
			if (descriptor != null)
			{
				propertyDescriptor.AddBehaviors(descriptor.MetaInitializers);
				typeBehaviors = typeBehaviors.Union(descriptor.Annotations).ToArray();
			}
			CreateMetaProperty(typeBuilder, AdapterGetMeta, field);
			foreach (KeyValuePair<string, PropertyDescriptor> item in propertyDescriptors)
			{
				CreateAdapterProperty(typeBuilder, item.Value);
			}
			TypeInfo typeInfo = typeBuilder.CreateTypeInfo();
			Func<DictionaryAdapterInstance, IDictionaryAdapter> creator = (Func<DictionaryAdapterInstance, IDictionaryAdapter>)typeInfo.GetDeclaredMethod("__Create").CreateDelegate(typeof(Func<DictionaryAdapterInstance, IDictionaryAdapter>));
			DictionaryAdapterMeta dictionaryAdapterMeta = new DictionaryAdapterMeta(type, typeInfo, typeBehaviors, propertyDescriptor.MetaInitializers.ToArray(), propertyDescriptor.Initializers.ToArray(), propertyDescriptors, this, creator);
			typeInfo.GetField("__meta", BindingFlags.Static | BindingFlags.Public).SetValue(typeInfo, dictionaryAdapterMeta);
			return dictionaryAdapterMeta;
		}

		private static ConstructorInfo CreateAdapterConstructor(TypeBuilder typeBuilder)
		{
			ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public | MethodAttributes.HideBySig, CallingConventions.Standard, ConstructorParameterTypes);
			ILGenerator iLGenerator = constructorBuilder.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldarg_1);
			iLGenerator.Emit(OpCodes.Call, BaseCtor);
			iLGenerator.Emit(OpCodes.Ret);
			return constructorBuilder;
		}

		private static void CreateAdapterFactoryMethod(TypeBuilder typeBuilder, ConstructorInfo constructor)
		{
			ILGenerator iLGenerator = typeBuilder.DefineMethod("__Create", MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig, typeof(IDictionaryAdapter), ConstructorParameterTypes).GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Newobj, constructor);
			iLGenerator.Emit(OpCodes.Ret);
		}

		private static void CreateMetaProperty(TypeBuilder typeBuilder, PropertyInfo prop, FieldInfo field)
		{
			MethodBuilder methodBuilder = typeBuilder.DefineMethod("get_" + prop.Name, MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.SpecialName, prop.PropertyType, null);
			ILGenerator iLGenerator = methodBuilder.GetILGenerator();
			if (field.IsStatic)
			{
				iLGenerator.Emit(OpCodes.Ldsfld, field);
			}
			else
			{
				iLGenerator.Emit(OpCodes.Ldarg_0);
				iLGenerator.Emit(OpCodes.Ldfld, field);
			}
			iLGenerator.Emit(OpCodes.Ret);
			typeBuilder.DefineMethodOverride(methodBuilder, prop.GetGetMethod());
		}

		private static void CreateAdapterProperty(TypeBuilder typeBuilder, PropertyDescriptor descriptor)
		{
			PropertyInfo property = descriptor.Property;
			PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(property.Name, property.Attributes, property.PropertyType, null);
			if (property.CanRead)
			{
				CreatePropertyGetMethod(typeBuilder, propertyBuilder, descriptor, MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.SpecialName);
			}
			if (property.CanWrite)
			{
				CreatePropertySetMethod(typeBuilder, propertyBuilder, descriptor, MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.SpecialName);
			}
		}

		private static void PreparePropertyMethod(PropertyDescriptor descriptor, ILGenerator propILGenerator)
		{
			propILGenerator.DeclareLocal(typeof(string));
			propILGenerator.DeclareLocal(typeof(object));
			propILGenerator.Emit(OpCodes.Ldstr, descriptor.PropertyName);
			propILGenerator.Emit(OpCodes.Stloc_0);
		}

		private static void CreatePropertyGetMethod(TypeBuilder typeBuilder, PropertyBuilder propertyBuilder, PropertyDescriptor descriptor, MethodAttributes propAttribs)
		{
			MethodBuilder methodBuilder = typeBuilder.DefineMethod("get_" + descriptor.PropertyName, propAttribs, descriptor.PropertyType, null);
			ILGenerator iLGenerator = methodBuilder.GetILGenerator();
			Label label = iLGenerator.DefineLabel();
			Label label2 = iLGenerator.DefineLabel();
			Label label3 = iLGenerator.DefineLabel();
			PreparePropertyMethod(descriptor, iLGenerator);
			LocalBuilder local = iLGenerator.DeclareLocal(descriptor.PropertyType);
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldloc_0);
			iLGenerator.Emit(OpCodes.Ldc_I4_0);
			iLGenerator.Emit(OpCodes.Callvirt, AdapterGetProperty);
			iLGenerator.Emit(OpCodes.Stloc_1);
			iLGenerator.Emit(OpCodes.Ldloc_1);
			iLGenerator.Emit(OpCodes.Brfalse_S, label);
			iLGenerator.Emit(OpCodes.Ldloc_1);
			iLGenerator.Emit(OpCodes.Unbox_Any, descriptor.PropertyType);
			iLGenerator.Emit(OpCodes.Br_S, label2);
			iLGenerator.MarkLabel(label);
			iLGenerator.Emit(OpCodes.Ldloca_S, local);
			iLGenerator.Emit(OpCodes.Initobj, descriptor.PropertyType);
			iLGenerator.Emit(OpCodes.Br_S, label3);
			iLGenerator.MarkLabel(label2);
			iLGenerator.Emit(OpCodes.Stloc_S, local);
			iLGenerator.MarkLabel(label3);
			iLGenerator.Emit(OpCodes.Ldloc_S, local);
			iLGenerator.Emit(OpCodes.Ret);
			propertyBuilder.SetGetMethod(methodBuilder);
		}

		private static void CreatePropertySetMethod(TypeBuilder typeBuilder, PropertyBuilder propertyBuilder, PropertyDescriptor descriptor, MethodAttributes propAttribs)
		{
			MethodBuilder methodBuilder = typeBuilder.DefineMethod("set_" + descriptor.PropertyName, propAttribs, null, new Type[1] { descriptor.PropertyType });
			ILGenerator iLGenerator = methodBuilder.GetILGenerator();
			PreparePropertyMethod(descriptor, iLGenerator);
			iLGenerator.Emit(OpCodes.Ldarg_1);
			if (descriptor.PropertyType.IsValueType)
			{
				iLGenerator.Emit(OpCodes.Box, descriptor.PropertyType);
			}
			iLGenerator.Emit(OpCodes.Stloc_1);
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldloc_0);
			iLGenerator.Emit(OpCodes.Ldloca_S, 1);
			iLGenerator.Emit(OpCodes.Callvirt, AdapterSetProperty);
			iLGenerator.Emit(OpCodes.Pop);
			iLGenerator.Emit(OpCodes.Ret);
			propertyBuilder.SetSetMethod(methodBuilder);
		}

		private static Dictionary<string, PropertyDescriptor> GetPropertyDescriptors(Type type, PropertyDescriptor initializers, out object[] typeBehaviors)
		{
			Dictionary<string, PropertyDescriptor> propertyMap = new Dictionary<string, PropertyDescriptor>();
			object[] interfaceBehaviors = (typeBehaviors = ExpandBehaviors(InterfaceAttributeUtil.GetAttributes(type, inherit: true)).ToArray());
			bool defaultFetch = typeBehaviors.OfType<FetchAttribute>().Select((Func<FetchAttribute, bool?>)((FetchAttribute b) => b.Fetch)).FirstOrDefault() == true;
			initializers.AddBehaviors(typeBehaviors.OfType<IDictionaryMetaInitializer>()).AddBehaviors(typeBehaviors.OfType<IDictionaryInitializer>());
			CollectProperties(type, delegate(PropertyInfo property, Type reflectedType)
			{
				object[] array = ExpandBehaviors(property.GetCustomAttributes(inherit: false)).ToArray();
				PropertyDescriptor propertyDescriptor = new PropertyDescriptor(property, array).AddBehaviors(array.OfType<IDictionaryBehavior>()).AddBehaviors(from b in interfaceBehaviors.OfType<IDictionaryBehavior>()
					where !(b is IDictionaryKeyBuilder)
					select b);
				IEnumerable<IDictionaryKeyBuilder> behaviors = ExpandBehaviors(InterfaceAttributeUtil.GetAttributes(reflectedType, inherit: true)).OfType<IDictionaryKeyBuilder>();
				propertyDescriptor = propertyDescriptor.AddBehaviors(behaviors);
				AddDefaultGetter(propertyDescriptor);
				bool? flag = array.OfType<FetchAttribute>().Select((Func<FetchAttribute, bool?>)((FetchAttribute b) => b.Fetch)).FirstOrDefault();
				propertyDescriptor.IfExists = array.OfType<IfExistsAttribute>().Any();
				propertyDescriptor.Fetch = flag.GetValueOrDefault(defaultFetch);
				foreach (IPropertyDescriptorInitializer item in propertyDescriptor.Behaviors.OfType<IPropertyDescriptorInitializer>())
				{
					item.Initialize(propertyDescriptor, array);
				}
				initializers.AddBehaviors(array.OfType<IDictionaryMetaInitializer>());
				if (propertyMap.TryGetValue(property.Name, out var value) && value.Property.PropertyType == property.PropertyType)
				{
					if (property.CanRead && property.CanWrite)
					{
						propertyMap[property.Name] = propertyDescriptor;
					}
				}
				else
				{
					propertyMap.Add(property.Name, propertyDescriptor);
				}
			});
			return propertyMap;
		}

		private static IEnumerable<object> ExpandBehaviors(IEnumerable<object> behaviors)
		{
			foreach (object behavior in behaviors)
			{
				if (behavior is IDictionaryBehaviorBuilder)
				{
					object[] array = ((IDictionaryBehaviorBuilder)behavior).BuildBehaviors();
					for (int i = 0; i < array.Length; i++)
					{
						yield return array[i];
					}
				}
				else
				{
					yield return behavior;
				}
			}
		}

		private static void CollectProperties(Type currentType, Action<PropertyInfo, Type> onProperty)
		{
			List<Type> list = new List<Type>();
			list.Add(currentType);
			list.AddRange(currentType.GetInterfaces());
			foreach (Type item in list.Where((Type t) => !InfrastructureTypes.Contains(t)))
			{
				PropertyInfo[] properties = item.GetProperties(BindingFlags.Instance | BindingFlags.Public);
				foreach (PropertyInfo arg in properties)
				{
					onProperty(arg, item);
				}
			}
		}

		private static void AddDefaultGetter(PropertyDescriptor descriptor)
		{
			if (descriptor.TypeConverter != null)
			{
				descriptor.AddBehavior(new DefaultPropertyGetter(descriptor.TypeConverter));
			}
		}
	}
}
