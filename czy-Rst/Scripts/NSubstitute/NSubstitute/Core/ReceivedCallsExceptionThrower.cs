using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute.Core.Arguments;
using NSubstitute.Exceptions;
using NSubstitute.ReceivedExtensions;

namespace NSubstitute.Core
{
	public class ReceivedCallsExceptionThrower : IReceivedCallsExceptionThrower
	{
		public void Throw(ICallSpecification callSpecification, IEnumerable<ICall> matchingCalls, IEnumerable<ICall> nonMatchingCalls, Quantity requiredQuantity)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(string.Format("Expected to receive {0} matching:\n\t{1}", requiredQuantity.Describe("call", "calls"), callSpecification));
			AppendMatchingCalls(callSpecification, matchingCalls, stringBuilder);
			if (requiredQuantity.RequiresMoreThan(matchingCalls))
			{
				AppendNonMatchingCalls(callSpecification, nonMatchingCalls, stringBuilder);
			}
			throw new ReceivedCallsException(stringBuilder.ToString());
		}

		private void AppendNonMatchingCalls(ICallSpecification callSpecification, IEnumerable<ICall> nonMatchingCalls, StringBuilder builder)
		{
			if (nonMatchingCalls.Any())
			{
				int num = nonMatchingCalls.Count();
				builder.AppendLine(string.Format("Received {0} non-matching {1} (non-matching arguments indicated with '*' characters):", num, (num == 1) ? "call" : "calls"));
				WriteCallsWithRespectToCallSpec(callSpecification, nonMatchingCalls, builder);
			}
		}

		private void AppendMatchingCalls(ICallSpecification callSpecification, IEnumerable<ICall> matchingCalls, StringBuilder builder)
		{
			int num = matchingCalls.Count();
			if (num == 0)
			{
				builder.AppendLine("Actually received no matching calls.");
				return;
			}
			builder.AppendLine(string.Format("Actually received {0} matching {1}:", num, (num == 1) ? "call" : "calls"));
			WriteCallsWithRespectToCallSpec(callSpecification, matchingCalls, builder);
		}

		private void WriteCallsWithRespectToCallSpec(ICallSpecification callSpecification, IEnumerable<ICall> relatedCalls, StringBuilder builder)
		{
			foreach (ICall relatedCall in relatedCalls)
			{
				builder.AppendFormat("\t{0}\n", callSpecification.Format(relatedCall));
				string text = DescribeNonMatches(relatedCall, callSpecification).Trim();
				if (!string.IsNullOrEmpty(text))
				{
					builder.AppendFormat("\t\t{0}\n", text.Replace("\n", "\n\t\t"));
				}
			}
		}

		private string DescribeNonMatches(ICall call, ICallSpecification callSpecification)
		{
			IEnumerable<string> values = from x in callSpecification.NonMatchingArguments(call)
				select x.DescribeNonMatch() into x
				where !string.IsNullOrEmpty(x)
				select x;
			return string.Join("\n", values);
		}
	}
}
