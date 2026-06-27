using System;
using System.Collections.Generic;
using Castle.Core.Logging;
using Castle.DynamicProxy.Generators;
using Castle.DynamicProxy.Generators.Emitters;
using Castle.DynamicProxy.Internal;

namespace Castle.DynamicProxy.Contributors
{
	internal abstract class CompositeTypeContributor : ITypeContributor
	{
		private sealed class MembersCollectorSink : IMembersCollectorSink
		{
			private readonly MetaType model;

			private readonly CompositeTypeContributor contributor;

			public MembersCollectorSink(MetaType model, CompositeTypeContributor contributor)
			{
				this.model = model;
				this.contributor = contributor;
			}

			public void Add(MetaEvent @event)
			{
				model.AddEvent(@event);
				contributor.events.Add(@event);
			}

			public void Add(MetaMethod method)
			{
				model.AddMethod(method);
				contributor.methods.Add(method);
			}

			public void Add(MetaProperty property)
			{
				model.AddProperty(property);
				contributor.properties.Add(property);
			}
		}

		protected readonly INamingScope namingScope;

		protected readonly ICollection<Type> interfaces = new HashSet<Type>();

		private ILogger logger = NullLogger.Instance;

		private readonly List<MetaProperty> properties = new List<MetaProperty>();

		private readonly List<MetaEvent> events = new List<MetaEvent>();

		private readonly List<MetaMethod> methods = new List<MetaMethod>();

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
			MembersCollectorSink sink = new MembersCollectorSink(model, this);
			foreach (MembersCollector collector in GetCollectors())
			{
				collector.CollectMembersToProxy(hook, sink);
			}
		}

		protected abstract IEnumerable<MembersCollector> GetCollectors();

		public virtual void Generate(ClassEmitter @class)
		{
			foreach (MetaMethod method in methods)
			{
				if (method.Standalone)
				{
					ImplementMethod(method, @class, @class.CreateMethod);
				}
			}
			foreach (MetaProperty property in properties)
			{
				ImplementProperty(@class, property);
			}
			foreach (MetaEvent @event in events)
			{
				ImplementEvent(@class, @event);
			}
		}

		public void AddInterfaceToProxy(Type @interface)
		{
			interfaces.Add(@interface);
		}

		private void ImplementEvent(ClassEmitter emitter, MetaEvent @event)
		{
			@event.BuildEventEmitter(emitter);
			ImplementMethod(@event.Adder, emitter, @event.Emitter.CreateAddMethod);
			ImplementMethod(@event.Remover, emitter, @event.Emitter.CreateRemoveMethod);
		}

		private void ImplementProperty(ClassEmitter emitter, MetaProperty property)
		{
			property.BuildPropertyEmitter(emitter);
			if (property.CanRead)
			{
				ImplementMethod(property.Getter, emitter, property.Emitter.CreateGetMethod);
			}
			if (property.CanWrite)
			{
				ImplementMethod(property.Setter, emitter, property.Emitter.CreateSetMethod);
			}
		}

		protected abstract MethodGenerator GetMethodGenerator(MetaMethod method, ClassEmitter @class, OverrideMethodDelegate overrideMethod);

		private void ImplementMethod(MetaMethod method, ClassEmitter @class, OverrideMethodDelegate overrideMethod)
		{
			MethodGenerator methodGenerator = GetMethodGenerator(method, @class, overrideMethod);
			if (methodGenerator == null)
			{
				return;
			}
			MethodEmitter methodEmitter = methodGenerator.Generate(@class, namingScope);
			foreach (CustomAttributeInfo nonInheritableAttribute in method.Method.GetNonInheritableAttributes())
			{
				methodEmitter.DefineCustomAttribute(nonInheritableAttribute.Builder);
			}
		}
	}
}
