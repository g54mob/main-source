using System;
using System.Reflection;
using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy.Generators
{
	public class MetaEvent : MetaTypeElement, IEquatable<MetaEvent>
	{
		private readonly MetaMethod adder;

		private readonly MetaMethod remover;

		private readonly Type type;

		private EventEmitter emitter;

		private string name;

		public MetaMethod Adder => adder;

		public EventAttributes Attributes { get; private set; }

		public EventEmitter Emitter
		{
			get
			{
				if (emitter != null)
				{
					return emitter;
				}
				throw new InvalidOperationException("Emitter is not initialized. You have to initialize it first using 'BuildEventEmitter' method");
			}
		}

		public MetaMethod Remover => remover;

		public MetaEvent(string name, Type declaringType, Type eventDelegateType, MetaMethod adder, MetaMethod remover, EventAttributes attributes)
			: base(declaringType)
		{
			if (adder == null)
			{
				throw new ArgumentNullException("adder");
			}
			if (remover == null)
			{
				throw new ArgumentNullException("remover");
			}
			this.name = name;
			type = eventDelegateType;
			this.adder = adder;
			this.remover = remover;
			Attributes = attributes;
		}

		public void BuildEventEmitter(ClassEmitter classEmitter)
		{
			if (emitter != null)
			{
				throw new InvalidOperationException();
			}
			emitter = classEmitter.CreateEvent(name, Attributes, type);
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
			if (obj.GetType() != typeof(MetaEvent))
			{
				return false;
			}
			return Equals((MetaEvent)obj);
		}

		public override int GetHashCode()
		{
			return (((((adder.Method != null) ? adder.Method.GetHashCode() : 0) * 397) ^ ((remover.Method != null) ? remover.Method.GetHashCode() : 0)) * 397) ^ Attributes.GetHashCode();
		}

		public bool Equals(MetaEvent other)
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
			return true;
		}

		internal override void SwitchToExplicitImplementation()
		{
			name = MetaTypeElementUtil.CreateNameForExplicitImplementation(sourceType, name);
			adder.SwitchToExplicitImplementation();
			remover.SwitchToExplicitImplementation();
		}
	}
}
