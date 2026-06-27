using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NSubstitute.Core
{
	public class MethodFormatter : IMethodInfoFormatter
	{
		public bool CanFormat(MethodInfo methodInfo)
		{
			return true;
		}

		public string Format(MethodInfo methodInfo, IEnumerable<string> arguments)
		{
			string text = string.Join(", ", arguments);
			return methodInfo.Name + FormatGenericType(methodInfo) + "(" + text + ")";
		}

		private static string FormatGenericType(MethodInfo methodInfoOfCall)
		{
			if (!methodInfoOfCall.IsGenericMethod)
			{
				return string.Empty;
			}
			Type[] genericArguments = methodInfoOfCall.GetGenericArguments();
			return "<" + string.Join(", ", genericArguments.Select((Type x) => x.GetNonMangledTypeName())) + ">";
		}
	}
}
