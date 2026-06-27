using System;

namespace NSubstitute.Core.Arguments
{
	public class ArgumentSpecification : IArgumentSpecification
	{
		private static readonly Action<object?> NoOpAction = delegate
		{
		};

		public Type ForType { get; }

		public bool HasAction => _003Caction_003EP != NoOpAction;

		public ArgumentSpecification(Type forType, IArgumentMatcher matcher, Action<object?> action)
		{
			_003Cmatcher_003EP = matcher;
			_003Caction_003EP = action;
			ForType = forType;
			base._002Ector();
		}

		public ArgumentSpecification(Type forType, IArgumentMatcher matcher)
			: this(forType, matcher, NoOpAction)
		{
		}

		public bool IsSatisfiedBy(object? argument)
		{
			if (!IsCompatibleWith(argument))
			{
				return false;
			}
			try
			{
				return _003Cmatcher_003EP.IsSatisfiedBy(argument);
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
			if (!(_003Cmatcher_003EP is IDescribeNonMatches describeNonMatches))
			{
				return string.Empty;
			}
			return describeNonMatches.DescribeFor(argument);
		}

		public string FormatArgument(object? argument)
		{
			bool flag = IsSatisfiedBy(argument);
			if (!(_003Cmatcher_003EP is IArgumentFormatter argumentFormatter))
			{
				return ArgumentFormatter.Default.Format(argument, !flag);
			}
			return argumentFormatter.Format(argument, !flag);
		}

		public override string ToString()
		{
			return _003Cmatcher_003EP.ToString() ?? string.Empty;
		}

		public IArgumentSpecification CreateCopyMatchingAnyArgOfType(Type requiredType)
		{
			return new ArgumentSpecification(requiredType, new AnyArgumentMatcher(requiredType), (_003Caction_003EP == NoOpAction) ? NoOpAction : new Action<object>(RunActionIfTypeIsCompatible));
		}

		public void RunAction(object? argument)
		{
			_003Caction_003EP(argument);
		}

		private void RunActionIfTypeIsCompatible(object? argument)
		{
			if (argument.IsCompatibleWith(ForType))
			{
				_003Caction_003EP(argument);
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
