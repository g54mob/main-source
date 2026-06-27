using System;

namespace NSubstitute.Core.Arguments
{
	public interface IArgumentSpecification
	{
		Type ForType { get; }

		bool HasAction { get; }

		bool IsSatisfiedBy(object? argument);

		IArgumentSpecification CreateCopyMatchingAnyArgOfType(Type requiredType);

		void RunAction(object? argument);

		string DescribeNonMatch(object? argument);

		string FormatArgument(object? argument);
	}
}
