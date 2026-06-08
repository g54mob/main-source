using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NSubstitute.Core;
using NSubstitute.Core.Arguments;

namespace NSubstitute.Exceptions
{
	public class AmbiguousArgumentsException : SubstituteException
	{
		internal const string NonReportedResolvedSpecificationsKey = "NON_REPORTED_RESOLVED_SPECIFICATIONS";

		private const string DefaultErrorMessage = "Cannot determine argument specifications to use. Please use specifications for all arguments of the same type.";

		private const string TabPadding = "    ";

		internal bool ContainsDefaultMessage { get; }

		public AmbiguousArgumentsException()
			: base("Cannot determine argument specifications to use. Please use specifications for all arguments of the same type.")
		{
			ContainsDefaultMessage = true;
		}

		public AmbiguousArgumentsException(string message)
			: base(message)
		{
		}

		public AmbiguousArgumentsException(MethodInfo method, IEnumerable<object?> invocationArguments, IEnumerable<IArgumentSpecification> matchedSpecifications, IEnumerable<IArgumentSpecification> allSpecifications)
			: this(BuildExceptionMessage(method, invocationArguments, matchedSpecifications, allSpecifications))
		{
		}

		private static string BuildExceptionMessage(MethodInfo method, IEnumerable<object?> invocationArguments, IEnumerable<IArgumentSpecification> matchedSpecifications, IEnumerable<IArgumentSpecification> allSpecifications)
		{
			string text = null;
			string text2 = null;
			string text3 = null;
			if (CallFormatter.Default.CanFormat(method))
			{
				object[] array = invocationArguments.ToArray();
				if (method.GetParameters().Last().IsParams() && array.Last() is IEnumerable source)
				{
					array = array.Take(array.Length - 1).Concat(source.Cast<object>()).ToArray();
				}
				text = CallFormatter.Default.Format(method, FormatMethodParameterTypes(method.GetParameters()));
				text2 = CallFormatter.Default.Format(method, FormatMethodArguments(array));
				text3 = CallFormatter.Default.Format(method, PadNonMatchedSpecifications(matchedSpecifications, array));
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Cannot determine argument specifications to use. Please use specifications for all arguments of the same type.");
			if (text != null)
			{
				stringBuilder.AppendLine("Method signature:");
				stringBuilder.Append("    ");
				stringBuilder.AppendLine(text);
			}
			if (text2 != null)
			{
				stringBuilder.AppendLine("Method arguments (possible arg matchers are indicated with '*'):");
				stringBuilder.Append("    ");
				stringBuilder.AppendLine(text2);
			}
			stringBuilder.AppendLine("All queued specifications:");
			stringBuilder.AppendLine(FormatSpecifications(allSpecifications));
			if (text3 != null)
			{
				stringBuilder.AppendLine("Matched argument specifications:");
				stringBuilder.Append("    ");
				stringBuilder.AppendLine(text3);
			}
			return stringBuilder.ToString();
		}

		private static IEnumerable<string> FormatMethodParameterTypes(IEnumerable<ParameterInfo> parameters)
		{
			return parameters.Select(delegate(ParameterInfo p)
			{
				Type parameterType = p.ParameterType;
				if (p.IsOut)
				{
					return "out " + parameterType.GetElementType().GetNonMangledTypeName();
				}
				if (parameterType.IsByRef)
				{
					return "ref " + parameterType.GetElementType().GetNonMangledTypeName();
				}
				return p.IsParams() ? ("params " + parameterType.GetNonMangledTypeName()) : parameterType.GetNonMangledTypeName();
			});
		}

		private static IEnumerable<string> FormatMethodArguments(IEnumerable<object?> arguments)
		{
			DefaultChecker defaultChecker = new DefaultChecker(new DefaultForType());
			return arguments.Select(delegate(object arg)
			{
				bool highlight = arg == null || defaultChecker.IsDefault(arg, arg.GetType());
				return ArgumentFormatter.Default.Format(arg, highlight);
			});
		}

		private static IEnumerable<string> PadNonMatchedSpecifications(IEnumerable<IArgumentSpecification> matchedSpecifications, IEnumerable<object?> allArguments)
		{
			string[] array = matchedSpecifications.Select((IArgumentSpecification x) => x.ToString() ?? string.Empty).ToArray();
			int count = allArguments.Count() - array.Length;
			IEnumerable<string> second = Enumerable.Repeat("???", count);
			return array.Concat(second);
		}

		private static string FormatSpecifications(IEnumerable<IArgumentSpecification> specifications)
		{
			return string.Join(Environment.NewLine, specifications.Select((IArgumentSpecification spec) => "    " + spec.ToString()));
		}
	}
}
