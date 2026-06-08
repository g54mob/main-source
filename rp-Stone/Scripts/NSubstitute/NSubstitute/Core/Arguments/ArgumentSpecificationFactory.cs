using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute.Exceptions;

namespace NSubstitute.Core.Arguments
{
	public class ArgumentSpecificationFactory : IArgumentSpecificationFactory
	{
		private class ParameterInfoFromType : IParameterInfo
		{
			public Type ParameterType { get; }

			public bool IsParams => false;

			public bool IsOptional => false;

			public bool IsOut => false;

			public ParameterInfoFromType(Type parameterType)
			{
				ParameterType = parameterType;
			}
		}

		public IArgumentSpecification Create(object? argument, IParameterInfo parameterInfo, ISuppliedArgumentSpecifications suppliedArgumentSpecifications)
		{
			if (!parameterInfo.IsParams)
			{
				return CreateSpecFromNonParamsArg(argument, parameterInfo, suppliedArgumentSpecifications);
			}
			return CreateSpecFromParamsArg(argument, parameterInfo, suppliedArgumentSpecifications);
		}

		private IArgumentSpecification CreateSpecFromNonParamsArg(object? argument, IParameterInfo parameterInfo, ISuppliedArgumentSpecifications suppliedArgumentSpecifications)
		{
			if (suppliedArgumentSpecifications.IsNextFor(argument, parameterInfo.ParameterType))
			{
				return suppliedArgumentSpecifications.Dequeue();
			}
			if (!suppliedArgumentSpecifications.AnyFor(argument, parameterInfo.ParameterType) || parameterInfo.IsOptional || parameterInfo.IsOut)
			{
				return new ArgumentSpecification(parameterInfo.ParameterType, new EqualsArgumentMatcher(argument));
			}
			throw new AmbiguousArgumentsException();
		}

		private IArgumentSpecification CreateSpecFromParamsArg(object? argument, IParameterInfo parameterInfo, ISuppliedArgumentSpecifications suppliedArgumentSpecifications)
		{
			if (suppliedArgumentSpecifications.IsNextFor(argument, parameterInfo.ParameterType))
			{
				return suppliedArgumentSpecifications.Dequeue();
			}
			if (suppliedArgumentSpecifications.AnyFor(argument, parameterInfo.ParameterType))
			{
				throw new AmbiguousArgumentsException();
			}
			if (argument == null)
			{
				return new ArgumentSpecification(parameterInfo.ParameterType, new EqualsArgumentMatcher(null));
			}
			if (!(argument is Array source))
			{
				throw new SubstituteInternalException("Expected to get array argument, but got argument of '" + argument.GetType().FullName + "' type.");
			}
			IEnumerable<IArgumentSpecification> argumentSpecifications = UnwrapParamsArguments(source.Cast<object>(), parameterInfo.ParameterType.GetElementType(), suppliedArgumentSpecifications);
			return new ArgumentSpecification(parameterInfo.ParameterType, new ArrayContentsArgumentMatcher(argumentSpecifications));
		}

		private IEnumerable<IArgumentSpecification> UnwrapParamsArguments(IEnumerable<object?> args, Type paramsElementType, ISuppliedArgumentSpecifications suppliedArgumentSpecifications)
		{
			ParameterInfoFromType parameterInfo = new ParameterInfoFromType(paramsElementType);
			List<IArgumentSpecification> list = new List<IArgumentSpecification>();
			foreach (object arg in args)
			{
				try
				{
					list.Add(CreateSpecFromNonParamsArg(arg, parameterInfo, suppliedArgumentSpecifications));
				}
				catch (AmbiguousArgumentsException ex)
				{
					ex.Data["NON_REPORTED_RESOLVED_SPECIFICATIONS"] = list;
					throw;
				}
			}
			return list;
		}
	}
}
