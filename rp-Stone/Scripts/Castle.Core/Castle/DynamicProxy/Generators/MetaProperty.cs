using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy.Generators
{
	public class MetaProperty : MetaTypeElement, IEquatable<MetaProperty>
	{
		private readonly Type[] arguments;

		private readonly PropertyAttributes attributes;

		private readonly IEnumerable<CustomAttributeBuilder> customAttributes;

		private readonly MetaMethod getter;

		private readonly MetaMethod setter;

		private readonly Type type;

		private PropertyEmitter emitter;

		private string name;

		public Type[] Arguments => arguments;

		public bool CanRead => getter != null;

		public bool CanWrite => setter != null;

		public PropertyEmitter Emitter
		{
			get
			{
				if (emitter == null)
				{
					throw new InvalidOperationException("Emitter is not initialized. You have to initialize it first using 'BuildPropertyEmitter' method");
				}
				return emitter;
			}
		}

		public MethodInfo GetMethod
		{
			get
			{
				if (!CanRead)
				{
					throw new InvalidOperationException();
				}
				return getter.Method;
			}
		}

		public MetaMethod Getter => getter;

		public MethodInfo SetMethod
		{
			get
			{
				if (!CanWrite)
				{
					throw new InvalidOperationException();
				}
				return setter.Method;
			}
		}

		public MetaMethod Setter => setter;

		public MetaProperty(string name, Type propertyType, Type declaringType, MetaMethod getter, MetaMethod setter, IEnumerable<CustomAttributeBuilder> customAttributes, Type[] arguments)
			: base(declaringType)
		{
			this.name = name;
			type = propertyType;
			this.getter = getter;
			this.setter = setter;
			attributes = PropertyAttributes.None;
			this.customAttributes = customAttributes;
			this.arguments = arguments ?? Type.EmptyTypes;
		}

		public void BuildPropertyEmitter(ClassEmitter classEmitter)
		{
			if (emitter != null)
			{
				throw new InvalidOperationException("Emitter is already created. It is illegal to invoke this method twice.");
			}
			emitter = classEmitter.CreateProperty(name, attributes, type, arguments);
			foreach (CustomAttributeBuilder customAttribute in customAttributes)
			{
				emitter.DefineCustomAttribute(customAttribute);
			}
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != typeof(MetaProperty))
			{
				return false;
			}
			return Equals((MetaProperty)obj);
		}

		public override int GetHashCode()
		{
			return (((GetMethod != null) ? GetMethod.GetHashCode() : 0) * 397) ^ ((SetMethod != null) ? SetMethod.GetHashCode() : 0);
		}

		public bool Equals(MetaProperty other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (!type.Equals(other.type))
			{
				return false;
			}
			if (!StringComparer.OrdinalIgnoreCase.Equals(name, other.name))
			{
				return false;
			}
			if (Arguments.Length != other.Arguments.Length)
			{
				return false;
			}
			for (int i = 0; i < Arguments.Length; i++)
			{
				if (!Arguments[i].Equals(other.Arguments[i]))
				{
					return false;
				}
			}
			return true;
		}

		internal override void SwitchToExplicitImplementation()
		{
			name = MetaTypeElementUtil.CreateNameForExplicitImplementation(sourceType, name);
			if (setter != null)
			{
				setter.SwitchToExplicitImplementation();
			}
			if (getter != null)
			{
				getter.SwitchToExplicitImplementation();
			}
		}
	}
}
