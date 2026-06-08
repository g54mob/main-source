using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Generators.Emitters
{
	public abstract class AbstractTypeEmitter
	{
		private const MethodAttributes defaultAttributes = MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig;

		private readonly ConstructorCollection constructors;

		private readonly EventCollection events;

		private readonly IDictionary<string, FieldReference> fields = new Dictionary<string, FieldReference>(StringComparer.OrdinalIgnoreCase);

		private readonly MethodCollection methods;

		private readonly Dictionary<string, GenericTypeParameterBuilder> name2GenericType;

		private readonly NestedClassCollection nested;

		private readonly PropertiesCollection properties;

		private readonly TypeBuilder typebuilder;

		private GenericTypeParameterBuilder[] genericTypeParams;

		public Type BaseType
		{
			get
			{
				if (TypeBuilder.IsInterface)
				{
					throw new InvalidOperationException("This emitter represents an interface; interfaces have no base types.");
				}
				return TypeBuilder.BaseType;
			}
		}

		public TypeConstructorEmitter ClassConstructor { get; private set; }

		public ConstructorCollection Constructors => constructors;

		public GenericTypeParameterBuilder[] GenericTypeParams => genericTypeParams;

		public NestedClassCollection Nested => nested;

		public TypeBuilder TypeBuilder => typebuilder;

		protected AbstractTypeEmitter(TypeBuilder typeBuilder)
		{
			typebuilder = typeBuilder;
			nested = new NestedClassCollection();
			methods = new MethodCollection();
			constructors = new ConstructorCollection();
			properties = new PropertiesCollection();
			events = new EventCollection();
			name2GenericType = new Dictionary<string, GenericTypeParameterBuilder>();
		}

		public void AddCustomAttributes(ProxyGenerationOptions proxyGenerationOptions)
		{
			foreach (CustomAttributeInfo additionalAttribute in proxyGenerationOptions.AdditionalAttributes)
			{
				typebuilder.SetCustomAttribute(additionalAttribute.Builder);
			}
		}

		public virtual Type BuildType()
		{
			EnsureBuildersAreInAValidState();
			Type result = CreateType(typebuilder);
			foreach (NestedClassEmitter item in nested)
			{
				item.BuildType();
			}
			return result;
		}

		public void CopyGenericParametersFromMethod(MethodInfo methodToCopyGenericsFrom)
		{
			if (genericTypeParams != null)
			{
				throw new ProxyGenerationException("CopyGenericParametersFromMethod: cannot invoke me twice");
			}
			SetGenericTypeParameters(GenericUtil.CopyGenericArguments(methodToCopyGenericsFrom, typebuilder, name2GenericType));
		}

		public ConstructorEmitter CreateConstructor(params ArgumentReference[] arguments)
		{
			if (TypeBuilder.IsInterface)
			{
				throw new InvalidOperationException("Interfaces cannot have constructors.");
			}
			ConstructorEmitter constructorEmitter = new ConstructorEmitter(this, arguments);
			constructors.Add(constructorEmitter);
			return constructorEmitter;
		}

		public void CreateDefaultConstructor()
		{
			if (TypeBuilder.IsInterface)
			{
				throw new InvalidOperationException("Interfaces cannot have constructors.");
			}
			constructors.Add(new ConstructorEmitter(this));
		}

		public EventEmitter CreateEvent(string name, EventAttributes atts, Type type)
		{
			EventEmitter eventEmitter = new EventEmitter(this, name, atts, type);
			events.Add(eventEmitter);
			return eventEmitter;
		}

		public FieldReference CreateField(string name, Type fieldType)
		{
			return CreateField(name, fieldType, serializable: true);
		}

		public FieldReference CreateField(string name, Type fieldType, bool serializable)
		{
			FieldAttributes fieldAttributes = FieldAttributes.Private;
			if (!serializable)
			{
				fieldAttributes |= FieldAttributes.NotSerialized;
			}
			return CreateField(name, fieldType, fieldAttributes);
		}

		public FieldReference CreateField(string name, Type fieldType, FieldAttributes atts)
		{
			FieldReference fieldReference = new FieldReference(typebuilder.DefineField(name, fieldType, atts));
			fields[name] = fieldReference;
			return fieldReference;
		}

		public MethodEmitter CreateMethod(string name, MethodAttributes attrs, Type returnType, params Type[] argumentTypes)
		{
			MethodEmitter methodEmitter = new MethodEmitter(this, name, attrs, returnType, argumentTypes ?? Type.EmptyTypes);
			methods.Add(methodEmitter);
			return methodEmitter;
		}

		public MethodEmitter CreateMethod(string name, Type returnType, params Type[] parameterTypes)
		{
			return CreateMethod(name, MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig, returnType, parameterTypes);
		}

		public MethodEmitter CreateMethod(string name, MethodInfo methodToUseAsATemplate)
		{
			return CreateMethod(name, MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig, methodToUseAsATemplate);
		}

		public MethodEmitter CreateMethod(string name, MethodAttributes attributes, MethodInfo methodToUseAsATemplate)
		{
			MethodEmitter methodEmitter = new MethodEmitter(this, name, attributes, methodToUseAsATemplate);
			methods.Add(methodEmitter);
			return methodEmitter;
		}

		public PropertyEmitter CreateProperty(string name, PropertyAttributes attributes, Type propertyType, Type[] arguments)
		{
			PropertyEmitter propertyEmitter = new PropertyEmitter(this, name, attributes, propertyType, arguments);
			properties.Add(propertyEmitter);
			return propertyEmitter;
		}

		public FieldReference CreateStaticField(string name, Type fieldType)
		{
			return CreateStaticField(name, fieldType, FieldAttributes.Private);
		}

		public FieldReference CreateStaticField(string name, Type fieldType, FieldAttributes atts)
		{
			atts |= FieldAttributes.Static;
			return CreateField(name, fieldType, atts);
		}

		public ConstructorEmitter CreateTypeConstructor()
		{
			TypeConstructorEmitter typeConstructorEmitter = new TypeConstructorEmitter(this);
			constructors.Add(typeConstructorEmitter);
			ClassConstructor = typeConstructorEmitter;
			return typeConstructorEmitter;
		}

		public void DefineCustomAttribute(CustomAttributeBuilder attribute)
		{
			typebuilder.SetCustomAttribute(attribute);
		}

		public void DefineCustomAttribute<TAttribute>(object[] constructorArguments) where TAttribute : Attribute
		{
			CustomAttributeInfo customAttributeInfo = AttributeUtil.CreateInfo(typeof(TAttribute), constructorArguments);
			typebuilder.SetCustomAttribute(customAttributeInfo.Builder);
		}

		public void DefineCustomAttribute<TAttribute>() where TAttribute : Attribute, new()
		{
			CustomAttributeInfo customAttributeInfo = AttributeUtil.CreateInfo<TAttribute>();
			typebuilder.SetCustomAttribute(customAttributeInfo.Builder);
		}

		public void DefineCustomAttributeFor<TAttribute>(FieldReference field) where TAttribute : Attribute, new()
		{
			CustomAttributeInfo customAttributeInfo = AttributeUtil.CreateInfo<TAttribute>();
			FieldBuilder fieldbuilder = field.Fieldbuilder;
			if (fieldbuilder == null)
			{
				throw new ArgumentException("Invalid field reference.This reference does not point to field on type being generated", "field");
			}
			fieldbuilder.SetCustomAttribute(customAttributeInfo.Builder);
		}

		public IEnumerable<FieldReference> GetAllFields()
		{
			return fields.Values;
		}

		public FieldReference GetField(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}
			fields.TryGetValue(name, out var value);
			return value;
		}

		public Type GetGenericArgument(string genericArgumentName)
		{
			if (name2GenericType.TryGetValue(genericArgumentName, out var value))
			{
				return value.AsType();
			}
			return null;
		}

		public Type[] GetGenericArgumentsFor(Type genericType)
		{
			List<Type> list = new List<Type>();
			Type[] genericArguments = genericType.GetGenericArguments();
			foreach (Type type in genericArguments)
			{
				if (type.GetTypeInfo().IsGenericParameter)
				{
					list.Add(name2GenericType[type.Name].AsType());
				}
				else
				{
					list.Add(type);
				}
			}
			return list.ToArray();
		}

		public Type[] GetGenericArgumentsFor(MethodInfo genericMethod)
		{
			List<Type> list = new List<Type>();
			Type[] genericArguments = genericMethod.GetGenericArguments();
			foreach (Type type in genericArguments)
			{
				list.Add(name2GenericType[type.Name].AsType());
			}
			return list.ToArray();
		}

		public void SetGenericTypeParameters(GenericTypeParameterBuilder[] genericTypeParameterBuilders)
		{
			genericTypeParams = genericTypeParameterBuilders;
		}

		protected Type CreateType(TypeBuilder type)
		{
			try
			{
				return type.CreateTypeInfo().AsType();
			}
			catch (BadImageFormatException ex)
			{
				if (!Debugger.IsAttached)
				{
					throw;
				}
				if (!ex.Message.Contains("HRESULT: 0x8007000B"))
				{
					throw;
				}
				if (!type.IsGenericTypeDefinition)
				{
					throw;
				}
				throw new ProxyGenerationException("This is a DynamicProxy2 error: It looks like you encountered a bug in Visual Studio debugger, which causes this exception when proxying types with generic methods having constraints on their generic arguments.This code will work just fine without the debugger attached. If you wish to use debugger you may have to switch to Visual Studio 2010 where this bug was fixed.")
				{
					Data = { 
					{
						(object)"ProxyType",
						(object)type.ToString()
					} }
				};
			}
		}

		protected virtual void EnsureBuildersAreInAValidState()
		{
			if (!typebuilder.IsInterface && constructors.Count == 0)
			{
				CreateDefaultConstructor();
			}
			foreach (PropertyEmitter property in properties)
			{
				((IMemberEmitter)property).EnsureValidCodeBlock();
				((IMemberEmitter)property).Generate();
			}
			foreach (EventEmitter @event in events)
			{
				((IMemberEmitter)@event).EnsureValidCodeBlock();
				((IMemberEmitter)@event).Generate();
			}
			foreach (ConstructorEmitter constructor in constructors)
			{
				((IMemberEmitter)constructor).EnsureValidCodeBlock();
				((IMemberEmitter)constructor).Generate();
			}
			foreach (MethodEmitter method in methods)
			{
				((IMemberEmitter)method).EnsureValidCodeBlock();
				((IMemberEmitter)method).Generate();
			}
		}
	}
}
