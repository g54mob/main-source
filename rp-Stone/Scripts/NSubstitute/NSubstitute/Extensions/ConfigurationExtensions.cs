using NSubstitute.Core;
using NSubstitute.Exceptions;

namespace NSubstitute.Extensions
{
	public static class ConfigurationExtensions
	{
		public static T Configure<T>(this T substitute) where T : class
		{
			if (substitute == null)
			{
				throw new NullSubstituteReferenceException();
			}
			ISubstitutionContext current = SubstitutionContext.Current;
			ICallRouter callRouterFor = current.GetCallRouterFor(substitute);
			current.ThreadContext.SetNextRoute(callRouterFor, current.RouteFactory.RecordCallSpecification);
			return substitute;
		}
	}
}
