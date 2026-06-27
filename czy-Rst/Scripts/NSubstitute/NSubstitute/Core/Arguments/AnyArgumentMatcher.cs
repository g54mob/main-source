using System;

namespace NSubstitute.Core.Arguments
{
	public class AnyArgumentMatcher : IArgumentMatcher
	{
		public AnyArgumentMatcher(Type typeArgMustBeCompatibleWith)
		{
			_003CtypeArgMustBeCompatibleWith_003EP = typeArgMustBeCompatibleWith;
			base._002Ector();
		}

		public override string ToString()
		{
			return "any " + _003CtypeArgMustBeCompatibleWith_003EP.GetNonMangledTypeName();
		}

		public bool IsSatisfiedBy(object? argument)
		{
			return argument.IsCompatibleWith(_003CtypeArgMustBeCompatibleWith_003EP);
		}
	}
}
