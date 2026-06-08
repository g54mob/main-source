using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NSubstitute.Exceptions;

namespace NSubstitute.Core.Arguments
{
	public class ArgumentSpecificationsFactory : IArgumentSpecificationsFactory
	{
		private readonly IArgumentSpecificationFactory _argumentSpecificationFactory;

		private readonly ISuppliedArgumentSpecificationsFactory _suppliedArgumentSpecificationsFactory;

		public ArgumentSpecificationsFactory(IArgumentSpecificationFactory argumentSpecificationFactory, ISuppliedArgumentSpecificationsFactory suppliedArgumentSpecificationsFactory)
		{
			_argumentSpecificationFactory = argumentSpecificationFactory;
			_suppliedArgumentSpecificationsFactory = suppliedArgumentSpecificationsFactory;
		}

		public IEnumerable<IArgumentSpecification> Create(IList<IArgumentSpecification> argumentSpecs, object?[] arguments, IParameterInfo[] parameterInfos, MethodInfo methodInfo, MatchArgs matchArgs)
		{
			ISuppliedArgumentSpecifications suppliedArgumentSpecifications = _suppliedArgumentSpecificationsFactory.Create(argumentSpecs);
			List<IArgumentSpecification> list = new List<IArgumentSpecification>();
			for (int i = 0; i < arguments.Length; i++)
			{
				object argument = arguments[i];
				IParameterInfo parameterInfo = parameterInfos[i];
				try
				{
					list.Add(_argumentSpecificationFactory.Create(argument, parameterInfo, suppliedArgumentSpecifications));
				}
				catch (AmbiguousArgumentsException ex) when (ex.ContainsDefaultMessage)
				{
					IEnumerable<IArgumentSpecification> enumerable = list;
					if (ex.Data["NON_REPORTED_RESOLVED_SPECIFICATIONS"] is IEnumerable<IArgumentSpecification> second)
					{
						enumerable = enumerable.Concat(second);
					}
					throw new AmbiguousArgumentsException(methodInfo, arguments, enumerable, argumentSpecs);
				}
			}
			IEnumerable<IArgumentSpecification> enumerable2 = suppliedArgumentSpecifications.DequeueRemaining();
			if (enumerable2.Any())
			{
				throw new RedundantArgumentMatcherException(enumerable2, argumentSpecs);
			}
			if (matchArgs != MatchArgs.Any)
			{
				return list;
			}
			return ConvertToMatchAnyValue(list);
		}

		private static IEnumerable<IArgumentSpecification> ConvertToMatchAnyValue(IEnumerable<IArgumentSpecification> specs)
		{
			return specs.Select((IArgumentSpecification x) => x.CreateCopyMatchingAnyArgOfType(x.ForType)).ToArray();
		}
	}
}
