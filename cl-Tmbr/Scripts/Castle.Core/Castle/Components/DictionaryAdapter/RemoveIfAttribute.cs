using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = true)]
	public class RemoveIfAttribute : DictionaryBehaviorAttribute, IDictionaryPropertySetter, IDictionaryBehavior
	{
		private class ValueCondition : ICondition
		{
			private readonly object[] values;

			private readonly IEqualityComparer comparer;

			public ValueCondition(object[] values, IEqualityComparer comparer)
			{
				this.values = values;
				this.comparer = comparer;
			}

			public bool SatisfiedBy(object value)
			{
				return values.Any((object valueToMatch) => (comparer == null) ? object.Equals(value, valueToMatch) : comparer.Equals(value, valueToMatch));
			}
		}

		private ICondition condition;

		public Type Condition
		{
			set
			{
				condition = Construct<ICondition>(value, "value");
			}
		}

		public RemoveIfAttribute()
		{
			base.ExecutionOrder += 10;
		}

		public RemoveIfAttribute(params object[] values)
			: this()
		{
			values = values ?? new object[1];
			condition = new ValueCondition(values, null);
		}

		public RemoveIfAttribute(object[] values, Type comparerType)
			: this()
		{
			IEqualityComparer comparer = Construct<IEqualityComparer>(comparerType, "comparerType");
			condition = new ValueCondition(values, comparer);
		}

		protected RemoveIfAttribute(ICondition condition)
			: this()
		{
			this.condition = condition;
		}

		bool IDictionaryPropertySetter.SetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, ref object value, PropertyDescriptor property)
		{
			if (ShouldRemove(value))
			{
				dictionaryAdapter.ClearProperty(property, key);
				return false;
			}
			return true;
		}

		internal bool ShouldRemove(object value)
		{
			if (condition != null)
			{
				return condition.SatisfiedBy(value);
			}
			return false;
		}

		private static TBase Construct<TBase>(Type type, string paramName) where TBase : class
		{
			if (type == null)
			{
				throw new ArgumentNullException(paramName);
			}
			if (!type.IsAbstract && typeof(TBase).IsAssignableFrom(type))
			{
				ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
				if (constructor != null)
				{
					return (TBase)constructor.Invoke(new object[0]);
				}
			}
			throw new ArgumentException($"{type.FullName} is not a concrete type implementing {typeof(TBase).FullName} with a default constructor");
		}
	}
}
