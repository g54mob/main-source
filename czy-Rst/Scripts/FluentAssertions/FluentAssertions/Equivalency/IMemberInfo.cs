using System;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency
{
	public interface IMemberInfo
	{
		string Name { get; }

		Type Type { get; }

		Type DeclaringType { get; }

		string Path { get; set; }

		CSharpAccessModifier GetterAccessibility { get; }

		CSharpAccessModifier SetterAccessibility { get; }
	}
}
