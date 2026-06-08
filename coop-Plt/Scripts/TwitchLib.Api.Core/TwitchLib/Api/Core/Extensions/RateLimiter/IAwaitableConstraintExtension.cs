using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Core.RateLimiter;

namespace TwitchLib.Api.Core.Extensions.RateLimiter
{
	public static class IAwaitableConstraintExtension
	{
		public static IAwaitableConstraint Compose(this IAwaitableConstraint ac1, IAwaitableConstraint ac2)
		{
			IAwaitableConstraint result;
			if (ac1 != ac2)
			{
				IAwaitableConstraint awaitableConstraint = new ComposedAwaitableConstraint(ac1, ac2);
				result = awaitableConstraint;
			}
			else
			{
				result = ac1;
			}
			return result;
		}
	}
}
