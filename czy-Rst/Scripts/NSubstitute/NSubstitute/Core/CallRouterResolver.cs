using System;
using NSubstitute.Exceptions;

namespace NSubstitute.Core
{
	public class CallRouterResolver : ICallRouterResolver
	{
		public ICallRouter ResolveFor(object substitute)
		{
			if (substitute != null)
			{
				if (!(substitute is ICallRouterProvider callRouterProvider))
				{
					if (substitute is Delegate { Target: ICallRouterProvider target })
					{
						return target.GetCallRouter();
					}
					throw new NotASubstituteException();
				}
				return callRouterProvider.GetCallRouter();
			}
			throw new NullSubstituteReferenceException();
		}
	}
}
