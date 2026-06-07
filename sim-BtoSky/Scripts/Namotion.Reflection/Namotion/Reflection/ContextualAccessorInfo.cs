using System;
using System.Collections.Generic;
using System.Linq;

namespace Namotion.Reflection
{
	public abstract class ContextualAccessorInfo : ContextualMemberInfo
	{
		public abstract ContextualType AccessorType { get; }

		public Nullability Nullability => AccessorType.Nullability;

		public Attribute[] ContextAttributes => AccessorType.ContextAttributes;

		public abstract object? GetValue(object? obj);

		public abstract void SetValue(object? obj, object? value);

		public T? GetContextAttribute<T>()
		{
			return ContextAttributes.GetSingleOrDefault<T>();
		}

		public IEnumerable<T> GetContextAttributes<T>()
		{
			return ContextAttributes.OfType<T>();
		}
	}
}
