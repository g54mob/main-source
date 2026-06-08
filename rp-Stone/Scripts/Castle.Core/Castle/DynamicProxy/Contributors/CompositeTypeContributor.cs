using System;
using System.Collections.Generic;
using Castle.Core.Logging;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Contributors
{
	public abstract class CompositeTypeContributor : ITypeContributor
	{
		protected readonly INamingScope namingScope;

		protected readonly ICollection<Type> interfaces = new HashSet<Type>();

		private ILogger logger = NullLogger.Instance;

		private readonly ICollection<MetaProperty> properties = new TypeElementCollection<MetaProperty>();

		private readonly ICollection<MetaEvent> events = new TypeElementCollection<MetaEvent>();

		private readonly ICollection<MetaMethod> methods = new TypeElementCollection<MetaMethod>();

		public ILogger Logger
		{
			get
			{
				return logger;
			}
			set
			{
				logger = value;
			}
		}

		protected CompositeTypeContributor(INamingScope namingScope)
		{
			this.namingScope = namingScope;
		}

		public void CollectElementsToProxy(IProxyGenerationHook hook, MetaType model)
		{
			foreach (MembersCollector item in CollectElementsToProxyInternal(hook))
			{
				foreach (MetaMethod method in item.Methods)
				{
					model.AddMethod(method);
					methods.Add(method);
				}
				foreach (MetaEvent @event in item.Events)
				{
					model.AddEvent(@event);
					events.Add(@event);
				}
				foreach (MetaProperty property in item.Properties)
				{
					model.AddProperty(property);
					properties.Add(property);
				}
			}
		}

		protected abstract IEnumerable<MembersCollector> CollectElementsToProxyInternal(IProxyGenerationHook hook);

		public virtual void Generate(ClassEmitter @class, ProxyGenerationOptions options)
		{
			foreach (MetaMethod method in methods)
			{
				if (method.Standalone)
				{
					ImplementMethod(method, @class, options, @class.CreateMethod);
				}
			}
			foreach (MetaProperty property in properties)
			{
				ImplementProperty(@class, property, options);
			}
			foreach (MetaEvent @event in events)
			{
				ImplementEvent(@class, @event, options);
			}
		}

		public void AddInterfaceToProxy(Type @interface)
		{
			interfaces.Add(@interface);
		}

		private void ImplementEvent(ClassEmitter emitter, MetaEvent @event, ProxyGenerationOptions options)
		{
			@event.BuildEventEmitter(emitter);
			ImplementMethod(@event.Adder, emitter, options, @event.Emitter.CreateAddMethod);
			ImplementMethod(@event.Remover, emitter, options, @event.Emitter.CreateRemoveMethod);
		}

		private void ImplementProperty(ClassEmitter emitter, MetaProperty property, ProxyGenerationOptions options)
		{
			property.BuildPropertyEmitter(emitter);
			if (property.CanRead)
			{
				ImplementMethod(property.Getter, emitter, options, property.Emitter.CreateGetMethod);
			}
			if (property.CanWrite)
			{
				ImplementMethod(property.Setter, emitter, options, property.Emitter.CreateSetMethod);
			}
		}

		protected abstract MethodGenerator GetMethodGenerator(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options, OverrideMethodDelegate overrideMethod);

		private void ImplementMethod(MetaMethod method, ClassEmitter @class, ProxyGenerationOptions options, OverrideMethodDelegate overrideMethod)
		{
			MethodGenerator methodGenerator = GetMethodGenerator(method, @class, options, overrideMethod);
			if (methodGenerator == null)
			{
				return;
			}
			MethodEmitter methodEmitter = methodGenerator.Generate(@class, options, namingScope);
			foreach (CustomAttributeInfo nonInheritableAttribute in method.Method.GetNonInheritableAttributes())
			{
				methodEmitter.DefineCustomAttribute(nonInheritableAttribute.Builder);
			}
		}
	}
}
