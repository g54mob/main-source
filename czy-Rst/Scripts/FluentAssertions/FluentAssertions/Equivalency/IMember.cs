using System;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency
{
	public interface IMember : INode
	{
		Type DeclaringType { get; }

		Type ReflectedType { get; }

		CSharpAccessModifier GetterAccessibility { get; }

		CSharpAccessModifier SetterAccessibility { get; }

		bool IsBrowsable { get; }

		object GetValue(object obj);
	}
}
