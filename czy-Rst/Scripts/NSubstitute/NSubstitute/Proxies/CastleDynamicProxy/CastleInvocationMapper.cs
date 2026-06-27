using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using NSubstitute.Core;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Proxies.CastleDynamicProxy
{
	public class CastleInvocationMapper
	{
		public CastleInvocationMapper(ICallFactory callFactory, IArgumentSpecificationDequeue argSpecificationDequeue)
		{
			_003CcallFactory_003EP = callFactory;
			_003CargSpecificationDequeue_003EP = argSpecificationDequeue;
			base._002Ector();
		}

		public virtual ICall Map(IInvocation castleInvocation)
		{
			Func<object> baseMethod = null;
			if (castleInvocation.InvocationTarget != null && castleInvocation.MethodInvocationTarget.IsVirtual && !castleInvocation.MethodInvocationTarget.IsAbstract)
			{
				baseMethod = CreateBaseResultInvocation(castleInvocation);
			}
			IList<IArgumentSpecification> argumentSpecifications = _003CargSpecificationDequeue_003EP.DequeueAllArgumentSpecificationsForMethod(castleInvocation.Arguments.Length);
			return _003CcallFactory_003EP.Create(castleInvocation.Method, castleInvocation.Arguments, castleInvocation.Proxy, argumentSpecifications, baseMethod);
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
