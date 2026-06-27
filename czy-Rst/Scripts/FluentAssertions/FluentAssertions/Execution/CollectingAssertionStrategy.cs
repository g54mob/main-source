using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace FluentAssertions.Execution
{
	internal class CollectingAssertionStrategy : IAssertionStrategy
	{
		private readonly List<string> failureMessages = new List<string>();

		public IEnumerable<string> FailureMessages => failureMessages;

		public IEnumerable<string> DiscardFailures()
		{
			string[] result = failureMessages.ToArray();
			failureMessages.Clear();
			return result;
		}

		public void ThrowIfAny(IDictionary<string, object> context)
		{
			if (failureMessages.Count <= 0)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilderExtensions.AppendJoin(stringBuilder, Environment.NewLine, failureMessages).AppendLine();
			if (context.Any())
			{
				foreach (KeyValuePair<string, object> item in context)
				{
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "\nWith {0}:\n{1}", item.Key, item.Value);
				}
			}
			AssertionEngine.TestFramework.Throw(stringBuilder.ToString());
		}

		public void HandleFailure(string message)
		{
			failureMessages.Add(message);
		}
	}
}
