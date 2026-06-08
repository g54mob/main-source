using System;
using System.Collections.Generic;
using System.Reflection;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Core
{
	public class ArgumentSpecificationDequeue : IArgumentSpecificationDequeue
	{
		private static readonly IArgumentSpecification[] EmptySpecifications = new IArgumentSpecification[0];

		private readonly Func<IList<IArgumentSpecification>> _dequeueAllQueuedArgSpecs;

		public ArgumentSpecificationDequeue(Func<IList<IArgumentSpecification>> dequeueAllQueuedArgSpecs)
		{
			_dequeueAllQueuedArgSpecs = dequeueAllQueuedArgSpecs;
		}

		public IList<IArgumentSpecification> DequeueAllArgumentSpecificationsForMethod(int parametersCount)
		{
			if (parametersCount == 0)
			{
				return EmptySpecifications;
			}
			return _dequeueAllQueuedArgSpecs();
		}

		public IList<IArgumentSpecification> DequeueAllArgumentSpecificationsForMethod(MethodInfo methodInfo)
		{
			return DequeueAllArgumentSpecificationsForMethod(methodInfo.GetParameters().Length);
		}
	}
}
