using System;

namespace NSubstitute.Core.Arguments
{
	public class ArgumentSpecification : IArgumentSpecification
	{
		private static readonly Action<object?> NoOpAction = delegate
		{
		};

		private readonly IArgumentMatcher _matcher;

		private readonly Action<object?> _action;

		public Type ForType { get; }

		public bool HasAction => _action != NoOpAction;

		public ArgumentSpecification(Type forType, IArgumentMatcher matcher)
			: this(forType, matcher, NoOpAction)
		{
		}

		public ArgumentSpecification(Type forType, IArgumentMatcher matcher, Action<object?> action)
		{
			ForType = forType;
			_matcher = matcher;
			_action = action;
		}

		public bool IsSatisfiedBy(object? argument)
		{
			if (!IsCompatibleWith(argument))
			{
				return false;
			}
			try
			{
				return _matcher.IsSatisfiedBy(argument);
			}
			catch
			{
				return false;
			}
		}

		public string DescribeNonMatch(object? argument)
		{
			if (!IsCompatibleWith(argument))
			{
				return GetIncompatibleTypeMessage(argument);
			}
			if (!(_matcher is IDescribeNonMatches describeNonMatches))
			{
				return string.Empty;
			}
			return describeNonMatches.DescribeFor(argument);
		}

		public string FormatArgument(object? argument)
		{
			bool flag = IsSatisfiedBy(argument);
			if (!(_matcher is IArgumentFormatter argumentFormatter))
			{
				return ArgumentFormatter.Default.Format(argument, !flag);
			}
			return argumentFormatter.Format(argument, !flag);
		}

		public override string ToString()
		{
			return _matcher.ToString() ?? string.Empty;
		}

		public IArgumentSpecification CreateCopyMatchingAnyArgOfType(Type requiredType)
		{
			return new ArgumentSpecification(requiredType, new AnyArgumentMatcher(requiredType), (_action == NoOpAction) ? NoOpAction : new Action<object>(RunActionIfTypeIsCompatible));
		}

		public void RunAction(object? argument)
		{
			_action(argument);
		}

		private void RunActionIfTypeIsCompatible(object? argument)
		{
			if (argument.IsCompatibleWith(ForType))
			{
				_action(argument);
			}
		}

		private bool IsCompatibleWith(object? argument)
		{
			return argument.IsCompatibleWith(ForType);
		}

		private string GetIncompatibleTypeMessage(object? argument)
		{
			Type arg = ((argument == null) ? typeof(object) : argument.GetType());
			return $"Expected an argument compatible with type '{ForType}'. Actual type was '{arg}'.";
		}
	}
}
