using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal class PropertyEmitter : IMemberEmitter
	{
		private readonly PropertyBuilder builder;

		private readonly AbstractTypeEmitter parentTypeEmitter;

		private MethodEmitter getMethod;

		private MethodEmitter setMethod;

		public MemberInfo Member => null;

		public Type ReturnType => builder.PropertyType;

		public PropertyEmitter(AbstractTypeEmitter parentTypeEmitter, string name, PropertyAttributes attributes, Type propertyType, Type[] arguments)
		{
			this.parentTypeEmitter = parentTypeEmitter;
			builder = parentTypeEmitter.TypeBuilder.DefineProperty(name, attributes, CallingConventions.HasThis, propertyType, null, null, arguments, null, null);
		}

		public MethodEmitter CreateGetMethod(string name, MethodAttributes attrs, MethodInfo methodToOverride, params Type[] parameters)
		{
			if (getMethod != null)
			{
				throw new InvalidOperationException("A get method exists");
			}
			getMethod = new MethodEmitter(parentTypeEmitter, name, attrs, methodToOverride);
			return getMethod;
		}

		public MethodEmitter CreateGetMethod(string name, MethodAttributes attributes, MethodInfo methodToOverride)
		{
			return CreateGetMethod(name, attributes, methodToOverride, Type.EmptyTypes);
		}

		public MethodEmitter CreateSetMethod(string name, MethodAttributes attrs, MethodInfo methodToOverride, params Type[] parameters)
		{
			if (setMethod != null)
			{
				throw new InvalidOperationException("A set method exists");
			}
			setMethod = new MethodEmitter(parentTypeEmitter, name, attrs, methodToOverride);
			return setMethod;
		}

		public MethodEmitter CreateSetMethod(string name, MethodAttributes attributes, MethodInfo methodToOverride)
		{
			return CreateSetMethod(name, attributes, methodToOverride, Type.EmptyTypes);
		}

		public void DefineCustomAttribute(CustomAttributeBuilder attribute)
		{
			builder.SetCustomAttribute(attribute);
		}

		public void EnsureValidCodeBlock()
		{
			if (setMethod != null)
			{
				setMethod.EnsureValidCodeBlock();
			}
			if (getMethod != null)
			{
				getMethod.EnsureValidCodeBlock();
			}
		}

		public void Generate()
		{
			if (setMethod != null)
			{
				setMethod.Generate();
				builder.SetSetMethod(setMethod.MethodBuilder);
			}
			if (getMethod != null)
			{
				getMethod.Generate();
				builder.SetGetMethod(getMethod.MethodBuilder);
			}
		}
	}
}
