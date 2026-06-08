using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal abstract class AbstractTypeEmitter
	{
		private const MethodAttributes defaultAttributes = MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig;

		private readonly List<ConstructorEmitter> constructors;

		private readonly List<EventEmitter> events;

		private readonly IDictionary<string, FieldReference> fields = new Dictionary<string, FieldReference>(StringComparer.OrdinalIgnoreCase);

		private readonly List<MethodEmitter> methods;

		private readonly List<NestedClassEmitter> nested;

		private readonly List<PropertyEmitter> properties;

		private readonly TypeBuilder typeBuilder;

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

		public GenericTypeParameterBuilder[] GenericTypeParams => genericTypeParams;

		public TypeBuilder TypeBuilder => typeBuilder;

		protected AbstractTypeEmitter(TypeBuilder typeBuilder)
		{
			this.typeBuilder = typeBuilder;
			nested = new List<NestedClassEmitter>();
			methods = new List<MethodEmitter>();
			constructors = new List<ConstructorEmitter>();
			properties = new List<PropertyEmitter>();
			events = new List<EventEmitter>();
		}

		public void AddCustomAttributes(IEnumerable<CustomAttributeInfo> additionalAttributes)
		{
			foreach (CustomAttributeInfo additionalAttribute in additionalAttributes)
			{
				typeBuilder.SetCustomAttribute(additionalAttribute.Builder);
			}
		}

		public void AddNestedClass(NestedClassEmitter nestedClass)
		{
			nested.Add(nestedClass);
		}

		public virtual Type BuildType()
		{
			EnsureBuildersAreInAValidState();
			Type result = CreateType(typeBuilder);
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
				throw new InvalidOperationException("Cannot invoke me twice");
			}
			SetGenericTypeParameters(GenericUtil.CopyGenericArguments(methodToCopyGenericsFrom, typeBuilder));
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
			FieldReference fieldReference = new FieldReference(typeBuilder.DefineField(name, fieldType, atts));
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
			typeBuilder.SetCustomAttribute(attribute);
		}

		public void DefineCustomAttribute<TAttribute>(object[] constructorArguments) where TAttribute : Attribute
		{
			CustomAttributeInfo customAttributeInfo = AttributeUtil.CreateInfo(typeof(TAttribute), constructorArguments);
			typeBuilder.SetCustomAttribute(customAttributeInfo.Builder);
		}

		public void DefineCustomAttribute<TAttribute>() where TAttribute : Attribute, new()
		{
			CustomAttributeInfo customAttributeInfo = AttributeUtil.CreateInfo<TAttribute>();
			typeBuilder.SetCustomAttribute(customAttributeInfo.Builder);
		}

		public void DefineCustomAttributeFor<TAttribute>(FieldReference field) where TAttribute : Attribute, new()
		{
			CustomAttributeInfo customAttributeInfo = AttributeUtil.CreateInfo<TAttribute>();
			FieldBuilder fieldBuilder = field.FieldBuilder;
			if (fieldBuilder == null)
			{
				throw new ArgumentException("Invalid field reference.This reference does not point to field on type being generated", "field");
			}
			fieldBuilder.SetCustomAttribute(customAttributeInfo.Builder);
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

		public Type GetClosedParameterType(Type parameter)
		{
			if (parameter.IsGenericType)
			{
				Type[] genericArguments = parameter.GetGenericArguments();
				if (CloseGenericParametersIfAny(genericArguments))
				{
					return parameter.GetGenericTypeDefinition().MakeGenericType(genericArguments);
				}
			}
			if (parameter.IsGenericParameter)
			{
				return GetGenericArgument(parameter.GenericParameterPosition);
			}
			if (parameter.IsArray)
			{
				Type closedParameterType = GetClosedParameterType(parameter.GetElementType());
				int arrayRank = parameter.GetArrayRank();
				if (arrayRank != 1)
				{
					return closedParameterType.MakeArrayType(arrayRank);
				}
				return closedParameterType.MakeArrayType();
			}
			if (parameter.IsByRef)
			{
				return GetClosedParameterType(parameter.GetElementType()).MakeByRefType();
			}
			return parameter;
			bool CloseGenericParametersIfAny(Type[] arguments)
			{
				bool result = false;
				for (int i = 0; i < arguments.Length; i++)
				{
					Type closedParameterType2 = GetClosedParameterType(arguments[i]);
					if (closedParameterType2 != null && (object)closedParameterType2 != arguments[i])
					{
						arguments[i] = closedParameterType2;
						result = true;
					}
				}
				return result;
			}
		}

		public Type GetGenericArgument(int position)
		{
			return genericTypeParams[position];
		}

		public Type[] GetGenericArgumentsFor(MethodInfo genericMethod)
		{
			return genericTypeParams;
		}

		public void SetGenericTypeParameters(GenericTypeParameterBuilder[] genericTypeParameterBuilders)
		{
			genericTypeParams = genericTypeParameterBuilders;
		}

		protected Type CreateType(TypeBuilder type)
		{
			return type.CreateTypeInfo();
		}

		protected virtual void EnsureBuildersAreInAValidState()
		{
			if (!typeBuilder.IsInterface && constructors.Count == 0)
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
