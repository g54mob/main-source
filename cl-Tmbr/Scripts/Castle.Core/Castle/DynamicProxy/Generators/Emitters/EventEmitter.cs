using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal class EventEmitter : IMemberEmitter
	{
		private readonly EventBuilder eventBuilder;

		private readonly Type type;

		private readonly AbstractTypeEmitter typeEmitter;

		private MethodEmitter addMethod;

		private MethodEmitter removeMethod;

		public MemberInfo Member => null;

		public Type ReturnType => type;

		public EventEmitter(AbstractTypeEmitter typeEmitter, string name, EventAttributes attributes, Type type)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			this.typeEmitter = typeEmitter;
			this.type = type;
			eventBuilder = typeEmitter.TypeBuilder.DefineEvent(name, attributes, type);
		}

		public MethodEmitter CreateAddMethod(string addMethodName, MethodAttributes attributes, MethodInfo methodToOverride)
		{
			if (addMethod != null)
			{
				throw new InvalidOperationException("An add method exists");
			}
			addMethod = new MethodEmitter(typeEmitter, addMethodName, attributes, methodToOverride);
			return addMethod;
		}

		public MethodEmitter CreateRemoveMethod(string removeMethodName, MethodAttributes attributes, MethodInfo methodToOverride)
		{
			if (removeMethod != null)
			{
				throw new InvalidOperationException("A remove method exists");
			}
			removeMethod = new MethodEmitter(typeEmitter, removeMethodName, attributes, methodToOverride);
			return removeMethod;
		}

		public void EnsureValidCodeBlock()
		{
			addMethod.EnsureValidCodeBlock();
			removeMethod.EnsureValidCodeBlock();
		}

		public void Generate()
		{
			if (addMethod == null)
			{
				throw new InvalidOperationException("Event add method was not created");
			}
			if (removeMethod == null)
			{
				throw new InvalidOperationException("Event remove method was not created");
			}
			addMethod.Generate();
			eventBuilder.SetAddOnMethod(addMethod.MethodBuilder);
			removeMethod.Generate();
			eventBuilder.SetRemoveOnMethod(removeMethod.MethodBuilder);
		}
	}
}
