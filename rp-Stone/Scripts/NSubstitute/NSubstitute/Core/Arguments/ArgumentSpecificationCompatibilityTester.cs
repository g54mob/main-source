using System;

namespace NSubstitute.Core.Arguments
{
	public class ArgumentSpecificationCompatibilityTester : IArgumentSpecificationCompatibilityTester
	{
		private readonly IDefaultChecker _defaultChecker;

		public ArgumentSpecificationCompatibilityTester(IDefaultChecker defaultChecker)
		{
			_defaultChecker = defaultChecker;
		}

		public bool IsSpecificationCompatible(IArgumentSpecification specification, object? argumentValue, Type argumentType)
		{
			Type forType = specification.ForType;
			if (AreTypesCompatible(argumentType, forType))
			{
				return IsProvidedArgumentTheOneWeWouldGetUsingAnArgSpecForThisType(argumentValue, forType);
			}
			return false;
		}

		private bool IsProvidedArgumentTheOneWeWouldGetUsingAnArgSpecForThisType(object? argument, Type typeArgSpecIsFor)
		{
			return _defaultChecker.IsDefault(argument, typeArgSpecIsFor);
		}

		private bool AreTypesCompatible(Type argumentType, Type typeArgSpecIsFor)
		{
			if (!argumentType.IsAssignableFrom(typeArgSpecIsFor))
			{
				if (argumentType.IsByRef && !typeArgSpecIsFor.IsByRef)
				{
					return argumentType.IsAssignableFrom(typeArgSpecIsFor.MakeByRefType());
				}
				return false;
			}
			return true;
		}
	}
}
