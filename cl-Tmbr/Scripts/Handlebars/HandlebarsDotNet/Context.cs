using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using HandlebarsDotNet.ObjectDescriptors;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet
{
	public readonly struct Context
	{
		private readonly DeferredValue<BindingContext, ObjectDescriptor> _descriptor;

		public readonly object Value;

		public IEnumerable<ChainSegment> Properties => from o in _descriptor.Value.GetProperties(_descriptor.Value, Value).OfType<object>()
			select ChainSegment.Create(o);

		public object this[ChainSegment segment]
		{
			get
			{
				if (!_descriptor.Value.MemberAccessor.TryGetValue(Value, segment, out var value))
				{
					return null;
				}
				return value;
			}
		}

		public Context(BindingContext context)
		{
			Value = context.Value;
			_descriptor = context.Descriptor;
		}

		public Context(BindingContext context, object value)
		{
			Value = value;
			_descriptor = context.Descriptor;
		}

		public T GetValue<T>(ChainSegment segment)
		{
			if (!_descriptor.Value.MemberAccessor.TryGetValue(Value, segment, out var value))
			{
				return default(T);
			}
			if (value is T)
			{
				return (T)value;
			}
			return (T)TypeDescriptor.GetConverter(value.GetType()).ConvertTo(value, typeof(T));
		}
	}
}
