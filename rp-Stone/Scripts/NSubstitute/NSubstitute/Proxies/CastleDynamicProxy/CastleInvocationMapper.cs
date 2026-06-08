using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using NSubstitute.Core;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Proxies.CastleDynamicProxy
{
	public class CastleInvocationMapper
	{
		private readonly ICallFactory _callFactory;

		private readonly IArgumentSpecificationDequeue _argSpecificationDequeue;

		public CastleInvocationMapper(ICallFactory callFactory, IArgumentSpecificationDequeue argSpecificationDequeue)
		{
			_callFactory = callFactory;
			_argSpecificationDequeue = argSpecificationDequeue;
		}

		public virtual ICall Map(IInvocation castleInvocation)
		{
			Func<object> baseMethod = null;
			if (castleInvocation.InvocationTarget != null && castleInvocation.MethodInvocationTarget.IsVirtual && !castleInvocation.MethodInvocationTarget.IsAbstract && !castleInvocation.MethodInvocationTarget.IsFinal)
			{
				baseMethod = CreateBaseResultInvocation(castleInvocation);
			}
			IList<IArgumentSpecification> argumentSpecifications = _argSpecificationDequeue.DequeueAllArgumentSpecificationsForMethod(castleInvocation.Arguments.Length);
			return _callFactory.Create(castleInvocation.Method, castleInvocation.Arguments, castleInvocation.Proxy, argumentSpecifications, baseMethod);
		}

		private static Func<object> CreateBaseResultInvocation(IInvocation invocation)
		{
			Func<object> valueFactory = delegate
			{
				invocation.Proceed();
				return invocation.ReturnValue;
			};
			Lazy<object> result = new Lazy<object>(valueFactory);
			return () => result.Value;
		}
	}
}
