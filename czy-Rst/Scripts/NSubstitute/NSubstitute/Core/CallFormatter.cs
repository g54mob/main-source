using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NSubstitute.Core
{
	public class CallFormatter : IMethodInfoFormatter
	{
		private readonly IEnumerable<IMethodInfoFormatter> _methodInfoFormatters;

		internal static IMethodInfoFormatter Default { get; } = new CallFormatter();

		public CallFormatter()
		{
			_methodInfoFormatters = new IMethodInfoFormatter[4]
			{
				new PropertyCallFormatter(),
				new EventCallFormatter(EventCallFormatter.IsSubscription),
				new EventCallFormatter(EventCallFormatter.IsUnsubscription),
				new MethodFormatter()
			};
		}

		public bool CanFormat(MethodInfo methodInfo)
		{
			return true;
		}

		public string Format(MethodInfo methodInfoOfCall, IEnumerable<string> formattedArguments)
		{
			return _methodInfoFormatters.First((IMethodInfoFormatter x) => x.CanFormat(methodInfoOfCall)).Format(methodInfoOfCall, formattedArguments);
		}
	}
}
