using System;
using System.Collections.Generic;
using System.Reflection;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Core
{
	public class ArgumentSpecificationDequeue : IArgumentSpecificationDequeue
	{
		private static readonly IArgumentSpecification[] EmptySpecifications = Array.Empty<IArgumentSpecification>();

		public ArgumentSpecificationDequeue(Func<IList<IArgumentSpecification>> dequeueAllQueuedArgSpecs)
		{
			_003CdequeueAllQueuedArgSpecs_003EP = dequeueAllQueuedArgSpecs;
			base._002Ector();
		}

		public IList<IArgumentSpecification> DequeueAllArgumentSpecificationsForMethod(int parametersCount)
		{
			if (parametersCount == 0)
			{
				return EmptySpecifications;
			}
			return _003CdequeueAllQueuedArgSpecs_003EP();
		}

		public IList<IArgumentSpecification> DequeueAllArgumentSpecificationsForMethod(MethodInfo methodInfo)
		{
			return DequeueAllArgumentSpecificationsForMethod(methodInfo.GetParameters().Length);
		}
	}
}
